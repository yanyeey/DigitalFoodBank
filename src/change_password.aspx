<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="change_password.aspx.cs" Inherits="FYP_DFB.change_password" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="MainContent1" runat="server">
    
    <div class="main-banner wow fadeIn" id="top" data-wow-duration="1s" data-wow-delay="0.5s">
        <div class="container" style="margin-top: -5rem;">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg-6 align-self-center">
                            <div class="left-content show-up header-text wow fadeInLeft" data-wow-duration="1s" data-wow-delay="1s">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <h6>Digital Food Bank</h6>
                                        <div class="section-heading">
                                            <h4>Change Password</h4>
                                            <div class="line-dec" style="background-color: #fa65b1;"></div>
                                            <br /><br /><br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="right-image wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.5s">
                                <img src="../Customised_Design/Images/password-bg.png" alt="" style="transform: scale(0.8); opacity: 0.9;">
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
                        <h6>Change Password</h6>
                        <h4>Please Enter <em>New Password</em></h4>
                        <div class="line-dec"></div>
                    </div>
                </div>
                <div class="row wow fadeInUp" data-wow-duration="0.8s" data-wow-delay="0.4s">   
                    <div class="col-lg-6 offset-lg-3" style="margin-bottom: 3rem">
                        <table>
                            <tr>
                                <td style="width: 350px; white-space: nowrap;">
                                    <asp:Label runat="server" Text="Old Password: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="old_password" runat="server" Height="50px" Width="350px" Placeholder=" Old Password" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="old_password_validator" runat="server" ErrorMessage="*Please Enter Old Password." ControlToValidate="old_password" Display="Dynamic" Text="*Please Enter Old Password." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:Label ID="LabelOldPasswordIncorrect" runat="server" Text="Old Password is Incorrect." Visible="False" ForeColor="#FF3300"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 350px;  white-space: nowrap;">
                                    <asp:Label runat="server" Text="New Password: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="new_password" runat="server" Height="50px" Width="350px" Placeholder=" New Password" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="new_password_validator" runat="server" ErrorMessage="*Please Enter New Password." ControlToValidate="new_password" Display="Dynamic" Text="*Please Enter New Password." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:Label ID="LabelPasswordLengthError" runat="server" Text="Password must be between 8 and 16 characters." Visible="False" ForeColor="#FF3300"></asp:Label>
                                </td>
                            </tr>                        
                            <tr>
                                <td style="width: 350px;  white-space: nowrap;">
                                    <asp:Label runat="server" Text="Confirm New Password: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="confirm_new_password" runat="server" Height="50px" Width="350px" Placeholder=" Confirm New Password" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="confirm_new_password_validator" runat="server" ErrorMessage="*Please Confirm New Password." ControlToValidate="confirm_new_password" Display="Dynamic" Text="*Please Confirm New Password." EnableClientScript="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:Label ID="LabelPasswordMatchError" runat="server" Text="Password Does Not Match." Visible="False" ForeColor="#FF3300"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br /><br />
                        <asp:Button ID="save_button" runat="server" Text="Save Changes" ForeColor="#FA65B1" Height="50px" Width="350px" BorderColor="#FA65B1" CssClass="asp-submit-button" Style="margin-left: 10rem;" OnClick="save_button_Click" />
                        <br />
                        <asp:Label ID="member_id" runat="server" Text="member id" Visible="False"></asp:Label>
                        <asp:Label ID="LabelOldPasswordCheck" runat="server" Text="Old Password" Visible="False" ForeColor="Black"></asp:Label>
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
