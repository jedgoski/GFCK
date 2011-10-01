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
                <ItemTemplate>
                    <div class="navigation_style_up">
                        <div class="navigation_style_up_inner22">
                            <div id="productsListingTopNumber" class="navSplitPagesResult back">
                                <img id="img" runat="server" height="20" width="20" src="/images/coupon.jpg" />
                                <a href="#" id="linkEdit" runat="server"><b><asp:Literal ID="litCouponName" runat="server" /></b>
                                (<asp:Literal ID="litCategory" runat="server" />)</a>
                                <b>$<asp:Literal ID="litValue" runat="server" /></b>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clicks:<b><asp:Literal ID="litClicks" runat="server" /></b>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Expires:<b><asp:Literal ID="litExpires" runat="server" /></b>
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
