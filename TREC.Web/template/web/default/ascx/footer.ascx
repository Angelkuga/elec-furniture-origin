<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="footer.ascx.cs" Inherits="TREC.Web.aspx.ascx.footer" %>
<style>
    .backToTop
    {
        display: none;
        padding: 26px;
        background-image: url(/resource/images/backtop.gif);
        background-repeat: no-repeat;
        vertical-align: middle;
        position: fixed;
        _position: absolute;
        right: 5px;
        bottom: 5px;
        _bottom: "auto";
        cursor: pointer;
        opacity: .8;
        filter: Alpha(opacity=60);
    }
</style>
<div class="footer">
<div style="position:relative;">
<div style="position:absolute;right:100px;">
<table border="0">
<tr><td>家具快搜订阅号：jiajuks</td> </tr>
<tr><td><img src="/resource/images/weixin.jpg" /> </td> </tr>
</table>
</div>
 </div>
    <p class="p1">
        <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/yqlj.aspx">友情链接</a> | <a
            href="#">标签云</a> | <a target="_blank" href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/gywm.aspx">
                企业介绍</a> | <a target="_blank" href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/lxwm.aspx">
                    联系我们</a> | <a href="#">招聘纳士</a> | <a href="#">网站地图</a> | <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/reg.aspx"
                        target="_blank">供应商加盟</a> | <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/reg.aspx?r=l"
                            target="_blank">供应商登录</a>
    </p>
    <p class="p3">
        Copyright &copy; <a href="http://www.jiajuks.com/">家具快搜</a>（www.jiajuks.com） &nbsp;沪ICP备12034118号</p>
    <p class="p4">
        <p>
            <img src="/resource/web/images/index_130.jpg">
            <a href="#">
                <img src="/resource/web/images/index-08.jpg"></a> <a href="#">
                    <img src="/resource/web/images/index-09.jpg"></a> <a href="#">
                        <img src="/resource/web/images/index-10.jpg"></a>
        </p>
    </p>
</div>
<!-- 外接网站统计 BEGIN -->

<script type="text/javascript">    var cnzz_protocol = (("https:" == document.location.protocol) ? " https://" : " http://"); document.write(unescape("%3Cspan id='cnzz_stat_icon_1254641769'%3E%3C/span%3E%3Cscript src='" + cnzz_protocol + "s95.cnzz.com/z_stat.php%3Fid%3D1254641769' type='text/javascript'%3E%3C/script%3E"));</script>

<script>
    var _hmt = _hmt || [];
    (function () {
        var hm = document.createElement("script");
        hm.src = "//hm.baidu.com/hm.js?a4d29f534554a8a9fa350c29e13f5688";
        var s = document.getElementsByTagName("script")[0];
        s.parentNode.insertBefore(hm, s);
    })();
</script>
<!-- 商桥begin -->
<script type="text/javascript">
    var _bdhmProtocol = (("https:" == document.location.protocol) ? " https://" : " http://");
    document.write(unescape("%3Cscript src='" + _bdhmProtocol + "hm.baidu.com/h.js%3F4e62b71116a6327f97e6ba6b7c00a270' type='text/javascript'%3E%3C/script%3E"));
</script>
<!-- 商桥END -->
<!-- 外接网站统计 END -->

<!-- JiaThis Button BEGIN -->
<script type="text/javascript">
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
<script type="text/javascript" src="http://v3.jiathis.com/code/jiathis_r.js?btn=r5.gif&move=0"
    charset="utf-8"></script>
<!-- JiaThis Button END -->
<script type="text/javascript">
    $(function () {
        $(window).scroll(function () {  //只要窗口滚动,就触发下面代码 
            var scrollt = document.documentElement.scrollTop + document.body.scrollTop; //获取滚动后的高度 
            if (scrollt > 200) {
                //判断滚动后高度超过200px,就显示  
                $(".backToTop").fadeIn(400); //淡出     
            } else {
                $(".backToTop").stop().fadeOut(400);
                //如果返回或者没有超过,就淡入.必须加上stop()停止之前动画,否则会出现闪动   
            }
        });
        $(".backToTop").click(function () { //当点击标签的时候,使用animate在200毫秒的时间内,滚到顶部
            $("html,body").animate({ scrollTop: "0px" }, 200);
        });
    });
</script>
<div class="backToTop" title="" style="display: none;">
</div>
