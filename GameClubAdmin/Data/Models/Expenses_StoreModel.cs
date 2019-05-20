using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClubAdmin
{
    class Expenses_StoreModel:BaseModel
    {
        #region CONSTRUCTOR

        public Expenses_StoreModel():base()
        {

        }

        #endregion

        #region PROPERTIES

        public string Name { get; set; }
        public int Price { get; set; }
        public string Date { get; set; }
        public int Amount { get; set; }

        #endregion

        #region METHODS

        public static List<Expenses_StoreModel> SelectAll()
        {
            return DBManager.SelectExpenses_Store();
        }

        public static int Insert(Expenses_StoreModel expenses_store)
        {
            return DBManager.InsertExpenses_Store(expenses_store);
        }

        public static bool Delete(int expensesStoreId)
        {
            return DBManager.DeleteExpensesStoreById(expensesStoreId);
        }

        #endregion

    }
}
