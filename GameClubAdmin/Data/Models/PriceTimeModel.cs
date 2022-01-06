using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClubAdmin
{
    class PriceTimeModel :BaseModel
    {

        #region CONSTRUCTOR

        public PriceTimeModel():base()
        {

        }

        #endregion

        #region PROPERTIES

        public string Name { get; set; }

        public int Price { get; set; }

        #endregion

        #region METHODS

        public static List<PriceTimeModel> SelectAll()
        {
            return DBManager.SelectPriceTime();
        }

        public static int Insert(PriceTimeModel price)
        {
            return DBManager.InsertPriceTime(price);
        }

        public static bool Update(PriceTimeModel priceTime)
        {
            return DBManager.UpdatePriceTime(priceTime);
        }

        public static bool Delete(int priceId)
        {
            return DBManager.DeletePriceById(priceId);
        }

        #endregion
    }
}
