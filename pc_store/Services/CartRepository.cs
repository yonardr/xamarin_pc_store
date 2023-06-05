using pc_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pc_store.Services
{
    public partial class Repository
    {
        public IEnumerable<UserCart> Getttt()
        {
            return database.Table<UserCart>().ToList();
        }
        public IEnumerable<Cart> GetCarts()
        {
            return database.Table<Cart>().ToList();
        }
        public IEnumerable<Cart> GetCartsUser(int id)
        {
            List<Cart> cart = new List<Cart>();
            var carts_ids =  database.Table<UserCart>().ToList().Where(i=> i.user_id == id);
            foreach (var item in carts_ids)
            {
                var c = database.Table<Cart>().ToList().Where(i=> i.Id == item.cart_id).FirstOrDefault();
                cart.Add(c);
            }

            return cart;
        }
        public int DeleteCart(int id, int user_id)
        {
            var find = database.Table<UserCart>().Where(i => i.cart_id == id && i.user_id == user_id).FirstOrDefault();
            database.Delete(find);
            return database.Delete<Cart>(id);
        }
        public void SaveCart(Cart item, int user_id)
        {
            var ins = 0;
            if (item.Id != 0)
            {
                database.Update(item);
               
            }
            else
            {
                ins = database.Insert(item);
            }
            UserCart u = new UserCart()
            {
                cart_id = ins,
                user_id = user_id
            };
            database.Insert(u);

        }
    }
}
