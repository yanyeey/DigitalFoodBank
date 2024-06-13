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
    public partial class manage_volunteer_form : System.Web.UI.Page
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
                dt_sample.Columns.Add("Column6");

                // Add sample rows to the DataTable
                dt_sample.Rows.Add("Value 1", "Value A", "Value I", "Value I", "Value 1", "Value 1");
                dt_sample.Rows.Add("Value 2", "Value B", "Value II", "Value I", "Value 2", "Value 1");
                dt_sample.Rows.Add("Value 3", "Value C", "Value III", "Value I", "Value 3", "Value 1");

                BindGridViewData();
            }

        }

        private void BindGridViewData()
        {
            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT volunteer_id, volunteer_first_name, volunteer_last_name, volunteer_contact_no, volunteer_email, volunteer_state FROM VOLUNTEER_FORM", dbconnection1);
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
                string volunteerID = e.CommandArgument.ToString();
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                string volunteerEmail = row.Cells[4].Text;

                Response.Redirect("details_volunteer_form.aspx?volunteerID=" + volunteerID + "&volunteerEmail=" + volunteerEmail);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim(); // Get the search term entered by the user

            // Retrieve the original data from the database or data source into a DataTable
            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT volunteer_id, volunteer_first_name, volunteer_last_name, volunteer_contact_no, volunteer_email, volunteer_state FROM VOLUNTEER_FORM", dbconnection1);
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
                // Filter the original data based on search query
                var filteredRows = originalData.AsEnumerable()
                    .Where(row => row.Field<string>("volunteer_id").IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                   row.Field<string>("volunteer_contact_no").IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                   row.Field<string>("volunteer_email").IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                   row.Field<string>("volunteer_state").IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 );

                // Create a new DataTable with the filtered rows
                DataTable filteredData = filteredRows.Any() ? filteredRows.CopyToDataTable() : originalData.Clone();
                return filteredData;
            }

            // If no search term provided, return the original data
            return originalData;
        }

    }
}