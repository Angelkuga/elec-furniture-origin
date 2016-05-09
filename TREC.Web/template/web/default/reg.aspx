<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reg.aspx.cs" Inherits="TREC.Web.aspx.reg" %>

<%@ Register Src="ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="ascx/_headA.ascx" TagName="_headA" TagPrefix="uc4" %>
<%@ Register Src="ascx/_foot.ascx" TagName="_foot" TagPrefix="uc5" %>

<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=pageTitle %></title>
    <ucnewresource:newresource ID="newresource1" runat="server" />

    <meta name="keywords" content="家具品牌,家具品牌排名,家具十大品牌,品牌家具,实木家具十大品牌,儿童家具十大品牌,板式家具十大品牌">
    <meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！">

    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/css/reg_new.css" rel="stylesheet" type="text/css" />
    <script src="/resource/content/libs/jquery-1.11.0.min.js"></script>
    <script src="/resource/content/indexnav/jquery.min.js" type="text/javascript"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/index/index.js"></script>
     
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/messages_cn.js"></script>
    <style type="text/css">
    .reg-table4 td
    {
        background-color: #fff;
    color: #333;
    font-size: 14px;
    text-align:left;
    padding-left:10px;
    padding-right:10px;
     }
    </style>
</head>
<body>
    <uc1:header ID="header1" runat="server" />
    <!--main-->
    <div class="topline"></div>
    <div align="center"><div class="bannerbox"><div align="center">
    <div class="topbanner"><div class="rukoubg"></div><div class="rukoucon"><div>
    <!--标签切换begin-->
    <div class="cpTitle"><ul><li id="one1" class="tabActive">商家注册</li><li id="one2" class="tabNormal">商家登录</li></ul></div>
	    <div class="cplist" id="con_one_1" style="DISPLAY: block;">
            <table width="250" border="0" cellspacing="0" cellpadding="0"> 
                <tr><td height="33">用&nbsp;户&nbsp;名：</td><td align="left"><input type="text" id="txtRegName" class="textfiled" /></td></tr>
                <tr><td height="33">手机号码：</td><td align="left"><input type="text" id="txtMoblie" maxlength="12" class="textfiled" /></td></tr>
                <tr><td height="33">登录密码：</td><td align="left"><input type="password" id="txtRegPwd" class="textfiled" /></td></tr>
                <tr><td height="33">确认密码：</td><td align="left"><input type="password" id="txtChekPwd" class="textfiled" /></td></tr>
                <tr><td height="33">验&nbsp;证&nbsp;码：</td><td align="left"><img id="imgValiateCode" src="/ajaxtools/imageVerify.aspx?model=reg"><input id="txtValidation" maxlength="4" type="text"  class="textfiled2" /><a class="xieyi" id="chkImgVerify">换一张</a></td></tr>
                <tr><td height="25" colspan="2" align="center"><input id="regpact" type="checkbox" checked="checked" />同意<a href="/agreement.aspx" target="_blank" class="huan" title="查看注册协议">注册协议</a></td></tr>
                <tr><td colspan="2" align="center" style="padding-top:15px;"><input type="button" class="rzbtn" value="提   交" /></td></tr>               
            </table>
        </div>
        <div class="cplist" id="con_one_2" style="DISPLAY: none;">
            <table width="250" border="0" cellspacing="0" cellpadding="0">               
                <tr><td height="30">&nbsp;</td><td>&nbsp;</td></tr>
                <tr><td height="40">用户名：</td><td align="left"><input type="text" id="txtLoginName" class="textfiled3" /></td></tr>
                <tr><td height="20">&nbsp;</td><td align="left" valign="top"><span class="wordcol"></span></td></tr>
                <tr><td height="40">密&nbsp;&nbsp;码：</td><td align="left"><input type="password" class="textfiled3" id="txtLoginPwd" /></td></tr>
                <tr><td height="40">验证码：</td><td>
               <div style="float:left;"><img id="imgValiateCode2" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/imageVerify.aspx?model=reg"></div>
               <div style="float:left;"><input id="txtValidation2" maxlength="4" type="text"  class="textfiled2" /></div>
               <div style="float:left;"><a class="xieyi" id="chkImgVerify2">换一张</a></div>
                </td> </tr>
                <tr><td style="padding-top:20px;" colspan="2" align="center"><a class="rzbtn">登&nbsp;&nbsp;录</a></td></tr>
                <tr><td height="40" colspan="2" align="center">
                <%--<a href="seekusername.aspx" target="_blank" class="huan" title="忘记用户名？">忘记用户名？</a>--%>
                <%--<a href="seekpass.aspx" target="_blank" class="huan" title="短信找密码？">短信找密码？</a>--%>
                <a href="FindPwdSupply.aspx" target="_blank" class="huan" title="找回密码？">找回密码？</a>
                </td></tr>                
            </table>
        </div>
    </div>
    <input  type="hidden" id="inputkey"  value="<%=getr %>"/>
    <!---标签切换end--->
