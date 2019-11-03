using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Frigate.Infrastructure.DbImplementation.Common
{
   public class Helper
    {
       private SqlConnection SqlCon=null;
        private MySqlConnection MySqlCon = null;
        public Helper(string connectionString,String ConnectionType)
        {
            if (ConnectionType == "Sql")
            {
                SqlCon = new SqlConnection(connectionString);
            }
           else if (ConnectionType == "MySql")
            {
                MySqlCon = new MySqlConnection(connectionString);
            }
        }

        public bool IsSqlConnection
        {
            get
            {
                if(SqlCon.State==System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool IsMySqlConnection
        {
            get
            {
                if (MySqlCon.State == System.Data.ConnectionState.Closed)
                {
                    MySqlCon.Open();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }
}
