<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPwd.aspx.cs" Inherits="TREC.Web.template.web.Ucenter.ModifyPwd" %>
<%@ Register Src="../ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<%@ Register src="../ascx/Ucenter.ascx" tagname="Ucenter" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link href="/resource/content/css/ucerter.css" rel="stylesheet" type="text/css">
    <link href="/resource/content/css/supplier.css" rel="stylesheet" type="text/css">
   <script src="/resource/content/indexnav/jquery.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:header ID="header1" runat="server" />
    <div class="site"><a href="#">首页</a> &gt; <a href="#">购物车</a> &gt; 用户中心</div>
    <div class="contentInner">
  <div class="inner">
    <div class="supplier">
                            
<uc2:Ucenter ID="Ucenter1" runat="server" />
        

                            <div class="spR">
                                <div class="spBox1">
                                    <div class="sphd">
                                        <span class="s1">密码修改</span></div>
                                    <div class="spbd">
                                        <div class="modifyPwd">
                                            <p class="p0">
                                                密码由6-16个字符组成，为了您的账号安全，请不要使用全数字、全字母或连续字符作为密码。</p>
                                            <div class="d1">
                                                <table width="500" border="0">
                                                    <tbody><tr>
                                                        <td>
                                                            我的旧密码：
                                                        </td>
                                                        <td>
                                                            
                                <asp:TextBox ID="txt_oldpwd" runat="server" TextMode="Password" class="i1 inputcss" MaxLength="30"></asp:TextBox>
                                                            
                                                        </td>
                                                    </tr>
                                                </tbody></table>
                                            </div>
                                            <div class="d2">
                                                <table width="500" border="0">
                                                    <tbody><tr>
                                                        <td>
                                                            新密码：
                                                        </td>
                                                        <td>
                                                             <asp:TextBox ID="txt_pwd1" runat="server" TextMode="Password" class="i1 inputcss" MaxLength="30"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            新密码确认：
                                                        </td>
                                                        <td>
                                                             <asp:TextBox ID="txt_pwd" runat="server" TextMode="Password" class="i1 inputcss" MaxLength="30"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;
                                                            
                                                      </td>
                                                        <td>
                                    <asp:ImageButton ID="bnt_save" ImageUrl="/resource/content/images/ucenter/supplier6.jpg" runat="server" 
                                                                onclick="bnt_save_Click" />
                                                            <input type="image" style="border-width:0px;display:none;" onclick="javascript:return(isNullControl());" src="/resource/content/images/ucenter/supplier6.jpg"  id="btnSave" name="btnSave">
                                                            <input type="image" src="/resource/content/images/ucenter/supplier7.jpg" class="i2" style="display:none;">
                                                      </td>
                                                    </tr>
                                                </tbody></table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
  </div>

</div>
    <ucfooter:footer ID="header2" runat="server" />
    </form>
</body>
</html>
