using System;
using System.Data.SqlClient;

namespace DAL
{
    public class Connection
    {
        static SqlConnection connection;
        public static void GenerarConexion()
        {
            connection = new SqlConnection();
            try
            {
                connection.ConnectionString = "server=servidordebrasil;database=surdebrasil.database.windows.net;uid=saboresdelatierra;pwd=#Mitesoro;";
                connection.Open();
            }
            catch 
            {
                //gestion del error
            }
        }
        public static String ConnectionState() 
        {
            return connection.State.ToString();
        }
    }
}
