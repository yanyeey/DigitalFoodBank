<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Admin.Master" AutoEventWireup="true" CodeBehind="sign_up_admin.aspx.cs" Inherits="FYP_DFB.sign_up_admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent1" runat="server">

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
                                            <h4>Admin Registration Form</h4>
                                            <div class="line-dec" style="background-color: #fa65b1;"></div>
                                            <br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="right-image wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.5s">
                                <img src="../Customised_Design/Images/form-background.jpeg" alt="" style="transform: scale(0.8);">
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
                        <h6>Admin Registration Form</h6>
                        <h4>Please Fill In The <em>Details</em></h4>
                        <div class="line-dec"></div>
                    </div>
                </div>
                <div class="row wow fadeInUp" data-wow-duration="0.8s" data-wow-delay="0.4s">   
                    <div class="col-lg-6 offset-lg-3" style="margin-bottom: 3rem;">
                        <table style="width: 750px; white-space: nowrap;">
                            <tr>
                                <td style="width: 350px;">
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
                                    <asp:RequiredFieldValidator ID="indiivdual_last_name_validator" runat="server" ErrorMessage="*Please Enter Last Name." ControlToValidate="individual_last_name" Display="Dynamic" Text="*Please Enter Last Name." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 350px;">
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
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="email" EnableClientScript="False" ErrorMessage="Invalid Email." ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
                                    <asp:Label ID="LabelEmailTakenError" runat="server" Text="This email has been registered." Visible="False" ForeColor="#FF3300"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label runat="server" Text="Password: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="password" runat="server" Height="50px" Width="350px" TextMode="Password" Placeholder=" Password"></asp:TextBox>  
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="password_validator" runat="server" ErrorMessage="*Please Enter Password." ControlToValidate="password" Display="Dynamic" Text="*Please Enter Password." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:Label ID="LabelPasswordLengthError" runat="server" Text="Password must be between 8 and 16 characters." Visible="False" ForeColor="#FF3300"></asp:Label>
                                </td>
                            </tr>
                            <tr><td></td></tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Confirm Password: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="confirm_password" runat="server" Height="50px" Width="350px" TextMode="Password" Placeholder=" Confirm Password"></asp:TextBox>  
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="confirm_password_validator" runat="server" ErrorMessage="*Please Confirm Password." ControlToValidate="confirm_password" Display="Dynamic" Text="*Please Confirm Password." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:Label ID="LabelPasswordMatchError" runat="server" Text="Password Does Not Match." Visible="False" ForeColor="#FF3300"></asp:Label>                           
                                </td>
                            </tr>
                        </table>
                        <br /><br />
                        <asp:Button ID="signup_button" runat="server" Text="Add Admin" ForeColor="#FA65B1" Height="50px" Width="350px" BorderColor="#FA65B1" CssClass="asp-submit-button" Style="margin-left: 12rem;" OnClick="signup_button_Click" />
                        <asp:Label runat="server" ID="AdminCount" Text="Label" Visible="False"></asp:Label>
                        <br /><br /><br />
                        <asp:Label ID="LabelErrorMessage" runat="server" Text="Error Message" Visible="False" style="margin-left: 14rem;"></asp:Label>
                    </div>
                </div>
            </div>
        </div> 
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" runat="server">
</asp:Content>
