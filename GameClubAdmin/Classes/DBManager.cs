using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameClubAdmin
{
    class DBManager
    {
        #region FIELDS

        private static readonly string _connectionString = string.Format("Data Source={0};FailIfMissing=False;", Environment.CurrentDirectory + "\\Data\\baza.db");
        private static SQLiteConnection connection = new SQLiteConnection(_connectionString, true);

        private static SQLiteDataReader reader;

        private static readonly string _tableNameRoles = "Roles";
        private static readonly string _tableNameUsers = "Users";
        private static readonly string _tableNameRooms = "Rooms";
        private static readonly string _tableNameStore = "Store";
        private static readonly string _tableNameTempOutcomes = "TempOutcomes";
        private static readonly string _tableNameOutcomes = "Outcomes";
        private static readonly string _tableNameTotalOutcomes = "TotalOutcomes";
        private static readonly string _tableNamePriceTime = "SettingPriceTime";
        private static readonly string _tableNameBarTables = "BarTables";
        private static readonly string _tableNameIncomes = "Incomes";
        private static readonly string _tableNameExpenses = "Expenses";
        private static readonly string _tableNameEncash = "Encash";
        private static readonly string _tableNameExpenses_Store = "Expenses_Store";
        private static readonly string _tableNameReportGoods = "ReportGoods";
        private static readonly string _tableNameStoreReport = "StoreReport";
        #endregion

        #region METHODS

        public static bool DeleteById(string tableName, int id)
        {
            bool isDeleted = false;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"DELETE FROM [{tableName}] WHERE Id = @id";
                        command.Parameters.AddWithValue("id", id);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            isDeleted = true;
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return isDeleted;
        }

        #region ROLES
        
        public static List<RoleModel> SelectAllRoles()
        {
            var items = new List<RoleModel>();

            try
            {
               connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] ", _tableNameRoles);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var name = reader[1].ToString();

                        var item = new RoleModel();
                        item.Id = id;
                        item.Name = name;

                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        public static int InsertRole(RoleModel role)
        {
            int lastId = -1;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tableNameRoles}](Name) VALUES(@name)";
                        command.Parameters.AddWithValue("name", role.Name);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return lastId;
        }

        public static bool UpdateRole(RoleModel role)
        {
            bool isUpdated = false;
            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"UPDATE [{_tableNameRoles}] SET Name = @name WHERE Id = @id";
                        command.Parameters.AddWithValue("id", role.Id);
                        command.Parameters.AddWithValue("name", role.Name);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            isUpdated = true;
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        public static bool DeleteRoleById(int id)
        {
            return DeleteById(_tableNameRoles, id);
        }

        #endregion

        #region USERS

        public static List<UserModel> SelectAllUsers()
        {
            var items = new List<UserModel>();
            try
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] ", _tableNameUsers);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var roleId = int.Parse(reader[1].ToString());
                        var name = reader[2].ToString();
                        var password = reader[3].ToString();

                        var item = new UserModel();
                        item.Id = id;
                        item.Name = name;
                        item.Password = password;
                        item.RoleId = roleId;

                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        public static int InsertUser(UserModel user)
        {
            int lastId = -1;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tableNameUsers}](RoleId, Name, Password) VALUES(@roleId, @name, @password)";
                        command.Parameters.AddWithValue("roleId", user.RoleId);
                        command.Parameters.AddWithValue("name", user.Name);
                        command.Parameters.AddWithValue("password", user.Password);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return lastId;
        }

        public static bool UpdateUser(UserModel user)
        {
            bool isUpdated = false;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"UPDATE [{_tableNameUsers}] SET RoleId = @roleId, Name = @name, Password = @password WHERE Id = @id";
                        command.Parameters.AddWithValue("id", user.Id);
                        command.Parameters.AddWithValue("roleId", user.RoleId);
                        command.Parameters.AddWithValue("name", user.Name);
                        command.Parameters.AddWithValue("password", user.Password);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            isUpdated = true;
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        public static bool DeleteUserById(int id)
        {
            return DeleteById(_tableNameUsers, id);
        }

        #endregion

        #region ROOMS

        public static List<RoomModel> SelectAllRooms()
        {
            var items = new List<RoomModel>();

            try
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] ",_tableNameRooms);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var name = reader[1].ToString();

                        var item = new RoomModel();
                        item.Id = id;
                        item.Name = name;

                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        public static int InsertRoom(RoomModel room)
        {
            int lastId = -1;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tableNameRooms}](Name) VALUES(@name)";
                        command.Parameters.AddWithValue("name", room.Name);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return lastId;
        }

        public static bool UpdateRoom(RoomModel room)
        {
            bool isUpdated = false;
            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"UPDATE [{_tableNameRooms}] SET Name = @name WHERE Id = @id";
                        command.Parameters.AddWithValue("id", room.Id);
                        command.Parameters.AddWithValue("name", room.Name);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            isUpdated = true;
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        public static bool DeleteRoomById(int id)
        {
            return DeleteById(_tableNameRooms, id);
        }
        #endregion

        #region STORE

        public static List<StoreModel> SelectAllStore()
        {
            var items = new List<StoreModel>();

            try
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] ", _tableNameStore);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var name = reader[1].ToString();
                        var price = int.Parse(reader[2].ToString());
                        var amount = int.Parse(reader[3].ToString());
                        var type = reader[4].ToString();

                        var item = new StoreModel();
                        item.Id = id;
                        item.Name = name;
                        item.Price = price;
                        item.Amount = amount;
                        item.Type = type;

                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        public static List<StoreModel> SelectAllStoreDrinks()
        {
            var items = new List<StoreModel>();

            try
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] WHERE Type='Напитки'", _tableNameStore);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var name = reader[1].ToString();
                        var price = int.Parse(reader[2].ToString());
                        var amount = int.Parse(reader[3].ToString());
                        var type = reader[4].ToString();

                        var item = new StoreModel();
                        item.Id = id;
                        item.Name = name;
                        item.Price = price;
                        item.Amount = amount;
                        item.Type = type;

                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        public static List<StoreModel> SelectAllStoreProducts()
        {
            var items = new List<StoreModel>();

            try
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] WHERE Type='Продукты'", _tableNameStore);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var name = reader[1].ToString();
                        var price = int.Parse(reader[2].ToString());
                        var amount = int.Parse(reader[3].ToString());
                        var type = reader[4].ToString();

                        var item = new StoreModel();
                        item.Id = id;
                        item.Name = name;
                        item.Price = price;
                        item.Amount = amount;
                        item.Type = type;

                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        public static int InsertStore(StoreModel store)
        {
            int lastId = -1;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tableNameStore}](Name,Price,Amount,Type) VALUES(@name, @price, @amount, @type)";
                        command.Parameters.AddWithValue("name", store.Name);
                        command.Parameters.AddWithValue("price", store.Price);
                        command.Parameters.AddWithValue("amount",store.Amount);
                        command.Parameters.AddWithValue("type", store.Type);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return lastId;
        }

        public static bool UpdateStore(StoreModel store)
        {
            bool isUpdated = false;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"UPDATE [{_tableNameStore}] SET Name = @name, Price = @price, Amount = Amount + @amount, Type=@type WHERE Id = @id";
                        command.Parameters.AddWithValue("id", store.Id);
                        command.Parameters.AddWithValue("name", store.Name);
                        command.Parameters.AddWithValue("price", store.Price);
                        command.Parameters.AddWithValue("amount",store.Amount);
                        command.Parameters.AddWithValue("type", store.Type);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            isUpdated = true;
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        public static bool UpdateStore2(StoreModel store)
        {
            bool isUpdated = false;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"UPDATE [{_tableNameStore}] SET Name = @name, Price =  @price, Amount = @amount, Type=@type WHERE Id = @id";
                        command.Parameters.AddWithValue("id", store.Id);
                        command.Parameters.AddWithValue("name", store.Name);
                        command.Parameters.AddWithValue("price", store.Price);
                        command.Parameters.AddWithValue("amount", store.Amount);
                        command.Parameters.AddWithValue("type", store.Type);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            isUpdated = true;
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        public static bool UpdateGoodByName(StoreModel store)
        {
            bool isUpdated = false;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"UPDATE [{_tableNameStore}] SET Amount = Amount - @amount WHERE Name = @name AND Amount >= @amount";
                        command.Parameters.AddWithValue("name", store.Name);
                        command.Parameters.AddWithValue("amount", store.Amount);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            isUpdated = true;
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }


        public static bool UpdateGoods(StoreModel store)
        {
            bool isUpdated = false;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"UPDATE [{_tableNameStore}] SET  Amount = Amount - @amount WHERE Id = @id AND Amount>=@amount";
                        command.Parameters.AddWithValue("id", store.Id);
                        command.Parameters.AddWithValue("amount", store.Amount);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            isUpdated = true;
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        public static bool ResetAmountGoods(StoreModel store)
        {
            bool isUpdated = false;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"UPDATE [{_tableNameStore}] SET  Amount = Amount + @amount WHERE Id = @id";
                        command.Parameters.AddWithValue("id", store.Id);
                        command.Parameters.AddWithValue("amount", store.Amount);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            isUpdated = true;
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        public static bool ResetGoodByName(StoreModel store)
        {
            bool isUpdated = false;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"UPDATE [{_tableNameStore}] SET  Amount = Amount + @amount WHERE Name = @name";
                        command.Parameters.AddWithValue("name", store.Name);
                        command.Parameters.AddWithValue("amount", store.Amount);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            isUpdated = true;
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        public static bool DeleteStoreById(int id)
        {
            return DeleteById(_tableNameStore, id);
        }

        #endregion

        #region TEMPOUTCOMES

        public static List<TempOutcomesModel> SelectAllTempOutcomes()
        {
            var items = new List<TempOutcomesModel>();

            try
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] ", _tableNameTempOutcomes);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var roomName = reader[1].ToString();
                        var name = reader[2].ToString();
                        var price = int.Parse(reader[3].ToString());
                        var amount = int.Parse(reader[4].ToString());
                        var dateOrder = reader[5].ToString();

                        var item = new TempOutcomesModel();
                        item.Id = id;
                        item.RoomName = roomName;
                        item.Name = name;
                        item.Price = price;
                        item.Amount = amount;
                        item.DateOrder = dateOrder;

                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        public static int InsertTempOutcomes(TempOutcomesModel temp)
        {
            int lastId = -1;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tableNameTempOutcomes}](RoomName, Name, Price, Amount, DateOrder) VALUES(@roomName, @name, @price, @amount, @dateOrder)";
                        command.Parameters.AddWithValue("roomName",temp.RoomName);
                        command.Parameters.AddWithValue("name", temp.Name);
                        command.Parameters.AddWithValue("price",temp.Price);
                        command.Parameters.AddWithValue("amount",temp.Amount);
                        command.Parameters.AddWithValue("dateOrder", temp.DateOrder);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return lastId;
        }

        public static bool UpdateTempOutcomes(TempOutcomesModel temp)
        {
            bool isUpdated = false;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"UPDATE [{_tableNameTempOutcomes}] SET Amount = @amount, DateOrder=@dateOrder WHERE Id = @id";
                        command.Parameters.AddWithValue("id", temp.Id);
                        command.Parameters.AddWithValue("amount", temp.Amount);
                        command.Parameters.AddWithValue("dateOrder", temp.DateOrder);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            isUpdated = true;
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        public static bool DeleteTempOutcomesrById(int tempId)
        {
            return DeleteById(_tableNameTempOutcomes, tempId);
        }

        #endregion

        #region OUTCOMES

        public static List<OutcomesModel> SelectAllOutcomes()
        {
            var items = new List<OutcomesModel>();

            try
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] ", _tableNameOutcomes);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var roomId = reader[1].ToString();
                        var name = reader[2].ToString();
                        var price = int.Parse(reader[3].ToString());
                        var amount = int.Parse(reader[4].ToString());
                        var dateOrder = reader[5].ToString();

                        var item = new OutcomesModel();
                        item.Id = id;
                        item.RoomId = roomId;
                        item.NameGoods = name;
                        item.PriceGoods = price;
                        item.AmountGoods = amount;
                        item.DateOrder = dateOrder;

                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        public static int InsertOutcomes(OutcomesModel outcomes)
        {
            int lastId = -1;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tableNameOutcomes}](RoomId, NameGoods, PriceGoods,AmountGoods,DateOrder) VALUES(@roomId, @name, @price, @amount, @dateOrder)";
                        command.Parameters.AddWithValue("roomId", outcomes.RoomId);
                        command.Parameters.AddWithValue("name", outcomes.NameGoods);
                        command.Parameters.AddWithValue("price", outcomes.PriceGoods);
                        command.Parameters.AddWithValue("amount", outcomes.AmountGoods);
                        command.Parameters.AddWithValue("dateStart", outcomes.DateOrder);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return lastId;
        }

        #endregion

        #region TOTALOUTCOMES

        public static List<TotalOutcomesModel> SelectAllTotalOutcomes()
        {
            var items = new List<TotalOutcomesModel>();

            try
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] ", _tableNameTotalOutcomes);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var roomId = reader[1].ToString();
                        var timerStart = reader[2].ToString();
                        var timerFinish = reader[3].ToString();
                        var sum= int.Parse(reader[4].ToString());

                        var item = new TotalOutcomesModel();
                        item.Id = id;
                        item.RoomId = roomId;
                        item.DateStart = timerStart;
                        item.DateFinish = timerFinish;
                        item.TotalSum = sum;
                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        public static int InsertTotalOutcomes(TotalOutcomesModel totalOutcomes)
        {
            int lastId = -1;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tableNameTotalOutcomes}](RoomId, DateStart, DateFinish TotalSum) VALUES(@roomId, @dateStart, @dateFinish @totalSum)";
                        command.Parameters.AddWithValue("roomId", totalOutcomes.RoomId);
                        command.Parameters.AddWithValue("dateStart", totalOutcomes.DateStart);
                        command.Parameters.AddWithValue("dateFinish", totalOutcomes.DateFinish);
                        command.Parameters.AddWithValue("totalSum",totalOutcomes.TotalSum);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return lastId;
        }

        #endregion

        #region SETTING_PRICE_TIME

        public static List<PriceTimeModel> SelectPriceTime()
        {
            var items = new List<PriceTimeModel>();

            try
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] ", _tableNamePriceTime);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var name = reader[1].ToString();
                        var priceTime = int.Parse(reader[2].ToString());

                        var item = new PriceTimeModel();
                        item.Id = id;
                        item.Name = name;
                        item.Price = priceTime;

                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        public static bool UpdatePriceTime(PriceTimeModel priceTime)
        {
            bool isUpdated = false;
            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"UPDATE [{_tableNamePriceTime}] SET Name=@name, PriceTime = @priceTime WHERE Id = @id";
                        command.Parameters.AddWithValue("id", priceTime.Id);
                        command.Parameters.AddWithValue("name",priceTime.Name);
                        command.Parameters.AddWithValue("priceTime", priceTime.Price);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            isUpdated = true;
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        public static int InsertPriceTime(PriceTimeModel price)
        {
            int lastId = -1;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tableNamePriceTime}](Name,PriceTime) VALUES(@name,@price)";
                        command.Parameters.AddWithValue("name", price.Name);
                        command.Parameters.AddWithValue("price",price.Price);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return lastId;
        }

        public static bool DeletePriceById(int id)
        {
            return DeleteById(_tableNamePriceTime, id);
        }

        #endregion

        #region BARTABLES

        public static List<BarTableModel> SelectAllBarTables()
        {
            var items = new List<BarTableModel>();

            try
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] ", _tableNameBarTables);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var name = reader[1].ToString();

                        var item = new BarTableModel();
                        item.Id = id;
                        item.Name = name;

                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        public static int InsertBarTable(BarTableModel table)
        {
            int lastId = -1;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tableNameBarTables}](Name) VALUES(@name)";
                        command.Parameters.AddWithValue("name", table.Name);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return lastId;
        }

        public static bool DeleteBarTableById(int id)
        {
            return DeleteById(_tableNameBarTables, id);
        }

        #endregion

        #region INCOMES

        public static List<IncomesModel> SelectAllIncomesGoods()
        {
            var items = new List<IncomesModel>();

            try
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] ", _tableNameIncomes);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var name = reader[1].ToString();
                        var price = int.Parse(reader[2].ToString());
                        var amount = int.Parse(reader[3].ToString());
                        var dateIncomes = reader[4].ToString();

                        var item = new IncomesModel();
                        item.Id = id;
                        item.Name = name;
                        item.Price = price;
                        item.Amount = amount;
                        item.DateIncomes = dateIncomes;

                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        public static int InsertIncomes(IncomesModel incomes)
        {
            int lastId = -1;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tableNameIncomes}](Name,Price,Amount,DateIncomes) VALUES(@name, @price, @amount,@dateIncomes)";
                        command.Parameters.AddWithValue("name", incomes.Name);
                        command.Parameters.AddWithValue("price", incomes.Price);
                        command.Parameters.AddWithValue("amount", incomes.Amount);
                        command.Parameters.AddWithValue("dateIncomes",incomes.DateIncomes);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return lastId;
        }

        #endregion

        #region EXPENSES

        public static List<ExpensesModel> SelectExpenses()
        {
            var items = new List<ExpensesModel>();

            try
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] ", _tableNameExpenses);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var name = reader[1].ToString();
                        var price = int.Parse(reader[2].ToString());
                        var date = reader[3].ToString();

                        var item = new ExpensesModel();
                        item.Id = id;
                        item.Name = name;
                        item.Price = price;
                        item.Date = date;

                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        public static int InsertExpenses(ExpensesModel expenses)
        {
            int lastId = -1;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tableNameExpenses}](Name,Price,Date) VALUES(@name, @price,@date)";
                        command.Parameters.AddWithValue("name", expenses.Name);
                        command.Parameters.AddWithValue("price", expenses.Price);
                        command.Parameters.AddWithValue("date", expenses.Date);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return lastId;
        }

        public static bool UpdateExpenses(ExpensesModel expenses)
        {
            bool isUpdated = false;
            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"UPDATE [{_tableNameExpenses}] SET Name=@name, Price = @price WHERE Id = @id";
                        command.Parameters.AddWithValue("id", expenses.Id);
                        command.Parameters.AddWithValue("name",expenses.Name);
                        command.Parameters.AddWithValue("price", expenses.Price);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            isUpdated = true;
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }


        #endregion

        #region ENCASH

        public static List<EncashModel> SelectAllEncash()
        {
            var items = new List<EncashModel>();

            try
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] ", _tableNameEncash);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var price = int.Parse(reader[1].ToString());
                        var date = reader[2].ToString();

                        var item = new EncashModel();
                        item.Id = id;
                        item.Price = price;
                        item.Date = date;

                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        public static int InsertEncash(EncashModel encash)
        {
            int lastId = -1;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tableNameEncash}](Price,Date) VALUES(@price, @dateIncomes)";
                        command.Parameters.AddWithValue("price", encash.Price);
                        command.Parameters.AddWithValue("dateIncomes", encash.Date);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return lastId;
        }

        public static bool DeleteEncashById(int id)
        {
            return DeleteById(_tableNameEncash, id);
        }

        #endregion

        #region EXPENSES_STORE

        public static List<Expenses_StoreModel> SelectExpenses_Store()
        {
            var items = new List<Expenses_StoreModel>();

            try
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] ", _tableNameExpenses_Store);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var name = reader[1].ToString();
                        var price = int.Parse(reader[2].ToString());
                        var date = reader[3].ToString();
                        var amount = int.Parse(reader[4].ToString());

                        var item = new Expenses_StoreModel();
                        item.Id = id;
                        item.Name = name;
                        item.Price = price;
                        item.Date = date;
                        item.Amount = amount;

                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        public static int InsertExpenses_Store(Expenses_StoreModel expenses_store)
        {
            int lastId = -1;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tableNameExpenses_Store}](Name, Price, Date, Amount) VALUES(@name, @price, @date, @amount)";
                        command.Parameters.AddWithValue("name", expenses_store.Name);
                        command.Parameters.AddWithValue("price", expenses_store.Price);
                        command.Parameters.AddWithValue("date", expenses_store.Date);
                        command.Parameters.AddWithValue("amount",expenses_store.Amount);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return lastId;
        }

        public static bool DeleteExpensesStoreById(int id)
        {
            return DeleteById(_tableNameExpenses_Store, id);
        }


        #endregion

        #region REPORT_GOODS

        public static List<ReportGoods> SelectAllReportGoods()
        {
            var items = new List<ReportGoods>();

            try
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] ", _tableNameReportGoods);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var name = reader[1].ToString();
                        var amount = int.Parse(reader[2].ToString());
                        var price = int.Parse(reader[3].ToString());

                        var item = new ReportGoods();
                        item.Id = id;
                        item.Name = name;
                        item.Price = price;
                        item.Amount = amount;

                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        #endregion

        #region STORE_REPORT

        public static List<StoreReportModel> SelectAllStoreReport()
        {
            var items = new List<StoreReportModel>();

            try
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("SELECT * FROM [{0}] ", _tableNameStoreReport);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = int.Parse(reader[0].ToString());
                        var name = reader[1].ToString();
                        var amount = int.Parse(reader[2].ToString());
                        var date = reader[3].ToString();
                        var type = reader[4].ToString();

                        var item = new StoreReportModel();
                        item.Id = id;
                        item.Name = name;
                        item.Amount = amount;
                        item.Date = date;
                        item.Type = type;

                        items.Add(item);
                    }
                }
            }
            catch
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return items;
        }

        public static int InsertStoreReport(StoreReportModel Store)
        {
            int lastId = -1;

            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"INSERT INTO [{_tableNameStoreReport}](Name,Amount,Date,Type) VALUES(@name, @amount, @dateIncomes, @type)";
                        command.Parameters.AddWithValue("name", Store.Name);
                        command.Parameters.AddWithValue("amount", Store.Amount);
                        command.Parameters.AddWithValue("dateIncomes", Store.Date);
                        command.Parameters.AddWithValue("type", Store.Type);

                        int rowsInserted = command.ExecuteNonQuery();

                        if (rowsInserted > 0)
                        {
                            command.CommandText = "select last_insert_rowid()";
                            lastId = Convert.ToInt32(command.ExecuteScalar());
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //wrongData.Add(item);
            }
            finally
            {
                connection.Close();
            }

            return lastId;
        }

        public static bool DeleteStoreReportById(int id)
        {
            return DeleteById(_tableNameStoreReport, id);
        }

        #endregion
        #endregion
    }
}
