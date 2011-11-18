<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Manufacturer.Master" CodeBehind="Action.aspx.cs" Inherits="GFCK.Manufacturer.Action" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="/scripts/jquery-barcode-2.0.2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#img1").hide();
            $("#img2").hide();
            $(document.getElementById('<%=txtBarcode1Value.ClientID%>')).blur(function () {
                if ($(document.getElementById('<%=txtBarcode1Value.ClientID%>')).val() == "") {
                    $("#img1").hide();
                }
                else {
                    $("#img1").show();
                    $("#img1").attr("src", "/BarcodeHandler.ashx?code=UPCACCA&modulewidth=1&unit=px&Data=" + $(document.getElementById('<%=txtBarcode2Value.ClientID%>')).val());
                }
            });
            $(document.getElementById('<%=txtBarcode2Value.ClientID %>')).blur(function () {
                if ($(document.getElementById('<%=txtBarcode2Value.ClientID %>')).val() == "") {
                    $("#img2").hide();
                }
                else {
                    $("#img2").show();
                    $("#img2").attr("src", "/BarcodeHandler.ashx?code=RSSExpandedStacked&modulewidth=1&unit=px&Data=" + $(document.getElementById('<%=txtBarcode2Value.ClientID%>')).val());
                }
            });

        });

        var v = true;
        function validate() {

            AddRemoveError(document.getElementById('<%=txtName.ClientID %>'));
            AddRemoveError(document.getElementById('<%=imgUpload.ClientID %>'));
            AddRemoveError(document.getElementById('<%=txtValue.ClientID %>'));
            AddRemoveError(document.getElementById('<%=txtStartDate.ClientID %>'));
            AddRemoveError(document.getElementById('<%=txtExpirationDate.ClientID %>'));
            AddRemoveError(document.getElementById('<%=txtNumberOfCoupons.ClientID %>'));
            AddRemoveError(document.getElementById('<%=txtDetails.ClientID %>'));
            AddRemoveError(document.getElementById('<%=txtTerms.ClientID %>'));
            AddRemoveError(document.getElementById('<%=txtBarcode1Value.ClientID %>'));
            AddRemoveError(document.getElementById('<%=txtBarcode2Value.ClientID %>'));

            return v;
        }

        function AddRemoveError(item) {
            if ($(item).val() == "") {
                $(item).addClass("error");
                v = false;
            }
            else {
                $(item).removeClass("error");
            }

        }
    </script>

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
        function change() {
            $("#divChange").toggle();
        }
		</script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="column-center-background">
    <div class="centerColumn" id="advSearchResultsDefault">

<div id="divAddCoupon" runat="server">
        <div class="title_box">
	        <div class="row1">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><img src="/images/pixel_trans.gif" alt="" width="1" height="1" /></div>
            </div></div></div>
	        <div class="row2">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><div class="title_inner4"><div class="title_inner5"><div class="title_inner6"><div class="title_inner7">
    	            <h2 id="newProductsDefaultHeading">Add Coupon</h2>
                </div></div></div></div></div></div></div>
            </div>
        </div>
</div>
<div id="divEditCoupon" runat="server">
        <div class="title_box">
	        <div class="row1">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><img src="/images/pixel_trans.gif" alt="" width="1" height="1" /></div>
            </div></div></div>
	        <div class="row2">
    	        <div class="title_inner1"><div class="title_inner2"><div class="title_inner3"><div class="title_inner4"><div class="title_inner5"><div class="title_inner6"><div class="title_inner7">
    	            <h2 id="newProductsDefaultHeading">Edit Coupon</h2>
                </div></div></div></div></div></div></div>
            </div>
        </div>
</div>

<div>
    <asp:Label ID="lblAddSuccessfull" runat="server" CssClass="messageStackError" Text="Added coupon successfully." Visible="false" />
    <asp:Label ID="lblEditSuccessfull" runat="server" CssClass="messageStackError" Text="Updated coupon successfully." Visible="false" />
    <asp:Label ID="lblError" runat="server" CssClass="messageStackError" Text="An error has occured." Visible="false" />
</div>

<fieldset id="couponInformation" runat="server">
<legend>Coupon Information</legend>
<div class="alert forward">* Required information</div>
<br class="clearBoth" /> 
 
<label class="inputLabel">Name this coupon:</label>
<asp:TextBox ID="txtName" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
<br />
<label class="inputLabel">Category:</label>
<asp:DropDownList ID="ddlCategory" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
<br />
<label class="inputLabel">Image:</label>
<asp:FileUpload ID="imgUpload" runat="server" CssClass="tblarge" Width="400px" /><span class="alert">*</span><br class="clearBoth" />
 <br />
