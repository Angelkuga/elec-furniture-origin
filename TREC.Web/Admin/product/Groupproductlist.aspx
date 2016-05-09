<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Groupproductlist.aspx.cs"
    Inherits="TREC.Web.Admin.product.Groupproductlist" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
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
            $("#selALL").click(function () {
                if ($("#selALL").attr("checked") == "checked")
                    $("input[type='checkbox']").attr("checked", true);
                else
                    $("input[type='checkbox']").attr("checked", false);
            });
        })
       
    </script>
</head>
<body style="padding: 10px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <b>您当前的位置：首页 &gt; 产品管理 &gt; 产品管理</b>
    </div>
    <div class="spClear">
    </div>
    <table>
        <tr>
            <td>
                大类：
            </td>
            <td>
                <asp:DropDownList ID="ddlproductcategory" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                品牌：
            </td>
            <td>
                <asp:DropDownList ID="ddlbrand" runat="server">
                </asp:DropDownList>
            </td>
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
                活动：
            </td>
            <td>
                <asp:DropDownList ID="ddlPT" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                推荐属性：
            </td>
            <td>
                <asp:DropDownList ID="ddlattribute" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                名称：
            </td>
            <td>
                <asp:TextBox ID="txtProductName" runat="server" CssClass="input"></asp:TextBox>
            </td>
            <td>
                <span class="btn_bg">
                    <asp:LinkButton ID="lkBtnSearch" runat="server" OnClick="lkBtnSearch_Click">查 找</asp:LinkButton>&nbsp;&nbsp;
                </span>
            </td>
        </tr>
    </table>
    <div class="spClear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th width="40px" align="center">
                <input id="selALL" type="checkbox" />
            </th>
            <th width="40px" align="center">
                编号
            </th>
            <th align="left">
                套组合名称
            </th>
            <th align="center" width="80">
                大类ID
            </th>
            <th>
                描述
            </th>
            <th align="center" width="160px">
                最后活动时间
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
                        <asp:Label ID="lb_id" runat="server" Text='<%#Eval("gpId")%>'></asp:Label>
                    </td>
                    <td align="center">
                        <%#Eval("Name")%>
                    </td>
                    <td align="left">
                        <%#Eval("bigCateId")%>
                    </td>
                    <td align="center">
                        <%#Eval("Descript")%>
                    </td>
                    <td align="center">
                        <%#Eval("ModifyTime")%>
                    </td>
                    <td align="right" style="padding-left: 5px;">
                        <a href="groupproductinfo.aspx?edit=1&id=<%#Eval("gpId") %>" target="_blank">修改</a><%--|<a href="productlist.aspx?edit=2&id=<%#Eval("id") %>"
                            onclick="confirm(是否确认删除该产品)">删除</a>--%>
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
            <span class="btn_bg">
                <asp:LinkButton ID="lbtnDel" runat="server" OnClientClick="return confirm( '确定要删除这些记录吗？ ');"
                    OnClick="lbtnDel_Click">删 除</asp:LinkButton></span> <span class="btn_bg">
                        <asp:LinkButton ID="linkGo" runat="server" OnClientClick="return confirm( '确定要审核通过并且上线这些记录吗？ ');"
                            OnClick="linkGo_Click">审核通过并且上线</asp:LinkButton></span> <span class="btn_bg">
                                <asp:LinkButton ID="lonkNo" runat="server" OnClientClick="return confirm( '确定要下线这些记录吗？ ');"
                                    OnClick="lonkNo_Click">下线并且未通过审核</asp:LinkButton></span>
        </div>
    </div>
    </form>
</body>
</html>
