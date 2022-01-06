using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GameClubAdmin
{
    public partial class LoginForm : Form
    {
        #region CONSTRUCTOR

        public LoginForm()
        {
            InitializeComponent();

            ShowLogin();
            textBoxPassword.PasswordChar = '*';
            buttonEnter.Enabled = false;
        }

        #endregion
        
        #region FIELDS

       private AdminForm admin = new AdminForm();
       private WorkerForm worker = new WorkerForm();

        #endregion

        #region LIST

       private List<UserModel> _users;
        #endregion

        #region EVENTS

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
            {
            if (textBoxPassword.Text != "")
            {
                var selectedUser = _users[comboBoxLogin.SelectedIndex];

                if (textBoxPassword.Text == selectedUser.Password)
                {
                    if (selectedUser.RoleId == 1)
                    {
                        Hide();
                        admin.ShowDialog();
                        Show();
                        ShowLogin();
                        textBoxPassword.Text = "";
                    }
                    else if (selectedUser.RoleId == 2)
                    {
                        int Id = comboBoxLogin.SelectedIndex + 1;
                        worker.userId = Id;
                        Hide();
                        worker.ShowDialog();
                        Show();
                        ShowLogin();
                        textBoxPassword.Text = "";
                        //worker.Select(selectedUser.Id);
                        //worker.SelectNameRoom();
                    }
                }
                else
                {
                    MessageBox.Show("Введите правильный пароль");
                }
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.Text != "")
            {
                buttonEnter.Enabled = true;
            }
            else
            {
                buttonEnter.Enabled = false;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ShowLogin();
        }
        #endregion

        #region METHOD

       private void ShowLogin()
        {
            _users = UserModel.SelectAll();
            comboBoxLogin.DisplayMember = "Name";
            comboBoxLogin.ValueMember = "Id";
            comboBoxLogin.DataSource = _users;
        }

        #endregion
    }
}