<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Stats.aspx.cs" Inherits="GFCK.Admin.Stats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">
        $(function () {

            // Datepicker
            $('.datepicker').datepicker({
                inline: true
            });

            //hover states on the static widgets
            $('#dialog_link, ul#icons li').hover(
					function () { $(this).addClass('ui-state-hover'); },
					function () { $(this).removeClass('ui-state-hover'); }
				);

        });
		</script>

    <div class="column-center-background">
    <div class="centerColumn" id="advSearchResultsDefault">

        <div class="title_box">
	        <div class="row1">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><img src="/images/pixel_trans.gif" alt="" width="1" height="1" /></div>
            </div></div></div>
	        <div class="row2">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><div class="title_inner4"><div class="title_inner5"><div class="title_inner6"><div class="title_inner7">
    	            <h2 id="newProductsDefaultHeading"><asp:Literal ID="litName" runat="server" /></h2>
                </div></div></div></div></div></div></div>
            </div>
        </div>

        <a href="/Admin/default.aspx" >Back</a>
        <br />
        <br />
        <table>
        <tr>
            <td>
            Filter: <asp:DropDownList ID="ddlFilter1" runat="server" AutoPostBack="true">
                <asp:ListItem Value="all" Text="All" />
                <asp:ListItem Value="current" Text="This Month" />
                <asp:ListItem Value="last" Text="Last Month" />
            </asp:DropDownList>

            </td>
            <td width="100px"></td>

            <td>
                Start Date:
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="datepicker tbsmall" />


                End Date:
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="datepicker tbsmall" />
            </td>
            <td width="10px"></td>
            <td>
                    <asp:ImageButton ID="btnGo" runat="server" AlternateText="Go" ImageUrl="/images/buttons/english/button_submit.gif" />
            </td>
            </tr>
        </table>

        <br class="clearBoth"/>
        <div id="productListing"><br /><br />
        <asp:Literal ID="litNoDataFound" runat="server" visible="false"><b>No Data Found</b></asp:Literal>
            <asp:Repeater ID="rptCoupons" runat="server" OnItemDataBound="rptCoupons_ItemDataBound" >
                <ItemTemplate>

                            <div class="navigation_style_up">
                                <div class="navigation_style_up_inner22">
                                    <div id="productsListingTopNumber" class="navSplitPagesResult back">
                                        <asp:Literal ID="litCoupon" runat="server" />
                                    </div>
                                    <div id="productsListingListingTopLinks" class="navSplitPagesLinks forward">
                                         <asp:Literal ID="litStats" runat="server" />
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
