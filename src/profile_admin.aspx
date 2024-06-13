<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Admin.Master" AutoEventWireup="true" CodeBehind="profile_admin.aspx.cs" Inherits="FYP_DFB.profile_admin" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="MainContent1" runat="server">
    
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div class="main-banner wow fadeIn" id="top" data-wow-duration="1s" data-wow-delay="0.5s">
        <div class="container" style="margin-top: -6rem;">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg-6 align-self-center">
                            <div class="left-content show-up header-text wow fadeInLeft" data-wow-duration="1s" data-wow-delay="1s">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <h6>Digital Food Bank</h6>
                                        <div class="section-heading">
                                            <h4>Admin Profile</h4>
                                            <div class="line-dec" style="background-color: #fa65b1;"></div>
                                            <br /><br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="right-image wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.5s">
                                <img src="../Customised_Design/Images/profile-bg.png" alt="" style="transform: scale(0.85);">
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
                        <h6>Admin Profile</h6>
                        <h4>Good Day, <asp:Label runat="server" ID="greet" Text="Username"></asp:Label><em></em></h4>
                        <div class="line-dec"></div>
                    </div>
                </div>
                <div class="row wow fadeInUp" data-wow-duration="0.8s" data-wow-delay="0.4s">   
                    <div class="col-lg-6 offset-lg-3" style="margin-bottom: 3rem;">
                        <table style="margin-left: 10rem;">
                            <tr>
                                <td style="width: 350px; white-space: nowrap;">
                                    <asp:Label runat="server" Text="Admin ID:" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="admin_id" Text="A0000"></asp:Label>
                                </td>
                            </tr>  
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="First Name:" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="MemberFirstName" Text="FirstName"></asp:Label>
                                </td>
                            </tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="Last Name:" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="MemberLastName" Text="LastName"></asp:Label>
                                </td>
                            </tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr>
                                <td style="width: 350px; white-space: nowrap;">
                                    <asp:Label runat="server" Text="Contact Number: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="MemberContactNum" Text="0123456789"></asp:Label>                                
                                </td>
                            </tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr>
                                <td style="width: 350px;">
                                    <asp:Label runat="server" Text="Email: " Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="MemberEmail" Text="example@mail.com"></asp:Label>                                
                                </td>
                            </tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr><td></td></tr>
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                        <br /><br />
                        <asp:Button ID="modify_button" runat="server" Text="Modify Details" ForeColor="#FA65B1" Height="50px" Width="350px" BorderColor="#FA65B1" CssClass="asp-submit-button" Style="margin-left: 10rem;" OnClick="modify_button_Click" />
                        <asp:Label ID="member_id" runat="server" Text="member id" Visible="False"></asp:Label>
                        <br /><br /><br />
                    </div>
                </div>
            </div>
        </div> 
    </div>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
</asp:Content>

