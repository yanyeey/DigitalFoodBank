﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="profile_modify_member.aspx.cs" Inherits="FYP_DFB.profile_modify_member" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="MainContent1" runat="server">
    
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div class="main-banner wow fadeIn" id="top" data-wow-duration="1s" data-wow-delay="0.5s">
        <div class="container" style="margin-top: -7rem;">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg-6 align-self-center">
                            <div class="left-content show-up header-text wow fadeInLeft" data-wow-duration="1s" data-wow-delay="1s">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <h6>Digital Food Bank</h6>
                                        <div class="section-heading">
                                            <h4>Modify Profile</h4>
                                            <div class="line-dec" style="background-color: #fa65b1;"></div>
                                            <br /><br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="right-image wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.5s">
                                <img src="../Customised_Design/Images/profile-bg.png" alt="" style="transform: scale(0.8);">
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
                        <h6>Modify Profile</h6>
                        <h4>Please Fill In Your <em>Details</em></h4>
                        <div class="line-dec"></div>
                    </div>
                </div>
                <div class="row wow fadeInUp" data-wow-duration="0.8s" data-wow-delay="0.4s">   
                    <div class="col-lg-6 offset-lg-3" style="margin-bottom: 3rem; margin-left: 26rem;">
                        <asp:UpdatePanel ID="role_UpdatePanel" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" Text="Role: " Font-Bold="True" Width="130px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="MemberRole" Text="Role"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr><td></td></tr>
                                    <tr><td></td></tr>
                                    <tr><td></td></tr>
                                </table>
                                <div id="individualFields" runat="server">
                                    <table>
                                        <tr>
                                            <td style="white-space:nowrap;">
                                                <asp:Label runat="server" Text="First Name:" Font-Bold="True" Width="130px"></asp:Label>
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
                                            <td style="width: 350px;">
                                                <asp:Label runat="server" Text="Last Name:" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="individual_last_name" runat="server" Height="50px" Width="350px" placeholder=" Last Name"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="individual_last_name_validator" runat="server" ErrorMessage="*Please Enter Last Name." ControlToValidate="individual_last_name" Display="Dynamic" Text="*Please Enter Last Name." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="organizationFields" runat="server" style="display: none;">
                                    <table>
                                        <tr>
                                            <td style="width: 350px; white-space:nowrap;">
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
                                            <td style="width: 350px; white-space:nowrap;">
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
                                            <td style="width: 350px; white-space:nowrap;">
                                                <asp:Label runat="server" Text="Name of Person in Charge: " Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="person_in_charge" runat="server" Height="50px" Width="350px" placeholder=" Name of Person in Charge"></asp:TextBox>
                                            </td>
                                        </tr>  
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="person_in_charge_validator" runat="server" ErrorMessage="*Please Enter Name of Person in Charge." ControlToValidate="person_in_charge" Display="Dynamic" Text="*Please Enter Enter Name of Person in Charge." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="UpdatePaneltype" runat="server">
                            <ContentTemplate>
                                <div id="IndividualRecipient" runat="server">
                                    <table>
                                        <tr>
                                            <td style="width: 350px; white-space:nowrap;">
                                                <asp:Label runat="server" ID="identification_num" Text="Identification Number: " Font-Bold="True" Width="130px"></asp:Label>
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
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="UpdatePanelRecipient" runat="server">
                            <ContentTemplate>
                                <div id="RecipientUpload" runat="server">
                                    <table>
                                        <tr>
                                            <td style="width: 350px; white-space:nowrap;">
                                                <asp:Label runat="server" Text="Identification Document: " Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="RecipientFileUpload" runat="server" />
                                                <br />
                                                <asp:Image ID="IdentificationImage" runat="server" Height="200px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="file_validator" runat="server" ErrorMessage="*Please Upload Identification Document." ControlToValidate="RecipientFileUpload" Display="Dynamic" Text="*Please Upload Identification Document." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <table>
                            <tr>
                                <td style="width: 350px; white-space:nowrap;">
                                    <asp:Label runat="server" Text="Contact Number: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="contact_no" runat="server" Height="50px" Width="350px" Placeholder=" E.g. 60123456789"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="contact_no_validator" runat="server" ErrorMessage="*Please Enter Contact Number." ControlToValidate="contact_no" Display="Dynamic" Text="*Please Enter Contact Number." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="phoneValidator" runat="server" ControlToValidate="contact_no" ValidationExpression="^60\d{9}$" Display="Dynamic" ErrorMessage="Please enter a valid contact number." ForeColor="Red" ></asp:RegularExpressionValidator>                                
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
                                    <asp:Label ID="LabelEmailTakenError" runat="server" Text="This email has been registered." Visible="False" ForeColor="#FF3300"></asp:Label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="email" EnableClientScript="False" ErrorMessage="Invalid Email." ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>                                
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 350px;">
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
                                    <asp:DropDownList runat="server" ID="DropDownListState" Height="40px" Width="150px">
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
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Password: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <a href="change_password.aspx"><u>Change Password</u></a>                                
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                        <br /><br />
                        <asp:Button ID="save_button" runat="server" Text="Save Changes" ForeColor="#FA65B1" Height="50px" Width="350px" BorderColor="#FA65B1" CssClass="asp-submit-button" Style="margin-left: 6rem;" OnClick="save_button_Click" />
                        <asp:Label ID="member_id" runat="server" Text="member id" Visible="False"></asp:Label>
                        <asp:Label ID="member_type" runat="server" Text="member type" Visible="False"></asp:Label>
                        <asp:Label ID="verified" runat="server" Text="verified" Visible="False"></asp:Label>
                        <br />
                        <asp:Label ID="LabelErrorMessage" runat="server" Text="Error Message" Visible="False"></asp:Label>
                        <br /><br />
                    </div>
                </div>
            </div>
        </div> 
    </div>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
</asp:Content>
