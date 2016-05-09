$(function() {
    $('<div id="ad_box_2009_04" style="text-align:center;"><a href="http://www.fujiawang.com/active/quanyou/" target="_blank"><img src="http://www.fujiawang.com/images/fz990X500.jpg" id="adImg" border="0" /></a></div>').insertBefore('.jiathis_style:eq(0)');    
});

var showAD = {
    curve: function(t, b, c, d, s) {
        if ((t /= d / 2) < 1) return c / 2 * t * t * t + b;
        return c / 2 * ((t -= 2) * t * t + 2) + b
    },
    fx: function(from, to, playTime, onEnd) {
        var Me = this,
who = document.getElementById('ad_box_2009_04'),
position = 0,
changeVal = to - from,
curve = this.curve;
        playTime = playTime / 10;
        who.style.overflow = 'hidden';
        function _run() {
            if (position++ < playTime) {
                $('#ad_box_2009_04').css('height', Math.max(1, Math.abs(Math.ceil(curve(position, from, changeVal, playTime)))) + 'px');
                setTimeout(_run, 10)
            } else {
                onEnd && onEnd.call(Me, to)
            }
        };
        _run()
    },
    init: function(info) {
        var Me = this,
loadImg = new Image;
        loadImg.src = info.endImgURL;
        window.onload = function() {
            Me.endImgURL = info.endImgURL;
            Me.img = document.getElementById(info.imgID);
            Me.adWrap = document.getElementById(info.adWrapID);
            var max = Me.img.height;
            setTimeout(function() {
                Me.fx(max, 0, 500,
function(x) {
    this.img.src = this.endImgURL;
    this.curve = function(t, b, c, d) {
        if ((t /= d) < (1 / 2.75)) {
            return c * (7.5625 * t * t) + b
        } else if (t < (2 / 2.75)) {
            return c * (7.5625 * (t -= (1.5 / 2.75)) * t + .75) + b
        } else if (t < (2.5 / 2.75)) {
            return c * (7.5625 * (t -= (2.25 / 2.75)) * t + .9375) + b
        } else {
            return c * (7.5625 * (t -= (2.625 / 2.75)) * t + .984375) + b
        }
    };
    this.fx(0, this.img.height, 600)
})
            },
info.timeout || 5000)
        };
    }
};
showAD.init({
    adWrapID: 'ad_box_2009_04',
    imgID: 'adImg',
    endImgURL: 'http://www.fujiawang.com/images/fz990X80.jpg'
});