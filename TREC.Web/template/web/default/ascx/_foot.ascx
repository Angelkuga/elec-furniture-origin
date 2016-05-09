<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_foot.ascx.cs" Inherits="TREC.Web.aspx.ascx._foot" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>

<div class="copyright">
<p>友情链接|标签云|<a href="/gywm.html">企业介绍</a>|<a href="/lxwm.html">联系我们</a></p>
<p>Copyright © <a href="<%=TREC.ECommerce.ECommon.WebUrl %>">家具快搜</a>（www.jiajuks.com） &nbsp;沪ICP备12034118号</p>
<p><img src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/index_130.jpg" /> <a href="#"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/index-08.jpg" /></a> <a href="#"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/index-09.jpg" /></a> <a href="#"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/index-10.jpg" /></a></p>
</div>


<script type="text/javascript">

    var _gaq = _gaq || [];
    _gaq.push(['_setAccount', 'UA-29901941-1']);
    _gaq.push(['_trackPageview']);

    (function () {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
    })();

</script>
<script type="text/javascript">
    var _bdhmProtocol = (("https:" == document.location.protocol) ? " https://" : " http://");
    document.write(unescape("%3Cscript src='" + _bdhmProtocol + "hm.baidu.com/h.js%3F91f7d5c30539521e5de3dbe0889f845e' type='text/javascript'%3E%3C/script%3E"));
</script>

<script src="http://s19.cnzz.com/stat.php?id=4297930&web_id=4297930&show=pic1" language="JavaScript"></script>

<!-- JiaThis Button BEGIN -->
<script type="text/javascript" >
    var jiathis_config = {
        siteNum: 15,
        sm: "qzone,tsina,tqq,renren,kaixin001,taobao,douban,xiaoyou,baidu,tieba,hi,qq,tianya,51,diandian",
        summary: "",
        boldNum: 3,
        marginTop: 388,
        showClose: true,
        hideMore: false
    }
</script>
<script type="text/javascript" src="http://v3.jiathis.com/code/jiathis_r.js?btn=r5.gif&move=0" charset="utf-8"></script>
<!-- JiaThis Button END -->


<script type="text/javascript">
    (function () {
        var $backToTopTxt = "", $backToTopEle = $('<div class="backToTop"></div>').appendTo($("body"))
        .text($backToTopTxt).attr("title", $backToTopTxt).click(function () {
            $("html, body").animate({ scrollTop: 0 }, 120);
        }), $backToTopFun = function () {
            var st = $(document).scrollTop(), winh = $(window).height();
            (st > 700) ? $backToTopEle.show() : $backToTopEle.hide();
            //IE6下的定位
            if (!window.XMLHttpRequest) {
                $backToTopEle.css("top", st + winh - 166);
            }
        };
        $(window).bind("scroll", $backToTopFun);
        $(function () { $backToTopFun(); });
    })();
</script>
