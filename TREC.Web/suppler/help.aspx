<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="help.aspx.cs" Inherits="TREC.Web.Suppler.help" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register src="ascx/head.ascx" tagname="head" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=ECommon.WebTitle%>-供应商系统-帮助中心</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link rel="stylesheet" type="text/css" href="css/index.css" />
    <link rel="Stylesheet" type="text/css" href=<%="\""+TREC.ECommerce.ECommon.WebSupplerResourceUrl%>/joyride/joyride-1.0.2.css" />
    <link rel="stylesheet" type="text/css" href=<%="\""+TREC.ECommerce.ECommon.WebSupplerResourceUrl%>/altdialog/skins/default.css" />
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" language="javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.poshytip.min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/joyride/jquery.joyride-1.0.2.min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/altdialog/artDialog.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/altdialog/plugins/iframeTools.js"></script>
    <script type="text/javascript" src="script/supplercommon.js"></script>
    <script type="text/javascript">
        $(function () {
            $(this).joyride();
            $('.helper').poshytip({
                className: 'tip-yellowsimple',
                showTimeout: 1,
                alignTo: 'target',
                alignX: 'left',
                alignY: 'center',
                offsetX: 5,
                allowTipHover: false,
                content: '帮助中心?'
            });
            $(".leftMenu > ul > li > a").live("click", function () {
                $(".leftMenu > ul > li > a").removeClass("cur");
                $(this).addClass("cur");
                $(".frameMenu").find("span.title").text($(this).text())
                $('#helpIco').poshytip('update', '如果您在 <strong>' + $(this).text() + ' 时遇到问题</strong>，点击 <strong>?</strong> 查看 ' + $(this).text() + '的使用帮助');
            });

        });
    </script>
</head>
<body>
<form id="form1" runat="server">
    <uc1:head ID="head1" runat="server" />
    <div class="Fcon">
        <div class="leftMenu">
            <h3><a href="javascript:;">帮助中心</a></h3>
            <ul> 
                <%foreach (EnArticleCategory c in helpCategoryList)
                  { %>
                <li><a href="help.aspx?cid=<%=c.id %>" target="_self"><%=c.title %></a></li>

                <%} %>
            </ul>
        </div>
        <div class="frameMenu">
            <span class="title"><asp:Label ID="lbtitle" runat="server"></asp:Label></span><a href="javascript:;" class="helper menuHelper"  title="" >&nbsp;</a>
        </div>
        <div class="rightFrame" style="height:auto;">
            <%if (ECommon.QueryCid == "" && ECommon.QueryId == "")
              {%>
                <%=modelMain.context%>
             <%} %>
             <%if (ECommon.QueryCid != "" && ECommon.QueryId == "")
              {%>
                <ul class="helplist">
                    <%foreach (EnArticle a in articlelist)
                      { %>
                    <li>
                        <a href="javascript:;"><%=a.title %><span>-<em><%=a.createtime.ToShortDateString() %></em></span></a>
                    </li>
                    <%} %>
                </ul>
             <%} %>
             
        </div>
    </div>
    <div class="clear"></div>
</form>
</body>
</html>
