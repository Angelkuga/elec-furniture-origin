//for node compress

$(function () {
    indexSlide();
    indexTab();
    indexRushTime();
});

function indexSlide() {

    var sw = $('body').width();

    //step view
    var slds = $('#j_stepView').find('.slides');
    slds.slides({
        generateNextPrev: false,
        generatePagination: true
    });

    var indexSlds = $('#j_advert').find('.slides');
    indexSlds.find('.box').width(sw);

    indexSlds.slides({
        generateNextPrev: false,
        generatePagination: true,
        effect:'fade'
    });

}

function indexTab() {
    var tab = $('.tab');
    tab.find('.hd').find('li').on('click', function () {
        var o = $(this);
        var os = o.siblings('li');
        var index = o.index();
        var items = o.parents('.hd').siblings('.bd').children('.item');

        os.removeClass('on');
        o.addClass('on');

        items.hide();
        items.eq(index).show();
    });
}

function indexRushTime() {
    
    function lxfEndtime() {
        $("#j_timeRush").find('.txt').each(function () {

            var nowtime = new Date().getTime();
            var o = $(this);
            var op = o.parents('li');
            nowtime = nowtime + 1000;
            var endtime = new Date(op.attr("data-endtime")).getTime();
            var youtime = endtime - nowtime;
            var seconds = youtime / 1000;
            var minutes = Math.floor(seconds / 60);
            var hours = Math.floor(minutes / 60);
            var days = Math.floor(hours / 24);
            var CDay = days;
            if (CDay.toString().length == 1) {
                CDay = "0" + CDay;
            }
            var CHour = hours % 24;
            if (CHour.toString().length == 1) {
                CHour = "0" + CHour;
            }
            var CMinute = minutes % 60;
            if (CMinute.toString().length == 1) {
                CMinute = "0" + CMinute;
            }
            var CSecond = Math.floor(seconds % 60);
            if (CSecond.toString().length == 1) {
                CSecond = "0" + CSecond;
            }

            if (endtime <= nowtime) {
                //endline
            }
            else {
                o.find(".day").text(CDay);
                o.find(".shi").text(CHour);
                o.find(".fen").text(CMinute);
                o.find(".miao").text(CSecond);
            }


        });
        setTimeout(function () {
            lxfEndtime()
        }, 1000);
    }
    lxfEndtime();
}

