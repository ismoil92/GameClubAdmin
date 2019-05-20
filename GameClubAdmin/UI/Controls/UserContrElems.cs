using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace GameClubAdmin
{
    public partial class UserContrElems : UserControl
    {
        #region FIELDS

        private static readonly string _connectionString = string.Format("Data Source={0};FailIfMissing=False;", Environment.CurrentDirectory + "\\Data\\baza.db");
        private static SQLiteConnection connection = new SQLiteConnection(_connectionString, true);
        SQLiteCommand command;
        Timer timer;
        Timer timerCount;
        int secondsCount;
        int seconds;
        int TotalSum = 0;
        StoreModel storeModel;
        #endregion

        #region METHODS

        void ShowComboBox()
        {
            store = StoreModel.SelectAll();
            comboBoxGoods.DisplayMember = "Name";
            comboBoxGoods.ValueMember = "Id";
            comboBoxGoods.DataSource = store;
        }



        void ShowPriceTime()
        {
            price = PriceTimeModel.SelectAll();
            comboBoxPriceTime.DisplayMember = "Name";
            comboBoxPriceTime.ValueMember = "Id";
            comboBoxPriceTime.DataSource = price;
        }

        int InsertTempOutcomes2()
        {
            int lastId = -1;
            string query = "INSERT INTO TempOutcomes (RoomName, Name, Price, Amount, DateOrder) VALUES((SELECT Name FROM Rooms WHERE Id=@roomId), (SELECT Name FROM Store WHERE Id=@goodId), (SELECT Price FROM Store WHERE Id=@goodId), @amount, @dateOrder)";
            int goodId = comboBoxGoods.SelectedIndex + 1;
            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@goodId", goodId);
                command.Parameters.AddWithValue("@amount", textBoxAmountGoods.Text);
                command.Parameters.AddWithValue("@roomId",RoomId);
                command.Parameters.AddWithValue("@dateOrder", dateTimePicker1.Value.ToString("dd-MM-yyyy HH:mm"));
                int rowInserted = command.ExecuteNonQuery();
                if (rowInserted > 0)
                {
                    command.CommandText = "select last_insert_rowid()";
                    lastId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
            return lastId;
        }

        bool DeleteTempOutcomes()
        {
            bool isDelete = false;
            string query = "DELETE FROM TempOutcomes WHERE RoomName IN (SELECT Name FROM Rooms WHERE Id=@roomId)";
            try
            {
                connection.Open();
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@roomId", RoomId);
                int delete = command.ExecuteNonQuery();
                if (delete > 0)
                {
                    isDelete = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
            return isDelete;
        }

        int InsertOutcomes()
        {
            temp = TempOutcomesModel.SelectAll();
            int count = temp.Count;
            int lastId = -1;
            for (int i = 1; i <= count; i++)
            {
                string query = "INSERT INTO Outcomes(RoomId, NameGoods, PriceGoods, AmountGoods, DateOrder) VALUES((SELECT Name FROM Rooms WHERE Id=@roomId),  (SELECT Name FROM TempOutcomes WHERE RoomName IN (SELECT Name FROM Rooms WHERE Id=@roomId) AND Id=@id), (SELECT Price FROM TempOutcomes WHERE RoomName IN (SELECT Name FROM Rooms WHERE Id=@roomId) AND Id=@id), (SELECT Amount FROM TempOutcomes WHERE RoomName IN (SELECT Name FROM Rooms WHERE Id=@roomId) AND Id=@id), @dateOrder)";
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
                else
                {
                    MessageBox.Show("Работа завершена");
                }
                try
                {
                    connection.Open();
                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("Id",i);
                    command.Parameters.AddWithValue("@roomId", RoomId);
                    command.Parameters.AddWithValue("@dateOrder", dateTimePicker1.Value.ToString("dd-MM-yyyy HH:mm"));
                    int rowInserted = command.ExecuteNonQuery();
                    if (rowInserted > 0)
                    {
                        command.CommandText = "select last_insert_rowid()";
                        lastId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { connection.Close(); }
            }
            return lastId;
        }

        int TotalOutcomes()
        {
            if (radioButtonVIPTime.Checked == true)
            {
                int lastId = -1;
                string query = "INSERT INTO TotalOutcomes(RoomId, DateStart, DateFinish, TotalSum) VALUES((SELECT Name FROM Rooms WHERE Id=@roomId), @dateStart, @dateFinish, @price)";
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
                    command.Parameters.AddWithValue("@roomId", RoomId);
                    command.Parameters.AddWithValue("@price", labelTotalSum.Text);
                    command.Parameters.AddWithValue("@dateStart", dateTimePicker1.Value.AddSeconds(-seconds).ToString("dd-MM-yyyy HH:mm"));
                    command.Parameters.AddWithValue("@dateFinish", dateTimePicker1.Value.ToString("dd-MM-yyyy HH:mm"));
                    command.Parameters.AddWithValue("@time", labelTimer.Text);
                    int rowInsert = command.ExecuteNonQuery();
                    if (rowInsert > 0)
                    {
                        command.CommandText = "select last_insert_rowid()";
                        lastId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { connection.Close(); }
                return lastId;
            }
            else if (radioButtonLimitedTime.Checked==true)
            {
                int lastId = -1;
                string query = "INSERT INTO TotalOutcomes(RoomId, DateStart, DateFinish, TotalSum) VALUES((SELECT Name FROM Rooms WHERE Id=@roomId), @dateStart, @dateFinish, @price)";
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
                    command.Parameters.AddWithValue("@roomId", RoomId);
                    command.Parameters.AddWithValue("@price", labelTotalSum.Text);
                    command.Parameters.AddWithValue("@dateStart", dateTimePicker1.Value.AddSeconds(-secondsCount).ToString("dd-MM-yyyy HH:mm"));
                    command.Parameters.AddWithValue("@dateFinish", dateTimePicker1.Value.ToString("dd-MM-yyyy HH:mm"));
                    command.Parameters.AddWithValue("@time", labelTimer.Text);
                    int rowInsert = command.ExecuteNonQuery();
                    if (rowInsert > 0)
                    {
                        command.CommandText = "select last_insert_rowid()";
                        lastId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { connection.Close(); }
                return lastId;
            }
            else
            {
                return -1;
            }
        }

        string MakeTimeFormat()
        {
            int totalSeconds = secondsCount;
            int hour = totalSeconds / 3600;
            string hourString = hour >= 10 ? hour.ToString() : "0" + hour.ToString();
            totalSeconds %= 3600;
            int minutes = totalSeconds / 60;
            string minutesString = minutes >= 10 ? minutes.ToString() : "0" + minutes.ToString();
            totalSeconds %= 60;
            string secondString = totalSeconds >= 10 ? totalSeconds.ToString() : "0" + totalSeconds.ToString();
            return $"{hourString}:{minutesString}:{secondString}";
        }

        string GetTime()
        {
                int totalSeconds = seconds;
                int hour = totalSeconds / 3600;
                string hourString = hour >= 10 ? hour.ToString() : "0" + hour.ToString();
                totalSeconds %= 3600;
                int minutes = totalSeconds / 60;
                string minutesString = minutes >= 10 ? minutes.ToString() : "0" + minutes.ToString();
                totalSeconds %= 60;
                string secondString = totalSeconds >= 10 ? totalSeconds.ToString() : "0" + totalSeconds.ToString();
                return $"{hourString}:{minutesString}:{secondString}";
        }

        string GetTimeCount()
        {
            int totalSeconds = Convert.ToInt32(textBoxTime.Text)*60- secondsCount;
            int hour = totalSeconds / 3600;
            string hourString = hour >= 10 ? hour.ToString() : "0" + hour.ToString();
            totalSeconds %= 3600;
            int minutes = totalSeconds / 60;
            string minutesString = minutes >= 10 ? minutes.ToString() : "0" + minutes.ToString();
            totalSeconds %= 60;
            string secondString = totalSeconds >= 10 ? totalSeconds.ToString() : "0" + totalSeconds.ToString();
            return $"{hourString}:{minutesString}:{secondString}";
        }

        void ShowTempOutcomes()
        {
            string query = "SELECT * FROM TempOutcomes WHERE RoomName IN (SELECT Name FROM Rooms WHERE Id=@roomId)";
            DataTable dt = new DataTable();
            SQLiteDataAdapter da;
            try
            {
                connection.Open();
                command = new SQLiteCommand(query,connection);
                command.Parameters.AddWithValue("@roomId", RoomId);
                da = new SQLiteDataAdapter(command);
                da.Fill(dt);
                dataGridViewTempOutcomes.DataSource = dt;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }


        #endregion

        #region PROPERTIES

        public int RoomId { get;  set; }

        public int UserId { get;   set; }

        #endregion
        
        #region LISTS

        List<StoreModel> store;
        List<PriceTimeModel> price;
        List<TempOutcomesModel> temp;
        List<TotalOutcomesModel> total;
        List<OutcomesModel> outcome;
        List<RoomModel> rooms;
        #endregion

        #region CONSTRUCTOR
        public UserContrElems()
        {
            InitializeComponent();
            buttonStop.Enabled = false;
            buttonSelect.Enabled = false;
            buttonTimeCount.Enabled = true;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            seconds = 0;
            secondsCount = 0;
            timerCount = new Timer();
            timerCount.Interval = 1000;
            timerCount.Tick += TimerCount_Tick;
        }


        #endregion

        #region EVENTS

        private void TimerCount_Tick(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(textBoxTime.Text) * 60;
            if(total> secondsCount)
            {
                secondsCount++;
                labelTimerCount.Text = GetTimeCount();
            }
            else
            {
                timerCount.Stop();
                secondsCount = 0;
                textBoxTime.Text = "";
                textBoxTime.Enabled = true;
                MessageBox.Show("Таймер стоп Кабинка №"+RoomId);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
                seconds++;
                labelTimer.Text = GetTime();
        }



        private void buttonStart_Click(object sender, EventArgs e)
        {
                timer.Start();
                buttonStop.Enabled = true;
                buttonStart.Enabled = false;
                labelTotalSum.Text = "";
                radioButtonVIPTime.Enabled = false;
                radioButtonLimitedTime.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
                timer.Stop();
                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
        }

        private void textBoxAmountGoods_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxAmountGoods_TextChanged(object sender, EventArgs e)
        {
            if(textBoxAmountGoods.Text!="")
            {
                buttonSelect.Enabled = true;
            }
            else
            {
                buttonSelect.Enabled = false;
            }
        }

        private void UserContrElems_Load(object sender, EventArgs e)
        {
            temp = TempOutcomesModel.SelectAll();
            ShowComboBox();
            ShowPriceTime();
            ShowTempOutcomes();
            buttonTimeCount.Visible = false;
            buttonTimerCountStop.Visible = false;
            labelTimerCount.Visible = false;
            labelTimeName.Visible = false;
            textBoxTime.Visible = false;
            buttonTimerCountStop.Enabled = false;
            buttonTimeCount.Enabled = false;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == true || timerCount.Enabled==true)
            {
                store = StoreModel.SelectAll();
                StoreModel storeModel = new StoreModel();
                int Id = comboBoxGoods.SelectedIndex + 1;
                storeModel.Id = Id;
                storeModel.Amount = int.Parse(textBoxAmountGoods.Text);
                storeModel.Name = store[Id-1].Name;
                storeModel.Price = store[Id-1].Price;

                TotalSum += storeModel.Amount * storeModel.Price;
                bool isUpdate = StoreModel.UpdateGood(storeModel);
                if (isUpdate)
                {
                    if (InsertTempOutcomes2() > 0)
                    {
                        textBoxAmountGoods.Text = "";
                        ShowTempOutcomes();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при заказа");
                    }
                }
                else
                {
                    MessageBox.Show("В складе не осталось продуктов");
                    textBoxAmountGoods.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Запустите таймер");
                textBoxAmountGoods.Text = "";
            }
        }

        private void buttonTotalSum_Click(object sender, EventArgs e)
        {
            if (radioButtonVIPTime.Checked == true)
            { if (timer.Enabled == false && seconds != 0)
                {
                    string query = "SELECT (PriceTime*@seconds)/3600 FROM SettingPriceTime WHERE Id=@priceId";
                    int priceId = comboBoxPriceTime.SelectedIndex + 1;
                    try
                    {
                        connection.Open();
                        command = new SQLiteCommand(query, connection);
                        command.Parameters.AddWithValue("@seconds", seconds);
                        command.Parameters.AddWithValue("@priceId", priceId);
                        var value = command.ExecuteScalar();
                        if (value != null)
                        {
                            if (value.ToString() != "")
                            {
                                double result = Convert.ToDouble(value) + TotalSum;
                                labelTotalSum.Text = result.ToString();
                            }
                            else
                            {
                                labelTotalSum.Text = TotalSum.ToString();
                            }
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { connection.Close(); }
                    InsertOutcomes();
                    TotalOutcomes();
                    DeleteTempOutcomes();
                    labelTimer.Text = "00:00:00";
                    seconds = 0;
                    ShowTempOutcomes();
                    radioButtonVIPTime.Enabled = true;
                    radioButtonLimitedTime.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Таймер не остановлен или секунды равно нулю");
                }
            }
            else if (radioButtonLimitedTime.Checked==true)
            {
                if (timerCount.Enabled == false && secondsCount != 0)
                {
                    string query = "SELECT (PriceTime*@seconds)/3600 FROM SettingPriceTime WHERE Id=@priceId";
                    int priceId = comboBoxPriceTime.SelectedIndex + 1;
                    try
                    {
                        connection.Open();
                        command = new SQLiteCommand(query, connection);
                        command.Parameters.AddWithValue("@seconds", secondsCount);
                        command.Parameters.AddWithValue("@priceId", priceId);
                        var value = command.ExecuteScalar();
                        if (value != null)
                        {
                            if (value.ToString() != "")
                            {
                                double result = Convert.ToDouble(value) + TotalSum;
                                labelTotalSum.Text = result.ToString();
                            }
                            else
                            {
                                labelTotalSum.Text = TotalSum.ToString();
                            }
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { connection.Close(); }
                    InsertOutcomes();
                    TotalOutcomes();
                    DeleteTempOutcomes();
                    labelTimerCount.Text = "00:00:00";
                    textBoxTime.Enabled = true;
                    secondsCount = 0;
                    ShowTempOutcomes();
                    radioButtonVIPTime.Enabled = true;
                    radioButtonLimitedTime.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Таймер не остановлен или секунды равно нулю");
                }
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
                update.Id = comboBoxGoods.SelectedIndex + 1;
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
                DialogResult result = MessageBox.Show("Отменить Заказ?", "Отмена заказа", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int storeId = comboBoxGoods.SelectedIndex + 1;
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

        private void checkBoxReservation_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonVIPTime.Checked == true)
            {
                if (checkBoxReservation.Checked == true)
                {
                    buttonStart.Enabled = false;
                }
                else
                {
                    buttonStart.Enabled = true;
                }
            }
            else if(radioButtonLimitedTime.Checked==true)
            {
                if (checkBoxReservation.Checked == true)
                {
                    textBoxTime.Enabled = false;
                }
                else
                {
                    textBoxTime.Enabled = true;
                }
            }
        }


        private void textBoxAmountGoods_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                buttonSelect.PerformClick();
            }
        }

        private void textBoxTime_TextChanged(object sender, EventArgs e)
        {
            if(textBoxTime.Text!="")
            {
                buttonTimeCount.Enabled = true;
            }
            else
            {
                buttonTimeCount.Enabled = false;
            }
        }

        private void buttonTimeCount_Click(object sender, EventArgs e)
        {
            timerCount.Start();
            buttonTimeCount.Enabled = false;
            buttonTimerCountStop.Enabled = true;
            labelTotalSum.Text = "";
            textBoxTime.Enabled = false;
            radioButtonLimitedTime.Enabled = false;
            radioButtonVIPTime.Enabled = false;
        }

        private void buttonTimerCountStop_Click(object sender, EventArgs e)
        {
            timerCount.Stop();
            buttonTimerCountStop.Enabled = false;
            textBoxTime.Text = null;
        }

        private void radioButtonVIPTime_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonVIPTime.Checked==true)
            {
                buttonStart.Visible = true;
                buttonStop.Visible = true;
                labelTimer.Visible = true;
                buttonTimeCount.Visible = false;
                buttonTimerCountStop.Visible = false;
                labelTimerCount.Visible = false;
                labelTimeName.Visible = false;
                textBoxTime.Visible = false;
            }
        }

        private void radioButtonLimitedTime_CheckedChanged(object sender, EventArgs e)
        {
            buttonTimeCount.Visible = true;
            buttonTimerCountStop.Visible = true;
            labelTimerCount.Visible = true;
            labelTimeName.Visible = true;
            textBoxTime.Visible = true;
            buttonStart.Visible = false;
            buttonStop.Visible = false;
            labelTimer.Visible = false;
        }

        #endregion
    }
}
