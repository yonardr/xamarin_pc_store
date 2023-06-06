using pc_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void SaveAttrinbute(Attributes a, int prod_id)
        {
            database.Insert(a);
            int id_attr = database.Table<Attributes>().Last().Id;
            AttributeProduct add = new AttributeProduct() { 
                prod_id= prod_id,
                attribute_id = id_attr
            };
            database.Insert(add);
        }
        public IEnumerable<Attributes> GetAttrs(int prod_id)
        {
            List<Attributes> attrs = new List<Attributes>();
            var all_ids_attr =  database.Table<AttributeProduct>().Where(i => i.prod_id == prod_id);
            foreach (var attr in all_ids_attr)
            {
                var a = database.Table<Attributes>().Where(i=> i.Id == attr.attribute_id).FirstOrDefault();
                attrs.Add(a);
            }
            return attrs;
        }

    }
}
