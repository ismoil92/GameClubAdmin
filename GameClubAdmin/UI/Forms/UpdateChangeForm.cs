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
    public partial class UpdateChangeForm : Form
    {
        #region FIELD

        internal StoreModel store;

        #endregion

        #region CONSTRUCTOR
        public UpdateChangeForm()
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


        private void UpdateChangeForm_Load(object sender, EventArgs e)
        {
            if(store!=null)
            {
                textBoxName.Text = store.Name;
                textBoxPrice.Text = Convert.ToString(store.Price);
                textBoxAmount.Text = Convert.ToString(store.Amount);
                textBoxType.Text = store.Type;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if(store!=null)
            {
                store.Name = textBoxName.Text;
                store.Price = Convert.ToInt32(textBoxPrice.Text);
                store.Amount = Convert.ToInt32(textBoxAmount.Text);
                store.Type = textBoxType.Text;
                bool isUpdate = StoreModel.Update2(store);
                if(isUpdate)
                {
                    StoreReportModel report = new StoreReportModel();
                    report.Name = textBoxName.Text;
                    report.Amount = Convert.ToInt32(textBoxAmount.Text);
                    report.Date = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                    report.Type = store.Type;
                    int Id = StoreReportModel.Insert(report);
                    if(Id>=0)
                    {
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибки");
                    }
                }
                else
                {
                    MessageBox.Show("ошибка");
                }
            }
        }

        private void textBoxPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                buttonUpdate.PerformClick();
            }
        }

        #endregion
    }
}
