using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStoreinClassSpring2021.OrderFolder
{
    public partial class OrderPlaced : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string orderid = Request.QueryString["OrderId"].ToString();

            Label1.Text = orderid;
        }
    }
}