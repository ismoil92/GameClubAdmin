using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GameClubAdmin
{
    public partial class UpdateTempOutcomesForm : Form
    {
        #region FIELDS

        internal TempOutcomesModel temp = new TempOutcomesModel();
        private StoreModel store = new StoreModel();
        public int Total = 0;
        #endregion

        #region LIST

       private List<StoreModel> storeModel;

        #endregion

        #region CONSTRUCTOR
        public UpdateTempOutcomesForm()
        {
            InitializeComponent();
        }
        #endregion

        #region PROPERTIES

        public int Id { get; set; }

        public int Amount { get; set; }

        #endregion

        #region EVENTS
        private void UpdateTempOutcomesForm_Load(object sender, EventArgs e)
        {
            storeModel = StoreModel.SelectAll();
            numericUpDownAmount.Maximum = storeModel[Id-1].Amount;
            if(temp!=null)
            {
                textBoxRoomName.Text = temp.RoomName;
                textBoxName.Text = temp.Name;
                textBoxPrice.Text = Convert.ToString(temp.Price);
                numericUpDownAmount.Value = temp.Amount;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if(temp!=null)
            {
                temp.RoomName = textBoxRoomName.Text;
                temp.Name = textBoxName.Text;
                temp.Price = int.Parse(textBoxPrice.Text);
                temp.Amount = Convert.ToInt32(numericUpDownAmount.Value);
                temp.DateOrder = dateTimePicker1.Value.ToString("dd-MM-yyyy HH:mm");
                bool IsUpdate = TempOutcomesModel.Update(temp);
                if(IsUpdate)
                {
                    if(Amount>0)
                    {
                        store.Id = Id;
                        store.Name = temp.Name;
                        store.Price = temp.Price;
                        store.Amount = Amount;
                        Total += store.Price * store.Amount;
                        bool isReset = StoreModel.ResetGoodsForName(store);
                        if(isReset)
                        {

                        } 
                        else
                        {
                            MessageBox.Show("Ошибка");
                        }
                    }
                    else if(Amount<0)
                    {
                        Amount *= (-1);
                        store.Id = Id;
                        store.Name = temp.Name;
                        store.Price = temp.Price;
                        store.Amount = Amount;
                        Total += store.Price * store.Amount;
                        bool isUpdate = StoreModel.UpdateGoodForName(store);
                        if(isUpdate)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }     
                    Close();
                }
                else
                {
                    MessageBox.Show("Ошибка при изменение");
                }
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
        }

        private void numericUpDownAmount_ValueChanged(object sender, EventArgs e)
        {
            decimal value = temp.Amount;
            if(value > numericUpDownAmount.Value)
            {
                decimal amount = value - numericUpDownAmount.Value;
                Amount = Convert.ToInt32(amount);
            }
            else if(value < numericUpDownAmount.Value)
            {
                decimal amount = value - numericUpDownAmount.Value;
                Amount = Convert.ToInt32(amount);
            }
        }
        #endregion
    }
}
