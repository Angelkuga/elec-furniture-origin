$(function () {
    skipLetter();
    brandTab();
    brandBar();
});

function skipLetter() {
    var jlt = $('#j_letterTree');
    $('#j_letterAlpha').find('a[href]').click(function (e) {
        var aname = $(this).attr('href').replace(/\#/, '');
        var liTop = jlt.find("a[name='" + aname + "']").parents('li').offset().top;
        var ulTop = jlt.offset().top;
        var ulscroTop = jlt.scrollTop();
        jlt.scrollTop(liTop - ulTop + ulscroTop);
        return false;
    });
}

function brandTab() {
    $('#j_brandTab').find('.arrow').on('click', function () {
        var o = $(this);
        var oft = o.parent('.hd').next('.filter');
        if (o.hasClass('arrow-on')) {
            o.removeClass('arrow-on');
            oft.slideDown('slow');
        } else {
            o.addClass('arrow-on');
            oft.slideUp('slow');
        }
    });
}

function brandBar() {
    var h = screen.height;
    //$('#j_letterTree').css({ 'height': h });
    //$('#j_letterTree').css({ 'height': 300 });
}