<label class="inputLabel" id="lblCurrent" runat="server">Current Image:</label>
<img id="imgCurrent" runat="server" />
 <br />
 <table>
 <tr><td>
<label class="inputLabel">Value:</label>
<asp:TextBox ID="txtValue" runat="server" CssClass="tbsmall" /><span class="alert">*</span><br class="clearBoth" />
 </td>
 <td width="100px"></td>
 <td>
<label class="inputLabel">Start Date:</label>
<asp:TextBox ID="txtStartDate" runat="server" CssClass="datepicker tbsmall" /><span class="alert">*</span><br class="clearBoth" />
</td> </tr></table> <br />
 <table>
 <tr><td width="219px">&nbsp;


 </td>
 <td width="100px"></td>
 <td>
<label class="inputLabel">Expiration Date:</label>
<asp:TextBox ID="txtExpirationDate" runat="server" CssClass="datepicker tbsmall" /><span class="alert">*</span><br class="clearBoth" />
 </td> </tr></table>
 <br />
<label class="inputLabel">Number of Coupons:</label>
<asp:TextBox ID="txtNumberOfCoupons" runat="server" CssClass="tbsmall" /><span class="alert">*</span><br class="clearBoth" />
 <br />
<label class="inputLabel">Details:</label>
<asp:TextBox ID="txtDetails" runat="server" CssClass="tblarge" TextMode="MultiLine" /><span class="alert">*</span><br class="clearBoth" />
 <br />
<label class="inputLabel">Terms:</label>
<asp:TextBox ID="txtTerms" runat="server" CssClass="tblarge" TextMode="MultiLine" /><span class="alert">*</span><br class="clearBoth" />
 <br />
 <hr />
 <h2>Please check all that apply:</h2><br />
 <table width="600px">
 <tr><td width="28%">
<label class="inputLabel">Gluten Free Faclility:</label>
<asp:CheckBox ID="chkGlutenFreeFacility" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td width="36%" nowrap>
<label class="inputLabel" style="width:165px">Gluten tested at less than 20PPM:</label>
<asp:CheckBox ID="chkContainGluten20PPM" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td width="36%" nowrap>
<label class="inputLabel" style="width:165px">Gluten tested at less Than 5PPM:</label>
<asp:CheckBox ID="chkLessThan5PPM" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 </tr>
 <tr><td>
<label class="inputLabel">Casein/Dairy Free:</label>
<asp:CheckBox ID="chkCaseinFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td>
<label class="inputLabel" style="width:165px">Soy Free:</label>
<asp:CheckBox ID="chkSoyFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td>
<label class="inputLabel" style="width:165px">Nut Free:</label>
<asp:CheckBox ID="chkNutFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 </tr>
 <tr>
 <td>
<label class="inputLabel">Egg Free:</label>
<asp:CheckBox ID="chkEggFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td>
<label class="inputLabel" style="width:165px">Corn Free:</label>
<asp:CheckBox ID="chkCornFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td>
<label class="inputLabel" style="width:165px">Yeast Free:</label>
<asp:CheckBox ID="chkYeastFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td> </tr></table>
 <br />
 <hr />
 <h2>Barcodes:</h2><br />
<div style="width:310px;float:left;">
<label class="inputLabellong">UPC-A Composite Symbology:</label>
<br /><br />
<asp:TextBox ID="txtBarcode1Value" runat="server" CssClass="tblarge" /><span class="alert">*</span>
<br />
<div style="padding-right:50px;float:left;height:95px;"><div id="bcTarget1"><img id="img1" /></div></div>
 </div>
<div style="width:310px;float:left;">
<label class="inputLabellong">GS1-DataBar Expanded Stacked:</label>
<br /><br />
<asp:TextBox ID="txtBarcode2Value" runat="server" CssClass="tblarge" /><span class="alert">*</span>
<br />
<div style="padding-right:50px;float:left;height:95px;"><div id="bcTarget2"><img id="img2" /></div></div>
 </div>
 <!---
<label class="inputLabel">Bottom Advertisement:</label>
<asp:TextBox ID="txtBottomAdvertisement" runat="server" CssClass="tblarge" /><span class="alert">*</span><br class="clearBoth" />
 -->
</fieldset>
<div class="buttonRow forward"><asp:ImageButton ID="btnCancel" runat="server" AlternateText="Cancel" ImageUrl="/images/buttons/english/button_cancel.gif" PostBackUrl="/Manufacturer/default.aspx" /></div>
<div class="buttonRow forward"><asp:ImageButton ID="btnSave" runat="server" AlternateText="Submit" OnClientClick="return validate();" OnClick="btnSave_Click" ImageUrl="/images/buttons/english/button_submit.gif" /></div>

    </div></div><br /><br /><br /><br />
</asp:Content>
