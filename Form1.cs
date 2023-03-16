using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PAB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RefreshTables();
        }

        public void RefreshTables()
        {
            string sql = "SELECT Item.Name, Quantity FROM PlayerItem INNER JOIN Item ON Item.ID = PlayerItem.ItemID WHERE PlayerItem.PlayerID = 1";
            SqlCommand command = new SqlCommand(sql, new SqlConnection(ConfigurationManager.ConnectionStrings["PAB2"].ConnectionString));
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];

            sql = "SELECT Item.Name, Quantity FROM ShopItem INNER JOIN Item ON Item.ID = ShopItem.ItemID WHERE ShopItem.ShopID = 1";
            command = new SqlCommand(sql, new SqlConnection(ConfigurationManager.ConnectionStrings["PAB2"].ConnectionString));
            adapter = new SqlDataAdapter(command);
            dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorText.Text = "";
            string playerItemNameText = playerItemName.Text;
            int playerItemQuantityNumber = Convert.ToInt32(playerItemQuantity.Value);
            string shopItemNameText = shopItemName.Text;
            int shopItemQuantityNumber = Convert.ToInt32(shopItemQuantity.Value);

            if(playerItemNameText == "" && shopItemNameText == "")
            {
                errorText.Text += "Nie podano przedmiotów do wymiany.";
                return;
            }
            //gracz
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PAB2"].ConnectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("SELECT Quantity FROM PlayerItem INNER JOIN Item ON PlayerItem.ItemID = Item.ID WHERE PlayerItem.PlayerID = 1 AND Item.Name = @playerItemNameText", connection);
                    command.Parameters.AddWithValue("@playerItemNameText", playerItemNameText);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int? returnedQuantity = reader.GetInt32(0);
                        if(returnedQuantity.HasValue && returnedQuantity >= playerItemQuantityNumber)
                        {
                            reader.Close();
                            //wymiana
                            try
                            {
                                int chosenItemExists = -1;
                                int chosenID = 0;
                                //odejmowanie graczowi
                                command = new SqlCommand("UPDATE PlayerItem SET Quantity -= @playerItemQuantityNumber FROM PlayerItem INNER JOIN Item ON PlayerItem.ItemID = Item.ID WHERE PlayerItem.PlayerID = 1 AND Item.Name = @playerItemNameText", connection);
                                command.Parameters.AddWithValue("@playerItemQuantityNumber", playerItemQuantityNumber);
                                command.Parameters.AddWithValue("@playerItemNameText", playerItemNameText);
                                command.ExecuteNonQuery();
                                Console.WriteLine("gracz - odjęte");

                                //dodawanie sklepowi

                                //SELECT ID ITEMU
                                command = new SqlCommand("SELECT COUNT(ItemID) FROM ShopItem INNER JOIN Item ON Item.ID = ShopItem.ItemID WHERE Item.Name = @playerItemNameText", connection);
                                command.Parameters.AddWithValue("@playerItemNameText", playerItemNameText);
                                reader = command.ExecuteReader();
                                if (reader.Read())
                                {
                                    chosenItemExists = reader.GetInt32(0);
                                }
                                else
                                {
                                    chosenItemExists = -1;
                                }
                                reader.Close();

                                command = new SqlCommand("SELECT ID FROM Item WHERE Item.Name = @playerItemNameText", connection);
                                command.Parameters.AddWithValue("@playerItemNameText", playerItemNameText);
                                reader = command.ExecuteReader();
                                if (reader.Read())
                                {
                                    chosenID = reader.GetInt32(0);
                                }
                                else
                                {
                                    chosenID = 0;
                                }
                                reader.Close();

                                if (chosenItemExists == 1 && chosenID != 0)
                                {
                                    command = new SqlCommand("UPDATE ShopItem SET Quantity += @playerItemQuantityNumber FROM ShopItem INNER JOIN Item ON ShopItem.ItemID = Item.ID INNER JOIN PlayerItem ON PlayerItem.ItemID = Item.ID WHERE ShopItem.ShopID = 1 AND Item.Name = @playerItemNameText", connection);
                                    command.Parameters.AddWithValue("@playerItemQuantityNumber", playerItemQuantityNumber);
                                    command.Parameters.AddWithValue("@playerItemNameText", playerItemNameText);
                                    command.ExecuteNonQuery();
                                    Console.WriteLine("sklep - dodane");
                                }
                                else if(chosenItemExists == 0 && chosenID != 0)
                                {
                                    command = new SqlCommand("INSERT INTO ShopItem (ShopID, ItemID, Quantity) VALUES (1, @chosenID, @playerItemQuantityNumber)", connection);
                                    command.Parameters.AddWithValue("@chosenID", chosenID);
                                    command.Parameters.AddWithValue("@playerItemQuantityNumber", playerItemQuantityNumber);
                                    command.ExecuteNonQuery();
                                    Console.WriteLine("sklep - wstawione");
                                    
                                }
                                else
                                {
                                    errorText.Text += "\n\rBłąd pobrania liczby przedmiotów z bazy (gracz do sklepu).";
                                }
                                
                                chosenItemExists = -1;
                                RefreshTables();
                            }
                            catch(SqlException ex)
                            {
                                errorText.Text += "\n\rBłąd kwerendy przy realizacji wymiany (gracz).";
                            }
                            catch(Exception ex)
                            {
                                errorText.Text += "\n\rBłąd środowiska przy realizacji wymiany (gracz).";
                            }
                            Console.WriteLine("gracz OK");
                        }
                        else
                        {
                            errorText.Text += "\n\rGracz nie posiada tak dużej liczby tych przedmiotów.";
                        }
                    }
                    else
                    {
                        errorText.Text += "\n\rGracz nie posiada takiego przedmiotu.";
                    }
                }
                catch (SqlException ex)
                {
                    errorText.Text += "\n\rWystąpił błąd kwerendy (gracz).";
                }
                catch(Exception ex)
                {
                    errorText.Text += "\n\rWystąpił błąd środowiska (gracz).";
                }
            }

            //sklep
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PAB2"].ConnectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("SELECT Quantity FROM ShopItem INNER JOIN Item ON ShopItem.ItemID = Item.ID WHERE ShopItem.ShopID = 1 AND Item.Name = @shopItemNameText", connection);
                    command.Parameters.AddWithValue("@shopItemNameText", shopItemNameText);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int? returnedQuantity = reader.GetInt32(0);
                        if (returnedQuantity.HasValue && returnedQuantity >= shopItemQuantityNumber)
                        {
                            reader.Close();
                            //wymiana
                            try
                            {
                                int chosenItemExists = -1;
                                int chosenID = 0;
                                //odejmowanie sklepowi
                                command = new SqlCommand("UPDATE ShopItem SET Quantity -= @shopItemQuantityNumber FROM ShopItem INNER JOIN Item ON ShopItem.ItemID = Item.ID WHERE ShopItem.ShopID = 1 AND Item.Name = @shopItemNameText", connection);
                                command.Parameters.AddWithValue("@shopItemQuantityNumber", shopItemQuantityNumber);
                                command.Parameters.AddWithValue("@shopItemNameText", shopItemNameText);
                                command.ExecuteNonQuery();
                                Console.WriteLine("sklep - odjęte");

                                //dodawanie graczowi

                                //SELECT ID ITEMU
                                command = new SqlCommand("SELECT COUNT(ItemID) FROM PlayerItem INNER JOIN Item ON Item.ID = PlayerItem.ItemID WHERE Item.Name = @shopItemNameText", connection);
                                command.Parameters.AddWithValue("@shopItemNameText", shopItemNameText);
                                reader = command.ExecuteReader();
                                if (reader.Read())
                                {
                                    chosenItemExists = reader.GetInt32(0);
                                }
                                else
                                {
                                    chosenItemExists = -1;
                                }
                                reader.Close();

                                command = new SqlCommand("SELECT ID FROM Item WHERE Item.Name = @shopItemNameText", connection);
                                command.Parameters.AddWithValue("@shopItemNameText", shopItemNameText);
                                reader = command.ExecuteReader();
                                if (reader.Read())
                                {
                                    chosenID = reader.GetInt32(0);
                                }
                                else
                                {
                                    chosenID = 0;
                                }
                                reader.Close();

                                if (chosenItemExists == 1 && chosenID != 0)
                                {
                                    command = new SqlCommand("UPDATE PlayerItem SET Quantity += @shopItemQuantityNumber FROM PlayerItem INNER JOIN Item ON PlayerItem.ItemID = Item.ID INNER JOIN ShopItem ON ShopItem.ItemID = Item.ID WHERE PlayerItem.PlayerID = 1 AND Item.Name = @shopItemNameText", connection);
                                    command.Parameters.AddWithValue("@shopItemQuantityNumber", shopItemQuantityNumber);
                                    command.Parameters.AddWithValue("@shopItemNameText", shopItemNameText);
                                    command.ExecuteNonQuery();
                                    Console.WriteLine("gracz - dodane");

                                }
                                else if (chosenItemExists == 0 && chosenID != 0)
                                {
                                    command = new SqlCommand("INSERT INTO PlayerItem (PlayerID, ItemID, Quantity) VALUES (1, @chosenID, @shopItemQuantityNumber)", connection);
                                    command.Parameters.AddWithValue("@chosenID", chosenID);
                                    command.Parameters.AddWithValue("@shopItemQuantityNumber", playerItemQuantityNumber);
                                    command.ExecuteNonQuery();
                                    Console.WriteLine("gracz - wstawione");
                                    
                                }
                                else
                                {
                                    errorText.Text += "\n\rBłąd pobrania liczby przedmiotów z bazy (gracz do sklepu).";
                                }
                                
                                chosenItemExists = -1;
                                RefreshTables();
                            }
                            catch (SqlException ex)
                            {
                                errorText.Text += "\n\rBłąd kwerendy przy realizacji wymiany (sklep).";
                            }
                            catch (Exception ex)
                            {
                                errorText.Text += "\n\rBłąd środowiska przy realizacji wymiany (sklep).";
                            }
                            Console.WriteLine("sklep OK");
                        }
                        else
                        {
                            errorText.Text += "\n\rW sklepie nie ma tak dużej liczby tych przedmiotów.";
                        }
                    }
                    else
                    {
                        errorText.Text += "\n\rW sklepie nie ma takiego przedmiotu.";
                    }
                }
                catch (SqlException ex)
                {
                    errorText.Text += "\n\rWystąpił błąd kwerendy (sklep).";
                }
                catch (Exception ex)
                {
                    errorText.Text += "\n\rWystąpił błąd środowiska (sklep).";
                }
            }
        }
    }
}