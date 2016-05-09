<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="../Member.Master"  CodeBehind="dealerproductlist.aspx.cs" Inherits="TREC.Web.Suppler.product.dealerproductlist" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" language="javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.poshytip.min.js"></script>
    <script type="text/javascript" src="../script/supplercommon.js"></script>
    <script type="text/javascript" src="../resource/script/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <script type="text/javascript" src="../resource/script/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <link rel="Stylesheet" type="text/css" href="../resource/script/fancybox/jquery.fancybox-1.3.4.css" />

    <script src="../script/supplercommon.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("tr[isEdit='False']").poshytip();
        });

        $(function () {
            $("a[name = various3]").fancybox({
                'width': '75%',
                'height': '75%',
                'autoScale': false,
                'transitionIn': 'none',
                'transitionOut': 'none',
                'type': 'iframe'
            });
        });
        //select all
        function chkboxAll(th) {
           // alert($(".msgtable").find("input[type=checkbox]").length);
            if ($(".msgtable").find("input[type=checkbox]:checked").length > 0) {
                $(".msgtable").find("input[type=checkbox]").attr('checked', false);
                $(th).text("全选")
            } else {

                $(".msgtable").find("input[type=checkbox]").attr('checked', "checked");
                $(th).text("取消")
            }
        }
        //是否删除
        function checkDel(obj) {            
            if ($("." + obj).find("input[type=checkbox]:checked").length > 0) {
                if (confirm("确定要删除吗？")) {
                    return true;
                } else {
                return false;
                }
        } else {
        alert("请选择要删除的项");
                return false;
            } 
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
    <tr>
        <td>分类：</td><td><asp:DropDownList ID="ddlproductcategory" runat="server"></asp:DropDownList></td>
        <td>品牌：</td><td><asp:DropDownList ID="ddlbrand" runat="server"></asp:DropDownList></td>
        <td>名称：</td><td><asp:TextBox ID="txtProductName" runat="server" CssClass="input"></asp:TextBox></td>
        <td><span class="btn_bg">
        <%--<input type="button" value="查 找" class="btnadd marbtm" onclick="lkBtnSearch_Click"   runat="server" name="button2">--%>
          <asp:LinkButton ID="lkBtnSearch" runat="server" onclick="lkBtnSearch_Click" >查 找</asp:LinkButton>&nbsp;&nbsp;    
        </span>
        <span class="btn_bg">
         <input type="button" value="添加新产品" class="btnadd marbtm" onclick="location.href='productinfo.aspx';" name="button2">
            <%--<asp:LinkButton ID="lkBtnAdd" runat="server" CssClass="btnadd marbtm" onclick="lkBtnAdd_Click">添加</asp:LinkButton>&nbsp;&nbsp;     --%>
        </span></td>
    </tr>
</table>



<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
    <tr>
    <th width="40px" align="center"><a  onclick="chkboxAll(this);">选择</a></th>
    <th width="50px" align="center">编号</th>
    <th align="center" width="80">分类</th>
    <th align="center" width="120">图片</th>
    <th align="left"  width="230" class="l">名称</th>
    <th align="center" width="100">尺寸</th>
    <%--<th align="center" width="80">品牌</th>
    <th align="center" width="80">上传日期</th>
    <th align="center" width="80">最后修改日期</th>--%>
    <th align="center" width="80">销量</th>
    <th align="center" width="80">库存</th>
     <th align="center" width="50">状态</th>
    <th align="center" width="60">上下线</th>

    <th align="center" width="50">操作</th>
    </tr>
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr isEdit="<%#GetEdit(Eval("createmid").ToString()) %>" title='<%#!GetEdit(Eval("createmid").ToString())?Eval("HtmlProductName").ToString()+"&nbsp;&nbsp;不是您创建的，可查看，不可编辑删除":""%>'>
            <td align="center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" Enabled='<%#GetEdit(Eval("createmid").ToString()) %>' />
            <asp:Label ID="lb_pid" style="display:none" runat="server" Text='<%#Eval("id")%>'></asp:Label>
            </td>
            <td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("sku")%>'></asp:Label></td>
            <td align="center"><a href="#"><%#Eval("categorytitle")%></a></td>
            <td align="center" style="height:70px; line-height:70;"><a href="productinfo.aspx?edit=1&id=<%#Eval("id") %>"><img width="105" height="60" src='<%#TREC.Entity.EnFilePath.GetProductThumbPath(Eval("id") != null ? Eval("id").ToString() : "", Eval("thumb") != null ? Eval("thumb").ToString() : "","upload") %>' /></a></td>
            <td align="left" class="l edit"><a href="productinfo.aspx?edit=1&id=<%#Eval("id") %>"><%#Eval("HtmlProductName")%></a></td>
             <td align="center">
             <%#getProductSize(Eval("Id")) %>
            <%--<%#GetWebProduct(Eval("Id"))%>--%>
            </td>
             <td><%#Eval("Sale")%></td>
              <td><%#Eval("Stock").ToString() == "-1" ? "长期供应" : Eval("Stock").ToString()%></td>
          <%--  <td align="center"><%#Eval("brandtitle")%></td>
            <td align="center"><%#Eval("Createtime", "{0:g}")%></td>
            <td align="center"><%#Eval("lastedittime", "{0:g}")%></td>--%>
            <td align="center"><%#GetStatusStr(Eval("auditstatus"))%></td>
            <td align="center"><%#Eval("linestatus").ToString()=="0"?"下线":"上线"%></td>
<%--            <td align="center"><%#Eval("stylename")%></td>
            <td align="center"><%#Eval("colorname")%></td>--%>
             <%--<td align="center"><a  href="modifyproductshop.aspx?id=<%#Eval("id") %>">编辑销售价</a>
             
             </td>--%>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>

<div class="listButtom">
        <%--<span class="btn_all" onclick="checkAll(this);"><a href="javascript:;">全选</a></span>--%>
        <span class="btn_bg" style=" float:left;"><a class="bome"  onclick="chkboxAll(this);">全选</a>
            <asp:LinkButton ID="lbtnDel" runat="server" class="bome" OnClientClick="return checkDel('msgtable');" OnClick="lbtnDel_Click" >删 除</asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server"  class="bome"  onclick="lkBtnAdd_Click">添加</asp:LinkButton>&nbsp;&nbsp;
             <asp:LinkButton ID="lbtnUp" runat="server"  
            OnClientClick="return confirm( '确定把这个商品设置为上线吗？ ');"  class="bome"   onclick="lbtnUp_Click" >上线</asp:LinkButton>&nbsp;&nbsp;   
             <asp:LinkButton ID="lbtnDon" runat="server"  
            OnClientClick="return confirm( '确定把这个商品设置为下线吗？ ');"  class="bome"   onclick="lbtnDon_Click" >下线</asp:LinkButton>&nbsp;&nbsp;        
        </span>
        <div class="pages">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" 
                    NextPageText="下一页" PrevPageText="上一页"
                    onpagechanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
        </div>
</div>

</asp:Content>