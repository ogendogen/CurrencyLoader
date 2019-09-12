using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CurrencyLoader
{
    public class Database
    {
        private static Database database = null;
        public MySqlConnection dbConnection { get; } = null;
        private Database(string host, string user, string pass, string db)
        {
            string connectionString = String.Format("Server={0}; database={1}; UID={2}; password={3}", host, db, user, pass);
            dbConnection = new MySqlConnection(connectionString);
        }

        public static Database GetInstance(string host, string user, string pass, string db)
        {
            if (database == null)
            {
                database = new Database(host, user, pass, db);
            }

            return database;
        }
    }
}
