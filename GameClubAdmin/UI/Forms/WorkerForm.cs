using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System.Collections;

namespace GameClubAdmin
{
    public partial class WorkerForm : Form
    {

        #region FIELDS
        private static readonly string _connectionString = string.Format("Data Source={0};FailIfMissing=False;", Environment.CurrentDirectory + "\\Data\\baza.db");
        private static SQLiteConnection connection = new SQLiteConnection(_connectionString, true);
        private static SQLiteCommand command;
        private UserContrElems userControl;
        private UserControlBarTable userbarTable;
        private ExpensesModel expenses;
        private DataTable dt = new DataTable();
        private string BarTable = "";
        #endregion

        #region LISTS

       private List<RoomModel> room;
       private List<BarTableModel> barTable;
       private List<StoreModel> Store;
       private List<ExpensesModel> expense;
       private List<EncashModel> encash;
       private List<Expenses_StoreModel> expenses_Store;
       private List<OutcomesModel> outcomes;
       private List<TotalOutcomesModel> totalOutcomes;

        #endregion

        #region COSTRUCTOR
        public WorkerForm()
        {
            InitializeComponent();
        }
        #endregion

        #region METHODS

       private void SelectRoomName()
        {
            int ID = cbxRooms.SelectedIndex + 1;
            string query = "SELECT Name FROM Rooms WHERE Id=@id";
            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("id", ID);
                var value = command.ExecuteScalar();
                if(value!=null)
                {
                    RoomName = value.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        //void Dicplay()
        //{
        //    dt.Columns.Add(new DataColumn("Отчёты"));

        //    dataGridViewTotalRoom.DataSource = dt;

        //    for (int i = 0; i < dataGridViewTotalRoom.Columns.Count; i++)
        //    {
        //        dataGridViewTotalRoom.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //    }
        //}

       private void ComboBoxRooms()
        {
            room = RoomModel.SelectAll();
            cbxRooms.DisplayMember = "Name";
            cbxRooms.ValueMember = "Id";
            cbxRooms.DataSource = room;
        }


       private void ShowRooms()
        {
            if (this.tabControlRooms.TabPages.Count == 0)
            {
                room = RoomModel.SelectAll();
                foreach (RoomModel r in room)
                {
                    TabPage tabpage = new TabPage(r.Name);
                    userControl = new UserContrElems();
                    userControl.RoomId = tabControlRooms.TabPages.Count + 1;
                    userControl.UserId = userId;
                    tabpage.Controls.Add(userControl);
                    this.tabControlRooms.TabPages.Add(tabpage);
                }
            }
        }

       private void ShowBarTable()
        {
            if (tabControlBarTable.TabPages.Count == 0)
            {
                barTable = BarTableModel.SelectAll();
                foreach (var bartables in barTable)
                {
                    TabPage tabpage = new TabPage(bartables.Name);
                    userbarTable = new UserControlBarTable();
                    userbarTable.barTableId = tabControlBarTable.TabPages.Count + 1;
                    userbarTable.userId = userId;
                    tabpage.Controls.Add(userbarTable);
                    this.tabControlBarTable.TabPages.Add(tabpage);
                }
            }
        }

       private void ClearTextBox()
        {
            textBoxExpenses.Text = "";
            textBoxPrice.Text = "";
        }


       private void ShowExpenses()
        {
            expense = ExpensesModel.SelectAll();
            dataGridViewExpenses.DataSource = expense;
        }

       private void ShowComboBox()
        {
            Store = StoreModel.SelectAll();
            comboBoxNameGood.DisplayMember = "Name";
            comboBoxNameGood.ValueMember = "Id";
            comboBoxNameGood.DataSource = Store;
        }

       private void ShowExpenses_Store()
        {
            expenses_Store = Expenses_StoreModel.SelectAll();
            dataGridViewExpenses_Store.DataSource = expenses_Store;
        }

       private void ShowEncash()
        {
            encash = EncashModel.SelectAll();
            dataGridViewEncash.DataSource = encash;
        }
 
        #endregion

        #region PROPERTY

        public int userId { get; set; }

        private string RoomName { get; set; }

        #endregion

        #region EVENTS

        private void WorkerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            buttonAddEncash.Enabled = false;
            ComboBoxRooms();
            ShowRooms();
            ShowBarTable();
            ShowExpenses();
            ShowComboBox();
            ShowExpenses_Store();
            ShowEncash();
            Store = StoreModel.SelectAll();
            var index = comboBoxNameGood.SelectedIndex;
            if (Store.Count !=0)
            {
                numericUpDownAmount.Maximum = Store[index].Amount;
            }
            else
            {
                numericUpDownAmount.Maximum = 0;
            }
        }


        private void tabControlRooms_Click(object sender, EventArgs e)
        {
            ShowRooms();
            if(userControl.checkBoxReservation.Checked==true)
            {
                
            }
        }

                
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonAddExpenses_Click(object sender, EventArgs e)
        {
            if(textBoxExpenses.Text!="" && textBoxPrice.Text!="")
            {
                expenses = new ExpensesModel();
                expenses.Name = textBoxExpenses.Text;
                expenses.Price = int.Parse(textBoxPrice.Text);
                var hour = DateTime.Now.Hour;
                var day = DateTime.Now.Day;
                var month = DateTime.Now.Month;
                var year = DateTime.Now.Year;
                if(hour>=0 && hour<=6)
                {
                    var date = new DateTime(year, month, day - 1, hour, dateTimePicker1.Value.Minute, dateTimePicker1.Value.Second);
                    dateTimePicker1.Value = date;
                }
                else if(hour>=9 && hour<=23)
                {
                    var date = new DateTime(year, month, day, hour, dateTimePicker1.Value.Minute, dateTimePicker1.Value.Second);
                    dateTimePicker1.Value = date;
                }
                else
                {
                    MessageBox.Show("Рабочий день закончился");
                }
                expenses.Date = dateTimePicker1.Value.ToString("dd-MM-yyyy HH:mm");
                int lastId = ExpensesModel.Insert(expenses);
                if(lastId>0)
                {
                    ShowExpenses();
                    ClearTextBox();
                }
                else
                {
                    MessageBox.Show("Ошибка при добавление");
                }
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
        }

        private void tabControlBarTable_Click(object sender, EventArgs e)
        {
            ShowBarTable();
        }

        private void buttonAddGood_Click(object sender, EventArgs e)
        {
            if(numericUpDownAmount.Value!=0)
            {
                expenses_Store = Expenses_StoreModel.SelectAll();
                int goodId = comboBoxNameGood.SelectedIndex + 1;
                var hour = DateTime.Now.Hour;
                var day = DateTime.Now.Day;
                var month = DateTime.Now.Month;
                var year = DateTime.Now.Year;
                if(hour>=9 && hour<=23)
                {
                    var date = new DateTime(year, month, day, hour, dateTimePicker1.Value.Minute, dateTimePicker1.Value.Second);
                    dateTimePicker1.Value = date;
                }
                else if(hour>=0 && hour<=6)
                {
                    var date = new DateTime(year, month, day - 1, hour, dateTimePicker1.Value.Minute, dateTimePicker1.Value.Second);
                    dateTimePicker1.Value = date;
                }
                Expenses_StoreModel expenses = new Expenses_StoreModel();
                expenses.Name = Store[goodId - 1].Name;
                expenses.Price = Store[goodId - 1].Price * Convert.ToInt32(numericUpDownAmount.Value);
                expenses.Date = dateTimePicker1.Value.ToString("dd-MM-yyyy HH:mm");
                expenses.Amount = Convert.ToInt32(numericUpDownAmount.Value);
                int lastId = Expenses_StoreModel.Insert(expenses);
                if (lastId > 0)
                {
                    int Id = comboBoxNameGood.SelectedIndex + 1;
                    StoreModel stores = new StoreModel();
                    stores.Id = Id;
                    stores.Name = Store[Id - 1].Name;
                    stores.Price = Store[Id - 1].Price;
                    stores.Amount = Convert.ToInt32(numericUpDownAmount.Value);
                    bool isUpdate = StoreModel.UpdateGood(stores);
                    if (isUpdate)
                    {
                        ShowExpenses_Store();
                        numericUpDownAmount.Value = 0;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при заказа");
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("Количество не выбрано");
            }
        }

        private void buttonAddEncash_Click(object sender, EventArgs e)
        {
            EncashModel encashModel = new EncashModel();
            encashModel.Price = Convert.ToInt32(textBoxPriceEncash.Text);
            encashModel.Date = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            int lastId = EncashModel.Insert(encashModel);
            if(lastId>0)
            {
                ShowEncash();
                textBoxPriceEncash.Text="";
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        } 

        private void textBoxPriceEncash_TextChanged(object sender, EventArgs e)
        {
            if(textBoxPriceEncash.Text!="")
            {
                buttonAddEncash.Enabled = true;
            }
            else
            {
                buttonAddEncash.Enabled = false;
            }
        }

        private void buttonUpdateExpenses_Click(object sender, EventArgs e)
        {
            expense = ExpensesModel.SelectAll();
            if (expense.Count != 0)
            {
                var index = dataGridViewExpenses.CurrentRow.Index;
                UpdatePriceExpenses updatePrice = new UpdatePriceExpenses();
                updatePrice.eModel = expense[index];
                updatePrice.ShowDialog();
                ShowExpenses();
                Show();
            }
            else
            {
                MessageBox.Show("Таблица пустая");
            }
        }

        private void buttonTotalSumStore_Click(object sender, EventArgs e)
        {
            string query = "SELECT SUM(Price) FROM Expenses_Store WHERE Date BETWEEN @before AND @after";
            var before = new DateTime(dateTimePickerBefore.Value.Year, dateTimePickerBefore.Value.Month, dateTimePickerBefore.Value.Day, 0, 0, 0);
            var after = new DateTime(dateTimePickerAfter.Value.Year, dateTimePickerAfter.Value.Month, dateTimePickerAfter.Value.Day, 23, 59, 0);
            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("before",before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("after",after.ToString("dd-MM-yyyy HH:mm"));
                var value = command.ExecuteScalar();
                if(value!=null)
                {
                    if (value.ToString() != "")
                    {
                        labelTotalsumStore.Text = "Сумма расходов " + value.ToString();
                    }
                    else
                    {
                        labelTotalsumStore.Text = "Сумма расходов 0";
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

        private void buttonTotalSum_Click(object sender, EventArgs e)
        {
            string query = "SELECT SUM(Price) FROM Expenses WHERE Date BETWEEN @before AND @after";
            var before = new DateTime(dateTimePickerbeforeExpenses.Value.Year, dateTimePickerbeforeExpenses.Value.Month, dateTimePickerbeforeExpenses.Value.Day, 0, 0, 0);
            var after = new DateTime(dateTimePickerAfterExpenses.Value.Year, dateTimePickerAfterExpenses.Value.Month, dateTimePickerAfterExpenses.Value.Day,23,59,0);
            try
            {
                connection.Open();
                command = new SQLiteCommand(query,connection);
                command.Parameters.AddWithValue("before", before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("after", after.ToString("dd-MM-yyyy HH:mm"));
                var value = command.ExecuteScalar();
                if(value!=null)
                {
                    if(value.ToString()!="")
                    {
                        labelExpensesSum.Text = "Сумма расходов " + value.ToString();
                    }
                    else
                    {
                        labelExpensesSum.Text = "Сумма расходов 0";
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

        private void buttonTotalSumEncash_Click(object sender, EventArgs e)
        {
            string query = "SELECT SUM(Price) FROM Encash WHERE Date BETWEEN @before AND @after";
            var before = new DateTime(dateTimePickerBeforeEncash.Value.Year, dateTimePickerBeforeEncash.Value.Month, dateTimePickerBeforeEncash.Value.Day, 0, 0, 0);
            var after = new DateTime(dateTimePickerAfterEncash.Value.Year, dateTimePickerAfterEncash.Value.Month, dateTimePickerAfterEncash.Value.Day, 23, 59, 0);
            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("before",before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("after",after.ToString("dd-MM-yyyy HH:mm"));
                var value = command.ExecuteScalar();
                if(value!=null)
                {
                    if(value.ToString()!="")
                    {
                        labelTotalSumEncash.Text = "Общий сумма "+value.ToString();
                    }
                    else
                    {
                        labelTotalSumEncash.Text = "Общий сумма 0";
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

        private void textBoxPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                buttonAddExpenses.PerformClick();
            }
        }

        private void textBoxPriceEncash_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                buttonAddEncash.PerformClick();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dataGridViewTotalRoom.DataSource == null)
            {
                if (chkbBarTable.Checked == false)
                {
                    outcomes = OutcomesModel.SelectAll();
                    totalOutcomes = TotalOutcomesModel.SelectAll();
                    SelectRoomName();
                    var before = new DateTime(dtpReportTotalBefore.Value.Year, dtpReportTotalBefore.Value.Month, dtpReportTotalBefore.Value.Day, 0, 0, 0);
                    var after = new DateTime(dtpReportTotalAfter.Value.Year, dtpReportTotalAfter.Value.Month, dtpReportTotalAfter.Value.Day, 23, 59, 0);
                    dt.Columns.Add(new DataColumn("Отчёты"));
                    if (RoomName != null)
                    {
                        //TotalOutcomes
                        foreach (var t in totalOutcomes)
                        {
                            if (RoomName == t.RoomId && ((before <= Convert.ToDateTime(t.DateStart) && Convert.ToDateTime(t.DateStart) <= after) && ((before <= Convert.ToDateTime(t.DateFinish)) && Convert.ToDateTime(t.DateFinish) <= after)))
                            {
                                dt.Rows.Add(t.DateStart);
                                //Outcomes
                                foreach (var o in outcomes)
                                {
                                    if (t.RoomId == o.RoomId && (Convert.ToDateTime(t.DateStart) <= Convert.ToDateTime(o.DateOrder) && Convert.ToDateTime(o.DateOrder) <= Convert.ToDateTime(t.DateFinish)))
                                    {
                                        dt.Rows.Add(o.NameGoods + ":" + o.AmountGoods + " - " + o.AmountGoods * o.PriceGoods);
                                    }
                                }
                                dt.Rows.Add(t.DateFinish);
                                dt.Rows.Add("Сумма:" + t.TotalSum);
                                dt.Rows.Add();
                            }
                        }
                        dataGridViewTotalRoom.DataSource = dt;
                        for (int i = 0; i < dataGridViewTotalRoom.Columns.Count; i++)
                        {
                            dataGridViewTotalRoom.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                }
                else if (chkbBarTable.Checked == true)
                {
                    outcomes = OutcomesModel.SelectAll();
                    totalOutcomes = TotalOutcomesModel.SelectAll();
                    RoomName = BarTable;
                    var before = new DateTime(dtpReportTotalBefore.Value.Year, dtpReportTotalBefore.Value.Month, dtpReportTotalBefore.Value.Day, 0, 0, 0);
                    var after = new DateTime(dtpReportTotalAfter.Value.Year, dtpReportTotalAfter.Value.Month, dtpReportTotalAfter.Value.Day, 23, 59, 0);
                    dt.Columns.Add(new DataColumn("Отчёты"));
                    //TotalOutcomes
                    foreach (var t in totalOutcomes)
                    {
                        if (RoomName == t.RoomId && ((before <= Convert.ToDateTime(t.DateStart) && Convert.ToDateTime(t.DateStart) <= after) && ((before <= Convert.ToDateTime(t.DateFinish)) && Convert.ToDateTime(t.DateFinish) <= after)))
                        {
                            dt.Rows.Add(t.DateStart);
                            //Outcomes
                            foreach (var o in outcomes)
                            {
                                if (t.RoomId == o.RoomId && (Convert.ToDateTime(t.DateStart) <= Convert.ToDateTime(o.DateOrder) && Convert.ToDateTime(o.DateOrder) <= Convert.ToDateTime(t.DateFinish)))
                                {
                                    dt.Rows.Add(o.NameGoods + ":" + o.AmountGoods + " - " + o.AmountGoods * o.PriceGoods);
                                }
                            }
                            dt.Rows.Add(t.DateFinish);
                            dt.Rows.Add("Сумма:" + t.TotalSum);
                            dt.Rows.Add();
                        }
                    }
                    dataGridViewTotalRoom.DataSource = dt;
                    for (int i = 0; i < dataGridViewTotalRoom.Columns.Count; i++)
                    {
                        dataGridViewTotalRoom.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            else
            {
                MessageBox.Show("Очистить данные!!!");
            }
        }

        private void chkbBarTable_CheckedChanged(object sender, EventArgs e)
        {
            if(chkbBarTable.Checked==true)
            {
                BarTable = "Бар";
                cbxRooms.Visible = false;
            }
            else
            {
                BarTable = null;
                cbxRooms.Visible = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridViewTotalRoom.DataSource = null;
            dt.Rows.Clear();
            dt.Columns.Clear();
        }

        #endregion
    }
}
