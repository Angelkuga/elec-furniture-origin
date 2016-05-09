<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="marketminInfor.aspx.cs" Inherits="TREC.Web.Suppler.market.marketminInfor" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Import Namespace="TREC.ECommerce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<link rel="icon" href="/jiajukuaiso.ico" type="image/x-icon" /><link rel="shortcut icon" href="/jiajukuaiso.ico" type="image/x-icon" /><link rel="stylesheet" type="text/css" href="../css/base.css" />
    <script type="text/javascript" src="/resource/script/jquery-1.7.1.min.js"></script>
    
    <link href="../resource/css/ymPrompt/simple_gray/ymPrompt.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/Aliyunfileupload.js"></script>
    <script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/')%>/script/ymPrompt.js" type="text/javascript"></script>
    <style type="text/css">
    .dropul
    {
        background-color:#ffffff;
        width:152px;
        border-width : 1px;
	    color : #909090;
	    border-color : #959595;
	    border-style : solid;
    }
    .dropul li
    {
        padding-left:10px;
     }
    </style>

    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#uldrop li").each(function (i) { this.style.backgroundColor = ['#ccc', '#A8D1FF'][i % 2] });
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divmarketadd">
    <table width="100%;height:800px;" border="0" cellpadding="3" cellspacing="3">
        <tr>
            <th colspan="2" align="left">
                &nbsp;&nbsp;基本信息：
            </th>
        </tr>
        <tr>
            <td align="right" width="170">
                卖场名称：
            </td>
            <td align="left">
              <table>
              <tr>
              <td valign="middle"><asp:TextBox ID="txt_Clique" runat="server" placeholder="请输入集团名称" CssClass="input required w250" ReadOnly="true"></asp:TextBox></td>
              <td style="width:12px;" valign="middle">+</td>
              <td valign="middle">
              <asp:TextBox ID="txt_stitle" runat="server" placeholder="请输入卖场名称" CssClass="input required w250"  onblur="checkmarket()"></asp:TextBox>
              </td>
              <td style="width:20px;">店</td>
              <td valign="middle">
              <div style="float:left;width:100px;color:Red;display:none;" id="divmarketmsg">卖场已经存在</div>
              </td>
              </tr> 
              
              </table>
                <div style="position:relative;display:none;" id="divdropmarket"> 
                <div style="position:absolute;">
                   <ul class="dropul" id="uldrop">
                   <%=dropMarket%>
                   </ul>
                </div>
                </div>
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
        <tr >
            <td align="right">
                注册城市：
            </td>
            <td align="left">
            <div style="float:left;">
                <asp:DropDownList ID="ddlPro" runat="server" CssClass="select">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlregcity" runat="server" CssClass="select selectNone" >
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
                    <asp:HiddenField ID="hfthumb" runat="server"  />
                    <div class="fileTools" style="width: 310px">
                        <input type="text" class="input w250 filedisplay" />
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
                        <input type="text" class="input w250 filedisplay" />
                        <a href="javascript:;" class="files">
                            <input id="File2" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>
                    <label>
                        (请上传企业标志，尺寸为：宽200 * 高72像素)</label>
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
                        <input type="text" class="input w250 filedisplay" />
                        <a href="javascript:;" class="files">
                            <input id="File3" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server"  /></a>
                        <span class="uploading">上传中</span>
                    </div>
                    <label>
                        (请上传缩略图，尺寸为：宽215 * 高200像素)</label>
                </div>
            </td>
        </tr>
    </table>
    <div>
    <center>
    <table style="width:200px;"><tr><td id="tdbntsave" > <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" OnClick="btnSave_Click"  OnClientClick="checkempty(event)"/></td>
    <td>
     <input name="重置" type="reset" class="submit" value="重置" />
    </td>
    </tr> </table>
    </center>
    </div>
    </div>
    
    <div class="clear">
    </div>

    <script type="text/javascript" language="javascript">
        function changeuldrop() {
            var title = $.trim($("#ctl00_ContentPlaceHolder1_txttitle").val());
            if (title == '') {
                $("#divdropmarket").hide();
            }
            else {
                $("#divdropmarket").show();
                $("#uldrop li").hide();
                var i = 0;
                $("#uldrop li").each(
            function (i) {
                if ($(this).html().indexOf(title) > -1) {
                    $(this).show();
                }
            }
            );
            }
    }

    $("#uldrop li").click(
    function (i) {
        $("#ctl00_ContentPlaceHolder1_txttitle").val($(this).html());
        $("#divdropmarket").hide();
    }
    );
    //验证卖场是否存在
    function checkmarket() {
        var title = $.trim($("#ctl00_ContentPlaceHolder1_txt_Clique").val()) + $.trim($("#ctl00_ContentPlaceHolder1_txt_stitle").val());
        $("#divmarketmsg").hide();
        $("#tdbntsave").show();
        if($.trim($("#ctl00_ContentPlaceHolder1_txt_stitle").val())!='')
        {
        $("#uldrop li").each(
            function (i) {
                if ($(this).html() == title) {
                    $("#divmarketmsg").show();
                    $("#tdbntsave").hide();
                }

            }
            )
            }
        }
        $("#ctl00_ContentPlaceHolder1_ddlPro").live("change", function () {
            if ($(this).val() != "" && $(this).val() != "0") {
                $("#ctl00_ContentPlaceHolder1_ddlregcity").html("<option selected='selected' value='0'>--区--</option>");
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

    function checkempty(e) {
        if ($.trim($("#ctl00_ContentPlaceHolder1_txt_Clique").val()) == '') {
            alert('卖场名称不能为空');
           if(document.all){ e.returnValue=false;}else { e.preventDefault(); }
            return;
        }
//        if ($.trim($("#ctl00_ContentPlaceHolder1_txtletter").val()) == '') {
//            alert('名称索引不能为空');
//            if (document.all) { e.returnValue = false; } else { e.preventDefault(); }
//            return;
//        }
        if ($("#selArea").val() == '0') {
            alert('请选择正确的地区');
            if (document.all) { e.returnValue = false; } else { e.preventDefault(); }
            return;
        }
        if ($.trim($("#ctl00_ContentPlaceHolder1_txtaddress").val()) == '') {
            alert('地址不能为空');
            if (document.all) { e.returnValue = false; } else { e.preventDefault(); }
            return;
        }

        if ($.trim($("#ctl00_ContentPlaceHolder1_txtaddress").val()) == '') {
            alert('地址不能为空');
            if (document.all) { e.returnValue = false; } else { e.preventDefault(); }
            return;
        }

        if ($.trim($("#ctl00_ContentPlaceHolder1_hfthumb").val()) == '') {
            alert('形象图不能为空');
            if (document.all) { e.returnValue = false; } else { e.preventDefault(); }
            return;
        }

        if ($.trim($("#ctl00_ContentPlaceHolder1_hflogo").val()) == '') {
            alert('企业标志不能为空');
            if (document.all) { e.returnValue = false; } else { e.preventDefault(); }
            return;
        }

        if ($.trim($("#ctl00_ContentPlaceHolder1_hfsurface").val()) == '') {
            if (document.all) { e.returnValue = false; } else { e.preventDefault(); }
            return;
        }

    }
    </script>
</asp:Content>
