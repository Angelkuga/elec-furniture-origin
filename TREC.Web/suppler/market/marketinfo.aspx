<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Member.Master" CodeBehind="marketinfo.aspx.cs"
    Inherits="TREC.Web.Suppler.market.marketinfo" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Import Namespace="TREC.ECommerce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link rel="stylesheet" type="text/css"  href="../css/style.css" />--%>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/Aliyunfileupload.js"></script>
    <script type="text/javascript" language="javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.poshytip.min.js"></script>
    <script type="text/javascript" src="../script/formValidator-4.1.1.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../script/formValidatorRegex.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../script/supplercommon.js"></script>
    <script type="text/javascript" src="../script/pageValitator/marketinfo.js"></script>
    <script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/')%>/script/ymPrompt.js"
        type="text/javascript"></script>
    <link href="../resource/css/ymPrompt/simple_gray/ymPrompt.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('#<%=txtdescript.ClientID %>', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                     <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=market&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
				'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
				'insertunorderedlist', '|', 'emoticons', 'image', 'link', 'fullscreen']
                });
            });

            $("#ddlPro").live("change", function () {
                if ($(this).val() != "" && $(this).val() != "0") {
                    $.ajax({
                        url: "<%=ECommon.WebSupplerUrl %>/ajaxtools/ajaxarea.ashx",
                        data: "type=c&p=" + $(this).val(),
                        success: function (data) {
                            $("#ddlregcity").html(data)
                        },
                        error: function (d, m) {
                            alert(m);
                        }
                    });
                }
            })

            
        });
        function ShowHelp(imgURL,txttitle){
            ymPrompt.win({ message: "<img src='"+imgURL+"'/>", width: 650, height: 460, title: txttitle});
        }
    </script>
    <style type="text/css">
        .pop
        {
            position: absolute;
        }
        .guishudp input
        {
            margin-right: 10px;
        }
        #typeId, #MaterialId, #SeriesId
        {
            width: 72px;
        }
        .addcm
        {
            position: relative;
        }
        .wait
        {
            position: absolute;
            z-index: 100;
            background: #ccc;
            width: 94%;
            top: 0;
            height: 246px;
            line-height: 246px;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            opacity: 0.8;
            color: #000;
            font-size: 14px;
        }
        #copyproductdiv
        {
            width: 450px;
        }
        #copyproductdiv .popcon
        {
            width: 410px;
        }
        #copyproductdiv td
        {
            font-size: 13px;
            padding-left: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="3" cellspacing="3">
        <tr>
            <th colspan="2" align="left" >
                &nbsp;&nbsp;基本信息：
            </th>
        </tr>
        <% if (_marketClique != null)
           {%>
        <tr style="display:none;">
            <td align="right" width="170">
                所属集团：
            </td>
            <td align="left">
                <%
                    Response.Write(_marketClique.Title);
                    if (_marketClique.Auditstatus == 1)
                    {
                        Response.Write("   <b>已审核</b>");
                    }
                    else
                    {
                        Response.Write("   <b>待审核</b>");
                    }
                %>
            </td>
        </tr>
        <%}%>
        <tr>
            <td align="right" width="170">
                卖场名称：
            </td>
            <td align="left">
            <table>
            <tr>
            <td valign="middle"><asp:TextBox ID="txt_Clique" runat="server" placeholder="请输入集团名称" CssClass="input required w250"></asp:TextBox></td>
            <td style="width:12px;" valign="middle">+</td>
            <td valign="middle">
             <asp:TextBox ID="txt_stitle" runat="server" placeholder="请输入路名" CssClass="input required w250"></asp:TextBox>
            </td>
            <td style="width:20px;" valign="middle">店</td>
            </tr>
            </table>
               
              
               
            </td>
        </tr>
        <tr style="display:none;">
            <td align="right">
                名称索引：
            </td>
            <td align="left">
                <asp:TextBox ID="txtletter" runat="server" CssClass="input required w250"></asp:TextBox>
                <div id="txtletterTip" style="width: 280px; float: left" class="forTip">
                </div>
                <label>
                    (请填写卖场全称的首字母)</label>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                人员规格 ：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlstaffsize" runat="server" CssClass="select selectNone" Width="160">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                注册年份：
            </td>
            <td align="left">
                <asp:TextBox ID="txtregyear" runat="server" CssClass="input w250 required digits"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                注册城市：
            </td>
            <td align="left">
                
            </td>
        </tr>
        <tr>
            <td align="right">
                营业面积：
            </td>
            <td align="left">
                <asp:TextBox ID="txtcbm" runat="server" CssClass="input w250 required digits"></asp:TextBox><label>(平方米)</label>
            </td>
        </tr>
        <tr>
            <td align="right">
                咨询电话：
            </td>
            <td align="left">
                <asp:TextBox ID="txtlphone" runat="server" CssClass="input w250"></asp:TextBox>
                <div id="txtlphoneTip" style="width: 280px; float: left" class="forTip">
                </div>
            </td>
        </tr>
        <tr>
            <td align="right">
                招商电话：
            </td>
            <td align="left">
                <asp:TextBox ID="txtzphone" runat="server" CssClass="input w250"></asp:TextBox>
                <div id="txtzphoneTip" style="width: 280px; float: left" class="forTip">
                </div>
            </td>
        </tr>
        <tr>
            <td align="right">
                乘车路线：
            </td>
            <td align="left">
                <asp:TextBox ID="txtbusroute" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                营业时间：
            </td>
            <td align="left">
                <asp:TextBox ID="txthours" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                业务描述：
            </td>
            <td align="left">
                <asp:TextBox ID="txtbuy" runat="server" CssClass="w250 textarea" TextMode="MultiLine"
                    Rows="4"></asp:TextBox><label>长度不超过250字符,生产/销售/租凭业务描述</label>
            </td>
        </tr>
        <tr>
            <th colspan="2" align="left">
                &nbsp;&nbsp; 联系信息：
            </th>
        </tr>
        <tr>
            <td align="right">
                地区：
            </td>
            <td align="left">
                <div  style="float:left;">
                 <asp:DropDownList ID="ddlPro" runat="server" CssClass="select">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlregcity" runat="server" CssClass="select selectNone">
                </asp:DropDownList>
                <select name="selArea"  id="selArea" style="width:75px;">
                             <%=droparea%>
                            </select>
                </div>
                <div style="float:left;color:Red;">*</div>
            </td>
        </tr>
        <tr>
            <td align="right">
                地址：
            </td>
            <td align="left">
                <asp:TextBox ID="txtaddress" runat="server" CssClass="input w380"></asp:TextBox>
                <div id="txtaddressTip" style="width: 280px; float: left" class="forTip">
                </div>
            </td>
        </tr>
        <tr>
            <td align="right">
                联系人：
            </td>
            <td align="left">
                <asp:TextBox ID="txtlinkman" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                手机 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtmphone" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                电话 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtphone" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                传真 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtfax" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                邮箱 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtemail" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                邮编 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtpostcode" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                网址 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txthomepage" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="2" align="left">
                &nbsp;&nbsp; 图片信息:
            </th>
        </tr>
        <tr>
            <td align="right" valign="top">
                形&nbsp;象&nbsp;&nbsp;图：
            </td>
            <td>
                <div class="fileUpload" path="">
                    <asp:HiddenField ID="hfthumb" runat="server" />
                    <div class="fileTools" style="width: 310px">
                        <input type="text" class="input w250 filedisplay"  id="rethumb" name="rethumb"/>
                        <a href="javascript:;" class="files">
                            <input id="File1" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>
                    <label>
                        (请上传品牌的标志/商标/logo，尺寸为：宽1200 * 高486像素)</label>
                </div>
            </td>
        </tr>
        <tr>
            <td align="right">
                企业标志：
            </td>
            <td>
                <div class="fileUpload" path="">
                    <asp:HiddenField ID="hflogo" runat="server" />
                    <div class="fileTools" style="width: 310px">
                        <input type="text" class="input w250 filedisplay"  id="relogo" name="relogo"/>
                        <a href="javascript:;" class="files">
                            <input id="File2" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>
                    <label>
                        (请上传企业标志，尺寸为：宽200* 高72像素)</label>
                </div>
            </td>
        </tr>
        <tr>
            <td align="right">
                缩&nbsp;略&nbsp;&nbsp;图：
            </td>
            <td>
                <div class="fileUpload" path="">
                    <asp:HiddenField ID="hfsurface" runat="server" />
                    <div class="fileTools" style="width: 310px">
                        <input type="text" class="input w250 filedisplay" id="resurface" name="resurface"/>
                        <a href="javascript:;" class="files">
                            <input  id="File3" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>
                    <label>
                        (请上传缩略图，尺寸为：宽251 * 高200像素)</label>
                </div>
            </td>
        </tr>
        <tr style="display:none;">
            <td align="right" valign="top">
                集团介绍用广告幻灯：
            </td>
            <td>
                <div class="fileUpload m" path="">
                    <asp:HiddenField ID="hfbannel" runat="server" />
                    <div class="fileTools" style="width: 310px">
                        <input type="text" class="input w250 filedisplay" />
                        <a href="javascript:;" class="files">
                            <input id="File4" type="file" class="upload" onchange="_upfileiswater(this)" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>
                    <label>
                        (请上传广告幻灯，尺寸为：宽795 * 高298像素)</label>
                </div>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                企业展示：
            </td>
            <td>
                <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Market, marketInfo.id, TREC.Entity.EnFilePath.DesImage)%>">
                    <asp:HiddenField ID="hfdesimage" runat="server" />
                    <div class="fileTools" style="width: 310px">
                        <input type="text" class="input w250 filedisplay" />
                        <a href="javascript:;" class="files">
                            <input id="File5" type="file" class="upload" onchange="_upfileiswater(this)" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>
                    <label>
                        (请上传企业展示，尺寸为：宽550 * 高410像素)</label>
                </div>
            </td>
        </tr>
    </table>
    <div class="clear">
    </div>
    <table class="formTable" width="100%">
        <tr>
            <th colspan="2" align="left">
                &nbsp;&nbsp;卖场介绍:
            </th>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea required kinkeditor"
                    TextMode="MultiLine" Rows="5" Width="98%" Height="220"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="170px">
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" OnClick="btnSave_Click" />
                <input name="重置" type="reset" class="submit" value="重置" />
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
        $("#ctl00_ContentPlaceHolder1_ddlPro").live("change", function () {
            if ($(this).val() != "" && $(this).val() != "0") {
                $("#ctl00_ContentPlaceHolder1_ddlregcity").html("<option selected='selected' value='0'>--城市--</option>");
                $.ajax({
                    url: "/ajaxtools/ajaxarea.ashx",
                    data: "type=c&p=" + $(this).val(),
                    success: function (data) {
                        $("#ctl00_ContentPlaceHolder1_ddlregcity").html(data);
                        $("#selArea").html("<option selected='selected' value='0'>--区--</option>");
                    },
                    error: function (d, m) {
                        alert(m);
                    }
                });
            }
        })

        $("#ctl00_ContentPlaceHolder1_ddlregcity").live("change", function () {
            if ($(this).val() != "" && $(this).val() != "0") {
                $("#selArea").html("<option selected='selected' value='0'>--区--</option>");
                $.ajax({
                    url: "/ajaxtools/ajaxarea.ashx",
                    data: "type=c&p=" + $(this).val(),
                    success: function (data) {
                        $("#selArea").html(data);
                    },
                    error: function (d, m) {
                        alert(m);
                    }
                });
            }
        })


        function getArea(pcode, checkcode, title, id) {
            $.get("/ajax/GetArea.aspx?pcode=" + pcode + "&checkcode=" + checkcode, '', function (data, textStatus) {
                $("#" + id).html(title + data);
            }, null);
        }

        function selPArea() {
            var pid = $("#ctl00_ContentPlaceHolder1_ddlregcity").val();
            if (pid != '') {
                getArea(pid, '', '', 'selArea');
            }
            else {
                $("#selArea").html("<option selected=\"selected\" value=\"0\">--区--</option>")
            }
        }

    </script>
</asp:Content>
