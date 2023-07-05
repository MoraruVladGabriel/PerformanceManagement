using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace WindowsFormsApp1.utils
{
    public class SqliteConnectionFactory : ConnectionFactory
    {
        public override IDbConnection createConnection(IDictionary<string,string> props)
        {
            String connectionString = props["ConnectionString"];

            //String connectionString = "Data Source=C:\Users\morar\Desktop\proiectMPPC#\proiect\festival.db;Version=3";
            return new SQLiteConnection(connectionString);
        }
    }
}