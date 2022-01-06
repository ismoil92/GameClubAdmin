using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClubAdmin
{
     class StoreModel : BaseModel
    {
        #region CONSTRUCTOR
        public StoreModel():base()
        {

        }
        #endregion

        #region PROPERTIES
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }
        #endregion

        #region METHODS

        public static List<StoreModel> SelectAll()
        {
            return DBManager.SelectAllStore();
        }

        public static List<StoreModel> SelectAllDrinks()
        {
            return DBManager.SelectAllStoreDrinks();
        }

        public static List<StoreModel> SelectAllProducts()
        {
            return DBManager.SelectAllStoreProducts();
        }

        public static int Insert(StoreModel store)
        {
            return DBManager.InsertStore(store);
        }

        public static bool Update(StoreModel store)
        {
            return DBManager.UpdateStore(store);
        }

        public static bool Update2(StoreModel store)
        {
            return DBManager.UpdateStore2(store);
        }

        public static bool UpdateGood(StoreModel store)
        {
            return DBManager.UpdateGoods(store);
        }

        public static bool UpdateGoodForName(StoreModel store)
        {
            return DBManager.UpdateGoodByName(store);
        }

        public static bool Reset(StoreModel store)
        {
            return DBManager.ResetAmountGoods(store);
        }

        public static bool ResetGoodsForName(StoreModel store)
        {
            return DBManager.ResetGoodByName(store);
        }

        public static bool Delete(int userId)
        {
            return DBManager.DeleteStoreById(userId);
        }

        #endregion
    }
}
