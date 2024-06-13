<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Admin.Master" AutoEventWireup="true" CodeBehind="manage_contact_form.aspx.cs" Inherits="FYP_DFB.manage_contact_form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent1" runat="server">

    <style>
    .gridview-item {
        padding: 20px;
        text-align: center;
    }

    .gridview-alternating-item {
        background-color: #fcf0f7;
        padding: 20px;
    }

    .header-style {
        padding-left: 40px;   
        padding-right: 40px;  
    }
    </style>

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
                                            <h4>Manage Contact Us Forms</h4>
                                            <div class="line-dec" style="background-color: #fa65b1;"></div>
                                            <br />
                                            <br /><br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="right-image wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.5s">
                                <img src="../Customised_Design/Images/manage.png" alt="" style="transform: scale(0.85)">
                            </div>
                        </div>
                    </div>                                       
                </div>
            </div>
        </div> 
    </div>

    <div id="blog" class="blog">
        <div class="container" style="margin-bottom: 14rem;">>
            <div class="row">
                <div class="col-lg-6 offset-lg-3  wow fadeInDown" data-wow-duration="1s" data-wow-delay="0.2s">
                    <div class="section-heading">
                        <h4><em>Manage Contact Us Forms</em></h4>
                        <div class="line-dec"></div>
                    </div>
                </div>
                <div class="row wow fadeInUp" data-wow-duration="0.8s" data-wow-delay="0.4s">
                    <div class="col-lg-6 offset-lg-3">
                        <div class="section-heading" style="width: 800px;">
                            <asp:TextBox ID="txtSearch" runat="server" placeholder=" Enter Form ID or Email to Search" Width="450px" Height="50px" style="border-radius: 10px; border-color: #c0c0c0;" TextMode="Search"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" style="margin-left: 1.5rem;" ForeColor="#FA65B1" Height="50px" Width="150px" BorderColor="#FA65B1" CssClass="asp-submit-button"/>
                        </div>
                    </div>
                    <br /><br />
                    <div class="col-lg-6 offset-lg-3">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" RowStyle-Height="75px" style="margin-left: -17rem;" BorderStyle="Solid" BorderColor="#fa65b1" BorderWidth="2px">
                            <Columns>
                                <asp:BoundField HeaderText="Form ID" DataField="contact_id" HeaderStyle-Height="50" ItemStyle-CssClass="gridview-item" HeaderStyle-Wrap="False">
                                    <HeaderStyle CssClass="header-style" ForeColor="#fa65b1" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Sender Name" DataField="contact_name" HeaderStyle-Height="50" ItemStyle-CssClass="gridview-item" HeaderStyle-Wrap="False">
                                    <HeaderStyle CssClass="header-style" ForeColor="#fa65b1" />
                                </asp:BoundField>                                
                                <asp:BoundField HeaderText="Email" DataField="contact_email" HeaderStyle-Height="50" ItemStyle-CssClass="gridview-item" HeaderStyle-Wrap="False">
                                    <HeaderStyle CssClass="header-style" ForeColor="#fa65b1" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Subject" HeaderStyle-Height="50" ItemStyle-CssClass="gridview-item" HeaderStyle-Wrap="False">
                                    <HeaderStyle CssClass="header-style" ForeColor="#fa65b1" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <div style="width: 200px; text-align: center;"> <%# Eval("contact_subject") %> </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Status" DataField="contact_status" HeaderStyle-Height="50" ItemStyle-CssClass="gridview-item" HeaderStyle-Wrap="False">
                                    <HeaderStyle CssClass="header-style" ForeColor="#fa65b1" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="">
                                    <HeaderStyle CssClass="header-style" ForeColor="#fa65b1" />
                                    <ItemTemplate>
                                        <asp:Button ID="ViewButton" runat="server" Text="View Details" CommandName="ViewDetails" CommandArgument='<%# Eval("contact_id") %>' style="margin-left: 4rem; text-align: center;" ForeColor="#FA65B1" Height="50px" Width="180px" BorderColor="#FA65B1" CssClass="asp-submit-button" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="gridview-item" />
                            <AlternatingRowStyle CssClass="gridview-alternating-item" />
                        </asp:GridView>
                        <br /><br /><br /><br /><br /><br /><br /><br />
                    </div>
                </div>
            </div>
        </div> 


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" runat="server">
</asp:Content>
