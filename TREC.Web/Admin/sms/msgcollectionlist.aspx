<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="msgcollectionlist.aspx.cs"
    Inherits="TREC.Web.Admin.sms.msgcollectionlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="<%="\""+TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/')%>/altdialog/skins/default.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/altdialog/artDialog.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/altdialog/plugins/iframeTools.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../script/admin.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".msgtable tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
            $(".msgtable tr").hover(
			    function () {
			        $(this).addClass("tr_hover_col");
			    },
			    function () {
			        $(this).removeClass("tr_hover_col");
			    }
		    );
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="add"><a href="smssend.aspx">客户报名</a></span><b>您当前的位置：首页 &gt; 促销活动 &gt;
            客户报名信息</b>
    </div>
    <div class="spClear">
    </div>
    <table>
        <tr>
            <td>
                姓名：
            </td>
            <td>
                <asp:TextBox id="txtname" runat="server" style="width:100px;"></asp:TextBox>
            </td>
            <td>
                手机：
            </td>
            <td>
                <asp:TextBox id="txtmobile" runat="server"  style="width:100px;"></asp:TextBox>
            </td>
            <td >
                需求产品 
            </td>
            <td>
                <asp:TextBox id="txtprod" runat="server"  style="width:100px;"></asp:TextBox>
            </td>
            <td>
                验证码：
            </td>
            <td>
                <asp:TextBox id="txtcode" runat="server"  style="width:100px;"></asp:TextBox>
            </td>
            <td>
                活动类型：
            </td>
            <td>
                <asp:DropDownList ID="ddlPromtype" runat="server"></asp:DropDownList>
            </td>
            <td >
                结束时间 
            </td>
            <td>
                <asp:TextBox id="txtstarttime" runat="server"  style="width:100px;"></asp:TextBox>
        <img onclick="WdatePicker({el:'txtstarttime'})" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/My97DatePicker/skin/datePicker.gif" width="16" height="22" style=" cursor:pointer" align="absmiddle">
        </td>
            <td>
        <asp:TextBox id="txtendtime" runat="server"  style="width:100px;"></asp:TextBox>
        <img onclick="WdatePicker({el:'txtendtime'})" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/My97DatePicker/skin/datePicker.gif" width="16" height="22" style=" cursor:pointer" align="absmiddle">
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="submit" Text="提交" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th width="60px" align="center">
                选择
            </th>
            <th width="40px" align="center">
                编号
            </th>
            <th width="60px" align="center">
                姓名
            </th>
            <th align="center" width="60px">
                手机
            </th>
            <th align="center" width="">
                需求产品
            </th>
            <th align="center" width="">
                地址
            </th>
            <th align="center" width="60px">
                验证码
            </th>
            <th align="center" width="160px">
                报名时间
            </th>
            <th width="80px" align="right" style="padding-left: 5px;">
                操作
            </th>
        </tr>
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
                    </td>
                    <td align="center">
                        <asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                    </td>
                    <td align="center">
                        <a href="/admin/member/customerinfo.aspx?edit=1&id=<%#Eval("MID")%>" target="_blank">
                            <%#Eval("name")%></a>
                    </td>
                    <td align="center">
                        <asp:Label ID="lb_status" runat="server" Text='<%#Eval("contact").ToString()%>'></asp:Label>
                    </td>
                    <td align="center">
                        <%#Eval("ProdCon").ToString() != "2" ? "<a href=\"/product/" + Eval("ProdID") + "/info.aspx\" target=\"_blank\">" + Eval("MsgInfo") + "</a>" : "<a href=\""+ECommon.WebUrl+"/productinfotzh.aspx?tid=" + Eval("ProdID") + "\" target=\"_blank\">" + Eval("MsgInfo") + "</a>"%>
                    </td>
                    <td align="center">
                        <%#Eval("UserAddress")%>
                    </td>
                    <td align="center">
                        <asp:Label ID="lb_return_string" runat="server" Text='<%#Eval("code")%>'></asp:Label>
                    </td>
                    <td align="center">
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("createtime")%>'></asp:Label>
                    </td>
                    <td width="80px" align="right" style="padding-left: 5px;">
                        <a href="msgcollectionlist.aspx?edit=2&id=<%#Eval("Id") %>">删除</a> <a href="addmsgcollection.aspx?id=<%#Eval("Id") %>">
                            编辑</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="spClear">
    </div>
    <div style="line-height: 30px; height: 30px;">
        <div id="Pagination" class="right flickr">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="20" AlwaysShow="true" 
                UrlPaging="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页">
            </webdiyer:AspNetPager>
        </div>
        <div class="left">
            <span class="btn_all" onclick="checkAll(this);">全选</span> <span class="btn_bg">
                <asp:LinkButton ID="lbtnDel" runat="server" OnClientClick="return confirm( '确定要删除这些记录吗？ ');"
                    OnClick="lbtnDel_Click">删 除</asp:LinkButton>&nbsp;&nbsp; </span>
        </div>
    </div>
    </form>
</body>
</html>
