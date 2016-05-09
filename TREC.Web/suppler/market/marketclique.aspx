<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true"
    CodeBehind="marketclique.aspx.cs" Inherits="TREC.Web.Suppler.market.marketclique" %>

<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Import Namespace="TREC.ECommerce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../resource/css/ymPrompt/simple_gray/ymPrompt.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/Aliyunfileupload.js"></script>
    <script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/')%>/script/ymPrompt.js" type="text/javascript"></script>
    <style>
        .txtinput
        {
            width: 400px;
        }
        .marketlist
        {
            width: 200px;
            float: left;
        }
        .tip
        {
            color: Red;
            font-weight: bold;
        }
    </style>
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
				'insertunorderedlist', '|', 'link', 'image', 'fullscreen']
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maintitle">
        <h1>
            <u>集团信息：<asp:HiddenField ID="hidId" runat="server" />
            </u>
        </h1>
    </div>
    <table width="100%" border="0" cellpadding="3" cellspacing="3">
        <tr>
            <td align="right" onclick="testkk()">
                集团名称：
            </td>
            <td align="left">
            <div style="float:left;width:160px;">
                <asp:TextBox ID="txttitle" runat="server" CssClass="input required w250" onblur="MarketCliqueCheck()"></asp:TextBox>
                </div>
                <div style="float:left;" id="divmarketmsg"></div>
                <span class="tip">*</span>
            </td>
        </tr>
        <tr style="display:<%=checkdisplay %>">
            <td align="right" width="12%">
                董事长姓名：
            </td>
            <td align="left">
                <asp:TextBox ID="txtchairman" runat="server" CssClass="input required w250"></asp:TextBox><span class="tip">*</span>
            </td>
        </tr>
        <tr>
            <td align="right" width="12%">
                电话：
            </td>
            <td align="left">
                <asp:TextBox ID="txt_phone" runat="server" CssClass="input required w250" MaxLength="15"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="12%">
                地址：
            </td>
            <td align="left">
                <asp:TextBox ID="txt_address" runat="server" CssClass="input required w250"  MaxLength="100"
                    Width="498px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display:<%=checkdisplay %>">
            <td align="right">
                董事长致辞：
            </td>
           <td align="left">
                <asp:TextBox ID="txtchairmanoration" Style="width: 500px;" runat="server" CssClass="txtinput input required w250"></asp:TextBox><span class="tip">*</span>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                集团介绍：
            </td>
            <td align="left" id="tddescriptv">
                <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea required kinkeditor"
                    TextMode="MultiLine" Rows="5" Width="500" Height="220"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="right">
                集团Log图片：
            </td>
            <td align="left">
                <div class="fileUpload" path="">
                    <asp:HiddenField ID="hidelogimg" runat="server" />
                    <div class="fileTools" style="width: 310px">
                        <input type="text" class="input w250 filedisplay"  id="mklogimg"/>
                        <a href="javascript:;" class="files">
                            <input id="File4" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>
                </div>
                (建议图片尺寸为：宽200 * 高72像素)
            </td>
        </tr>
        <tr style="display:<%=checkdisplay %>">
            <td align="right">
                董事长照片：
            </td>
            <td align="left">
                <div class="fileUpload" path="">
                    <asp:HiddenField ID="hfchairmanimg" runat="server" />
                    <div class="fileTools" style="width: 310px">
                        <input type="text" class="input w250 filedisplay"  id="mkchairmanimg"/>
                        <a href="javascript:;" class="files">
                            <input id="File3" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>
                </div>
                (建议图片尺寸为：宽234 * 高163像素)
            </td>
        </tr>
        <tr>
            <td align="right">
                集团缩略图：
            </td>
            <td align="left">
                <div class="fileUpload" path="">
                    <asp:HiddenField ID="hfthumbimg" runat="server" />
                    <div class="fileTools" style="width: 310px">
                        <input type="text" class="input w250 filedisplay"  id="mkthumbimg"/>
                        <a href="javascript:;" class="files">
                            <input id="File1" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>
                </div>
                (建议图片尺寸为：宽259 * 高158像素)
            </td>
        </tr>
        <tr style="display:<%=checkdisplay %>">
            <td align="right" valign="top">
                集团形象大图：
            </td>
            <td align="left">
                <div class="fileUpload" path="">
                    <asp:HiddenField ID="hfinfoimg" runat="server" />
                    <div class="fileTools" style="width: 310px">
                        <input type="text" class="input w250 filedisplay"  id="mkinfoimg"/>
                        <a href="javascript:;" class="files">
                            <input id="File2" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>
                </div>
                (建议图片尺寸为：宽1200 * 高487像素)
            </td>
        </tr>
        <tr style="display:none;">
            <td align="right" rowspan="3" valign="top">
                卖场：
            </td>
            <td align="left">
                <input type="button" class="btnlitl" onclick="searchsubmarket()" style="width: 80px;"
                    value="添加卖场" />
                <asp:HiddenField ID="hfsubmarketidlist" runat="server" />
            </td>
        </tr>
        <tr style="display:none;">
            <td id="selectMarket" class="msgtableSelect" style="margin: 6px; display: none; border: 2px solid #DCDCDC">
            </td>
        </tr>
        <tr style="display:none;">
            <td align="left" >
                <a class="bome" onclick="delSeleProID()">删除</a>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;&nbsp;状态：
            </td>
             <td align="left">
                <%=auditstatus%>
            </td>
        </tr>
        <tr id="trbnt" runat="server">
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="btnl" OnClick="btnSave_Click"
                    OnClientClick="return chkForm();" />
                <input name="重置" type="reset" class="btnl" value="重置" />
                <input id="loadmarket" type="hidden" name="loadmarket" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $(function () {
            $("#loadmarket").click(function () {
                var submarketidlist = 0;
                if ($("#<%=hfsubmarketidlist.ClientID %>").val() != "")
                    submarketidlist = $("#<%=hfsubmarketidlist.ClientID %>").val();
                $.get('../ajax/MemberHandler.ashx',
                        { Action: 'searchmarketbyid',
                            IdList: submarketidlist
                        },
                         function (data) {
                             $("#selectMarket").html(data);
                             $("#selectMarket").show();
                         });
            });
            $("#loadmarket").click();
        });
        function chkForm() {
            if ($('#<%=txttitle.ClientID %>').val() == "") {
                alert('请填写集团名称！');
                $('#<%=txttitle.ClientID %>').focus();
                return false;
            }
//            if ($('#<%=txtchairman.ClientID %>').val() == "") {
//                alert('请填写董事长姓名！');
//                $('#<%=txtchairman.ClientID %>').focus();
//                return false;
//            }
//            if ($('#<%=txtchairmanoration.ClientID %>').val() == "") {
//                alert('请填写董事长致辞！');
//                $('#<%=txtchairmanoration.ClientID %>').focus();
//                return false;
//            }
            //产品描述
            var descript = $.trim($(document.getElementsByTagName('iframe')[0].contentWindow.document.body).html());
            if (descript.toString() == '' || descript == '<br>') {
                alert('请填写集团介绍！');
                return false;
            }
        }
        //删除已选择单品
        function delSeleProID() {
            if ($("#selectMarket").find("input[type=checkbox]:checked").length == 0) {
                alert("请选择要删除卖场");
                return;
            } else {
                var hiddValue = $("#<%=hfsubmarketidlist.ClientID %>");
                var nhiddValue = "";
                $("#selectMarket").find("input[type=checkbox]:checked").each(function () {
                    if (hiddValue.val().split(',').length > 0) {
                        if (hiddValue.val().indexOf($(this).val() + ",") >= 0) {
                            nhiddValue = hiddValue.val().replace($(this).val() + ",", "");
                        } else {
                            nhiddValue = hiddValue.val().replace("," + $(this).val(), "");
                        }
                    } else {
                        nhiddValue = hiddValue.val().replace($(this).val(), "");
                    }
                    $($(this).parent()).remove();
                });
                hiddValue.val(nhiddValue);
                var mySize = $('#selectMarket label').size();
                if (mySize < 1) {
                    $("#<%=hfsubmarketidlist.ClientID %>").val("");
                    $("#selectMarket").hide("slow");
                }
            }
        }
        function searchsubmarket() {
            ymPrompt.win({ message: "/suppler/market/addSubMarket.aspx", width: 600, height: 530, title: '添加子卖场', handler: function () { }, iframe: true });
        }

        function MarketCliqueCheck() {
            var title = $.trim($("#ctl00_ContentPlaceHolder1_txttitle").val());
            if ($("#ctl00_ContentPlaceHolder1_txttitle").attr("readonly") == "readonly") {
                return;
            }
            if (title == '') {
                return;
            }
            $.ajax({
                async: false, //是否异步
                url: '/Suppler/ajax/CliqueCheck.aspx?title=' + title + '&m=' + Math.random(),
                type: 'post', //post方法
                dataType: 'json', //返回json格式数据
                success: function (data) {

                    if (data.msg == "1") {
                        $("#divmarketmsg").html("集团名称可以使用");
                    }
                    else if (data.msg == "0") {
                        $("#divmarketmsg").html("<span style='color:red;'>集团名已存在，不可使用</span>");
                    }
                    else if (data.msg == "2") {
                        $("#divmarketmsg").html("集团名称可以使用");
                        $("#ctl00_ContentPlaceHolder1_txtchairman").val(data.chairman);
                        $("#ctl00_ContentPlaceHolder1_txtchairmanoration").val(data.chairmanoration);
                        $("#ctl00_ContentPlaceHolder1_txtdescript").val(data.descript);
                        $("#ctl00_ContentPlaceHolder1_hidelogimg").val(data.logimg);
                        $("#mklogimg").val(data.logimg);
                        $("#ctl00_ContentPlaceHolder1_hfchairmanimg").val(data.chairmanimg);
                        $("#mkchairmanimg").val(data.chairmanimg);
                        $("#ctl00_ContentPlaceHolder1_hfthumbimg").val(data.thumbimg);
                        $("#mkthumbimg").val(data.thumbimg);
                        $("#ctl00_ContentPlaceHolder1_hfinfoimg").val(data.infoimg);
                        $("#mkinfoimg").val(data.infoimg);
                        $("#ctl00_ContentPlaceHolder1_txt_phone").val(data.phone);
                        $("#ctl00_ContentPlaceHolder1_txt_address").val(data.address);
                        $("#tddescriptv iframe").contents().find("body").html(data.descript);
                    }

                }
            })
        }

       
        function testkk() {
          
        }
    </script>
</asp:Content>
