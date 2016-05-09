<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="colorswatchlist.aspx.cs" Inherits="TREC.Web.Suppler.colorswatch.colorswatchlist" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
   .outpop li,.outpop{text-align:left;background:#fff;}
   .outpop{padding-bottom:20px;}
   .outpop input.btnlitl{margin-left:20px;}
   .outpop li input{margin-right:10px;}
    .pop,.outpop{position:absolute;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maintitle"><h1><u>色板管理</u></h1></div>
<div class="maincon"><div>
<div class="sobox" style="margin-bottom:15px;text-align:left;"><table cellspacing="0" cellpadding="0" border="0">
  <tbody><tr>   
    <td align="right">品牌</td>
    <td class="pr20"><select id="brandId">
        <option value="">请选择</option>      
        <asp:Repeater ID="rptBrand" runat="server">
            <ItemTemplate><option value="<%#Eval("id")%>"><%#Eval("title")%></option></ItemTemplate>
        </asp:Repeater>
      </select></td>
    <td align="left">系列</td>
    <td class="pr20"><select id="SeriesId">
      <option value="">请选择</option>      
      <asp:Repeater ID="RptSeries" runat="server">
      <ItemTemplate><option value="<%#Eval("id") %>"><%#Eval("title")%></option></ItemTemplate>
      </asp:Repeater>
      </select></td>
    <td align="right">色板名称</td>
    <td class="pr20"><input type="text" size="11" maxlength="100" value="<%=SwatchName %>" id="SwatchName"></td>
    <td><input type="button" class="btnso" value="搜索" /></td>
    </tr> 
</tbody></table>
</div>
<div style="DISPLAY: block" id="con_two_1" class="cplist">
<input type="button" onclick="location.href='IssueSwatch.aspx';" value="添加色板" class="btnadd marbtm">
  <div class="msgtable">
    <table width="100%" cellspacing="0" cellpadding="0" border="0" id="swatchlist">
      <tbody><tr class="titlecor">
        <th width="9%">选择</th>
            <th width="10%">品牌名称</th>
            <th width="10%">系列名称</th>
            <th width="16%">色板名称</th>
            <th width="18%">色板图片</th>
            <th width="10%">类别</th>
            <th width="9%">编辑</th>
            <th width="9%">删除</th>
        </tr>        
      <asp:Repeater ID="RptSwatch" runat="server">
      <ItemTemplate>
      <tr>
            <td><input type="checkbox" value="<%#Eval("csid") %>"></td>
            <td><%#Eval("bName")%></td>
            <td><%#Eval("brandsName")%></td>
            <td><%#Eval("SwatchName")%></td>
            <td><img width="100" height="60" border="0" style="margin:5px 0;" src="<%#Eval("Picture").ToString()==""?"../Images/noshop.jpg":("/upload/temp/"+Eval("Picture").ToString()) %>"></td>
            <td><%#Eval("cName")%></td>
            <td><a href="IssueSwatch.aspx?SwatchId=<%#Eval("csid") %>"><img width="16" height="16" border="0" src="../Images/bianji.png"></a></td>
            <td><a class="myhander" onclick="delSingleBrand(<%#Eval("csid") %>);"><img width="16" height="16" border="0" src="../Images/del.png"></a></td>
        </tr>
      </ItemTemplate>
      </asp:Repeater>
      </tbody></table>
  </div>
  <%if (!string.IsNullOrEmpty(pageStr)) { Response.Write(pageStr); } %>
  <div class="btmenu">
    <p> <a onclick="chkboxAll(this);" class="bome">全选</a><a href="IssueSwatch.aspx" class="bome">添加</a><a onclick="showDelBox('');" class="bome">删除</a>&nbsp;&nbsp;<span class="lookdel"><img width="11" height="13" align="absmiddle" alt="回收站" src="../Images/ljt.gif">&nbsp;<a href="DelSwatchList.aspx">&nbsp;查看已删除色板</a></span></p>
  </div>
</div>
</div>
	<!-- 标签切换 end -->
</div>
    <script src="../script/myPublic.js" type="text/javascript"></script>
<script type="text/javascript">
   <!--

    function getQueryString(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }
    $(function () {
        //弹出的删除提示框始终位于屏幕中间
        $(window).scroll(function () {
            if ($('.mainbox .pop').size() != 0) {
                $('.mainbox .pop').css('top', ($(window).height() - $('.mainbox .pop').height()) / 2 + $(document).scrollTop() + 'px');
                $('.mainbox .pop').css('left', ($(window).width() - $('.mainbox .pop').width()) / 2 + 'px');
            }
        });

        var brandid = getQueryString("brandId");
        var brandsid = getQueryString("seriesId");
        if (brandid != null) {            
            $("#brandId").val(brandid);
            $.ajax({
                url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                data: 'type=getbrands&v=' + brandid + "&ram=" + Math.random(),
                dataType: 'json',
                success: function (data) {
                    $.each(data, function (i) {
                        if (data[i].id != "" && data[i].title != "") {
                            $("#SeriesId").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                        }
                    });
                    if (brandsid != null) {
                        $("#SeriesId").val(brandsid);
                    }
                }
            });
        }

        //品牌下拉。获得系列及绑定品牌数据  
        $("#brandId").change(function () {
            if (this.value != "") {
                $.ajax({
                    url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                    data: 'type=getbrands&v=' + this.value + "&ram=" + Math.random(),
                    dataType: 'json',
                    success: function (data) {
                        $.each(data, function (i) {
                            if (data[i].id != "" && data[i].title != "") {
                                $("#SeriesId").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                            }
                        });
                    }
                });
            }
        });
        //搜索色板
        $('.btnso').click(function () {
            var url = '';
            //品牌id
            var brandId = $.trim($('#brandId option:selected').val());
            if (brandId.toString() != '') {
                url += 'brandId=' + brandId.toString();
            }
            //系列
            var seriesId = $.trim($('#SeriesId option:selected').val());
            if (seriesId.toString() != '') {
                if (url != '') { url += '&'; }
                url += 'seriesId=' + seriesId.toString();
            }
            //色板名称
            var SwatchName = $.trim($('#SwatchName').val());
            if (SwatchName.toString() != '') {
                if (url != '') { url += '&'; }
                url += 'SwatchName=' + escape(SwatchName.toString());
            }

            if (url != '') { url = '?' + url; }
            location.href = 'colorswatchlist.aspx' + url;
        });

        var brandId = '<%=brandId %>';
        //品牌
        $.getJSON('../MemberAjax/BrandHandler.ashx?Action=swatchlistsearchbrand&brandId=0', function (data) {
            $('#brandId').empty();
            var brandlist = '<option value="">请选择</option>';
            $.each(data, function (key, val) {
                brandlist += '<option value="' + key + '">' + val + '</option>';
            });
            $(brandlist).appendTo($('#brandId'));
            if (brandId.toString() != '0') {
                selectDdlByValue('brandId', brandId.toString());
            }
        });

        $('#brandId').change(function () {
            var brandId = $(this).val();
            if (brandId.toString() == '') {
                brandId = '0';
            }
            FillDdlSeries(brandId.toString());
        });

        //系列
        FillDdlSeries(brandId.toString());
    });
    function showDelBox(swId) {
        if (swId == '') {
            //判断是否选择了品牌
            swId = checkSelectedObj('swatchlist');
            if (swId == '') {
                alert('抱歉，请选择您要删除的色板！');
                return;
            }
        }

        if ($('.mainbox .pop').size() == 0) {
            var myhtml = showDelBoxHtml('您将把这个色板从这里移除，点击右下角的“查看已删除色板”可进行还原。', swId, '', '删除确认');
            $(myhtml).insertAfter($('.mainbox .maincon'));
            $('.mainbox .pop').css('top', ($(window).height() - $('.mainbox .pop').height()) / 2 + $(document).scrollTop() + 'px');
            $('.mainbox .pop').css('left', ($(window).width() - $('.mainbox .pop').width()) / 2 + 'px');
            $('.pop i').click(function () {
                hideDelBox();
            });
            $('.pop .btnlitr').click(function () {
                hideDelBox();
            });
        }
    }

    function delSingleBrand(swId) {
        showDelBox(swId);
    }

    //删除色板
    function doAboutDb(swId, type) {
        $.ajax({
            url: '../ajax/MemberHandler.ashx',
            dataType: 'text',
            data: 'swId=' + swId.toString() + '&Action=delsw&rnd=' + Math.random(),
            success: function (data) {
                if (data == 'success') {
                    cancelCheckBoxChecked('swatchlist');
                    alert('删除色板成功！');
                    location.reload();
                } else if (data == 'fail') {
                    alert('抱歉，系统正忙删除色板失败！');
                }
            }
        });
    }

    //填充系列下拉菜单
    function FillDdlSeries(brandId) {
        $('#SeriesId').empty();
        $('<option value="">请选择</option>').appendTo($('#SeriesId'));
        if (brandId.toString() != '0') {
            $.getJSON('../MemberAjax/BrandHandler.ashx?Action=swatchlistsearchseries&brandId=' + brandId.toString(), function (data) {
                var seriesList = '';
                $.each(data, function (key, value) {
                    seriesList += '<option value="' + key + '">' + value + '</option>';
                })
                $(seriesList).appendTo($('#SeriesId'));
                var seriesId = '<%=seriesId %>';
                if (seriesId.toString() != '0') {
                    selectDdlByValue('SeriesId', seriesId.toString());
                }
            });
        }
    }
    //select all
    function chkboxAll(th) {
        if ($(".msgtable").find("input[type=checkbox]:checked").length > 0) {
            $(".msgtable").find("input[type=checkbox]").attr('checked', false);
            $(th).text("全选")
        } else {
            $(".msgtable").find("input[type=checkbox]").attr('checked', "checked");
            $(th).text("取消")
        }
    }
   //-->
</script>
</asp:Content>