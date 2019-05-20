using System;
using System.Windows.Forms;

namespace GameClubAdmin
{
    public partial class BuyGoodsForm : Form
    {
        #region COSTRUCTOR
        public BuyGoodsForm()
        {
            InitializeComponent();
        }
        #endregion

        #region FIELD

      internal IncomesModel incomes;

        #endregion

        #region EVENTS
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if(incomes==null)
            {
                incomes = new IncomesModel();
                if(textBoxName.Text!="" && textBoxPrice.Text!="" && textBoxAmount.Text!="")
                {
                    incomes.Name = textBoxName.Text;
                    incomes.Price = int.Parse(textBoxPrice.Text);
                    incomes.Amount = int.Parse(textBoxAmount.Text);
                    incomes.DateIncomes = dateTimePickerAddGoods.Value.ToString("dd-MM-yyyy HH:mm");
                    int lastId = IncomesModel.Insert(incomes);
                    if(lastId>0)
                    {
                        MessageBox.Show("Успешно добавлен");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавлений");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля");
                }
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
