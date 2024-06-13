using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Drawing;
using System.IO;

namespace FYP_DFB
{
    public partial class profile_member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!Page.IsPostBack)
            {
                SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                dbconnection1.Open();

                if (Session["member_type"].ToString() == "donor" && Session["member_role"].ToString() == "individual")
                {
                    individualFields.Style["display"] = "block";
                    organizationFields.Style["display"] = "none";
                    IndividualRecipient.Style["display"] = "none";
                    RecipientUpload.Style["display"] = "none";

                    // Display record from first table
                    SqlDataAdapter da1 = new SqlDataAdapter("select * from MEMBER where member_email = '" + Session["member_email"] + "'", dbconnection1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    member_id.Text = dt1.Rows[0][0].ToString();
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
                    verified.Text = dt2.Rows[0][11].ToString();

                    if (verified.Text == "No")
                    {
                        verified_icon.Visible = false;
                    }

                    greet.Text = MemberLastName.Text;
                }

                else if (Session["member_type"].ToString() == "donor" && Session["member_role"].ToString() == "organization")
                {
                    individualFields.Style["display"] = "none";
                    organizationFields.Style["display"] = "block";
                    IndividualRecipient.Style["display"] = "none";
                    RecipientUpload.Style["display"] = "none";

                    // Display record from first table
                    SqlDataAdapter da1 = new SqlDataAdapter("select * from MEMBER where member_email = '" + Session["member_email"] + "'", dbconnection1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    member_id.Text = dt1.Rows[0][0].ToString();
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
                    verified.Text = dt2.Rows[0][11].ToString();

                    if (verified.Text == "No")
                    {
                        verified_icon.Visible = false;
                    }

                    greet.Text = MemberOrgName.Text;
                }

                else if (Session["member_type"].ToString() == "recipient" && Session["member_role"].ToString() == "individual")
                {
                    individualFields.Style["display"] = "block";
                    organizationFields.Style["display"] = "none";
                    IndividualRecipient.Style["display"] = "block";
                    RecipientUpload.Style["display"] = "block";

                    // Display record from first table
                    SqlDataAdapter da1 = new SqlDataAdapter("select * from MEMBER where member_email = '" + Session["member_email"] + "'", dbconnection1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    member_id.Text = dt1.Rows[0][0].ToString();
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
                    verified.Text = dt2.Rows[0][13].ToString();

                    if (verified.Text == "No")
                    {
                        verified_icon.Visible = false;
                    }

                    greet.Text = MemberLastName.Text;
                }

                else if (Session["member_type"].ToString() == "recipient" && Session["member_role"].ToString() == "organization")
                {
                    individualFields.Style["display"] = "none";
                    organizationFields.Style["display"] = "block";
                    IndividualRecipient.Style["display"] = "none";
                    RecipientUpload.Style["display"] = "block";

                    // Display record from first table
                    SqlDataAdapter da1 = new SqlDataAdapter("select * from MEMBER where member_email = '" + Session["member_email"] + "'", dbconnection1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    member_id.Text = dt1.Rows[0][0].ToString();
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
                    verified.Text = dt2.Rows[0][13].ToString();

                    if (verified.Text == "No")
                    {
                        verified_icon.Visible = false;
                    }

                    greet.Text = MemberOrgName.Text;
                }

                dbconnection1.Close();
            }
        }

        protected void modify_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile_modify_member.aspx");
        }
    }
}