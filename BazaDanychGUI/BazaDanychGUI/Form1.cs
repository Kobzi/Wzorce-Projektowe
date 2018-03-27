using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BazaDanychGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ipTextBox.Text = "127.0.0.1";
            portTextBox.Text = "3306";
            usernameTextBox.Text = "root";
            datebaseTextBox.Text = "test";
            tableTextBox.Text = "users";

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void getDateFromDatebase(String ip, String port, String username, String password, String datebase)
        {
            string connectionString = "datasource=" +ip+ ";port=" +port+ ";username=" +username+
                                      ";password=" +password+ ";database=" +datebase+ ";"
                                      ;
          
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            try
            {
                databaseConnection.Open();

                getColumnsName(databaseConnection);
                getDateIntoTable(databaseConnection);

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getColumnsName(MySqlConnection databaseConnection)
        {
            string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '"+ datebaseTextBox.Text + "' AND TABLE_NAME = '"+ tableTextBox.Text + "';";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            reader = commandDatabase.ExecuteReader();
            listView1.Columns.Clear();

            if (reader.HasRows)
            {
                bool firstIteration = true;
                int width;
                while (reader.Read())
                {
                    width = 100;
                    if (firstIteration)
                    {
                        width = 30;
                        firstIteration = false;
                    }
                    listView1.Columns.Add(reader.GetString(0), width, HorizontalAlignment.Left);
                }
            }
            else
            {
                MessageBox.Show("Brak kolumn w tabeli");
            }
            reader.Close();
        }
        private void getDateIntoTable(MySqlConnection databaseConnection)
        {
            string query = "SELECT * FROM " + tableTextBox.Text;
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            reader = commandDatabase.ExecuteReader();
            listView1.Items.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string[] row = { reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetString(2)};
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
            }
            else
            {
                MessageBox.Show("Brak danych w tabeli");
            }
            reader.Close();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            getDateFromDatebase(ipTextBox.Text, portTextBox.Text, usernameTextBox.Text, passwordTextBox.Text, datebaseTextBox.Text);
        }
    }
}
