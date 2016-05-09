<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotionslist.aspx.cs"
    Inherits="TREC.Web.Admin.information.promotionslist" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="Haojibiz.Data" %>
<%@ Import Namespace="Haojibiz.DAL" %>
<%@ Import Namespace="Haojibiz.Model" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js"></script>
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
<body style="padding: 10px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="add"><a href="promotionsinfo.aspx?display=<%=TRECommon.WebRequest.GetString("display") %>">
            添加信息</a></span><b>您当前的位置：首页 &gt; 成员管理 &gt; 登陆账号管理</b>
    </div>
    <div class="spClear">
    </div>
    <table>
        <tr>
            <td>
                审核：
            </td>
            <td>
                <asp:DropDownList ID="ddlauditstatus" runat="server">
                    <asp:ListItem Value="">--请选择--</asp:ListItem>
                    <asp:ListItem Value="-1">正在审核</asp:ListItem>
                    <asp:ListItem Value="0">等待审核</asp:ListItem>
                    <asp:ListItem Value="1">审核通过</asp:ListItem>
                    <asp:ListItem Value="-99">审核未过</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                上/下线：
            </td>
            <td>
                <asp:DropDownList ID="ddllinestatus" runat="server">
                    <asp:ListItem Value="">--请选择--</asp:ListItem>
                    <asp:ListItem Value="0">下线</asp:ListItem>
                    <asp:ListItem Value="1">上线</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="submit" Text="提交" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    <div class="spClear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th width="40px" align="center">
                选择
            </th>
            <th width="40px" align="center">
                编号
            </th>
            <th align="center">
                标题
            </th>
            <th align="center">
                所属会员
            </th>
            <th align="center" width="75px">
                状态
            </th>
            <th align="center" width="75px">
                上/下线
            </th>
            <th align="center" width="160px">
                结束时间
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
                        <a href="promotionsinfo.aspx?display=<%=TRECommon.WebRequest.GetString("display") %>&id=<%#Eval("id") %>">
                            <%#Eval("title") %></a>
                    </td>
                    <td align="center">
                        <%#dpromotions.LinqData<Mmember>().Where(c => c.id == Convert.ToInt32(Eval("mid"))).Select(c => c.username).FirstOrDefault() %>
                    </td>
                    <td align="center" width="75px">
                        <%#GetStatusStrA(Eval("auditstatus"))%>
                    </td>
                    <td align="center" width="75px">
                        <%#GetStatusStr(Eval("linestatus"))%>
                    </td>
                    <td align="center">
                        <%#Eval("enddatetime")%>
                    </td>
                    <td align="right" style="padding-left: 5px;">
                        <a href="promotionsinfo.aspx?display=<%=TRECommon.WebRequest.GetString("display") %>&id=<%#Eval("id") %>">
                            修改</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="spClear">
    </div>
    <div style="line-height: 30px; height: 30px;">
        <div id="Pagination" class="right flickr">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true" UrlPaging="true"
                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页">
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
