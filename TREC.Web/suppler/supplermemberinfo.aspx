<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supplermemberinfo.aspx.cs" Inherits="TREC.Web.Suppler.supplermemberinfo" %>
<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link rel="stylesheet" type="text/css" href=<%="\""+TREC.ECommerce.ECommon.WebSupplerResourceUrl%>/altdialog/skins/default.css" />
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.inputlabel.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/altdialog/artDialog.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/altdialog/plugins/iframeTools.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/fileupload.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="script/formValidator-4.1.1.js" charset="UTF-8"></script>
    <script type="text/javascript" src="script/formValidatorRegex.js" charset="UTF-8"></script>
    <script type="text/javascript" src="script/supplercommon.js"></script>
    <script type="text/javascript" src="script/pageValitator/dealeraddbrand.js"></script>
   
    <style>
        .aui_buttons{padding:3px 0px;}
    </style>
</head>
<body style=" background:url(images/kefu.gif)  no-repeat; background-position:bottom; background-position:right;">
<form id="form1" runat="server">
<table class="formTable" style="width:100%; height:310px; border:0px;">
            <tr>
                <td valign="top" align="right" width="90px" style="height:28px;">
                <%if (Request.QueryString["v"] != null) { %><%=TRECommon.WebRequest.UrlDecode(Request.QueryString["v"]).ToString()%><%} %>名称：</td>
                <td  valign="top"><asp:TextBox ID="txtctitle" runat="server" CssClass="input required"></asp:TextBox>
                <div id="txtctitleTip"  style="width:200px; float:left" class="forTip" ></div> 
                </td>
            </tr>
             <tr>
                <td valign="top" align="right" width="90px" style="height:28px;">联系人：</td>
                <td><asp:TextBox ID="txtlinkman" runat="server" CssClass="input required"></asp:TextBox>
                <div id="txtlinkmanTip"  style="width:200px; float:left" class="forTip" ></div> 
                </td>
            </tr>
            <tr>
                <td valign="top" align="right" width="90px" style="height:28px;">联系QQ：</td>
                <td><asp:TextBox ID="txtqq" runat="server" CssClass="input required"></asp:TextBox>
                <div id="txtqqTip"  style="width:200px; float:left" class="forTip" ></div> 
                </td>
            </tr>
            <tr>
                <td valign="top" align="right" width="90px"  style="height:28px;">职位：</td>
                <td valign="top"><asp:TextBox ID="txtzhiwei" runat="server" CssClass="input required"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top" align="right" width="90px"  style="height:28px;">电话：</td>
                <td  valign="top"><asp:TextBox ID="txtphone" runat="server" CssClass="input"></asp:TextBox>
                <div id="txtphoneTip"  style="width:200px; float:left" class="forTip" ></div> 
                </td>
            </tr>
            <tr>
                <td valign="top" align="right" width="90px"  style="height:28px;">手机：</td>
                <td  valign="top"><asp:TextBox ID="txtmphone" runat="server" CssClass="input digits" maxlength="11" MinLength="11"></asp:TextBox>
                <div id="txtmphoneTip"  style="float:left" class="forTip" ></div> 
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">邮箱：</td>
                <td  valign="top"><asp:TextBox ID="txtemail" runat="server" CssClass="input email"></asp:TextBox>
                <div id="txtemailTip"  style="width:200px; float:left" class="forTip" ></div> 
                </td>
            </tr>
           
        </table>
        <div class="aui_buttons"><asp:Button ID="btn" runat="server" Text="提交" 
                            CssClass="aui_state_highlight" onclick="btn_Click" /></div>
</form>
 <script type="text/javascript">
     $(function () {
         //表单验证JS
         //            $("#form1").validate({
         //                //出错时添加的标签
         //                errorElement: "span",
         //                showErrors: function (errorMap, errorList) {
         //                    if (errorList.length > 0) {
         //                        if ($("#" + errorList[0].element.id).next() != null) {
         //                            $("#" + errorList[0].element.id).next().remove();
         //                        }
         //                    }
         //                    this.defaultShowErrors();
         //                },
         //                success: function (label) {
         //                    //正确时的样式
         //                    label.text(" ").addClass("success");
         //                }
         //            });


         $("#txtctitle").formValidator({ onShow: "请输入名称", onFocus: "请输入名称", onCorrect: "正确" }).inputValidator({ min: 3, onError: "名称输入不正确" });
         $("#txtlinkman").formValidator({ onShow: "请输入联系人", onFocus: "请输入联系人", onCorrect: "正确" }).inputValidator({ min: 3, onError: "联系人输入不正确" });
         $("#txtphone").formValidator({ onShow: "请输入你的联系电话", onFocus: "格式例如：021-88888888", onCorrect: "输入正确" }).regexValidator({ regExp: "(^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$)|(^(4[0]{2})+(\-[0-9]{3})+(\-[0-9]{4})?$)|(^(4[0]{2})+([0-9]{7})?$)|(^1[3|4|5|6|7|8|9][0-9]{9}$)", onError: "你输入的联系电话格式不正确" });
         $("#txtemail").formValidator({ empty: true, onShow: "请输入邮箱", onFocus: "请正确输入您的电子邮箱", onCorrect: "恭喜你,你输对了" }).inputValidator({ min: 6, max: 100, onError: "你输入的邮箱长度非法,请确认" }).regexValidator({ regExp: "^([\\w-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([\\w-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$", onError: "你输入的邮箱格式不正确" });
         $("#txtqq").formValidator({ empty: true, onShow: "请输入你的联系QQ", onFocus: "格式例如：123456789", onCorrect: "输入正确" }).regexValidator({ regExp: "^[0-9]{3,13}$", onError: "你输入的联系QQ格式不正确" });

     })
    </script>
</body>
</html>
