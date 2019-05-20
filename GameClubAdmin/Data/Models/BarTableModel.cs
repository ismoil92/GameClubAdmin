using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClubAdmin
{
    class BarTableModel:BaseModel
    {
        #region CONSTRUCTORS
        public BarTableModel():base()
        {

        }
        #endregion

        #region PROPERTIES

        public string Name { get; set; }

        #endregion

        #region METHODS

        public static List<BarTableModel> SelectAll()
        {
            return DBManager.SelectAllBarTables();
        }

        public static int Insert(BarTableModel table)
        {
            return DBManager.InsertBarTable(table);
        }

        public static bool Delete(int tableId)
        {
            return DBManager.DeleteBarTableById(tableId);
        }

        #endregion
    }
}
