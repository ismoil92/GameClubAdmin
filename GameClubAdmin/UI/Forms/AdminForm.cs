using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GameClubAdmin
{
    public partial class AdminForm : Form
    {

        #region FIELDS

        private static readonly string _connectionString = string.Format("Data Source={0};FailIfMissing=False;", Environment.CurrentDirectory + "\\Data\\baza.db");
        private static SQLiteConnection connection = new SQLiteConnection(_connectionString, true);
        private static SQLiteCommand command;

        #endregion

        #region LISTS

       private List<StoreModel> store;
       private List<UserModel> user;
       private List<RoomModel> room;
       private List<TotalOutcomesModel> totalOutcomes;
       private List<OutcomesModel> outcomes;
       private List<PriceTimeModel> priceTime;
       private List<BarTableModel> barTable;
       private List<IncomesModel> incomes;
       private List<ExpensesModel> expenses;
       private List<Expenses_StoreModel> expenses_Store;
       private List<EncashModel> encash;

        #endregion

        #region CONSTRUCTOR
        public AdminForm()
        {
            InitializeComponent();
            ShowIncomes();
            ShowUsers();
            ShowRooms();
            ShowPriceTime();
        }
        #endregion
 
        #region METHODS

        public void ShowStore()
        {
            store = StoreModel.SelectAllDrinks();
            dataGridViewStore.DataSource = store;
        }

        public void ShowBar()
        {
            store = StoreModel.SelectAllProducts();
            dataGridViewBar.DataSource = store;
        }

        private void ShowUsers()
        {
            user = UserModel.SelectAll();
            string query = "SELECT u.Id, u.Name, u.Password, r.Name AS Роль FROM Users u INNER JOIN Roles r ON u.RoleId=r.Id";
            DataSet ds = new DataSet();
            SQLiteDataAdapter da;
            try
            {
                connection.Open();
                da = new SQLiteDataAdapter(query, connection);
                da.Fill(ds);
                dataGridViewUsers.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

       private void ShowRooms()
        {
            room = RoomModel.SelectAll();
            dataGridViewRooms.DataSource = room;
        }

       private void ShowTotalOutcomes()
        {
            totalOutcomes = TotalOutcomesModel.SelectAll();
            dataGridViewTotalSum.DataSource = totalOutcomes;
        }

       private void ShowOutcomes()
        {
            outcomes = OutcomesModel.SelectAll();
            dataGridViewSelectGoods.DataSource = outcomes;
        }

       private void ShowPriceTime()
        {
            priceTime = PriceTimeModel.SelectAll();
            dataGridViewPriceTime.DataSource = priceTime;
        }

       private void ShowBarTables()
        {
            barTable = BarTableModel.SelectAll();
            dataGridViewBarTables.DataSource = barTable;
        }

       private void ShowIncomes()
        {
            incomes = IncomesModel.SelectAll();
            dataGridViewIncomes.DataSource = incomes;
        }

       private void ShowExpenses()
        {
            expenses = ExpensesModel.SelectAll();
            dataGridViewExpenses.DataSource = expenses;
        }


       private void ShowComboBoxRooms()
        {
            comboBoxRooms.DisplayMember = "Name";
            comboBoxRooms.ValueMember = "Id";
            comboBoxRooms.DataSource = room;
        }

       private void TotalOutcomesSum()
        {
            string query = "SELECT SUM(TotalSum) FROM TotalOutcomes WHERE Date_Time BETWEEN @before AND @after";
            var before = new DateTime(dateTimePickerBeforeTotalOutcomes.Value.Year, dateTimePickerBeforeTotalOutcomes.Value.Month, dateTimePickerBeforeTotalOutcomes.Value.Day, 0, 0, 0);
            var after = new DateTime(dateTimePickerAfterTotalOutcomes.Value.Year, dateTimePickerAfterTotalOutcomes.Value.Month, dateTimePickerAfterTotalOutcomes.Value.Day, 23, 59, 0);
            try
            {
                connection.Open();
                command = new SQLiteCommand(query,connection);
                command.Parameters.AddWithValue("before", before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("after",after.ToString("dd-MM-yyyy HH:mm"));
                    var value = command.ExecuteScalar();
                    if (value!=null)
                    {
                    if (value.ToString() != "")
                    {
                        labelTotalOutcomesSum.Text = value.ToString();
                    }
                    else
                    {
                        labelTotalOutcomesSum.Text = "0";
                    }
                    }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

       private void ExpensesSum()
        {
            string query = "SELECT SUM(Price) FROM Expenses WHERE Date BETWEEN @before AND @after";
            var before = new DateTime(dateTimePickerBeforeTotalOutcomes.Value.Year, dateTimePickerBeforeTotalOutcomes.Value.Month, dateTimePickerBeforeTotalOutcomes.Value.Day, 0, 0, 0);
            var after = new DateTime(dateTimePickerAfterTotalOutcomes.Value.Year, dateTimePickerAfterTotalOutcomes.Value.Month, dateTimePickerAfterTotalOutcomes.Value.Day, 23, 59, 0);
            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("before", before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("after", after.ToString("dd-MM-yyyy HH:mm"));
                    var value = command.ExecuteScalar();
                if (value != null)
                {
                    if (value.ToString() != "")
                    {
                        labelExpensesSum.Text = value.ToString();
                    }

                    else
                    {
                        labelExpensesSum.Text = "0";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

       private void EncashSum()
        {
            string query = "SELECT SUM(Price) FROM Encash WHERE Date BETWEEN @before AND @after";
            var before = new DateTime(dateTimePickerBeforeTotalOutcomes.Value.Year, dateTimePickerBeforeTotalOutcomes.Value.Month, dateTimePickerBeforeTotalOutcomes.Value.Day, 0, 0, 0);
            var after = new DateTime(dateTimePickerAfterTotalOutcomes.Value.Year, dateTimePickerAfterTotalOutcomes.Value.Month, dateTimePickerAfterTotalOutcomes.Value.Day, 23, 59, 0);
            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("before", before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("after", after.ToString("dd-MM-yyyy HH:mm"));
                    var value = command.ExecuteScalar();
                if (value != null)
                {
                    if (value.ToString() != "")
                    {
                        labelEncashSum.Text = value.ToString();
                    }

                    else
                    {
                        labelEncashSum.Text = "0";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

       private void ShowComboBoxGoods()
        {
            comboBoxNameGoods.DisplayMember = "Name";
            comboBoxNameGoods.ValueMember = "Id";
            comboBoxNameGoods.DataSource = store;
        }

       private void OutcomesSum()
        {
            string query = "SELECT SUM(AmountGoods) FROM Outcomes WHERE (NameGoods IN (SELECT Name FROM Store WHERE Id=@id)) AND (DataFinish BETWEEN @before AND @after)";
            var before = new DateTime(dateTimePickerBeforeGoodsName.Value.Year, dateTimePickerBeforeGoodsName.Value.Month, dateTimePickerBeforeGoodsName.Value.Day, 0, 0, 0);
            var after = new DateTime(dateTimePickerAfterGoodsName.Value.Year, dateTimePickerAfterGoodsName.Value.Month, dateTimePickerAfterGoodsName.Value.Day, 23, 59, 0);
            int Id = comboBoxNameGoods.SelectedIndex + 1;
            try
            {
                connection.Open();
                command = new SQLiteCommand(query,connection);
                command.Parameters.AddWithValue("before",before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("after",after.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("id",Id);
                var value = command.ExecuteScalar();
                if(value!=null)
                {
                    if(value.ToString()!="")
                    {
                        labelOutcomesSum.Text = value.ToString();
                    }
                    else
                    {
                        labelOutcomesSum.Text = "0";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }
       private void Expenses_StoreSum()
        {
            string query = "SELECT SUM(Amount) FROM Expenses_Store WHERE (Name IN (SELECT Name FROM Store WHERE Id=@id)) AND (Date BETWEEN @before AND @after)";
            var before = new DateTime(dateTimePickerBeforeGoodsName.Value.Year, dateTimePickerBeforeGoodsName.Value.Month, dateTimePickerBeforeGoodsName.Value.Day, 0, 0, 0);
            var after = new DateTime(dateTimePickerAfterGoodsName.Value.Year, dateTimePickerAfterGoodsName.Value.Month, dateTimePickerAfterGoodsName.Value.Day, 23, 59, 0);
            int Id = comboBoxNameGoods.SelectedIndex + 1;
            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("before", before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("after", after.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("id",Id);
                var value = command.ExecuteScalar();
                if (value != null)
                {
                    if (value.ToString() != "")
                    {
                        labelExpenses_StoreSum.Text = value.ToString();
                    }
                    else
                    {
                        labelExpenses_StoreSum.Text = "0";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

       private void ShowExpensesStore()
        {
            expenses_Store = Expenses_StoreModel.SelectAll();
            dataGridViewEncasesStore.DataSource = expenses_Store;
        }

       private void ShowEncash()
        {
            encash = EncashModel.SelectAll();
            dataGridViewEncash.DataSource = encash;
        }
 
        #endregion

        #region EVENTS

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddGoodsForm addgood = new AddGoodsForm();
            addgood.ShowDialog();
            if (addgood.radioButtonDrink.Checked == true)
            {
                ShowStore();
            }
            else if(addgood.radioButtonGoods.Checked==true)
            {
                ShowBar();
            }
            Show();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            store = StoreModel.SelectAllDrinks();
            if (store.Count != 0)
            {
                var index = dataGridViewStore.CurrentRow.Index;
                AddGoodsForm addgood = new AddGoodsForm();
                addgood.store = store[index];
                addgood.ShowDialog();
                ShowStore();
                Show();
            }
            else
            {
                MessageBox.Show("Склад пустой");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            store = StoreModel.SelectAllDrinks();
            if (store.Count != 0)
            {
                var index = dataGridViewStore.CurrentRow.Index;
                int id = store[index].Id;
                DialogResult result = MessageBox.Show("Удалить запись?", "Удаление запись", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool isDelete = StoreModel.Delete(id);
                    if (isDelete)
                    {
                        ShowStore();
                    }
                }
            }
            else
            {
                MessageBox.Show("Склад пустой");
            }
        }

        private void buttonInsertUsers_Click(object sender, EventArgs e)
        {
            AddUserForm userform = new AddUserForm();
            userform.ShowDialog();
            ShowUsers();
            Show();
        }

        private void buttonUpdateUsers_Click(object sender, EventArgs e)
        {
            if (user.Count != 0)
            {
                var index = dataGridViewUsers.CurrentRow.Index;
                AddUserForm userform = new AddUserForm();
                userform.user = user[index];
                userform.ShowDialog();
                ShowUsers();
                Show();
            }
            else
            {
                MessageBox.Show("Таблица пустая");
            }
        }

        private void buttonDeleteUsers_Click(object sender, EventArgs e)
        {
            if (user.Count != 0)
            {
                var index = dataGridViewUsers.CurrentRow.Index;
                int id = user[index].Id;
                DialogResult result = MessageBox.Show("УДАЛИТЬ?", "Удаление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool isDelete = UserModel.Delete(id);
                    if (isDelete)
                    {
                        ShowUsers();
                    }
                    else
                    {
                        MessageBox.Show("ошибка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Таблица пустая");
            }
        }


        private void buttonInsertRooms_Click(object sender, EventArgs e)
        {
            RoomModel roomform = new RoomModel();
            int index;
            if (dataGridViewRooms.Rows.Count == 0)
            {
                index = 0;
            }
            else
            {
                index = dataGridViewRooms.Rows[dataGridViewRooms.Rows.Count-1].Index;
            }
            string name = $"Кабинка №{dataGridViewRooms.Rows.Count + 1}";
            roomform.Name = name;
            int lastId = RoomModel.Insert(roomform);
            if (lastId >= 0)
            {
                ShowRooms();
            }
            else
            {
                MessageBox.Show("ошибка");
            }
        }

        private void buttonDeleteRooms_Click(object sender, EventArgs e)
        {
            if (dataGridViewRooms.Rows.Count != 0)
            {
                var index = dataGridViewRooms.Rows[dataGridViewRooms.Rows.Count - 1].Index;
                int id = room[index].Id;
                DialogResult result = MessageBox.Show("Удалить кабинку?", "Удаление кабинок", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool isDelete = RoomModel.Delete(id);
                    if (isDelete)
                    {
                        ShowRooms();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Удаления не возможно");
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            //dataGridViewRooms.Rows[0].Selected = false;
            //dataGridViewRooms.Rows[dataGridViewRooms.Rows.Count - 1].Selected = true;
        }

        private void buttonUpdatePriceTime_Click(object sender, EventArgs e)
        {
            if (priceTime.Count != 0)
            {
                var index = dataGridViewPriceTime.CurrentRow.Index;
                UpdatePriceTimeForm update = new UpdatePriceTimeForm();
                update.price = priceTime[index];
                update.ShowDialog();
                ShowPriceTime();
                Show();
            }
            else
            {
                MessageBox.Show("Таблица пустая");
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            ShowStore();
            ShowTotalOutcomes();
            ShowOutcomes();
            ShowBarTables();
            ShowIncomes();
            ShowExpenses();
            ShowComboBoxRooms();
            ShowComboBoxGoods();
            ShowBar();
            ShowExpensesStore();
            ShowEncash();
        }

        private void buttonRecords_Click(object sender, EventArgs e)
        {
            Hide();
            BuyGoodsForm buyGoods = new BuyGoodsForm();
            buyGoods.ShowDialog();
            ShowIncomes();
            Show();
        }

        private void buttonProfit_Click(object sender, EventArgs e)
        {
            string query = "SELECT SUM(TotalSum) FROM TotalOutcomes WHERE DateFinish BETWEEN @dateBefore AND @dateAfter";
            try
            {
                var before = new DateTime(dateTimePickerBeforeTotalOutcomes.Value.Year, dateTimePickerBeforeTotalOutcomes.Value.Month, dateTimePickerBeforeTotalOutcomes.Value.Day, 0, 0, 0);
                var after = new DateTime(dateTimePickerAfterTotalOutcomes.Value.Year, dateTimePickerAfterTotalOutcomes.Value.Month, dateTimePickerAfterTotalOutcomes.Value.Day, 23, 59, 0);

                connection.Open();
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@dateBefore", before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("@dateAfter", after.ToString("dd-MM-yyyy HH:mm"));
                var value = command.ExecuteScalar();
                if(value!=null)
                {
                    if (value.ToString() != "")
                    {
                        labelTotalSum.Text = "Сумма доходов равен: " + value.ToString();
                    }
                    else
                    {
                        labelTotalSum.Text = "Сумма доходов равен: 0";
                    }
                }
                else
                {
                    MessageBox.Show("ошибка");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

        //private void buttonTotalCosts_Click(object sender, EventArgs e)
        //{
        //    string query = "SELECT SUM(Price*Amount) AS Сумма FROM Incomes WHERE DateIncomes BETWEEN @dateBefore AND @dateAfter";
        //    var before = new DateTime(dateTimePickerBefore.Value.Year, dateTimePickerBefore.Value.Month, dateTimePickerBefore.Value.Day, 0, 0, 0);
        //    var after = new DateTime(dateTimePickerAfter.Value.Year, dateTimePickerAfter.Value.Month, dateTimePickerAfter.Value.Day, 23, 59, 0);
        //    try
        //    {
        //        connection.Open();
        //        command = new SQLiteCommand(query, connection);
        //        command.Parameters.AddWithValue("@dateBefore", before.ToString("dd-MM-yyyy HH:mm"));
        //        command.Parameters.AddWithValue("@dateAfter", after.ToString("dd-MM-yyyy HH:mm"));
        //        var value = command.ExecuteScalar();
        //        if(value!=null)
        //        {
        //            if (value.ToString() != "")
        //            {
        //                labelIncomes.Text = "Сумма доходов равно: " + value.ToString();
        //            }
        //            else
        //            {
        //                labelIncomes.Text = "Сумма доходов равно: 0";
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Ошибка");
        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); }
        //    finally { connection.Close(); }
        //}

        private void buttonSumExpenses_Click(object sender, EventArgs e)
        {
            string query = "SELECT SUM(Price) FROM Expenses WHERE Date BETWEEN @before AND @after";
            var before = new DateTime(dateTimePickerBeforeExpenses.Value.Year, dateTimePickerBeforeExpenses.Value.Month, dateTimePickerBeforeExpenses.Value.Day, 0, 0, 0);
            var after = new DateTime(dateTimePickerAfterExpenses.Value.Year, dateTimePickerAfterExpenses.Value.Month, dateTimePickerAfterExpenses.Value.Day, 23, 59, 0);
            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@before", before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("after", after.ToString("dd-MM-yyyy HH:mm"));
                var value = command.ExecuteScalar();
                if(value!=null)
                {
                    if (value.ToString() != "")
                    {
                        labelExpenses.Text = "Сумма расходов сотрудников равно: " + value.ToString();
                    }
                    else
                    {
                        labelExpenses.Text = "Сумма расходов сотрудников равно: 0";
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

        private void buttonInsertPriceTime_Click(object sender, EventArgs e)
        {
            UpdatePriceTimeForm update = new UpdatePriceTimeForm();
            update.ShowDialog();
            ShowPriceTime();
            Show();
        }

        private void buttonDeletePriceTime_Click(object sender, EventArgs e)
        {
            if (priceTime.Count != 0)
            {
                var index = dataGridViewPriceTime.CurrentRow.Index;
                int Id = priceTime[index].Id;
                DialogResult result = MessageBox.Show("Удалить?", "Удаление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool isDelete = PriceTimeModel.Delete(Id);
                    if (isDelete)
                    {
                        ShowPriceTime();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при удаления");
                    }
                }
            }
            else
            {
                MessageBox.Show("Таблица пустая");
            }
        }

        private void buttonSortByRooms_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM TotalOutcomes ORDER BY RoomId";
            DataTable dt = new DataTable();
            SQLiteDataAdapter da;
            try
            {
                connection.Open();
                command = new SQLiteCommand(query,connection);
                da = new SQLiteDataAdapter(command);
                da.Fill(dt);
                dataGridViewTotalSum.DataSource = dt;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally  { connection.Close(); }
        }

        private void buttonTotalSumRoom_Click(object sender, EventArgs e)
        {
            string query = "SELECT SUM(TotalSum) FROM TotalOutcomes WHERE (DateFinish BETWEEN @before AND @after) AND RoomId IN (SELECT Name FROM Rooms WHERE Id=@id)";
            var before = new DateTime(dateTimePickerBeforeTotalOutcomes.Value.Year, dateTimePickerBeforeTotalOutcomes.Value.Month, dateTimePickerBeforeTotalOutcomes.Value.Day, 0, 0, 0);
            var after = new DateTime(dateTimePickerAfterTotalOutcomes.Value.Year, dateTimePickerAfterTotalOutcomes.Value.Month, dateTimePickerAfterTotalOutcomes.Value.Day, 23, 59, 0);
            int Id = comboBoxRooms.SelectedIndex + 1;
            try
            {
                connection.Open();
                command = new SQLiteCommand(query,connection);
                command.Parameters.AddWithValue("@before",before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("@after",after.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("@id", Id);
                var value = command.ExecuteScalar();
                if(value!=null)
                {
                    if (value.ToString() != "")
                    {
                        labelTotalSumByRoom.Text = $"Сумма доходов Кабинка №{Id} равен " + value;
                    }
                    else
                    {
                        labelTotalSumByRoom.Text = $"Сумма доходов Кабинка №{Id} равен 0";
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

        private void buttonSortByOutcomesRoom_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Outcomes ORDER BY RoomId";
            DataTable dt = new DataTable();
            SQLiteDataAdapter da;
            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                da = new SQLiteDataAdapter(command);
                da.Fill(dt);
                dataGridViewSelectGoods.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

        private void buttonSortByGoodsName_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Outcomes WHERE DateOrder BETWEEN @before AND @after ORDER BY NameGoods";
            var before = new DateTime(dateTimePickerBeforeGoodsName.Value.Year, dateTimePickerBeforeGoodsName.Value.Month, dateTimePickerBeforeGoodsName.Value.Day, 0, 0, 0);
            var after = new DateTime(dateTimePickerAfterGoodsName.Value.Year, dateTimePickerAfterGoodsName.Value.Month, dateTimePickerAfterGoodsName.Value.Day, 23, 59, 0);
            DataTable dt = new DataTable();
            SQLiteDataAdapter da;
            try
            {
                connection.Open();
                command = new SQLiteCommand(query,connection);
                command.Parameters.AddWithValue("@before",before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("@after", after.ToString("dd-MM-yyyy HH:mm"));
                da = new SQLiteDataAdapter(command);
                da.Fill(dt);
                dataGridViewSelectGoods.DataSource = dt;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

        private void buttonResetDataOutcomes_Click(object sender, EventArgs e)
        {
            ShowOutcomes();
        }

        private void buttonSortByDate_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM TotalOutcomes WHERE DateFinish BETWEEN @before AND @after ORDER BY DateFinish DESC";
            var before = new DateTime(dateTimePickerBeforeTotalOutcomes.Value.Year, dateTimePickerBeforeTotalOutcomes.Value.Month,dateTimePickerBeforeTotalOutcomes.Value.Day,0,0,0);
            var after = new DateTime(dateTimePickerAfterTotalOutcomes.Value.Year, dateTimePickerAfterTotalOutcomes.Value.Month, dateTimePickerAfterTotalOutcomes.Value.Day, 23, 59, 0);
            DataTable dt = new DataTable();
            SQLiteDataAdapter da;
            try
            {
                connection.Open();
                command = new SQLiteCommand(query,connection);
                command.Parameters.AddWithValue("@before",before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("@after", after.ToString("dd-MM-yyyy HH:mm"));
                da = new SQLiteDataAdapter(command);
                da.Fill(dt);
                dataGridViewTotalSum.DataSource = dt;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

        private void buttonResetTotalOutcomes_Click(object sender, EventArgs e)
        {
            ShowTotalOutcomes();
        }

        private void buttonSortByDateOutcomes_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Outcomes WHERE DateOrder BETWEEN @before AND @after ORDER BY DateOrder DESC";
            var before = new DateTime(dateTimePickerBeforeGoodsName.Value.Year, dateTimePickerBeforeGoodsName.Value.Month, dateTimePickerBeforeGoodsName.Value.Day, 0, 0, 0);
            var after = new DateTime(dateTimePickerAfterGoodsName.Value.Year, dateTimePickerAfterGoodsName.Value.Month, dateTimePickerAfterGoodsName.Value.Day, 23, 59, 0);
            DataTable dt = new DataTable();
            SQLiteDataAdapter da;
            try
            {
                connection.Open();
                command = new SQLiteCommand(query,connection);
                command.Parameters.AddWithValue("@before",before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("@after", after.ToString("dd-MM-yyyy HH:mm"));
                da = new SQLiteDataAdapter(command);
                da.Fill(dt);
                dataGridViewSelectGoods.DataSource = dt;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TotalOutcomesSum();
            ExpensesSum();
            EncashSum();
            long total, encash, expenses, balance;
            if (labelTotalOutcomesSum.Text != "")
            {
                total = Convert.ToInt64(labelTotalOutcomesSum.Text);
            }
            else
            {
                total = 0;
            }
            if (labelExpensesSum.Text != "")
            {
                expenses = Convert.ToInt64(labelExpensesSum.Text);
            }
            else
            {
                expenses = 0;
            }
            if (labelEncashSum.Text != "")
            {
                encash = Convert.ToInt64(labelEncashSum.Text);
            }
            else
            {
                encash = 0;
            }
            balance = total - (expenses + encash);
            if(balance>0)
            {
                labelBalanceSum.Text = balance.ToString();
            }
            else if(balance<0)
            {
                labelBalanceSum.Text = "Долг " + (balance*(-1)).ToString();
            }
            else
            {
                labelBalanceSum.Text = "Баланс ноль";
            }
        }

        private void buttonTotalAmount_Click(object sender, EventArgs e)
        {
            OutcomesSum();
            Expenses_StoreSum();
            int outcomes, expenses_tore, totalAmount;
            outcomes = Convert.ToInt32(labelOutcomesSum.Text);
            expenses_tore = Convert.ToInt32(labelExpenses_StoreSum.Text);
            totalAmount = outcomes + expenses_tore;
            labelTotalAmountSum.Text = totalAmount.ToString();
        }

        private void buttonUpdateChange_Click(object sender, EventArgs e)
        {
            store = StoreModel.SelectAllDrinks();
            if (store.Count != 0)
            {
                var index = dataGridViewStore.CurrentRow.Index;
                UpdateChangeForm update = new UpdateChangeForm();
                update.store = store[index];
                update.ShowDialog();
                ShowStore();
                Show();
            }
            else
            {
                MessageBox.Show("Склад пустой");
            }
        }

 
        private void buttonReportStore_Click(object sender, EventArgs e)
        {
            StoreReportForm report = new StoreReportForm();
            report.ShowDialog();
            Show();
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            store = StoreModel.SelectAllProducts();
            if (store.Count != 0)
            {
                var index = dataGridViewBar.CurrentRow.Index;
                AddGoodsForm addgood = new AddGoodsForm();
                addgood.radioButtonGoods.Checked = true;
                addgood.store = store[index];
                addgood.ShowDialog();
                ShowBar();
                Show();
            }
            else
            {
                MessageBox.Show("Склад пустой");
            }
        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            store = StoreModel.SelectAllProducts();
            if (store.Count != 0)
            {
                var index = dataGridViewBar.CurrentRow.Index;
                DialogResult result = MessageBox.Show("Удалить?", "Удаление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int Id = store[index].Id;
                    bool delete = StoreModel.Delete(Id);
                    if (delete)
                    {
                        ShowBar();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при удаления");
                    }
                }
            }
            else
            {
                MessageBox.Show("Склад пустой");
            }
        }

        private void buttonUpdateProduct_Click(object sender, EventArgs e)
        {
            store = StoreModel.SelectAllProducts();
            if(store.Count!=0)
            {
                var index = dataGridViewBar.CurrentRow.Index;
                UpdateChangeForm update = new UpdateChangeForm();
                update.store = store[index];
                update.ShowDialog();
                ShowBar();
                Show();
            }
            else
            {
                MessageBox.Show("Склад пустой");
            }
        }

        private void buttonDeleteByDateTotal_Click(object sender, EventArgs e)
        {
            if (totalOutcomes.Count != 0)
            {
                string query = "DELETE FROM TotalOutcomes WHERE DateFinish BETWEEN @before AND @after";
                var before = new DateTime(dateTimePickerBeforeTotalOutcomes.Value.Year, dateTimePickerBeforeTotalOutcomes.Value.Month, dateTimePickerBeforeTotalOutcomes.Value.Day, 0, 0, 0);
                var after = new DateTime(dateTimePickerAfterTotalOutcomes.Value.Year, dateTimePickerAfterTotalOutcomes.Value.Month, dateTimePickerAfterTotalOutcomes.Value.Day, 23, 59, 0);
                try
                {
                    connection.Open();
                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("before", before.ToString("dd-MM-yyyy HH:mm"));
                    command.Parameters.AddWithValue("after", after.ToString("dd-MM-yyyy HH:mm"));
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { connection.Close(); }
                ShowTotalOutcomes();
            }
            else
            {
                MessageBox.Show("Таблица пустая");
            }
        }

        private void buttonDeleteByDateOutcome_Click(object sender, EventArgs e)
        {
            if (outcomes.Count != 0)
            {
                string query = "DELETE FROM Outcomes WHERE DateOrder BETWEEN @before AND @after";
                var before = new DateTime(dateTimePickerBeforeGoodsName.Value.Year, dateTimePickerBeforeGoodsName.Value.Month, dateTimePickerBeforeGoodsName.Value.Day, 0, 0, 0);
                var after = new DateTime(dateTimePickerAfterGoodsName.Value.Year, dateTimePickerAfterGoodsName.Value.Month, dateTimePickerAfterGoodsName.Value.Day, 23, 59, 0);
                try
                {
                    connection.Open();
                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("before", before.ToString("dd-MM-yyyy HH:mm"));
                    command.Parameters.AddWithValue("after", after.ToString("dd-MM-yyyy HH:mm"));
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { connection.Close(); }
                ShowOutcomes();
            }
            else
            {
                MessageBox.Show("Таблица пустая");
            }
        }

        private void buttonRecords_Click_1(object sender, EventArgs e)
        {
            IncomesGoodsForm income = new IncomesGoodsForm();
            income.ShowDialog();
            ShowIncomes();
            Show();
        }

        private void buttonTotalCosts_Click(object sender, EventArgs e)
        {
            string query = "SELECT SUM(Price*Amount) AS Сумма FROM Incomes WHERE DateIncomes BETWEEN @dateBefore AND @dateAfter";
            var before = new DateTime(dateTimePickerBefore.Value.Year, dateTimePickerBefore.Value.Month, dateTimePickerBefore.Value.Day, 0, 0, 0);
            var after = new DateTime(dateTimePickerAfter.Value.Year, dateTimePickerAfter.Value.Month, dateTimePickerAfter.Value.Day, 23, 59, 0);
            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@dateBefore", before.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("@dateAfter", after.ToString("dd-MM-yyyy HH:mm"));
                var value = command.ExecuteScalar();
                if (value != null)
                {
                    if (value.ToString() != "")
                    {
                        labelIncomes.Text = "Сумма доходов равно: " + value.ToString();
                    }
                    else
                    {
                        labelIncomes.Text = "Сумма доходов равно: 0";
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

        private void buttonDeleteByDateIncomes_Click(object sender, EventArgs e)
        {
            if (incomes.Count != 0)
            {
                incomes = IncomesModel.SelectAll();
                string query = "DELETE FROM Incomes WHERE DateIncomes BETWEEN @before AND @after";
                var before = new DateTime(dateTimePickerBefore.Value.Year, dateTimePickerBefore.Value.Month, dateTimePickerBefore.Value.Day, 0, 0, 0);
                var after = new DateTime(dateTimePickerAfter.Value.Year, dateTimePickerAfter.Value.Month, dateTimePickerAfter.Value.Day, 23, 59, 0);
                try
                {
                    connection.Open();
                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("before", before.ToString("dd-MM-yyyy HH:mm"));
                    command.Parameters.AddWithValue("after", after.ToString("dd-MM-yyyy HH:mm"));
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { connection.Close(); }
                ShowIncomes();
            }
            else
            {
                MessageBox.Show("Таблица пустая");
            }
        }

        private void buttonDeleteByDateExpenses_Click(object sender, EventArgs e)
        {
            if (expenses.Count != 0)
            {
                string query = "DELETE FROM Expenses WHERE Date BETWEEN @before AND @after";
                var before = new DateTime(dateTimePickerBeforeExpenses.Value.Year, dateTimePickerBeforeExpenses.Value.Month, dateTimePickerBeforeExpenses.Value.Day, 0, 0, 0);
                var after = new DateTime(dateTimePickerAfterExpenses.Value.Year, dateTimePickerAfterExpenses.Value.Month, dateTimePickerAfterExpenses.Value.Day, 23, 59, 0);
                try
                {
                    connection.Open();
                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("before", before.ToString("dd-MM-yyyy HH:mm"));
                    command.Parameters.AddWithValue("after", after.ToString("dd-MM-yyyy HH:mm"));
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { connection.Close(); }
                ShowExpenses();
            }
            else
            {
                MessageBox.Show("Таблица пустая");
            }
        }

        private void buttonDeleteByIdExpensesStore_Click(object sender, EventArgs e)
        {
            if (expenses_Store.Count != 0)
            {
                var index = dataGridViewEncasesStore.CurrentRow.Index;
                int Id = expenses_Store[index].Id;
                DialogResult result = MessageBox.Show("Удалить?", "Удаление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool delete = Expenses_StoreModel.Delete(Id);
                    if (delete)
                    {
                        ShowExpensesStore();
                    }
                    else
                    {
                        MessageBox.Show("ошибка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Таблица пустая");
            }
        }

        private void buttonDeleteByIdEncash_Click(object sender, EventArgs e)
        {
            if (encash.Count != 0)
            {
                var index = dataGridViewEncash.CurrentRow.Index;
                int Id = encash[index].Id;
                DialogResult result = MessageBox.Show("Удалить?", "Удаление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool delete = EncashModel.Delete(Id);
                    if (delete)
                    {
                        ShowEncash();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                    }
                }
            }
            else
            {
                MessageBox.Show("Таблица пустая");
            }
        }

        #endregion
    }
}
