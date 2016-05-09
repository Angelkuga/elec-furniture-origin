/*! jiajuks - v0.1.11 - 2015-02 */

function actTab() {
    var a = $("#j_activity");

    a.find(".hd").find("li").on("click", function () {
            var a = $(this),
            b = a.siblings("li"),
            c = a.index(),
            d = a.parents(".hd").siblings(".bd").children(".item");

            b.removeClass("on"),
            a.addClass("on")
            //, d.hide(),
            //d.eq(c).show()
    })
} $(function () { actTab() });