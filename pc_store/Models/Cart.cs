using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace pc_store.Models
{
    [Table("Cart")]
    public class Cart
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int prod_id { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
    }
}
