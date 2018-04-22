using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace BazaDanychGUI
{
    class DBconnector
    {
        private string ip;
        private string port;
        private string username;
        private string password;
        private string datebase;

        private string[] ColumnsName;
        private string[] ColumnsTypes;

        MySqlConnection databaseConnection;
        MySqlCommand commandDatabase;
        MySqlDataReader reader;

        public void setDate(string ipBox, string portBox, string userBox, string passwdBox, string dbBox)
        {
            this.ip = ipBox;
            this.port = portBox;
            this.username = userBox;
            this.password = passwdBox;
            this.datebase = dbBox;

            string connectionString = "datasource=" + this.ip + ";port=" + this.port + ";username=" + this.username +
                                      ";password=" + this.password + ";database=" + this.datebase + ";"
                                      ;
            this.databaseConnection = new MySqlConnection(connectionString);
        }

        public List<string> getColumnsName(string selectedTable)
        {
            List<string> lista = new List<string>();
            List<string> listaTypow = new List<string>();
            string query = "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '" + datebase+ "' AND TABLE_NAME = '" + selectedTable + "';";
            this.commandDatabase = new MySqlCommand(query, this.databaseConnection);
            this.commandDatabase.CommandTimeout = 60;
            this.reader = commandDatabase.ExecuteReader();

            if (this.reader.HasRows)
            {
                while (this.reader.Read())
                {
                    lista.Add(this.reader.GetString(0));
                    listaTypow.Add(this.reader.GetString(1));                    
                }
            }
            else
            {
                MessageBox.Show("Brak kolumn w danej tabeli");
            }
            this.reader.Close();
            this.ColumnsName = lista.ToArray();
            this.ColumnsTypes = listaTypow.ToArray();
            return lista;            
        }

        public List<string> getTableNames()
        {            
            List<string> lista = new List<string>();
            string query = "SELECT table_name FROM information_schema.tables where table_schema = '" + this.datebase + "'";
            this.commandDatabase = new MySqlCommand(query, this.databaseConnection);
            this.commandDatabase.CommandTimeout = 60;
            this.reader = commandDatabase.ExecuteReader();

            if (this.reader.HasRows)
            {
                while (this.reader.Read())
                {
                    lista.Add(this.reader.GetString(0));
                }
            }
            else
            {
                MessageBox.Show("Brak tabel w danej bazie");
            }
            this.reader.Close();            
            return lista;
        }
        
        public List<string[]> getData(string selectedTable)
        {
            List<string[]> lista = new List<string[]>();

            string query = "SELECT * FROM " + selectedTable;
            this.commandDatabase = new MySqlCommand(query, this.databaseConnection);
            this.commandDatabase.CommandTimeout = 60;
            this.reader = commandDatabase.ExecuteReader();

            if (this.reader.HasRows)
            {
                while (this.reader.Read())
                {
                    string[] row=new string[this.ColumnsTypes.Length];
                    for (int i = 0; i < this.ColumnsTypes.Length; i++)
                    {
                        switch (this.ColumnsTypes[i])
                        {
                            case "int":
                                row[i]=reader.GetInt32(i).ToString();
                                break;
                            case "varchar":
                                row[i]=reader.GetString(i);
                                break;
                        }
                    }
                    lista.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Brak danych w tabeli");
            }
            this.reader.Close();
            return lista;

        }

        public void Open()
        {
            this.databaseConnection.Open();
        }

        public void Close()
        {
            this.databaseConnection.Close();
        }

    }
}
