using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;

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

        public static DataTable GetCartItems()
        {
            HttpContext context = HttpContext.Current;

            string cartID;

            // if the user has a cart already, fetch their cartid from their machine(cookies)
            if (context.Request.Cookies["SportsStore_CartID"] != null)
            {
                cartID = context.Request.Cookies["SportsStore_CartID"].Value;
            }
            // if they dont have a cart already, generate a unique cartID for them and write on their machine
            else
            {
                cartID = Guid.NewGuid().ToString();

                HttpCookie cookie = new HttpCookie("SportsStore_CartID", cartID);

                TimeSpan timeSpan = new TimeSpan(10, 0, 0, 0);

                DateTime expirationDate = DateTime.Now.Add(timeSpan);

                cookie.Expires = expirationDate;

                context.Response.Cookies.Add(cookie);
            }

            // create the connection string
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // create the sql connection using that connection string
            SqlConnection conn = new SqlConnection(connString);

            // create the sql command object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spShoppingCartGetItems";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // add the parameter
            SqlParameter param = new SqlParameter("@cartID", cartID);
            param.SqlDbType = System.Data.SqlDbType.NVarChar;
            cmd.Parameters.Add(param);

            DataTable table = new DataTable();

            try
            {
                cmd.Connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                table.Load(rdr);
                rdr.Close();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n\n\n" + ex + "\n\n\n");
            }
            finally
            {
                cmd.Connection.Close();
            }

            return table;
        }
        
        public static decimal GetCartTotal()
        {
            HttpContext context = HttpContext.Current;

            string cartID;

            // if the user has a cart already, fetch their cartid from their machine(cookies)
            if (context.Request.Cookies["SportsStore_CartID"] != null)
            {
                cartID = context.Request.Cookies["SportsStore_CartID"].Value;
            }
            // if they dont have a cart already, generate a unique cartID for them and write on their machine
            else
            {
                cartID = Guid.NewGuid().ToString();

                HttpCookie cookie = new HttpCookie("SportsStore_CartID", cartID);

                TimeSpan timeSpan = new TimeSpan(10, 0, 0, 0);

                DateTime expirationDate = DateTime.Now.Add(timeSpan);

                cookie.Expires = expirationDate;

                context.Response.Cookies.Add(cookie);
            }

            // create the connection string
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // create the sql connection using that connection string
            SqlConnection conn = new SqlConnection(connString);

            // create the sql command object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spShoppingCartGetTotalAmount";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // add the parameter
            SqlParameter param = new SqlParameter("@cartID", cartID);
            param.SqlDbType = System.Data.SqlDbType.NVarChar;
            cmd.Parameters.Add(param);

            decimal cartTotal = 0;

            try
            {
                cmd.Connection.Open();
                decimal.TryParse(cmd.ExecuteScalar().ToString(), out cartTotal);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n\n\n" + ex + "\n\n\n");
            }
            finally
            {
                cmd.Connection.Close();
            }
            return cartTotal;
        }

        public static bool UpdateItem(string productID, int newQty)
        {
            HttpContext context = HttpContext.Current;

            string cartID;

            // if the user has a cart already, fetch their cartid from their machine(cookies)
            if (context.Request.Cookies["SportsStore_CartID"] != null)
            {
                cartID = context.Request.Cookies["SportsStore_CartID"].Value;
            }
            else
            {
                cartID = Guid.NewGuid().ToString();

                HttpCookie cookie = new HttpCookie("SportsStore_CartID", cartID);

                TimeSpan timeSpan = new TimeSpan(10, 0, 0, 0);

                DateTime expirationDate = DateTime.Now.Add(timeSpan);

                cookie.Expires = expirationDate;

                context.Response.Cookies.Add(cookie);
            }

            // create the connection string
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // create the sql connection using that connection string
            SqlConnection conn = new SqlConnection(connString);

            // create the sql command object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spShoppingCartUpdateItem";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // add the parameter
            SqlParameter param = new SqlParameter("@cartID", cartID);
            param.SqlDbType = System.Data.SqlDbType.NVarChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@productID", productID);
            param.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Qauntity", newQty);
            param.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(param);

            try
            {
                cmd.Connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\n\n\n" + ex + "\n\n\n");
            }
            finally
            {
                cmd.Connection.Close();
            }
            return false;
        }
    }
}