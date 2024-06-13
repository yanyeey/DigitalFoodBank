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
    public partial class member_donation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!Page.IsPostBack)
            {
                // Create a DataTable with sample data
                DataTable dt_sample = new DataTable();
                dt_sample.Columns.Add("Column1");
                dt_sample.Columns.Add("Column2");
                dt_sample.Columns.Add("Column3");
                dt_sample.Columns.Add("Column4");
                dt_sample.Columns.Add("Column5");

                // Add sample rows to the DataTable
                dt_sample.Rows.Add("Value A", "Value I", "Value I", "Value 1", "Value 1");
                dt_sample.Rows.Add("Value B", "Value II", "Value I", "Value 2", "Value 1");
                dt_sample.Rows.Add("Value C", "Value III", "Value I", "Value 3", "Value 1");

                BindGridViewData();
            }

        }

        private void BindGridViewData()
        {
            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT donation_id, donation_date, donation_time, donation_pickup_service, donation_status FROM DONATION_FORM where donation_member_id = '" + Session["member_id"].ToString() + "'", dbconnection1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            GridView1.DataSource = dt1;
            GridView1.DataBind();

            dbconnection1.Close();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                string donationID = e.CommandArgument.ToString();
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                string memberID = Session["member_id"].ToString();

                Response.Redirect("details_donation_member.aspx?donationID=" + donationID + "&memberID=" + memberID);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim(); // Get the search term entered by the user

            // Retrieve the original data from the database or data source into a DataTable
            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT donation_id, donation_date, donation_time, donation_pickup_service, donation_status FROM DONATION_FORM where donation_member_id = '" + Session["member_id"].ToString() + "'", dbconnection1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            dbconnection1.Close();

            // Filter the original data based on the search term
            DataTable filteredData = FilterData(dt1, searchTerm);

            // Bind the filtered data to the GridView
            GridView1.DataSource = filteredData;
            GridView1.DataBind();

        }

        private DataTable FilterData(DataTable originalData, string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Filter the original data based on search query (case-insensitive)
                var filteredRows = originalData.AsEnumerable()
                    .Where(row => row.Field<string>("donation_id").IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                   row.Field<string>("donation_status").IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);

                // Create a new DataTable with the filtered rows
                DataTable filteredData = filteredRows.Any() ? filteredRows.CopyToDataTable() : originalData.Clone();
                return filteredData;
            }

            // If no search term provided, return the original data
            return originalData;
        }
    }
}
