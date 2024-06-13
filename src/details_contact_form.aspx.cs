using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_DFB
{
    public partial class details_contact_form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!IsPostBack)
            {
                if (Request.QueryString["contactID"] != null && Request.QueryString["contactEmail"] != null)
                {
                    string contactID = Request.QueryString["contactID"];
                    string contactEmail = Request.QueryString["contactEmail"];

                    form_id.Text = contactID;
                    email.Text = contactEmail;

                    //Retrieve and display more details from the database based on the member ID
                    DisplayFormDetails(contactID);
                }
                else
                {
                    Response.Redirect("manage_contact_form.aspx");
                }
            }
        }

        private void DisplayFormDetails(string contactID)
        {
            // Fetch additional details from the database based on the form ID
            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            // Display record from first table
            SqlDataAdapter da1 = new SqlDataAdapter("select * from CONTACT_FORM where contact_id = '" + contactID + "'", dbconnection1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            form_id.Text = dt1.Rows[0][0].ToString();
            name.Text = dt1.Rows[0][1].ToString();
            email.Text = dt1.Rows[0][2].ToString();
            subject.Text = dt1.Rows[0][3].ToString();
            message.Text = dt1.Rows[0][4].ToString();
            string status = dt1.Rows[0][5].ToString();

            if (status == "Resolved")
            {
                submit_button.Visible = false;
            }

            dbconnection1.Close();
        }

        protected void submit_button_Click(object sender, EventArgs e)
        {
            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            string query4 = "update CONTACT_FORM set contact_status = 'Resolved' ";
            SqlCommand cmd4 = new SqlCommand(query4, dbconnection1);
            cmd4.ExecuteNonQuery();


            dbconnection1.Close();

            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}