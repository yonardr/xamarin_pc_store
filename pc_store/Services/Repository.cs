using pc_store.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace pc_store.Services
{
    public partial class Repository
    {
        SQLiteConnection database;
        public Repository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTables<Users, Products, Types, Cart, UserCart>();
            database.CreateTables<Orders, CartsOrder, Attributes, AttributeProduct>();
        }
        
    }
}