</div>
</div>
</div>
</div>
<div class="menubg">
<div align="center">
<div class="mainmenu"><ul><li><a href="#a01">为什么要加入我们？</a></li><li><a href="#a03">我们做什么？</a></li><li><a href="#a02">入驻流程</a></li><li style="display:none;"><a href="#a04">收费标准</a></li><li><a href="#a05">会员特权</a></li><li><a href="#a06">如何发布信息？</a></li><li><a href="#a07">组织团购</a></li></ul></div>
</div>
</div>
</div>
<!-- main begin --->
<div align="center">
<div class="mainout">
<div class="mainbox">
<div class="content">
<h1 class="banner"><a name="a01">&nbsp;</a><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/sjrz_16.jpg" alt="为什么要加入家具快搜" /></h1>
<div class="subonel">
<p>家具快搜是互联网第一个家具行业的专业信息发布平台，也是家具行业最全信息官网。
与网络商城相互结合形成信息平台与电子商务的互补，有效的弥补了家具行业信息不流通，
没有有效的传播途径的空白，是对家具行业电子商务的有机整合。
</p>
<p>家具快搜提供最专业的行业信息发布和搜索。为家具厂商、经销商提供最便捷、迅速的
售货渠道；更为家具商家量身打造品牌推广、口碑营销的专业化道路。
</p>
<p>低成本，高收益；卖家具，入驻家具快搜已成为家具商家的不二选择！
</p>
</div>
<div class="suboner"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/sjrz_20.jpg" alt="为什么要加入家具快搜" width="246" height="209" /></div>
<div class="clear"></div></div>
<div class="content">
<h1 class="banner"><a name="a02"></a><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/sjrz_23.jpg" alt="入驻流程" width="865" height="43" border="0" /></h1>
<img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/sjrz_26.jpg" alt="入驻流程" width="843" height="109"  style="margin:10px 0 15px;"/></div>
<div class="content"><h1 class="banner"><a name="a03"></a><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/sjrz_29.jpg" alt="家具快搜的作用" width="865" height="43" /></h1>
<h2>对商家家具快搜可以提供如下服务</h2>
<ul class="fuwu">
<li><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/sjrz_36.jpg" />
<div class="rcon">
<h3>网络商城功能</h3>
<p>可以实时发布品牌，厂家，产品，店铺，促销信息以及招商信息，节省商家额外的网络营销和广告费用。</p>
</div>
</li>
<li><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/sjrz_38.jpg" width="129" height="69" />
<div class="rcon">
<h3>客服坐席功能</h3><p>24小时为消费者提供专业的咨询服务，有效的为消费者进行职业导购，引导顾客完成品质消费。等于商家多了一名职业导购和客服，降低了雇佣成本。 </p>
</div>
</li>
<li><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/sjrz_42.jpg" width="129" height="69" />
<div class="rcon"><h3>网络营销推广（增值服务）</h3><p>为商家带来更精准的广告投放和有需求的潜在客户。快搜在为商家发布信息同时，也积极在互联网上进行推广，增加了商家产品的曝光率和线上线下商家店铺的访问量。 </p></div>
</li>
<li><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/sjrz_43.jpg" width="129" height="69" /><div class="rcon"><h3>全国客服咨询中心（增值服务）</h3><p>为商家提供自身信息窗口；拓展销售的渠道、推广宣传品牌的专业化平台；低成本、高收益。 </p>
</div>
</li>
<div class="clear"></div>
</ul>
<h2>家具快搜可以为消费者做什么?</h2>
<div class="subtwol">快搜有<span class="redbold">113</span>个品牌<span class="redbold">26</span>座卖场<span class="redbold">7040</span>件商品节省了消费者的大量查询时间，让消费者可以足不出户在家逛卖场，了解市场任一品牌厂商信息、资质；家具产品图片、尺寸、材质、参考价格等详细情况；卖场、店铺及销售联系方式各种促销活动消息等等。为消费者在购
买家具前提供全方位家具导购，真正实现消费者、商家和快搜三方共赢的局面。</div>
<div class="sbutwor"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/sjrz_51.jpg" width="317" height="119" /></div>
<div class="clear"></div></div>
<div class="content"   >

