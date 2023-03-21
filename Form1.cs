using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PAB2.Generated;

namespace PAB2
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=.;Initial Catalog=PAB2;Integrated Security=True;TrustServerCertificate=True";

        public Form1()
        {
            InitializeComponent();
            RefreshTables();
        }

        public async void RefreshTables()
        {
            using (var context = new Pab2Context(connectionString))
            {
                //pobranie przedmiotow gracza
                var playerItems = await context.PlayerItems
                    .Where(p => p.PlayerId == 1)
                    .Select(p => new { p.Item.Name, p.Quantity })
                    .ToListAsync();

                dataGridView1.DataSource = playerItems;

                //pobranie przedmiotow sklepu
                var shopItems = await context.ShopItems
                    .Where(s => s.ShopId == 1)
                    .Select(s => new { s.Item.Name, s.Quantity })
                    .ToListAsync();

                dataGridView2.DataSource = shopItems;
            }
        }

        private void exchangeButton_Click(object sender, EventArgs e)
        {
            errorText.Text = "";
            string playerItemNameText = playerItemName.Text;
            int playerItemQuantityNumber = Convert.ToInt32(playerItemQuantity.Value);
            string shopItemNameText = shopItemName.Text;
            int shopItemQuantityNumber = Convert.ToInt32(shopItemQuantity.Value);

            if (playerItemNameText == "" && shopItemNameText == "")
            {
                errorText.Text = "Nie podano przedmiotów do wymiany.";
                return;
            }

            try
            {
                using (var context = new Pab2Context(connectionString))
                {
                    using (var contextTransaction = context.Database.BeginTransaction())
                    {
                        //odejmowanie graczowi
                        var playerItem = context.PlayerItems
                        .Include(p => p.Item)
                        .Where(p => p.PlayerId == 1 && p.Item.Name == playerItemNameText)
                        .SingleOrDefault();

                        playerItem.Quantity -= playerItemQuantityNumber;

                        //dodawanie sklepowi
                        var shopItem = context.ShopItems
                            .Include(s => s.Item)
                            .Where(s => s.ShopId == 1 && s.Item.Name == playerItemNameText)
                            .SingleOrDefault();

                        shopItem.Quantity += playerItemQuantityNumber;

                        //odejmowanie sklepowi
                        shopItem = context.ShopItems
                            .Include(s => s.Item)
                            .Where(s => s.ShopId == 1 && s.Item.Name == shopItemNameText)
                            .SingleOrDefault();

                        shopItem.Quantity -= shopItemQuantityNumber;

                        //dodawanie graczowi
                        playerItem = context.PlayerItems
                            .Include(p => p.Item)
                            .Where(p => p.PlayerId == 1 && p.Item.Name == shopItemNameText)
                            .SingleOrDefault();

                        playerItem.Quantity += shopItemQuantityNumber;

                        context.SaveChanges();
                        contextTransaction.Commit();
                    }
                }
            }
            catch (SqlException ex)
            {
                errorText.Text = "Błąd serwera";
            }
            catch (Exception ex)
            {
                errorText.Text = "Błąd";
            }
            
            RefreshTables();
        }
    }
}