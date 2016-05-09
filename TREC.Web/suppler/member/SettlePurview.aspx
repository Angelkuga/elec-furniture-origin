<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="SettlePurview.aspx.cs" Inherits="TREC.Web.Suppler.member.SettlePurview" %>

<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/ymPrompt.js" type="text/javascript"></script>
    <link href="../resource/css/ymPrompt/simple_gray/ymPrompt.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../script/myPublic.js"></script>
<script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/editor/kindeditor/kindeditor-min.js"></script>
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
    <input type="button" class="btnadd marbtm" onclick="CreateAccount('','');" value="创建新账号" />
    <div class="msgtable">
      <table width="100%" border="0" id="accountlist" cellpadding="0" cellspacing="0">
        <tr class="titlecor">
          <th>选择</th>
          <th>编号</th>
          <th>账号</th>
          <th>管理店铺</th>
          <th>创建日期</th>
          <th>编辑</th>
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
              <td><a href="Javascript:void();" onclick="CreateAccount(<%#Eval("id")%>,'<%#Eval("username")%>/<%#Eval("shopid")%>');"><img src="../images/bianji.png" alt="编辑" width="16" height="16" border="0" /></a></td>
              <td><a href="Javascript:void();" onclick="showDelBox(<%#Eval("id")%>);"><img src="../images/del.png" alt="删除" width="16" height="16" border="0" /></a></td>
            </tr>
           </ItemTemplate>
        </asp:Repeater>
      </table>
    </div>
    <%if (!string.IsNullOrEmpty(pageStr)) { Response.Write(pageStr); } %>
    <div class="btmenu">
      <p><a class="bome" id="off" onclick="chkAll(this,'accountlist');">全选</a><a class="bome" onclick="CreateAccount('','');">添加</a><a class="bome" onclick="showDelBox('');">删除</a>&nbsp;&nbsp;<span class="lookdel"><img src="../images/ljt.gif" alt="回收站" width="11" height="13" align="absmiddle" />&nbsp;<a href="DelAccount.aspx">&nbsp;查看已删除账号</a></span></p>
  </div>        
