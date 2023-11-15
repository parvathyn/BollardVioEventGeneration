using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BollardVioEventGeneration
{
    public static class Utilities
    {
        public static DateTime GetCustomerPresentTime(string strConn, int CustomerID)
        {
            DateTime dateTime = new DateTime();
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand sqlCommand = new SqlCommand("CustomerPresenttime", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add("@cid", SqlDbType.BigInt).Value = (object)CustomerID;
                    connection.Open();
                    object obj = sqlCommand.ExecuteScalar();
                    connection.Close();
                    dateTime = DateTime.Parse(obj.ToString());
                }
            }
            return dateTime;
        }

    }
}
