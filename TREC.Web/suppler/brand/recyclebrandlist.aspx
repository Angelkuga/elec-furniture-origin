<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="recyclebrandlist.aspx.cs" Inherits="TREC.Web.Suppler.brand.recyclebrandlist" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Import Namespace="TREC.ECommerce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../script/myPublic.js"></script>    
<style type="text/css">
    .pop{position:absolute;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="subright bord">
<div class="maintitle"><h1><u>已删除品牌</u></h1></div>
<div class="maincon">
  <div class="msgtable">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="brandlist">
      <tr class="titlecor">
        <th width="9%">选择</th>
        <th width="13%">编号</th>
        <th width="26%">LOGO图片</th>
        <th width="16%">品牌名称</th>
        <th width="9%">还原</th>
        <th width="9%">删除</th>
      </tr>      
      <asp:Repeater ID="RptBrand" runat="server">
          <ItemTemplate>
          <tr>
            <td><input type="checkbox" value="<%#Eval("Id")%>" /></td>
            <td><%#Eval("Id")%></td>
            <td><img width="100" border="0" height="60" style="margin:5px 0;" src="<%#TREC.Entity.EnFilePath.GetBrandLogoPath(Eval("Id")!=null?Eval("Id").ToString():"",Eval("logo")!=null?Eval("logo").ToString():"") %>"></td>
            <td><%#Eval("title") %></td>
            <td><a onclick="showRevertBox(<%#Eval("Id")%>);" href="Javascript:void();"><img width="16" height="16" alt="还原" src="../Images/huanyuan.gif"></a></td>
            <td><a onclick="delSingleBrand(<%#Eval("Id")%>);" href="Javascript:void();"><img width="16" border="0" height="16" alt="删除" src="../Images/del.png"></a></td>
          </tr>
          </ItemTemplate>
      </asp:Repeater>          
   </table>
  </div>
 <%if (!string.IsNullOrEmpty(pageStr)) { Response.Write(pageStr); } %>
<div class="btmenu">
<p>
<a onclick="chkAll(this,'brandlist');" id="off" class="bome">全选</a><a onclick="showRevertBox('');" class="bome">还原</a><a onclick="showDelBox('');" class="bome">删除</a>&nbsp;&nbsp;<a href="BrandList.aspx"><span class="lookdel"><img width="16" align="absmiddle" height="16" alt="返回" src="../Images/back.gif">&nbsp;返回</span></a></p>
</div>
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
    function showDelBox(brandId) {
        if (brandId == '') {
            //判断是否选择了品牌
            brandId = checkSelectedObj('brandlist');
            if (brandId == '') {
                alert('抱歉，请选择您要删除的品牌！');
                return;
            }
        }

        if ($('.mainbox .pop').size() == 0) {
            var myhtml = showDelBoxHtml('您将对品牌进行删除操作，点击“确定”后，该品牌将从您的品牌列表里消失，不可还原。', brandId, 'delbrandrecycle', '删除确认');
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

    //还原品牌提示
    function showRevertBox(brandId) {
        if (brandId == '') {
            //判断是否选择了品牌
            brandId = checkSelectedObj('brandlist');
            if (brandId == '') {
                alert('抱歉，请选择您要还原的品牌！');
                return;
            }
        }

        if ($('.mainbox .pop').size() == 0) {
            var myhtml = showDelBoxHtml('您将对这个品牌进行还原操作，点击“确定”后，该品牌将出来在您的品牌列表里。', brandId, 'revertbrandrecycle', '还原提示');
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

    function delSingleBrand(brandId) {
        showDelBox(brandId);
    }

    //删除品牌
    function doAboutDb(brandId, type) {
        $.ajax({
            url: '../ajax/MemberHandler.ashx',
            dataType: 'text',
            data: 'recyclebrandId=' + brandId.toString() + '&Action=' + type.toString() + '&rnd=' + Math.random(),
            success: function (data) {                
                if (data == 'success') {
                    cancelCheckBoxChecked('brandlist');
                    if (type.toString() == 'delbrandrecycle') {
                        alert('删除品牌成功！');
                    } else {
                        alert('还原品牌成功！');
                    }
                    location.reload();
                } else if (data == 'fail') {
                    if (type.toString() == 'delbrandrecycle') {
                        alert('抱歉，系统正忙删除品牌失败！');
                    } else {
                        alert('抱歉，系统正忙还原品牌失败！');
                    }
                }
            }
        });
    }
   //-->
</script>
<div class="clear"></div>
</div>
</asp:Content>