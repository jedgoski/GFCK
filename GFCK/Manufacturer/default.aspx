<%@ Page Title="" Language="C#" MasterPageFile="~/Manufacturer.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GFCK.Manufacturer._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="column-center-background">
    <div class="centerColumn" id="advSearchResultsDefault">
        <div class="title_box">
	        <div class="row1">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><img src="/images/pixel_trans.gif" alt="" width="1" height="1" /></div>
            </div></div></div>
	        <div class="row2">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><div class="title_inner4"><div class="title_inner5"><div class="title_inner6"><div class="title_inner7">
    	            <h2 id="newProductsDefaultHeading"><asp:Literal ID="litManufacturer" runat="server" /></h2>
                </div></div></div></div></div></div></div>
            </div>
        </div>
            
        <br class="clearBoth"/>
        <div id="productListing"><br /><br />
            <asp:Repeater ID="rptCoupons" runat="server" OnItemDataBound="rptCoupons_ItemDataBound" >
            <HeaderTemplate>
                    <div class="navigation_style_up">
                        <div class="navigation_style_up_header">
                            <div id="productsListingTopNumber" class="navSplitPagesResulthead back"><table><tr>
                                <td width="22px">&nbsp;</td>
                                <td width="250px">Name and Category</td>
                                <td width="100px">Value</td>
                                <td width="75px">Prints used</td>
                                <td width="50px">Expires</td></tr></table>
                            </div>
                            <div id="productsListingListingTopLinks" class="navSplitPagesLinks forward">
                                    &nbsp;
                            </div>
                            <div class="clear"></div>
                        </div>
                    </div>
            </HeaderTemplate>
                <ItemTemplate>
                    <div class="navigation_style_up">
                        <div class="navigation_style_up_inner22">
                            <div id="productsListingTopNumber" class="navSplitPagesResult back"><table><tr>
                                <td width="22px"><img id="img" runat="server" height="20" width="20" src="/images/coupon.jpg" /></td>
                                <td width="250px"><a href="#" id="linkEdit" runat="server"><b><asp:Literal ID="litCouponName" runat="server" /></b>
                                (<asp:Literal ID="litCategory" runat="server" />)</a></td>
                                <td width="100px"><b><asp:Literal ID="litValue" runat="server" /></b></td>
                                <td width="75px"><b><asp:Literal ID="litClicks" runat="server" /></b></td>
                                <td width="50px"><b><asp:Literal ID="litExpires" runat="server" /></b></td></tr></table>
                            </div>
                            <div id="productsListingListingTopLinks" class="navSplitPagesLinks forward">
                                    <a href="#" id="linkDelete" runat="server">Inactivate</a>
                            </div>
                            <div class="clear"></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    </div><br /><br />
</asp:Content>
