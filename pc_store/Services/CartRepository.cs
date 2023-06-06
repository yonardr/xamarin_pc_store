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
            //int i = 1;
            //while (i<100)
            //{
            //    database.Delete<UserCart>(i);
            //    database.Delete<Cart>(i);
            //    i++;
            //}
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
            var ff = database.Table<CartsOrder>().ToList();
            foreach (var item in carts_ids)
            {
                bool flag = true;
                
                foreach (var o in ff)
                {
                    if (item.cart_id == o.cart_id) flag = false;
                }
                if (flag)
                {
                    var c = database.Table<Cart>().ToList().Where(i => i.Id == item.cart_id).FirstOrDefault();
                    cart.Add(c);
                }
            }

            return cart;
        }
        public int DeleteCart(int id, int user_id)
        {
            var find = database.Table<UserCart>().Where(i => i.cart_id == id && i.user_id == user_id).FirstOrDefault();
            database.Delete<UserCart>(find.id);
            return database.Delete<Cart>(id);
        }
        public void SaveCart(Cart item, int user_id)
        {
            int ins = 0;
            if (item.Id != 0)
            {
                database.Update(item);
               
            }
            else
            {
                 database.Insert(item);
                ins = database.Table<Cart>().Last().Id;
            }
            UserCart u = new UserCart()
            {
                cart_id = ins,
                user_id = user_id
            };
            database.Insert(u);

        }

        public int CreateOrder(List<int> carts, int user_id, double price)
        {
            Orders order = new Orders() {
                status = "Обрабатывается",
                date = Convert.ToString(DateTime.Now),
                price = price,
                user_id=user_id
            };

            database.Insert(order);

            int id_order = database.Table<Orders>().Last().Id;
            CartsOrder item = new CartsOrder();
            foreach (var id_cart in carts)
            {
                item.cart_id = id_cart;
                item.order_id = id_order;
                database.Insert(item);
            }
            return id_order;
        }

        public IEnumerable<Orders> GerOrders(int user_id)
        {
            return database.Table<Orders>().ToList().Where(i=> i.user_id == user_id);
        }

        public IEnumerable<Cart> GerDataOrder(int order_id)
        {
            var orders = database.Table<CartsOrder>().ToList().Where(i=> i.order_id == order_id);
            List<Cart> carts = new List<Cart>();
            foreach (var o in orders)
            {
                foreach( var item in database.Table<Cart>().Where(i => i.Id == o.cart_id))
                {
                    carts.Add(item);
                }
            }
            return carts;
        }
    }
}
