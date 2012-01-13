<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="GFCK.UserControls.Search" %>
<script type="text/javascript">
    function addSearchItem() {
        if ($("#txtSearch").val() != "Enter search keywords here") {
            window.location = "/default.aspx?search=" + $("#txtSearch").val();
        }
    }
</script>
<div class="col1">
    <div class="indent">
        <div class="col1">
            <div class="inn1">
                <div class="inn2">
                    <div class="inn3">
                        <div class="inn4">
                            <input type="hidden" name="main_page" value="advanced_search_result" /><input type="hidden"
                                name="search_in_description" value="1" /><input id="txtSearch" type="text" name="keyword" size="6"
                                    maxlength="30" class="input_search" value="Enter search keywords here" onfocus="if (this.value == 'Enter search keywords here') this.value = '';"
                                    onblur="if (this.value == '') this.value = 'Enter search keywords here';" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col2">
            <div style="padding-left: 4px;">
                <img src="/images/pixel_trans.gif" alt="" width="1" height="1" /><br />
                <input type="image" src="/images/buttons/english/b_search.gif" alt="Search" title=" Search " onclick="addSearchItem(); return false;" /><br />
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</div>
<div class="clear">
</div>