using System;
using System.Data;
using System.Data.SqlClient;
using AutomationFramework.Configuration;

namespace SeleniumWebdriver.ComponentHelper
{
    class DBAccessHelper
    {
        private static SqlConnection connection = new SqlConnection();
        private static string strConnString = @"";


        public static SqlConnection openConn()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString;
                    connection.Open();
                    return connection;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void closeConn()
        {
            connection.Close();
        }
    }
}

