<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getbrand.aspx.cs" Inherits="TREC.Web.common.getbrand" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>获取品牌</title>
    <link rel="stylesheet" type="text/css" href=<%="\""+TREC.ECommerce.ECommon.WebResourceUrl%>/altdialog/skins/default.css" />
    <link rel="stylesheet" type="text/css" href=<%="\""+TREC.ECommerce.ECommon.WebResourceUrl%>/css/webcommon.css" />
    <script type="text/javascript" src="<%=ECommon.WebResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebResourceUrl %>/script/jquery.inputlabel.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebResourceUrl %>/altdialog/artDialog.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebResourceUrl %>/altdialog/plugins/iframeTools.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebResourceUrl %>/altdialog/plugins/rtDialog.plugins.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebResourceUrl %>/script/common.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebResourceUrl %>/script/jquery.getcss.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#txtBrandName").inputLabel("请输入品牌名称……");
            if ($(".infolist").html() == "") {
                $(".infolist").html("<li class=\"no\"><a href=\"#\">请按品牌<font style=\"color:#f30\">名称/风格/材质</font>等查找!</a></li>");
            }
            if ($(".sinfolist").html() == "") {
                $(".sinfolist").html("<li class=\"no\"><a href=\"#\">该店铺无品牌<br>请查找加入!</li>");
            }
            $("#btnSearch").click(function () {
                if ($("#txtBrandName").val() == "请输入品牌名称……" || $("#txtBrandName").val() == "") {
                    art.dialog({
                        title: "搜索提示",
                        content: '请按品牌<font style=\"color:#f30\">名称/风格/材质</font>等查找!',
                        ok: function () {
                            $("#txtBrandName").focus();
                        }
                    });
                } else {
                    $.ajax({
                        url: '<%=TREC.ECommerce.ECommon.WebUrl %>/ajax/ajaxuser.ashx',
                        data: 'type=getwebtopbrand&m=<%=m %>&mt=<%=mt %>&v=' + $("#txtBrandName").val(),
                        dataType: "json",
                        success: function (data) {
                            if (data != null) {
                                $(".infolist").hide();
                                $(".infolist").show();
                                $(".infolist").html("");
                                $.each(data, function (i) {
                                    var j = '<%=string.Format(EnFilePath.Brand,"_",EnFilePath.Logo) %>';
                                    var mHtml = "<li id=\"" + data[i].id + "\"><a href=\"#\">";
                                    mHtml += "<span>选择</span>";
                                    mHtml += "<img src=\"" + j.replace("_", data[i].id) + "/" + data[i].logo + "\" width='105' height='38' alt='" + data[i].name + "' />"
                                    mHtml += "<p class=\"t\"><strong>品牌：</strong>" + data[i].name + "</p>";
                                    mHtml += "<p class=\"d\"><strong>材质：</strong>" + data[i].materialname + "</p>";
                                    mHtml += "<p class=\"d\"><strong>风格：</strong>" + data[i].stylename + "</p>";
                                    mHtml += "<p class=\"d\"><strong>档位：</strong>" + data[i].spreadname + "</p>";
                                    mHtml += "<p class=\"d\"><strong>公司：</strong>" + data[i].company + "</p>";
                                    mHtml += "</a></li>"
                                    $(".infolist").append(mHtml);

                                });
                            }
                            else {
                                $(".infolist").html("<li class=\"no\"><a href=\"#\">请按品牌<font style=\"color:#f30\">名称/风格/材质</font>等查找!</a></li>");
                            }
                        }
                    })
                }
            })

            $("ul.infolist").find("a").live("click", function () {
                var o = $(this).parent();
                if (!$(o).hasClass("no")) {
                    if ($("ul.sinfolist").find("li.no").length > 0) {
                        $("ul.sinfolist").html("");
                    }
                    $(o).find("span").text("移除");
                    $("ul.sinfolist").append(o);
                    $("#hfvalue").attr("value", $("#hfvalue").attr("value") + $(o).attr("id") + ",");

                }
            });

            $("ul.sinfolist").find("a").live("click", function () {
                var o = $(this).parent();
                if (!$(o).hasClass("no")) {
                    art.dialog({
                        title: '是否移除',
                        content: '您确定是否移除该品牌吗？',
                        button: [
                            {
                                name: '取消'
                            },
                            {
                                name: '确定',
                                callback: function () {
                                    if ($("ul.infolist").find("li.no").length > 0) {
                                        $("ul.infolist").html("");
                                    }
                                    $("#hfvalue").attr("value", $("#hfvalue").attr("value").replace($(o).attr("id") + ",", ""));
                                    $(o).find("span").text("增加");
                                    $("ul.infolist").append(o);
                                },
                                focus: true
                            }
                        ]
                    });
                }
            });
        });
    </script>
</head>
<body>
<form id="form1" runat="server">
    
                
    <table cellpadding="0" cellspacing="0" class="conSearch">
        <tr>
            <td class="searchBox">
                <asp:HiddenField ID="hfvalue" runat="server" />
                &nbsp;&nbsp;品牌搜索:<input type="text" id="txtBrandName" class="webSearch" /><input type="button" id="btnSearch" value="搜索" class="submit" />
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table class="searchList"  cellpadding="0" cellspacing="0">
                    <tr>
                        <th class="l">&nbsp;品牌库</th><th>店铺品牌</th>
                    </tr>
                     <tr>
                        <td class="c l" valign="top">
                            <ul class="infolist"></ul>
                        </td>
                        <td valign="top">
                            <%if (brandList.Count == 0)
                              { %>
                            <ul class="sinfolist"></ul>
                            <%}
                              else
                              { %><ul class="sinfolist">
                              <%foreach(EnWebBrand b in brandList){ %>
                              <li id="<%=b.id %>">
                                    <a href="javascript:;">
                                        <span>选择</span>
                                        <img height="38" width="105" alt="<%=b.title %>" src="<%=string.Format(EnFilePath.Brand,b.id,EnFilePath.Logo)+b.logo %>">
                                        <p class="t"><strong>品牌：</strong><%=b.title %></p>
                                        <p class="d"><strong>材质：</strong><%=b.materialname %></p>
                                        <p class="d"><strong>风格：</strong><%=b.stylename %></p>
                                        <p class="d"><strong>档位：</strong><%=b.spreadname %></p>
                                        <p class="d"><strong>厂家：</strong><%=b.companyname %></p>
                                    </a>
                               </li>
                              <%} %>
                              </ul>
                            <%} %>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</form>
</body>
</html>
