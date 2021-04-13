using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStoreinClassSpring2021
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }
        protected void PopulateControls()
        {
            string deptID = Request.QueryString["DepartmentID"];
            string catID = Request.QueryString["CategoryID"];

            if(catID != null)
            {
                DataList1.DataSource = CatalogAccess.GetProductsbyCatID(catID);
                DataList1.DataBind();
            }
            else if(deptID != null)
            {
                DataList1.DataSource = CatalogAccess.GetProductsByDeptID(deptID);
                DataList1.DataBind();
            }
            else
            {
                deptID = "1";
                DataList1.DataSource = CatalogAccess.GetProductsByDeptID(deptID);
                DataList1.DataBind();
            }
        }
    }
}