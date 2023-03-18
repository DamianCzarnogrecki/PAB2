using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAB2
{
    public partial class Form1 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PAB2"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
            RefreshTables();
        }

        public async void RefreshTables()
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    //zwrocenie przedmiotow gracza
                    command.CommandText = "SELECT Item.Name, Quantity FROM PlayerItem INNER JOIN Item ON Item.ID = PlayerItem.ItemID WHERE PlayerItem.PlayerID = @PlayerID";
                    command.Parameters.AddWithValue("@PlayerID", 1);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        await Task.Run(() => adapter.Fill(dataSet));
                        dataGridView1.DataSource = dataSet.Tables[0];
                    }

                    //zwrocenie przedmiotow sklepu
                    command.CommandText = "SELECT Item.Name, Quantity FROM ShopItem INNER JOIN Item ON Item.ID = ShopItem.ItemID WHERE ShopItem.ShopID = @ShopID";
                    command.Parameters.AddWithValue("@ShopID", 1);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        await Task.Run(() => adapter.Fill(dataSet));
                        dataGridView2.DataSource = dataSet.Tables[0];
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction = connection.BeginTransaction("Wymiana gracz-sklep");

                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    //odejmowanie graczowi
                    command.CommandText = "UPDATE PlayerItem SET Quantity -= @playerItemQuantityNumber FROM PlayerItem INNER JOIN Item ON PlayerItem.ItemID = Item.ID WHERE PlayerItem.PlayerID = 1 AND Item.Name = @playerItemNameText";
                    command.Parameters.AddWithValue("@playerItemQuantityNumber", playerItemQuantityNumber);
                    command.Parameters.AddWithValue("@playerItemNameText", playerItemNameText);
                    command.ExecuteNonQuery();

                    //dodawanie sklepowi
                    command.CommandText = "UPDATE ShopItem SET Quantity += @playerItemQuantityNumber FROM ShopItem INNER JOIN Item ON ShopItem.ItemID = Item.ID INNER JOIN PlayerItem ON PlayerItem.ItemID = Item.ID WHERE ShopItem.ShopID = 1 AND Item.Name = @playerItemNameText";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@playerItemQuantityNumber", playerItemQuantityNumber);
                    command.Parameters.AddWithValue("@playerItemNameText", playerItemNameText);
                    command.ExecuteNonQuery();

                    //odejmowanie sklepowi
                    command.CommandText = "UPDATE ShopItem SET Quantity -= @shopItemQuantityNumber FROM ShopItem INNER JOIN Item ON ShopItem.ItemID = Item.ID WHERE ShopItem.ShopID = 1 AND Item.Name = @shopItemNameText";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@shopItemQuantityNumber", shopItemQuantityNumber);
                    command.Parameters.AddWithValue("@shopItemNameText", shopItemNameText);
                    command.ExecuteNonQuery();

                    //dodawanie graczowi
                    command.CommandText = "UPDATE PlayerItem SET Quantity += @shopItemQuantityNumber FROM PlayerItem INNER JOIN Item ON PlayerItem.ItemID = Item.ID INNER JOIN ShopItem ON ShopItem.ItemID = Item.ID WHERE PlayerItem.PlayerID = 1 AND Item.Name = @shopItemNameText";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@shopItemQuantityNumber", shopItemQuantityNumber);
                    command.Parameters.AddWithValue("@shopItemNameText", shopItemNameText);
                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    errorText.Text = "Błąd serwera";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    errorText.Text = "Błąd";
                }
            }
            RefreshTables();
            }
        }
    }