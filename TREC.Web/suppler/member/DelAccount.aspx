<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="DelAccount.aspx.cs" Inherits="TREC.Web.Suppler.member.DelAccount" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/resource/script/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/ymPrompt.js" type="text/javascript"></script>
    <link href="../resource/css/ymPrompt/simple_gray/ymPrompt.css" rel="stylesheet" type="text/css" />
    <script src="../script/myPublic.js" type="text/javascript"></script>
<script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/editor/kindeditor/kindeditor-min.js"></script>
<style type="text/css">
 .pop{position:absolute;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maintitle"><h1><u>权限管理</u></h1></div>
<div class="maincon">
<!-- 标签切换 begin -->
<div>
    <div class="cpTitle">
      <ul>
        <li class="tabNormal" style="position:relative"><a href="Purview.aspx">修改密码</a></li>
	    <li class="tabNormal" style="position: relative"><a href="UpdateAccount.aspx">修改管理员资料</a></li>
	    <li class="tabActive" style="position: relative"><a href="SettlePurview.aspx">设置店铺管理权限</a></li>
      </ul> 
    </div>
    <div class="cplist"><br />
    <div class="msgtable">
      <table width="100%" border="0" id="accountlist" cellpadding="0" cellspacing="0">
        <tr class="titlecor">
          <th>选择</th>
          <th>编号</th>
          <th>账号</th>
          <th>管理店铺</th>
          <th>创建日期</th>
          <th>还原</th>
          <th>删除</th>
        </tr>
        <asp:Repeater ID="RptAccont" runat="server">
           <ItemTemplate>
             <tr>
               <td><input type="checkbox" value="<%#Eval("id")%>" /></td>
              <td><%#getCode(Eval("id").ToString())%></td>
              <td><%#Eval("username")%></td>
              <td>  <%# GetShopName(Eval("shopid"))%></td>
              <td><%#Eval("regtime", "{0:yyyy-MM-dd}")%></td>
              <td><a href="Javascript:void();" onclick="showRevertBox(<%#Eval("id") %>);"><img src="../Images/huanyuan.gif" alt="还原" width="16" height="16" border="0" /></a></td>
              <td><a href="Javascript:void();" onclick="showDelBox(<%#Eval("id")%>);"><img src="../images/del.png" alt="删除" width="16" height="16" border="0" /></a></td>
            </tr>
           </ItemTemplate>
        </asp:Repeater>
      </table>
    </div>
    <%if (!string.IsNullOrEmpty(pageStr)) { Response.Write(pageStr); } %>
    <div class="btmenu">
      <p><a class="bome" id="off" onclick="chkAll(this,'accountlist');">全选</a><a class="bome" onclick="showRevertBox('');">还原</a><a class="bome" onclick="showDelBox('');">删除</a>&nbsp;&nbsp;<a href="SettlePurview.aspx"><span class="lookdel"><img src="../Images/back.gif" alt="返回" width="16" height="16" align="absmiddle" />&nbsp;返回</span></a></p>
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
    function showDelBox(AccountId) {
        if (AccountId == '') {
            //判断是否选择了账号
            AccountId = checkSelectedObj('accountlist');
            if (AccountId == '') {
                alert('抱歉，请选择您要删除的账号！');
                return;
            }
        }

        if ($('.mainbox .pop').size() == 0) {
            var myhtml = showDelBoxHtml('您将对账号进行删除操作，点击“确定”后，该账号将从您的账号列表里消失，不可还原。', AccountId, 'delaccountrecycle', '删除确认');
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

    //还原账号提示
    function showRevertBox(AccountId) {
        if (AccountId == '') {
            //判断是否选择了账号
            AccountId = checkSelectedObj('accountlist');
            if (AccountId == '') {
                alert('抱歉，请选择您要还原的账号！');
                return;
            }
        }

        if ($('.mainbox .pop').size() == 0) {
            var myhtml = showDelBoxHtml('您将对这个账号进行还原操作，点击“确定”后，该账号将出来在您的账号列表里。', AccountId, 'revertaccountrecycle', '还原提示');
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

    function delSingleBrand(AccountId) {
        showDelBox(AccountId);
    }

    //删除账号
    function doAboutDb(AccountId, type) {
        $.ajax({
            url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
            dataType: 'text',
            data: 'AccountId=' + AccountId.toString() + '&type=' + type.toString() + '&rnd=' + Math.random(),
            success: function (data) {
                if (data == 'success') {
                    cancelCheckBoxChecked('accountlist');
                    if (type.toString() == 'delaccountrecycle') {
                        alert('删除账号成功！');
                    } else {
                        alert('还原账号成功！');
                    }
                    location.reload();
                } else if (data == 'fail') {
                    if (type.toString() == 'delaccountrecycle') {
                        alert('抱歉，系统正忙删除账号失败！');
                    } else {
                        alert('抱歉，系统正忙还原账号失败！');
                    }
                }
            }
        });
    }
   //-->
</script>
</asp:Content>