<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="DelShopList.aspx.cs" Inherits="TREC.Web.Suppler.shop.DelShopList" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../script/myPublic.js"></script>
<style type="text/css">
 .pop{position:absolute;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maintitle"><h1><u>已删除店铺</u></h1></div>
<div class="maincon">
  <div class="msgtable"> 
  <table width="100%" cellspacing="0" cellpadding="0" border="0" id="shoplist">
  <tbody><tr class="titlecor">
    <th width="40">选择</th>
    <th width="40">编号</th>
    <th width="120">店铺图片</th>
    <th>店铺名称</th>
    <th width="60">品牌</th>
    <th>地址</th>
    <th width="40">还原</th>
    <th width="40">删除</th>
  </tr>
  <asp:Repeater ID="rptList" runat="server">
  <ItemTemplate>
  <tr>
    <td><input type="checkbox" value="<%#Eval("Id")%>" /></td>
    <td><%#Eval("Id")%></td>
    <td><a><img width="100" height="60" border="0" src="<%#TREC.Entity.EnFilePath.GetShopThumbPath(Eval("Id")!=null?Eval("Id").ToString():"",Eval("thumb")!=null?Eval("thumb").ToString():"") %>"></a></td>
    <td width="140"><%#Eval("title") %></td>
    <td><div style="width:100%;float:left;line-height:18px;"><%#GetBrandOfShopId(Eval("id"))%></div></td>
    <td width="200"><%#Eval("address") %></td>        
    <td><a onclick="showRevertBox(<%#Eval("Id")%>);" href="Javascript:void();"><img width="16" height="16" border="0" alt="还原" src="../Images/huanyuan.gif"></a></td>
    <td><a onclick="showDelBox(<%#Eval("Id")%>);" href="Javascript:void();"><img width="16" height="16" border="0" alt="删除" src="../Images/del.png"></a></td>
  </tr>
  </ItemTemplate>
  </asp:Repeater>
</tbody></table>
</div>
<%=pageStr%>
<div class="btmenu">
<p>
<a onclick="chkAll(this,'shoplist');" id="off" class="bome">全选</a><a onclick="showRevertBox('');" class="bome">还原</a>
<a onclick="showDelBox('');" class="bome">删除</a>&nbsp;&nbsp;<a href="ShopList.aspx"><span class="lookdel"><img width="16" height="16" align="absmiddle" alt="返回" src="../Images/back.gif">&nbsp;返回</span></a></p>
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
    function showDelBox(shopId) {
        if (shopId == '') {
            //判断是否选择了店铺
            shopId = checkSelectedObj('shoplist');
            if (shopId == '') {
                alert('抱歉，请选择您要删除的店铺！');
                return;
            }
        }

        if ($('.mainbox .pop').size() == 0) {
            var myhtml = showDelBoxHtml('您将对店铺进行删除操作，点击“确定”后，该店铺将从您的店铺列表里消失，不可还原。', shopId, 'delete', '删除确认');
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
    function showRevertBox(shopId) {
        if (shopId == '') {
            //判断是否选择了店铺
            shopId = checkSelectedObj('shoplist');
            if (shopId == '') {
                alert('抱歉，请选择您要还原的店铺！');
                return;
            }
        }

        if ($('.mainbox .pop').size() == 0) {
            var myhtml = showDelBoxHtml('您将对这个店铺进行还原操作，点击“确定”后，该店铺将出来在您的店铺列表里。', shopId, 'revert', '还原提示');
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

    function delSingleBrand(shopId) {
        showDelBox(shopId);
    }

    //删除店铺
    function doAboutDb(shopId, type) {
        $.ajax({
            url: '../ajax/MemberHandler.ashx',
            dataType: 'text',
            data: 'shopId=' + shopId.toString() + '&Type=' + type.toString() + '&Action=doshoprecycle&rnd=' + Math.random(),
            success: function (data) {               
                var TypeName = "删除";
                if (type.toString() == 'revert') {
                    TypeName = '还原';
                }
                if (data == 'success') {
                    cancelCheckBoxChecked('shoplist');
                    alert(TypeName.toString() + '店铺成功！');
                    location.reload();
                } else if (data == 'fail') {
                    alert('抱歉，系统正忙' + TypeName.toString() + '店铺失败！');
                }
            }
        });
    }
   //-->
</script>
<div class="clear"></div>
</asp:Content>