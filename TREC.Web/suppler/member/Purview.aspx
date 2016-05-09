<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="Purview.aspx.cs" Inherits="TREC.Web.Suppler.member.Purview" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maintitle"><h1><u>权限管理</u></h1></div>
<div class="maincon">
<!-- 标签切换 begin -->
 <div>
    <div class="cpTitle">
      <ul>
        <li class="tabActive" style="position:relative"><a href="Purview.aspx">修改密码</a></li>
	    <li class="tabNormal" style="position: relative"><a href="UpdateAccount.aspx">修改管理员资料</a></li>
	    <%if (memberInfo.type != 103)
       {%> <li class="tabNormal" style="position: relative"><a href="SettlePurview.aspx">设置店铺管理权限</a></li><%} %>
      </ul> 
    </div>
<div class="cplist"><br />
  <div class="maintabcor">
  <table cellpadding="6" cellspacing="1" class="formTable">
        <tbody id="Tabs1">
            <tr>
                <td class="tl" align="right" style="color:Red;">
                    注：
                </td>
                <td class="tr f_red" style="color:Red;">
                        修改密码成功后必须重新登录系统
                </td>
            </tr>
            <tr>
                <td class="tl" align="right">
                    旧密码：
                </td>
                <td class="tr f_red">
                    <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password" Width="180" CssClass="required input"></asp:TextBox>&nbsp;
                    <span class="lbInfo">*输入您原来的密码!</span>
                </td>
            </tr>
            <tr>
                <td class="tl" align="right">
                    新密码：
                </td>
                <td class="tr  f_red">
                    <asp:TextBox ID="txtNewPwd" runat="server"  TextMode="Password" Width="180" CssClass="required input"></asp:TextBox>
                    <span id="dpassword" class="f_red"></span>
                </td>
            </tr>
            <tr>
                <td class="tl" align="right">
                    重复新密码：
                </td>
                <td class="tr  f_red">
                    <asp:TextBox ID="txtCheckPwd" runat="server"  TextMode="Password" Width="180" CssClass="required input"></asp:TextBox>&nbsp;
                    <span id="dcpassword" class="f_red"></span>
                </td>
            </tr>
        </tbody>
        <tr>
            <td class="tl">
                &nbsp;
            </td>
            <td class="tr  f_red">
                <asp:Button ID="btnEdit" runat="server" Text="保 存" CssClass="submit" OnClientClick="return checkinput();" OnClick="btnEdit_Click" />
                <input type="button" value=" 返 回 " class="submit" onclick="history.back(-1);" />
            </td>
        </tr>
    </table>
  </div>
  </div>
</div>
<!-- 标签切换 end -->
</div>
<script type="text/javascript">
   <!--
    function checkinput() {
        var oldpwd = $("#<%=txtOldPwd.ClientID %>");
        if (oldpwd.val() == "") {
            alert("请输入旧密码");
            oldpwd.focus();
            return false;
        }
        var newpwd = $("#<%=txtNewPwd.ClientID %>");
        if (newpwd.val() == "") {
            newpwd.focus();
            alert("请输入新密码！");
            return false;
        }
        var checkpwd = $("#<%=txtCheckPwd.ClientID %>");
        if (checkpwd.val() == "") {
            checkpwd.focus();
            alert("请再次输入新密码！");
            return false;
        } 
        if (newpwd.val() != checkpwd.val()) {
            alert("两次输入的新密码不一致！");
            return false;
        }
        if (oldpwd.val() == newpwd.val()) {
            alert("旧密码和新密码一样！");
            return false;
        }
        return true;

    }
   //-->
</script>
</asp:Content>