using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClubAdmin
{
    class OutcomesModel : BaseModel
    {
        #region CONSTRUCTORS
        public OutcomesModel():base()
        {

        }
        #endregion

        #region PROPERTIES

         public string RoomId { get; set; }
         public string NameGoods { get; set; }
        public int PriceGoods { get; set; }
        public int AmountGoods { get; set; }
        public string DateOrder { get; set; }

        #endregion

        #region METHODS

        public static List<OutcomesModel> SelectAll()
        {
            return DBManager.SelectAllOutcomes();
        }

        public static int Insert(OutcomesModel outcomes)
        {
            return DBManager.InsertOutcomes(outcomes);
        }

        #endregion

    }
}
