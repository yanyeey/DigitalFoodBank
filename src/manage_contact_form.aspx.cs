using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_DFB
{
    public partial class manage_contact_form : System.Web.UI.Page
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
                dt_sample.Rows.Add("Value 1", "Value A", "Value I", "Subject1", "A");
                dt_sample.Rows.Add("Value 2", "Value B", "Value II", "Subject2", "A");
                dt_sample.Rows.Add("Value 3", "Value C", "Value III", "Subject3", "A");

                BindGridViewData();
            }

        }

        private void BindGridViewData()
        {
            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT contact_id, contact_name, contact_email, contact_subject, contact_status FROM CONTACT_FORM", dbconnection1);
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
                string contactID = e.CommandArgument.ToString();
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                string contactEmail = row.Cells[2].Text;

                Response.Redirect("details_contact_form.aspx?contactID=" + contactID + "&contactEmail=" + contactEmail);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim(); // Get the search term entered by the user

            // Retrieve the original data from the database or data source into a DataTable
            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT contact_id, contact_name, contact_email, contact_subject FROM CONTACT_FORM", dbconnection1);
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
                // Filter the original data based on contact ID or contact email
                var filteredRows = originalData.AsEnumerable()
                    .Where(row => row.Field<string>("contact_id").IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                   row.Field<string>("contact_email").IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);

                // Create a new DataTable with the filtered rows
                DataTable filteredData = filteredRows.Any() ? filteredRows.CopyToDataTable() : originalData.Clone();
                return filteredData;
            }

            // If no search term provided, return the original data
            return originalData;
        }

    }
}