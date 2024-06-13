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
    public partial class details_assistance_member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReceiveDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");

            DateTime maxDate = DateTime.Today.AddMonths(2); // Set maximum date to 2 months from today
            ReceiveDate.Attributes["max"] = maxDate.ToString("yyyy-MM-dd");

            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!IsPostBack)
            {
                if (Request.QueryString["assistanceID"] != null && Request.QueryString["memberID"] != null)
                {
                    string assistanceID = Request.QueryString["assistanceID"];
                    string assistanceEmail = Request.QueryString["assistanceEmail"];

                    form_id.Text = assistanceID;
                    email.Text = assistanceEmail;

                    if (Session["member_role"] != null)
                    {
                        if (Session["member_role"].ToString() == "individual")
                        {
                            individualFields.Style["display"] = "block";
                            organizationFields.Style["display"] = "none";

                            // Disable the organization radio button
                            ListItem roleItem = RadioButtonListRole.Items.FindByValue("Organization");
                            if (roleItem != null)
                            {
                                roleItem.Enabled = false;
                            }

                            PopulateIndividualDetails();
                        }

                        else if (Session["member_role"].ToString() == "organization")
                        {
                            individualFields.Style["display"] = "none";
                            organizationFields.Style["display"] = "block";

                            // Disable the individual radio button
                            ListItem roleItem = RadioButtonListRole.Items.FindByValue("Individual");
                            if (roleItem != null)
                            {
                                roleItem.Enabled = false;
                                ListItem organizationListItem = RadioButtonListRole.Items.FindByValue("Organization");
                                organizationListItem.Selected = true;
                            }

                            PopulateOrganizationDetails();
                        }

                        SetFieldsReadOnly();

                    }
                }
                else
                {
                    Response.Redirect("manage_assistance_member.aspx");
                }

            }
        }

        private void PopulateIndividualDetails()
        {
            string assistanceID = Request.QueryString["assistanceID"];

            email.Text = Session["member_email"].ToString();

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            // Display record from second table
            SqlDataAdapter da2 = new SqlDataAdapter("select * from ASSISTANCE_FORM where assistance_id = '" + assistanceID + "'", dbconnection1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            status.Text = dt2.Rows[0][2].ToString();
            individual_first_name.Text = dt2.Rows[0][4].ToString();
            individual_last_name.Text = dt2.Rows[0][5].ToString();
            identification_number.Text = dt2.Rows[0][9].ToString();
            contact_no.Text = dt2.Rows[0][10].ToString();
            street_address.Text = dt2.Rows[0][12].ToString();
            postal_code.Text = dt2.Rows[0][13].ToString();
            city.Text = dt2.Rows[0][14].ToString();
            DropDownListState.Text = dt2.Rows[0][15].ToString();
            Fruits_Quantity.Text = dt2.Rows[0][16].ToString();
            Vegetables_Quantity.Text = dt2.Rows[0][17].ToString();
            Dairy_and_Eggs_Quantity.Text = dt2.Rows[0][18].ToString();
            Meat_Quantity.Text = dt2.Rows[0][19].ToString();
            Seafood_Quantity.Text = dt2.Rows[0][20].ToString();
            Breads_and_Cereals_Quantity.Text = dt2.Rows[0][21].ToString();
            Sweets_Snacks_Beverages_Quantity.Text = dt2.Rows[0][22].ToString();
            Canned_Products_Quantity.Text = dt2.Rows[0][23].ToString();
            string date = dt2.Rows[0][24].ToString();
            string time = dt2.Rows[0][25].ToString();
            other_messages_textbox.Text = dt2.Rows[0][26].ToString();
            string deliveryService = dt2.Rows[0][27].ToString();

            if (deliveryService == "Yes")
            {
                delivery_service.Checked = true;
                delivery_text.Text = "Yes";
            }
            else
            {
                delivery_service.Checked = false;
                delivery_text.Text = "No";
            }

            if (!string.IsNullOrEmpty(date) && !string.IsNullOrEmpty(time))
            {
                ReceiveDate.Text = Convert.ToDateTime(dt2.Rows[0][24]).ToShortDateString();
                ReceiveTime_DropDownList.Text = dt2.Rows[0][25].ToString();
                submit_button.Visible = false;
            }
            else
            {
                ReceiveTime_DropDownList.ClearSelection();
                ReceiveTime_DropDownList.Items.Insert(0, new ListItem("", ""));
                ReceiveTime_DropDownList.Text = string.Empty;                
            }

            if (status.Text != "In Progress")
            {
                submit_button.Visible = false;
                cancelButton.Visible = false;
            }

            SqlDataAdapter da22 = new SqlDataAdapter("select * from RECIPIENT where member_id = '" + Session["member_id"] + "'", dbconnection1);
            DataTable dt22 = new DataTable();
            da22.Fill(dt22);
            verified.Text = dt22.Rows[0][13].ToString();

            if (verified.Text != "Yes")
            {
                delivery_service.Enabled = false;
            }

            dbconnection1.Close();
        }

        private void PopulateOrganizationDetails()
        {
            string assistanceID = Request.QueryString["assistanceID"];
            email.Text = Session["member_email"].ToString();

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            // Display record from second table
            SqlDataAdapter da2 = new SqlDataAdapter("select * from ASSISTANCE_FORM where assistance_id = '" + assistanceID + "'", dbconnection1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            status.Text = dt2.Rows[0][2].ToString();
            org_name.Text = dt2.Rows[0][6].ToString();
            org_num.Text = dt2.Rows[0][7].ToString();
            person_in_charge.Text = dt2.Rows[0][8].ToString();
            contact_no.Text = dt2.Rows[0][10].ToString();
            street_address.Text = dt2.Rows[0][12].ToString();
            postal_code.Text = dt2.Rows[0][13].ToString();
            city.Text = dt2.Rows[0][14].ToString();
            DropDownListState.Text = dt2.Rows[0][15].ToString();
            Fruits_Quantity.Text = dt2.Rows[0][16].ToString();
            Vegetables_Quantity.Text = dt2.Rows[0][17].ToString();
            Dairy_and_Eggs_Quantity.Text = dt2.Rows[0][18].ToString();
            Meat_Quantity.Text = dt2.Rows[0][19].ToString();
            Seafood_Quantity.Text = dt2.Rows[0][20].ToString();
            Breads_and_Cereals_Quantity.Text = dt2.Rows[0][21].ToString();
            Sweets_Snacks_Beverages_Quantity.Text = dt2.Rows[0][22].ToString();
            Canned_Products_Quantity.Text = dt2.Rows[0][23].ToString();
            string date = dt2.Rows[0][24].ToString();
            string time = dt2.Rows[0][25].ToString();
            other_messages_textbox.Text = dt2.Rows[0][26].ToString();
            string deliveryService = dt2.Rows[0][27].ToString();
            if (deliveryService == "Yes")
            {
                delivery_service.Checked = true;
                delivery_text.Text = "Yes";
            }
            else
            {
                delivery_service.Checked = false;
                delivery_text.Text = "No";
            }

            if (!string.IsNullOrEmpty(date) && !string.IsNullOrEmpty(time))
            {
                ReceiveDate.Text = Convert.ToDateTime(dt2.Rows[0][24]).ToShortDateString();
                ReceiveTime_DropDownList.Text = dt2.Rows[0][25].ToString();
            }
            else
            {
                ReceiveTime_DropDownList.ClearSelection();
                ReceiveTime_DropDownList.Items.Insert(0, new ListItem("", ""));
                ReceiveTime_DropDownList.Text = string.Empty;
            }

            if (status.Text != "In Progress")
            {
                submit_button.Visible = false;
                cancelButton.Visible = false;
            }

            SqlDataAdapter da22 = new SqlDataAdapter("select * from RECIPIENT where member_id = '" + Session["member_id"] + "'", dbconnection1);
            DataTable dt22 = new DataTable();
            da22.Fill(dt22);
            verified.Text = dt22.Rows[0][13].ToString();

            if (verified.Text != "Yes")
            {
                delivery_service.Enabled = false;
            }

            dbconnection1.Close();
        }

        private void SetFieldsReadOnly()
        {
            individual_first_name.ReadOnly = true;
            individual_last_name.ReadOnly = true;
            org_name.ReadOnly = true;
            org_num.ReadOnly = true;
            person_in_charge.ReadOnly = true;
            identification_number.ReadOnly = true;
            contact_no.ReadOnly = true;
            email.ReadOnly = true;
            street_address.ReadOnly = true;
            postal_code.ReadOnly = true;
            city.ReadOnly = true;
            DropDownListState.Enabled = false; // Disable dropdownlist
            Fruits_Quantity.ReadOnly = true;
            Vegetables_Quantity.ReadOnly = true;
            Dairy_and_Eggs_Quantity.ReadOnly = true;
            Meat_Quantity.ReadOnly = true;
            Seafood_Quantity.ReadOnly = true;
            Breads_and_Cereals_Quantity.ReadOnly = true;
            Sweets_Snacks_Beverages_Quantity.ReadOnly = true;
            Canned_Products_Quantity.ReadOnly = true;
            ReceiveDate.ReadOnly = true;
            ReceiveTime_DropDownList.Enabled = false;
            other_messages_textbox.ReadOnly = true;
            delivery_service.Enabled = false;
        }

        protected void submit_button_Click(object sender, EventArgs e)
        {
            string assistanceID = Request.QueryString["assistanceID"];

            if (submit_button.Text == "Save Changes")
            {
                if (delivery_service.Checked == true)
                {
                    delivery_text.Text = "Yes";
                }
                else
                {
                    delivery_text.Text = "No";
                }

                SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                dbconnection1.Open();

                string query3 = "update ASSISTANCE_FORM set assistance_fruits_quantity = '" + Fruits_Quantity.Text + "', assistance_vegetables_quantity = '" + Vegetables_Quantity.Text + "', assistance_dairy_egg_quantity = '" + Dairy_and_Eggs_Quantity.Text + "', assistance_meat_quantity = '" + Meat_Quantity.Text + "', assistance_seafood_quantity = '" + Seafood_Quantity.Text + "', assistance_bread_cereal_quantity = '" + Breads_and_Cereals_Quantity.Text + "', assistance_sweet_snack_quantity = '" + Sweets_Snacks_Beverages_Quantity.Text + "', assistance_canned_quantity = '" + Canned_Products_Quantity.Text + "', assistance_delivery_service = '" + delivery_text.Text + "' where assistance_id = '" + assistanceID + "'";
                SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                cmd3.ExecuteNonQuery();
                dbconnection1.Close();

                submit_button.Text = "Modify Details";
                Response.Redirect("manage_assistance_member.aspx");
            }

            // Change the button text
            if (submit_button.Text == "Modify Details")
            {
                Fruits_Quantity.ReadOnly = false;
                Vegetables_Quantity.ReadOnly = false;
                Dairy_and_Eggs_Quantity.ReadOnly = false;
                Meat_Quantity.ReadOnly = false;
                Seafood_Quantity.ReadOnly = false;
                Breads_and_Cereals_Quantity.ReadOnly = false;
                Sweets_Snacks_Beverages_Quantity.ReadOnly = false;
                Canned_Products_Quantity.ReadOnly = false;
                other_messages_textbox.ReadOnly = false;
                delivery_service.Enabled = true;

                SqlConnection dbconnection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                dbconnection2.Open();

                SqlDataAdapter da23 = new SqlDataAdapter("select * from RECIPIENT where member_id = '" + Session["member_id"] + "'", dbconnection2);
                DataTable dt23 = new DataTable();
                da23.Fill(dt23);
                verified.Text = dt23.Rows[0][13].ToString();

                if (verified.Text != "Yes")
                {
                    delivery_service.Enabled = false; 
                }

                if (delivery_service.Checked == true)
                {
                    delivery_text.Text = "Yes";
                }
                else
                {
                    delivery_text.Text = "No";
                }

                submit_button.Text = "Save Changes";
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            string assistanceID = Request.QueryString["assistanceID"];

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            string query3 = "update ASSISTANCE_FORM set assistance_status = 'Cancelled' where assistance_id = '" + assistanceID + "'";
            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
            cmd3.ExecuteNonQuery();
            dbconnection1.Close();

            Response.Redirect(Request.Url.AbsoluteUri);
        }

    }
}
