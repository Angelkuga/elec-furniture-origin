<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="memberinfo.aspx.cs" Inherits="TREC.Web.Admin.member.memberinfo" %>

<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            //表单验证JS
            $("#form1").validate({
                //出错时添加的标签
                errorElement: "span",
                showErrors: function (errorMap, errorList) {
                    if (errorList.length > 0) {
                        if ($("#" + errorList[0].element.id).next() != null) {
                            $("#" + errorList[0].element.id).next().remove();
                        }
                    }
                    this.defaultShowErrors();
                },
                success: function (label) {
                    //正确时的样式
                    label.text(" ").addClass("success");
                }
            });
        });
    </script>
    <style type="text/css">
        .formTable
        {
            border: 1px solid #ccc;
        }
        .formTable tr th
        {
            background: #ededed;
            text-align: left;
        }
        .formTable tr td
        {
            border: none;
            padding-top: 8px;
            padding-bottom: 8px;
        }
    </style>
</head>
<body style="padding: 10px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="back"><a href="memberlist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 成员管理 &gt;
            登陆账号管理</b>
    </div>
    <div class="spClear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="3" align="left">
                登陆账号信息
            </th>
        </tr>
        <tr>
            <td width="390px" valign="top">
                <table class="formTable" width="380px">
                    <tr>
                        <th colspan="2">
                            账号信息：
                        </th>
                    </tr>
                    <%if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
                      { %>
                    <tr>
                        <td width="70px" align="right">
                            通&nbsp;行&nbsp;&nbsp;证：
                        </td>
                        <td align="left">
                            <asp:Label ID="lbpassport" runat="server" CssClass="w160"></asp:Label>
                        </td>
                    </tr>
                    <%} %>
                    <tr>
                        <td width="70px" align="right">
                            登陆账号：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtusername" runat="server" CssClass="input required w160"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            登陆密码：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtpassword" runat="server" CssClass="input w160"></asp:TextBox>
                            <asp:HiddenField ID="hfpassword" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            支付密码：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtpaypassword" runat="server" CssClass="input w160"></asp:TextBox>
                            <asp:HiddenField ID="hfpaypassword" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            会&nbsp;员&nbsp;&nbsp;组：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlmembergroup" runat="server" Width="160" CssClass="select selectNone">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div class="spClear">
                </div>
                <%-- <table class="formTable" width="380px">
                    <tr>
                        <th colspan="2">余额信息：</th>
                    </tr>
                    <tr>
	                    <td width="70px" align="right">
		                    短信余额
	                    ：</td>
	                    <td >
		                    <asp:TextBox id="txtsms" runat="server" CssClass="input required w160"></asp:TextBox>
	                    </td></tr>
                    <tr>
                        <td align="right">
                            积分 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtintegral" runat="server" CssClass="input required w160"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            资金金额 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtmoney" runat="server" CssClass="input required w160"></asp:TextBox>
                        </td>
                    </tr>
                </table>--%>
                <div class="spClear">
                </div>
                <%-- <table class="formTable" width="380px">
                    <tr>
                        <th colspan="2">银行信息：</th>
                    </tr>
                    <tr>
                        <td width="76px" align="right">
                            收款银行 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtbank" runat="server" CssClass="input w160"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            收款账号 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtaccount" runat="server" CssClass="input w250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            支付宝账号 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtalipay" runat="server" CssClass="input w160"></asp:TextBox>
                        </td>
                    </tr>
                </table>--%>
                 <table class="formTable" width="380px">
                    <tr>
                        <th colspan="2">充值信息：</th>
                    </tr>
                    <tr>
                        <td width="76px" align="right">
                            充值金额 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtprice" runat="server" CssClass="input w160"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            到期时间 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtRegEndTime" runat="server" CssClass="input Wdate w160"
                                onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="spClear">
                </div>
                <%-- <table class="formTable" width="380px">
                    <tr>
                        <th colspan="2">认证信息：</th>
                    </tr>
                    <tr>
                        <td>
                            <label>邮箱认证 ：</label><asp:RadioButtonList ID="ravemail" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"><asp:ListItem Text="否" Selected="True" Value="0"></asp:ListItem><asp:ListItem Text="是" Value="1"></asp:ListItem></asp:RadioButtonList>
                            <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                            <label>手机认证 ：</label><asp:RadioButtonList ID="ravmobile" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"><asp:ListItem Text="否" Selected="True" Value="0"></asp:ListItem><asp:ListItem Text="是" Value="1"></asp:ListItem></asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>实名认证 ：</label><asp:RadioButtonList ID="ravname" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"><asp:ListItem Text="否" Selected="True" Value="0"></asp:ListItem><asp:ListItem Text="是" Value="1"></asp:ListItem></asp:RadioButtonList>
                            <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                            <label>验证银行 ：</label><asp:RadioButtonList ID="ravbank" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"><asp:ListItem Text="否" Selected="True" Value="0"></asp:ListItem><asp:ListItem Text="是" Value="1"></asp:ListItem></asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>    
                            <label>验证公司 ：</label><asp:RadioButtonList ID="ravcompany" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"><asp:ListItem Text="否" Selected="True" Value="0"></asp:ListItem><asp:ListItem Text="是" Value="1"></asp:ListItem></asp:RadioButtonList>
                            <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                            <label>验证支付 ：</label><asp:RadioButtonList ID="ravalipay" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"><asp:ListItem Text="否" Selected="True" Value="0"></asp:ListItem><asp:ListItem Text="是" Value="1"></asp:ListItem></asp:RadioButtonList>
                        </td>
                    </tr>
                </table>--%>
                <div class="spClear">
                </div>
            </td>
            <td width="380px" valign="top">
                <table class="formTable" width="380px">
                    <tr>
                        <th colspan="2">
                            基本信息：
                        </th>
                    </tr>
                    <tr>
                        <td width="70px" align="right">
                            账号类型：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlmembertype" runat="server" CssClass="w160 selectNone" Width="160">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            真实姓名：
                        </td>
                        <td>
                            <asp:TextBox ID="txttname" runat="server" CssClass="input w160"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            email：
                        </td>
                        <td>
                            <asp:TextBox ID="txtemail" runat="server" CssClass="input w160"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            性别：
                        </td>
                        <td>
                            <asp:RadioButtonList ID="raGender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="女" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            手机 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtmobile" runat="server" CssClass="input w160"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            电话 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtphone" runat="server" CssClass="input w160"></asp:TextBox>
                        </td>
                    </tr>
                    <%-- <tr>
                         <td align="right">
                             msn ：
                         </td>
                         <td>
                             <asp:TextBox ID="txtmsn" runat="server" CssClass="input w160"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right">
                             qq ：
                         </td>
                         <td>
                             <asp:TextBox ID="txtqq" runat="server" CssClass="input w160"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right">
                             skype ：
                         </td>
                         <td>
                             <asp:TextBox ID="txtskype" runat="server" CssClass="input w160"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right">
                             ali ：
                         </td>
                         <td>
                             <asp:TextBox ID="txtali" runat="server" CssClass="input w160"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right">
                             出生日期 ：
                         </td>
                         <td>
                             <asp:TextBox ID="txtbirthdate" runat="server" CssClass="input Wdate w160 required" onfocus="WdatePicker()"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right">
                             地区 ：
                         </td>
                         <td>
                             <asp:TextBox ID="txtareacode" runat="server" CssClass="input w160"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right">
                             详细地址 ：
                         </td>
                         <td>
                             <asp:TextBox ID="txtaddress" runat="server" CssClass="input w160"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right">
                             部门 ：
                         </td>
                         <td>
                             <asp:TextBox ID="txtdepartment" runat="server" CssClass="input w160"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right">
                             职位 ：
                         </td>
                         <td>
                             <asp:TextBox ID="txtcareer" runat="server" CssClass="input w160"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right">
                             提示音 ：
                         </td>
                         <td>
                             <asp:TextBox ID="txtsound" runat="server" CssClass="input w160"></asp:TextBox>
                         </td>
                     </tr>--%>
                </table>
                <div class="spClear">
                </div>
            </td>
            <td valign="top">
                <%if (ECommon.QueryId != "" && ECommon.QueryEdit != "" && ddlmembertype.SelectedValue != ((int)TREC.Entity.EnumMemberType.个人成员).ToString())
                  { %>
               <%-- <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">
                            商务信息：
                        </th>
                    </tr>
                    <tr>
                        <td>
                            名称：<strong> 状态：</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            电话：
                        </td>
                    </tr>
                    <tr>
                        <td>
                            手机：
                        </td>
                    </tr>
                    <tr>
                        <td>
                            邮箱：
                        </td>
                    </tr>
                    <tr>
                        <td>
                            地区：
                        </td>
                    </tr>
                    <tr>
                        <td>
                            地址：
                        </td>
                    </tr>
                </table>--%>
                <div class="spClear">
                </div>
                <%} %>
                <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">
                            注册信息:
                        </th>
                    </tr>
                    <tr>
                        <td width="90px" align="right">
                            注册IP：
                        </td>
                        <td>
                            <asp:TextBox ID="txtregip" runat="server" CssClass="input required w160"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            注册时间：
                        </td>
                        <td>
                            <asp:TextBox ID="txtregtime" runat="server" CssClass="input Wdate w160 required"
                                onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <%if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
                  { %>
                <div class="spClear">
                </div>
                <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">
                            登陆信息:
                        </th>
                    </tr>
                    <tr>
                        <td width="90px" align="right">
                            最后登陆IP：
                        </td>
                        <td>
                            <asp:TextBox ID="txtloginip" runat="server" CssClass="input required w160"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            最后登陆时间：
                        </td>
                        <td>
                            <asp:TextBox ID="txtlogintime" runat="server" CssClass="input Wdate w160 required"
                                onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            登陆次数 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtlogincount" runat="server" CssClass="input w160"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="spClear">
                </div>
                <%-- <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">其它信息：</th>
                    </tr>
                    <tr>
                        <td width="70" align="right">
                            客服专员 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtsupport" runat="server" CssClass="input w160"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            推&nbsp;&nbsp;荐&nbsp;&nbsp;人：
                        </td>
                        <td>
                            <asp:TextBox ID="txtinviter" runat="server" CssClass="input w160"></asp:TextBox>(限定为用户名)
                        </td>
                    </tr>
                    <tr>
                        <td align="right">站内信息：</td><td>消息：<asp:Label ID="lbchat" runat="server"></asp:Label>(条)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;短信：<asp:Label ID="lbmsg" runat="server"></asp:Label>(条)</td>
                    </tr>
                    <tr>
                        <td align="right">更新时间：</td><td><asp:Label ID="lblastedittime" runat="server"></asp:Label></td>
                    </tr>
                </table>--%>
                <%} %>
            </td>
        </tr>
    </table>
    <div style="margin-top: 10px; margin-left: 180px">
        <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" OnClick="btnSave_Click" /><input
            name="重置" type="reset" class="submit" value="重置" />
    </div>
    </form>
</body>
</html>
