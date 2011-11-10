<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OnlineBarcodeDemo.aspx.cs" Inherits="OnlineBarcodeDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <title>TEC-IT Online Barcode Demo</title> 
 <style type="text/css">
 body,h1,h2,h3,td { font-family: Arial,Helvetica,sans-serif }
 td { font-size: 9pt; }
 td.td-form-bg { background-color: #f0f0f0 }
 </style>
</head>
<body style="margin: 2em">
    <form id="form1" action="BarcodeHandler.ashx" target="_blank" method="get">
    <h1>
        TBarCode Online Barcode Demo</h1>
        <p>
            <span style="font-size: 0.8em">(c) TEC-IT Datenverarbeitung GmbH - <a href="http://www.tec-it.com">
                http://www.tec-it.com</a></span><span style="font-size: 0.8em">.</span></p>
    <h3>
        Barcode Demo Form</h3>
    <p>
        The following form transmits the entered data through the GET method to the online
        generator url:</p>
    <div>
    <ul>
        <li>http:// [YourHostName] /BarcodeHandler.ashx</li>
    </ul>


    
    </div>
    <p>
        For demo purposes please leave the form as is.</p>

        <table id="Table2" cellpadding="2" border="0" cellspacing="2" width="800">
            <tr>
                <td class="td-form-bg" align="right" colspan="3" >
                    <h3 style="text-align: left">
                        Barcode Properties</h3>
                </td>
            </tr>
            <tr>
                <td class="td-form-bg" align="right" style="text-align:right; width: 150px" 
                    width="150"  >
                    Barcode type</td>
                <td class="td-form-bg"  >
                    <select style="WIDTH: 333px" name="code" id="code">
	                <optgroup label="2D und Stacked Codes">
		                <option value="Aztec">
			                Aztec
		                </option><option value="DataMatrix">
			                Data Matrix
		                </option><option value="MicroPDF417">
			                MicroPDF417
		                </option><option value="PDF417">
			                PDF417
		                </option><option value="QRCode">
			                QR Code
		                </option>
	                </optgroup>
	                <optgroup label="1D Barcodes (a selection)">
		                <option value="Code128" selected="selected">
			                Code-128
		                </option><option value="Code25IL">
			                Code-2of5 Interleaved
		                </option><option value="Code39">
			                Code-39
		                </option><option value="Code93">
			                Code-93
		                </option><option value="EAN8">
			                EAN-8
		                </option><option value="EAN13">
			                EAN-13
		                </option><option value="EANUCC128">
			                GS1-128 (UCC/EAN-128)
		                </option><option value="UPCA">
			                UPC-A
		                </option><option value="UPCE">
			                UPC-E
		                </option>
	                </optgroup>
                    <optgroup label="Postal Codes">
		                <option value="AustralianPost">
			                Australian Post Standard Customer
		                </option><option value="JapanesePostal">
			                Japanese Postal (Customer) Code
		                </option><option value="PostNet5">
			                USPS PostNet 5
		                </option><option value="PostNet9">
			                USPS PostNet 9
		                </option><option value="PostNet11">
			                USPS PostNet 11
		                </option><option value="USPSOneCode">
			                USPS OneCode 4-State Customer Barcode
		                </option>
	                </optgroup>
                    <optgroup label="GS1-DataBar Symbology (RSS Codes)">
		                <option value="RSS14">
			                GS1-DataBar
		                </option><option value="RSS14Stacked">
			                GS1-DataBar Stacked
		                </option><option value="RSS14StackedOmni">
			                GS1-DataBar Stacked Omni
		                </option><option value="RSSLimited">
			                GS1-DataBar Limited
		                </option><option value="RSSExpanded">
			                GS1-DataBar Expanded
		                </option><option value="RSSExpandedStacked">
			                GS1-DataBar Expanded Stacked
		                </option>
	                </optgroup>
                    <optgroup label="EAN.UCC Composite Symbology">
		                <option value="EAN8CCA">
			                EAN-8 Composite Symbology
		                </option><option value="EAN13CCA">
			                EAN-13 Composite Symbology
		                </option><option value="GS1-128CCA">
			                GS1-128 Composite Symbology
		                </option><option value="RSS14CCA">
			                GS1-DataBar Composite
		                </option><option value="RSS14StackedCCA">
			                GS1-DataBar Stacked Composite
		                </option><option value="RSS14StackedOmniCCA">
			                GS1-DataBar Stacked Omni Composite
		                </option><option value="RSSLimitedCCA">
			                GS1-DataBar Limited Composite
		                </option><option value="RSSExpandedCCA">
			                GS1-DataBar Expanded Composite
		                </option><option value="RSSExpandedStackedCCA">
			                GS1-DataBar Expanded Stacked Composite
		                </option><option value="UPCACCA">
			                UPC-A Composite Symbology
		                </option><option value="UPCECCA">
			                UPC-E Composite Symbology
		                </option>
	                </optgroup>
                </select>
                </td>
                <td class="td-form-bg" style="font-size: 0.8em;" nowrap="NoWrap" width="250">
                    Parameter "&amp;code=..."</td>
            </tr>
            <tr>
                <td class="td-form-bg" align="right" style="width: 162px"  >
                    Module width</td>
                <td class="td-form-bg"  >
                    <input name="modulewidth" style="WIDTH: 200px" maxlength="25" value="" /> 
                    <select name="unit" style="width: 123px">
	                <option value="fit" selected="selected">
		                Fit (Auto)
	                </option><option value="min">
		                Minimal
	                </option><option value="mm">
		                [mm]
	                </option><option value="mils">
		                [mils]
	                </option><option value="px">
		                [Pixel]
	                </option>
                    </select> 
                </td>
                <td class="td-form-bg" style="font-size: 0.8em; " nowrap="NoWrap" width="250">
                    Parameter "&amp;modulewidth=..."<br />
                    Parameter "&amp;unit=..."</td>
            </tr>
            <tr>
                <td class="td-form-bg" align="right" style="width: 162px"  >
                    Rotation</td>
                <td class="td-form-bg"  >
                <select name="rotation" style="width: 123px">
	            <option value="0" selected="selected">
		            0&#176;
	            </option><option value="90">
		            90&#176;
	            </option><option value="180">
		            180&#176;
	            </option><option value="270">
		            270&#176;
	            </option>
                </select>
                </td>
                <td class="td-form-bg" style="font-size: 0.8em; " nowrap="NoWrap" width="250">
                    Parameter "&amp;rotation=..."</td>
            </tr>
            <tr>
                <td class="td-form-bg" colspan="3" style="width: 800px">
                    <h3 style="text-align: left">
                        Data to be encoded</h3>
                </td>
            </tr>
            <tr>
                <td class="td-form-bg" align="right" >
                    Data</td>
                <td class="td-form-bg"  >
                    <input style="WIDTH: 333px" maxlength="255" name="Data" value="1234567890"/>
                </td>
                <td class="td-form-bg" style="font-size: 0.8em; " nowrap="NoWrap" width="250">
                    Parameter "&amp;data=..."</td>
            </tr>
	<tr>
		<td colspan="3" style="font-size: 0.9em">
            <p style="margin: 0.66em 0 0.66em 0">
            When you click [Generate Barcode], the entered data will be sent to <strong>BarcodeHandler.ashx</strong>
                (Online Barcode Generator).
            The bar code will be generated and sent back to the browser as image (bitmap). For this a new browser windows opens.
            In case of an error an image containing the error message will be generated instead of the barcode.</p>
        </td>
	</tr>
	<tr style="font-size: 10pt">
		<td colspan="3" >
		<input type="submit" value="Generate Barcode"/> 
		</td>
	</tr>
</table>
    <h3>
        Implementation Into Your Application</h3>
    <p>
        The barcode will be generated as image data stream in GIF format and sent to the
        browser or your application.<br />
        Integration into your Html documents can be done through the Html
        Image
        Tag - as
        follows:</p>
            <p><span style="color: blue"><strong>&lt;img</strong><span style="color: black; background-color: white;"> src="<span style="background-color: #ccffff"><span>BarcodeHandler.ashx</span>?<span><span></span><span>code=EAN13<span>&amp;</span></span><span>data=978020137962<span>&amp;</span></span><span>dpi=96<span>&amp;</span></span><span>modulewidth=2<span>&amp;</span></span><span>unit=px</span></span></span>"</span><span style="color: blue"><strong>&gt;</strong></span></span></p>
        <p><img alt="Barcode Image" src="BarcodeHandler.ashx?code=EAN13&data=978020137962&dpi=96&rotation=0&modulewidth=2&unit=px" />
            <strong><span style="color: blue"></span></strong>&nbsp;</p>
        <h3>
            Supported Get Parameters</h3>
    <p> The following GET parameters will be recognized by the Online Barcode Generator:</p>
        <p>
            <strong><span style="color: #0000cd; font-family: Courier New"></span></strong></p>
            <table cellpadding="1" cellspacing="1" border="0">
                <tr>
                    <td style="height: 19px; background-color: #ccffff" colspan="2">
                        <strong><span style="color: #0000cd;">http:// [Your Hostname] /BarcodeHandler.ashx?</span></strong></td>
                </tr>
                <tr>
                    <td style="width: 250px; background-color: #ccffff; color: mediumblue;">
                        &amp;code=BarcodeType</td>
                    <td style="width: 250px; height: 19px; background-color: #ccffff">
                        Code39, Code128...</td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 22px; background-color: #ccffff; color: mediumblue;">
                        &amp;data=DataToEncode</td>
                    <td style="width: 250px; height: 22px; background-color: #ccffff">
                        Barcode Data&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 250px; color: mediumblue;">
                        &amp;dpi=DPI</td>
                    <td style="width: 250px; height: 19px">
                        Default: 96 dpi</td>
                </tr>
                <tr>
                    <td style="width: 250px; color: mediumblue;">
                        &amp;modulewidth=ModuleWidth</td>
                    <td style="width: 250px">
                        modulewidth=fit|min|[value]</td>
                </tr>
                <tr>
                    <td style="width: 250px; color: mediumblue;">
                        &amp;unit=Unit</td>
                    <td style="width: 250px">
                        unit=mm|px|mils</td>
                </tr>
                <tr>
                    <td style="width: 250px; color: mediumblue;">
                        &amp;height=Height</td>
                    <td style="width: 250px">
                        optional: height (&amp;unit=..)
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; color: mediumblue;">
                        &amp;width=Width</td>
                    <td style="width: 250px">
                        optional: width&nbsp; (&amp;unit=..)</td>
                </tr>
                <tr>
                    <td style="width: 250px; color: mediumblue;">
                        &amp;translate-esc=on|off</td>
                    <td style="width: 250px">
                        on: \F =&gt; FNC1</td>
                </tr>
                <tr>
                    <td style="width: 250px; color: mediumblue;">
                        &amp;printdatatext=true|false</td>
                    <td style="width: 250px">
                        optional: enable/disable HRT</td>
                </tr>
                <tr>
                    <td style="width: 250px; color: mediumblue;">
                        &amp;hrt=HumanReadableText</td>
                    <td style="width: 250px">
                        optional: set HRT</td>
                </tr>
                <tr>
                    <td style="width: 250px; color: mediumblue;">
                        &amp;composite</td>
                    <td style="width: 250px">
                        optional: composite=auto|cca|ccb|ccc</td>
                </tr>
                <tr>
                    <td style="width: 250px; color: mediumblue;">
                        &amp;rotation=degree</td>
                    <td style="width: 250px">
                        optional: rotation=0|90|180|270</td>
                </tr>
                <tr>
                    <td style="width: 250px; color: mediumblue;">
                        &amp;scalex=HorizontalScaling</td>
                    <td style="width: 250px">
                        optional: scalex=1,2,3...</td>
                </tr>
                <tr>
                    <td style="width: 250px; color: mediumblue;">
                        &amp;scaley=VerticalScaling</td>
                    <td style="width: 250px">
                        optional: scaley=1,2,3...</td>
                </tr>
                <tr>
                    <td style="width: 250px; color: mediumblue">
                        &amp;format=BitmapFormat</td>
                    <td style="width: 250px">
                        optional: format=gif|jpg</td>
                </tr>
            </table>
    </form>
</body>
</html>
