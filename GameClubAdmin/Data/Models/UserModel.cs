using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClubAdmin
{
    class UserModel : BaseModel
    {
        #region CONTRUCTORS

        public UserModel() : base()
        {

        }

        #endregion

        #region PROPERTIES

        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        #endregion

        #region METHODS

        public static List<UserModel> SelectAll()
        {
            return DBManager.SelectAllUsers();
        }

        public static int Insert(UserModel user)
        {
            return DBManager.InsertUser(user);
        }

        public static bool Update(UserModel user)
        {
            return DBManager.UpdateUser(user);
        }

        public static bool Delete(int userId)
        {
            return DBManager.DeleteUserById(userId);
        }

        #endregion
    }
}
