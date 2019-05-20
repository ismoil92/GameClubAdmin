using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClubAdmin
{
    class ExpensesModel : BaseModel
    {
        #region CONSTRUCTOR

        public ExpensesModel():base()
        {

        }

        #endregion

        #region PROPERTIES

        public string Name { get; set; }
        public int Price { get; set; }
        public string Date { get; set; }

        #endregion

        #region METHODS

        public static List<ExpensesModel> SelectAll()
        {
            return DBManager.SelectExpenses();
        }

        public static int Insert(ExpensesModel expenses)
        {
            return DBManager.InsertExpenses(expenses);
        }

        public static bool Update(ExpensesModel expenses)
        {
            return DBManager.UpdateExpenses(expenses);
        }

        #endregion
    }
}
