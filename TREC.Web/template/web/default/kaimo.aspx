<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.kaimo" %>

<%@ Register Src="ascx/_resource.ascx" TagName="_resource" TagPrefix="uc1" %>
<%@ Register Src="ascx/_head.ascx" TagName="_head" TagPrefix="uc2" %>
<%@ Register Src="ascx/_foot.ascx" TagName="_foot" TagPrefix="uc3" %>
<%@ Register Src="ascx/_nav.ascx" TagName="_nav" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>家具快搜楷模十一专场活动！</title>
<meta name="keywords" content="家具品牌,家具品牌排名,家具十大品牌,品牌家具,实木家具十大品牌,儿童家具十大品牌,板式家具十大品牌">
<meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！">
    <uc1:_resource ID="_resource1" runat="server" />
<style>
 #focus {width:650px; height:430px; overflow:hidden; position:relative;}
#focus ul {height:430px; position:absolute;}
#focus ul li {float:left; width:650px; height:430px; overflow:hidden; position:relative; background:#000;}
#focus ul li div {position:absolute; overflow:hidden;}
#focus .btnBg {position:absolute; width:650px; height:40px; left:0; bottom:0; background:#000;}
#focus .btn {position:absolute; width:650px; height:24px; left:0; bottom:8px; padding-left:10px; text-align:right;background: none;}
#focus .btn span {display:inline-block; _display:inline; _zoom:1; width:24px; height:24px; line-height:24px; text-align:center; font-size:20px; font-family:"Microsoft YaHei",SimHei; margin-right:10px; cursor:pointer; color:#fff;}
#focus .btn span.on {background:#000; color:#fcc;}
</style>
<script type="text/javascript">
    $(function () {
        var sWidth = $("#focus").width(); //获取焦点图的宽度（显示面积）
        var len = $("#focus ul li").length; //获取焦点图个数
        var index = 0;
        var picTimer;

        //以下代码添加数字按钮和按钮后的半透明长条
        var btn = "<div class='btnBg'></div><div class='btn'>";
        for (var i = 0; i < len; i++) {
            btn += "<span>" + (i + 1) + "</span>";
        }
        btn += "</div>"
        $("#focus").append(btn);
        $("#focus .btnBg").css("opacity", 0.5);

        //为数字按钮添加鼠标滑入事件，以显示相应的内容
        $("#focus .btn span").mouseenter(function () {
            index = $("#focus .btn span").index(this);
            showPics(index);
        }).eq(0).trigger("mouseenter");

        //本例为左右滚动，即所有li元素都是在同一排向左浮动，所以这里需要计算出外围ul元素的宽度
        $("#focus ul").css("width", sWidth * (len + 1));



        //鼠标滑上焦点图时停止自动播放，滑出时开始自动播放
        $("#focus").hover(function () {
            clearInterval(picTimer);
        }, function () {
            picTimer = setInterval(function () {
                if (index == len) { //如果索引值等于li元素个数，说明最后一张图播放完毕，接下来要显示第一张图，即调用showFirPic()，然后将索引值清零
                    showFirPic();
                    index = 0;
                } else { //如果索引值不等于li元素个数，按普通状态切换，调用showPics()
                    showPics(index);
                }
                index++;
            }, 3000); //此3000代表自动播放的间隔，单位：毫秒
        }).trigger("mouseleave");

        //显示图片函数，根据接收的index值显示相应的内容
        function showPics(index) { //普通切换
            var nowLeft = -index * sWidth; //根据index值计算ul元素的left值
            $("#focus ul").stop(true, false).animate({ "left": nowLeft }, 500); //通过animate()调整ul元素滚动到计算出的position
            $("#focus .btn span").removeClass("on").eq(index).addClass("on"); //为当前的按钮切换到选中的效果
        }

        function showFirPic() { //最后一张图自动切换到第一张图时专用
            $("#focus ul").append($("#focus ul li:first").clone());
            var nowLeft = -len * sWidth; //通过li元素个数计算ul元素的left值，也就是最后一个li元素的右边
            $("#focus ul").stop(true, false).animate({ "left": nowLeft }, 500, function () {
                //通过callback，在动画结束后把ul元素重新定位到起点，然后删除最后一个复制过去的元素
                $("#focus ul").css("left", "0");
                $("#focus ul li:last").remove();
            });
            $("#focus .btn span").removeClass("on").eq(0).addClass("on"); //为第一个按钮添加选中的效果
        }
    });

