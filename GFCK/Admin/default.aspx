<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GFCK.Admin._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Repeater ID="rptManufacturers" runat="server" OnItemDataBound="rptManufacturers_ItemDataBound" >
    <HeaderTemplate>
        <div class="column-center-background">
        <div class="centerColumn" id="advSearchResultsDefault">
            <div class="title_box">
	            <div class="row1">
    	            <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><img src="/images/pixel_trans.gif" alt="" width="1" height="1" /></div>
                </div></div></div>
	            <div class="row2">
    	            <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><div class="title_inner4"><div class="title_inner5"><div class="title_inner6"><div class="title_inner7">
    	                <h2 id="newProductsDefaultHeading">List of Manufacturers</h2>
                    </div></div></div></div></div></div></div>
                </div>
            </div>

            Filter: <asp:DropDownList ID="ddlFilter1" runat="server">
                <asp:ListItem Value="" Text="All" />
                <asp:ListItem Value="current" Text="This Month" />
                <asp:ListItem Value="last" Text="Last Month" />
            </asp:DropDownList>

            <br class="clearBoth"/>
            <div id="productListing"><br /><br />
    </HeaderTemplate>
    <ItemTemplate>

                <div class="navigation_style_up">
                    <div class="navigation_style_up_inner22">
                        <div id="productsListingTopNumber" class="navSplitPagesResult back">
                            <asp:Literal ID="litName" runat="server" />
                        </div>
                        <div id="productsListingListingTopLinks" class="navSplitPagesLinks forward">
                             <a href="#" id="linkEdit" runat="server">Edit</a> | 
                             <a href="#" id="linkDelete" runat="server">Delete</a> | 
                             <a href="#" id="linkStats" runat="server">View Statistics</a>
                        </div>
                        <div class="clear"></div>
                    </div>
                </div>
    </ItemTemplate>
    <FooterTemplate>
            </div>
        </div>
    </div><br /><br />
    </FooterTemplate>
</asp:Repeater>
</asp:Content>
