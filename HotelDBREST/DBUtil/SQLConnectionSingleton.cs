using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelDBREST.DBUtil
{
    public class SQLConnectionSingleton
    {
        private static SQLConnectionSingleton _instance = new SQLConnectionSingleton();

        public static SQLConnectionSingleton Instance => _instance;

        private SQLConnectionSingleton()
        {
            _dbConnection = new SqlConnection(ConnString);
            _dbConnection.Open();
        }

        private SqlConnection _dbConnection;

        private const String ConnString =
            @"#######";

        public SqlConnection DbConnection => _dbConnection;
    }
}