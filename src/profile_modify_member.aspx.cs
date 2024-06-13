using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Reflection.Emit;
using System.Web.Security;

namespace FYP_DFB
{
    public partial class profile_modify_member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!Page.IsPostBack)
            {
                SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["ConnectionString"].ConnectionString);
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
                    member_type.Text = dt1.Rows[0][2].ToString();
                    email.Text = dt1.Rows[0][3].ToString();

                    // Display record from second table
                    SqlDataAdapter da2 = new SqlDataAdapter("select * from DONOR where member_id = '" + member_id.Text + "'", dbconnection1);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    individual_first_name.Text = dt2.Rows[0][1].ToString();
                    individual_last_name.Text = dt2.Rows[0][2].ToString();
                    contact_no.Text = dt2.Rows[0][6].ToString();
                    street_address.Text = dt2.Rows[0][7].ToString();
                    postal_code.Text = dt2.Rows[0][8].ToString();
                    city.Text = dt2.Rows[0][9].ToString();
                    DropDownListState.SelectedValue = dt2.Rows[0][10].ToString();
                }

                if (Session["member_type"].ToString() == "donor" && Session["member_role"].ToString() == "organization")
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
                    member_type.Text = dt1.Rows[0][2].ToString();
                    email.Text = dt1.Rows[0][3].ToString();

                    // Display record from second table
                    SqlDataAdapter da2 = new SqlDataAdapter("select * from DONOR where member_id = '" + member_id.Text + "'", dbconnection1);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    org_name.Text = dt2.Rows[0][3].ToString();
                    org_num.Text = dt2.Rows[0][4].ToString();
                    person_in_charge.Text = dt2.Rows[0][5].ToString();
                    contact_no.Text = dt2.Rows[0][6].ToString();
                    street_address.Text = dt2.Rows[0][7].ToString();
                    postal_code.Text = dt2.Rows[0][8].ToString();
                    city.Text = dt2.Rows[0][9].ToString();
                    DropDownListState.SelectedValue = dt2.Rows[0][10].ToString();
                }

                if (Session["member_type"].ToString() == "recipient" && Session["member_role"].ToString() == "individual")
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
                    member_type.Text = dt1.Rows[0][2].ToString();
                    email.Text = dt1.Rows[0][3].ToString();

                    // Display record from second table
                    SqlDataAdapter da2 = new SqlDataAdapter("select * from RECIPIENT where member_id = '" + member_id.Text + "'", dbconnection1);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    individual_first_name.Text = dt2.Rows[0][1].ToString();
                    individual_last_name.Text = dt2.Rows[0][2].ToString();
                    identification_number.Text = dt2.Rows[0][6].ToString();
                    IdentificationImage.ImageUrl = dt2.Rows[0][7].ToString();
                    contact_no.Text = dt2.Rows[0][8].ToString();
                    street_address.Text = dt2.Rows[0][9].ToString();
                    postal_code.Text = dt2.Rows[0][10].ToString();
                    city.Text = dt2.Rows[0][11].ToString();
                    DropDownListState.SelectedValue = dt2.Rows[0][12].ToString();
                    verified.Text = dt2.Rows[0][13].ToString();

                    if (verified.Text == "Yes")
                    {
                        RecipientFileUpload.Visible = false;
                        identification_number.Enabled = false;
                    }
                }

                if (Session["member_type"].ToString() == "recipient" && Session["member_role"].ToString() == "organization")
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
                    member_type.Text = dt1.Rows[0][2].ToString();
                    email.Text = dt1.Rows[0][3].ToString();

                    // Display record from second table
                    SqlDataAdapter da2 = new SqlDataAdapter("select * from RECIPIENT where member_id = '" + member_id.Text + "'", dbconnection1);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    org_name.Text = dt2.Rows[0][3].ToString();
                    org_num.Text = dt2.Rows[0][4].ToString();
                    person_in_charge.Text = dt2.Rows[0][5].ToString();
                    IdentificationImage.ImageUrl = dt2.Rows[0][7].ToString();
                    contact_no.Text = dt2.Rows[0][8].ToString();
                    street_address.Text = dt2.Rows[0][9].ToString();
                    postal_code.Text = dt2.Rows[0][10].ToString();
                    city.Text = dt2.Rows[0][11].ToString();
                    DropDownListState.SelectedValue = dt2.Rows[0][12].ToString();
                    verified.Text = dt2.Rows[0][13].ToString();

                    if (verified.Text == "Yes")
                    {
                        RecipientFileUpload.Visible = false;
                    }
                }
                dbconnection1.Close();

                Session["member_email"] = email.Text;
                Session["member_type"] = member_type.Text;
                Session["member_role"] = MemberRole.Text;

            }
        }

        protected void save_button_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                dbconnection1.Open();

                string query1 = "select count(*) from MEMBER where member_email = '" + email.Text + "' and member_id != '" + member_id.Text + "'";
                SqlCommand cmd1 = new SqlCommand(query1, dbconnection1);

                int check1 = Convert.ToInt32(cmd1.ExecuteScalar().ToString());

                if (check1 > 0)
                {
                    LabelEmailTakenError.Visible = true;
                    LabelEmailTakenError.ForeColor = System.Drawing.Color.Red;
                    LabelEmailTakenError.Text = "This email has been registered.";
                }

                if (check1 == 0 && contact_no.Text != "" && email.Text != "" && 
                    street_address.Text != "" && postal_code.Text != "" && city.Text != "" 
                    && RegularExpressionValidatorEmail.IsValid)
                {
                    if (Session["member_type"].ToString() == "donor" && Session["member_role"].ToString() == "individual")
                    {
                        if (individual_first_name.Text != "" && individual_last_name.Text != "")
                        {
                            //update record in a table called MEMBER
                            string query2 = "update MEMBER set member_email = '" + email.Text + "' where member_id = '" + member_id.Text + "'";
                            SqlCommand cmd2 = new SqlCommand(query2, dbconnection1);
                            cmd2.ExecuteNonQuery();

                            //update record in a table called DONOR
                            string query3 = "update DONOR set donor_first_name = '" + individual_first_name.Text + "', donor_last_name = '" + individual_last_name.Text + "', donor_contact_no = '" + contact_no.Text + "', donor_street_address = '" + street_address.Text + "', donor_postal_code = '" + postal_code.Text + "', donor_city = '" + city.Text + "', donor_state = '" + DropDownListState.SelectedValue + "' where member_id = '" + member_id.Text + "'";
                            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                            cmd3.ExecuteNonQuery();
                            dbconnection1.Close();

                            Session["member_email"] = email.Text;
                            Session["member_type"] = "donor";
                            Session["member_role"] = "individual";

                            Response.Redirect("profile_member.aspx");
                        }
                    }

                    else if (Session["member_type"].ToString() == "donor" && Session["member_role"].ToString() == "organization")
                    {
                        if (org_name.Text != "" && org_num.Text != "")
                        {
                            //update record in a table called MEMBER
                            string query2 = "update MEMBER set member_email = '" + email.Text + "' where member_id = '" + member_id.Text + "'";
                            SqlCommand cmd2 = new SqlCommand(query2, dbconnection1);
                            cmd2.ExecuteNonQuery();

                            //update record in a table called DONOR
                            string query3 = "update DONOR set donor_org_name = '" + org_name.Text + "', donor_org_no = '" + org_num.Text + "', donor_pic_name = '" + person_in_charge.Text + "', donor_contact_no = '" + contact_no.Text + "', donor_street_address = '" + street_address.Text + "', donor_postal_code = '" + postal_code.Text + "', donor_city = '" + city.Text + "', donor_state = '" + DropDownListState.SelectedValue + "' where member_id = '" + member_id.Text + "'";
                            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                            cmd3.ExecuteNonQuery();
                            dbconnection1.Close();

                            Session["member_email"] = email.Text;
                            Session["member_type"] = "donor";
                            Session["member_role"] = "organization";

                            Response.Redirect("profile_member.aspx");
                        }
                    }

                    else if (Session["member_type"].ToString() == "recipient" && Session["member_role"].ToString() == "individual")
                    {
                        if (individual_first_name.Text != "" && individual_last_name.Text != "")
                        {
                            string folderPath = Server.MapPath("~/Identification_Documents/");
                            RecipientFileUpload.SaveAs(folderPath + Path.GetFileName(RecipientFileUpload.FileName));
                            IdentificationImage.ImageUrl = "~/Identification_Documents/" + Path.GetFileName(RecipientFileUpload.FileName);

                            //update record in a table called MEMBER
                            string query2 = "update MEMBER set member_email = '" + email.Text + "' where member_id = '" + member_id.Text + "'";
                            SqlCommand cmd2 = new SqlCommand(query2, dbconnection1);
                            cmd2.ExecuteNonQuery();

                            //update record in a table called RECIPIENT
                            string query3 = "update RECIPIENT set recipient_first_name = '" + individual_first_name.Text + "', recipient_last_name = '" + individual_last_name.Text + "', recipient_identification_no = '" + identification_number.Text + "', recipient_identification_document = '" + IdentificationImage.ImageUrl + "', recipient_contact_no = '" + contact_no.Text + "', recipient_street_address = '" + street_address.Text + "', recipient_postal_code = '" + postal_code.Text + "', recipient_city = '" + city.Text + "', recipient_state = '" + DropDownListState.SelectedValue + "' where member_id = '" + member_id.Text + "'";
                            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                            cmd3.ExecuteNonQuery();
                            dbconnection1.Close();

                            Session["member_email"] = email.Text;
                            Session["member_type"] = "recipient";
                            Session["member_role"] = "individual";

                            Response.Redirect("profile_member.aspx");
                        }
                    }

                    else if (Session["member_type"].ToString() == "recipient" && Session["member_role"].ToString() == "organization")
                    {
                        if (org_name.Text != "" && org_num.Text != "")
                        {
                            string folderPath = Server.MapPath("~/Identification_Documents/");
                            RecipientFileUpload.SaveAs(folderPath + Path.GetFileName(RecipientFileUpload.FileName));
                            IdentificationImage.ImageUrl = "~/Identification_Documents/" + Path.GetFileName(RecipientFileUpload.FileName);

                            //update record in a table called MEMBER
                            string query2 = "update MEMBER set member_email = '" + email.Text + "' where member_id = '" + member_id.Text + "'";
                            SqlCommand cmd2 = new SqlCommand(query2, dbconnection1);
                            cmd2.ExecuteNonQuery();

                            //update record in a table called RECIPIENT
                            string query3 = "update RECIPIENT set recipient_org_name = '" + org_name.Text + "', recipient_org_no = '" + org_num.Text + "', recipient_pic_name = '" + person_in_charge.Text + "', recipient_identification_document = '" + IdentificationImage.ImageUrl + "', recipient_contact_no = '" + contact_no.Text + "', recipient_street_address = '" + street_address.Text + "', recipient_postal_code = '" + postal_code.Text + "', recipient_city = '" + city.Text + "', recipient_state = '" + DropDownListState.SelectedValue + "' where member_id = '" + member_id.Text + "'";
                            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                            cmd3.ExecuteNonQuery();
                            dbconnection1.Close();

                            Session["member_email"] = email.Text;
                            Session["member_type"] = "recipient";
                            Session["member_role"] = "organization";

                            Response.Redirect("profile_member.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
                this.LabelErrorMessage.Text = "Failed to Update Changes!" + ex.ToString();
                this.LabelErrorMessage.Visible = true;
                return;
            }

        }
    }
}