<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="recyclebrandslist.aspx.cs" Inherits="TREC.Web.Suppler.brand.recyclebrandslist" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../script/myPublic.js"></script>    
<style type="text/css">
    .pop{position:absolute;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maintitle"><h1><u>已删除系列</u></h1></div>
<div class="maincon">
<div>
<div class="cpTitle">
	<ul><li style="position: relative" class="tabNormal" id="two1"><a href="BrandList.aspx">品牌管理</a></li>
	<li style="position: relative" class="tabActive" id="two2"><a href="brandslist.aspx">系列管理</a></li>
	</ul> 
</div>
<div id="con_two_2" class="cplist"><br>
    <div class="msgtable">
      <table width="100%" cellspacing="0" cellpadding="0" border="0" id="brandserieslist">
        <tbody><tr class="titlecor">
          <th width="14%">选择</th>
          <th width="18%">编号</th>
          <th width="21%">品牌名称</th>
          <th width="29%">系列名称</th>
          <th width="9%">还原</th>
          <th width="9%">删除</th>
        </tr>
        
       <asp:Repeater ID="RptBrand" runat="server">
           <ItemTemplate>
           <tr>
                <td><input type="checkbox" value="<%#Eval("Id")%>" /></td>
                <td><%#Eval("Id")%></td>
                <td><%#Eval("brandtitle")%></td>
                <td><%#Eval("title")%></td>
                <td><a onclick="showRevertBox(<%#Eval("Id")%>);" href="Javascript:void();"><img width="16" border="0" height="16" alt="还原" src="../Images/huanyuan.gif"></a></td>
                <td><a onclick="delSingleBrand(<%#Eval("Id")%>);" href="Javascript:void();"><img width="16" border="0" height="16" alt="删除" src="../Images/del.png"></a></td>
            </tr>
           </ItemTemplate>
       </asp:Repeater> 
      </tbody></table>
    </div>
	<%=pageStr%>
	<div class="btmenu">
    <p> <a onclick="chkAll(this,'brandserieslist');" id="off" class="bome">全选</a><a onclick="showRevertBox('');" href="Javascript:void();" class="bome">还原</a><a onclick="showDelBox('');" class="bome">删除</a>&nbsp;&nbsp;<a href="brandslist.aspx"><span class="lookdel"><img width="16" align="absmiddle" height="16" alt="返回" src="../Images/back.gif">&nbsp;返回</span></a></p>
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
            var myhtml = showDelBoxHtml('您将对系列进行删除操作，点击“确定”后，该系列将从您的系列回收站里消失，不可还原。', brandId, 'delbrandseriesrecycle', '删除确认');
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

    //还原系列提示
    function showRevertBox(brandId) {
        if (brandId == '') {
            //判断是否选择了系列
            brandId = checkSelectedObj('brandserieslist');
            if (brandId == '') {
                alert('抱歉，请选择您要还原的系列！');
                return;
            }
        }

        if ($('.mainbox .pop').size() == 0) {
            var myhtml = showDelBoxHtml('您将对这个系列进行还原操作，点击“确定”后，该系列将出来在您的系列列表里。', brandId, 'revertbrandseriesrecycle', '还原提示');
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
            data: 'recycleId=' + brandId.toString() + '&Action=' + type.toString() + '&rnd=' + Math.random(),
            success: function (data) {
                if (data == 'success') {
                    cancelCheckBoxChecked('brandserieslist');
                    if (type.toString() == 'delbrandseriesrecycle') {
                        alert('删除系列成功！');
                    } else {
                        alert('还原系列成功！');
                    }
                    location.reload();
                } else if (data == 'fail') {
                    if (type.toString() == 'delbrandseriesrecycle') {
                        alert('抱歉，系统正忙删除系列失败！');
                    } else {
                        alert('抱歉，系统正忙还原系列失败！');
                    }
                }
            }
        });
    }
   //-->
</script>
<div class="clear"></div>
</asp:Content>