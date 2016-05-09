<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newslist.aspx.cs" Inherits="TREC.Web.Suppler.information.newslist" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../script/supplercommon.js"></script>
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
<body style="height:auto;">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th width="40" align="center">
                选择
            </th>
            <th width="40" align="center">
                编号
            </th>
            <th align="left">
                新闻标题
            </th>
            <th width="50" align="center">
                状态
            </th>
            <th width="50" align="center">
                上线
            </th>
            <th width="50" align="center">
                操作
            </th>
        </tr>
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
            <tr>
                <td width="40" align="center">
                    <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
                </td>
                <td width="40" align="center">
                    <asp:Label ID="lb_id" runat="server" Text='<%#Eval("id")%>'></asp:Label>
                </td>
                <td align="left">
                    <a href="newsinfo.aspx?id=<%#Eval("id") %>"><%#Eval("title") %></a>
                </td>
                <td width="50" align="center">
                    <%#GetStatusStr(Eval("auditstatus")) %>
                </td>
                <td width="50" align="center">
                    <%#GetStatusStr(Eval("linestatus")) %>
                </td>
                <td width="50" align="center">
                    <a href="newsinfo.aspx?id=<%#Eval("id") %>">修改</a>
                </td>
            </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="listButtom">
        <div class="pages" style="float:right; width:80%; margin-top:0;">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" 
                    NextPageText="下一页" PrevPageText="上一页" HorizontalAlign="Right"></webdiyer:AspNetPager>
        </div>
        <span class="btn_bg" onclick="checkAll(this);"><a href="javascript:;">全选</a></span>
        <span class="btn_bg">
            <asp:LinkButton ID="lbtnDel" runat="server" OnClick="lbtnDel_Click"  OnClientClick="return confirm( '确定要删除这些记录吗？ ');" >删 除</asp:LinkButton>&nbsp;&nbsp; 
        </span>
    </div>
    </form>
</body>
</html>
