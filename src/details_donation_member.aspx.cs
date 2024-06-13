using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;

namespace FYP_DFB
{
    public partial class details_donation_member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DonateDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");

            DateTime maxDate = DateTime.Today.AddMonths(2); // Set maximum date to 2 months from today
            DonateDate.Attributes["max"] = maxDate.ToString("yyyy-MM-dd");

            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (!IsPostBack)
            {
                if (Request.QueryString["donationID"] != null && Request.QueryString["memberID"] != null)
                {
                    string donationID = Request.QueryString["donationID"];
                    string donationEmail = Request.QueryString["donationEmail"];

                    form_id.Text = donationID;
                    email.Text = donationEmail;

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
                    Response.Redirect("manage_donation_member.aspx");
                }

            }
        }

        private void PopulateIndividualDetails()
        {
            string donationID = Request.QueryString["donationID"];

            email.Text = Session["member_email"].ToString();

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            // Display record from second table
            SqlDataAdapter da2 = new SqlDataAdapter("select * from DONATION_FORM where donation_id = '" + donationID + "'", dbconnection1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            status.Text = dt2.Rows[0][2].ToString();
            individual_first_name.Text = dt2.Rows[0][4].ToString();
            individual_last_name.Text = dt2.Rows[0][5].ToString();
            contact_no.Text = dt2.Rows[0][9].ToString();
            street_address.Text = dt2.Rows[0][11].ToString();
            postal_code.Text = dt2.Rows[0][12].ToString();
            city.Text = dt2.Rows[0][13].ToString();
            DropDownListState.Text = dt2.Rows[0][14].ToString();
            Fruits_Quantity.Text = dt2.Rows[0][15].ToString();
            Vegetables_Quantity.Text = dt2.Rows[0][16].ToString();
            Dairy_and_Eggs_Quantity.Text = dt2.Rows[0][17].ToString();
            Meat_Quantity.Text = dt2.Rows[0][18].ToString();
            Seafood_Quantity.Text = dt2.Rows[0][19].ToString();
            Breads_and_Cereals_Quantity.Text = dt2.Rows[0][20].ToString();
            Sweets_Snacks_Beverages_Quantity.Text = dt2.Rows[0][21].ToString();
            Canned_Products_Quantity.Text = dt2.Rows[0][22].ToString();
            DropDownListShelfLife.Text = dt2.Rows[0][23].ToString();
            DisplayDate.Text = Convert.ToDateTime(dt2.Rows[0][24]).ToShortDateString();
            DonateDate.Text = Convert.ToDateTime(dt2.Rows[0][24]).ToShortDateString();
            DonateTime_DropDownList.Text = dt2.Rows[0][25].ToString();
            other_messages_textbox.Text = dt2.Rows[0][26].ToString();
            string pickupService = dt2.Rows[0][27].ToString();
            if (pickupService == "Yes")
            {
                pickup_service.Checked = true;
                pickup_text.Text = "Yes";
            }
            else
            {
                pickup_service.Checked = false;
                pickup_text.Text = "No";
            }

            if (status.Text != "In Progress")
            {
                submit_button.Visible = false;
                cancelButton.Visible = false;
            }

            SqlDataAdapter da22 = new SqlDataAdapter("select * from DONOR where member_id = '" + Session["member_id"] + "'", dbconnection1);
            DataTable dt22 = new DataTable();
            da22.Fill(dt22);
            verified.Text = dt22.Rows[0][11].ToString();

            if (verified.Text != "Yes")
            {
                pickup_service.Enabled = false;
            }

            dbconnection1.Close();
        }

        private void PopulateOrganizationDetails()
        {
            string donationID = Request.QueryString["donationID"];
            email.Text = Session["member_email"].ToString();

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            // Display record from second table
            SqlDataAdapter da2 = new SqlDataAdapter("select * from DONATION_FORM where donation_id = '" + donationID + "'", dbconnection1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            status.Text = dt2.Rows[0][2].ToString();
            org_name.Text = dt2.Rows[0][6].ToString();
            org_num.Text = dt2.Rows[0][7].ToString();
            person_in_charge.Text = dt2.Rows[0][8].ToString();
            contact_no.Text = dt2.Rows[0][9].ToString();
            street_address.Text = dt2.Rows[0][11].ToString();
            postal_code.Text = dt2.Rows[0][12].ToString();
            city.Text = dt2.Rows[0][13].ToString();
            DropDownListState.Text = dt2.Rows[0][14].ToString();
            Fruits_Quantity.Text = dt2.Rows[0][15].ToString();
            Vegetables_Quantity.Text = dt2.Rows[0][16].ToString();
            Dairy_and_Eggs_Quantity.Text = dt2.Rows[0][17].ToString();
            Meat_Quantity.Text = dt2.Rows[0][18].ToString();
            Seafood_Quantity.Text = dt2.Rows[0][19].ToString();
            Breads_and_Cereals_Quantity.Text = dt2.Rows[0][20].ToString();
            Sweets_Snacks_Beverages_Quantity.Text = dt2.Rows[0][21].ToString();
            Canned_Products_Quantity.Text = dt2.Rows[0][22].ToString();
            DropDownListShelfLife.Text = dt2.Rows[0][23].ToString();
            DisplayDate.Text = Convert.ToDateTime(dt2.Rows[0][24]).ToShortDateString();
            DonateDate.Text = Convert.ToDateTime(dt2.Rows[0][24]).ToShortDateString();
            DonateTime_DropDownList.Text = dt2.Rows[0][25].ToString();
            other_messages_textbox.Text = dt2.Rows[0][26].ToString();
            string pickupService = dt2.Rows[0][27].ToString();
            if (pickupService == "Yes")
            {
                pickup_service.Checked = true;
                pickup_text.Text = "Yes";
            }
            else
            {
                pickup_service.Checked = false;
                pickup_text.Text = "No";
            }

            if (status.Text != "In Progress")
            {
                submit_button.Visible = false;
                cancelButton.Visible = false;
            }

            SqlDataAdapter da22 = new SqlDataAdapter("select * from DONOR where member_id = '" + Session["member_id"] + "'", dbconnection1);
            DataTable dt22 = new DataTable();
            da22.Fill(dt22);
            verified.Text = dt22.Rows[0][11].ToString();

            if (verified.Text != "Yes")
            {
                pickup_service.Enabled = false;
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
            DropDownListShelfLife.Enabled = false;
            DonateDate.ReadOnly = true;
            DisplayDate.ReadOnly = true;
            DonateTime_DropDownList.Enabled = false;
            other_messages_textbox.ReadOnly = true;
            pickup_service.Enabled = false;
        }

        protected void submit_button_Click(object sender, EventArgs e)
        {
            string donationID = Request.QueryString["donationID"];

            if (submit_button.Text == "Save Changes")
            {
                if (pickup_service.Checked == true)
                {
                    pickup_service.Text = "Yes";
                }
                else
                {
                    pickup_service.Text = "No";
                }

                SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                dbconnection1.Open();

                string query3 = "update DONATION_FORM set donation_fruits_quantity = '" + Fruits_Quantity.Text + "', donation_vegetables_quantity = '" + Vegetables_Quantity.Text + "', donation_dairy_egg_quantity = '" + Dairy_and_Eggs_Quantity.Text + "', donation_meat_quantity = '" + Meat_Quantity.Text + "', donation_seafood_quantity = '" + Seafood_Quantity.Text + "', donation_bread_cereal_quantity = '" + Breads_and_Cereals_Quantity.Text + "', donation_sweet_snack_quantity = '" + Sweets_Snacks_Beverages_Quantity.Text + "', donation_canned_quantity = '" + Canned_Products_Quantity.Text + "', donation_shelf_life = '" + DropDownListShelfLife.SelectedValue + "', donation_date = '" + DonateDate.Text + "', donation_time = '" + DonateTime_DropDownList.SelectedValue + "', donation_message = '" + other_messages_textbox.Text + "', donation_pickup_service = '" + pickup_text.Text + "' where donation_id = '" + donationID + "'";
                SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                cmd3.ExecuteNonQuery();
                dbconnection1.Close();

                submit_button.Text = "Modify Details";
                Response.Redirect("manage_donation_member.aspx");
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
                DropDownListShelfLife.Enabled = true;
                DonateDate.ReadOnly = false;
                DonateTime_DropDownList.Enabled = true;
                other_messages_textbox.ReadOnly = false;
                DisplayDate.Visible = false;
                DonateDate.Visible = true;
                pickup_service.Enabled = true;

                SqlConnection dbconnection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                dbconnection2.Open();

                SqlDataAdapter da23 = new SqlDataAdapter("select * from DONOR where member_id = '" + Session["member_id"] + "'", dbconnection2);
                DataTable dt23 = new DataTable();
                da23.Fill(dt23);
                verified.Text = dt23.Rows[0][11].ToString();

                if (verified.Text != "Yes")
                {
                    pickup_service.Enabled = false;
                }

                if (pickup_service.Checked == true)
                {
                    pickup_text.Text = "Yes";
                }
                else
                {
                    pickup_text.Text = "No";
                }

                submit_button.Text = "Save Changes";
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            string donationID = Request.QueryString["donationID"];

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            string query3 = "update DONATION_FORM set donation_status = 'Cancelled' where donation_id = '" + donationID + "'";
            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
            cmd3.ExecuteNonQuery();
            dbconnection1.Close();

            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}