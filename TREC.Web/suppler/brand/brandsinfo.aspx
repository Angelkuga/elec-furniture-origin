<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="brandsinfo.aspx.cs" MasterPageFile="../Member.Master" Inherits="TREC.Web.Suppler.brand.brandsinfo" EnableEventValidation="false" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/editor/kindeditor/kindeditor-min.js"></script>
<style type="text/css">
    .pop{position:absolute;display:none;}#stip{ height:5px; line-height:5px;}#uSwatch{color:#008CD4;}
    .fileTools a._filedel, .fileTools a._filesee{ display:none;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maintitle"><h1><u><%=myTitle%>系列</u></h1></div>
<div class="maincon">
  <div class="maintabcor">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="173" height="40" align="right">选择品牌</td>
            <td width="577" class="textleft"><asp:DropDownList ID="ddlbrand" runat="server" CssClass="select selectNone"></asp:DropDownList></td>
        </tr>
        <tr>
            <td height="40" align="right">系列名称</td>
            <td class="textleft"><asp:TextBox ID="txttitle" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td height="40" align="right">材质</td>
            <td class="textleft"><asp:DropDownList ID="ddlmaterial" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td height="40" align="right">风格</td>
            <td class="textleft"><asp:DropDownList ID="ddlstyle" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td height="40" align="right">色系</td>
            <td class="textleft"><asp:DropDownList ID="ddlcolor" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
        <td height="40" align="right">色板</td>
        <td class="textleft"><input type="button" class="btnadd" onclick="showSwatchesBox();" value="上传色板" /><span id="uSwatch"><%if (!string.IsNullOrEmpty(SwatchName)) { Response.Write("已上传色板：" + SwatchName + "<input type=\"hidden\" value=" + SwatchId + " id=\"mySwatchName\" />"); } %></span></td>
        </tr>
        <tr><td height="130" colspan="2"><div class="btnone bordtop"><asp:Button ID="btnSave" runat="server" Text="提 交" CssClass="btnl" OnClientClick="return chkSeriesForm();" OnClick="btnSave_Click" /><input name="重置" type="reset" class="btnr" value="重 填" runat="server" id="btnRequest" /></td></div></tr>
    </table>
    </div>
</div>
<div class="pop bord">
  <h1><u>上传色板</u><i>X</i></h1>
  <div class="popcon">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td height="35" align="right">色板名称</td>
        <td class="textleft"><input name="SwatchName" type="text" maxlength="100" size="16" /></td>
      </tr>
      <tr>
        <td height="35" align="right">类别</td>
        <td class="textleft"><select name="myCategroy" id="myCategroy">
          <option value="0">类别</option>
        </select></td>
      </tr>
      <tr>
        <td height="35" align="right">色板图片</td>
        <td class="textleft"><div path="<%=string.Format(TREC.Entity.EnFilePath.Brand, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>" class="fileUpload">
                    <input type="hidden" id="hfthumb" name="hfthumb" class="notip" />
                    <div class="fileTools">
                        <input type="text" class="input w67 filedisplay" id="SeriesPictrue" readonly="readonly" />
                        <a class="files" href="javascript:;">
                            <input type="file" onchange="_upfile(this,'0')" class="upload" id="File3" name="File3" /></a>
                        <span class="uploading"></span>
                    </div>
                </div></td>
      </tr>
      <tr>
        <td colspan="2" id="stip">&nbsp;</td>
      </tr>
      <tr>
        <td colspan="2">        
        <div class="btnone bordtop"><input type="button" ID="SwatchBt" onclick="chkSwatchForm(this);" class="btnlitl" value="提 交" />
        <input type="reset" value="取消" class="btnlitr" /></div>
        </td>
    </tr>
    </table>    
  </div>
</div>
<script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
<script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/fileupload.js"></script>
<script type="text/javascript">
    <!--
    $(function () {
        //弹出提示框始终位于屏幕中间
        $(window).scroll(function () {
            if ($('.mainbox .pop').css('display').toString() != 'none') {
                $('.mainbox .pop').css('top', ($(window).height() - $('.mainbox .pop').height()) / 2 + $(document).scrollTop() + 'px');
                $('.mainbox .pop').css('left', ($(window).width() - $('.mainbox .pop').width()) / 2 + 'px');
            }
        });
        $('#<%=txttitle.ClientID %>').change(function () {
            var brandId = $('#<%=ddlbrand.ClientID %>').val();
            if (brandId.toString() == '0') {
                alert('抱歉，请选择品牌！');
                $('#<%=ddlbrand.ClientID %>').focus();
                return;
            }
            var obj = this;
            var myvalue = $.trim($(obj).val());
            if (myvalue != '') {
                if ($('#sntip').size() == 0) {
                    $('<span style="margin-left:5px;color:#999;" id="sntip">正在验证系列名称是否重复中...</span>').insertAfter($(this));
                }
                $('#seriesbt').attr('disabled', 'disabled');
                var SeriesId = '<%=SeriesId %>';
                var db = 'Action=chkseriesname&SeriesName=' + myvalue.toString() + '&SeriesId=' + SeriesId.toString() + '&seriesbrandId=' + brandId.toString() + '&rnd=' + Math.random();
                $.ajax({
                    url: '../ajax/MemberHandler.ashx',
                    dataType: 'text',
                    data: db,
                    success: function (data) {
                        if (data.toString() != 'no') {
                            $('#sntip').html('抱歉，名称为：' + myvalue + '系列已经存在！').css('color', '#999');
                        } else {
                            $('#sntip').html('该名称的系列可用！').css('color', '#008CD4');
                            $('#seriesbt').removeAttr('disabled');
                        }
                    }
                });
            }
        });
    });

    function showSwatchesBox() {
        loadSwatchCategroy();
        $('.mainbox .pop').show();
        $('.mainbox .pop').css('top', ($(window).height() - $('.mainbox .pop').height()) / 2 + $(document).scrollTop() + 'px');
        $('.mainbox .pop').css('left', ($(window).width() - $('.mainbox .pop').width()) / 2 + 'px');
        $('.pop i').click(function () {
            $('.mainbox .pop').hide();
        });
        $('.pop .btnlitr').click(function () {
            $('.mainbox .pop').hide();
        });
    }

    function loadSwatchCategroy() {
        if ($('#myCategroy option').size() == 1) {
            $('#myCategroy').empty();
            $('<option value="0">类别</option>').appendTo($('#myCategroy'));
            $('<option value="182">沙发</option><option value="184">木质家具</option>').appendTo($('#myCategroy'));
        }
    }

    //验证色板表单
    function chkSwatchForm(obj) {
        var SwatchName = $.trim($('input[name=SwatchName]').val());
        if (SwatchName == '') {
            alert('抱起，请输入色板名称！');
            $('input[name=SwatchName]').focus();
            return;
        }
        var myCategroy = $.trim($('#myCategroy option:selected').val());
        if (myCategroy.toString() == '0') {
            alert('抱歉，请选择类别！');
            $('#myCategroy').focus();
            return;
        }
        var hfthumb = $.trim($('#hfthumb').val());
        if (hfthumb == '') {
            alert('抱歉，请上传色板图片！');
            $('#SeriesPictrue').focus();
            return;
        }
        $('#stip').css({ 'height': 'auto', 'line-height': 'normal' });
        $('#stip').html('<div style="font-size:12px;color:#999;">正在保存数据中...</div>');
        //保存数据
        var SeriesId = '<%=SeriesId %>';
        $('#SwatchBt').attr('disabled', 'disabled');
        var db = 'Action=saveswatch&SeriesName=' + SwatchName.toString() + '&SeriesId=' + SeriesId.toString() + '&myCategroy=' + myCategroy.toString() + '&hfthumb=' + hfthumb.toString() + '&rnd=' + Math.random();
        $.ajax({
            url: '../ajax/MemberHandler.ashx',
            dataType: 'text',
            data: db,
            success: function (data) {
                $('#SwatchBt').removeAttr('disabled');
                $('#stip').html('');
                if (data == null) {
                    alert('抱歉，系统正忙请稍后上传色板！');
                } else {
                    if (data.toString() == 'login') {
                        alert('抱歉，登陆已过期，请重新登陆！');
                    } else {
                        $('#uSwatch').html('已上传色板：' + data.toString());
                        alert('上传色板成功！');
                        $('input[name=SwatchName]').val('');
                        $('#SeriesPictrue').val('');
                        $('#hfthumb').html('');
                        $('.mainbox .pop').hide();
                        $('#stip').html('').css({ 'height': '5px', 'line-height': '5px' });
                    }
                }
            }
        });
        return;
    }

    //验证系列表单
    function chkSeriesForm() {
        var DdlBrand = $('#<%=ddlbrand.ClientID %>').val();
        if (DdlBrand.toString() == '0') {
            alert('抱歉，请选择品牌！');
            $('#<%=ddlbrand.ClientID %>').focus();
            return false;
        }
        var SeriesName = $.trim($('#<%=txttitle.ClientID %>').val());
        if (SeriesName == '') {
            alert('抱歉，请输入系列名称！');
            $('#<%=txttitle.ClientID %>').focus();
            return false;
        }
        return true;
    }

    //选中材质、风格、色系
    function SelectMSC(MaterialId, StyleId, ColorId) {
        //材质
        if (MaterialId != 0) {
            $('#Material option[value=' + MaterialId.toString() + ']').attr('selected', true);
        }
        //风格
        if (StyleId != 0) {
            $('#Style option[value=' + StyleId.toString() + ']').attr('selected', true);
        }
        //色系
        if (ColorId != 0) {
            $('#Color option[value=' + ColorId.toString() + ']').attr('selected', true);
        }
    }

    //成功上传色板后提示信息
    function showUploadSC(SwatchName, csId) {
        var mySwatchName = '<%=SwatchName %>';
        var mySwatchId = '<%=SwatchId %>';
        if (mySwatchName.toString() != '') {
            mySwatchName += "、";
            mySwatchId += ',';
        }
        mySwatchName += SwatchName.toString();
        mySwatchId += csId.toString();

        $('#uSwatch').html('已上传色板：' + mySwatchName.toString() + '<input type="hidden" value="' + mySwatchId.toString() + '" id="mySwatchName" />');
        $('.mainbox .pop').hide();
        $('#stip').html('').css({ 'height': '5px', 'line-height': '5px' });
    }
    //-->
</script>
</asp:Content>