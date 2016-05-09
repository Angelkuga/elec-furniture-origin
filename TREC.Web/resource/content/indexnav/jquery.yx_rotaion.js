/*设置首页上面图片*/


(function ($) {
    $.fn.extend({
        yx_rotaion: function (options) {
            //默认参数
            var defaults = {
                /**轮换间隔时间，单位毫秒*/
                during: 10000,
                /**是否显示左右按钮*/
                btn: false,
                /**是否显示焦点按钮*/
                focus: true,
                /**是否显示标题*/
                title: true,
                /**是否自动播放*/
                auto: true,
                /**点点右边距*/
                position: 50,
                id: ""
            }
            var options = $.extend(defaults, options);

            var i = 0;

            return this.each(function () {
                i++;
                var o = options;
                var curr_index = 0;
                var $this = $(this);
                var nid = $(this).attr('id');
                var $li = $this.find("li");
                var li_count = $li.length;
                $this.css({ position: 'relative', overflow: 'hidden', width: $li.find("img").width(), height: $li.find("img").height() });
                $this.find("li").css({ position: 'absolute', left: 0, top: 0 }).hide();
                $li.first().show();
                $this.append('<div class="yx-rotaion-btn" id="btnspan' + o.id + i + '" ><span class="left_btn"><\/span><span class="right_btn"></span><\/div>');
                if (!o.btn) $(".yx-rotaion-btn").css({ visibility: 'hidden' });
                if (o.title) $this.append(' <div class="yx-rotation-title" id="title_bg' + o.id + i + '" ><\/div><a href="" id="title' + o.id + i + '" class="yx-rotation-t"><\/a>');



                if (o.focus) $this.append('<div class="yx-rotation-focus" id="divnav' + o.id + i + '"><\/div>');

                var $btn = $('#btnspan' + o.id + i + ' span'), //$(".yx-rotaion-btn span"),
                $title = $('#title' + o.id + i + ''), //$(".yx-rotation-t"),
                $title_bg = $('#title_bg' + o.id + i + ''), //$(".yx-rotation-title"),
                $focus = $('#divnav' + o.id + i + ''); // $(".yx-rotation-focus");


                //如果自动播放，设置定时器
                if (o.auto) var t = setInterval(function () { $btn.last().click() }, o.during);
                $title.text($li.first().find("img").attr("alt"));
                $title.attr("href", $li.first().find("a").attr("href"));


                //                var img = new Image();
                //                img.src = $('#img_nav0').attr("src");
                //                var w = img.width;

                $("#divnav" + o.id + i).css("right", o.position);


                // 输出焦点按钮
                for (i = 1; i <= li_count && li_count != 1; i++) {
                    $focus.append('<span id="span' + o.id + i + '" >' + i + '</span>');
                }
                // 兼容IE6透明图片   
                //                if ($.browser.msie && $.browser.version == "6.0") {
                //                    $btn.add($focus.children("span")).css({ backgroundImage: 'url(images/ico.gif)' });
                //                }
                var $f = $focus.children("span");
                $f.first().addClass("hover");
                // 鼠标覆盖左右按钮设置透明度
                $btn.hover(function () {
                    $(this).addClass("hover");
                }, function () {
                    $(this).removeClass("hover");
                });
                //鼠标覆盖元素，清除计时器
                $btn.add($li).add($f).hover(function () {
                    if (t) clearInterval(t);
                }, function () {
                    if (o.auto) t = setInterval(function () { $btn.last().click() }, o.during);
                });
                //鼠标覆盖焦点按钮效果
                $f.bind("mouseover", function () {
                    var i = $(this).index();

                    //$focus.children("span").not($(this)).removeClass("hover");

                    //获取此span父节点
                    var $focuscurr = $(this).closest('.yx-rotation-focus');
                    $focuscurr.children("span").not($(this)).removeClass("hover");

                    $(this).addClass("hover");
                    $li.eq(i).fadeIn(300);
                    $li.not($li.eq(i)).fadeOut(300);
                    $title.text($li.eq(i).find("img").attr("alt"));
                    curr_index = i;
                });
                //鼠标点击左右按钮效果
                $btn.bind("click", function () {
                    $(this).index() == 1 ? curr_index++ : curr_index--;
                    if (curr_index >= li_count) curr_index = 0;
                    if (curr_index < 0) curr_index = li_count - 1;
                    $li.eq(curr_index).fadeIn(300);
                    $li.not($li.eq(curr_index)).fadeOut(300);
                    $f.eq(curr_index).addClass("hover");
                    $f.not($f.eq(curr_index)).removeClass("hover");
                    $title.text($li.eq(curr_index).find("img").attr("alt"));
                    $title.attr("href", $li.eq(curr_index).find("a").attr("href"));
                });

            });
        }
    });

})(jQuery);


