using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GameClubAdmin
{ 
    public partial class AddGoodsForm : Form
    {
        #region FIELD

        internal StoreModel store;

        #endregion

        #region LIST

        List<StoreModel> stores;

        #endregion

        #region CONSTRUCTOR

        public AddGoodsForm()
        {
            InitializeComponent();
        }

        #endregion

        #region METHOD

        void InsertGoods()
        {
            store.Name = textBoxName.Text;
            store.Price = int.Parse(textBoxPrice.Text);
            store.Amount = int.Parse(textBoxAmount.Text);
        }

        #endregion

        #region EVENTS

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (store == null)
            {
                stores = StoreModel.SelectAll();
                store = new StoreModel();
                if (textBoxName.Text != "" && textBoxPrice.Text != "" && textBoxAmount.Text != "")
                {
                    InsertGoods();
                    if(radioButtonDrink.Checked==true)
                    {
                        store.Type = textBoxDrink.Text;
                    }
                    else if(radioButtonGoods.Checked==true)
                    {
                        store.Type = textBoxGoods.Text;
                    }
                    for(int i=0;i< stores.Count;i++)
                    {
                        if(store.Name == stores[i].Name)
                        {
                            MessageBox.Show("Товар с таким названием уже есть");
                            textBoxName.Text = null;
                            textBoxAmount.Text = null;
                            textBoxPrice.Text = null;
                            store = null;
                            return;
                        }
                    }
                    int lastId = StoreModel.Insert(store);
                    if (lastId >= 0)
                    {
                        StoreReportModel report = new StoreReportModel();
                        report.Name = textBoxName.Text;
                        report.Amount = Convert.ToInt32(textBoxAmount.Text);
                        report.Date = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                        report.Type = store.Type;
                        int Id = StoreReportModel.Insert(report);
                        if (Id >= 0)
                        {
                            Close();
                        }
                        else
                        { MessageBox.Show("ошибки"); }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля");
                }
            }
            else
            {
                if (textBoxName.Text != "" && ((textBoxPrice.Text != "" && textBoxAmount.Text != "") || (textBoxPrice.Text != "" || textBoxAmount.Text != "")))
                {
                    InsertGoods();
                    StoreReportModel report = new StoreReportModel();
                    if (radioButtonDrink.Checked == true)
                    {
                        store.Type = textBoxDrink.Text;
                    }
                    else if (radioButtonGoods.Checked == true)
                    {
                        store.Type = textBoxGoods.Text;
                    }
                    bool isUpdated = StoreModel.Update(store);

                    if (isUpdated)
                    {
                        stores = StoreModel.SelectAll();
                        for(int i=0;i< stores.Count;i++)
                        {
                            if(stores[i].Id == store.Id)
                            {
                                var numb = i;
                                report.Amount = stores[numb].Amount;
                            }
                        }
 
                        report.Name = textBoxName.Text;
                        report.Date = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                        report.Type = store.Type;
                        int Id = StoreReportModel.Insert(report);
                        if (Id >= 0)
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
                        MessageBox.Show("ошибка изменения");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля");
                }
            }
        }


        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AddGoodsForm_Load(object sender, EventArgs e)
        {
            if (store != null)
            {
                textBoxName.Text = store.Name;
                textBoxPrice.Text = Convert.ToString(store.Price);
                textBoxAmount.Text = Convert.ToString(0);
            }
        }

        private void radioButtonGoods_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonGoods.Checked==true)
            {
                textBoxDrink.Visible = false;
                textBoxGoods.Visible = true;
            }
        }

        private void radioButtonDrink_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDrink.Visible = true;
            textBoxGoods.Visible = false;
        }


        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                buttonInsert.PerformClick();
            }
        }
        #endregion
    }
}
