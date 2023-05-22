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
            public string name { get; set; }
            public string price { get; set; }
            public string description { get; set; }
            public int type { get; set;}
            public string img { get; set; }
        }
    
}
