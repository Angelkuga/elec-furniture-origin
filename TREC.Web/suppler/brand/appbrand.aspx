<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="../Member.Master"  CodeBehind="appbrand.aspx.cs" Inherits="TREC.Web.Suppler.brand.appbrand" %>
<%@ Import Namespace="TREC.ECommerce" %><%@ Import Namespace="TREC.Entity" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href=<%="\""+TREC.ECommerce.ECommon.WebSupplerResourceUrl%>/altdialog/skins/default.css" />
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.inputlabel.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/altdialog/artDialog.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/altdialog/plugins/iframeTools.js"></script>
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
            $("#txtsearch").inputLabel("请输入品牌工厂名称/品牌名称/风格搜索……");
        })
        function addBrand() {
            art.dialog.open('createbrand.aspx?mt=<%=memberInfo.type %>&m=<%=dealerInfo.id %>', {
                title: '添加新品牌',
                width: '760px',
                height: '470px'
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $(".checkall").click(function () {
                var hascheck = false;
                $("[type='checkbox']").each(function () {
                    if ($(this).attr("checked")) {
                        hascheck = true;
                    }
                });
                if (hascheck) { $("a#btnAppend").addClass("curappend") } else { $("a#btnAppend").removeClass("curappend") }
                hascheck = false;
            });

            $("#btnAppend").click(function () {
                var hascheck = false;
                $("[type='checkbox']").each(function () {
                    if ($(this).attr("checked")) {
                        hascheck = true;
                    }
                });
                if (!hascheck) { alert("选择品牌-->提交"); return false; } else { return confirm('确认代理选中的品牌？ '); }
                hascheck = false;
            })
        })
                                    </script>
    <style type="text/css">
        .brandList{margin-left:15px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td colspan="2" style="background:url(../images/tieshi.jpg) no-repeat;height:70px;"></td>
    </tr>
    <tr>
        <td width="70px" align="right">品牌搜索：</td>
        <td><asp:TextBox ID="txtsearch" runat="server" CssClass="input" style="width:300px;"></asp:TextBox>
            <asp:Button ID="btnSearch" CssClass="submit" Text="搜索" runat="server" 
                onclick="btnSearch_Click" /><span style="display:block; float:left; padding-top:5px;">(*如搜索没有品牌)</span><a href="javascript:;" id="addBrand" onclick="addBrand()" style="margin-top:0px; float:left; margin-left:10px; margin-top:-5px;" >&nbsp;&nbsp;</a>
       </td>
    </tr>
    <tr>
        <td colspan="2" style="height:20px;"></td>
    </tr>
    <tr>
        <td colspan="2" align="left" style="text-align:left;" ><asp:LinkButton ID="btnAppend" runat="server"  CssClass="addapend"  OnClick="btnAppend_Click" style="float:left; margin:0 95px"></asp:LinkButton></td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
             <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                <tr>
                <th width="40px" align="center">选择</th>
                <th width="40px" align="center">编号</th>
                <th align="center" width="200px">品牌图</th>
                <th align="left" class="l" width="200px">品牌名</th>
                <th align="left">&nbsp;&nbsp;工厂名</th>
                </tr>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>
                        <td align="center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
                        <td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
                        <td align="center" style="height:45px;"><img src='<%#string.Format(EnFilePath.Brand,Eval("Id"),EnFilePath.Logo) %>/<%#Eval("logo")%>' width="105" height="38"  /></td>
                        <td align="left" class="l edit  "><a href="brandinfo.aspx?edit=1&id=<%#Eval("id") %>"><asp:Label ID="lb_title" runat="server" Text='<%#Eval("title") %>'></asp:Label></a></td>
                        <td align="left" class="l"><%#Eval("companyname")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div class="listButtom">
                    <div class="pages">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" 
                                NextPageText="下一页" PrevPageText="上一页">
                            </webdiyer:AspNetPager>
                    </div>
            </div>
        </td>
    </tr>
    <tr>
        <td class="2"></td>
    </tr>
</table>
</asp:Content>
