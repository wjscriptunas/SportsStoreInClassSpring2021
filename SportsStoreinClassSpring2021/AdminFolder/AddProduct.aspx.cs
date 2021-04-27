using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStoreinClassSpring2021.AdminFolder
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddProductButton_Click(object sender, EventArgs e)
        {
            int categoryID = int.Parse(prodCatDDL.SelectedValue);
            string productName = prodNameTxtbox.Text;
            string productDesc = prodDescTxtbox.Text;
            decimal productPrice = Decimal.Parse(prodPriceTxtbox.Text);
            string image = prodImage.FileName;

            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // create the sql connection using that connection string
            SqlConnection conn = new SqlConnection(connString);

            // create the sql command object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spAddProduct";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // add the parameter
            SqlParameter param = new SqlParameter("@CategoryID", catID);
            param.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DescriptionLength", 60);
            param.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(param);

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
        }
    }
}