using System.Diagnostics;
using Dapper;
using MySql.Data.MySqlClient;
using PAB2.Generated;

namespace PAB2
{
    public partial class Form1 : Form
    {
        string connectionString =
            "server=localhost;userid=root;password=71Bs3*VIkvv)s3HyDEWqM@6**6P]d!8K;database=pab2";

        public Form1()
        {
            InitializeComponent();
            RefreshTables();
        }

        public async void RefreshTables()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                //pobranie przedmiotow gracza
                string playerQuery =
                    "SELECT item.Name, Quantity FROM playeritem INNER JOIN item ON item.ID = playeritem.ItemID WHERE playeritem.PlayerID = @PlayerID";
                var playerItems = await connection.QueryAsync(playerQuery, new { PlayerID = 1 });
                dataGridView1.DataSource = playerItems;

                //pobranie przedmiotow sklepu
                string shopQuery =
                    "SELECT item.Name, Quantity FROM shopItem INNER JOIN item ON item.ID = shopitem.ItemID WHERE shopitem.ShopID = @ShopID";
                var shopItems = await connection.QueryAsync(shopQuery, new { ShopID = 1 });
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

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        //odejmowanie graczowi
                        var playerItem = connection.QueryFirstOrDefault<PlayerItem>(@"
                            UPDATE playeritem SET Quantity -= @playerItemQuantityNumber
                            FROM playeritem INNER JOIN Item ON playeritem.itemID = item.ID
                            WHERE playeritem.PlayerID = 1 AND item.Name = @playerItemNameText",
                            new { PlayerId = 1, PlayerItemNameText = playerItemNameText },
                            transaction
                        );

                        playerItem.Quantity -= playerItemQuantityNumber;

                        //dodawanie sklepowi
                        var shopItem = connection.QueryFirstOrDefault<ShopItem>(@"
                            UPDATE shopitem SET Quantity += @playerItemQuantityNumber
                            FROM shopitem INNER JOIN item ON shopitem.ItemID = item.ID
                            INNER JOIN playeritem ON playeritem.ItemID = item.ID WHERE shopitem.ShopID = 1
                            AND item.Name = @playerItemNameText",
                            new { ShopId = 1, PlayerItemNameText = playerItemNameText },
                            transaction
                        );

                        shopItem.Quantity += playerItemQuantityNumber;

                        //odejmowanie sklepowi
                        shopItem = connection.QueryFirstOrDefault<ShopItem>(@"
                            UPDATE shopitem SET Quantity -= @shopItemQuantityNumber
                            FROM shopitem INNER JOIN item ON shopitem.ItemID = item.ID
                            WHERE shopitem.ShopID = 1 AND item.Name = @shopItemNameText",
                            new { ShopId = 1, ShopItemNameText = shopItemNameText },
                            transaction
                        );

                        shopItem.Quantity -= shopItemQuantityNumber;

                        //dodawanie graczowi
                        playerItem = connection.QueryFirstOrDefault<PlayerItem>(@"
                            UPDATE playeritem SET Quantity += @shopItemQuantityNumber
                            FROM playeritem INNER JOIN item ON playeritem.ItemID = item.ID
                            INNER JOIN shopitem ON shopitem.ItemID = item.ID WHERE playeritem.PlayerID = 1
                            AND item.Name = @shopItemNameText",
                            new { PlayerId = 1, ShopItemNameText = shopItemNameText },
                            transaction
                        );

                        playerItem.Quantity += shopItemQuantityNumber;

                        connection.Execute(@"
                            UPDATE playeritem SET Quantity = @PlayerItemQuantity WHERE Id = @PlayerItemId;
                            UPDATE shopitem SET Quantity = @ShopItemQuantity WHERE Id = @ShopItemId;",
                            new
                            {
                                PlayerItemQuantity = playerItem.Quantity,
                                PlayerItemId = playerItem.ItemId,
                                ShopItemQuantity = shopItem.Quantity,
                                ShopItemId = shopItem.ItemId
                            },
                            transaction
                        );

                        transaction.Commit();
                    }
                }
            }
            catch
            {
                errorText.Text = "Błąd";
            }

            TimeSpan queryTime = stopwatch.Elapsed;
            Console.WriteLine("Komenda wykonana w {0} milisekund.", queryTime.TotalMilliseconds);

            RefreshTables();
        }
    }
}