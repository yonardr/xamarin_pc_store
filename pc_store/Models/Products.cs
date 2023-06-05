using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace pc_store.Models
{
    
        [Table("Products")]
        public class Products
        {
            [PrimaryKey, AutoIncrement, Column("_id")]
            public int Id { get; set; }
            [Unique]public string name { get; set; }
            public int price { get; set; }
            public string description { get; set; }
            public int type { get; set;}
            public string img { get; set; }
            public int quantity { get; set; }
        }
    
}
