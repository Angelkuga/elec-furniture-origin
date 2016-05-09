<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IpAddressPage.aspx.cs" Inherits="TREC.Web.Admin.brand.IpAddressPage" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Import Namespace="TREC.ECommerce" %>
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
        <span class="add"><a href="ipaddresspage.aspx">新增</a></span><b>您当前的位置：首页 &gt; 成员管理 &gt;
            IP地址管理</b>
    </div>
    <div class="spClear">
    </div>

    <table>
    <tr><td>二级域名 </td><td> <asp:TextBox ID="txt_ip" runat="server"></asp:TextBox> </td> 
    <td>对应地址：</td><td> <asp:TextBox ID="txt_url" runat="server"></asp:TextBox>  </td>
    <td>商家名称：</td><td> <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>  </td>
    <td><asp:Button ID="bnt_save" runat="server" Text="添加" onclick="bnt_save_Click" CssClass="submit"/>
        </td>
    </tr>
    </table>
    <table>
        <tr>
            
            
            
            
            <td>
                 <label>
                    二级域名/商家名称：</label><asp:TextBox ID="txt_search" runat="server" CssClass="input"></asp:TextBox>
            </td>
            
            <td>
               
                <asp:Button ID="btnSearch" runat="server" CssClass="submit" Text="查询" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    
    <div class="spClear">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                二级域名
            </th>
       
         <th align="center">
                商家
            </th>
              <th align="center">
                跳转地址
            </th>
            <th align="center" width="160px">
                添加时间
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
                        
                            <%#Eval("Ip")%>
                    </td>
                        <td align="center">
                        
                            <%#Eval("Companyname")%>
                    </td>
                    
                        <td align="center">
                        
                            <%#Eval("Url")%>
                    </td>
                    
                    
                    
                    <td align="center">
                        <%#Eval("CreateTime")%>
                    </td>
                    <td align="right" style="padding-left: 5px;">
                        <a href="IpAddressPage.aspx?id=<%#Eval("id") %>">修改</a><%--|<a href="brandlist.aspx?edit=2&id=<%#Eval("id") %>">删除</a>--%></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="spClear">
    </div>
    <div style="line-height: 30px; height: 30px;">
        <div id="Pagination" class="right flickr">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true" UrlPaging="false"
                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" 
                onpagechanging="AspNetPager1_PageChanging">
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
