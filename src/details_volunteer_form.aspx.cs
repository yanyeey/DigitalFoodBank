using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace FYP_DFB
{
    public partial class details_volunteer_form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!IsPostBack)
            {
                if (Request.QueryString["volunteerID"] != null && Request.QueryString["volunteerEmail"] != null)
                {
                    string volunteerID = Request.QueryString["volunteerID"];
                    string volunteerEmail = Request.QueryString["volunteerEmail"];

                    form_id.Text = volunteerID;
                    email.Text = volunteerEmail;

                    //Retrieve and display more details from the database based on the member ID
                    DisplayFormDetails(volunteerID);
                }
                else
                {
                    Response.Redirect("manage_volunteer_form.aspx");
                }
            }
        }

        private void DisplayFormDetails(string volunteerID)
        {
            // Fetch additional details from the database based on the form ID
            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            // Display record from first table
            SqlDataAdapter da1 = new SqlDataAdapter("select * from VOLUNTEER_FORM where volunteer_id = '" + volunteerID + "'", dbconnection1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            form_id.Text = dt1.Rows[0][0].ToString();
            first_name.Text = dt1.Rows[0][1].ToString();
            last_name.Text = dt1.Rows[0][2].ToString();
            gender.Text = dt1.Rows[0][3].ToString();
            dob.Text = Convert.ToDateTime(dt1.Rows[0][4]).ToShortDateString();
            contact_no.Text = dt1.Rows[0][5].ToString();
            email.Text = dt1.Rows[0][6].ToString();
            city.Text = dt1.Rows[0][7].ToString();
            state.Text = dt1.Rows[0][8].ToString();
            preferred_days.Text = dt1.Rows[0][9].ToString();
            interest_area.Text = dt1.Rows[0][10].ToString();
            message.Text = dt1.Rows[0][11].ToString();

            dbconnection1.Close();
        }
    }
}