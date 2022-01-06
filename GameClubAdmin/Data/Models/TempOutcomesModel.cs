using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClubAdmin
{
    class TempOutcomesModel : BaseModel
    {
        #region CONSTRUCTOR

        public TempOutcomesModel():base()
        {

        }

        #endregion

        #region PROPERTIES

        public string RoomName { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Amount { get; set; }

        public string DateOrder { get; set; }

        #endregion

        #region METHODS

        public static List<TempOutcomesModel> SelectAll()
        {
            return DBManager.SelectAllTempOutcomes();
        }

        public static int Insert(TempOutcomesModel temp)
        {
            return DBManager.InsertTempOutcomes(temp);
        }

        public static bool Update(TempOutcomesModel temp)
        {
            return DBManager.UpdateTempOutcomes(temp);
        }

        public static bool Delete(int tempId)
        {
            return DBManager.DeleteTempOutcomesrById(tempId);
        }

        #endregion
    }
}
