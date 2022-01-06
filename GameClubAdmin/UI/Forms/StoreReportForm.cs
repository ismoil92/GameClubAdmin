using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GameClubAdmin
{
    public partial class StoreReportForm : Form
    {
        #region FIELDS

        private static readonly string _connectionString = string.Format("Data Source={0};FailIfMissing=False;", Environment.CurrentDirectory + "\\Data\\baza.db");
        private static SQLiteConnection connection = new SQLiteConnection(_connectionString, true);
        private static SQLiteCommand command;

        #endregion

        #region LISTS

       private List<StoreModel> store;
       private List<StoreReportModel> storeReport;

        #endregion

        #region METHODS

       private void ShowComboBox()
        {
            store = StoreModel.SelectAll();
            comboBoxGoods.DisplayMember = "Name";
            comboBoxGoods.ValueMember = "Id";
            comboBoxGoods.DataSource = store;
        }

       private void ShowStoreReport()
        {
            storeReport = StoreReportModel.SelectAll();
            dataGridView1.DataSource = storeReport;
        }

        #endregion

        #region CONSTRUCTOR
        public StoreReportForm()
        {
            InitializeComponent();
        }
        #endregion

        #region EVENTS

        private void StoreReportForm_Load(object sender, EventArgs e)
        {
            ShowComboBox();
            ShowStoreReport();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ShowStoreReport();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM StoreReport WHERE Name IN (SELECT Name FROM Store WHERE Id= @id)";
            int Id = comboBoxGoods.SelectedIndex + 1;
            DataTable dt = new DataTable();
            SQLiteDataAdapter da;
            try
            {
                connection.Open();
                command = new SQLiteCommand(query,connection);
                command.Parameters.AddWithValue("id",Id);
                da = new SQLiteDataAdapter(command);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.CurrentRow.Index;
            int Id = storeReport[index].Id;
            DialogResult result = MessageBox.Show("Удалить?", "Удаление", MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
                bool delete = StoreReportModel.Delete(Id);
                if(delete)
                {
                    ShowStoreReport();
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
