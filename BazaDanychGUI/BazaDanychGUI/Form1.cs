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

            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            tablesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            deleteButton.Enabled = false;
            editButton.Enabled = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                deleteButton.Enabled = false;
                editButton.Enabled = false;

            }
            else if (listView1.SelectedItems.Count == 1)
            {
                deleteButton.Enabled = true;
                editButton.Enabled = true;
            }
            else
            {
                editButton.Enabled = false;
            }

        }

        private void getDataFromDatebase(String ip, String port, String username, String password, String datebase)
        {
            string connectionString = "datasource=" +ip+ ";port=" +port+ ";username=" +username+
                                      ";password=" +password+ ";database=" +datebase+ ";"
                                      ;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            try
            {
                databaseConnection.Open();

                getTableNames(databaseConnection);

                getColumnsName(databaseConnection);
                getDataIntoListView(databaseConnection);

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getTableNames(MySqlConnection databaseConnection)
        {
            string query = "SELECT table_name FROM information_schema.tables where table_schema = '" +datebaseTextBox.Text+ "'";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            MySqlDataReader reader;
            reader = commandDatabase.ExecuteReader();
            tablesComboBox.Items.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tablesComboBox.Items.Add(reader.GetString(0));                   
                }
                tablesComboBox.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Brak tabel w danej bazie");
            }
            reader.Close();
        }

        private void getColumnsName(MySqlConnection databaseConnection)
        {
            string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '"+ datebaseTextBox.Text + "' AND TABLE_NAME = '"+ tablesComboBox.SelectedItem.ToString() + "';";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            reader = commandDatabase.ExecuteReader();
            listView1.Columns.Clear();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listView1.Columns.Add(reader.GetString(0), 50, HorizontalAlignment.Left);
                }
            }
            else
            {
                MessageBox.Show("Brak kolumn w tabeli");
            }
            reader.Close();
        }
        private void getDataIntoListView(MySqlConnection databaseConnection)
        {
            string query = "SELECT * FROM " + tablesComboBox.SelectedItem.ToString();
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            reader = commandDatabase.ExecuteReader();
            listView1.Items.Clear();

            if ( reader.HasRows )
            {
                while ( reader.Read() )
                {
                    string[] row = { reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetString(2)};
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add( listViewItem );
                }
            }
            else
            {
                MessageBox.Show("Brak danych w tabeli");
            }
            listView1.AutoResizeColumns( ColumnHeaderAutoResizeStyle.ColumnContent );
            listView1.AutoResizeColumns( ColumnHeaderAutoResizeStyle.HeaderSize );
            reader.Close();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            getDataFromDatebase(ipTextBox.Text, portTextBox.Text, usernameTextBox.Text, passwordTextBox.Text, datebaseTextBox.Text);

        }

        private void tableLabel_Click(object sender, EventArgs e)
        {

        }

        private void databaseLabel_Click(object sender, EventArgs e)
        {

        }

        private void datebaseTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
