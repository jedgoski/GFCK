﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="home.ascx.cs" Inherits="GFCK.UserControls.Coupon.home" %>
    <div id="coupons" style="width: 49%;float:left;">
        <div class="box_head">
            <div class="innerbox1"><div class="innerbox2"><div class="innerbox3"><div class="innerbox4"><div class="innerbox5"><div class="innerbox6"><div class="innerbox7"><div class="innerbox8"><div class="innerbox9">
                <img src="/images/scissors.jpg" height="14px" alt="GFCK" />
            </div></div></div></div></div></div></div></div></div>
        </div>
        <div class="box">
            <div class="box_inner1"><div class="background-top-4"><div class="background-top-left-4"><div class="background-top-right-4"><div class="background-bottom-left-4"><div class="background-bottom-right-4"><div class="background-bottom-right-44"><div class="box-indent"><div class="box1_body">
            <div class="centerBoxContentsFeatured centeredContent back" style="width: 49%; zoom: 1;">
                <div style="margin-left: 0px; width: auto;">
                    <table style="width: 220px;" >
                        <tr>
                            <td>
                                <div class="img_box1" style="height:125px;overflow:hidden;">
		
                                    <a href="/detail.aspx" id="linkImage" runat="server" class="dialog_link">
                                        <img id="imgProduct" src="" runat="server" width="95" alt="GFCK"/></a><br />
                                </div>
                                <div style="height: 5px;"></div>
                            </td>
                            <td>
                                <div style="width: 5px;"></div>
                            </td>
                            <td style="width: 100%;">
                                <div class="product_box" style="width: auto;">
                                    <div class="product_box_addition">
                                        <div class="product_box_name">
                                            <div class="indent">
                                                <asp:Label ID="lblName" runat="server" /><br />
                                            </div>
                                        </div>
                                        <div class="product_box_price">
                                            <div class="indent">
                                                <strong>Save <asp:Literal ID="litPrice" runat='server' /></strong><br />
                                            </div>
                                        </div>
                                        <div class="text" style="width: 97%;">
                                            <asp:Literal ID="litDesc" runat="server" /><br />
                                        </div>
                                        <a id="linkSubmit" runat="server" class="dialog_link">
                                            <img src="/images/buttons/english/button_goto_prod_details.gif" alt="Go To This Product's Detailed Information"
                                                title=" Go To This Product's Detailed Information " width="55" height="19" /></a><br />
                                        
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="box_line2_spec">
                    <div class="inner">
                        <img src="/images/pixel_trans.gif" alt="" width="1" height="1" /><br />
                    </div>
                </div>
            </div>
            </div></div></div></div></div></div></div></div></div>
        </div>
    </div>