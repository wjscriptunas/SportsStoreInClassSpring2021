using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SportsStoreinClassSpring2021
{
    public class CatalogAccess // utility class
    {
        public static DataTable GetProductsbyCatID(string catID)
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // create the sql connection using that connection string
            SqlConnection conn = new SqlConnection(connString);

            // create the sql command object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spGetProductsInCategory";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // add the parameter
            SqlParameter param = new SqlParameter("@CategoryID", catID);
            param.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DescriptionLength", 60);
            param.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(param);

            DataTable table = new DataTable();

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Connection.Close();
            }
            return table;

        }
        public static DataTable GetProductsByDeptID(string deptID)
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // create the sql connection using that connection string
            SqlConnection conn = new SqlConnection(connString);

            // create the sql command object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spGetAllProductsByDeptID";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // add the parameter
            SqlParameter param = new SqlParameter("@deptID", deptID);
            param.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(param);

            DataTable table = new DataTable();

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Connection.Close();
            }
            return table;
        }

        public static Product GetProductDetails(string productID)
        {
            //we will call the sp here
            // create the connectin string
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // create the sql connection using that connection string
            SqlConnection conn = new SqlConnection(connString);

            // create the sql command object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spGetProductDetails";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // add the parameter
            SqlParameter param = new SqlParameter("@prodid", productID);
            param.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(param);

            DataTable table = new DataTable();

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
                reader.Close(); // releases the resources that are not needed anymore
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Connection.Close();
            }

            // which will give us a single row(single product)
            Product pd = new Product();
            if(table.Rows.Count > 0)
            {
                DataRow dr = table.Rows[0];

                pd.ProductID = int.Parse(dr["ProductID"].ToString());
                pd.Name = dr["Name"].ToString();
                pd.Price = decimal.Parse(dr["Price"].ToString());
                pd.Description = dr["Description"].ToString();
                pd.Thumbnail = dr["Thumbnail"].ToString();
                pd.Image = dr["Image"].ToString();

            }
            return pd;

            // we will package that single row into a product object and pass it to the caller
            // the caller will unpack this object and plug in the inidividual 
        }
        public static DataTable GetAllDepartments()
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // create the sql connection using that connection string
            SqlConnection conn = new SqlConnection(connString);

            // create the sql command object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spGetAllDepts";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DataTable table = new DataTable();

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Connection.Close();
            }
            return table;
        }
        
        public static DataTable GetAllCategoriesByDeptID(string deptID)
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // create the sql connection using that connection string
            SqlConnection conn = new SqlConnection(connString);

            // create the sql command object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spGetCategoriesByDeptID";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@deptID", deptID);
            param.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(param);

            DataTable table = new DataTable();

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Connection.Close();
            }
            return table;
        }
    }
}