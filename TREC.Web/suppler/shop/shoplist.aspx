<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoplist.aspx.cs" MasterPageFile="../Member.Master" Inherits="TREC.Web.Suppler.shop.shoplist" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../script/myPublic.js"></script>
<style type="text/css">
 .pop{position:absolute;}
 .fileTools a._filedel, .fileTools a._filesee{ display:none;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maintitle"><h1><u>店铺管理</u></h1></div>
<div class="maincon">
  <div class="msgtable">
  <input type="button" onclick="location.href='shopinfo.aspx';" value="添加新店铺" class="btnadd marbtm">
  <table width="100%" cellspacing="0" cellpadding="0" border="0" id="shoplist">
  <tbody><tr class="titlecor">
    <th width="40">选择</th>
    <th width="40">编号</th>
    <th width="120">店铺图片</th>
    <th>店铺名称</th>
    <th width="60">品牌</th>
    <th>地址</th>
    <th width="70">状态</th>
    <th width="40">编辑</th>
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
        <td><%#GetStatusStr(Eval("linestatus"))%></td>
        <td><a href="shopinfo.aspx?edit=1&id=<%#Eval("Id")%>"><img width="16" height="16" border="0" alt="编辑" src="../Images/bianji.png"></a></td>
        <td><a onclick="showDelBox(<%#Eval("Id")%>);" href="Javascript:void();"><img width="16" height="16" border="0" alt="删除" src="../Images/del.png"></a></td>
        </tr>
      </ItemTemplate>
 </asp:Repeater>   
</tbody></table>
</div>
<%=pageStr%>
<div class="btmenu">
<p>
<a onclick="chkAll(this,'shoplist');" id="off" class="bome">全选</a><a href="shopinfo.aspx" class="bome">添加</a><a onclick="doShopStatus('up');" class="bome">上线</a><a onclick="doShopStatus('down');" class="bome">下线</a>
<a onclick="showDelBox('');" class="bome">删除</a>&nbsp;&nbsp;<span class="lookdel"><img width="11" height="13" align="absmiddle" src="../Images/ljt.gif">&nbsp;<a href="DelShopList.aspx">&nbsp;查看已删除店铺</a></span></p>
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
            var myhtml = showDelBoxHtml('您将把这个店铺从这里移除，点击右下角的“查看已删除店铺”可进行还原。', shopId, 'delete', '删除确认');
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

    //店铺（上、下）线
    function doShopStatus(Type) {
        var TypeName=Type == 'down' ? '下线' : '上线';
        //判断是否选择了店铺
        shopId = checkSelectedObj('shoplist');
        if (shopId == '') {
            alert('抱歉，请选择您要' + TypeName + '的店铺！');
            return;
        }

        var myhtml = showDelBoxHtml('您将把这个店铺从这里'+TypeName+'，'+(Type=='down'?'下线后该店铺将不在前台显示':'需要等待管理员审核，审核后才能在前台显示')+'。', shopId, Type, TypeName + '确认');
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

    function delSingleBrand(shopId) {
        showDelBox(shopId);
    }

    //删除店铺
    function doAboutDb(shopId, type) {
        $.ajax({
            url: '../ajax/MemberHandler.ashx',
            dataType: 'text',
            data: 'shopId=' + shopId.toString() + '&Type=' + type.toString() + '&Action=doshop&rnd=' + Math.random(),
            success: function (data) {
                var TypeName = "删除";
                if (type.toString() == 'up') {
                    TypeName = '上线';
                } else if (type.toString() == 'down') {
                    TypeName = '下线';
                }
                if (data == 'success') {
                    cancelCheckBoxChecked('shoplist');
                    var message = '';
                    switch (type.toString()) {
                        case 'up':
                            message = '店铺上线正在申请中，请等待审核！';
                            break;
                        case 'down':
                            message = '店铺下线成功';
                            break;
                        default:
                            message = '店铺已删除至品牌回收站，您可以到品牌回收站查看！';
                            break;
                    }
                    alert(message);
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