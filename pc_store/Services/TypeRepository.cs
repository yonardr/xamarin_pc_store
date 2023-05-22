using pc_store.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace pc_store.Services
{
    public partial class Repository
    {
        public IEnumerable<Types> GetTypes()
        {
            return database.Table<Types>().ToList();
        }
        public Types GetType(int id)
        {
            return database.Get<Types>(id);
        }
        public int DeleteType(int id)
        {
            return database.Delete<Types>(id);
        }
        public int SaveType(Types item)
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
