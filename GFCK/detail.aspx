<%@ Page Title="" Language="C#" MasterPageFile="~/LightBox.Master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="GFCK.detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function printpage() {
        var $dialog1 = $('<div></div>')
			        .load("/printcoupon.aspx")
			        .dialog({
			            autoOpen: true,
			            width: 780,
			            height: 430,
			            modal: true,
			            stack: true,
			            resizable: false,
			            title: 'Coupon Print'
			        });
			        $dialog1.dialog('open');
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="dialog" title="test" class="column-center-background" style="width:750px;">
        <!--content_center-->
        <div id="divPrint" runat="server">
            <span class="printHeading" style="float:right;"><a href="#" onclick="printpage(); return false;"><img src="images/icons/print.gif" height="20px" style="margin-top:-3px" /></a></span>&nbsp;&nbsp;<span  class="printHeading" style="float:right;"><a href="#" onclick="printpage(); return false;">print coupon</a></span>
        </div>
        <br />
        <div class="centerColumn" id="productGeneral" style="padding: 0;">
            <!--bof Main Product Image -->
            <div id="productMainImage" class="centeredContent back">
                <div class="img_box1" style="float: left; overflow: hidden; margin-right: 0;">
                        <a href="#"
                            target="_blank">
                            <img src="images/123456790.gif" alt="Product #04" title=" Product #04 "  /></a><br />
                </div>
            </div>
            <!--eof Main Product Image-->
            <!--bof Product description -->
            <div id="productDescription" class="productGeneral biggerText" style="margin-top: 15px;">
                Quisque sed leo. Vivamus arcu purus, adipiscing et, consequat id, tincidunt sed,
                ligula. Proin bibendum dignissim sem. Nam tempus. Vestibulum sagittis suscipit urna.
                Vestibulum malesuada commodo odio. Nam fermentum neque sit amet massa. Nunc blandit
                lacus in quam. Aliquam fringilla, massa vel malesuada feugiat, enim mi molestie
                turpis, in rhoncus dui tellus vitae turpis. Donec urna enim, congue ut, hendrerit
                nec, imperdiet sed, libero. Nulla ante eros, sagittis et, laoreet in, congue nec,
                odio. In lectus nisi, scelerisque quis, condimentum a, sollicitudin vitae, ligula.
                Maecenas blandit. Duis sodales euismod lectus. Sed vel est et orci laoreet ultricies.
                Mauris consequat placerat diam. Etiam ut libero. Pellentesque aliquet fermentum
                velit. Nullam risus metus, dignissim interdum, dapibus sed, posuere ac, mi. Mauris
                condimentum, neque vel tristique faucibus, mauris tortor tincidunt nunc, at pretium
                turpis dui id elit. Donec sit amet est. Mauris quis erat ac diam tincidunt hendrerit.
                Fusce malesuada tortor ut leo. Nulla facilisi. Aenean placerat, eros quis ultrices
                vehicula, enim lacus interdum turpis, non iaculis metus odio sit amet tellus. Pellentesque
                cursus tempor metus. In aliquam pulvinar nibh.</div>
            <br class="clearBoth" />
            <!--eof Product description -->
        </div>
        <!--eof content_center-->
    </div>
    <div class="clear">
    </div>
</asp:Content>
