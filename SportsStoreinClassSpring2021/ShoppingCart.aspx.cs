using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStoreinClassSpring2021
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }
        public void PopulateControls()
        {
            DataTable dt = ShoppingCartAccess.GetCartItems();

            if(dt.Rows.Count > 0)
            {
                Label1.Text = "These are the items in your cart: ";
                GridView1.DataSource = dt;
                GridView1.DataBind();

                decimal amount = ShoppingCartAccess.GetCartTotal();
                cartTotalLabel.Text = String.Format("{0:c}", amount);

                UpdateQty_Btn.Enabled = true;
            }
            else
            {
                Label1.Text = "there are no items in your cart!!";
                GridView1.Visible = false;

                cartTotalLabel.Text = "0";
                UpdateQty_Btn.Enabled = false;
            }
        }
    }
}