</div>
</div>
<!-- 标签切换 end -->
</div>
<script type="text/javascript">
   <!--
        //弹出的删除提示框始终位于屏幕中间
        $(window).scroll(function () {
            if ($('.mainbox .pop').size() != 0) {
                $('.mainbox .pop').css('top', ($(window).height() - $('.mainbox .pop').height()) / 2 + $(document).scrollTop() + 'px');
                $('.mainbox .pop').css('left', ($(window).width() - $('.mainbox .pop').width()) / 2 + 'px');
            }
        });

        function showDelBox(accountId) {
            if (accountId == '') {
                //判断是否选择了品牌
                accountId = checkSelectedObj('accountlist');
                if (accountId == '') {
                    alert('抱歉，请选择您要删除的账号！');
                    return;
                }
            }

            if ($('.mainbox .pop').size() == 0) {
                var myhtml = showDelBoxHtml('您将把这个账号从这里移除，点击右下角的“查看已删除账号”可进行还原。', accountId, '', '删除确认');
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

        //创建账号
        function CreateAccount(accountId,gp) {
            var myhtml = AccountHtml(accountId);
            $(myhtml).insertAfter($('.mainbox .maincon'));
            $('.mainbox .pop').css('top', ($(window).height() - $('.mainbox .pop').height()) / 2 + $(document).scrollTop() + 'px');
            $('.mainbox .pop').css('left', ($(window).width() - $('.mainbox .pop').width()) / 2 + 'px');
            $('.pop i').click(function () {
                hideDelBox();
            });
            $('.pop .btnlitr').click(function () {
                hideDelBox();
            });
            var userName = '', shopId = '';
            if (gp != '') {
                userName = gp.toString().substring(0, gp.toString().indexOf('/'));
                shopId = gp.toString().substring(gp.toString().lastIndexOf('/')+1);
            }
            if (userName != '') {
                $('#userName').val(userName).attr('disabled', 'disabled');
            }
            //店铺下拉菜单
            $.ajax({
                url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                dataType: 'html',
                data: 'type=queryshoplist&rnd=' + Math.random(),
                success: function (data) {
                    $(data).appendTo($('#myshop'));
                    if (shopId != '') {
                        $('#myshop option[value=' + shopId.toString() + ']').attr('selected',true);
                    }
                }
            });
        }

        function AccountHtml(accountId) {
            var myhtml = '<div class="pop bord"><h1><u>添加账号</u><i>X</i></h1>';
            myhtml += '<div class="popcon"><table width="100%" border="0" cellpadding="0" cellspacing="0">';
            myhtml += '<tr><td width="28%" height="35" align="right">账号名称</td><td width="72%"><input type="text" id="userName" maxlength="20" /></td></tr>';
            myhtml += '<tr><td height="35" align="right">账号密码</td><td><input type="password" id="newpassword" /></td></tr>';
            myhtml += '<tr><td height="35" align="right">重复密码</td><td><input type="password" id="cfpassword" /></td></tr>';
            myhtml += '<tr><td height="35" align="right">管理店铺</td><td><select id="myshop" style="width:160px;"><option value="">请选择</option></select></td></tr>';
            myhtml += '</table>';
            myhtml += '<div class="btnone"><input type="button" onclick="SaveAccountDb(\''+accountId.toString()+'\');" class="btnlitl" value="确定" /><input name="button" type="button" value="取消" class="btnlitr" /></div>';
            myhtml += '</div></div>';
            return myhtml;
        }

        //保存账号
        function SaveAccountDb(accountId) {
            var userName = $.trim($('#userName').val());
            if (userName == '') {
                alert('抱歉，请输入账号名称！');
                $('#userName').focus();
                return;
            }
            //判断账号是否存在
            $.ajax({
                url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                data: 'type=checkname&v=' + userName + "&t=seek&ram=" + Math.random(),
                dataType: 'text',
                success: function (data) {
                    if (data == "true") {
                        alert("您输入的登录账号名称已经存在，请更换!");
                        $('#userName').select();
                          return;                                
                    }
                }
            });
            var newpassword = $.trim($('#newpassword').val());
            if (newpassword == '') {
                alert('抱歉，请输入账号密码！');
                $('#newpassword').focus();
                return;
            }
            var cfpassword = $.trim($('#cfpassword').val());
            if (cfpassword == '') {
                alert('抱歉，请输入重复密码！');
                $('#cfpassword').focus();
                return;
            }
            if (newpassword.toString() != cfpassword.toString()) {
                alert('抱歉，两次输入的密码不一致！');
                $('#cfpassword').focus();
                return;
            }
            var myshop = $.trim($('#myshop option:selected').val());
            if (myshop == '') {
                alert('抱歉，请选择管理店铺！');
                $('#myshop').focus();
                return;
            }
            var db = 'type=saveaccountdb&AccountId=' + accountId.toString() + '&Account=' +escape(userName.toString()) + '&password=' + newpassword.toString() + '&shopId=' + myshop.toString() + '&rnd=' + Math.random();
            $.ajax({
                url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                dataType: 'text',
                data: db,
                success: function (data) {
                    if (data != null) {
                        if (data == 'success') {
                            alert('保存账号数据成功！');
                            location.reload();
                        } else {
                            alert('抱歉，系统正忙请稍后保存账号数据！');
                        }
                    }
                }
            });
        }

        //删除账号到回收站
        function doAboutDb(AccountId, type) {
            var db = 'type=delaccount&AccountId=' + AccountId.toString() + '&rnd=' + Math.random();
            $.ajax({
                url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                dataType: 'text',
                data: db,
                success: function (data) {
                    if (data != null) {
                        if (data == 'success') {
                            cancelCheckBoxChecked('accountlist');
                            alert('删除账号成功！');
                            location.reload();
                        } else {
                            alert('抱歉，系统正忙请稍后删除账号！');
                        }
                    }
                }
            });
        }
   //-->
</script>
</asp:Content>