function BingYingAdd(Description, phone, Msg, ImgPath, code) {

    if ($.trim(phone) != '') {
        var reg = new RegExp(/((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/);
        var input = $.trim(phone);
        if (!reg.test(input) & input != '') {
            alert('电话号码有误');
            window.event.returnValue = false;
        }
    }

    if ($.trim(Description) == '') {
        alert('提交内容不能为空');
    }
    $.post("/ajax/AddressSubmit.aspx", { "Description": Description, "phone": phone, "Msg": Msg, "ImgPath": ImgPath, "code": code }, function (data, textStatus) {
        if (data == 'true') {
            alert('提交成功');
        }
    }, null);
}

$(document).ready(function () {
    jQuery.jqtab = function (tabtit, tab_conbox, shijian) {
        $(tab_conbox).find("li").hide();
        $(tabtit).find("li:first").addClass("thistab").show();
        $(tab_conbox).find("li:first").show();

        $(tabtit).find("li").bind(shijian, function () {
            $(this).addClass("thistab").siblings("li").removeClass("thistab");
            var activeindex = $(tabtit).find("li").index(this);
            $(tab_conbox).children().eq(activeindex).show().siblings().hide();
            return false;
        });

    };
    $.jqtab("#tabs51", "#tab_conbox", "mouseenter");

});

(function (a) { a.flexslider = function (c, b) { var d = c; d.init = function () { d.vars = a.extend({}, a.flexslider.defaults, b); d.data("flexslider", true); d.container = a(".slides", d); d.slides = a(".slides > li", d); d.count = d.slides.length; d.animating = false; d.currentSlide = d.vars.slideToStart; d.atEnd = (d.currentSlide == 0) ? true : false; d.eventType = ("ontouchstart" in document.documentElement) ? "touchstart" : "click"; d.cloneCount = 0; d.cloneOffset = 0; if (d.vars.controlsContainer != "") { d.controlsContainer = a(d.vars.controlsContainer).eq(a(".slides").index(d.container)); d.containerExists = d.controlsContainer.length > 0 } if (d.vars.manualControls != "") { d.manualControls = a(d.vars.manualControls, ((d.containerExists) ? d.controlsContainer : d)); d.manualExists = d.manualControls.length > 0 } if (d.vars.randomize) { d.slides.sort(function () { return (Math.round(Math.random()) - 0.5) }); d.container.empty().append(d.slides) } if (d.vars.animation.toLowerCase() == "slide") { d.css({ overflow: "hidden" }); if (d.vars.animationLoop) { d.cloneCount = 2; d.cloneOffset = 1; d.container.append(d.slides.filter(":first").clone().addClass("clone")).prepend(d.slides.filter(":last").clone().addClass("clone")) } d.container.width(((d.count + d.cloneCount) * d.width()) + 2000); d.newSlides = a(".slides > li", d); setTimeout(function () { d.newSlides.width(d.width()).css({ "float": "left" }).show() }, 100); d.container.css({ marginLeft: (-1 * (d.currentSlide + d.cloneOffset)) * d.width() + "px" }) } else { d.slides.css({ width: "100%", "float": "left", marginRight: "-100%" }).filter(":first").fadeIn(400, function () { }) } if (d.vars.controlNav) { if (d.manualExists) { d.controlNav = d.manualControls } else { var g = a('<ol class="flex-control-nav"></ol>'); var k = 1; for (var l = 0; l < d.count; l++) { g.append("<li><a>" + k + "</a></li>"); k++ } if (d.containerExists) { a(d.controlsContainer).append(g); d.controlNav = a(".flex-control-nav li a", d.controlsContainer) } else { d.append(g); d.controlNav = a(".flex-control-nav li a", d) } } d.controlNav.eq(d.currentSlide).addClass("active"); d.controlNav.bind(d.eventType, function (i) { i.preventDefault(); if (!a(this).hasClass("active")) { d.flexAnimate(d.controlNav.index(a(this)), d.vars.pauseOnAction) } }) } if (d.vars.directionNav) { var f = a('<ul class="flex-direction-nav"><li><a class="prev" href="#">' + d.vars.prevText + '</a></li><li><a class="next" href="#">' + d.vars.nextText + "</a></li></ul>"); if (d.containerExists) { a(d.controlsContainer).append(f); d.directionNav = a(".flex-direction-nav li a", d.controlsContainer) } else { d.append(f); d.directionNav = a(".flex-direction-nav li a", d) } if (!d.vars.animationLoop) { if (d.currentSlide == 0) { d.directionNav.filter(".prev").addClass("disabled") } else { if (d.currentSlide == d.count - 1) { d.directionNav.filter(".next").addClass("disabled") } } } d.directionNav.bind(d.eventType, function (i) { i.preventDefault(); var j = (a(this).hasClass("next")) ? d.getTarget("next") : d.getTarget("prev"); if (d.canAdvance(j)) { d.flexAnimate(j, d.vars.pauseOnAction) } }) } if (d.vars.keyboardNav && a("ul.slides").length == 1) { a(document).keyup(function (i) { if (d.animating) { return } else { if (i.keyCode != 39 && i.keyCode != 37) { return } else { if (i.keyCode == 39) { var j = d.getTarget("next") } else { if (i.keyCode == 37) { var j = d.getTarget("prev") } } if (d.canAdvance(j)) { d.flexAnimate(j, d.vars.pauseOnAction) } } } }) } if (d.vars.slideshow) { if (d.vars.pauseOnHover && d.vars.slideshow) { d.hover(function () { d.pause() }, function () { d.resume() }) } d.animatedSlides = setInterval(d.animateSlides, d.vars.slideshowSpeed) } if (d.vars.pausePlay) { var e = a('<div class="flex-pauseplay"><span></span></div>'); if (d.containerExists) { d.controlsContainer.append(e); d.pausePlay = a(".flex-pauseplay span", d.controlsContainer) } else { d.append(e); d.pausePlay = a(".flex-pauseplay li a", d) } var h = (d.vars.slideshow) ? "pause" : "play"; d.pausePlay.addClass(h).text(h); d.pausePlay.click(function (i) { i.preventDefault(); (a(this).hasClass("pause")) ? d.pause() : d.resume() }) } if (d.vars.touchSwipe && "ontouchstart" in document.documentElement) { d.each(function () { var i, j = 20; isMoving = false; function o() { this.removeEventListener("touchmove", m); i = null; isMoving = false } function m(s) { if (isMoving) { var p = s.touches[0].pageX, q = i - p; if (Math.abs(q) >= j) { o(); var r = (q > 0) ? d.getTarget("next") : d.getTarget("prev"); if (d.canAdvance(r)) { d.flexAnimate(r, d.vars.pauseOnAction) } } } } function n(p) { if (p.touches.length == 1) { i = p.touches[0].pageX; isMoving = true; this.addEventListener("touchmove", m, false) } } if ("ontouchstart" in document.documentElement) { this.addEventListener("touchstart", n, false) } }) } if (d.vars.animation.toLowerCase() == "slide") { d.sliderTimer; a(window).resize(function () { d.newSlides.width(d.width()); d.container.width(((d.count + d.cloneCount) * d.width()) + 2000); clearTimeout(d.sliderTimer); d.sliderTimer = setTimeout(function () { d.flexAnimate(d.currentSlide) }, 300) }) } d.vars.start(d) }; d.flexAnimate = function (f, e) { if (!d.animating) { d.animating = true; if (e) { d.pause() } if (d.vars.controlNav) { d.controlNav.removeClass("active").eq(f).addClass("active") } d.atEnd = (f == 0 || f == d.count - 1) ? true : false; if (!d.vars.animationLoop) { if (f == 0) { d.directionNav.removeClass("disabled").filter(".prev").addClass("disabled") } else { if (f == d.count - 1) { d.directionNav.removeClass("disabled").filter(".next").addClass("disabled"); d.pause(); d.vars.end(d) } else { d.directionNav.removeClass("disabled") } } } d.vars.before(d); if (d.vars.animation.toLowerCase() == "slide") { if (d.currentSlide == 0 && f == d.count - 1 && d.vars.animationLoop) { d.slideString = "0px" } else { if (d.currentSlide == d.count - 1 && f == 0 && d.vars.animationLoop) { d.slideString = (-1 * (d.count + 1)) * d.slides.filter(":first").width() + "px" } else { d.slideString = (-1 * (f + d.cloneOffset)) * d.slides.filter(":first").width() + "px" } } d.container.animate({ marginLeft: d.slideString }, d.vars.animationDuration, function () { if (d.currentSlide == 0 && f == d.count - 1 && d.vars.animationLoop) { d.container.css({ marginLeft: (-1 * d.count) * d.slides.filter(":first").width() + "px" }) } else { if (d.currentSlide == d.count - 1 && f == 0 && d.vars.animationLoop) { d.container.css({ marginLeft: -1 * d.slides.filter(":first").width() + "px" }) } } d.animating = false; d.currentSlide = f; d.vars.after(d) }) } else { d.slides.eq(d.currentSlide).fadeOut(d.vars.animationDuration); d.slides.eq(f).fadeIn(d.vars.animationDuration, function () { d.animating = false; d.currentSlide = f; d.vars.after(d) }) } } }; d.animateSlides = function () { if (!d.animating) { var e = (d.currentSlide == d.count - 1) ? 0 : d.currentSlide + 1; d.flexAnimate(e) } }; d.pause = function () { clearInterval(d.animatedSlides); if (d.vars.pausePlay) { d.pausePlay.removeClass("pause").addClass("play").text("play") } }; d.resume = function () { d.animatedSlides = setInterval(d.animateSlides, d.vars.slideshowSpeed); if (d.vars.pausePlay) { d.pausePlay.removeClass("play").addClass("pause").text("pause") } }; d.canAdvance = function (e) { if (!d.vars.animationLoop && d.atEnd) { if (d.currentSlide == 0 && e == d.count - 1 && d.direction != "next") { return false } else { if (d.currentSlide == d.count - 1 && e == 0 && d.direction == "next") { return false } else { return true } } } else { return true } }; d.getTarget = function (e) { d.direction = e; if (e == "next") { return (d.currentSlide == d.count - 1) ? 0 : d.currentSlide + 1 } else { return (d.currentSlide == 0) ? d.count - 1 : d.currentSlide - 1 } }; d.init() }; a.flexslider.defaults = { animation: "fade", slideshow: true, slideshowSpeed: 7000, animationDuration: 600, directionNav: true, controlNav: true, keyboardNav: true, touchSwipe: true, prevText: "Previous", nextText: "Next", pausePlay: false, randomize: false, slideToStart: 0, animationLoop: true, pauseOnAction: true, pauseOnHover: false, controlsContainer: "", manualControls: "", start: function () { }, before: function () { }, after: function () { }, end: function () { } }; a.fn.flexslider = function (b) { return this.each(function () { if (a(this).find(".slides li").length == 1) { a(this).find(".slides li").fadeIn(400) } else { if (a(this).data("flexslider") != true) { new a.flexslider(a(this), b) } } }) } })(jQuery);
