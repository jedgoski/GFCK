<%@ Page Title="" Language="C#" MasterPageFile="~/LightBox.Master" AutoEventWireup="true" CodeBehind="printcoupon.aspx.cs" Inherits="GFCK.printcoupon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

	<script type="text/javascript">
	    $(document).ready(function () {
	        $("#dialog1").jqprint();
	    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="dialog1" title="test" class="column-center-background" style="width:730px; height:360px;">
        <!--content_center-->
        <img src="/images/coupontest.png" />
        
        <div class="printthis">
            <img src="/images/banner2.jpg" />
        </div>
        <!--eof content_center-->
    </div>
</asp:Content>
