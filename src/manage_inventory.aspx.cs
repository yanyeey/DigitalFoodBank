using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;

namespace FYP_DFB
{
    public partial class manage_inventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!IsPostBack)
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

        protected void submit_button_Click(object sender, EventArgs e)
        {
            // Convert the input quantities to integers
            int inputFruitsQuantity = int.Parse(Fruits_Quantity.Text);
            int inputVegetablesQuantity = int.Parse(Vegetables_Quantity.Text);
            int inputDairyAndEggsQuantity = int.Parse(Dairy_Eggs_Quantity.Text);
            int inputMeatQuantity = int.Parse(Meat_Quantity.Text);
            int inputSeafoodQuantity = int.Parse(Seafood_Quantity.Text);
            int inputBreadsCerealsQuantity = int.Parse(Breads_Cereals_Quantity.Text);
            int inputSweetsSnacksBeveragesQuantity = int.Parse(Sweets_Snacks_Beverages_Quantity.Text);
            int inputCannedProductsQuantity = int.Parse(Canned_Quantity.Text);

            // Update the inventory quantities in the database
            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();
            string query4 = "update INVENTORY set inventory_fruit_quantity = '" + inputFruitsQuantity + "', inventory_vegetable_quantity = '" + inputVegetablesQuantity + "', inventory_dairy_egg_quantity = '" + inputDairyAndEggsQuantity + "', inventory_meat_quantity = '" + inputMeatQuantity + "', inventory_seafood_quantity = '" + inputSeafoodQuantity + "', inventory_bread_cereal_quantity = '" + inputBreadsCerealsQuantity + "', inventory_sweet_snack_quantity = '" + inputSweetsSnacksBeveragesQuantity + "', inventory_canned_quantity = '" + inputCannedProductsQuantity + "'";
            SqlCommand cmd4 = new SqlCommand(query4, dbconnection1);
            cmd4.ExecuteNonQuery();

            dbconnection1.Close();

            Response.Redirect(Request.Url.AbsoluteUri);

        }
    }
}