function sydt(Navs) 
{ 
    /*首页大图*/

    Navs = [
        { Title: '', Href: '/51/default.aspx', Target: '_blank', Img: '/resource/content/images/img1index.jpg' }
        ];

    var width = screen.width;
    var height = 378;
    var ss = " <div class='yx-rotaion'><ul class='rotaion_list'>";

    for (var i = 0; i < Navs.length; i++) {
        ss += "<li><a href='" + Navs[i].Href + "' target='" + Navs[i].Target + "' ><img style='width:" + $(document.body).width() + "px;height:" + height + "px;' border='0'  src='" + Navs[i].Img + "'  alt='" + Navs[i].Title + "' /></a></li>";
    }    
    ss += "</ul></div>";

    if ($("#navindex").length > 0) {
        $("#navindex").html(ss); 
        $("#navindex").yx_rotaion({during:3000, auto: true, position: (screen.width - 100) / 2, title: false, id: "navindex" });
    }
}

function gmc(Navs) {
    /*逛卖场图片*/
    Navs = [
	{ Title: '', Href: '##', Target: '_blank', Img: '../../../resource/content/img/index/h4.jpg' },
	{ Title: '', Href: '##', Target: '_blank', Img: '../../../resource/content/img/index/h4.jpg' },
	{ Title: '', Href: '##', Target: '_blank', Img: '../../../resource/content/img/index/h4.jpg'}];

    ss = " <div class='yx-rotaion'><ul class='rotaion_list'>";

    for (var i = 0; i < Navs.length; i++) {
        ss += "<li><a href='" + Navs[i].Href + "' target='" + Navs[i].Target + "' ><img  border='0'  src='" + Navs[i].Img + "' style='width:760px;height:325px;' alt='" + Navs[i].Title + "' /></a></li>";
    }
    ss += "</ul></div>";

    if ($("#navindex3").length > 0) {
        $("#navindex3").html(ss);
       
        try {
            $("#navindex3").yx_rotaion({ during: 3000, auto: true, position: 50, title: true, id: "navindex3" });
        } catch (e) { alert(e); }
    }
    if ($("#navindex2").length > 0) {
        $("#navindex2").html(ss);

        try {
            $("#navindex2").yx_rotaion({ during: 3000, auto: true, position: 50, title: true, id: "navindex2" });
        } catch (e) {alert(e);}
    }

    
}

function hddg(Navs) { 

/*活动导购*/
    Navs = [
	    { Title: '', Href: '##', Target: '_blank', Img: '../../../resource/content/img/index/h5.jpg' },
	    { Title: '', Href: '##', Target: '_blank', Img: '../../../resource/content/img/index/h5.jpg'}];

    ss = " <div class='yx-rotaion'><ul class='rotaion_list'>";

    for (var i = 0; i < Navs.length; i++) {
        ss += "<li><a href='" + Navs[i].Href + "' target='" + Navs[i].Target + "' ><img  border='0'  src='" + Navs[i].Img + "'  style='width:795px;height:298px;' alt='" + Navs[i].Title + "' /></a></li>";
    }
    ss += "</ul></div>"; 
    if ($("#navindex3").length > 0)
    {
        $("#navindex3").html(ss);
        $("#navindex3").yx_rotaion({ during: 3000, auto: true, position: 50, title: false, id: "navindex3" });
    }


}