</script>
</head>
<body>
    <uc2:_head ID="_head1" runat="server" />
    <uc4:_nav ID="_nav1" runat="server" />
    
    
<div class="km">
	<div class="km-hd"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/km-1.jpg" alt="楷模活动"/></div>
    <!--/km-hd-->
    <div class="km-bd">
    	<div class="km-m">
        	<div class="km-m-h"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/km-2.jpg" alt="楷模活动"/></div>
            <div class="km-reg-tip"><a name="1"></a><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/km-png1.png" alt="1"/></div>
            <div class="km-reg fix">
            	<div class="l" id="focus">
                	<ul>
                    	<li><div><a href="http://www.fujiawang.com/cantingtaozuhe/581-1/"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/km-7.jpg" alt="楷模餐厅系列7件套"/></a></div></li>
                        <li><div><a href="http://www.fujiawang.com/shugui/4046/"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/km-8.jpg" alt="拿铁 LEAMING朗宁组合书柜 "/></a></div></li>
                        <li><div><a href="http://www.fujiawang.com/ketingtaozuhe/596-1/"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/km-9.jpg" alt="大普客厅系列8件套塞娜沙发"/></a></div></li>
                    </ul>
                    
                </div>
                <div class="r">
                        <input type="text" id="txtname" class="name" />
                        <input type="text" id="txtcontact" class="tel" />
                        <a href="javascript:void(0)" id="wantgo">立即报名抢购</a>
                    </div>
                    <script type="text/javascript">
                        $(document).ready(function () {
                            $("#wantgo").live("click", function () {
                                var name = $("#txtname").val();
                                name = name.replace(/[ ]/g, "");
                                if (name == "") {
                                    $("#txtname").val('');
                                    $("#txtname").focus();
                                    alert("抱歉，请输入您的姓名！");
                                    return;
                                }
                                else if (name.length < 2 || name.length > 8) {
                                    $("#txtname").focus();
                                    alert("抱歉，请输入正确的姓名！");
                                    return;
                                }
                                var contact = $("#txtcontact").val();
                                contact = contact.replace(/[ ]/g, "");
                                var regstr = /^0{0,1}(13[0-9]|15[0-9]|153|156|18[0-9])[0-9]{8}$/; //手机13，15，18开头的验证
                                if (!regstr.test(contact)) {
                                    $("#txtcontact").focus();
                                    alert("抱歉，请输入正确的手机号！");
                                    return;
                                }

                                $.ajax({
                                    url: "<%=TREC.ECommerce.ECommon.WebUrl %>/ajax/ajaxmsgcollection.ashx",
                                    data: "name=" + name + "&contact=" + contact,
                                    dataType: "text",
                                    success: function (data) {
                                        if (data == "true") {
                                            $("#txtname").val('');
                                            $("#txtcontact").val('');
                                            alert('恭喜，报名成功！入场验证码已经发送到您的手机，请查收！');
                                        }
                                        else if (data == "haveName") 
                                        {
                                            alert('抱歉，您的手机号码已经提交过一次了！');
                                        }
                                        else {
                                            alert('抱歉，暂时无法报名，请联系网站客服！')
                                        }
                                    }
                                });
                            });
                        }); 
                    </script>
            </div>
        </div>
        <!--/km-reg-->
        <div class="km-m">
        	<div class="km-m-h"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/km-4.jpg" alt="楷模活动"/></div>
            <div class="km-txt-tip"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/km-png2.png" alt="1"/></div>
            <div class="km-txt">
            	<p class="p1">“花好月圆迎中秋，普天同庆庆国庆”，在这个金色的收获季节，我们和家人团聚中秋，我们和祖国欢度国庆！在这双节来临的特殊日子里，楷模上海文定路盛源店给您意想不到的惊喜价格！只要在这里
					预先报名的客户即可享受劲爆最低价，购买到您心怡的楷模、大普、拿铁所有产品。一年仅此一次，不要错过哟！
                </p>
                <p class="p2">活动时间：10月1日到7日</p>
                <p class="p2">活动地址：徐汇区文定路200号盛源大地家居城  展位号：楷模2C03，大普2C01、2D01，拿铁2D06</p>
            </div>
        </div>
        <!--/km-txt-->
        <div class="km-m">
        	<div class="km-m-h"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/km-5.jpg" alt="楷模活动"/></div>
            <div class="km-pro-tip"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/km-png3.png" alt="1"/></div>
            <ul class="km-pro fix">
            	<li>
                	<p class="p1"><a href="http://www.fujiawang.com/woshitaozuhe/589-1/"><img src="http://www.fujiawang.com/files/productgroup/big/589/20120904182705.jpg"/></a></p>
                    <p class="p2"><a href="http://www.fujiawang.com/woshitaozuhe/589-1/">楷模 卧室系列 2件套 现代风格 家具 奥米床AMTZH</a></p>
                    <p class="p3"><a href="#1"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/km-6.jpg"/></a></p>
                </li>
                <li>
                	<p class="p1"><a href="http://www.fujiawang.com/ketingtaozuhe/591-1/"><img src="http://www.fujiawang.com/files/productgroup/big/591/20120906162434.jpg"/></a></p>
                    <p class="p2"><a href="http://www.fujiawang.com/ketingtaozuhe/591-1/">大普 客厅系列 5件套 现代风格 家具 迪奥沙发DATZH</a></p>
                    <p class="p3"><a href="#1"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/km-6.jpg"/></a></p>
                </li>
                <li>
                	<p class="p1"><a href="http://www.fujiawang.com/dianshigui/4987/"><img src="http://www.fujiawang.com/files/product/big/1004630/20120903154017.jpg"/></a></p>
                    <p class="p2"><a href="http://www.fujiawang.com/dianshigui/4987/">楷模 电视柜 现代风格 实木框架+板材+贴木皮 家具 TV04沃顿电视柜</a></p>
                    <p class="p3"><a href="#1"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/km-6.jpg"/></a></p>
                </li>
                <li>
                	<p class="p1"><a href="http://www.fujiawang.com/ketingtaozuhe/595-1/"><img src="http://www.fujiawang.com/files/productgroup/big/595/20120913170917.jpg"/></a></p>
                    <p class="p2"><a href="http://www.fujiawang.com/ketingtaozuhe/595-1/">大普 客厅系列 4件套 现代风格 家具 大风沙发DFTZH</a></p>
                    <p class="p3"><a href="#1"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/km-6.jpg"/></a></p>
                </li>
                <li>
                	<p class="p1"><a href="http://www.fujiawang.com/shufangtaozuhe/624-1/"><img src="http://www.fujiawang.com/files/productgroup/big/624/20120914143640.jpg"/></a></p>
                    <p class="p2"><a href="http://www.fujiawang.com/shufangtaozuhe/624-1/">大普 书房系列 3件套 现代风格 家具 歌地书柜GDTZH</a></p>
                    <p class="p3"><a href="#1"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/km-6.jpg"/></a></p>
                </li>
                <li>
                	<p class="p1"><a href="http://www.fujiawang.com/canzhuo/4042/"><img src="http://www.fujiawang.com/files/product/big/1003690/20110225113446.jpeg"/></a></p>
                    <p class="p2"><a href="http://www.fujiawang.com/canzhuo/4042/">拿铁 DEEBO迪宝 圆餐桌 现代风格 实木框架+板材+贴木皮 家具 DBYCT迪宝</a></p>
                    <p class="p3"><a href="#1"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/km-6.jpg"/></a></p>
                </li>
            </ul>
          </div>
        <!--/km-pro-->
        <div class="km-ft"><a href="http://www.jiajuks.com/company/84/index.aspx">查看全部活动产品>></a></div>
    </div>
    <!--/km-bd-->
</div>
    <uc3:_foot ID="_foot1" runat="server" />
</body>
</html>
