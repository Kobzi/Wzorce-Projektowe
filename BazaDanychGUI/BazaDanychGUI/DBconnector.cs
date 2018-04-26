using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
//using System.Windows.Forms;

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

        private MySqlConnection databaseConnection;
        //private MySqlCommand commandDatabase;
        //private MySqlDataReader reader;

        public void setData(string ipBox, string portBox, string userBox, string passwdBox, string dbBox)
        {
            this.ip = ipBox;
            this.port = portBox;
            this.username = userBox;
            this.password = passwdBox;
            this.datebase = dbBox;                      
        }

        public List<string> getColumnsName(string selectedTable)
        {
            List<string> lista = new List<string>();
            List<string> listaTypow = new List<string>();

            string query = "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '" + datebase + "' AND TABLE_NAME = '" + selectedTable + "';";
            using (MySqlCommand commandDatabase = new MySqlCommand(query, this.databaseConnection))
            {
                using ( MySqlDataReader reader = commandDatabase.ExecuteReader() )
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            lista.Add(reader.GetString(0));
                            listaTypow.Add(reader.GetString(1));
                        }
                    }
                    else
                    {
                        throw new Exception("Brak kolumn w danej tabeli lub jest z nimi jakiś problem");
                    }
                }
            }
            this.ColumnsName = lista.ToArray();
            this.ColumnsTypes = listaTypow.ToArray();
            return lista;            
        }

        public List<string> getTableNames()
        {            
            List<string> lista = new List<string>();

            string query = "SELECT table_name FROM information_schema.tables where table_schema = '" + this.datebase + "'";
            using ( MySqlCommand commandDatabase = new MySqlCommand(query, this.databaseConnection) )
            {
                using ( MySqlDataReader reader = commandDatabase.ExecuteReader() )
                {
                    if ( reader.HasRows )
                    {
                        while ( reader.Read() )
                        {
                            lista.Add( reader.GetString(0) );
                        }
                    }
                    else
                    {
                        throw new Exception("Brak tabel w danej bazie");
                    }
                }
            }    
            return lista;
        }
        
        public List<string[]> getData(string selectedTable)
        {
            List<string[]> lista = new List<string[]>();

            string query = "SELECT * FROM " + selectedTable;
            using ( MySqlCommand commandDatabase = new MySqlCommand(query, this.databaseConnection) )
            {
                using ( MySqlDataReader reader = commandDatabase.ExecuteReader() )
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string[] row = new string[reader.FieldCount];
                            for (int i = 0; i < reader.FieldCount; i++)
                            {                              
                                row[i] = reader.GetValue(i).ToString();
                            }
                            lista.Add(row);
                        }
                    }
                    else
                    {
                        throw new Exception("Brak danych w tabeli");
                    }
                } 
            }
            return lista;
        }



        public void AddRecord(string selectedTable, string[] row)
        {

        }

        public void Open()
        {
            string connectionString = "datasource=" + this.ip + ";port=" + this.port + ";username=" + this.username +
                                      ";password=" + this.password + ";database=" + this.datebase + ";"
                                      ;
            this.databaseConnection = new MySqlConnection(connectionString);

            if (this.databaseConnection.State != System.Data.ConnectionState.Closed)
            {
                this.Close();
            }
            this.databaseConnection.Open();
        }

        public void Close()
        {
            this.databaseConnection.Close();
        }
    }
}
