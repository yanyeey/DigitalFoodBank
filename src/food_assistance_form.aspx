<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="food_assistance_form.aspx.cs" Inherits="FYP_DFB.food_assistance_form" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="MainContent1" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div class="main-banner wow fadeIn" id="top" data-wow-duration="1s" data-wow-delay="0.5s">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg-6 align-self-center">
                            <div class="left-content show-up header-text wow fadeInLeft" data-wow-duration="1s" data-wow-delay="1s">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <h6>Digital Food Bank</h6>
                                        <div class="section-heading">
                                            <h4>Food Assistance Form</h4>
                                            <div class="line-dec" style="background-color: #fa65b1;"></div>
                                            <br /><br /><br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="right-image wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.5s">
                                <img src="../Customised_Design/Images/form-background.jpeg" alt="" style="opacity: 0.9">
                            </div>
                        </div>
                    </div>                                       
                </div>
            </div>
        </div> 
    </div>

    <div id="blog" class="blog">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 offset-lg-3  wow fadeInDown" data-wow-duration="1s" data-wow-delay="0.2s">
                    <div class="section-heading">
                        <h6>Food Assistance Form</h6>
                        <h4>Please Fill In Your <em>Details</em></h4>
                        <div class="line-dec"></div>
                    </div>
                </div>
                <div class="row wow fadeInUp" data-wow-duration="0.8s" data-wow-delay="0.4s">   
                    <div class="col-lg-6 offset-lg-3">
                        <asp:UpdatePanel ID="role_UpdatePanel" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr style="width: 350px; white-space: nowrap;">
                                        <td style="width: 350px;">
                                            <asp:Label runat="server" Text="Request Assistance As: " Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="RadioButtonListRole" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListType_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="&nbsp;Individual" Value="Individual" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="&nbsp;Organization" Value="Organization"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr><td></td></tr>
                                </table>
                                <div id="individualFields" runat="server">
                                    <table>
                                        <tr>
                                            <td style="width: 350px; white-space: nowrap;">
                                                <asp:Label runat="server" Text="First Name:" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="individual_first_name" runat="server" Height="50px" Width="350px" placeholder=" First Name"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="indiivdual_first_name_validator" runat="server" ErrorMessage="*Please Enter First Name." ControlToValidate="individual_first_name" Display="Dynamic" Text="*Please Enter First Name." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 350px; white-space: nowrap;">
                                                <asp:Label runat="server" Text="Last Name:" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="individual_last_name" runat="server" Height="50px" Width="350px" placeholder=" Last Name"></asp:TextBox>
                                            </td>
                                        </tr>  
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="indiivdual_last_name_validator" runat="server" ErrorMessage="*Please Enter Last Name." ControlToValidate="individual_last_name" Display="Dynamic" Text="*Please Enter Last Name." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 350px; white-space: nowrap;">
                                                <asp:Label runat="server" Text="Identification Number:" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="identification_number" runat="server" Height="50px" Width="350px" placeholder=" NRIC / Passport"></asp:TextBox>
                                            </td>
                                        </tr>  
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="identification_number_validator" runat="server" ErrorMessage="*Please Enter Identification Number." ControlToValidate="identification_number" Display="Dynamic" Text="*Please Enter Identification Number." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="organizationFields" runat="server" style="display: none;">
                                    <table>
                                        <tr>
                                            <td style="width: 350px; white-space: nowrap;">
                                                <asp:Label runat="server" Text="Organization Name: " Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="org_name" runat="server" Height="50px" Width="350px" placeholder=" Organization Name"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="org_name_validator" runat="server" ErrorMessage="*Please Enter Organization Name." ControlToValidate="org_name" Display="Dynamic" Text="*Please Enter Organization Name." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 350px; white-space: nowrap;">
                                                <asp:Label runat="server" Text="Organization Registration Number: " Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="org_num" runat="server" Height="50px" Width="350px" placeholder=" Organization Registration Number"></asp:TextBox>
                                            </td>
                                        </tr>  
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="org_num_validator" runat="server" ErrorMessage="*Please Enter Organization Registration Number." ControlToValidate="org_num" Display="Dynamic" Text="*Please Enter Organization Number." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 350px; white-space: nowrap;">
                                                <asp:Label runat="server" Text="Name of Person in Charge: " Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="person_in_charge" runat="server" Height="50px" Width="350px" placeholder=" Name of Person in Charge"></asp:TextBox>
                                            </td>
                                        </tr>  
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="person_in_charge_validator" runat="server" ErrorMessage="*Please Enter Name of Person in Charge." ControlToValidate="person_in_charge" Display="Dynamic" Text="*Please Enter Name of Person in Charge." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <table>
                            <tr>
                                <td style="width: 350px; white-space: nowrap;">
                                    <asp:Label runat="server" Text="Contact Number: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="contact_no" runat="server" Height="50px" Width="350px" Placeholder=" E.g. 60123456789"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RegularExpressionValidator ID="phoneValidator" runat="server" ControlToValidate="contact_no" ValidationExpression="^60\d{9}$" Display="Dynamic" ErrorMessage="Please enter a valid contact number." ForeColor="Red" ></asp:RegularExpressionValidator>                                
                                    <asp:RequiredFieldValidator ID="contact_no_validator" runat="server" ErrorMessage="*Please Enter Contact Number." ControlToValidate="contact_no" Display="Dynamic" Text="*Please Enter Contact Number." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="Email: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="email" runat="server" Height="50px" Width="350px" Placeholder=" Email"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="email_validator" runat="server" ErrorMessage="*Please Enter Email." ControlToValidate="email" Display="Dynamic" Text="*Please Enter Email." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="email" EnableClientScript="False" ErrorMessage="Invalid Email." ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 350px; white-space: nowrap;">
                                    <asp:Label runat="server" Text="Street Address:" Font-Bold="True"></asp:Label>
                                </td>
                                <td style="width: 350px;">
                                    <asp:TextBox ID="street_address" runat="server" Height="50px" Width="350px" Placeholder=" Street Address"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="street_address_validator" runat="server" ErrorMessage="*Please Enter Street Address." ControlToValidate="street_address" Display="Dynamic" Text="*Please Enter Street Address." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="Postal Code:" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="postal_code" runat="server" Height="50px" Width="350px" Placeholder=" Postal Code"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="postal_code_validator" runat="server" ErrorMessage="*Please Enter Postal Code." ControlToValidate="postal_code" Display="Dynamic" Text="*Please Enter Postal Code." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="City: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="city" runat="server" Height="50px" Width="350px" Placeholder=" City"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="city_validator" runat="server" ErrorMessage="*Please Enter City Name." ControlToValidate="city" Display="Dynamic" Text="*Please Enter City Name." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="State:" Font-Bold="True"></asp:Label>
                                </td>
                                <td style="width: 350px;">
                                    <asp:DropDownList ID="DropDownListState" runat="server" Height="40px" Width="150px">
                                        <asp:ListItem Text="Johor" Value="Johor"></asp:ListItem>
                                        <asp:ListItem Text="Kedah" Value="Kedah"></asp:ListItem>
                                        <asp:ListItem Text="Kelantan" Value="Kelantan"></asp:ListItem>
                                        <asp:ListItem Text="Kuala Lumpur" Value="Kuala Lumpur"></asp:ListItem>
                                        <asp:ListItem Text="Melaka" Value="Melaka"></asp:ListItem>
                                        <asp:ListItem Text="Negeri Sembilan" Value="Negeri Sembilan"></asp:ListItem>
                                        <asp:ListItem Text="Pahang" Value="Pahang"></asp:ListItem>
                                        <asp:ListItem Text="Penang" Value="Penang"></asp:ListItem>
                                        <asp:ListItem Text="Perak" Value="Perak"></asp:ListItem>
                                        <asp:ListItem Text="Perlis" Value="Perlis"></asp:ListItem>
                                        <asp:ListItem Text="Sabah" Value="Sabah"></asp:ListItem>
                                        <asp:ListItem Text="Sarawak" Value="Sarawak"></asp:ListItem>
                                        <asp:ListItem Text="Selangor" Value="Selangor"></asp:ListItem>
                                        <asp:ListItem Text="Terengganu" Value="Terengganu"></asp:ListItem>
                                    </asp:DropDownList>                                
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                        <br /><br />
                        <table style="margin-left: -6rem;" >
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Item(s) Needed: " Font-Bold="True"></asp:Label>
                                    <br />
                                    <asp:Label runat="server" Text="*Measured in kilograms (kgs)." style="color:#9e9e9e; font-size: 0.8rem;" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Image runat="server" ID="Fruits" ImageUrl="../Customised_Design/Images/fruits.jpg" Width="250px"></asp:Image>
                                </td>
                                <td>
                                    <asp:Image runat="server" ID="Vegetables" ImageUrl="../Customised_Design/Images/vegetables.jpg" Width="250px"></asp:Image>
                                </td>
                                <td>
                                    <asp:Image runat="server" ID="Dairy_and_Eggs" ImageUrl="../Customised_Design/Images/dairy-and-eggs.jpg" Width="250px"></asp:Image>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Fruits" Font-Bold="True" />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="Vegetables" Font-Bold="True" />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="Dairy and Eggs" Font-Bold="True" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="Fruits_Quantity" runat="server" Width="90px" TextMode="Number" Min="0" Max="99999" onkeydown="return false;" />
                                </td>
                                <td>
                                    <asp:TextBox ID="Vegetables_Quantity" runat="server" Width="90px" TextMode="Number" Min="0" Max="99999" onkeydown="return false;" />
                                </td>
                                <td>
                                    <asp:TextBox ID="Dairy_and_Eggs_Quantity" runat="server" Width="90px" TextMode="Number" Min="0" Max="99999" onkeydown="return false;" />
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td>
                                    <asp:Image runat="server" ID="Meat" ImageUrl="../Customised_Design/Images/meat.jpg" Width="250px"></asp:Image>
                                </td>
                                <td>
                                    <asp:Image runat="server" ID="Seafood" ImageUrl="../Customised_Design/Images/seafood.jpg" Width="250px"></asp:Image>
                                </td>
                                <td>
                                    <asp:Image runat="server" ID="Breads_and_Cereals" ImageUrl="../Customised_Design/Images/breads-and-cereals.jpg" Width="250px"></asp:Image>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Meat" Font-Bold="True" />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="Seafood" Font-Bold="True" />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="Breads and Cereals" Font-Bold="True" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="Meat_Quantity" runat="server" Width="90px" TextMode="Number" Min="0" Max="99999" onkeydown="return false;" />
                                </td>
                                <td>
                                    <asp:TextBox ID="Seafood_Quantity" runat="server" Width="90px" TextMode="Number" Min="0" Max="99999" onkeydown="return false;" />
                                </td>
                                <td>
                                    <asp:TextBox ID="Breads_and_Cereals_Quantity" runat="server" Width="90px" TextMode="Number" Min="0" Max="99999" onkeydown="return false;" />
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td>
                                    <asp:Image runat="server" ID="Sweets_Snacks_Beverages" ImageUrl="../Customised_Design/Images/sweets-snacks-beverages.jpg" Width="250px"></asp:Image>
                                </td>
                                <td>
                                    <asp:Image runat="server" ID="Canned_Products" ImageUrl="../Customised_Design/Images/canned-products.jpg" Width="250px"></asp:Image>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Sweets, Snacks, or Beverages" Font-Bold="True" />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="Canned Products" Font-Bold="True" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="Sweets_Snacks_Beverages_Quantity" runat="server" Width="90px" TextMode="Number" Min="0" Max="99999" onkeydown="return false;" />
                                </td>
                                <td>
                                    <asp:TextBox ID="Canned_Products_Quantity" runat="server" Width="90px" TextMode="Number" Min="0" Max="99999" onkeydown="return false;"/>
                                </td>
                            </tr>
                        </table>
                        <br /><br /><br />
                        <br />
                        <table style="margin-left: -2.5rem;">
                            <tr><td></td></tr>
                                <tr>
                                    <td style="width: 350px; white-space: nowrap;">
                                        <asp:Label runat="server" Text="Other Messages: " Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="other_messages_textbox" runat="server" TextMode="MultiLine" Width="450px" Height="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                </table>
                                <table style="margin-left: -2.5rem;">
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="delivery_service" runat="server" Height="20" Width="20" />
                                            <asp:Label runat="server" Text="Delivery Service" style="margin-left: 6px;" ></asp:Label>
                                            <br />
                                            <asp:Label runat="server" Text="*Applicable only for verified recipients." style="color:#9e9e9e; font-size: 0.8rem;" ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                        <br /><br />
                        <asp:Button ID="submit_button" runat="server" Text="Submit" ForeColor="#FA65B1" BorderColor="#FA65B1" CssClass="asp-submit-button" OnClick="submit_button_Click" />
                        <asp:Label runat="server" ID="FormCount" Text="Label" Visible="False"></asp:Label>
                        <asp:Label ID="member_id" runat="server" Text="member id" Visible="False"></asp:Label>
                        <asp:Label ID="verified" runat="server" Text="verified" Visible="False"></asp:Label>
                        <asp:Label ID="LabelErrorMessage" runat="server" Text="Error Message" Visible="False"></asp:Label>
                    </div>
                </div>
            </div>
        </div> 
    </div>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
</asp:Content>
