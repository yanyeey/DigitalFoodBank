using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace FYP_DFB
{
    public partial class details_member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!IsPostBack)
            {
                if (Request.QueryString["memberID"] != null && Request.QueryString["memberType"] != null && Request.QueryString["memberRole"] != null)
                {
                    string memberID = Request.QueryString["memberID"];
                    string memberType = Request.QueryString["memberType"];
                    string memberRole = Request.QueryString["memberRole"];

                    member_id.Text = memberID;
                    member_type.Text = memberType;
                    member_role.Text = memberRole;

                    //Retrieve and display more details from the database based on the member ID
                    DisplayMemberDetails(memberID);
                }
                else
                {
                    Response.Redirect("manage_member.aspx");
                }
            }
        }

        private void DisplayMemberDetails(string memberID)
        {
            // Fetch additional details from the database based on the member ID
            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            if (member_type.Text == "donor" && member_role.Text == "individual")
            {
                individualFields.Style["display"] = "block";
                organizationFields.Style["display"] = "none";
                IndividualRecipient.Style["display"] = "none";
                RecipientUpload.Style["display"] = "none";

                // Display record from first table
                SqlDataAdapter da1 = new SqlDataAdapter("select * from MEMBER where member_id = '" + member_id.Text + "'", dbconnection1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                MemberRole.Text = dt1.Rows[0][1].ToString();
                MemberEmail.Text = dt1.Rows[0][3].ToString();

                // Display record from second table
                SqlDataAdapter da2 = new SqlDataAdapter("select * from DONOR where member_id = '" + member_id.Text + "'", dbconnection1);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                MemberFirstName.Text = dt2.Rows[0][1].ToString();
                MemberLastName.Text = dt2.Rows[0][2].ToString();
                MemberContactNum.Text = dt2.Rows[0][6].ToString();
                MemberStreetAddress.Text = dt2.Rows[0][7].ToString();
                MemberPostalCode.Text = dt2.Rows[0][8].ToString();
                MemberCity.Text = dt2.Rows[0][9].ToString();
                MemberState.Text = dt2.Rows[0][10].ToString();
                string verify = dt2.Rows[0][11].ToString();
                if (verify == "No")
                {
                    verified.Text = "Unverified";
                }
                else if (verify == "Yes")
                {
                    verified.Text = "Verified";
                }
            }

            else if (member_type.Text == "donor" && member_role.Text == "organization")
            {
                individualFields.Style["display"] = "none";
                organizationFields.Style["display"] = "block";
                IndividualRecipient.Style["display"] = "none";
                RecipientUpload.Style["display"] = "none";

                // Display record from first table
                SqlDataAdapter da1 = new SqlDataAdapter("select * from MEMBER where member_id = '" + member_id.Text + "'", dbconnection1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                MemberRole.Text = dt1.Rows[0][1].ToString();
                MemberEmail.Text = dt1.Rows[0][3].ToString();

                // Display record from second table
                SqlDataAdapter da2 = new SqlDataAdapter("select * from DONOR where member_id = '" + member_id.Text + "'", dbconnection1);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                MemberOrgName.Text = dt2.Rows[0][3].ToString();
                MemberBusinessNum.Text = dt2.Rows[0][4].ToString();
                PICName.Text = dt2.Rows[0][5].ToString();
                MemberContactNum.Text = dt2.Rows[0][6].ToString();
                MemberStreetAddress.Text = dt2.Rows[0][7].ToString();
                MemberPostalCode.Text = dt2.Rows[0][8].ToString();
                MemberCity.Text = dt2.Rows[0][9].ToString();
                MemberState.Text = dt2.Rows[0][10].ToString();
                string verify = dt2.Rows[0][11].ToString();
                if (verify == "No")
                {
                    verified.Text = "Unverified";
                }
                else if (verify == "Yes")
                {
                    verified.Text = "Verified";
                }
            }

            else if (member_type.Text == "recipient" && member_role.Text == "individual")
            {
                individualFields.Style["display"] = "block";
                organizationFields.Style["display"] = "none";
                IndividualRecipient.Style["display"] = "block";
                RecipientUpload.Style["display"] = "block";

                // Display record from first table
                SqlDataAdapter da1 = new SqlDataAdapter("select * from MEMBER where member_id = '" + member_id.Text + "'", dbconnection1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                MemberRole.Text = dt1.Rows[0][1].ToString();
                MemberEmail.Text = dt1.Rows[0][3].ToString();

                // Display record from second table
                SqlDataAdapter da2 = new SqlDataAdapter("select * from RECIPIENT where member_id = '" + member_id.Text + "'", dbconnection1);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                MemberFirstName.Text = dt2.Rows[0][1].ToString();
                MemberLastName.Text = dt2.Rows[0][2].ToString();
                MemberIdentificationNumber.Text = dt2.Rows[0][6].ToString();
                IdentificationImage.ImageUrl = dt2.Rows[0][7].ToString();
                MemberContactNum.Text = dt2.Rows[0][8].ToString();
                MemberStreetAddress.Text = dt2.Rows[0][9].ToString();
                MemberPostalCode.Text = dt2.Rows[0][10].ToString();
                MemberCity.Text = dt2.Rows[0][11].ToString();
                MemberState.Text = dt2.Rows[0][12].ToString();
                string verify = dt2.Rows[0][13].ToString();
                if (verify == "No")
                {
                    verified.Text = "Unverified";
                }
                else if (verify == "Yes")
                {
                    verified.Text = "Verified";
                }
            }

            else if (member_type.Text == "recipient" && member_role.Text == "organization")
            {
                individualFields.Style["display"] = "none";
                organizationFields.Style["display"] = "block";
                IndividualRecipient.Style["display"] = "none";
                RecipientUpload.Style["display"] = "block";

                // Display record from first table
                SqlDataAdapter da1 = new SqlDataAdapter("select * from MEMBER where member_id = '" + member_id.Text + "'", dbconnection1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                MemberRole.Text = dt1.Rows[0][1].ToString();
                MemberEmail.Text = dt1.Rows[0][3].ToString();

                // Display record from second table
                SqlDataAdapter da2 = new SqlDataAdapter("select * from RECIPIENT where member_id = '" + member_id.Text + "'", dbconnection1);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                MemberOrgName.Text = dt2.Rows[0][3].ToString();
                MemberBusinessNum.Text = dt2.Rows[0][4].ToString();
                PICName.Text = dt2.Rows[0][5].ToString();
                IdentificationImage.ImageUrl = dt2.Rows[0][7].ToString();
                MemberContactNum.Text = dt2.Rows[0][8].ToString();
                MemberStreetAddress.Text = dt2.Rows[0][9].ToString();
                MemberPostalCode.Text = dt2.Rows[0][10].ToString();
                MemberCity.Text = dt2.Rows[0][11].ToString();
                MemberState.Text = dt2.Rows[0][12].ToString();
                string verify = dt2.Rows[0][13].ToString();
                if (verify == "No")
                {
                    verified.Text = "Unverified";
                }
                else if (verify == "Yes")
                {
                    verified.Text = "Verified";
                }
            }


            dbconnection1.Close();
        }

        protected void submit_button_Click(object sender, EventArgs e)
        {
            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            if (member_type.Text == "donor")
            {
                string query4 = "update DONOR set donor_verified = 'Yes' ";
                SqlCommand cmd4 = new SqlCommand(query4, dbconnection1);
                cmd4.ExecuteNonQuery();
            }
            else if (member_type.Text == "recipient")
            {
                string query4 = "update RECIPIENT set recipient_verified = 'Yes' ";
                SqlCommand cmd4 = new SqlCommand(query4, dbconnection1);
                cmd4.ExecuteNonQuery();
            }

            dbconnection1.Close();

            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}