<!--
<h1 class="banner">
<a name="a04"></a>
<img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/sjrz_54.jpg" alt="收费标准" width="865" height="43" /></h1>
<div class="biaozhun">
    <%--<table width="865" align="center" cellspacing="1" widtd="940">
        <tr class="bg01"><td width="100" widtd="156">时长</td><td width="193">正常收费标准 </td><td width="284">8月15日之前的新商家</td><td>8月15日之前的老商家</td></tr>
        <tr class="bg02"><td>3个月</td><td>3000元</td><td>1500元</td><td>1000元</td></tr>
        <tr class="bg02"><td>6个月</td><td>5000元</td><td>2500元</td><td>1500元</td></tr>
    </table>--%>
    <br />
    <table width="865" border="0" align="center" cellpadding="0" cellspacing="1" widtd="940" >
        <tr class="bg01"><td width="295">增值服务</td><td width="283">收费标准</td><td width="283">说明</td></tr>
        <tr><td class="bg02">店铺在线客服坐席</td><td class="bg02"></td><td rowspan="3" class="bg02">&nbsp;</td></tr>
        <tr class="bg02"><td class="bg03">网络推广营销</td><td class="bg03"></td></tr>
        <tr class="bg02"><td class="bg03">首页横幅广告</td><td class="bg03"></td></tr>
        <tr><td class="bg02">首页产品推荐</td><td class="bg02"></td><td rowspan="4" class="bg02"></td></tr>
        <tr class="bg02"><td class="bg03">首页品牌推荐</td><td class="bg03"></td></tr>
        <tr class="bg02"><td class="bg03">首页工厂推荐</td><td class="bg03"></td></tr>
        <tr class="bg02"><td class="bg03">首页店铺推荐</td><td class="bg03"></td></tr>
    </table>
</div>
-->


<div class="biaozhun"><br /><h1 class="banner"><a name="a05"></a><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/sjrz_56.jpg" alt="会员所享功能" width="865" height="43" /></h1>
<table width="865" border="0" align="center" cellpadding="0" cellspacing="1" class="reg-table3">
<tr class="bg01"><td width="290">功能明细</td><td width="282">免费用户</td><td width="279" style="color:Red;">VIP会员（6000元/年）</td></tr>
<tr><td class="bg02">获得一个网上店铺</td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td></tr>
<tr><td class="bg02">发布工厂信息</td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td></tr>
<tr><td class="bg02">发布品牌信息</td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td></tr>
<tr><td class="bg02">展示产品信息（可标价可不标价）</td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td></tr>
<tr><td class="bg02">发布联系方式</td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/delete.png" width="16" height="16" /></td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td></tr>
<tr><td class="bg02">发布公司新闻</td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/delete.png" width="16" height="16" /></td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td></tr>
<tr><td class="bg02">发布线下店铺地址</td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/delete.png" width="16" height="16" /></td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td></tr>
<tr><td class="bg02">发布促销信息</td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/delete.png" width="16" height="16" /></td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td></tr>

<tr><td class="bg02">发布招商信息</td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/delete.png" width="16" height="16" /></td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td></tr>
<tr><td class="bg02">开通在线客服功能</td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/delete.png" width="16" height="16" /></td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td></tr>
<tr><td class="bg02">开通在线促销和订购功能</td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/delete.png" width="16" height="16" /></td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td></tr>
<tr><td class="bg02">参加团购活动</td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/delete.png" width="16" height="16" /></td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td></tr>
<tr><td class="bg02">入驻淘宝贝-库存促销</td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/delete.png" width="16" height="16" /></td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td></tr>

