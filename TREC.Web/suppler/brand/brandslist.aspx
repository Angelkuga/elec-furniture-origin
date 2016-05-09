<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="brandslist.aspx.cs" MasterPageFile="../Member.Master" Inherits="TREC.Web.Suppler.brand.brandslist" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Import Namespace="TREC.ECommerce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../script/myPublic.js"></script>    
<style type="text/css">
    .pop{position:absolute;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maintitle"><h1><u>品牌管理</u></h1></div>
<div class="maincon">
<div>
<div class="cpTitle">
	<ul><li onclick="location.href='BrandList.aspx';" style="position:relative;" class="tabNormal" id="two1"><a href="BrandList.aspx">品牌管理</a></li>
	<li style="position:relative;cursor:default;" class="tabActive" id="two2"><a>系列管理</a></li>
	</ul> 
</div>
<div id="con_two_2" class="cplist"><br>
<input type="button" onclick="location.href='brandsinfo.aspx';" value="添加新系列" class="btnadd marbtm" name="button2">
    <div class="msgtable">
      <table width="100%" cellspacing="0" cellpadding="0" border="0" id="brandserieslist">
        <tr class="titlecor">
          <th width="14%">选择</th>
          <th width="18%">编号</th>
          <th width="21%">品牌名称</th>
          <th width="29%">系列名称</th>
          <th width="9%">编辑</th>
          <th width="9%">删除</th>
        </tr>
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
            <tr>
                <td><input type="checkbox" value="<%#Eval("Id")%>"></td>
                <td><%#Eval("Id")%></td>
                <td><%#Eval("brandtitle")%></td>
                <td><%#Eval("title")%></td>
                <td><a href="brandsinfo.aspx?edit=1&id=<%#Eval("Id")%>"><img width="16" border="0" height="16" alt="编辑" src="../Images/bianji.png"></a></td>
                <td><a onclick="delSingleBrand(<%#Eval("Id")%>);" href="Javascript:void();"><img width="16" border="0" height="16" alt="删除" src="../Images/del.png"></a></td>
            </tr>                
          </ItemTemplate>
       </asp:Repeater>
      </table>
    </div>
	<%=pageStr%>
	<div class="btmenu">
    <p> <a onclick="chkAll(this,'brandserieslist');" id="off" class="bome">全选</a><a href="brandsinfo.aspx" class="bome">添加</a><a onclick="showDelBox('');" class="bome">删除</a>&nbsp;&nbsp;<span class="lookdel"><img width="11" align="absmiddle" height="13" alt="回收站" src="../Images/ljt.gif">&nbsp;<a href="recyclebrandslist.aspx">&nbsp;查看已删除系列</a></span></p>
  </div>
</div>
</div>
<!-- 标签切换 end -->
</div>
<script type="text/javascript">
    <!--
        $(function () {
            //弹出的删除提示框始终位于屏幕中间
            $(window).scroll(function () {
                if ($('.mainbox .pop').size() != 0) {
                    $('.mainbox .pop').css('top', ($(window).height() - $('.mainbox .pop').height()) / 2 + $(document).scrollTop() + 'px');
                    $('.mainbox .pop').css('left', ($(window).width() - $('.mainbox .pop').width()) / 2 + 'px');
                }
            });
        });

        //单个删除系列
        function delSingleBrand(brandId) {
            showDelBox(brandId);
        }

        //批量删除系列
        function showDelBox(brandId) {
            if (brandId == '') {
                //判断是否选择了系列
                brandId = checkSelectedObj('brandserieslist');
                if (brandId == '') {
                    alert('抱歉，请选择您要删除的系列！');
                    return;
                }
            }

            if ($('.mainbox .pop').size() == 0) {
                var myhtml = showDelBoxHtml('您将把这个系列从这里移除，点击右下角的“查看已删除系列”可进行还原。', brandId, '', '删除确认');
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

        //删除系列
        function doAboutDb(SeriesId, type) {            
            $.ajax({
                url: '../ajax/MemberHandler.ashx',
                dataType: 'text',
                data: 'seriesId=' + SeriesId.toString() + '&Action=delseries&rnd=' + Math.random(),
                success: function (data) {
                    if (data == 'success') {
                        cancelCheckBoxChecked('brandserieslist');
                        alert('删除系列成功！');
                        location.reload();
                    } else if (data == 'fail') {
                        alert('抱歉，系统正忙删除系列失败！');
                    }
                }
            });
        }
    //-->
</script>
<div class="clear"></div>
</asp:Content>