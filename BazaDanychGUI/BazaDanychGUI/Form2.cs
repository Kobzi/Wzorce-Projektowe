using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazaDanychGUI
{
    public partial class Form2 : Form
    {
        private string typeOfValue;
        public string tempValue;

        public Form2(string typeOfForm)
        {
            InitializeComponent();

            if (typeOfForm == "addMode")
            {
                labelTitle.Text = "Wpisywanie wartości do tabeli ";
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            throw new Exception("Anulowanio wprowadzanie danych");
        }

        public void Set(string typeOfValue, string defaultValue)
        {
            this.typeOfValue = typeOfValue;
            valueTextBox.Text = defaultValue;
            tempValue = "";
        }

        private void DoneFunction()
        {
            tempValue = valueTextBox.Text;
            this.Hide();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            DoneFunction();
        }

        private void valueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                DoneFunction();
            }
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
             valueTextBox.Focus();
        }
    }
}
