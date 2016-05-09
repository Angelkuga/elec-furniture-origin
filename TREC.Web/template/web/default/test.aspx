
<!doctype html>
<html>
<head>
    <title></title>
<script language="javascript" type="text/javascript" src="http://www.mm123m.com/JS/jquery-1.4.1.min.js"></script>
<script language="javascript" type="text/javascript">
    var browserType = (function () {
        var a = navigator.userAgent.toLowerCase();
        return {
            webkit: /webkit/.test(a) ? (a.match(/webkit\/(\d+)/) || [])[1] : 0,
            ie: ! +"\v1",
            iOS: (a.match(/(ipad|iphone|ipod)/) || [])[0],
            iOSVersion: (a.match(/os\s+([\d_]+)\s+like\s+mac\s+os/) || [0, "0_0_0"])[1].split("_"),
            wphone: parseFloat((a.match(/windows\sphone\sos\s([\d.]+)/) || ["", "0"])[1]),
            android: parseFloat((a.match(/android\s([\d.]+)/) || ["", "0"])[1]) || (a.indexOf("android") > -1 && 4)
        }
    })();

    function loaddata()
    {
     $("#aaa1").hide();
             $("#bbb1").hide();
            if(browserType.iOS||browserType.wphone||browserType.android)
            {
            $(".bbb1").show();
            }
            else
            {
            $(".aaa1").show();
            }
    }

    $(document).ready(function () {
        loaddata();
    });
</script>
</head>
<body >
    <div class="aaa1" style="display:none;">电脑打开</div>
    <div class="aaa1" style="display:none;">电脑打开</div>
    <div class="aaa1" style="display:none;">电脑打开</div>
    <div class="aaa1" style="display:none;">电脑打开</div>
    <div class="bbb1" style="display:none;">手机打开</div>
    <div class="bbb1" style="display:none;">手机打开</div>
    <div class="bbb1" style="display:none;">手机打开</div>
    <div class="bbb1" style="display:none;">手机打开</div>
    <div class="bbb1" style="display:none;">手机打开</div>


    <div  style="width: 100%; height:108px; overflow: hidden; position: relative;  background-color: red; background: url(http://www.jiajuks.com/resource/content/images/sxx.jpg) center no-repeat;cursor:pointer;">  
<a style="height:108px; z-index: 31px;width:100%;position:absolute;top:0px;left:0px;" href="http://www.jiajuks.com/51/default.aspx" target="_blank"></a>
 </div>

</body>
</html>
