<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.index" %>

<%@ OutputCache Duration="10" VaryByParam="none" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="Haojibiz.Model" %>
<%@ Import Namespace="Haojibiz.Data" %>
<%@ Import Namespace="Haojibiz.DAL" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>家具快搜 - 中国品牌家具信息发布官网【www.jiajuks.com】,家具品牌,家具厂商,家具店铺,家居卖场营销平台</title>
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <meta http-equiv="X-UA-Compatible" content="IE=7;IE=9;IE=8">
    <meta name="keywords" content="家具品牌,家具品牌排名,家具十大品牌,品牌家具,实木家具十大品牌,儿童家具十大品牌,板式家具十大品牌">
    <meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！">
  
  
    <script src="/resource/content/js/core.js" type="text/javascript"></script>
    <link href="/resource/content/indexnav/yx_rotaion.css" rel="stylesheet" type="text/css" />
    <script src="/resource/content/indexnav/jquery.min.js" type="text/javascript"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/index/index.js"></script> 
    <style type="text/css">
        /*弹出框*/
        .topstyle
        {
            position: absolute;
            background-color: #000000;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            z-index: 9999999998;
            display: none;
            opacity: 0.0;
        }
        .divopenv
        {
            width: 300px;
            height: 300px;
            position: fixed;
            z-index: 9999999998;
            display: none;
            opacity: 0.0;
        }
        /*弹出框*/
    </style>
    <style>
        .login a
        {
            padding: 5px 10px;
            background: #fbc219;
            color: #b9003c;
            border-radius: 5px;
        }
        body
        {
           
         }
         
         .tab_con {display: none; overflow: hidden; padding:10px 10px 0; height:185px;}
