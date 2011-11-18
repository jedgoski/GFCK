<%@ Page Title="" Language="C#" MasterPageFile="~/LightBox.Master" AutoEventWireup="true" CodeBehind="printcoupon.aspx.cs" Inherits="GFCK.printcoupon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

	<script type="text/javascript">
	    $(document).ready(function () {
	        //$("#dialog1").jqprint();
	        window.print();
	    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="dialog1" title="test" class="column-center-background" style="width:730px; height:360px;">
        <!--content_center-->
        <div class="coupon">
            <div class="couponheading">
                <div style="padding-left:20px;width:250px;float:left;">MANUFACTURER'S COUPON</div>
                <div style="float:right; padding-right:20px;width:200px;text-align:right;">Expires <asp:Literal ID="litExpDate" runat="server" /></div>
            </div>
            <div class="couponbody">
                <div style="float:left;"><img id="img" runat="server" height="150" /></div>
                <div style="float:left;padding: 10px 0px 0px 15px;width:520px;">
                    <div class="dotscan"><img id="dotscan" runat="server" /><br />
                    &nbsp;<asp:Literal ID="litDotScan" runat="server" /></div>
                    <div class="couponbold">Save <asp:Literal ID="litValue" runat="server" /><br /><br />
                    <asp:Literal ID="litDesc" runat="server" /></div><br />
                    <p><b>Retailer:</b> Udi's, Inc. or a subsidiary, will reimburse the face value of this coupon plus handling if submitted in compliance with its Coupon Redemption Policy, previously provided to you and available upon request. Cash value 1/100c. Coupon can only be distributed by Udi's Inc. or its agent.  Mail to: Udi's Inc., P.O. Box 12345, San Francisco, CA 29348-2837.  Offer expires on date listed above.</p>
                    <p><b>Consumer:</b> Distribution of this coupon in PDF or other portable document format is not permitted. Void if copied, altered, reproduced, sold, transferred or exchanged. Any misuse constitutes fraud and is prosecutable under federal wire and other statutes. Civil and criminal penalties exceeding $2,000,000 and/or imprisonment may apply.</p>
                </div>
            </div>
            <div class="couponbarcode">
               <div style="float:left;padding:4px 10px 0px 10px;"><img id="imgBarcode1" runat="server" /></div>
               <div style="float:left;padding:4px 0px 0px 40px;"><img id="imgBarcode2" runat="server" /></div>
            </div>
        </div>
        <!--<img src="/images/coupontest.png" />-->
        
        <div class="printthis"><br /><br /><br />
            <img id="imgBanner" runat="server" visible="false" />
        </div>
        <!--eof content_center-->
    </div>
</asp:Content>
