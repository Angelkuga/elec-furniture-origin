<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="UpdateAccount.aspx.cs" Inherits="TREC.Web.Suppler.member.UpdateAccount" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Import Namespace="TREC.ECommerce" %>

<%@ Import Namespace="TREC.Entity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/suppler/script/formValidatorRegex.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maintitle"><h1><u>权限管理</u></h1></div>
<div class="maincon">
<!-- 标签切换 begin -->
 <div>
    <div class="cpTitle">
      <ul>
        <li class="tabNormal" style="position:relative"><a href="Purview.aspx">修改密码</a></li>
	    <li class="tabActive" style="position: relative"><a href="UpdateAccount.aspx">修改管理员资料</a></li>
	   <%if (memberInfo.type != 103)
      {%>   <li class="tabNormal" style="position: relative"><a href="SettlePurview.aspx">设置店铺管理权限</a></li><%} %>
      </ul> 
    </div>
   <div class="cplist"><br />
  <div class="maintabcor">
  <table width="100%" border="0" cellpadding="0" cellspacing="0">
    <%if (model != null)
      { %>
    <tr>
      <td width="18%" height="40" align="right">&nbsp;联系人</td>
      <td width="34%"><label>
        <input id="Contact" type="text" value="<%=model.tname %>" maxlength="20" />
        </label>      </td>
      <td width="8%" align="right">职位</td>
      <td width="40%"><label>
        <input id="Duty" type="text" value="<%=model.career %>" maxlength="50" />
        </label>
      </td>
    </tr>
    <tr>
      <td height="40" align="right">&nbsp;手机</td>
      <td><input id="Mobile" type="text" value="<%=model.mobile %>" maxlength="20" /></td>
      <td align="right">电话</td>
      <td><input id="Tel" type="text" value="<%=model.phone %>" maxlength="20" /></td>
    </tr>
    <tr>
      <td height="40" align="right">QQ/微博</td>
      <td><label>
        <input id="QQWeiBo" type="text" value="<%=model.qq %>" maxlength="100" />
        <br />
      </label></td>
      <td align="right">E-mail</td>
      <td><label>
        <input id="Email" type="text" value="<%=model.email %>" maxlength="50" />
      </label></td>
    </tr><%model = null;} %>
  </table>
  <br />
  <div class="btnone bordtop">
    <input type="button" class="btnl" value="保 存" />
  </div>
</div>
<div class="msgtable"></div>
	</div>
  </div>
<!-- 标签切换 end -->
</div>
<script type="text/javascript">
   <!--
    $(function () {
        $('.btnl').click(function () {
            var obj = this;
            //联系人
            var Contact = $.trim($('#Contact').val());
            if (Contact == '') {
                alert('抱歉，请输入联系人！');
                $('#Contact').focus();
                return;
            }
            //手机、电话
            var Mobile = $.trim($('#Mobile').val());
            var Tel = $.trim($('#Tel').val());
            if (Tel == '' && Mobile == '') {
                alert('抱歉，电话跟手机至少输入一处，请输入！');
                $('#Mobile').focus();
                return;
            }

            var cfr = false;
            var reg = null;
            if (Mobile != "") {
                reg = new RegExp(regexEnum.mobile);
                cfr = reg.test(Mobile);
            }

            if (!cfr && Tel != '') {
                reg = new RegExp(regexEnum.tel);
                cfr = reg.test(Tel);
            }

            if (!cfr) {
                if (Mobile != '') {
                    alert('抱歉，您输入正确的手机号码！');
                    $('#Mobile').focus();
                    return;
                }

                if (Tel != '') {
                    alert('抱歉，您输入正确的电话号码！');
                    $('#Tel').focus();
                    return;
                }
            }

            var Email = $.trim($('#Email').val());
            if (Email == '') {
                alert('抱歉，请输入E-mail！');
                $('#Email').focus();
                return;
            }

            reg = new RegExp(regexEnum.email);
            cfr = reg.test(Email);
            if (!cfr) {
                alert('抱歉，请输入正确的E-mail！');
                $('#Email').focus();
                return;
            }

            //职位
            var Duty = $.trim($('#Duty').val());
            //QQ/微博
            var QQWeiBo = $.trim($('#QQWeiBo').val());
            var db = 'type=updatebasicdb&Contact=' + escape(Contact.toString()) + '&Duty=' + escape(Duty.toString()) + '&Mobile=' + Mobile.toString() + '&';
            db += 'Tel=' + Tel.toString() + '&QQWeiBo=' + QQWeiBo.toString() + '&Email=' + Email.toString() + '&rnd=' + Math.random();
            $(obj).attr('disabled', 'disabled').val('修改中');
            $.ajax({
                url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                dataType: 'html',
                data: db,
                success: function (data) {
                    $(obj).removeAttr('disabled').val('保 存');
                    if (data == 'success') {
                        alert('修改资料成功！');
                    } else {
                        alert('抱歉，系统正忙修改资料失败！');
                    }
                }
            });
        });
    });
   //-->
</script>
</asp:Content>