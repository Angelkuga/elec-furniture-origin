function setTab(name, cursel, n) {
    for (i = 1; i <= n; i++) {
        var menu = document.getElementById(name + i);
        var con = document.getElementById("con_" + name + "_" + i);
        menu.className = i == cursel ? "hover" : "";
        con.style.display = i == cursel ? "block" : "none";
    }
}

$(function () {
    SoFolderCondition(); //点击收起
    SoGetMoreBrand(); //点击更多品牌
    SoAlpha();

    SoAjaxThumbViews(); //点击Views Tab
    SoThumbViewsHover('div.dealerLiMc,div.brandsDealer,div.productPic,div.braAbout1,div.brandsgc');
    SoProductNewHover();

    SoAjaxTab('products');

    SoSlider("#infiniteCarousel");
    SoAjaxViewTab(".searchBrand");


    $("#searchTypeList").find("a").click(function () {
        $("#searchTypeList").hide();
    })
    $(".topSearch1").hover(function () {
        $(this).find("ol").show();
    }, function () {
        $(this).find("ol").hide();
    })

    //搜索选择
    $("#searchTypeList > a").click(function () {
        $("#searchTypeDisplay").html($(this).text());
        $("#searchTypeList > a").removeClass("Searcha");
        $(this).addClass("Searcha");
    })

});
 
    function SoFolderCondition() {

        $('div.prlifl1>div.prsq>a').toggle(function () {
            var o = $(this);
            o.parents('div.prlifl1').siblings('div.prlifl2').find('div.prlifl20').slideUp('slow');
            o.addClass('on');
            o.text("展开");
            return false;
        }, function () {
            var o = $(this);
            o.parents('div.prlifl1').siblings('div.prlifl2').find('div.prlifl20').slideDown('slow');
            o.removeClass('on');
            o.text("收起");
            return false;
        });
    }

    function SoGetMoreBrand() {

        $('dt.prWhole>a').toggle(function() {
            var o = $(this);
            o.parent('dt.prWhole').siblings('dt.dt1').find('a.ahide').show();
            o.addClass('on');
            return false;
        }, function() {
            var o = $(this);
            o.parent('dt.prWhole').siblings('dt.dt1').find('a.ahide').hide();
            o.removeClass('on');
            return false;
        });
    }

    function SoAlpha() {
        $('div.prlifl1>div.pren li').hover(function() {
            var o = $(this);
            var oa = o.find('a.a1')
            var oText = oa.text();
            oa.addClass('prena');
            o.find("div.prentc[alphaid='" + oText + "']").show();
        }, function() {
            var o = $(this);
            var oa = o.find('a.a1')
            var oText = oa.text();
            oa.removeClass('prena');
            o.find("div.prentc[alphaid='" + oText + "']").hide();
        });
        $('div.prlifl1>div.pren a').click(function() {
            return false;
        });
    }

    function SoAjaxThumbViews() {
        SoAjaxViewTab('productView');
    }

    function SoAjaxViewTab(obj) {
        $('.' + obj + '>.hd>ul>li').click(function () {
            var o = $(this);

            var objPa = o.parent('ul');
            var objSib = objPa.find('li');
            var index = objSib.index(o);

            objSib.not(o).removeClass('on');

            var objItemList = objPa.parent('.hd').siblings('.bd');

            var itemTarget = objItemList.find('.item').eq(index);

            objItemList.find('.item').not(itemTarget).hide();


            //如果已经ajax 请求过     //暂时注释掉，静态页面无AJAX 方法 否则IE6 测试报错
            //            var ajaxid = o.attr('ajaxid');
            //            if (itemTarget.html().length <= 0) {
            //                $.ajax({
            //                    type: "GET",
            //                    cache: true,
            //                    url: "/xxx/somepage.aspx?ajax=" + ajaxid,
            //                    error: function () {

            //                    },
            //                    beforeSend: function () {

            //                    },
            //                    success: function (d) {

            //                    }
            //                });
            //            }



            //存在on属性
            if (o.attr('class') == 'on') {
                o.removeClass('on');
                itemTarget.slideUp('slow');
                itemTarget.parent('div.bd').css({ "padding-bottom": "0px" });
            }
            else {
                o.addClass('on');
                itemTarget.show();
                itemTarget.parent('div.bd').css({ "padding-bottom": "10px" });
            }

            $(this).find('a').blur();
            return false;
        });
    }

    function SoProductNewHover() {
        $('div.productNew-content li').hover(function () {
            $(this).addClass('on').find('.button').css('visibility', 'visible');
        }, function () {
            $(this).removeClass('on').find('.button').css('visibility', 'hidden');
        });
    }

    function SoThumbViewsHover(obj) {
        if ($('div.productView').get(0) != null) {
            $(obj).hover(makeShow, makeHide).hover(function () {
                $(this).find('div.productPic13').addClass('productPic13-curr');
                if ($(this).hasClass("productPic")) {
                    $(this).addClass("productPic_hover");
                }
            },
            function () {
                $(this).find('div.productPic13').removeClass('productPic13-curr');
                if ($(this).hasClass("productPic")) {
                    $(this).removeClass("productPic_hover");
                    $(this).find('div.productView').hide();
                }
            });
        }
    }

    function makeShow() {
        var o = $(this);
        if (o.find('li.on').size() > 0) {
            o.find('div.bd').css({ "padding-bottom": "10px" }).show();
        }
        else {
            o.find('div.bd').css({ "padding-bottom": "0" }).show();
        }
        o.find('div.productView').show(); //.fadeIn("slow");
    }

    function makeHide() {
        var o = $(this);
        if (o.find('li.on').size() > 0) {
            $('');
            o.find('div.bd').hide();
            o.find('div.productView').hide();
        }
        else {
            o.find('div.bd').hide();
            o.find('div.productView').hide();
        }
    }

    function SoAjaxTab(obj) {
        $('.' + obj + '>.hd>ul>li').click(function () {
            var o = $(this);
            var objPa = o.parent('ul');
            var objSib = objPa.find('li');
            var index = objSib.index(o);
            objSib.removeClass('on');
            o.addClass('on');

            var objItemList = objPa.parent('.hd').siblings('.bd');
            objItemList.find('.item').hide();

            var itemTarget = objItemList.find('.item').eq(index);

            var ajaxid = o.attr('ajaxid');
            var ajaxGetType = o.attr('name');



            //如果已经ajax 请求过     
            //暂时注释掉，静态页面无AJAX 方法 否则IE6 测试报错
            if (itemTarget.html().length <= 0) {
                $.ajax({
                    type: "GET",
                    cache: true,
                    url: "../ashx/ajaxCommon.ashx?type=" + ajaxGetType + "&v=" + ajaxid,
                    error: function () {

                    },
                    beforeSend: function () {
                        itemTarget.html("")
                    },
                    success: function (d) {
                        itemTarget.html(d);
                    }
                });
            }

            itemTarget.show();

            $(this).find('a').blur();
            return false;
        });
    }

    function SoSlider(obj) {
        var autoscrolling = true;

        if ($(obj).get(0) != null) {
            $(obj).infiniteCarousel().mouseover(function () {
                autoscrolling = false;
            }).mouseout(function () {
                autoscrolling = true;
            });

            setInterval(function () {
                if (autoscrolling) {
                    $(obj).trigger('next');
                }
            }, 5000);
        }
    }

    String.prototype.format = function (args) {
        var result = this;
        if (arguments.length > 0) {
            if (arguments.length == 1 && typeof (args) == "object") {
                for (var key in args) {
                    if (args[key] != undefined) {
                        var reg = new RegExp("({" + key + "})", "g");
                        result = result.replace(reg, args[key]);
                    }
                }
            }
            else {
                for (var i = 0; i < arguments.length; i++) {
                    if (arguments[i] != undefined) {
                        var reg = new RegExp("({[" + i + "]})", "g");
                        result = result.replace(reg, arguments[i]);
                    }
                }
            }
        }
        return result;
    }

    

