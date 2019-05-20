using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClubAdmin
{
    class BaseModel
    {
        #region CONSTRUCTORS

        public BaseModel()
        {

        }

        public BaseModel(int id)
        {
            Id = id;
        }

        #endregion

        #region PROPERTIES

        public int Id { get; set; }

        #endregion
    }
}
