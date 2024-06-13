using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_DFB
{
    public partial class food_assistance_form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["member_email"] != null && Session["member_type"].ToString() != "recipient")
            {
                string message = "Please login as a recipient to access this form.";
                Session["MessageBoxMessage"] = message;
                Response.Redirect("home.aspx");
            }

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            //read donation form count
            string query1 = "select count(*) from ASSISTANCE_FORM";
            SqlCommand cmd1 = new SqlCommand(query1, dbconnection1);

            int record_assistance = Convert.ToInt32(cmd1.ExecuteScalar().ToString().Replace(" ", ""));
            if (record_assistance < 1)
            {
                FormCount.Text = "1";
            }
            else
            {
                int form_count = record_assistance + 1;
                FormCount.Text = form_count.ToString();
            }

            if (Session["member_email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (Session["member_email"] != null)
            {
                //read member_id
                SqlDataAdapter da1 = new SqlDataAdapter("select * from MEMBER where member_email = '" + Session["member_email"] + "'", dbconnection1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                member_id.Text = dt1.Rows[0][0].ToString();
            }

            dbconnection1.Close();

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

            if (verified.Text != "Yes")
            {
                delivery_service.Enabled = false;
            }
        }

        private void PopulateIndividualDetails()
        {
            email.Text = Session["member_email"].ToString();

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            // Display record from second table
            SqlDataAdapter da2 = new SqlDataAdapter("select * from RECIPIENT where member_id = '" + member_id.Text + "'", dbconnection1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            individual_first_name.Text = dt2.Rows[0][1].ToString();
            individual_last_name.Text = dt2.Rows[0][2].ToString();
            identification_number.Text = dt2.Rows[0][6].ToString();
            contact_no.Text = dt2.Rows[0][8].ToString();
            street_address.Text = dt2.Rows[0][9].ToString();
            postal_code.Text = dt2.Rows[0][10].ToString();
            city.Text = dt2.Rows[0][11].ToString();
            DropDownListState.Text = dt2.Rows[0][12].ToString();
            verified.Text = dt2.Rows[0][13].ToString();

            dbconnection1.Close();
        }

        private void PopulateOrganizationDetails()
        {
            email.Text = Session["member_email"].ToString();

            SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            dbconnection1.Open();

            // Display record from second table
            SqlDataAdapter da2 = new SqlDataAdapter("select * from RECIPIENT where member_id = '" + member_id.Text + "'", dbconnection1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            org_name.Text = dt2.Rows[0][3].ToString();
            org_num.Text = dt2.Rows[0][4].ToString();
            person_in_charge.Text = dt2.Rows[0][5].ToString();
            contact_no.Text = dt2.Rows[0][8].ToString();
            street_address.Text = dt2.Rows[0][9].ToString();
            postal_code.Text = dt2.Rows[0][10].ToString();
            city.Text = dt2.Rows[0][11].ToString();
            DropDownListState.Text = dt2.Rows[0][12].ToString();
            verified.Text = dt2.Rows[0][13].ToString();

            dbconnection1.Close();
        }

        private void SetFieldsReadOnly()
        {
            individual_first_name.ReadOnly = true;
            individual_last_name.ReadOnly = true;
            identification_number.ReadOnly = true;
            org_name.ReadOnly = true;
            org_num.ReadOnly = true;
            person_in_charge.ReadOnly = true;
            contact_no.ReadOnly = true;
            email.ReadOnly = true;
            street_address.ReadOnly = true;
            postal_code.ReadOnly = true;
            city.ReadOnly = true;
            DropDownListState.Enabled = false; // Disable dropdownlist
        }


        protected void RadioButtonListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonListRole.SelectedValue == "Individual")
            {
                individualFields.Style["display"] = "block";
                organizationFields.Style["display"] = "none";
            }
            else if (RadioButtonListRole.SelectedValue == "Organization")
            {
                individualFields.Style["display"] = "none";
                organizationFields.Style["display"] = "block";
            }
        }

        protected void submit_button_Click(object sender, EventArgs e)
        {
            try
            {
                String delivery = "";

                if (delivery_service.Checked)
                {
                    delivery = "Yes";
                }
                else
                {
                    delivery = "No";
                }

                SqlConnection dbconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                dbconnection1.Open();

                if (FormCount.Text != "" && contact_no.Text != ""
                    && email.Text != "" && street_address.Text != "" && postal_code.Text != ""
                    && city.Text != "" && RegularExpressionValidatorEmail.IsValid)
                {
                    if (RadioButtonListRole.SelectedValue == "Individual")
                    {
                        if (individual_first_name.Text != "" && individual_last_name.Text != "")
                        {
                            //create record in a table called ASSISTANCE_FORM
                            string query3 = "insert into ASSISTANCE_FORM (assistance_id, assistance_member_id, assistance_status, assistance_role, assistance_first_name, assistance_last_name, assistance_identification_no, assistance_contact_no, assistance_email, assistance_street_address, assistance_postal_code, assistance_city, assistance_state, assistance_fruits_quantity, assistance_vegetables_quantity, assistance_dairy_egg_quantity, assistance_meat_quantity, assistance_seafood_quantity, assistance_bread_cereal_quantity, assistance_sweet_snack_quantity, assistance_canned_quantity, assistance_message, assistance_delivery_service) values (@assistance_id, @member_id, @status, @role, @first_name, @last_name, @identification_no, @contact_no, @email, @street_address, @postal_code, @city, @state, @fruits, @vegetables, @dairy_egg, @meat, @seafood, @bread_cereal, @sweet_snack, @canned, @message, @delivery) ";
                            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                            cmd3.Parameters.AddWithValue("@assistance_id", "AF" + FormCount.Text);
                            cmd3.Parameters.AddWithValue("@member_id", member_id.Text);
                            cmd3.Parameters.AddWithValue("@status", "In Progress");
                            cmd3.Parameters.AddWithValue("@role", "individual");
                            cmd3.Parameters.AddWithValue("@first_name", individual_first_name.Text);
                            cmd3.Parameters.AddWithValue("@last_name", individual_last_name.Text);
                            cmd3.Parameters.AddWithValue("@identification_no", identification_number.Text);
                            cmd3.Parameters.AddWithValue("@contact_no", contact_no.Text);
                            cmd3.Parameters.AddWithValue("@email", email.Text);
                            cmd3.Parameters.AddWithValue("@street_address", street_address.Text);
                            cmd3.Parameters.AddWithValue("@postal_code", postal_code.Text);
                            cmd3.Parameters.AddWithValue("@city", city.Text);
                            cmd3.Parameters.AddWithValue("@state", DropDownListState.SelectedValue);
                            cmd3.Parameters.AddWithValue("@fruits", Fruits_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@vegetables", Vegetables_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@dairy_egg", Dairy_and_Eggs_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@meat", Meat_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@seafood", Seafood_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@bread_cereal", Breads_and_Cereals_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@sweet_snack", Sweets_Snacks_Beverages_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@canned", Canned_Products_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@message", other_messages_textbox.Text);
                            cmd3.Parameters.AddWithValue("@delivery", delivery);
                            cmd3.ExecuteNonQuery();

                            dbconnection1.Close();
                            Response.Redirect("food_assistance_form.aspx");
                        }
                    }

                    else if (RadioButtonListRole.SelectedValue == "Organization")
                    {
                        if (org_name.Text != "" && org_num.Text != "")
                        {
                            //create record in a table called ASSISTANCE_FORM
                            string query3 = "insert into ASSISTANCE_FORM (assistance_id, assistance_member_id, assistance_status, assistance_role, assistance_org_name, assistance_org_no, assistance_pic_name, assistance_contact_no, assistance_email, assistance_street_address, assistance_postal_code, assistance_city, assistance_state, assistance_fruits_quantity, assistance_vegetables_quantity, assistance_dairy_egg_quantity, assistance_meat_quantity, assistance_seafood_quantity, assistance_bread_cereal_quantity, assistance_sweet_snack_quantity, assistance_canned_quantity, assistance_message, assistance_delivery_service) values (@assistance_id, @member_id, @status, @role, @org_name, @org_no, @pic_name, @contact_no, @email, @street_address, @postal_code, @city, @state, @fruits, @vegetables, @dairy_egg, @meat, @seafood, @bread_cereal, @sweet_snack, @canned, @message, @delivery) ";
                            SqlCommand cmd3 = new SqlCommand(query3, dbconnection1);
                            cmd3.Parameters.AddWithValue("@assistance_id", "AF" + FormCount.Text);
                            cmd3.Parameters.AddWithValue("@member_id", member_id.Text);
                            cmd3.Parameters.AddWithValue("@status", "In Progress");
                            cmd3.Parameters.AddWithValue("@role", "organization");
                            cmd3.Parameters.AddWithValue("@org_name", org_name.Text);
                            cmd3.Parameters.AddWithValue("@org_no", org_num.Text);
                            cmd3.Parameters.AddWithValue("@pic_name", person_in_charge.Text);
                            cmd3.Parameters.AddWithValue("@contact_no", contact_no.Text);
                            cmd3.Parameters.AddWithValue("@email", email.Text);
                            cmd3.Parameters.AddWithValue("@street_address", street_address.Text);
                            cmd3.Parameters.AddWithValue("@postal_code", postal_code.Text);
                            cmd3.Parameters.AddWithValue("@city", city.Text);
                            cmd3.Parameters.AddWithValue("@state", DropDownListState.SelectedValue);
                            cmd3.Parameters.AddWithValue("@fruits", Fruits_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@vegetables", Vegetables_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@dairy_egg", Dairy_and_Eggs_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@meat", Meat_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@seafood", Seafood_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@bread_cereal", Breads_and_Cereals_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@sweet_snack", Sweets_Snacks_Beverages_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@canned", Canned_Products_Quantity.Text);
                            cmd3.Parameters.AddWithValue("@message", other_messages_textbox.Text);
                            cmd3.Parameters.AddWithValue("@delivery", delivery);
                            cmd3.ExecuteNonQuery();

                            dbconnection1.Close();
                            Response.Redirect("food_assistance_form.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LabelErrorMessage.Visible = true;
                LabelErrorMessage.ForeColor = System.Drawing.Color.Red;
                LabelErrorMessage.Text = "Form Submission not sucessful!" + ex.ToString();
                return;
            }

        }

    }
}