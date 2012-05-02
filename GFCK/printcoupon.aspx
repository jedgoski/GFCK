<%@ Page Title="" Language="C#" MasterPageFile="~/LightBox.Master" AutoEventWireup="true" CodeBehind="printcoupon.aspx.cs" Inherits="GFCK.printcoupon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href='http://fonts.googleapis.com/css?family=Fredericka+the+Great' rel='stylesheet' type='text/css'>
	<script type="text/javascript">
	    $(document).ready(function () {
	        //$("#dialog1").jqprint();
	        window.print();
	        setTimeout(function () {
	            hideAll();
	        }, 2000);
	    });

	    function hideAll() {
	        $(".ui-dialog").hide();
	        $(".ui-widget-overlay").hide();
	    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="dialog1" title="coupon" class="column-center-background" style="width:8.5in; height:11in; overflow:hidden;">
        <!--content_center-->
        <div class="coupon">
            <div class="couponheading">
                <div style="padding-left:20px;width:250px;float:left;">MANUFACTURER'S COUPON</div>
                <div style="float:right; padding-right:20px;width:200px;text-align:right;">Expires <asp:Literal ID="litExpDate" runat="server" /></div>
            </div>
            <div class="couponbody">
                <div style="float:left;"><img id="img" runat="server" style="max-height:1.7in;max-width:1.7in;height:100%"  /></div>
                <div class="couponContent">
                    <div class="dotscan"><img id="dotscan" runat="server" />
                    &nbsp;<asp:Literal ID="litDotScan" runat="server" /></div>
                    <div class="couponbold"><asp:Literal ID="litValue" runat="server" /></div>
                    <p class="couponfontbold"><asp:Literal ID="litName" runat="server" /></p>
                    <p><asp:Literal ID="litTerms" runat="server" /></p>
                </div>
            </div>
            <div class="couponbarcode">
               <div style="float:right;padding:4px 20px 0px 40px;"><img id="imgBarcode2" runat="server" /></div>
               <div style="float:right;padding:4px 10px 0px 10px;"><img id="imgBarcode1" runat="server" /></div>
            </div>
        </div>
        <!--<img src="/images/coupontest.png" />-->
        
        <div class="printthis"><br /><br /><br />
            <img id="imgBanner" runat="server" visible="false" />
        </div>
        <!--eof content_center-->
    </div>
</asp:Content>
