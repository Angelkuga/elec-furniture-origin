<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addSubMarket.aspx.cs" Inherits="TREC.Web.Suppler.market.addSubMarket" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"
        type="text/javascript"></script>
    <link href="../resource/css/ymPrompt/simple_gray/ymPrompt.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../css/base.css" />
    <style>
        .marketlist{ width:200px;float:left;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input name="marketName" id="marketName" maxlength="100" value="<%=Request["marketName"] %>" type="text" size="30" />
        <input type="button" class="btnlitl" id="searchProduct" value="搜索" onclick="Dosearch(1);" />
        <div style="margin-top: 0; text-align: center;">
            <table width="100%" border="0" id="productlist" cellspacing="0" cellpadding="0">
                <tr>
                    <th align="left">
                        <a onclick="chkboxAll(this,'msgtable');">全选择</a>
                    </th> 
                </tr>
                <tr>
                    <th align="center" class="msgtable">
                         
                    </th> 
                </tr>
            </table>
            <a class="bome" style="font-size: 18px; font-weight: bolder;" id="addMarket">添加选择的卖场</a>
            <asp:HiddenField ID="hiddSingProductID" runat="server" />
             <script type="text/javascript">
                 $(function () {
                     //添加单品到父级窗口
                     $("#addMarket").click(function () {
                         var chk_str = "";
                         var chk_value = [];
                         if ($(".msgtable").find("input[type=checkbox]:checked").length == 0) {
                             alert("请选择卖场 ");
                             return;
                         } else {
                             $(".msgtable").find("input[type=checkbox]:checked").each(function () {
                                 if ($(this).attr("checked")) {
                                     if (chk_str == "")
                                         chk_str = $(this).val();
                                     else
                                         chk_str += "," + $(this).val();
                                 }
                                 chk_value.push($(this).val());
                             });
                         }
                         if ($(".ymPrompt_close", parent.document).length > 0) {
                             var pCTRL = $("#ctl00_ContentPlaceHolder1_hfsubmarketidlist", parent.document);
                             var old_value_str = pCTRL.val();
                             if (old_value_str != "") {
                                 old_value_str = unique((old_value_str + ',' + chk_str).split(","));
                             }
                             else {
                                 old_value_str = chk_str;
                             }
                             pCTRL.val(old_value_str);
                             //alert(old_value_str);
                             $("#loadmarket", parent.document).click();
                             window.parent.ymPrompt.doHandler('', true);
                         }
                     });
                     //数组去重复项
                     function unique(arr) {
                         var result = [], hash = {};
                         for (var i = 0, elem; (elem = arr[i]) != null; i++) {
                             if (!hash[elem]) {
                                 result.push(elem);
                                 hash[elem] = true;
                             }
                         }
                         return result;
                     }
                 });
                 //分页
                 function singleProductPage(totalPage, currentPage) {
                     var mysize = $('.msgtable .pages').size();
                     if (mysize == 0) {
                         $('<div class="pages"></div>').insertAfter($('#productlist'));
                     }
                     var epage = currentPage + 3;
                     var spage = currentPage - 2;
                     if (spage <= 0 || totalPage <= 5) {
                         spage = 1;
                     }
                     if (totalPage < epage) {
                         epage = totalPage;
                     }
                     var pagehtml = '';
                     for (var i = spage; i <= epage; i++) {
                         if (i == currentPage) {
                             pagehtml += '<span class="current">' + i + '</span>';
                         } else {
                             pagehtml += '<a onclick="Dosearch(' + i + ');">' + i + '</a>';
                         }
                     }
                     //上一页
                     if (currentPage == 1) {
                         pagehtml = '<span class="disabled"> &lt; </span>' + pagehtml;
                     } else {
                         pagehtml = '<a onclick="Dosearch(' + (currentPage - 1) + ');"> &lt; </a>' + pagehtml;
                     }
                     //下一页
                     if (currentPage == totalPage) {
                         pagehtml += '<span class="disabled"> &gt; </span>';
                     } else {
                         pagehtml += '<a onclick="Dosearch(' + (currentPage + 1) + ');"> &gt; </a>';
                     }
                     $('.msgtable .pages').html(pagehtml);
                 }
                 //搜索卖场 
                 function Dosearch(pp) {
                     var gpId = 0;
                     var marketName = $("#marketName").val();
                     $('.msgtable').html("正在读取数据中...");
                     $.get('../ajax/MemberHandler.ashx',
                        { Action: 'searchmarketbykey',
                            marketName: marketName.toString()
                        },
                         function (data) {
                             if (data != null) {
                                 if (data.toString() == 'no' || data.toString() == '$0') {
                                     $('.msgtable').html('抱歉，暂无找到您要的卖场 ！');
                                 } else {
                                     $('.msgtable').empty();
                                     $('.msgtable').html(data);
                                 }
                             }
                         });
                 }
                 //select all
                 function chkboxAll(th, t_class) {
                     if ($("." + t_class).find("input[type=checkbox]:checked").length > 0) {
                         $("." + t_class).find("input[type=checkbox]").attr('checked', false);
                         // $(th).text("全选")
                     } else {
                         $("." + t_class).find("input[type=checkbox]").attr('checked', "checked");
                         // $(th).text("取消")
                     }
                 } 
        </script>
    </div>
    </form>
</body>
</html>
