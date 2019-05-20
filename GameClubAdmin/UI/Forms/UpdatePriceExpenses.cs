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
    public partial class UpdatePriceExpenses : Form
    {
        #region CONSTRUCTOR
        public UpdatePriceExpenses()
        {
            InitializeComponent();
            buttonUpdate.Enabled = false;
        }
        #endregion

        #region FIELD

        internal ExpensesModel eModel;

        #endregion

        #region EVENTS

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            if(textBoxPrice.Text!="")
            {
                buttonUpdate.Enabled = true;
            }
            else
            {
                buttonUpdate.Enabled = false;
            }
        }

        private void UpdatePriceExpenses_Load(object sender, EventArgs e)
        {
            if(eModel!=null)
            {
                textBoxPrice.Text = Convert.ToString(eModel.Price);
                textBoxDate.Text = eModel.Date;
                textBoxName.Text = eModel.Name;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if(eModel!=null)
            {
                eModel.Price = Convert.ToInt32(textBoxPrice.Text);
                eModel.Date = textBoxDate.Text;
                eModel.Name = textBoxName.Text;
                bool isUpdate = ExpensesModel.Update(eModel);
                if(isUpdate)
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }

        #endregion
    }
}
