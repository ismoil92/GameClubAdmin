using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClubAdmin
{
   
    class RoomModel :BaseModel
    {
        #region CONSTRUCTOR
        public RoomModel() : base()
        {

        }
        #endregion

        #region PROPERTY
        public string Name { get; set; }
        #endregion

        #region METHODS

        public static List<RoomModel> SelectAll()
        {
            return DBManager.SelectAllRooms();
        }

        public static int Insert(RoomModel room)
        {
            return DBManager.InsertRoom(room);
        }

        public static bool Update(RoomModel room)
        {
            return DBManager.UpdateRoom(room);
        }

        public static bool Delete(int roomId)
        {
            return DBManager.DeleteRoomById(roomId);
        }

        #endregion
    }
}
