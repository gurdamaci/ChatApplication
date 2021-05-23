using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MessageLogService.Tools.DAL
{
    public static class Mssql
    {
        //https://docs.microsoft.com/tr-tr/visualstudio/data-tools/create-a-simple-data-application-by-using-adonet?view=vs-2019
        public static void SaveMessage(MessageLog message)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Message"].ToString()))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SP_MESSAGE_INSERT", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Add input parameter for the stored procedure and specify what to use as its value.
                    sqlCommand.Parameters.Add(new SqlParameter("@user_id", SqlDbType.Int));
                    sqlCommand.Parameters["@user_id"].Value = 1;

                    // Add input parameter for the stored procedure and specify what to use as its value.
                    sqlCommand.Parameters.Add(new SqlParameter("@chat_room_id", SqlDbType.Int));
                    sqlCommand.Parameters["@chat_room_id"].Value = 1;


                    // Add input parameter for the stored procedure and specify what to use as its value.
                    sqlCommand.Parameters.Add(new SqlParameter("@message", SqlDbType.NVarChar, -1));
                    sqlCommand.Parameters["@message"].Value = message.MESSAGETEXT;

                    try
                    {
                        connection.Open();

                        // Run the stored procedure.
                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Customer ID was not returned. Account could not be created.");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }


}
