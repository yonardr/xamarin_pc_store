using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace pc_store.Models
{
    [Table("Orders")]
    public class Orders
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        
        public string status { get; set; }
        public string date { get; set; } 
        public double price { get; set; }   
    }
}
