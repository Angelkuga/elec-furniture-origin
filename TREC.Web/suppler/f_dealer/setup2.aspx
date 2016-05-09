<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setup2.aspx.cs" Inherits="TREC.Web.Suppler.f_dealer.setup2" %>

<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register Src="../ascx/headNoLog.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="nav.ascx" TagName="nav" TagPrefix="uc2" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=ECommon.WebTitle%>-商务中心</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../../resource/altdialog/skins/default.css" />
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
                width: '800px',
                height: '470px'
            });
        }
    </script>
    <style type="text/css">
        .brandList
        {
            margin-left: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:head ID="head1" runat="server" />
    <div class="Fcon setup">
        <div class="setupTitle">
            &nbsp;&nbsp;欢迎您进入家具快搜供应商管理系统，请先按顺序添加完成以下内容，以便正式上传产品。
        </div>
        <div class="setupNext">
            <uc2:nav ID="nav1" runat="server" />
        </div>
        <div class="setupCon">
            <%if (TREC.ECommerce.SupplerPageBase.brandList != null && TREC.ECommerce.SupplerPageBase.brandList.Count > 0)
          { %>
            <div class="info" style="width:727px"><span class="ico">&nbsp;</span><b>您己创建过</b>
                <%foreach (EnBrand b in TREC.ECommerce.SupplerPageBase.brandList)
                { %>
                &nbsp;&nbsp;<b><a href="javascript:;">[<%=b.title %>]</a></b>&nbsp;
                <%} %>
                <b><a href="<%=brandnexturl %>" class="next">点击这里</a></b>&nbsp;进入下一步
            </div>
            <%} %>
            <table cellpadding="0" cellspacing="0" width="98%" style="margin:0px auto;">
                <tr>
                    <td colspan="2" style="height: 20px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table style="background:url(../images/e7.jpg) no-repeat; width:474px; height:124px; float:left;">
                            <tr>
                                <td>
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
                                    <div style=" display:block; float:left; height:30px;  width:100%; margin-top:30px;">
                                    <asp:TextBox ID="txtsearch" runat="server" CssClass="input" style="margin-left:20px; width:350px; display:block; float:left;"></asp:TextBox>
                                    <asp:Button ID="btnSearch" CssClass="submit2" Text="搜索" runat="server" OnClick="btnSearch_Click"  /></div>
                                     <div style=" display:block; float:left;  width:100%">
                                    <asp:LinkButton ID="btnAppend" runat="server" 
                                    OnClick="btnAppend_Click" CssClass="addapend"></asp:LinkButton></div>
                                </td>
                            </tr>
                        </table>
                        <table style="background:url(../images/e7.jpg) no-repeat; width:474px; height:124px; float:right;">
                            <tr>
                                <td>
                                    <a href="javascript:;"
                                id="addBrand" onclick="addBrand()" >&nbsp;</a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                            <tr>
                                <th width="40px" align="center">
                                    选择
                                </th>
                                <th width="40px" align="center">
                                    编号
                                </th>
                                <th align="center" width="200px">
                                    品牌图
                                </th>
                                <th align="left" class="l" width="200px">
                                    品牌名
                                </th>
                                <th align="left">
                                    &nbsp;&nbsp;工厂名
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
                                        <td align="center" style="height: 45px;">
                                            <img src='<%#string.Format(EnFilePath.Brand,Eval("Id"),EnFilePath.Logo) %>/<%#Eval("logo")%>'
                                                width="105" height="38" />
                                        </td>
                                        <td align="left" class="l edit  ">
                                            <%--<a href="brandinfo.aspx?edit=1&id=<%#Eval("id") %>">--%>
                                                <asp:Label ID="lb_title" runat="server" Text='<%#Eval("title") %>'></asp:Label>
                                                <%--</a>--%>
                                        </td>
                                        <td align="left" class="l">
                                            <%#Eval("companyname")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <div class="listButtom">
                            <span class="btn_bg">&nbsp;&nbsp; </span>
                            <div class="pages">
                                <webdiyer:aspnetpager id="AspNetPager1" runat="server" alwaysshow="true" urlpaging="true"
                                    firstpagetext="首页" lastpagetext="尾页" nextpagetext="下一页" prevpagetext="上一页">
                            </webdiyer:aspnetpager>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="2">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="clear">
    </div>
    <div class="foot" style="position: static; left: 0px; background: #f4f4f4; bottom: 0px;
        right: 0px; width: 100%; height: 30px; display: none">
        底部
    </div>
    </form>
</body>
</html>
