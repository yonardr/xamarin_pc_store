using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace pc_store.Models
{
    [Table("Attributes")]
    public class Attributes
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
 
    }
}
