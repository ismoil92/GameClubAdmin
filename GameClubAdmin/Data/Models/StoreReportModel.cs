using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClubAdmin
{
    class StoreReportModel:BaseModel
    {
        #region CONSTRUCTOR

        public StoreReportModel():base()
        {

        }

        #endregion

        #region PROPERTIES

        public string Name { get; set; }
        public int Amount { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }

        #endregion

        #region METHODS

        public static List<StoreReportModel> SelectAll()
        {
            return DBManager.SelectAllStoreReport();
        }

        public static int Insert(StoreReportModel Store)
        {
            return DBManager.InsertStoreReport(Store);
        }

        public static bool Delete(int tableId)
        {
            return DBManager.DeleteStoreReportById(tableId);
        }

        #endregion
    }
}
