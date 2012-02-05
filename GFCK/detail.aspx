<%@ Page Title="" Language="C#" MasterPageFile="~/LightBox.Master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="GFCK.detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function printpage() {
        var d = new Date();
        var min = d.getMinutes();
        var s = d.getSeconds();
        var m = d.getMilliseconds();
        var time = min + s + m;
        var $dialog1 = $('<div id="cp123"></div>')
			        .load('/printcoupon.aspx?time=' + time)
			        .dialog({
			            autoOpen: true,
			            width: 883,
			            modal: true,
			            stack: true,
			            resizable: false,
			            title: 'Printing Coupon...',
			            position: [0,0],
			            close: function (event, ui) {
			                $(this).dialog('destroy');
			                $("#cp123").remove();
			            }
			        });
                    //$("#dialog").html('');
                    $dialog1.dialog('open');
                    //$(this).dialog('close');
                    //$dialog.dialog('close');
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="dialog" class="column-center-background" style="width:750px;">
        <!--content_center-->
        <div id="divPrint" runat="server">
            <span class="printHeading" style="float:right;"><a href="#" onclick="printpage(); return false;"><img src="images/icons/print.gif" height="20px" style="margin-top:-3px" /></a></span>&nbsp;&nbsp;<span  class="printHeading" style="float:right;"><a href="#" onclick="printpage(); return false;">print coupon</a></span>
        </div>
        <br />
        <div class="centerColumn" id="productGeneral" style="padding: 0;">
            <!--bof Main Product Image -->
            <div id="productMainImage" class="centeredContent back">
                <div class="img_box1" style="float: left; overflow: hidden; margin-right: 0;height:250px;width:250px;">
                    <img id="imgProduct" runat="server" style="max-height:250px;max-width:250px;" /><br />
                </div>
            </div>
            <div class="checkboxes">
            <asp:Literal ID="litValue" runat="server" />
            <asp:Repeater ID="rptFree" runat="server" OnItemDataBound="rptFree_ItemDataBound">
                <HeaderTemplate><ul></HeaderTemplate>
                <ItemTemplate><li id="liItem" runat="server"></li></ItemTemplate>
                <FooterTemplate></ul></FooterTemplate>
            </asp:Repeater>
            </div>
            <!--eof Main Product Image-->
            <br class="clearBoth" />
            <!--bof Product description -->
            <div id="productDescription" class="productGeneral" style="float:left;">
                <asp:Literal ID="litDescription" runat="server" /><br /><br />
            </div>

            <br class="clearBoth" />
            <div style="font-size:10px">
                <asp:Literal ID="litTerms" runat="server" /><br /><br />
            </div>
            <div style="font-size:10px"><p>Distribution of this coupon in PDF or other portable document format is not permitted. Void if copied, altered, reproduced, sold, transferred or exchanged. Any misuse constitutes fraud and is prosecutable under federal wire and other statutes. Civil and criminal penalties exceeding $2,000,000 and/or imprisonment may apply.</p></div>
            <!--eof Product description -->
        </div>
        <!--eof content_center-->
    </div>
    <div class="clear">
    </div>
</asp:Content>
