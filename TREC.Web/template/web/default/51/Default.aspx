<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TREC.Web.template.web._51.Default" %>
<%@ Register Src="../ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>


<!DOCTYPE html>
<html>
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=7;IE=9;IE=8">
   <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
 <title>【家具卖场】家具卖场十大品牌,家具价格,家具品牌,家具卖场团购 - 家具快搜</title>
<meta name="keywords" content="家具卖场十大品牌,家具价格,家具品牌,家具卖场团购" />
<meta name="description" content="家具快搜网的卖场频道，传递家具卖场十大品牌分布情况，家具卖场团购促销活动等信息，健康家居,定制家具,高档家具,古典家具,新古典家具,儿童家具,家具品牌,家具品牌排名等均来家具快搜网。"/>
    
    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css">
    
   <script src="/resource/content/indexnav/jquery.min.js" type="text/javascript"></script>
   <script src="/resource/content/js/core.js" type="text/javascript"></script>
    <script src="/resource/content/js/_src/index/index.js" type="text/javascript"></script>
 
    
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

    <script type="text/javascript">
        //活动报名 -start
        function addBAOMING(Pid, Ptitle, Purl,brandid,brandName,number) {

            $("#ifr").attr("src", "/addBaoMing.aspx?Pid=" + Pid + "&Ptitle=" + Ptitle + "&prodcon=1&brandid=" + brandid + "&brandName=" + brandName + "&number=" + number); 
                $("#ifr").attr("width","374");
                $("#ifr").attr("height","523"); 
                $("#divsj").css("width","374px");
                $("#divsj").css("height","523px");
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
        //addBaoMing.aspx?Pid=&Ptitle=康帝星&prodcon=1&brandid=53&brandName=康帝星
        function funclose(id) {
            $("#divop").hide();
            $("#" + id).hide();
            $("#ifr").attr("src","");
        }

        function funchangeprice() {
            var ifrurl = $("#ifr").attr("src");
            var str = new Array();
            str = ifrurl.split("&");
            var spanid = str[3].split("=")[1];
            $("#spanyx" + spanid).html(parseInt($("#spanyx" + spanid).html()) + 1);
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


        function fungroup(id)
        {
           for(var i=1;i<=6;i++)
           {
           $("#licon"+i).hide();
            $("#tabli"+i).attr("class","");
           
           }
            $("#licon"+id).show();
            $("#tabli"+id).attr("class","thistab");
        }
    </script>
</head>

<body>

  
     <uc1:header ID="header1" runat="server" />
    


    <div  style="background-image:url(http://www.jiajuks.com/resource/content/img/common/j3.jpg);height:378px;width:1600px;">

    </div>


     <!--菜单开始-->
<div class="tuang">
  <div class="tuanghd" style="display:none;"><a href="#"><img src="/resource/content/images/51/bn2.jpg" width="1150" height="351" alt=""/></a> </div>
  <div class="tuang2">
    <div class="tuang21"> 参加团购品牌
      <ul class="tabs51" id="">
        <li id="tabli1" onmousemove="fungroup('1')" class="thistab"><a href="javascript:void(0)" >全部</a></li>
        <li id="tabli2" onmousemove="fungroup('2')"><a href="javascript:void(0)">沙发</a> </li>
        <li id="tabli3" onmousemove="fungroup('3')"><a href="javascript:void(0)">全实木</a> </li>
        <li id="tabli4" onmousemove="fungroup('4')"><a href="javascript:void(0)">儿童</a> </li>
        <li id="tabli5" onmousemove="fungroup('5')"><a href="javascript:void(0)">现代板式</a> </li>
        <li id="tabli6" onmousemove="fungroup('6')"><a href="javascript:void(0)">床垫</a> </li>
      </ul>
    </div>
    <div class="tuangjs">
      <ul class="tab_conbox" id="tab_conbox">
        <li  style="display:block;"  id="licon1">
            <asp:Repeater ID="Repeater_All" runat="server">
            <ItemTemplate>
            <div class="tgpp" onclick="window.location='#brand<%#Eval("Id")%>'"><img src="<%#checkurl(Eval("brandImgUrl").ToString(),Eval("brandId").ToString(),Eval("ImgUrl").ToString()) %>" width="131" height="36" alt=""/><br>
            <%#Eval("brandName")%><br>
           已有<span><%#Eval("allp")%></span>人报名</div>
            </ItemTemplate>
            </asp:Repeater>
        </li>
        <li style="display:none;" id="licon2">
        <asp:Repeater ID="Repeater_data1" runat="server">
            <ItemTemplate>
            <div class="tgpp" onclick="window.location='#brand<%#Eval("Id")%>'"><img src="<%#checkurl(Eval("brandImgUrl").ToString(),Eval("brandId").ToString(),Eval("ImgUrl").ToString()) %>" width="131" height="36" alt=""/><br>
            <%#Eval("brandName")%><br>
           已有<span><%#Eval("allp")%></span>人报名</div>
            </ItemTemplate>
            </asp:Repeater>
        </li>
        <li style="display:none;" id="licon3">
        <asp:Repeater ID="Repeater_data2" runat="server">
            <ItemTemplate>
            <div class="tgpp" onclick="window.location='#brand<%#Eval("Id")%>'"><img src="<%#checkurl(Eval("brandImgUrl").ToString(),Eval("brandId").ToString(),Eval("ImgUrl").ToString()) %>" width="131" height="36" alt=""/><br>
            <%#Eval("brandName")%><br>
          已有<span><%#Eval("allp")%></span>人报名</div>
            </ItemTemplate>
            </asp:Repeater>
        </li>
        <li style="display:none;" id="licon4">
        <asp:Repeater ID="Repeater_data3" runat="server">
            <ItemTemplate>
            <div class="tgpp" onclick="window.location='#brand<%#Eval("Id")%>'"><img src="<%#checkurl(Eval("brandImgUrl").ToString(),Eval("brandId").ToString(),Eval("ImgUrl").ToString()) %>" width="131" height="36" alt=""/><br>
            <%#Eval("brandName")%><br>
            已有<span><%#Eval("allp")%></span>人报名</div>
            </ItemTemplate>
            </asp:Repeater>
        </li>
        <li style="display:none;" id="licon5">
        <asp:Repeater ID="Repeater_data4" runat="server">
            <ItemTemplate>
            <div class="tgpp" onclick="window.location='#brand<%#Eval("Id")%>'"><img src="<%#checkurl(Eval("brandImgUrl").ToString(),Eval("brandId").ToString(),Eval("ImgUrl").ToString()) %>" width="131" height="36" alt=""/><br>
            <%#Eval("brandName")%><br>
            已有<span><%#Eval("allp")%></span>人报名</div>
            </ItemTemplate>
            </asp:Repeater>
        </li>

         <li style="display:none;" id="licon6">
        <asp:Repeater ID="Repeater_data5" runat="server">
            <ItemTemplate>
            <div class="tgpp" onclick="window.location='#brand<%#Eval("Id")%>'"><img src="<%#checkurl(Eval("brandImgUrl").ToString(),Eval("brandId").ToString(),Eval("ImgUrl").ToString()) %>" width="131" height="36" alt=""/><br>
            <%#Eval("brandName")%><br>
           已有<span><%#Eval("allp")%></span>人报名</div>
            </ItemTemplate>
            </asp:Repeater>
        </li>

      </ul>
    </div>

    
      <asp:Repeater ID="Repeater_tuan" runat="server" 
          onitemdatabound="Repeater_tuan_ItemDataBound">
      <ItemTemplate>
      <div class="tuangpp" id="brand<%#Eval("Id")%>">
      <h1>大牌团购<span>挑战全网最低价</span></h1>
      <div class="tgcp1"><img src="<%#checkurl(Eval("brandImgUrl").ToString(),Eval("brandId").ToString(),Eval("ImgUrl").ToString()) %>" width="180" height="44" alt=""/><br>
        材质：实木      风格：欧式 <br>
       <%#geturl(Eval("brandId").ToString())%>
        
         <br>

        <%#Eval("Title")%><br>
        <em>线下体验馆：<%#Eval("Unline")%></em><br>
        <span>展位号：</span><i><%#Eval("ShowPosition")%></i></div>
      <div class="tgcp2">
        <div class="tgcp21">
          <div class="tgcp211">
             <div class="flexslider">
	    <ul class="slides">
            <%#getBrandProc(Eval("brandId").ToString())%>
	    </ul>
  </div>
          </div>
          <img src="/resource/content/images/51/j.png" class="tuj" width="40" height="41" alt=""/>
         
        </div>
       <div class="tgcp22"> 当前折扣<span><%#Eval("zk").ToString()%></span>折</div>
      </div>
      <div class="tgcp3">
        <div class="tgcp31">
          <div style="color:Red;"><i><%#Eval("DiscountBegin")%></i>折起</div>
          确认有效订单
          <br>
            <%#Eval("DiscountPerson1")%>人以上<span><%#Eval("DiscountResult1")%>折</span><br>
          <%#Eval("DiscountPerson2")%>人以上<span><%#Eval("DiscountResult2")%>折</span> </div>
         
        <div class="tgcp32">消费者以支付10%订金为有效订单。<br>活动期间可以提前出单，以活动结束时终团购折扣价为准，超出的部分可以返还现金、直接抵扣余款或获得积分兑换礼品.<a href="/51/Activity.aspx" target="_blank">【查看活动细则】</a> </div>
        <div class="tgcp33">已确认订单<span><%#Eval("qr")%></span>人<%#getct(Eval("brandId").ToString()) %><br>
意向报名<span id="spanyx<%#Eval("brandId")%>"><%#Eval("yx")%></span>人<a href="javascript:onclick=addBAOMING('','<%#Eval("brandName")%>','<%#Eval("Id")%>','<%#Eval("brandId")%>','<%#Eval("brandName")%>','<%#Eval("yx")%>')">意向报名</a></div>
      </div>
    </div>
      </ItemTemplate>
      </asp:Repeater>

  </div>
</div>

 <!--弹出窗口-->
    <div class="topstyle" id="divop"></div> 
    <div class="divopenv" id="divsj" style=""><iframe src="" id="ifr"></iframe></div>
    <!--弹出窗口-->
  <ucfooter:footer ID="header2" runat="server" />
<script type="text/javascript">
    $(window).load(function () {
        $('.flexslider').flexslider();
    });
	</script>


</body>
</html>
