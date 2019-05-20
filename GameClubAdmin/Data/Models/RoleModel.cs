using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClubAdmin
{
    class RoleModel : BaseModel
    {
        #region CONTRUCTORS

        public RoleModel() : base()
        {

        }

        #endregion

        #region PROPERTIES

        public string Name { get; set; }

        #endregion

        #region METHODS

        public static List<RoleModel> SelectAll()
        {
            return DBManager.SelectAllRoles();
        }

        public static int Insert(RoleModel role)
        {
            return DBManager.InsertRole(role);
        }

        public static bool Update(RoleModel role)
        {
            return DBManager.UpdateRole(role);
        }

        public static bool Delete(int roleId)
        {
            return DBManager.DeleteRoleById(roleId);
        }

        #endregion
    }
}
