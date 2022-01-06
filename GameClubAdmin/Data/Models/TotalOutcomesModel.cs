using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClubAdmin
{
    class TotalOutcomesModel:BaseModel
    {
        #region CONSTRUCTOR
        public TotalOutcomesModel():base()
        {

        }
        #endregion

        #region PROPERTIES

        public string RoomId { get; set; }
        public string DateStart { get; set; }
        public string DateFinish { get; set; }
        public int TotalSum { get; set; }

        #endregion

        #region METHODS

        public static List<TotalOutcomesModel> SelectAll()
        {
            return DBManager.SelectAllTotalOutcomes();
        }

        public static int Insert(TotalOutcomesModel totalOutcomes)
        {
            return DBManager.InsertTotalOutcomes(totalOutcomes);
        }

        #endregion
    }
}
