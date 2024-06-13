<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="inventory.aspx.cs" Inherits="FYP_DFB.inventory" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="MainContent1" runat="server">

    <div class="main-banner wow fadeIn" id="top" data-wow-duration="1s" data-wow-delay="0.5s">
        <div class="container" style="margin-top: -2.5rem;">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg-6 align-self-center">
                            <div class="left-content show-up header-text wow fadeInLeft" data-wow-duration="1s" data-wow-delay="1s">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <h6>Digital Food Bank</h6>
                                        <div class="section-heading">
                                            <h4>Our Inventory</h4>
                                            <div class="line-dec" style="background-color: #fa65b1;"></div>
                                            <br />
                                            <p>We believe that by providing inventory visibility, individuals and organizations can make informed decisions regarding food donations and requests for food assistance. This can significantly mitigate the risks of overstocking or understocking of food items, which in turn helps us to deliver a more efficient and effective service to our partners.</p>
                                            <br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="right-image wow fadeInRight" data-wow-duration="1s" data-wow-delay="0.5s">
                                <img src="../Customised_Design/Images/inventory-background.jpg" alt="" style="transform: scale(0.8);">
                            </div>
                        </div>
                    </div>                                       
                </div>
            </div>
        </div> 
    </div>

    <div id="blog" class="blog" style="margin-top: -2rem;">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 offset-lg-3  wow fadeInDown" data-wow-duration="1s" data-wow-delay="0.2s">
                    <div class="section-heading">
                        <h4><em>Our Inventory</em></h4>
                        <div class="line-dec"></div>
                        <p style="margin-top: 1.5rem; color: #9c9c9c;">
                            Available quantities are shown as below.
                            Items are measured in kilograms (kgs).</p>
                    </div>
                </div>
                <div class="row wow fadeInUp" data-wow-duration="0.8s" data-wow-delay="0.4s">   
                    <div class="col-lg-6 offset-lg-3">
                        <table style="margin-left: -9.5rem;" >
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
                                <td style="text-align: center;">
                                    <asp:Label runat="server" Text="Fruits" Font-Bold="True" style="font-size: 1.2rem;" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label runat="server" Text="Vegetables" Font-Bold="True" style="font-size: 1.2rem;" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label runat="server" Text="Dairy and Eggs" Font-Bold="True" style="font-size: 1.2rem;" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;">
                                    <asp:Label runat="server" ID="Fruits_Quantity" Text="1" Font-Bold="True" style="color: #86db6e; font-size: 2rem;" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label runat="server" ID="Vegetables_Quantity" Text="1" Font-Bold="True" style="color: #86db6e; font-size: 2rem;" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label runat="server" ID="Dairy_Eggs_Quantity" Text="1" Font-Bold="True" style="color: #86db6e; font-size: 2rem;" />
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
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
                                <td style="text-align: center;">
                                    <asp:Label runat="server" Text="Meat" Font-Bold="True" style="font-size: 1.2rem;" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label runat="server" Text="Seafood" Font-Bold="True" style="font-size: 1.2rem;" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label runat="server" Text="Breads and Cereals" Font-Bold="True" style="font-size: 1.2rem;" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;">
                                    <asp:Label runat="server" ID="Meat_Quantity" Text="1" Font-Bold="True" style="color: #86db6e; font-size: 2rem;" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label runat="server" ID="Seafood_Quantity" Text="1" Font-Bold="True" style="color: #86db6e; font-size: 2rem;" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label runat="server" ID="Breads_Cereals_Quantity" Text="1" Font-Bold="True" style="color: #86db6e; font-size: 2rem;" />
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
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
                                <td style="text-align: center;">
                                    <asp:Label runat="server" Text="Sweets, Snacks, or Beverages" Font-Bold="True" style="font-size: 1.2rem;" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label runat="server" Text="Canned Products" Font-Bold="True" style="font-size: 1.2rem;" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;">
                                    <asp:Label runat="server" ID="Sweets_Snacks_Beverages_Quantity" Text="1" Font-Bold="True" style="color: #86db6e; font-size: 2rem;" />
                                </td>
                                <td style="text-align: center;">
                                    <asp:Label runat="server" ID="Canned_Quantity" Text="1" Font-Bold="True" style="color: #86db6e; font-size: 2rem;" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div> 
    </div>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
</asp:Content>
