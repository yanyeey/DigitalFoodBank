<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Admin.Master" AutoEventWireup="true" CodeBehind="profile_modify_admin.aspx.cs" Inherits="FYP_DFB.profile_modify_admin" %>

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
                                            <h4>Modify Admin Profile</h4>
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
                        <h6>Modify Admin Profile</h6>
                        <h4>Please Fill In Your <em>Details</em></h4>
                        <div class="line-dec"></div>
                    </div>
                </div>
                <div class="row wow fadeInUp" data-wow-duration="0.8s" data-wow-delay="0.4s">   
                    <div class="col-lg-6 offset-lg-3" style="margin-bottom: 3rem;">
                        <table style="margin-left: 4rem;">
                            <tr>
                                <td style="width: 350px; white-space:nowrap">
                                    <asp:Label runat="server" Text="Admin ID: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="AdminNum" Text="Type"></asp:Label>
                                </td>
                            </tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr>
                                <td style="width: 350px; white-space:nowrap"">
                                    <asp:Label runat="server" Text="First Name:" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="admin_first_name" runat="server" Height="50px" Width="350px" placeholder=" First Name"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="admin_first_name_validator" runat="server" ErrorMessage="*Please Enter First Name." ControlToValidate="admin_first_name" Display="Dynamic" Text="*Please Enter First Name." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="Last Name:" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="admin_last_name" runat="server" Height="50px" Width="350px" placeholder=" Last Name"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="admin_last_name_validator" runat="server" ErrorMessage="*Please Enter Last Name." ControlToValidate="admin_last_name" Display="Dynamic" Text="*Please Enter Last Name." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 350px; white-space:nowrap"">
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
                        <asp:Button ID="save_button" runat="server" Text="Save Changes" ForeColor="#FA65B1" Height="50px" Width="350px" BorderColor="#FA65B1" CssClass="asp-submit-button" Style="margin-left: 12rem;" OnClick="save_button_Click" />
                        <br />
                        <asp:Label ID="member_id" runat="server" Text="member id" Visible="False"></asp:Label>
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

