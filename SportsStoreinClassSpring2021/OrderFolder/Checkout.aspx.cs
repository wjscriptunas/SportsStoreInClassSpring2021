using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStoreinClassSpring2021.OrderFolder
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckoutBtn_click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // create the sql connection using that connection string
            SqlConnection conn = new SqlConnection(connString);

            // create the sql command object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spCreateCustomerOrder";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // add the parameter
            SqlParameter param = new SqlParameter("@cartID", Request.Cookies["SportsStore_CartID"].Value);
            param.SqlDbType = System.Data.SqlDbType.NVarChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter("customerid", User.Identity.GetUserId());
            param.SqlDbType = System.Data.SqlDbType.NVarChar;
            cmd.Parameters.Add(param);

            SqlParameter orderIDparam = new SqlParameter("@orderid", System.Data.SqlDbType.Int);
            orderIDparam.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(orderIDparam);

            
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                cmd.Connection.Close();

            Response.Redirect("~/OrderFolder/OrderPlaced.aspx?OrderId=" + orderIDparam.Value); // sending the user to a new page when they click on the checkout button, order placed page
        }
    }
}