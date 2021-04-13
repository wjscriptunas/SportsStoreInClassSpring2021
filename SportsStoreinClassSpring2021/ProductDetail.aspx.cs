using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStoreinClassSpring2021
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }
        protected void PopulateControls()
        {
            string prodID = Request.QueryString["ProductID"];

            Product pd = CatalogAccess.GetProductDetails(prodID);

            titleLabel.Text = pd.Name;
            prodImage.ImageUrl = "Images/" + pd.Image;
            descLabel.Text = pd.Description;
            priceLabel.Text = string.Format("{0:c}", pd.Price);
        }


        protected void addToCart_Btn_Click(object sender, EventArgs e)
        {
            string prodID = Request.QueryString["ProductID"];

            string cartID;

            // if the user has a cart already, fetch their cartid from their machine(cookies)
            if(Request.Cookies["SportsStore_CartID"] != null)
            {
                cartID = Request.Cookies["SportsStore_CartID"].Value;
            }
            // if they dont have a cart already, generate a unique cartID for them and write on their machine
            else
            {
                cartID = Guid.NewGuid().ToString();

                HttpCookie cookie = new HttpCookie("SportsStore_CartID", cartID);

                TimeSpan timeSpan = new TimeSpan(10, 0, 0, 0);

                DateTime expirationDate = DateTime.Now.Add(timeSpan);

                cookie.Expires = expirationDate;

                Response.Cookies.Add(cookie);
            }

            ShoppingCartAccess.AddToCart(prodID, cartID);
        }
    }
}