$(function () {
    ksTab('j_salesBrandIntro');
    ksTab('j_floorTab');
    ksSlides('j_keynote');
    skipLetter();
    brandBar();
    floorFix();
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

function brandBar() {
    var h = screen.height;
   // $('#j_letterTree').css({ 'height': h });
}


function floorFix() {
    $('#j_floorTab').find('.bd').find('li').on('mouseenter', function () {
        var o = $(this);
        var odrop = o.find('.drop');
        var ot = o.offset().top-10;
        var ol = o.offset().left+140;

        odrop.css({ 'display': 'block', 'top': ot, 'left': ol });


    }).on('mouseleave', function () {
        var o = $(this);
        var odrop = o.find('.drop');
        odrop.css({ 'display': 'none' });
    })
}