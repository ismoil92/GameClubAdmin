using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClubAdmin
{
    class ReportGoods:BaseModel
    {
        #region CONSTRUCTOR

        public ReportGoods():base()
        {

        }

        #endregion

        #region PROPERTIES

        public string Name { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }

        #endregion

        #region METHODS

        public static List<ReportGoods> SelectAll()
        {
            return DBManager.SelectAllReportGoods();
        }

        #endregion
    }
}
