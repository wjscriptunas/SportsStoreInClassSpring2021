using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SportsStoreinClassSpring2021
{
    public class ShoppingCartAccess
    {
        public static void AddToCart(string prodID, string cartID)
        {

            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // create the sql connection using that connection string
            SqlConnection conn = new SqlConnection(connString);

            // create the sql command object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "ShoppingCartAddItem";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // add the parameter
            SqlParameter param = new SqlParameter("@cartID", cartID);
            param.SqlDbType = System.Data.SqlDbType.NVarChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@productID", prodID);
            param.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@attributes", "none");
            param.SqlDbType = System.Data.SqlDbType.NVarChar;
            cmd.Parameters.Add(param);

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n\n\n" + ex + "\n\n\n");
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}