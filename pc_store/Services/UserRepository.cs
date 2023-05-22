using pc_store.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace pc_store.Services
{
    public partial class Repository
    {
        public IEnumerable<Users> GetUsers()
        {
            return database.Table<Users>().ToList();
        }
        public Users GetUser(int id)
        {
            return database.Get<Users>(id);
        }
        public int DeleteUser(int id)
        {
            return database.Delete<Users>(id);
        }
        public int SaveUser(Users item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
