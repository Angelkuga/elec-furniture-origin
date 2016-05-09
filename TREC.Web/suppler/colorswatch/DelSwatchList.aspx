<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="DelSwatchList.aspx.cs" Inherits="TREC.Web.Suppler.colorswatch.DelSwatchList" %>
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
<div class="maintitle"><h1><u>已删除色板</u></h1></div>
<div class="maincon"><div>
<div style="DISPLAY: block" id="con_two_1" class="cplist">
  <div class="msgtable">
    <table width="100%" cellspacing="0" cellpadding="0" border="0" id="swatchlist">
      <tbody><tr class="titlecor">
        <th width="9%">选择</th>
            <th width="10%">品牌名称</th>
            <th width="10%">系列名称</th>
            <th width="16%">色板名称</th>
            <th width="18%">色板图片</th>
            <th width="10%">类别</th>
            <th width="9%">还原</th>
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
            <td><a class="myhander" onclick="showRevertBox(<%#Eval("csid") %>);"><img width="16" height="16" border="0" src="../Images/huanyuan.gif"></a></td>
            <td><a class="myhander" onclick="delSingleBrand(<%#Eval("csid") %>);"><img width="16" height="16" border="0" src="../Images/del.png"></a></td>
        </tr>
      </ItemTemplate>
      </asp:Repeater>
      </tbody></table>
  </div>
  <%if (!string.IsNullOrEmpty(pageStr)) { Response.Write(pageStr); } %>
  <div class="btmenu">
    <p> <a onclick="chkAll(this,'swatchlist');" id="off" class="bome">全选</a><a onclick="showRevertBox('');" class="bome">还原</a><a onclick="showDelBox('');" class="bome">删除</a>&nbsp;&nbsp;<a href="colorswatchlist.aspx"><span class="lookdel"><img width="16" height="16" align="absmiddle" alt="返回" src="../Images/back.gif">&nbsp;返回</span></a></p>
  </div>
</div>
</div>
	<!-- 标签切换 end -->
</div>
<script src="../script/myPublic.js" type="text/javascript"></script>
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
    function showDelBox(swId) {
        if (swId == '') {
            //判断是否选择了色板
            swId = checkSelectedObj('swatchlist');
            if (swId == '') {
                alert('抱歉，请选择您要删除的色板！');
                return;
            }
        }

        if ($('.mainbox .pop').size() == 0) {
            var myhtml = showDelBoxHtml('您将对色板进行删除操作，点击“确定”后，该色板将从您的色板列表里消失，不可还原。', swId.toString(), 'delswrecycle', '删除确认');
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

    //还原色板提示
    function showRevertBox(swId) {
        if (swId == '') {
            //判断是否选择了色板
            swId = checkSelectedObj('swatchlist');
            if (swId == '') {
                alert('抱歉，请选择您要还原的色板！');
                return;
            }
        }

        if ($('.mainbox .pop').size() == 0) {
            var myhtml = showDelBoxHtml('您将对这个色板进行还原操作，点击“确定”后，该色板将出来在您的色板列表里。', swId.toString(), 'revertswrecycle', '还原提示');
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
        showDelBox(swId.toString());
    }

    //删除色板
    function doAboutDb(swId, type) {
        $.ajax({
            url: '../ajax/MemberHandler.ashx',
            dataType: 'text',
            data: 'swId=' + swId.toString() + '&Action=' + type.toString() + '&rnd=' + Math.random(),
            success: function (data) {
                if (data == 'success') {
                    cancelCheckBoxChecked('swatchlist');
                    if (type.toString() == 'delswrecycle') {
                        alert('删除色板成功！');
                    } else {
                        alert('还原色板成功！');
                    }
                    location.reload();
                } else if (data == 'fail') {
                    if (type.toString() == 'delswrecycle') {
                        alert('抱歉，系统正忙删除色板失败！');
                    } else {
                        alert('抱歉，系统正忙还原色板失败！');
                    }
                }
            }
        });
    }
   //-->
</script>
</asp:Content>