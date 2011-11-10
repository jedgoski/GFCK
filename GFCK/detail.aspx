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
                            <img id="imgProduct" runat="server" /></a><br />
                </div>
            </div>
            <!--eof Main Product Image-->
            <!--bof Product description -->
            <div id="productDescription" class="productGeneral biggerText" style="margin-top: 15px;">
                <asp:Literal ID="litDescription" runat="server" />
            </div>
            <br class="clearBoth" />
            <div class="checkboxes">
            <asp:Repeater ID="rptFree" runat="server" OnItemDataBound="rptFree_ItemDataBound">
                <HeaderTemplate><ul></HeaderTemplate>
                <ItemTemplate><li id="liItem" runat="server"></li></ItemTemplate>
                <FooterTemplate></ul></FooterTemplate>
            </asp:Repeater>
            </div>
            <br class="clearBoth" />
            <div>
                <asp:Literal ID="litTerms" runat="server" />
            </div>
            <div><p>Distribution of this coupon in PDF or other portable document format is not permitted. Void if copied, altered, reproduced, sold, transferred or exchanged. Any misuse constitutes fraud and is prosecutable under federal wire and other statutes. Civil and criminal penalties exceeding $2,000,000 and/or imprisonment may apply.</p></div>
            <!--eof Product description -->
        </div>
        <!--eof content_center-->
    </div>
    <div class="clear">
    </div>
</asp:Content>
