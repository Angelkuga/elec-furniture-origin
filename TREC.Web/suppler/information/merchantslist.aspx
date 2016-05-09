<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="merchantslist.aspx.cs" Inherits="TREC.Web.Suppler.information.merchantslist" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

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
<body style="height:auto">
<form id="form1" runat="server">
<div class="spClear">
    </div>
    <table>
        <tr>
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
                名称：
            </td>
            <td>
                <asp:TextBox ID="txttitle" runat="server" CssClass="input"></asp:TextBox>
            </td>
            <td>
                <span class="btn_bg">
                    <asp:LinkButton ID="lkBtnSearch" runat="server" 
                    onclick="lkBtnSearch_Click" >查 找</asp:LinkButton>&nbsp;&nbsp;
                </span>
            </td>
        </tr>
    </table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
    <tr>
    <th width="40px" align="center">选择</th>
    <th width="40px" align="center">编号</th>
    <th align="left"  width="160px">&nbsp;&nbsp;标题 </th>
    <th align="left"  width="200px">&nbsp;&nbsp;状态</th>
    <th align="left"  width="200px">&nbsp;&nbsp;上/下线</th>
    <th align="left">&nbsp;&nbsp;留言数量</th>
    <th align="left">&nbsp;&nbsp;最后活动时间</th>
    </tr>
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr>
            <td align="center" style="height:100px; line-height:100px;"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
            <td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
            <td align="center">
                 <a href="merchantsinfo.aspx?edit=1&id=<%#Eval("id") %>">
                            <%#Eval("title")%></a>
            </td>
            <td align="left" class="edit l">
             <%#GetStatusStrA(Eval("auditstatus"))%>
            </td>
             <td align="left" class="edit l">
             <%#GetStatusStr(Eval("linestatus"))%>
             </td>
            <td align="left" class="l"><%#Eval("Membercount")%></td>
            <td align="left" class="l"><%#Eval("Lastedittime")%></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
<div class="listButtom">
        <span class="btn_bg" onclick="checkAll(this);"><a href="javascript:;">全选</a></span>
        <span class="btn_bg">
            <asp:LinkButton ID="lbtnDel" runat="server"  OnClientClick="return confirm( '确定要删除这些记录吗？ ');" OnClick="lbtnDel_Click" >删 除</asp:LinkButton>&nbsp;&nbsp;     
        </span>
        <span class="btn_bg"><asp:LinkButton ID="lkBtnAdd" runat="server" 
            onclick="lkBtnAdd_Click">添加</asp:LinkButton></span>
        <div class="pages">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" UrlPaging="true" 
                    FirstPageText="首页" LastPageText="尾页" 
                    NextPageText="下一页" PrevPageText="上一页">
                </webdiyer:AspNetPager>
        </div>
</div>
</form>
</body>
</html>
