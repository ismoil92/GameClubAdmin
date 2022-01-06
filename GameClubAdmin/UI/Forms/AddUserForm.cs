using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GameClubAdmin
{
    public partial class AddUserForm : Form
    {
        #region LIST

       private List<RoleModel> role;

        #endregion

        #region FIELD

        internal UserModel user;

        #endregion

        #region CONSTRUCTOR
        public AddUserForm()
        {
            InitializeComponent();
            ShowCombobox();
        }
        #endregion

        #region METHOD

       private void ShowCombobox()
        {
            role = RoleModel.SelectAll();
            comboBoxRoles.DisplayMember = "Name";
            comboBoxRoles.ValueMember = "Id";
            comboBoxRoles.DataSource = role;
        }
        #endregion

        #region EVENTS
        private void buttonSave_Click(object sender, EventArgs e)
        {
            int role = comboBoxRoles.SelectedIndex + 1;
            if (user==null)
            {
                user = new UserModel();
                if (textBoxName.Text != "" && textBoxPassword.Text != "")
                {
                    user.Name = textBoxName.Text;
                    user.Password = textBoxPassword.Text;
                    user.RoleId = role;
                    int lastId = UserModel.Insert(user);
                    if(lastId>=0)
                    {
                        Close();
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
                if(textBoxName.Text != "" && textBoxPassword.Text != "")
                {
                    user.Name = textBoxName.Text;
                    user.Password = textBoxPassword.Text;
                    user.RoleId = role;
                    bool isUpdate = UserModel.Update(user);
                    if(isUpdate)
                    {
                        Close();
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
        }


        private void AddUserForm_Load(object sender, EventArgs e)
        {
            if(user!=null)
            {
                 textBoxName.Text=user.Name;
                textBoxPassword.Text = user.Password;
                comboBoxRoles.SelectedIndex = user.RoleId-1;
            }
        }

        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                buttonSave.PerformClick();
            }
        }
        #endregion
    }
}
