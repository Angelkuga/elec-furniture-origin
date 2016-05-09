<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="IssueSwatch.aspx.cs" Inherits="TREC.Web.Suppler.colorswatch.IssueSwatch" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Import Namespace="TREC.ECommerce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maintitle"><h1><u><%if (SwatchId == 0) { Response.Write("添加"); } else { Response.Write("编辑"); } %>色板</u></h1></div>
<div class="maincon">
  <div class="maintabcor">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="173" height="40" align="right">&nbsp;选择品牌</td>
    <td width="577" class="textleft"><asp:DropDownList ID="DdlBrand" runat="server"></asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td height="40" align="right">系列</td>
    <td class="textleft"><select id="SeriesId" name="SeriesId">
      <option value="0">请选择</option>
        <asp:Repeater ID="RptSeries" runat="server">
      <ItemTemplate><option value="<%#Eval("id") %>"><%#Eval("title")%></option></ItemTemplate>
      </asp:Repeater>
    </select><a target="_blank" href="../brand/brandsinfo.aspx"><img width="16" height="16" border="0" alt="添加" src="../Images/jiahao.jpg"></a>    </td>
    </tr>
    <tr>
    <td height="40" align="right">类别</td>
    <td class="textleft"><select id="myCategroy" name="myCategroy">
        <option value="0">读取数据中</option>
      </select></td>
    </tr>
  <tr>
    <td height="40" align="right">&nbsp;色板名称</td>
    <td class="textleft"><input type="text" id="SwatchName" name="SwatchName" value="<%=SwatchName %>" maxlength="100" /></td>
    </tr> 
  <tr>
    <td height="40" align="right">色板图片</td>
    <td class="textleft"><div path="/upload/temp/" class="fileUpload">
                    <input type="hidden" id="hfthumb" value="<%=Picture %>" name="hfthumb" class="notip" />
                    <div class="fileTools">
                        <input type="text" class="input w150 filedisplay" id="SeriesPictrue" name="thumb" value="<%=Picture %>" readonly="readonly" />
                        <a class="files" href="javascript:;">
                            <input type="file" onchange="_upfile(this)" class="upload" id="File3" name="File3" /></a>
                        <span class="uploading"></span>
                    </div>
                </div></td>
    </tr>
  <tr>
    <td height="130" colspan="2">
      <div class="btnone bordtop">
      <asp:Button ID="btnSave" runat="server" OnClientClick="return chkColorSwatchForm();" Text="提 交" CssClass="btnl" OnClick="btnSave_Click" />
<%--<input type="button" value="提 交" id="seriesbt" runat="server" onclick="return chkColorSwatchForm(this);" class="btnl" />--%>
<input type="reset" value="重 填" class="btnr" />
</div></td>
    </tr>
</table>
</div>
</div>
<script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
<script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/fileupload.js"></script>
<script type="text/javascript">
<!--
    function getQueryString(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }
    $(function () {
        loadSwatchCategroy();
        $('#<%=DdlBrand.ClientID %>').change(function () {
            var brandId = $(this).val();
            $('#SeriesId').empty();
            if (brandId.toString() != '') {
                $.ajax({
                    url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                    data: 'type=getbrands&v=' + brandId + '&ram=' + Math.random(),
                    dataType: 'json',
                    success: function (data) {
                        $("#SeriesId").append("<option value=\"\">请选择</option>");
                        $.each(data, function (i) {
                            if (data[i].id != "" && data[i].title != "") {
                                $("#SeriesId").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                            }
                        });
                    }
                });
            }
        });
        var brandsid = "<%=brandsid %>";
        if (brandsid != 0) {
            $("#SeriesId").val(brandsid);
        }

    });
    function getQueryString(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }
    function loadSwatchCategroy() {
    var cateogryid= "<%=cateogryid %>";
    $.ajax({
        url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
        dataType: 'text',
        data: 'type=swatchcategroy&rnd=' + Math.random(),
        success: function (data) {
            $('#myCategroy').empty();
            $('<option value="0">请选择</option>').appendTo($('#myCategroy'));
            if (data != null) {
                $(data).appendTo($('#myCategroy'));
            }
            if (cateogryid != 0) {
                $('#myCategroy').val(cateogryid);
            }
        }
    });
    }

//    function selecteDdl(CategroyId, BrandId, SeriesId) {
//        setTimeout('selectDdlByValue(\'myCategroy\', ' + CategroyId.toString() + ');', 500);
//        if (BrandId.toString() != '') {
//            selectDdlByValue('<%=DdlBrand.ClientID %>', BrandId.toString());
//            $('#SeriesId').empty();
//            $('<option value="0">读取数据中</option>').appendTo($('#SeriesId'));
//            $.get('../MemberAjax/ProductHandler.ashx', { Action: 'series', brandId: BrandId.toString(), rnd: Math.random() }, function (data) {
//                if (data != null) {
//                    $('#SeriesId').empty();
//                    data = '<option value="0">请选择</option>' + data;
//                    $(data).appendTo($('#SeriesId'));
//                    selectDdlByValue('SeriesId', SeriesId.toString());
//                }
//            });
//        }
//    }

    function selectDdlByValue(objId, objValue) {
        $('#' + objId.toString() + ' option[value=\'' + objValue.toString() + '\']').attr('selected', true);
    }

    function chkColorSwatchForm(obj) {
        var brandId = $.trim($('#<%=DdlBrand.ClientID %> option:selected').val());
        var SeriesId = $.trim($('#SeriesId option:selected').val());
        if (brandId.toString() == '') {            
                alert('请选择品牌！');
                $('#<%=DdlBrand.ClientID %>').focus();
                return false;            
        }
        if (SeriesId.toString() == '') {
            alert('请选择系列！');
            $('#SeriesId').focus();
            return false;
        }
        var categroyId = $.trim($('#myCategroy option:selected').val());
        if (categroyId.toString() == '0') {
            alert('请选择类别！');
            $('#myCategroy').focus();
            return false;
        }
        var SwatchName = $.trim($('#SwatchName').val());
        if (SwatchName == '') {
            alert('请输入色板名称！');
            $('#SwatchName').focus();
            return false;
        }
        var Pictrue = $.trim($('#SeriesPictrue').val());
        if (Pictrue == '') {
            alert('请上传色板图片！');
            return false;
        }
        return true;       
    }
//-->
</script>
</asp:Content>