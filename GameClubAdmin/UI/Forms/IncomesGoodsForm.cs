using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameClubAdmin
{
    public partial class IncomesGoodsForm : Form
    {
        #region FIELD

        IncomesModel income;

        #endregion

        #region CONSTRUCTOR
        public IncomesGoodsForm()
        {
            InitializeComponent();
        }

        #endregion

        #region EVENTS

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonAddGood_Click(object sender, EventArgs e)
        {
            if(income == null)
            {
                income = new IncomesModel();
                if(textBoxAmount.Text!="" && textBoxName.Text!="" && textBoxPrice.Text!="")
                {
                    income.Name = textBoxName.Text;
                    income.Price = Convert.ToInt32(textBoxPrice.Text);
                    income.Amount = Convert.ToInt32(textBoxAmount.Text);
                    income.DateIncomes = dateTimePicker1.Value.ToString("dd-MM-yyyy HH:mm");
                    int id = IncomesModel.Insert(income);
                    if(id>=0)
                    {
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля");
                }
            }
        }

        #endregion
    }
}
