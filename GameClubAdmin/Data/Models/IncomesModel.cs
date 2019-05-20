using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClubAdmin
{
    class IncomesModel:BaseModel
    {
        #region CONSTRCUTOR
        public IncomesModel():base()
        {

        }
        #endregion

        #region PROPERTIES
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public string DateIncomes { get; set; }
        #endregion

        #region METHODS

        public static List<IncomesModel> SelectAll()
        {
            return DBManager.SelectAllIncomesGoods();
        }

        public static int Insert(IncomesModel incomes)
        {
            return DBManager.InsertIncomes(incomes);
        }

        #endregion
    }
}
