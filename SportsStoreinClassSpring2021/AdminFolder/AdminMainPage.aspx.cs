using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStoreinClassSpring2021.AdminFolder
{
    public partial class AdminMainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addNewProductBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdminFolder/AddProduct.aspx");
        }
    }
}