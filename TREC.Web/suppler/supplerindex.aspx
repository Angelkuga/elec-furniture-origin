<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supplerindex.aspx.cs" Inherits="TREC.Web.Suppler.supplerindex" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>供应商系统第一步</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link rel="stylesheet" type="text/css" href="<%="\""+TREC.ECommerce.ECommon.WebSupplerResourceUrl%>/altdialog/skins/default.css" />
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" language="javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.poshytip.min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/altdialog/artDialog.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/altdialog/plugins/iframeTools.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/messages_cn.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#div1").animate({ opacity: 0.5 });
        });

        function openLink(i, v) {
            $(".aui_state_focus").hide();
            $("#mainaui_state_focus").show();
            art.dialog.open('supplermemberinfo.aspx?sid=' + i + '&v=' + encodeURI(v), {
                title: '恭喜您已经成为我们的会员（第②步）完善  供应商  联系信息',
                width: '625px',
                height: '365px',
                padding: '1px'
            });
        }
    </script>
    <style type="text/css">
        .aui_buttons button
        {
            float: none;
        }
    </style>
</head>
<body style="background: #CCC">    
    <form id="form1" runat="server">
    <div style="position: absolute; left: 50%; top: 50%; margin: -195px 0px 0px -360px;
        display: block; width: auto; z-index: 1986;" class="aui_state_focus aui_state_lock"
        id="mainaui_state_focus">
        <table class="aui_dialog">
            <tbody>
                <tr>
                    <td class="aui_header" colspan="2">
                        <div class="aui_titleBar">
                            <div class="aui_title" style="cursor: auto; display: block;">
                                恭喜您已经成为我们的会员<br />
                                （第①步）选择您想注册的供应商类型
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="aui_icon" style="display: none;">
                        <div class="aui_iconBg" style="background: none repeat scroll 0% 0% transparent;">
                        </div>
                    </td>
                    <td class="aui_main" style="width: 625px; height: 365px;">
                        <div class="aui_content" style="padding: 1px; background: #f1f9ff;">
                            <div id="btnAdd" style="display: block;width:850px;" class="Fcon">
                                <div style="background: #f1f9ff; background: url('images/supplerindex_bg.gif') repeat-x;"
                                    class="supplerindex">
                                    <ul>
                                        <li>
                                            <%--  <a onclick="openLink('<%=(int)EnumMemberType.工厂企业 %>','厂商')" title="点击完善品牌厂家联系信息"
                                                                class="txtTip" href="#">
                                                                <img height="269" width="169" src="images/1-1.gif"></a>--%>
                                            <a href="Settled.aspx?sid=101" title="点击完善品牌厂家联系信息" class="txtTip" href="#">
                                                <img height="269" width="169" src="images/1-1.gif"></a> </li>
                                        <li>
                                            <%--<a onclick="openLink('<%=(int)EnumMemberType.经销商 %>','经销商')" title="点击完善经销商联系信息"
                                                                class="txtTip" id="top1" href="#">--%>
                                            <%-- <a href="f_dealer/setup1.aspx" title="点击完善经销商联系信息"
                                                                class="txtTip" id="A1" href="#">--%>
                                            <a href="Settled.aspx?sid=102" title="点击完善经销商联系信息" class="txtTip" id="A1">
                                                <img height="269" width="169" src="images/2-1.gif"></a></li>
                                        <li>
                                        <table border="0" cellpadding="0" cellspacing="0" style="background:url(images/3-100.gif);width:340px;height:269px;cursor:pointer;"><tr>
                                         <td title="点击完善经卖场联系信息" onclick="javascript:location.href='Settled.aspx?sid=103'" style="width:50%;cursor:pointer;"></td>
                                        <td onclick="javascript:location.href='/suppler/market/marketclique.aspx'"  style="width:50%" title="点击完善集团信息"></td>
                                        </tr> </table>
                                       
                                          
                                            
                                            </li>
                                            
                                            
                                    </ul>
                                    <%-- <ul>
                                                            <li><a onclick="openLink('<%=(int)EnumMemberType.工厂企业 %>','厂商')" title="点击完善品牌厂家联系信息"
                                                                class="txtTip" href="#">
                                                             <%--   <li><a href="f_company/setup1.aspx" title="点击完善品牌厂家联系信息"
                                                                class="txtTip" href="#"><img height="269" width="169" src="images/1-1.gif"></a></li>
                                                            <li><a onclick="openLink('<%=(int)EnumMemberType.经销商 %>','经销商')" title="点击完善经销商联系信息"
                                                                class="txtTip" id="top1" href="#">
                                                               <a href="f_dealer/setup1.aspx" title="点击完善经销商联系信息"
                                                                class="txtTip" id="top1" href="#">    <img height="269" width="169" src="images/2-1.gif"></a></li>
                                                            <li><%--<a onclick="openLink('<%=(int)EnumMemberType.卖场 %>','卖场')" title="点击完善经卖场联系信息"
                                                                class="txtTip" href="#">
                                                                <a href="f_market/setup1.aspx" title="点击完善经卖场联系信息"
                                                                class="txtTip" href="#">
                                                                <img height="269" width="169" src="images/3-1.gif"></a></li>
                                                        </ul>--%>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <style type="text/css">
        #btnAdd
        {
            float: left;
            width: 680px;
            height: 348px;
            background: #f1f9ff;
        }
        .supplerindex ul
        {
            margin-top: 20px;
        }
        .supplerindex ul li
        {
            float: left;
            margin: 0px 15px 0px 35px;
            width: 170px;
        }
        .supplerindex ul li a
        {
            display: block;
        }
        
        #linkInfo
        {
            display: none;
        }
    </style>

    
    </form>
</body>
</html>
