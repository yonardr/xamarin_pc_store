using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace pc_store.Models
{
    [Table("CartsOrder")]
    public class CartsOrder
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }
        public int order_id { get; set; }
        public int cart_id { get; set; }

    }
}