<tr><td class="bg02">开通订单查看功能</td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/delete.png" width="16" height="16" /></td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td></tr>
<tr><td class="bg02">获得家具快搜的客户资源和有效订单</td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/delete.png" width="16" height="16" /></td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td></tr>
<tr><td class="bg02">获得家具快搜的客户浏览、搜索等市场参考数据【功能开发中】</td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/delete.png" width="16" height="16" /></td><td class="bg02"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/checkmark.png" width="16" height="16" /></td></tr>
</table><br />
<table width="865" border="0" align="left" cellpadding="0" cellspacing="1" class="reg-table4">
    <tr><td width="291" class="bg01">增值服务项目明细</td><td width="564" class="bg01">收费标准</td><td width="564" class="bg01">说明</td></tr>
    
    <tr><td class="" align="left">产品图片拍摄处理(上海)</td><td class="" align="left">3000元/品牌/100个产品【超过100个产品每50为一个级别增加1000元】</td><td class="" align="left">
     专业摄影师，自带设备、灯光等；单品图，套组合图，细节图，各角度图拍摄；并可留底存档
    </td></tr>
    <tr><td class="">
    切图、资料整理和录入，完整的店铺建立
    </td><td class="bg02">2000元/店铺</td><td class="">切图，拼图，产品详细资料整理，录入，店铺建立</td></tr>
    <tr><td class="bg02">团购板块</td><td class="bg02">
    6000元/年；订单金额5万以上按5%收取提成
    </td><td class="bg02">
   <a href="http://hd.jiajuks.com/51/hdxz.html" target="_blank">点击查看活动细则</a>
    </td></tr>
   
    <%--<tr><td class="bg02" align="left">商家店铺在线客服坐席</td><td class="bg02">&nbsp;</td><td class="bg02" align="left">专业客服人员热诚接待</td></tr>
    <tr><td class="bg02">商家在线成交</td><td class="bg02">&nbsp;</td><td class="bg02">此功能近期将推出</td></tr>
    <tr><td class="bg02">家具快搜黄页/杂志期刊</td><td class="bg02">&nbsp;</td><td class="bg02">定期的潮流品牌家居资讯</td></tr>
    <tr><td class="bg02">商家网络营销包装推广</td><td class="bg02">&nbsp;</td><td class="bg02">热门论坛、博客的推广发布</td></tr>
    <tr><td class="bg02">商家全国客服咨询中心</td><td class="bg02">&nbsp;</td><td class="bg02">400-001-9211</td></tr>
    <tr><td rowspan="14" valign="middle" class="bg02">站内广告和店铺包装</td><td class="bg02">&nbsp;</td><td class="bg02">首页横幅广告</td></tr>
    <tr><td class="bg02">&nbsp;</td><td class="bg02">首页产品推荐</td></tr>
    <tr><td class="bg02">&nbsp;</td><td class="bg02">首页品牌推荐</td></tr>
    <tr><td class="bg02">&nbsp;</td><td class="bg02">首页工厂推荐</td></tr>
    <tr><td class="bg02">&nbsp;</td><td class="bg02">首页卖场推荐</td></tr>
    <tr><td class="bg02">&nbsp;</td><td class="bg02">首页店铺推荐</td></tr>
    <tr><td class="bg02">&nbsp;</td><td class="bg02">内页右侧推荐（不限推荐类型）</td></tr>
    <tr><td class="bg02">&nbsp;</td><td class="bg02">产品详细页右侧店铺推荐</td></tr>
    <tr><td class="bg02">&nbsp;</td><td class="bg02">产品图片拍摄处理</td></tr>
    <tr><td class="bg02">&nbsp;</td><td class="bg02">子页面包装上线（不含产品)</td></tr>
    <tr><td class="bg02">&nbsp;</td><td class="bg02">增加个性域名</td></tr>
    <tr><td class="bg02">&nbsp;</td><td class="bg02">招商栏目招商信息置顶</td></tr>
    <tr><td class="bg02">&nbsp;</td><td class="bg02">招商信息策划设计上线</td></tr>
    <tr><td class="bg02">&nbsp;</td><td class="bg02">促销栏目促销信息置顶</td></tr>--%>

  </table>
</div>
</div>

<div class="content">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>

