<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BiYing.aspx.cs" Inherits="TREC.Web.Admin.member.BiYing" %>

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

			function byshow(id) {
			    if (document.getElementById("by" + id).style.display == 'block') {
			        document.getElementById("by" + id).style.display = "none";
			    }
			    else {
			        document.getElementById("by" + id).style.display = "block";
			    }
			  
			}
    </script>
     <style type="text/css">
 .biyingList
 {
     border-style : dotted;
	border-width : 1px;
	border-color : #AAAAAA;
	display:none;
	padding:5px 5px 5px 5px;
	width:100%;
  }
   .biyingList div
   {
       margin:2px 2px 2px 2px;
    }
 </style>
</head>
<body style="padding: 10px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="add"><a href="memberinfo.aspx">添加系列</a></span><b>您当前的位置：首页 &gt; 成员管理 &gt;
            有求必应管理</b>
    </div>
    <div class="spClear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="80" align="center">
                会员类型：
            </td>
            <td width="100" align="left">
                <asp:DropDownList ID="ddlmembertype" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlmembertype_SelectedIndexChanged">
                    <asp:ListItem Value="-1">不限</asp:ListItem>
                    <asp:ListItem Value="false">未审核</asp:ListItem>
                    <asp:ListItem Value="true">已审核</asp:ListItem>
                </asp:DropDownList>
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
            <th align="center" width="160px">
               提交内容
            </th>
            <th align="center" width="160px">
                手机号码
            </th>
            <th align="center" width="160px">
                邮箱或QQ或微信
            </th>
            <th align="center" width="160px">
                联系时间
            </th>
           
            <th align="center" width="160px">
               是否审核
            </th>
             <th align="center" width="160px">
               上传时间
            </th>
            <%--<th align="center" width="160px">最后活动时间</th>--%>
            <th width="80px" align="right" style="padding-left: 5px;">
                查看
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
                       <%#curstring(Eval("Description").ToString(), 20)%>
                    </td>
                    <td align="center">
                        <%#Eval("phone")%>
                    </td>
                     <td align="center">
                        <%#Eval("Msg")%>
                    </td>
                    <td align="center">
                         <%#Eval("Contact_time")%>
                    </td>
                   
                    <td align="center">
                          <%#isshow(Eval("isShow"))%>
                    </td>
                    <td align="center">
                      <%#Convert.ToDateTime( Eval("CreateTime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                    </td>
                   
                    <td align="right" style="padding-left: 5px;" title='<%#Eval("Description")%>'>
                       查看
                    </td>
                </tr>
                <tr id="by<%#Eval("Id")%>" class="biyingList">
                <td colspan="10" style="width:100%;">
                <div>
      <%#Eval("Description")%>
      </div>
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

                    <span class="btn_bg"><asp:LinkButton ID="lbtnshow" runat="server" 
                onclick="lbtnshow_Click">通过审核</asp:LinkButton>
            </span>&nbsp;</div>
    </div>
    </form>
</body>
</html>
