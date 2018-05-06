﻿using System;
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
        DBconnector db = new DBconnector();

        public Form1()
        {
            InitializeComponent();

            ipTextBox.Text = "127.0.0.1";
            portTextBox.Text = "3306";
            usernameTextBox.Text = "root";
            datebaseTextBox.Text = "test";

            tablesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            passwordTextBox.UseSystemPasswordChar=true;
            
            addButton.Enabled = false;
            deleteButton.Enabled = false;
            editButton.Enabled = false;
            sortButton.Enabled = false;
        }
        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( listView1.SelectedItems.Count == 0 )
            {
                deleteButton.Enabled = false;
                editButton.Enabled = false;
            }
            else if ( listView1.SelectedItems.Count == 1 )
            {
                deleteButton.Enabled = true;
                editButton.Enabled = true;
            }
            else
            {
                deleteButton.Enabled = true;
                editButton.Enabled = false;
            }
        }

        private void getDataFromDatebase()
        {            
            db.setData(ipTextBox.Text, portTextBox.Text, usernameTextBox.Text, passwordTextBox.Text, datebaseTextBox.Text);

            tablesComboBox.Items.Clear();
            listView1.Columns.Clear();
            listView1.Items.Clear();

            addButton.Enabled = false;

            try
            {
                db.Open();
                tablesComboBox.Items.AddRange(db.getTableNames().ToArray());

                if (tablesComboBox.Items.Count > 0)
                {
                    tablesComboBox.SelectedIndex = 0;
                    addButton.Enabled = true;
                }
                else
                {
                    throw new Exception("Brak tabel w podanej bazie danych");
                }                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        private void getDataIntoListView()
        {
            listView1.Columns.Clear();
            listView1.Items.Clear();

            try
            {
                db.Open();

                foreach (string listItem in db.getColumnsName(tablesComboBox.SelectedItem.ToString()))
                {
                    listView1.Columns.Add(listItem, -2, HorizontalAlignment.Left);
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                foreach (string[] item in db.getData(tablesComboBox.SelectedItem.ToString()))
                {
                    listView1.Items.Add(new ListViewItem(item));
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Close();
            } 
        }

        private void add() {
            //listView1.Columns.Count.ToString();
            Form2 frm = new Form2();
            frm.Show();
        }

        private void delete()
        {
            try
            {
                db.Open();
                foreach (ListViewItem row in listView1.SelectedItems)
                {
                    db.DeleteRecord(tablesComboBox.SelectedItem.ToString(), listView1.Columns[0].Text, row.SubItems[0].Text);
                    //listView1.Items.RemoveAt();
                }
                getDataIntoListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Close();
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            getDataFromDatebase();
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
            getDataIntoListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            add();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            delete();
        }
    }
}
