using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.Common;

namespace GameWiki.Core
{
    public class DataAccess
    {
        public const int COMMAND_TIMEOUT = 300;
        public const string DEFAULT_SESSION_SETTING = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; SET NOCOUNT ON;";

        public static String CreateCommand(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                if(command.ExecuteScalar().ToString() == null)
                {
                    return "null";
                }
                else
                {
                    return command.ExecuteScalar().ToString();
                }
            }
        }
    }
}