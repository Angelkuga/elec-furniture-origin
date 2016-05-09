<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createbrand.aspx.cs"  MasterPageFile="../Member.Master"  Inherits="TREC.Web.Suppler.brand.createbrand" %>
<%@ Import Namespace="TREC.ECommerce" %><%@ Import Namespace="TREC.Entity" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href=<%="\""+TREC.ECommerce.ECommon.WebSupplerResourceUrl%>/altdialog/skins/default.css" />
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.inputlabel.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/altdialog/artDialog.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/altdialog/plugins/iframeTools.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/fileupload.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="../script/formValidator-4.1.1.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../script/formValidatorRegex.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../script/supplercommon.js"></script>
    <script type="text/javascript" src="../script/pageValitator/dealeraddbrand.js"></script>
   <!--控制搜索厂商的CSS-->
    <style type="text/css">
        #the_one{display: none; position: absolute; list-style-type: none; margin: 0pt; padding: 0pt; border: 1px solid rgb(225, 43, 41); overflow: auto; background-color: rgb(255, 255, 255); z-index: 10010; max-height: 200px; width: 166px;}
        .li_Calss{padding: 2px 0px 2px 5px; height: 16px; line-height: 16px; cursor: pointer; overflow: hidden; position: relative; color: rgb(102, 102, 102);}
        .li_Calss:hover{background-color: rgb(250, 143, 92);}
        #ul_Id {margin: 0pt; padding: 0pt;  position: relative;  border: 5px solid rgb(248, 241, 207);};
    </style>
</head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <table class="formTable" style="display:none;">
                <tr>
                    <th colspan="2">&nbsp;&nbsp;工厂信息：</th>
                </tr>
                <tr>
                    <td align="right" width="90">厂家名称：</td>
                    <td><asp:TextBox ID="txtcompanytitlesss" runat="server" CssClass="input required"></asp:TextBox>
                        <div id="txtcompanytitleTipss"  style="width:280px; float:left" class="forTip" ></div> 
                    </td>
                </tr>
                <tr>
                    <td align="right">联系人：</td>
                    <td><asp:TextBox ID="txtclinkman" runat="server" CssClass="input required"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">联系电话：</td>
                    <td><asp:TextBox ID="txtcphone" runat="server" CssClass="input"></asp:TextBox>
                        <div id="txtcphoneTip"  style="width:280px; float:left" class="forTip" ></div> 
                    
                    </td>
                </tr>
                <tr>
                    <td align="right">厂家介绍：</td>
                    <td><asp:TextBox ID="txtcdescript" runat="server" CssClass="textarea" TextMode="MultiLine" Height="80px" Width="500"></asp:TextBox></td>
                </tr>
            </table>
            <div class="clear"></div>
            <table class="formTable">
                <tr>
                    <th colspan="2">&nbsp;&nbsp;品牌/工厂信息：<asp:HiddenField ID="hfcompanyid" runat="server" /></th>
                </tr>
                 <tr>
                    <td align="right" width="110">厂商名称：</td>
                    <td><asp:TextBox ID="txtcompanytitle" runat="server" CssClass="input required"></asp:TextBox>
                        <div id="txtcompanytitleTip"  style="width:280px; float:left" class="forTip" ></div> 
                        <br /><br />
                        <div id="the_one">
                            <ul id="ul_Id">
                            </ul>
                        </div>
                        <script type="text/javascript">
                            $(".li_Calss").live("click", function () {
                                $("#txtcompanytitle").val($.trim($(this).html()));
                                $("#txtcompanytitle").focus();
                                hidethe_one();
                            });
                            $('html,body').live("click",function () {                                
                                hidethe_one();
                            });
                            function hidethe_one() {
                                $("#the_one").hide();
                            }
                            $("#txtcompanytitle").keyup(function () {
                                var txtval = $.trim($(this).val());
                                if (txtval == "") {
                                    hidethe_one();
                                    return;
                                }
                                $.ajax({
                                    url: "<%=ECommon.WebSupplerUrl %>/ajax/search.ashx",
                                    data: "type=company&key=" + txtval,
                                    dataType: "text",
                                    success: function (data) {
                                        if (data != "") {
                                            $("#the_one").show();
                                            $("#ul_Id").html("");
                                            $("#ul_Id").html(data);
                                        }
                                        else {
                                            hidethe_one();
                                        }
                                    }
                                })
                            });
                        </script>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="70">品牌名称：</td>
                    <td><asp:TextBox ID="txtbrandtitle" runat="server" CssClass="input required"></asp:TextBox>
                        <div id="txtbrandtitleTip"  style="width:280px; float:left" class="forTip" ></div>
                    </td>
                </tr>
                <tr>
                    <td align="right">品牌索引：</td>
                    <td><asp:TextBox ID="txtbrandletter" runat="server" CssClass="input required"></asp:TextBox>
                        <div id="txtbrandletterTip"  style="width:280px; float:left" class="forTip" ></div> 
                        <label>(请填写品牌全称的首字母)</label>
                    </td>
                </tr>
                <tr>
                    <td align="right">品牌商标或Logo：</td>
                    <td>
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Brand, ECommon.QueryId, TREC.Entity.EnFilePath.Logo)%>">
                            <asp:HiddenField ID="hfbrandlogo" runat="server"  />
                            <div class="fileTools" style="width:310px">
                                <input type="text" class="input w160 filedisplay" />
                                <a href="javascript:;" class="files"><input id="File2"  type="file" class="upload" onchange="_upfile(this,'0')"  runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div><label>(尺寸为：宽196 * 高70像素)</label>
                        </div>
                        
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" style="width:200px">
                        品牌Logo：<a href="javascript:;" class="helper" title="点击查看图片位置示意"><img src="../images/d8.gif"/></a>
                    </td>
                    <td>
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Brand, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
                            <asp:HiddenField ID="hfthumb" runat="server" />
                            <div class="fileTools" style="width:310px;">
                                <input type="text" class="input w160 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File1" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div><label>(高550×410像素)</label>
                        </div>
                    </td>
                </tr>
                <%--<tr style="display:none;">
                    <td align="right">风格/材质：</td>
                    <td>
                        <asp:DropDownList ID="ddlstyle" runat="server" CssClass="select"></asp:DropDownList>
                        <asp:DropDownList ID="ddlmaterial" runat="server" CssClass="select"></asp:DropDownList>
                        <asp:DropDownList ID="ddlspread" runat="server" CssClass="select"></asp:DropDownList>
                        <asp:DropDownList ID="ddlcolor" runat="server" CssClass="select"></asp:DropDownList>
                        <script type="text/javascript">
                            $(function () {
                                $("#btnSave").click(function () {
                                    if ($("#ddlstyle").val() == "" || $("#ddlmaterial").val() == "" || $("#ddlspread").val() == "" || $("#ddlcolor").val() == "") {
                                        alert("品牌风格/材质/价位/色系 不能为空");
                                        return false;
                                    }

                                })
                            })
                        </script>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        品牌档位：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlspread" runat="server" CssClass="select selectNone" Width="160">
                        </asp:DropDownList>
                        <div id="ddlspreadTip"  style="width:280px; float:left" class="forTip" ></div> 
                    </td>
                </tr>
                <tr>
                    <td align="right">品牌介绍：</td>
                    <td><asp:TextBox ID="txtbranddescript" runat="server"  CssClass="textarea" TextMode="MultiLine" Height="80px" Width="500"></asp:TextBox></td>
                </tr>
            </table>

    <div style="margin-top:10px; margin-left:180px">
  <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
            onclick="btnSave_Click" /><input name="重置" type="reset" class="submit" value="重置" />
</div>
</asp:Content>