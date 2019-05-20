using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClubAdmin
{
    class EncashModel : BaseModel
    {
        #region CONSTRUCTOR

        public EncashModel():base()
        {

        }

        #endregion

        #region PROPERTIES

        public int Price { get; set; }
        public string Date { get; set; }

        #endregion

        #region METHODS

        public static List<EncashModel> SelectAll()
        {
            return DBManager.SelectAllEncash();
        }

        public static int Insert(EncashModel encash)
        {
            return DBManager.InsertEncash(encash);
        }

        public static bool Delete(int encashId)
        {
            return DBManager.DeleteEncashById(encashId);
        }

        #endregion
    }
}
