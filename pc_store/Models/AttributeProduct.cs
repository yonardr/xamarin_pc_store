using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace pc_store.Models
{
    [Table("AttributeProduct")]
    public class AttributeProduct
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int prod_id { get; set; }
        public int attribute_id { get; set; }
    }
}
