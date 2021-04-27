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
            if(!IsPostBack)
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

        protected void UpdateQty_Btn_Click(object sender, EventArgs e)
        {
            int rowCount = GridView1.Rows.Count;

            string productID;

            int newQty;

            bool success = true;

            GridViewRow gridRow;
            TextBox qtyTextBox;

            for(int i = 0; i < rowCount; i++)
            {
                gridRow = GridView1.Rows[i]; // current row of the grid view
                productID = GridView1.DataKeys[i].Value.ToString(); // current data key from the grid view (0th row)

                qtyTextBox = (TextBox)gridRow.FindControl("editQty");

                if(Int32.TryParse(qtyTextBox.Text, out newQty))
                {
                    success = success && ShoppingCartAccess.UpdateItem(productID, newQty);
                }
                else
                {
                    success = false;
                }
            }

            cartUpdateStatusLabel.Text = success ? "The cart was successfully updated!!" : "Some quantity updates failed!! Please check your cart!!";

            PopulateControls();
        }

        protected void Checkout_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/OrderFolder/Checkout.aspx");
        }
    }
}