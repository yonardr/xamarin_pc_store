using pc_store.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace pc_store.Services
{
    public partial class Repository
    {
        public IEnumerable<Products> GetProducts()
        {
            return database.Table<Products>().ToList();
        }
        public Products GetProduct(int id)
        {
            return database.Get<Products>(id);
        }
        public int DeleteProduct(int id)
        {
            return database.Delete<Products>(id);
        }
        public int SaveProduct(Products item)
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
