using System;
using System.Windows.Forms;

namespace GameClubAdmin
{
    public partial class UpdatePriceTimeForm : Form
    {
        #region FIELD

        internal PriceTimeModel price;

        #endregion

        #region CONSTRUCTOR

        public UpdatePriceTimeForm()
        {
            InitializeComponent();
        }
        #endregion

        #region EVENTS
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (price == null)
            {
                price = new PriceTimeModel();
                if(textBoxTypeTime.Text!="" && textBoxPriceTime.Text!="")
                {
                    price.Name = textBoxTypeTime.Text;
                    price.Price = int.Parse(textBoxPriceTime.Text);
                    int lastId = PriceTimeModel.Insert(price);
                    if(lastId>0)
                    {
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавления");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля");
                }
            }
            else
            {
                price.Name = textBoxTypeTime.Text;
                price.Price = int.Parse(textBoxPriceTime.Text);
                bool isUpdate = PriceTimeModel.Update(price);
                if (isUpdate)
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }

        private void UpdatePriceTimeForm_Load(object sender, EventArgs e)
        {
            if(price!=null)
            {
                textBoxTypeTime.Text = price.Name;
                textBoxPriceTime.Text = Convert.ToString(price.Price);
            }
        }

        private void textBoxPriceTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxTypeTime_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                buttonSave.PerformClick();
            }
        }
        #endregion
    }
}