.tab_conbox{border-top:1px solid #b9003c; margin-top:-1px;}
.tabs { height: 32px; width: 100%; }
.tabs li { height: 32px;text-align:center; float: left;margin-left:10px; }
.tabs li a { color:#868585; display: block;font-family:"microsoft yahei"; padding:0px 15px;font-size:14px; line-height:30px;font-weight:bold;background:#fff; border-radius:5px 5px 0 0;}
.tabs .thistab a, .tabs .thistab a:hover {color: #b9003c;border:1px solid #b9003c; background:#fff;line-height:31px;border-bottom:none}
.bynr{ width:214px; height:45px; padding:3px;margin-bottom:2px; border-radius:5px;border: 1px solid #c0c0c0;}.gdxq{ background: url(/resource/content/images/xq.gif) no-repeat right;font-family:"microsoft yahei"; padding-right:22px;}
.bynrr{ border: 1px solid #c0c0c0;width:212px; height:20px; margin-bottom:8px;border-radius:5px;padding:3px;}
.bynrr1{ border: 1px solid #c0c0c0;width:110px; float:left; height:20px; margin-bottom:8px;border-radius:5px;padding:3px;}
.bynrr11
{
margin: 3px 5px 8px 10px;
float: left;
    }
.bynrn{ width:80px; color:#fff;border:none; cursor:pointer; line-height:22px; margin-bottom:5px;font-size:14px;padding:3px;font-family:"microsoft yahei"; background:#b9003c; border-radius:6px; margin-right:65px;}
.byqh a{ width:212px; float:left; color:#6a6a6a;}
.byqh a.gd{background: url(/resource/content/img/common/j5.png) no-repeat right center;padding-right: 16px; text-align:right;}

.conby{ width:619px; margin:30px auto; padding:90px 260px 30px 20px; border:1px solid #f10148; border-bottom:20px solid #f10148;background:url(/resource/images/us.gif) no-repeat; font-family:"microsoft yahei"; font-size:14px;}
.conby span{font-size:12px; color:#7b7a7a;} .conby p{ margin:25px 0} 
.conbyi{ width:612px; height:145px;}.conbyii{ width:200px; height:30px;} 
.bynri{ width:160px; color:#fff;border:none; cursor:pointer; line-height:35px; margin-bottom:5px;font-size:18px;padding:3px;font-family:"microsoft yahei"; background:#c81033; border-radius:6px;}
.conbyy{ width:569px; margin-top:10px;line-height:35px;padding:20px;}
.conbyy a{ color:#095fa1; margin:0 5px;}
.fileInput{width:102px;height:28px; background: url(/resource/images/12.png);overflow:hidden;position:relative;}
.upfile{position:absolute;top:-100px;}
.upFileBtn{width:102px;height:28px;opacity:0;filter:alpha(opacity=0);cursor:pointer;}


.tgbody
{
   border-left-width : 1px;
   border-right-width :1px;
	border-bottom-width :1px;
	border-left-color : #D2D2D2;
	border-right-color : #D2D2D2;
	border-bottom-color : #D2D2D2;
	border-left-style : solid;
	border-right-style : solid;
	border-bottom-style : solid; 
	height:339px;
	padding-top:0px;
 }
.tgbody table
{
    margin-top:0px;
 }
 .tgbody1
 {
     padding-top:10px;
  }
   .tgbody1 li
   {
   width:285px;
   height:304px;
   border-width :1px;
	border-style : solid;
	border-color : #D2D2D2;
	float:left;
	margin-right:17px;
   }
    .tgbody1_title
    {
        padding-top:12px;
        font-size:14px;
        color:#333333;
        font-weight:bold;
     }
      .tgbody1_img
      {
          margin-top:15px;
          width:266px;
          height:176px;
          overflow:hidden;
      }
      .tgbody1_imgdiv
      {
     filter:alpha(Opacity=80);
    -moz-opacity:0.5;
    opacity: 0.5;
    z-index:100;
    background-color:#000000;
    width:266px;
    height:25px;
    position:absolute;
    bottom:0px; 
          }
           .tgbody1_imgdivdiv
           {
      position:absolute;
    bottom:0px; 
            color:#ffffff; 
            width:266px;
    padding-top:2px;
    z-index:210;
    font-size:13px;
    font-weight:bold;
    height:25px;
            }
            .tgbody1_bnt
            {
              
               width:266px;
               height:46px;
               margin-top:18px;
               text-align:left;
               }
          .tgbody1_bnt div
          {
              padding-top:10px;
              padding-left:20px;
              font-size:20px;
              color:#fff;
              font-weight:bold;
           }      
    </style>
     
    <script type="text/javascript">
        //活动报名 -start
        function addBAOMING(Pid, Ptitle, Purl) {
            <%if (TRECommon.CookiesHelper.GetCookieCustomer("cid") != ""){ %>
                $("#ifr").attr("src","/addBaoMing.aspx?Pid=" + Pid + "&Ptitle=" + Ptitle + "&prodcon=1"); 
                $("#ifr").attr("width","374");
                $("#ifr").attr("height","523"); 
                $("#divsj").css("width","374px");
                $("#divsj").css("height","523px");
            <%}else{ %>
                $("#ifr").attr("src","/addloginuser.aspx");
                $("#ifr").attr("width","502");
                $("#ifr").attr("height","488"); 
                $("#divsj").css("width","502px");
                $("#divsj").css("height","488px");
            <%} %>
            funopen("divsj");
        }
        //-------------弹出div begin------------------------ 
        function funbgopen() {
            $("#divop").height($(document).height());
            $("#divop").show();
            $("#divop").animate({ opacity: 0.6 }, "slow");

        }
        function funopen(id) {

            funbgopen();

            var w = $("#" + id).width();
            var h = $("#" + id).height();

            var winwid = $(window).width();
            var winheight = $(window).height();
            var sw = (winwid - w) / 2;
            var sh = (winheight - h) / 2;

            $("#" + id).css("left", sw);
            $("#" + id).css("top", sh);
            $("#" + id).show();
            $("#" + id).animate({ opacity: 1.0 }, "slow");


        }
        function funclose(id) {
            $("#divop").hide();
            $("#" + id).hide();
            $("#ifr").attr("src","");
        }

        $(document).ready(function() {
	jQuery.jqtab = function(tabtit,tab_conbox,shijian) {
		$(tab_conbox).find("li").hide();
		$(tabtit).find("li:first").addClass("thistab").show(); 
		$(tab_conbox).find("li:first").show();
	
		$(tabtit).find("li").bind(shijian,function(){
		  $(this).addClass("thistab").siblings("li").removeClass("thistab"); 
			var activeindex = $(tabtit).find("li").index(this);
			$(tab_conbox).children().eq(activeindex).show().siblings().hide();
			return false;
		});
	
	};
	$.jqtab("#tabs","#tab_conbox","mouseenter");
	
});

function funimgcheck()
{
    $("#imgcheck").attr("src",$("#imgcheck").attr("src")+"?");
}
        //-------------弹出div end---divsj---------------------------
        //活动报名 -start
    </script>


<script language="javascript" type="text/javascript">
    function tgloopfun(t,ulinput,indexinput) {

        var licount = parseInt($("#" + ulinput + " li").length);
        var pageindex = parseInt($("#" + indexinput).val());
     
        if(licount > 1) {
            if (t == '+') {
                pageindex = pageindex + 1;
                if (pageindex >= licount) {
                    pageindex = 0;
                }
            }
            if (t == '-') {
                pageindex = pageindex - 1;
                if (pageindex < 0) {
                    pageindex = licount-1;
                }
            }
            $("#" + indexinput).val(pageindex);
            $("#" + ulinput + " li").each(
            function (i) {
                if (i == pageindex) {
                    $(this).fadeIn(500);
                }
                else {
                    $(this).hide();
                }
            }
            )
            
        }
    }
    function funtimeloop1() {
        tgloopfun('+', "tgulloop1", "tgloop1");
    }
    function funtimeloop2() {
        tgloopfun('+', "tgulloop2", "tgloop2");
    }
    var timer1 = setInterval(funtimeloop1, 4000);
    var timer2 = setInterval(funtimeloop2, 4000);

    function funcleartime1() {
        clearInterval(timer1);
    }

    function funcleartime2() {
        clearInterval(timer2);
    }
    function funout1() {
        timer1 = setInterval(funtimeloop1, 4000);
    }
    function funout2() {
        timer2 = setInterval(funtimeloop2, 4000);
    }
</script>

<script language="javascript" type="text/javascript">

    function showbrandletter(id) {
        $("#divbrandtitleList div").hide();
        $("#" + id).show();
    }
</script>
</head>
<body >
    <%--<div  style="width: 100%; height: 108px; overflow: hidden; position: relative;
        background-color: red; background: url(/resource/content/images/sxx.jpg) center no-repeat;cursor:pointer;"  onclick="javascript:location.href='/51/default.aspx'">
    
        <a href='/reg.aspx' style="position: absolute; top: 397px; left: 203px; width: 935px;
            height: 25px; z-index: 31px;display:none;"></a>
    </div>--%>
    <uc1:header ID="header1" runat="server" />
      <link href="/resource/content/css/index/index.css" rel="stylesheet" type="text/css" />
    <div class="advert" id="j_advert">
        <div>
            <div id='navindex' >
               
            </div>
        </div >
        
         <div style="position:relative;z-index:5;" >
        
        <div style="position:absolute;width:750px;height:330px;left:300px;bottom:5px;cursor:pointer;z-index:5" onclick="window.open('/51/default.aspx');void(0);">
        </div>
        </div>
        <div class="advert-box-wrap" >
            <div class="w">
                <!----有求必应 begin----->
                <div class="advert-box">
                
                    <ul class="tabs" id="tabs">
        <li class="thistab"><a href="javascript:void(0)" >有求必应</a></li>
        <li><a href="javascript:void(0)">快搜快报</a> </li>
      </ul>
      <ul class="tab_conbox" id="tab_conbox">
        <li class="tab_con"><textarea placeholder="请输入需求信息" class="bynr"  id="txtDescription"></textarea><input placeholder="请输入手机号码"  onblur="funcheckphone()" class="bynrr" type="text" id="txtphone" maxlength="15">
<input placeholder="请输入验证码"  class="bynrr1" type="text" id="txtcode" maxlength="5">
<img src="/common/VerifyCode.aspx" class="bynrr11"  id="imgcheck"  title="看不清，换一张！" onclick="this.src=this.src+'?'" alt=""/>
<input type="button" value="提交"class="bynrn" onclick="BingYingAdd()" id="bntbying" >
<img src="/resource/content/images/wait.gif"  id="imgwait" style="display:none;margin:0 80px 0 50px;"/>

<a target="_blank" 

href="/biyinglist.aspx" class="gdxq">更多需求</a></li>
        <li class="tab_con">
        <div class="byqh">

        <% foreach (System.Data.DataRow dr in promsdt.Rows)
                           { %>
                      <a target="_blank" href="/promotions/<%=dr["id"] %>/info.aspx"><i>.</i>
                            <%=dr["title"].ToString().Length<15?dr["title"].ToString():dr["title"].ToString().Substring(0, 15)%>
                        </a>
                        <%} %>
       <a href="/promotions/list.aspx" class="gd">更多</a></div></li>

      </ul>
                    <div class="login">
                        <p style="font-size: 18px;">
                            入驻家具快搜</p>
                        <a href="/reg.aspx">申请入驻</a> <a href="/reg.aspx?r=l">商家登录</a>
                    </div>
                </div>
                <!---有求必应 end------>
            </div>
        </div>
    </div>


    <!--新加品牌功能 begin--------->
    <div class="brand-intro  w">
        <div class="hd clearfix"  style="border-bottom:2px solid #2f2f2f;">
            <h2 class="f18 yahei fl mr10">
                家具品牌</h2>
            <a href="companybrandlist.aspx" target="_blank" class="fr more">更多</a>
            <div class="sub-tit fr">
                <%--<a href="companybrandlist.aspx" target="_blank">中式家具</a> <a href="companybrandlist.aspx"
                    target="_blank">欧式家具</a> <a href="companybrandlist.aspx" target="_blank">韩式田园</a>
                <a href="companybrandlist.aspx" target="_blank">东南亚风格</a>--%>
            </div>
        </div>

        <div>
        <div class="nbrandletter">
        <div >
        <%=indbrandLetter%>
        </div>
        </div>
        <div class="nbrandlettercon" id="divbrandtitleList">
        <%=indbrandtitle%>
        </div>

        <div>
        <table border="0" cellpadding="0" cellspacing="0"><tr>
        
        <td valign="top" class="nbrand_left">
        <div class="nbrand_left1" style="height:60px;">
       <%-- <a href="javascript:void(0);" onmouseover="checkbrand(1)" style="float:left;">行业前25品牌</a>
         <a  style="float:right;" href="javascript:void(0);" onmouseover="checkbrand(2)">高端品牌</a>--%>
    
          <a href="javascript:void(0);" onmouseover="checkbrand(3)" style="float:left;margin-left:11px;">热门品牌</a>
           <a href="javascript:void(0);" onmouseover="checkbrand(1)" style="float:right;margin-right:11px;">大牌推荐</a>
        </div>
        <div class="nbrand_left2" >
        <table border="0"> 
        <tr>
        <td class="nbrand_left2td" id="tdbrand_style5" onmouseover="checkbrand(5)">
        <span>现代简约</span><br />
        都市青年最爱
        </td><td class="nbrand_left2td2" id="tdbrand_style6" onmouseover="checkbrand(6)">
       <span>韩式田园</span><br />
       温暖可爱小清新
        </td>
        </tr>
            <tr>
        <td class="nbrand_left2td2" id="tdbrand_style7" onmouseover="checkbrand(7)">
        <span>   欧美</span><br />
        体验奢华生活
        </td><td class="nbrand_left2td2" id="tdbrand_style8" onmouseover="checkbrand(8)">
        <span>北欧宜家</span><br />
        极致简洁舒适风
        </td>
        </tr>
        </table>
        </div>
        <div class="nbrand_left_bo"  style="height:90px;">
         <table border="0">
        <tr><td><span style="float:left;color:#AF0F28;font-size:15px;font-weight:bold;margin-top:40px;margin-left:40px;" onmouseover="checkbrand(9)">全实木家具品牌</span> 
        <span style="float:left;margin-left:50px;display:none;" onmouseover="checkbrand(10)">实木框架</span> 
         <span style="float:right;display:none;" onmouseover="checkbrand(11)">板式</span> 
         </td> </tr>
    
        <tr  style="display:none;"><td> <span style="float:left;" onmouseover="checkbrand(12)">布艺</span> <span style="float:left;margin-left:72px;" onmouseover="checkbrand(13)">藤艺</span>  <span style="float:right;" onmouseover="checkbrand(14)">皮艺</span></td> </tr>
        </table>
        </div>
        <div class="nbrand_left_cen">
       <a href="/companybrandlist.aspx?n=2" target="_blank"><img src="/resource/images/indexmore.jpg" /></a>
        </div>
        <div> </div>
        </td> 
        
        <td class="nbrand_zhong" valign="top" align="left">
         <!--company begin--->
         <div style="width:100%;height:100%;display:block;" id="divbrand0">
         <div style="height:70px;"><table border="0" cellpadding="0" cellspacing="0"><tr><td style="width:525px;">
         <div class="nbrand_zhong_title">
         <a href="#" id="ban_company"></a><br />
         <span id="ban_style" style="display:none;">风格：</span> <span id="ban_material" style="display:none;">材质：</span> <span id="ban_address"></span> <span id="ban_phone"></span>
          </div>
         </td><td align="center" valign="middle"><a href="" id="ban_logourl" target="_blank"> <img src="" border="0"  style="width:170px;height:50px;margin-top:2px;" id="ban_logo"/> </a> </td> </tr>  </table> </div>

         <div>
     <a href="#" id="ban_imgurl" target="_blank">
         <img src="" style="width:700px;height:323px;margin-left:12px;"  border="0" id="ban_img"/>
         </a>
         </div>


         </div>
         <!--company end---> 
       <!--brand begin-->
       <!--行业前20品牌-->
       <div class="nbrand_list" style="display:none;" id="divbrand1">
       <ul>
           <asp:Repeater ID="Repeater_brand2" runat="server">
           <ItemTemplate>
       <li><a href="/ShopBrand.aspx?bname=<%#Eval("Title") %>" target="_blank"><img src="/upload/brand/logo/<%#Eval("id") %>/<%#Eval("logo").ToString().Replace(",","") %>"  border="0"/> </a></li>
          </ItemTemplate>
           </asp:Repeater>
          </ul>
       </div>
       <!---高端品牌 广告位--->
       <div id="divbrand2" style="display:none;" class="nbrand_list">
       <ul>
           <asp:Repeater ID="Repeater_gd" runat="server">
           <ItemTemplate>
       <li><a target="_blank" href="<%#Eval("linkurl")%>"><img border="0" src="/upload/show/thumb/<%#Eval("Id")%>/<%#Eval("imgurl").ToString().Replace(",","") %>"> </a></li>
         </ItemTemplate>
           </asp:Repeater>
          </ul>
       </div>

       <!---人气品牌------>
       <div class="nbrand_list" style="display:none;" id="divbrand3">
       <ul>
           <asp:Repeater ID="Repeater_brand3" runat="server">
           <ItemTemplate>
       <li><a href="/ShopBrand.aspx?bname=<%#Eval("Title") %>" target="_blank"><img src="/upload/brand/logo/<%#Eval("id") %>/<%#Eval("logo").ToString().Replace(",","") %>"  border="0"/> </a></li>
          </ItemTemplate>
           </asp:Repeater>
          </ul>
       </div>

       <!---新品牌推荐--->
       <div class="nbrand_list" style="display:none;" id="divbrand4">
       <ul>
           <asp:Repeater ID="Repeater_brand4" runat="server">
           <ItemTemplate>
       <li><a href="/ShopBrand.aspx?bname=<%#Eval("Title") %>" target="_blank"><img src="/upload/brand/logo/<%#Eval("id") %>/<%#Eval("logo").ToString().Replace(",","") %>"  border="0"/> </a></li>
          </ItemTemplate>
           </asp:Repeater>
          </ul>
       </div>

       <!---现代---->
       <div class="nbrand_list" style="display:none;" id="divbrand5">
       <ul>
           <asp:Repeater ID="Repeater_brand5" runat="server">
           <ItemTemplate>
       <li><a href="/ShopBrand.aspx?bname=<%#Eval("Title") %>" target="_blank"><img src="/upload/brand/logo/<%#Eval("id") %>/<%#Eval("logo").ToString().Replace(",","") %>"  border="0"/> </a></li>
          </ItemTemplate>
           </asp:Repeater>
          </ul>
       </div>

         <!---田园---->
         <div class="nbrand_list" style="display:none;" id="divbrand6">
       <ul>
           <asp:Repeater ID="Repeater_brand6" runat="server">
           <ItemTemplate>
       <li><a href="/ShopBrand.aspx?bname=<%#Eval("Title") %>" target="_blank"><img src="/upload/brand/logo/<%#Eval("id") %>/<%#Eval("logo").ToString().Replace(",","") %>"  border="0"/> </a></li>
          </ItemTemplate>
           </asp:Repeater>
          </ul>
       </div>
        <!---美式---->

        <div class="nbrand_list" style="display:none;" id="divbrand7">
       <ul>
           <asp:Repeater ID="Repeater_brand7" runat="server">
           <ItemTemplate>
       <li><a href="/ShopBrand.aspx?bname=<%#Eval("Title") %>" target="_blank"><img src="/upload/brand/logo/<%#Eval("id") %>/<%#Eval("logo").ToString().Replace(",","") %>"  border="0"/> </a></li>
          </ItemTemplate>
           </asp:Repeater>
          </ul>
       </div>
        <!---北欧宜家---->

        <div class="nbrand_list" style="display:none;" id="divbrand8">
       <ul>
           <asp:Repeater ID="Repeater_brand8" runat="server">
           <ItemTemplate>
       <li><a href="/ShopBrand.aspx?bname=<%#Eval("Title") %>" target="_blank"><img src="/upload/brand/logo/<%#Eval("id") %>/<%#Eval("logo").ToString().Replace(",","") %>"  border="0"/> </a></li>
          </ItemTemplate>
           </asp:Repeater>
          </ul>
       </div>
       <!--全实木-->
       <div class="nbrand_list" style="display:none;" id="divbrand9">
       <ul>
           <asp:Repeater ID="Repeater_brand9" runat="server">
           <ItemTemplate>
       <li><a href="/ShopBrand.aspx?bname=<%#Eval("Title") %>" target="_blank"><img src="/upload/brand/logo/<%#Eval("id") %>/<%#Eval("logo").ToString().Replace(",","") %>"  border="0"/> </a></li>
          </ItemTemplate>
           </asp:Repeater>
          </ul>
       </div>
        <!--实木框架-->
        <div class="nbrand_list" style="display:none;" id="divbrand10">
       <ul>
           <asp:Repeater ID="Repeater_brand10" runat="server">
           <ItemTemplate>
       <li><a href="/ShopBrand.aspx?bname=<%#Eval("Title") %>" target="_blank"><img src="/upload/brand/logo/<%#Eval("id") %>/<%#Eval("logo").ToString().Replace(",","") %>"  border="0"/> </a></li>
          </ItemTemplate>
           </asp:Repeater>
          </ul>
       </div>
       <!--板式-->
       <div class="nbrand_list" style="display:none;" id="divbrand11">
       <ul>
           <asp:Repeater ID="Repeater_brand11" runat="server">
           <ItemTemplate>
       <li><a href="/ShopBrand.aspx?bname=<%#Eval("Title") %>" target="_blank"><img src="/upload/brand/logo/<%#Eval("id") %>/<%#Eval("logo").ToString().Replace(",","") %>"  border="0"/> </a></li>
          </ItemTemplate>
           </asp:Repeater>
          </ul>
       </div>
          <!--布艺-->
          <div class="nbrand_list" style="display:none;" id="divbrand12">
       <ul>
           <asp:Repeater ID="Repeater_brand12" runat="server">
           <ItemTemplate>
       <li><a href="/ShopBrand.aspx?bname=<%#Eval("Title") %>" target="_blank"><img src="/upload/brand/logo/<%#Eval("id") %>/<%#Eval("logo").ToString().Replace(",","") %>"  border="0"/> </a></li>
          </ItemTemplate>
           </asp:Repeater>
          </ul>
       </div>

         <!--藤艺-->
         <div class="nbrand_list" style="display:none;" id="divbrand13">
       <ul>
           <asp:Repeater ID="Repeater_brand13" runat="server">
           <ItemTemplate>
       <li><a href="/ShopBrand.aspx?bname=<%#Eval("Title") %>" target="_blank"><img src="/upload/brand/logo/<%#Eval("id") %>/<%#Eval("logo").ToString().Replace(",","") %>"  border="0"/> </a></li>
          </ItemTemplate>
           </asp:Repeater>
          </ul>
       </div>

       <!--皮艺-->
       <div class="nbrand_list" style="display:none;" id="divbrand14">
       <ul>
           <asp:Repeater ID="Repeater_brand14" runat="server">
           <ItemTemplate>
       <li><a href="/ShopBrand.aspx?bname=<%#Eval("Title") %>" target="_blank"><img src="/upload/brand/logo/<%#Eval("id") %>/<%#Eval("logo").ToString().Replace(",","") %>"  border="0"/> </a></li>
          </ItemTemplate>
           </asp:Repeater>
          </ul>
       </div>

       <!--brand end-->
        </td>
        
        <td class="nbrand_right">
        <%=brand_adleft %>
        </td> </tr> </table>
        </div>
        </div>

        <div style="">
        <table border="0" cellpadding="0" cellspacing="0" class="nbrand_ad">
        <tr><td>
        <%=brand_ad1%>
        </td> <td>
                <%=brand_ad2%>
        </td><td>
                 <%=brand_ad3%>
        </td><td >
               <%=brand_ad4%>
        </td><td style="width:241px;">
                <%=brand_ad5%>
        </td></tr>
        </table>
        </div>
        </div>
   <!---新加品牌功能 end---------->
    <div class="brand-intro  w" style="display:none;">
        <div class="hd clearfix"  style="border-bottom:2px solid #2f2f2f;">
            <h2 class="f18 yahei fl mr10">
                品牌推荐</h2>
            <a href="companybrandlist.aspx" target="_blank" class="fr more">更多</a>
            <div class="sub-tit fr">
                <%--<a href="companybrandlist.aspx" target="_blank">中式家具</a> <a href="companybrandlist.aspx"
                    target="_blank">欧式家具</a> <a href="companybrandlist.aspx" target="_blank">韩式田园</a>
                <a href="companybrandlist.aspx" target="_blank">东南亚风格</a>--%>
            </div>
        </div>
        <div class="bd clearfix" id='divtj'>
            <div class="focus fl">
                <%foreach (t_advertising item in list1)
                  { %>
                <a href="<%=item.linkurl %>" title="<%=item.title %>" target="_blank">
                    <img style='width: 230px; height: 180px;' src='<%=item.imgurl %>' alt="<%=item.title %>"
                        class="block" /></a>
                <%} %>
            </div>
            <div class="list fr">
                <table class="g10">
                    <tbody>
                        <tr>
                            <%
                                int i = 1;
                                foreach (t_advertising items in newBrand)
                                {%>
                            <%if (i == 8) this.Response.Write("</tr><tr>");%>
                            <td>
                                <a href="<%=items.linkurl%>" target="_blank">
                                    <img src="<%=items.imgurl%>" /></a>
                            </td>
                            <%i++;
                                } %>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
  
    
  <!------团购 begin------->
    <div class="week-special time-rush clearfix w"  >
        <div class="list-time fl">
            <div class="hd clearfix">
                <h2 class="f18 yahei fl mr10">
                    团购专版</h2>
                <a href="/51/default.aspx" target="_blank" class="fr more">更多</a>
            </div>
            <div class="tgbody">
                <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                <td style="width:230px;height:339px;">
                <a href="/51/default.aspx" target="_blank"><img src="/resource/images/51/6-3hd.jpg" /> </a>
                </td>
                <td style="width:725px;" valign="top">
               <center style="padding-top:10px;">
               <a href="/51/default.aspx#brand5" target="_blank"> <image src="/resource/images/51/6-3datu.jpg" /></a> </center>
                </td>
                <td  valign="top">
              <a href="51/default.aspx#brand4" target="_blank"><img src="/resource/content/images/51/51top3.jpg" /></a>
                </td>
                </tr>
                </table>
            </div>
            <div class="tgbody1">
            <ul>
            <li>
           <center><div  class="tgbody1_title" target="_blank"><a href="/51/default.aspx#brand6">【大普】实木框架 床 DB12CB</a></div></center>
           <center>
           <div class="tgbody1_img">
           <a href="/51/default.aspx#brand6" target="_blank"><img src="/resource/images/51/6-3-1.jpg"  style="width:266px;height:176px;"/> </a>
           <div style="position:relative;">
           <div class="tgbody1_imgdiv">
           </div>
             <div class="tgbody1_imgdivdiv">
             报名<%=getEnterUser("363",1,"5")%>人</div>
           </div>
           </div>
           
           <center>
          
           <div class="tgbody1_bnt">
            <a href="/51/default.aspx#brand6" target="_blank"><img src="/resource/images/51/6-3a1.jpg"  border="0"/>  </a>
           </div>
           
           </center>
           </center>
            </li>
             <li>
            <center><div  class="tgbody1_title" ><a href="/51/default.aspx#brand12" target="_blank">【柏逸轩】全实木 餐椅 CB106B</a></div></center>
           <center>
           <div class="tgbody1_img">
           <a href="/51/default.aspx#brand12" target="_blank"><img src="/resource/images/51/6-3-2.jpg"  style="width:266px;height:176px;"/> </a>
           <div style="position:relative;">
           <div class="tgbody1_imgdiv">
             
             
           </div>
           <div class="tgbody1_imgdivdiv">
           报名<%=getEnterUser("53", 1, "8")%>人</div>
           </div>
           </div>
           
           <center>
          
           <div class="tgbody1_bnt">
            <a href="/51/default.aspx#brand12" target="_blank"><img src="/resource/images/51/6-3a2.jpg"  border="0"/>  </a>
           </div>
           
           </center>
           </center>
            </li>
             <li>
             <center><div  class="tgbody1_title" ><a href="/51/default.aspx#brand13" target="_blank">【爱凡】全实木 学生桌 QM-1</a></div></center>
           <center>
           <div class="tgbody1_img">
           <a href="/51/default.aspx#brand13" target="_blank"><img src="/resource/images/51/6-3-3.jpg"  style="width:266px;height:176px;"/> </a>
           <div style="position:relative;">
           <div class="tgbody1_imgdiv">
           </div>
             <div class="tgbody1_imgdivdiv">报名<%=getEnterUser("363", 1, "6")%>人</div>
           </div>
           </div>
           
           <center>
          
           <div class="tgbody1_bnt">
            <a href="/51/default.aspx#brand13" target="_blank"><img src="/resource/images/51/6-3-a3.jpg"  border="0"/>  </a>
           </div>
           
           </center>
           
           </center>
            </li>
             <li style="float:right;margin-right:0px;">
            <center><div  class="tgbody1_title"><a href="/51/default.aspx#brand4" target="_blank">【全友家私】板式 餐桌 QY81707A</a></div></center>
           <center>
           <div class="tgbody1_img">
           <a href="/51/default.aspx#brand4"><img src="/resource//images/51/6-3-4.jpg"  style="width:266px;height:176px;"/> </a>
           <div style="position:relative;">
           <div class="tgbody1_imgdiv">
           </div>
             <div class="tgbody1_imgdivdiv">报名<%=getEnterUser("401", 1, "14")%>人</div>
           </div>
           </div>
           
           <center>
           <div class="tgbody1_bnt">
            <a href="/51/default.aspx#brand4"><img src="/resource//images/51/6-3a4.jpg"  border="0"/>  </a>
           </div>
           </center>
           </center>
            </li>
            </ul>
            </div>
        </div>
       
    </div>
    <!------团购 end------->
   
    <div class="week-special time-rush clearfix w" id="j_timeRush">
        <div class="list-time fl">
            <div class="hd clearfix">
                <h2 class="f18 yahei fl mr10">
                    限时抢购</h2>
                <a href="#" target="_blank" class="fr more">更多</a>
            </div>
            <div class="bd">
                <ul>
                    <li class="li0"><a href="#" target="_blank">
                        <img src="../../resource/content/img/index/xsqg.jpg" alt="" class="block" />
                    </a></li>
                    <%
                        i = 1;
                        string imgstyle = "";
                        foreach (t_advertising items in timeLimiBuy)
                        {
                            if (i == 2 || i == 6)
                                imgstyle = "width:382px;height:240px;";
                            else
                                imgstyle = "width:190px;height:240px;";
                    %>
                    <li class="li<%=i %>" data-endtime="<%=items.endtime.ToString().Replace('-','/') %>">
                        <a href="<%=items.linkurl %>" target="_blank">
                            <img src="<%=items.imgurl %>" class="block" style="<%=imgstyle%>" />
                            <div class="txt">
                                <div class="p1">
                                    剩余 <span class="day">00</span> 天 <span class="shi">00</span> 时 <span class="fen">
                                        00</span> 分 <span class="miao">00</span> 秒 </div>
                                <p class="p2">
                                    <%=items.title%></p>
                                <p class="p2">
                                    <del>原价：<%=items.orgprice%></del></p>
                                <p class="p3">
                                    <u>抢购:<%=items.price%></u></p>
                            </div>
                        </a></li>
                    <%i++;
                        } %>
                </ul>
            </div>
        </div>
        <div class="list-sad fr">
            <%
                int list2count = 0;
                string list2style = "";
                foreach (t_advertising item in list2)
                {

                    if (list2count == 0)
                        list2style = "width:240px;height:287px;";
                    else
                        list2style = "width:240px;height:190px;";
                    list2count++;
            %>
            <a href="<%=item.linkurl %>" class="block a1" title="<%=item.title %>" target="_blank">
                <img src='<%=item.imgurl %>' style="<%=list2style%>" alt="<%=item.title %>" class="block" /></a>
            <%} %>
        </div>
    </div>
    <br />
   
    <div class="week-special clearfix w">
        <div class="list-time fl">
            <div class="hd clearfix">
                <h2 class="f18 yahei fl mr10">
                    本周特价</h2>
                <a href="#" target="_blank" class="fr more">更多</a>
            </div>
            <div class="bd">
                <ul>
                    <li class="li0"><a href="#" target="_blank">
                        <img src="../../../resource/content/img/index/h19.jpg" alt="" class="block" />
                    </a></li>
                    <%
                        i = 1;
                        foreach (t_advertising items in timeLimiBuyB)
                        {
                            if (i == 2 || i == 6)
                                imgstyle = "width:382px;height:240px;";
                            else
                                imgstyle = "width:190px;height:240px;";
                    %>
                    <li class="li<%=i %>"><a href="<%=items.linkurl %>" target="_blank">
                        <img src="<%=items.imgurl%>" class="block" style="<%=imgstyle%>" />
                        <div class="txt">
                            <p class="p1">
                                <%=items.title%></p>
                            <p class="p2">
                                <del>原价：<%=items.orgprice%></del></p>
                            <p class="p3">
                                <u>特价:<%=items.price%></u></p>
                        </div>
                    </a></li>
                    <%i++;
                        } %>
                </ul>
            </div>
        </div>
        <div class="list-sad fr">
            <%
                int list3count = 0;
                string list3style = "";
                foreach (t_advertising item in list3)
                {

                    if (list3count == 0)
                        list3style = "width:240px;height:287px;";
                    else
                        list3style = "width:240px;height:190px;";
                    list3count++;
            %>
            <a href="<%=item.linkurl %>" class="block a1" title="<%=item.title %>" target="_blank">
                <img src='<%= item.imgurl %>' style="<%=list3style%>" alt="<%=item.title %>" class="block" /></a>
            </a>
            <%} %>
        </div>
    </div>
    <br />
    <br />
    <div class="tao-trea w">
        <div class="tab">
            <div class="hd clearfix">
                <h2 class="f18 yahei fl" id="addProductPOP">
                    淘宝贝</h2>
                <ul>
                    <%=tbbdl %>
                </ul>
                <a href="productlisttbb.aspx" target="_blank" class="fr songti more">更多</a> <span
                    class="fr sub-tit  f666">在这里，你可以用最实惠的价格买到厂家的库存产品</span>
            </div>
            <div class="bd" style='background-color: #F2F2F2;'>
                <%=tbbxlxq2 %>
            </div>
        </div>
    </div>
    <br />
    <!--商家活动导购开始-->
    <div class="step-view w" id="j_stepView" style="padding-bottom: 2px; margin-bottom: 5px;">
        <div class="tab">
            <div class="hd clearfix">
                <h2 class="f18 yahei fl">
                    商家活动导购</h2>
                <ul style='margin-left: 40px;'>
                    <%=dgtitle %>
                    <%-- <li class="on">商场</li>
                    <li>品牌</li>
                    <li>厂商</li>
                    <li>店铺</li>--%>
                </ul>
                <a href="/guide.aspx" target="_blank" class="fr songti more">更多</a>
            </div>
            <div class="bd">
                <%=strbdt.ToString()%>
            </div>
        </div>
    </div>
    <!--商家活动导购结束-->
    <div class="step-view w" id="j_stepView"  style="height:auto;">
        <div class="tab"  style="height:auto;">
            <div class="hd clearfix">
                <h2 class="f18 yahei fl">
                    逛卖场</h2>
                <ul>
                    <%=strb.ToString() %>
                    <%-- <li class="on">宝山区</li>
                    <li>长宁区</li>
                    <li>虹口区</li>
                    <li>嘉定区</li>--%>
                </ul>
                <a href="market/list.aspx" target="_blank" class="fr songti more"  >更多</a>
            </div>
            <div  style="height:auto;">
               <div>
            <%=market_adtop%>
               </div>
                <div style="" class="nmarketbottom">
              
               <ul>
                   <asp:Repeater ID="Repeater_brandmarket" runat="server">
                   <ItemTemplate>
                <li>
                 <a href="<%#Eval("linkurl") %>" target="_blank"><img  src="/upload/show/thumb/<%#Eval("Id")%>/<%#Eval("imgurl").ToString().Replace(",","")%>" /></a> <br />
                <center><a href="<%#Eval("linkurl") %>" target="_blank"><%#Eval("title").ToString().Split('/')[0]%></a>
                <span><%#Eval("title").ToString().Split('/').Length > 1 ? Eval("title").ToString().Split('/')[1] : ""%></span>
                </center>
                </li>
                   </ItemTemplate>
                   </asp:Repeater>

                </ul>
                </div>
            </div>
        </div>
    </div>

    <!--弹出窗口-->
    <div class="topstyle" id="divop"></div> 
    <div class="divopenv" id="divsj" style=""><iframe src="" id="ifr" ></iframe></div>
    <!--弹出窗口-->

    <ucfooter:footer ID="header2" runat="server" />
    <script src="../../../resource/content/indexnav/jquery.yx_rotaion.js" type="text/javascript"></script>
    <script type="text/javascript">


        sydt("");
        //gmc("");

        $("[id*='navindex_']").each(function (i) {
            $(this).yx_rotaion({ during: 3000, auto: true, position: 50, title: true, id: $(this).attr("id") });
        });

        $(function () {
            $(".pull-down").removeClass("hide");
        });

        function getdid(did, xid) {

            $.ajax({
                async: false, //是否异步
                url: '../../../ajax/hdsearch.ashx?t=tbb&xid=' + xid + '&did=' + did + '&m=' + Math.random(),
                type: 'post', //post方法
                success: function (data) {
                    $("#divinfo" + did).html(data);

                },
               // error: function () { alert('错误'); }
            });
        }

    </script>
    <script type="text/javascript">
        function reduceDiv() {
            var A = arguments[0]
            var O = document.getElementById(A);
            var reduce = parseInt(arguments[1]);
            var nextReduce;
            O.style.backgroundImage = "url(/resource/content/images/sxx.jpg)";
            $("#ad").height(108);
            if (!reduce) {
                reduce = parseInt(O.style.height);
            }
            if (reduce > 108) {
                $("#ad").height(reduce);
                //O.style.height = reduce; 
                nextReduce = reduce - 2;
                setTimeout(function () {
                    reduceDiv(A, nextReduce)
                },
                    10);
            } else {
                O.style.backgroundImage = "url(/resource/content/images/sxx.jpg)";
            }
        }

                setTimeout(function () {
                    //reduceDiv("ad");
                }, 1000);


                function funcheckphone() {
                    var phone = $("#txtphone").val();

                    if (phone == '') {
                        alert('手机号码不能为空');
                        return;
                        window.event.returnValue = false;
                    }
                    if ($.trim(phone) != '') {
                        var reg = new RegExp(/((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/);
                        var input = $.trim(phone);
                        if (!reg.test(input) & input != '') {
                            $("#txtphone").focus();
                            alert('手机号码有误');
                            return;
                            window.event.returnValue = false;
                        }
                    }
                }
                function BingYingAdd() {
                    var Description = $("#txtDescription").val();
                    var phone = $("#txtphone").val();
                    var code = $("#txtcode").val();
                    var Msg = "";
                    var ImgPath = "";

                    if (phone == '') {
                        alert('手机号码不能为空');
                        return;
                        window.event.returnValue = false;
                    }

                    if ($.trim(phone) != '') {
                        var reg = new RegExp(/((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/);
                        var input = $.trim(phone);
                        if (!reg.test(input) & input != '') {
                            alert('手机号码有误');
                            return;
                            window.event.returnValue = false;
                        }
                    }
                   
                    if ($.trim(Description) == '') {
                        alert('提交内容不能为空');
                        return;
                    }

                    if (Description.length>500) {
                        alert('字符串长度不能超过500个字符');
                        return;
                    }
               
                    if (code == '') {
                        alert('验证码不能为空');
                        return;
                    }
                    $("#bntbying").hide();
                    $("#imgwait").show();
                    $.post("/ajax/ajaxBingYing.aspx", { "Description": Description, "phone": phone, "Msg": Msg, "ImgPath": ImgPath, "code": code }, function (data, textStatus) {
                        $("#bntbying").show();
                        $("#imgwait").hide();
                        if (data == 'true') {
                            $("#txtDescription").val('');
                            $("#txtphone").val('');
                            $("#txtcode").val('');
                            alert('您的需求已经提交成功！我们会尽快受理，请耐心等待');
                        }
                        else {
                            alert(data);
                            funimgcheck();
                        }
                    }, null);
                }

    </script>

    <script language="javascript" type="text/javascript">

        var brandjson =<%=indbrandurl %>
        function searchbrna(bname) {
       checkbrand(0);
        $("#ban_company").html(brandjson[bname].company);
        $("#ban_company").attr("href",brandjson[bname].url);
        $("#ban_imgurl").attr("href",brandjson[bname].url);
        $("#imgurl").attr("href",brandjson[bname].url);
        $("#ban_img").attr("src",brandjson[bname].bannel);//  $("#ban_img").attr("src","http://www.jiajuks.com/"+brandjson[bname].bannel);
        $("#ban_logourl").attr("href",brandjson[bname].url);
        $("#ban_logo").attr("src",brandjson[bname].logo);//$("#ban_logo").attr("src","http://www.jiajuks.com/"+brandjson[bname].logo);
        $("#ban_style").html("风格："+brandjson[bname].style);
        $("#ban_material").html("材质："+brandjson[bname].material);
        $("#ban_address").html(brandjson[bname].address);
        $("#ban_phone").html(brandjson[bname].phone);
        }
        searchbrna('<%=firstBrandTitle %>');


      function checkbrand(id)
      {
        for(var i=0;i<=14;i++)
        {
          $("#divbrand"+i).hide();
        }
        if(id>4&&id<=8)
        {
            for(var j=5;j<=8;j++)
            {
                $("#tdbrand_style"+j).attr("class","nbrand_left2td2");
            }
            $("#tdbrand_style"+id).attr("class","nbrand_left2td");
        }
        $("#divbrand"+id).show();
      }
    </script>

</body>
</html>
