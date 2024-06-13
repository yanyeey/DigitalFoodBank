using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_DFB
{
    public partial class inventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM INVENTORY", dbconnection1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            Fruits_Quantity.Text = dt1.Rows[0][0].ToString();
            Vegetables_Quantity.Text = dt1.Rows[0][1].ToString();
            Dairy_Eggs_Quantity.Text = dt1.Rows[0][2].ToString();
            Meat_Quantity.Text = dt1.Rows[0][3].ToString();
            Seafood_Quantity.Text = dt1.Rows[0][4].ToString();
            Breads_Cereals_Quantity.Text = dt1.Rows[0][5].ToString();
            Sweets_Snacks_Beverages_Quantity.Text = dt1.Rows[0][6].ToString();
            Canned_Quantity.Text = dt1.Rows[0][7].ToString();

        }
    }
}