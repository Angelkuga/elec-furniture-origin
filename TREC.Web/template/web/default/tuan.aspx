<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tuan.aspx.cs" Inherits="TREC.Web.aspx.tuan" %>
<%@ Register src="ascx/_head.ascx" tagname="_head" tagprefix="uc1" %>
<%@ Register src="ascx/_resource.ascx" tagname="_resource" tagprefix="uc2" %>
<%@ Register src="ascx/_foot.ascx" tagname="_foot" tagprefix="uc3" %>
<%@ Register src="ascx/_nav.ascx" tagname="_nav" tagprefix="uc4" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=pageTitle %></title>
    <uc2:_resource ID="_resource1" runat="server" />
    <link rel="stylesheet" type="text/css" href=<%="\""+TREC.ECommerce.ECommon.WebResourceUrl%>/css/jquery.jcarousel.css" />
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl%>/script/jquery.jcarousel.pack.js"></script>
    <script type="text/javascript">
        $(function () {
            jQuery('.mycarousel').jcarousel({ auto: "1" });
        });
    </script>

    <style type="text/css">
        .tuan{float:left; width:327px; border:1px solid #CFCFCF; padding:0px 0px 10px 0px; margin:0px 10px 10px 0px;}
        .destInfo2 {border-top:1px dotted #989898;}
        .destInfo{float:left; width:317px; margin:0px 5px;}
        .destInfo p{ display:block; float:left; margin-top:10px;}
        .destInfo p.p1{width:105px; height:50px;}
        .destInfo p.p2{ background:url("http://www.fujiawang.com/images/t4_2.gif"); width:204px; height:35px; float:right; }
        .destInfo p.p2 i{ font-family:"Microsoft YaHei";font-size:30px;text-shadow:#000 1px 1px 1px;font-size:20px;font-style:normal; color:#fff; margin-left:25px; margin-top:3px;}
        .destInfo p.p3{height:15px; float:right; margin-right:10px;}
        .destInfo span.t{font-weight:bold;font-family:"Microsoft YaHei";font-size:18px;text-shadow:#eee 1px 1px 1px;color:#c10015; margin-left:5px; }
        
        div.fla{float:left; width:100%; margin:18px 0px 5px 0px;}
        div.f1{background:url('<%=TREC.ECommerce.ECommon.WebResourceUrl%>/web/images/t_fla_t1.gif');  width:300px; float:left; height:14px; margin-top:10px;}
        div.f2{background:url('<%=TREC.ECommerce.ECommon.WebResourceUrl%>/web/images/t_fla_t2.gif'); height:14px; float:left; }
        span.f3{display:block; float:left;  background:url('<%=TREC.ECommerce.ECommon.WebResourceUrl%>/web/images/t_fla_t3.gif');width:32px; height:14px; }
        
        div.i1{display:block;  float:left; width:300px;  margin-top:10px;}
        div.i1 span{line-height:25px; height:25px; float:left; display:block; text-align:center; background:url('<%=TREC.ECommerce.ECommon.WebResourceUrl%>/web/images/t_i_3.gif') no-repeat; background-position:center;}
        div.i1 span a{ font-weight:bold;}
        div.i1 span.cur{background:url('<%=TREC.ECommerce.ECommon.WebResourceUrl%>/web/images/t_i_1.gif') no-repeat; background-position:center;}
        div.i1 span.cur a{color:#fff; font-weight:bold;}
        div.i1 span.cur_on{background:url('<%=TREC.ECommerce.ECommon.WebResourceUrl%>/web/images/t_i_2.gif') no-repeat; background-position:center;}
        div.i1 span.cur_on a{color:#fff;}
        
        div.groupInfo{width:976px; float:left; height:149px; border:2px solid #b31528;background:url('<%=TREC.ECommerce.ECommon.WebResourceUrl%>/web/images/groupInfo_bg.gif') no-repeat; background-position:right;}
        
        div.groupInfo .conBox{border:2px solid #ffe7a5; height:145px; width:850px; float:left; border-right:none;}
        div.groupInfo .conTitle{color:#d00000; font-size:16px; float:left; margin-left:10px; font-weight:bold; height:30px; line-height:30px; }
        .conBox .con{background:url('<%=TREC.ECommerce.ECommon.WebResourceUrl%>/web/images/groupInfo_con_bg.png') no-repeat; margin-left:10px; width:743px; height:91px; float:left;}
        .con .fla,.con .infoT,.con .infoB{float:left; margin-top:20px; margin-left:20px;}
        .infoT p,.infoT span{ line-height:20px; height:20px; color:#636363;}
        .infoT span{ font-weight:bold;color:#cf293b; margin:0px 3px;}
    </style>
</head>
<body>
<form id="form1" runat="server">
<uc1:_head ID="_head1" runat="server" />
<uc4:_nav ID="_nav1" runat="server" />
<div class="topNav992" style="margin-top:20px;">
<%foreach(EnWebPromotionInfoList i in ECPromotionDef.GetWebPromotionInfoList(1,100,"","","",out ECommon.tmpPageCount)){ %>
<div class="tuan">
    <div class="destImg">
        <ul class="mycarousel" class="jcarousel-skin-tango" style="width:327px; height:260px;">
            <li style="width:327px; height:260px;"><a href="javascript:;"><img src="http://www.fujiawang.com/files/Group/SmallShow/2011122817312715.jpg" width="327px" height="260px" /></a></li>
            <li style="width:327px; height:260px;"><a href="javascript:;"><img src="http://www.fujiawang.com/files/Group/Silde/2011122817173690.jpg" width="327px" height="260px" /></a></li>
        </ul>
    </div>
    <div class="destInfo">
        <p class="p1"><img src="http://www.jiajuks.com//upload/brand/logo/328/2012032516584655.gif" width="105" height="38" /></p>
        <p class="p2"><i>暂未开团</i></p>
        <p class="p3"><strong>开团日期：</strong>2011-10-10</p>
    </div>
    <div class="destInfo destInfo2">
        <span class="t"><%=i.title %></span>
    </div>
    <div class="destInfo">
        <div class="fla" >
            <div class="i1">
                <%for (int j = 0; j < i.stagecount; j++)
                  { %>
                    <%if (j < int.Parse(i.curstage))
                      { %>
                    <span style="width:<%=Math.Round((decimal)300/5, 2) %>px; "  class="cur_on"><a href="#"><%=j %>折</a></span>
                    <%} %>
                    <%if (j == int.Parse(i.curstage))
                      { %>
                    <span style="width:<%=Math.Round((decimal)300/5, 2) %>px; "  class="cur"><a href="#"><%=j %>折</a></span>
                    <%} %>
                    <%if (j > int.Parse(i.curstage))
                      { %>
                    <span style="width:<%=Math.Round((decimal)300/5, 2) %>px; "><a href="#"><%=j %>折</a></span>
                    <%} %>  
               <%} %>
            </div>
            <div class="f1">
                <div class="f2" style="width:<%=(Math.Round((decimal)3 / 5, 2)*300).ToString()%>px">&nbsp;</div>
                <span class="f3"><a href="#"><%=(Math.Round((decimal)int.Parse(i.curstage) / int.Parse(i.stagecount.ToString()), 2)*300).ToString()%></a></span>
            </div>
        </div>
    </div>
</div>
<%} %>


<br><br><br>
<%if (ECPromotionDef.ExtWebPromotionDefByBrand(56,52)>0){ %>

<div class="groupInfo">
    <div class="conBox">
        <div class="conTitle">本品牌参与拼团活动</div>
        <div  class="con">
            <div class="fla" style="width:310px;">
            <div class="i1">
                <%for (int j = 0; j < 5; j++)
                  { %>
                    <%if (j < 3)
                      { %>
                    <span style="width:<%=Math.Round((decimal)300/5, 2) %>px; "  class="cur_on"><a href="#"><%=j %>折</a></span>
                    <%} %>
                    <%if (j == 3)
                      { %>
                    <span style="width:<%=Math.Round((decimal)300/5, 2) %>px; "  class="cur"><a href="#"><%=j %>折</a></span>
                    <%} %>
                    <%if (j > 3)
                      { %>
                    <span style="width:<%=Math.Round((decimal)300/5, 2) %>px; "><a href="#"><%=j %>折</a></span>
                    <%} %>  
               <%} %>
            </div>
            <div class="f1">
                <div class="f2" style="width:<%=(Math.Round((decimal)3 / 5, 2)*300).ToString()%>px">&nbsp;</div>
                <span class="f3"><a href="#">&nbsp;</a></span>
            </div>
        </div>
            <div class="infoT">
                <p>目前折扣力度：<span>4</span>折</p>
                <p>目前报名人数：<span>452</span>人</p>
                <p>目前预计金额：<span>5224412.4</span>元</p>
            </div>
            <div class="infoB">
                <a href="javascript:;"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl%>/web/images/groupInfo_baoming.png" width="196px" height="62px" /></a>
            </div>
        </div>
        
    </div>
</div>

<%} %>
</div>


<uc3:_foot ID="_foot1" runat="server" />
</form>
</body>
</html>
