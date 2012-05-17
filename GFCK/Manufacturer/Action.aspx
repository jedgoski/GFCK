<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Manufacturer.Master" CodeBehind="Action.aspx.cs" Inherits="GFCK.Manufacturer.Action" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#img1").hide();
            $("#img2").hide();
            ShowBarcode1();
            ShowBarcode2();
            $(document.getElementById('<%=txtBarcode1Value.ClientID%>')).blur(function () {
                ShowBarcode1();
            });
            $(document.getElementById('<%=txtBarcode2Value.ClientID %>')).blur(function () {
                ShowBarcode2();
            });

        });

        function ShowBarcode1() {
            if ($(document.getElementById('<%=txtBarcode1Value.ClientID%>')).val() == "") {
                $("#img1").hide();
            }
            else {
                $("#img1").show();
                $("#img1").attr("src", "http://www.tec-it.com/aspx/service/tbarcode/barcode.ashx?accesskey=demo&code=UPCA&modulewidth=min&Data=" + $(document.getElementById('<%=txtBarcode1Value.ClientID%>')).val());
            }
        }

        function ShowBarcode2() {
            if ($(document.getElementById('<%=txtBarcode2Value.ClientID %>')).val() == "") {
                $("#img2").hide();
            }
            else {
                $("#img2").show();
                $("#img2").attr("src", "http://www.tec-it.com/aspx/service/tbarcode/barcode.ashx?accesskey=demo&code=RSSExpandedStacked&modulewidth=min&Data=" + $(document.getElementById('<%=txtBarcode2Value.ClientID%>')).val());
            }
        }


        var v = true;
        function validate() {

            AddRemoveError(document.getElementById('<%=txtValue.ClientID %>'));
            AddRemoveError(document.getElementById('<%=txtName.ClientID %>'));
            AddRemoveError(document.getElementById('<%=txtDetails.ClientID %>'));
            AddRemoveErrorImage(document.getElementById('<%=imgUpload.ClientID %>'));
            AddRemoveError(document.getElementById('<%=txtStartDate.ClientID %>'));
            AddRemoveError(document.getElementById('<%=txtExpirationDate.ClientID %>'));
            AddRemoveError(document.getElementById('<%=txtNumberOfCoupons.ClientID %>'));
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
        function AddRemoveErrorImage(item) {
            if ($(item).val() == "" && document.getElementById('<%=imgCurrent.ClientID %>').src == "") {
                $(item).addClass("error");
                v = false;
            }
            else if (!checkFile()) {
                $(item).addClass("error");
                v = false;
            }
            else {
                $(item).removeClass("error");
                v = true;
            }
            return v;
        }
        function checkFile() {
            var fileElement = document.getElementById('<%= imgUpload.ClientID %>');

            //if they aren't uploading and image, but already have one, return true.
            if ($(fileElement).val() == "" && document.getElementById('<%=imgCurrent.ClientID %>').src != "") {
                return true;
            }

            //otherwise, make sure the new image is of type image.
            var fileExtension = "";
            if (fileElement.value.lastIndexOf(".") > 0) {
                fileExtension = fileElement.value.substring(fileElement.value.lastIndexOf(".") + 1, fileElement.value.length);
            }
            if (fileExtension == "gif" || fileExtension == "jpg" || fileExtension == "jpeg" || fileExtension == "png") {
                return true;
            }
            else {
                alert("You must select an image file for upload");
                return false;
            }
        }

        function RestrictSize(x, len) {
            if (x.value.length > len) {
                x.value = x.value.subString(0, len);
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

        <style type="text/css">
        label.inputLabel
        {
            width:12em;
            padding-right:5px;
        }
        </style>

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
 
<label class="inputLabel">Coupon Amount:<span class="alert">*</span></label>
<asp:TextBox ID="txtValue" runat="server" CssClass="tbsmall" Width="250px" onkeyup="RestrictSize(this, 50);" /><span class="alert">(50 characters max)</span><br class="clearBoth" /><br />
<label class="inputLabel">Product Description:<span class="alert">*</span></label>
<asp:TextBox ID="txtName" runat="server" CssClass="tblarge" MaxLength="100" onkeyup="RestrictSize(this, 100);" Width="350px" /><span class="alert">(100 characters max)</span><br class="clearBoth" /><br />
<label class="inputLabel">Additional Product Info: <span class="alert" style="margin-right:0px;">*</span> <font class="alert" style="margin-right:0px;">(not displayed on coupon)</font></label>
<asp:TextBox ID="txtDetails" runat="server" CssClass="tblarge" TextMode="MultiLine" Rows="4" Columns="50" /><br class="clearBoth" />
 <br />
 <label class="inputLabel">Category:<span class="alert">*</span></label>
<asp:DropDownList ID="ddlCategory" runat="server" CssClass="tblarge" /><br class="clearBoth" />
<br />
<label class="inputLabel">Image:<span class="alert">*</span></label>
<asp:FileUpload ID="imgUpload" runat="server" CssClass="tblarge" Width="400px" /><br class="clearBoth" />
<label class="inputLabel" style="width:400px"><span class="alert">Recommended file dimmensions are 250px high by 190px wide.</span><br /><span class="alert">Maximum file size is 5MB.</span></label>
<br class="clearBoth" />
<label class="inputLabel" id="lblCurrent" runat="server">Current Image:</label>
<img id="imgCurrent" runat="server" style="max-height:250px;" />
 <br />
 <table>
<tr><td colspan="3">&nbsp;</td></tr>
 <tr><td width="219px">
<label class="inputLabel">Start Date:<span class="alert">*</span></label>
<asp:TextBox ID="txtStartDate" runat="server" CssClass="datepicker tbsmall" /><br class="clearBoth" />


 </td>
 <td width="100px">&nbsp;</td>
 <td>
<label class="inputLabel">Expiration Date:<span class="alert">*</span></label>
<asp:TextBox ID="txtExpirationDate" runat="server" CssClass="datepicker tbsmall" /><br class="clearBoth" />
 </td> </tr></table>
 <br />
<label class="inputLabel">Number of Coupons:<span class="alert">*</span></label>
<asp:TextBox ID="txtNumberOfCoupons" runat="server" CssClass="tbsmall" /><br class="clearBoth" />
 <br />
<label class="inputLabel">Terms and Redemption:<span class="alert">*</span></label>
<asp:TextBox ID="txtTerms" runat="server" CssClass="tblarge" TextMode="MultiLine" Rows="4" Columns="50" /><br class="clearBoth" />
<input type="hidden" id="txtEnabled" runat="server" value="false" />
 <br />
<label class="inputLabel">Marketing Image:</label>
<asp:FileUpload ID="imgUploadMarketing" runat="server" CssClass="tblarge" Width="400px" /><br class="clearBoth" />
<label class="inputLabel" style="width:400px"><span class="alert">Recommended file dimmensions are 7" tall by 7" wide or smaller.</span><br /><span class="alert">Maximum file size is 10MB.</span></label>
<br class="clearBoth" />
<label class="inputLabel" id="lblCurrentMarketing" runat="server">Current Marketing Image:</label>
<asp:Literal ID="litImageMarketing" runat="server" /><br class="clearBoth" />
 <br />
 <hr />
 <h2>Please check all that apply:</h2><br />
 <table width="600px">
 <tr><td width="45%">
<label class="inputLabel1" style="width:185px">Gluten Free Faclility:</label>
<asp:CheckBox ID="chkGlutenFreeFacility" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td width="35%" nowrap>
<label class="inputLabel1">Casein/Dairy Free:</label>
<asp:CheckBox ID="chkCaseinFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td width="20%" nowrap>
<label class="inputLabel1">Egg Free:</label>
<asp:CheckBox ID="chkEggFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 </tr>
 <tr><td>
<label class="inputLabel1" style="width:185px">Gluten tested at less than 20PPM:</label>
<asp:CheckBox ID="chkContainGluten20PPM" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td>
<label class="inputLabel1">Soy Free:</label>
<asp:CheckBox ID="chkSoyFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td>
<label class="inputLabel1">Nut Free:</label>
<asp:CheckBox ID="chkNutFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 </tr>
 <tr>
 <td>
<label class="inputLabel1" style="width:185px">Gluten tested at less than 10PPM:</label>
<asp:CheckBox ID="chkLessThan10PPM" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td>
<label class="inputLabel1">Corn Free:</label>
<asp:CheckBox ID="chkCornFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td>
<label class="inputLabel1">Yeast Free:</label>
<asp:CheckBox ID="chkYeastFree" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td> </tr>
 <tr>
 <td>
<label class="inputLabel1" style="width:185px">Gluten tested at less than 5PPM:</label>
<asp:CheckBox ID="chkLessThan5PPM" runat="server" CssClass="tblarge" /><br class="clearBoth" />
 </td>
 <td>&nbsp;
 </td>
 <td>&nbsp;
 </td> </tr></table>
 <br />
 <hr />
 <h2>Barcodes:</h2><br />
<div style="width:310px;float:left;">
<label class="inputLabellong">UPC-A Composite Symbology:<span class="alert">*</span></label>
<br /><br />
<asp:TextBox ID="txtBarcode1Value" runat="server" CssClass="tblarge" />
<br />
<div style="padding-right:50px;float:left;height:95px;"><div id="bcTarget1"><img id="img1" /></div></div>
 </div>
<div style="width:310px;float:left;">
<label class="inputLabellong">GS1-DataBar Expanded Stacked:<span class="alert">*</span></label>
<br /><br />
<asp:TextBox ID="txtBarcode2Value" runat="server" CssClass="tblarge" />
<br />
<div style="padding-right:50px;float:left;height:95px;"><div id="bcTarget2"><img id="img2" /></div></div>
 </div>
</fieldset>
<div class="buttonRow forward"><asp:ImageButton ID="btnCancel" runat="server" AlternateText="Cancel" ImageUrl="/images/buttons/english/button_cancel.gif" PostBackUrl="/Manufacturer/default.aspx" /></div>
<div class="buttonRow forward"><asp:ImageButton ID="btnSave" runat="server" AlternateText="Submit" OnClientClick="return validate();" OnClick="btnSave_Click" ImageUrl="/images/buttons/english/button_submit.gif" /></div>

    </div></div><br /><br /><br /><br />
</asp:Content>
