using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace GameClubAdmin
{
    public partial class UserControlBarTable : UserControl
    {
        #region FIELDS

        private int TotalSum = 0;
        private static readonly string _connectionString = string.Format("Data Source={0};FailIfMissing=False;", Environment.CurrentDirectory + "\\Data\\baza.db");
        private static SQLiteConnection connection = new SQLiteConnection(_connectionString, true);
        private SQLiteCommand command;
        private StoreModel storeModel;

        #endregion

        #region CONSTRUCTOR
        public UserControlBarTable()
        {
            InitializeComponent();
            buttonSelectGoods.Enabled = false;
        }
        #endregion

        #region PROPERTIES

       public int barTableId { get; set; }

       public int userId { get; set; }

        #endregion

        #region LISTS

       private List<StoreModel> store;
       private List<TempOutcomesModel> temp;

        #endregion

        #region METHODS

       private void ShowStore()
        {
            store = StoreModel.SelectAll();
            comboBoxNameGoods.DisplayMember = "Name";
            comboBoxNameGoods.ValueMember = "Id";
            comboBoxNameGoods.DataSource = store;
        }

       private int InsertTempOutcomes()
        {
            int lastId = -1;
            string query = "INSERT INTO TempOutcomes(RoomName, Name, Price, Amount, DateOrder) VALUES((SELECT Name FROM BarTables WHERE Id=@barTableId),  (SELECT Name FROM Store WHERE Id=@goodId), (SELECT Price FROM Store WHERE Id=@goodId), @amount, @dateOrder)";
            int goodId = comboBoxNameGoods.SelectedIndex + 1;
            try
            {
                connection.Open();
                command = new SQLiteCommand(query,connection);
                command.Parameters.AddWithValue("@barTableId",barTableId);
                command.Parameters.AddWithValue("@goodId",goodId);
                command.Parameters.AddWithValue("@amount",textBoxAmountGoods.Text);
                command.Parameters.AddWithValue("@dateOrder", dateTimePicker1.Value.ToString("dd-MM-yyyy HH:mm"));
                int rowInserted = command.ExecuteNonQuery();
                if(rowInserted>0)
                {
                    command.CommandText = "SELECT last_insert_rowid()";
                    lastId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
            return lastId;
        }

       private bool DeleteTempOutcomes()
        {
            bool isDelete = false;
            string query = "DELETE FROM TempOutcomes WHERE RoomName IN (SELECT Name FROM BarTables WHERE Id=@barTableId)";
            try
            {
                connection.Open();
                command = new SQLiteCommand(query,connection);
                command.Parameters.AddWithValue("@barTableId", barTableId);
                int delete = command.ExecuteNonQuery();
                if(delete>0)
                {
                    isDelete = true;
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
            return isDelete;
        }

       private int InsertOutcomes()
        {
            temp = TempOutcomesModel.SelectAll();
            int lastId = -1;
            int count = temp.Count;
            for (int i = 1; i <= count; i++)
            {
                string query = "INSERT INTO Outcomes(RoomId, NameGoods, PriceGoods, AmountGoods, DateOrder) VALUES((SELECT Name FROM BarTables WHERE Id=@barTableId),  (SELECT Name FROM TempOutcomes WHERE RoomName IN (SELECT Name FROM BarTables WHERE Id=@barTableId) AND Id=@id), (SELECT Price FROM TempOutcomes WHERE RoomName IN (SELECT Name FROM BarTables WHERE Id=@barTableId) AND Id=@id), (SELECT Amount FROM TempOutcomes WHERE RoomName IN (SELECT Name FROM BarTables WHERE Id=@barTableId) AND Id=@id), @dateOrder)";
                var hour = DateTime.Now.Hour;
                var day = DateTime.Now.Day;
                var month = DateTime.Now.Month;
                var year = DateTime.Now.Year;
                if (hour >= 9 && hour <= 23)
                {
                    var date = new DateTime(year, month, day, hour, dateTimePicker1.Value.Minute, dateTimePicker1.Value.Second);
                    dateTimePicker1.Value = date;
                }
                else if (hour >= 0 && hour <= 6)
                {
                    var date = new DateTime(year, month, day - 1, hour, dateTimePicker1.Value.Minute, dateTimePicker1.Value.Second);
                    dateTimePicker1.Value = date;
                }
                try
                {
                    connection.Open();
                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("Id",i);
                    command.Parameters.AddWithValue("@barTableId", barTableId);
                    command.Parameters.AddWithValue("@dateOrder", dateTimePicker1.Value.ToString("dd-MM-yyyy HH:mm"));
                    int rowInserted = command.ExecuteNonQuery();
                    if (rowInserted > 0)
                    {
                        command.CommandText = "SELECT last_insert_rowid()";
                        lastId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { connection.Close(); }
            }
            return lastId;
        }

       private int InsertTotalOutcomes()
        {
            int lastId = -1;
            string query = "INSERT INTO TotalOutcomes(RoomId, DateStart, DateFinish, TotalSum) VALUES((SELECT RoomId FROM Outcomes WHERE RoomId IN (SELECT Name FROM BarTables WHERE Id=@barTableId)), @dateStart, @dateFinish, @price)";
            var hour = DateTime.Now.Hour;
            var day = DateTime.Now.Day;
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            if(hour>=9 && hour<=23)
            {
                var date = new DateTime(year, month, day, hour, dateTimePicker1.Value.Minute, dateTimePicker1.Value.Second);
                dateTimePicker1.Value = date;
            }
            else if(hour>=0 && hour<=23)
            {
                var date = new DateTime(year, month, day - 1, hour, dateTimePicker1.Value.Minute, dateTimePicker1.Value.Second);
                dateTimePicker1.Value = date;
            }
            try
            {
                connection.Open();
                command = new SQLiteCommand(query,connection);
                command.Parameters.AddWithValue("@barTableId", barTableId);
                command.Parameters.AddWithValue("@dateStart",dateTimePicker1.Value.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("@dateFinish", dateTimePicker1.Value.ToString("dd-MM-yyyy HH:mm"));
                command.Parameters.AddWithValue("@price",labelTotalSum.Text);
                int rowInserted = command.ExecuteNonQuery();
                if(rowInserted>0)
                {
                    command.CommandText = "SELECT last_insert_rowid()";
                    lastId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
            return lastId;
        }

       private void ShowTempOutcomes()
        {
            string query = "SELECT * FROM TempOutcomes WHERE RoomName IN (SELECT Name FROM BarTables WHERE Id=@barTableId)";
            DataTable dt = new DataTable();
            SQLiteDataAdapter da;
            try
            {
                connection.Open();
                command = new SQLiteCommand(query,connection);
                command.Parameters.AddWithValue("@barTableId", barTableId);
                da = new SQLiteDataAdapter(command);
                da.Fill(dt);
                dataGridViewTempOutcomes.DataSource = dt;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }
        #endregion

        #region EVENTS
        private void UserControlBarTable_Load(object sender, EventArgs e)
        {
            temp = TempOutcomesModel.SelectAll();
            ShowStore();
            ShowTempOutcomes();
        }

        private void textBoxAmountGoods_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAmountGoods.Text != "")
            {
                buttonSelectGoods.Enabled = true;
            }
            else
            {
                buttonSelectGoods.Enabled = false;
            }
        }

        private void textBoxAmountGoods_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonSelectGoods_Click(object sender, EventArgs e)
        {
            store = StoreModel.SelectAll();
            StoreModel storeModel = new StoreModel();
            int Id = comboBoxNameGoods.SelectedIndex + 1;
            storeModel.Id = Id;
            storeModel.Amount = int.Parse(textBoxAmountGoods.Text);
            storeModel.Price = store[Id - 1].Price;
            storeModel.Name = store[Id - 1].Name;
            TotalSum += storeModel.Amount * storeModel.Price;
            bool isUpdate = StoreModel.UpdateGood(storeModel);
            if (isUpdate)
            {
                if (InsertTempOutcomes() > 0)
                {
                    ShowTempOutcomes();
                    textBoxAmountGoods.Text = "";
                    labelTotalSum.Text = "";
                }
            }
            else
            {
                MessageBox.Show("В складе продуктов не осталось");
            }
        }

        private void buttonTotalSum_Click(object sender, EventArgs e)
        {
            if (TotalSum != 0)
            {
                labelTotalSum.Text = TotalSum.ToString();
                InsertOutcomes();
                InsertTotalOutcomes();
                DeleteTempOutcomes();
                TotalSum = 0;
                ShowTempOutcomes();
            }
            else
            {
                MessageBox.Show("Не заказано");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            temp = TempOutcomesModel.SelectAll();
            if (temp.Count != 0)
            {
                var index = dataGridViewTempOutcomes.CurrentRow.Index;
                UpdateTempOutcomesForm update = new UpdateTempOutcomesForm();
                update.temp = temp[index];
                update.Id = comboBoxNameGoods.SelectedIndex + 1;
                update.ShowDialog();
                TotalSum -= update.Total;
                ShowTempOutcomes();
                Show();
            }
            else
            {
                MessageBox.Show("Заказ пустой");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            temp = TempOutcomesModel.SelectAll();
            store = StoreModel.SelectAll();
            if (temp.Count != 0)
            {
                storeModel = new StoreModel();
                var index = dataGridViewTempOutcomes.CurrentRow.Index;
                int Id = temp[index].Id;
                DialogResult result = MessageBox.Show("Удалить?", "Удаление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int storeId = comboBoxNameGoods.SelectedIndex + 1;
                    storeModel.Id = storeId;
                    storeModel.Name = temp[index].Name;
                    storeModel.Price = temp[index].Price;
                    storeModel.Amount = temp[index].Amount;
                    TotalSum -= storeModel.Price * storeModel.Amount;
                    bool isReset = StoreModel.ResetGoodsForName(storeModel);
                    if (isReset)
                    {
                        bool isDelete = TempOutcomesModel.Delete(Id);
                        if (isDelete)
                        {
                            ShowTempOutcomes();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при удаление");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Заказ пустой");
            }
        }

        private void textBoxAmountGoods_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSelectGoods.PerformClick();
            }
        }

        #endregion
    }
}