<div class="content">
<h1 class="banner"><a name="a06"></a><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/sjrz_58.jpg" alt="发布信息流程" width="865" height="43" /></h1>
<img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/sjrz_60.jpg" alt="发布信息流程" /></div>
<div class="content">
<h1 class="banner"><a name="a07"></a><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/sjrz_62.jpg" alt="如何组织团购" width="865" height="43" /></h1>
<div class="subtwol"><p>团购您一定不陌生，有没有想过自己也组织一次团购活动，不仅能有好的利润，还能打响品牌的号召力。团购的力量不容小觑，与快搜开展团购活动从此让您的店面门可罗雀，财源广进。</p><p>家具快搜有着丰富的团购组织策划经验，及众多的关注潜在客户。迄今为止已经成功的为多家品牌组织做面向全国的团购活动，取得良好的效果。</p></div>
<div class="sbutwor"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>web/images/newreg/sjrz_65.jpg" alt="如何组织团购" width="326" height="125" onclick="window.scrollTo(0,0);" border="0" /></div>
<div class="clear"></div></div>

</div></div></div>
<!--- main end -->
<script type="text/javascript">
<!--
    $(function () {
        $('#txtValidation').numeral();
        $('.banner a').click(function () {
            window.scrollTo(0, 0);
        });

        function keybnt() {
            if ($("#inputkey").val() == "1") {
                $('.rzbtn:eq(0)')[0].click();
            }
            else {
                $('.rzbtn:eq(1)')[0].click();
            }
        }
        $(document).keypress(function (e) {
            // 回车键事件 
            if (e.which == 13) {
                keybnt();
            }
        });

        //在密码框里按enter键时让登录按钮获取焦点
        $("#txtLoginPwd").keydown(function () {
            if (event.keyCode == 13) {
                $('.rzbtn:eq(1)').click();
            }
        });
        $('.cpTitle li').click(function () {

            if ($(this).attr('class').toString() != 'tabActive') {
                $(this).siblings().removeClass('tabActive').addClass('tabNormal');
                $(this).removeClass('tabNormal').addClass('tabActive');
                var id = $(this).attr('id').toString().replace('one', '');

                $("#inputkey").val(id);
                $('#con_one_' + id).show();
                $('#con_one_' + (id.toString() == '1' ? '2' : '1')).hide();
            }
        });

        $("#imgValiateCode,#chkImgVerify").live("click", function () {
            $('#imgValiateCode').attr('src', "<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/imageVerify.aspx?rand=" + Math.random() + "&model=reg");
        });

        $("#imgValiateCode2,#chkImgVerify2").live("click", function () {
            $('#imgValiateCode2').attr('src', "<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/imageVerify.aspx?rand=" + Math.random() + "&model=reg");
        });

        var url = location.href;
        if (-1 < url.indexOf('?r=l')) {
            $('#one1').removeClass('tabActive').addClass('tabNormal');
            $('#one2').removeClass('tabNormal').addClass('tabActive');
            $('#con_one_1').hide();
            $('#con_one_2').show();
        }

        //request join
        $('.rzbtn:eq(0)').click(function () {
            var reguser = $.trim($('#txtRegName').val());
            if (reguser == '') {
                showTip('抱歉，请输入用户名！', 0);
                $('#txtRegName').focus();
                return;
            } else {
                removeShowTip();
                $.ajax({
                    url: 'ajax/ajaxuser.ashx',
                    data: 'type=checkusername&t=m&v=' + reguser.toString(),
                    dataType: 'text',
                    success: function (data) {
                        if (data.toString() == 'true') {
                            var moblie = $.trim($('#txtMoblie').val());
                            if (moblie == '') {
                                showTip('抱歉，请输入手机！', 0);
                                $('#txtMoblie').focus();
                                return;
                            }
                            else {
                                //check email or mobile
                                var reg = /^0{0,1}(13[0-9]|15[0-9]|153|156|18[0-9])[0-9]{8}$/;
                                var isMobile = reg.test(moblie);
                                reg = /^([a-zA-Z0-9]+[_|-|.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|-|.]?)*[a-zA-Z0-9]+.[a-zA-Z]{2,3}$/;
                                var isEmail = reg.test(moblie);
                                if (!isMobile && !isEmail) {
                                    showTip('输入的手机格式不对！', 0);
                                    $('#txtMoblie').focus();
                                } else {
                                    removeShowTip();
                                    $.ajax({
                                        url: 'ajax/ajaxuser.ashx',
                                        data: 'type=checkmoblieemail&t=mobliemail&v=' + moblie.toString() + '&v2=' + moblie.toString() + '&ram=' + Math.random(),
                                        dataType: 'text',
                                        success: function (data) {
                                            if (data.toString() == 'false') {
                                                var password = $.trim($('#txtRegPwd').val());
                                                var cfpassword = $.trim($('#txtChekPwd').val());
                                                if (password == '') {
                                                    showTip('抱歉，请输入登录密码！', 0);
                                                    $('#txtRegPwd').focus();
                                                } else if (password.length < 6) {
                                                    showTip('抱歉，登录密码不能少于6位！', 0);
                                                    $('#txtRegPwd').focus();
                                                } else if (cfpassword == '') {
                                                    showTip('抱歉，请输入确认密码！', 0);
                                                    $('#txtChekPwd').focus();
                                                } else if (password != cfpassword) {
                                                    showTip('登录密码与确认密码不一致！', 0);
                                                    $('#txtChekPwd').focus();
                                                } else {
                                                    var vali = $.trim($('#txtValidation').val());
                                                    if (vali == '') {
                                                        showTip('抱歉，该输入验证码！', 0);
                                                        $('#txtValidation').focus();
                                                    } else if (vali.length != 4) {
                                                        showTip('抱歉，您输入验证码有误！', 0);
                                                        $('#txtValidation').focus();
                                                    } else {
                                                        removeShowTip();
                                                        $.ajax({
                                                            url: 'ajax/ajaxuser.ashx',
                                                            data: 'v=' + vali.toString() + '&type=checkvali&t=reg&ran=' + Math.random(),
                                                            dataType: 'text',
                                                            success: function (data) {
                                                                if (data.toString() == 'true') {
                                                                    var pact = $('#regpact').attr('checked');
                                                                    if (pact) {
                                                                        var mydata = 'type=sreg&v=' + reguser.toString() + '&m=' + moblie.toString() + '&v2=' + password.toString() + '&t=';
                                                                        if (isMobile) {
                                                                            mydata += '1';
                                                                        } else {
                                                                            mydata += '0';
                                                                        }
                                                                        showTip('正在提交数据中...！', 1);
                                                                        $.ajax({
                                                                            url: 'ajax/ajaxuser.ashx',
                                                                            data: mydata,
                                                                            dataType: 'text',
                                                                            success: function (data) {
                                                                                if (data) {
                                                                                    showTip('注册成功，跳转页面中...！', 2);
                                                                                    location.href = '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/suppler/supplerindex.aspx';
                                                                                } else {
                                                                                    showTip('抱歉，系统正忙请稍后入住！', 0);
                                                                                    setTimeout('removeShowTip();', 5000); //3秒钟后消失提示信息
                                                                                }
                                                                            }
                                                                        });
                                                                    } else {
                                                                        showTip('抱歉，您需要同意注册协议！', 0);
                                                                    }
                                                                } else {
                                                                    showTip('抱歉，您输入验证码有误！', 0);
                                                                    $('#txtValidation').focus();
                                                                }
                                                            }
                                                        });
                                                    }
                                                }
                                            } else {
                                                showTip('抱歉，该手机已被注册！', 0);
                                                $('#txtMoblie').focus();
                                            }
                                        }
                                    });
                                }
                            }
                        } else {
                            showTip('抱歉，该用户名已被注册！', 0);
                            $('#txtRegName').focus();
                        }
                    }
                });
            }
        });

        $('.rzbtn:eq(1)').click(function () {
            var v = $.trim($('#txtLoginName').val());
            if (v == '') {
                showLoginTip('抱歉，请输入用户名！', 0);
                $('#txtLoginName').focus();
            } else {
                var v2 = $.trim($('#txtLoginPwd').val());
                if (v2 == '') {
                    showLoginTip('抱歉，请输入密码！', 0);
                    $('#txtLoginPwd').focus();
                } else if (v2.length < 6) {
                    showLoginTip('抱歉，密码不能少于6位！', 0);
                    $('#txtLoginPwd').focus();
                } else {
                    showLoginTip('正在提交数据中...！', 1);
                    jQuery.ajax({
                        url: 'ajax/ajaxuser.ashx',
                        data: 'type=login&v=' + v + '&v2=' + v2 + '&ram=' + Math.random(),
                        dataType: 'text',
                        success: function (data) {
                            //alert(data);
                            if (data == "1") {
                                showLoginTip('登录成功，跳转页面中...！', 2);
                                window.location = "<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/suppler/index.aspx";
                            } else if (data == "2") {
                                showLoginTip('登录成功，跳转页面中...！', 2);
                                window.location = "<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/suppler/supplerindex.aspx";
                            } else if (data == "10") {
                                showLoginTip('登录成功，跳转页面中...！', 2);
                                window.location = "<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/index.aspx";
                            } else if (data == "-1") {
                                showLoginTip('验证码有误！', 0);
                            }
                            else {
                                showLoginTip('用户名或密码错误！', 0);
                                setTimeout('removeLoginShowTip();', 5000); //3秒钟后消失提示信息
                            }
                        }
                    });
                }
            }
        });
    });

    function showTip(message, type) {
        var size = $('.loginerror').size();
        if (size == 0) {
            $('<tr class="loginerror"><td height="20"></td><td align="left">' + message + '</td></tr>').insertAfter('#con_one_1 tr:eq(5)');
        } else {
            $('.loginerror td:eq(1)').html(message);
        }
        $('#con_one_1 tr:eq(' + ($('#con_one_1 tr').size() - 1) + ') td').css('padding-top', '5px');
        if (type == 0) {
            $('.loginerror td:eq(1)').removeClass('smessage').addClass('emessage');           
        } else if (type == 1) {
            $('.loginerror td:eq(1)').removeClass('emessage').addClass('smessage');
        } else {
            $('.loginerror td:eq(1)').removeClass('smessage').addClass('omessage');
        }
    }

    function showLoginTip(message, type) {
        var size = $('.loginingerror').size();
        if (size == 0) {
            $('<tr class="loginingerror"><td height="20"></td><td align="left">' + message + '</td></tr>').insertAfter('#con_one_2 tr:eq(3)');
        } else {
            $('.loginingerror td:eq(1)').html(message);
        }
        $('#con_one_2 tr:eq(' + ($('#con_one_2 tr').size() - 2) + ') td').css('padding-top', '5px');
        if (type == 0) {
            $('.loginingerror td:eq(1)').removeClass('smessage').addClass('emessage');
        } else if (type == 1) {
            $('.loginingerror td:eq(1)').removeClass('emessage').addClass('smessage');
        } else {
            $('.loginingerror td:eq(1)').removeClass('smessage').addClass('omessage');
        }
    }

    function removeShowTip() {
        //$('.loginerror td:eq(1)').html('');
        $('.loginerror').remove();
        $('#con_one_1 tr:eq(' + ($('#con_one_1 tr').size() - 1) + ') td').css('padding-top', '15px');
    }

    function removeLoginShowTip() {
        $('.loginingerror').remove();
        $('#con_one_2 tr:eq(' + ($('#con_one_2 tr').size() - 2) + ') td').css('padding-top', '20px');
    }

    //只能输入数字
    $.fn.numeral = function () {
        $(this).css("ime-mode", "disabled");
        this.bind("keypress", function (event) {
            var isie = (document.all) ? true : false; //判断是IE内核还是Mozilla
            var keyCode = '';
            if (isie) {
                keyCode = event.keyCode;
            }
            else {
                keyCode = event.which;
                if (keyCode == 0 || keyCode == 8) {
                    return true;
                }
            }

            if (keyCode == 46) {
                if (this.value.indexOf(".") != -1) {
                    return false;
                }
            } else {
                return keyCode >= 46 && keyCode <= 57;
            }
        });
        this.bind("blur", function () {
            if (this.value.lastIndexOf(".") == (this.value.length - 1)) {
                this.value = this.value.substr(0, this.value.length - 1);
            } else if (isNaN(this.value)) {
                this.value = "";
            }
        });
        this.bind("paste", function () {
            var s = clipboardData.getData('text');
            if (!/\D/.test(s));
            value = s.replace(/^0*/, '');
            return false;
        });
        this.bind("dragenter", function () {
            return false;
        });
        this.bind("keyup", function () {
            if (/(^0+)/.test(this.value)) this.value = this.value.replace(/^0*/, '');
        });
    };  
//-->
</script>    
<ucfooter:footer ID="header2" runat="server" />
</body>
</html>