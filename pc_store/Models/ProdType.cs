using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace pc_store.Models
{
    [Table("ProdTypes")]
    public class ProdTypes
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int prod_id { get; set; }
        public int type_id { get; set; }

    }
}
