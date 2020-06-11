using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Data.SqlClient;

namespace TankLevelWebJob
{
    public class Functions
    {
        public static void ProcessTiemrAction([TimerTrigger("0 0 * * * *", RunOnStartup = true)] TimerInfo timerinfo, ILogger logger)
        {
            logger.LogInformation(DateTime.Now.ToString());

            // Get the connection string from app settings and use it to create a connection.
            var str = Environment.GetEnvironmentVariable("sqldb_connection");
            //str = "Server=tcp:deliverplandbserver.database.windows.net,1433;Initial Catalog=DeliverPlan_db;Persist Security Info=False;User ID=PlanningAdmin;Password=K0ng0Afr!ca;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    var text = "UPDATE dbo.Tank" +
                            " SET [Level] = ROUND(Level - RAND(),1)" +
                            " WHERE Level > 0;";

                    using (SqlCommand cmd = new SqlCommand(text, conn))
                    {
                        // Execute the command and log the # rows affected.
                        int rows = cmd.ExecuteNonQuery();
                        Console.WriteLine(rows + " rows effected");
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}