; (function ($) {
    $.fn.extend({
        hasScrollBarX: function () {
            return this[0].scrollWidth > this[0].clientWidth;
        },
        hasScrollBarY: function () {
            return this[0].scrollHeight > this[0].clientHeight;
        },
        hasScrollBar: function () {
            return this.hasScrollBarX() || this.hasScrollBarY();
        }
    });
    $.params = function (a, b) {
        var t = '';
        if (typeof a == 'string' && a != '') {
            t = a;
        }
        if (typeof b == 'string' && b != '') {
            if (t != '') {
                t += '&' + b;
            } else {
                t = b;
            }
        }
        return t;
    };
})(jQuery)
;(function ($) {
    $.fn.oms_autocomplate = function (options) {
        var timer;
        var childindex = -1;
        var _seft = this;
        $(_seft).attr("autocomplete", "off");
        var defaults = { url: null, maxHeight: 412, paramTypeSelector: "", select: function (event, ui) {
            this.value = ui.item.value;
            if (ui.item.redirecturl != undefined && $.trim(ui.item.redirecturl) != '') {
                window.top.location = $.trim(ui.item.redirecturl);
            }
        }
        };
        var opt = $.extend({}, defaults, options);
        function search_keyup(e) {
            var the = this;
            if ((e.keyCode == 38 || e.keyCode == 40) && this.value != "") {
                window.clearInterval(timer);
            } 
            if (e.keyCode == 13) {
                if (childindex > -1) {
                    getElem().css("display", "none");
                    $(the).trigger('selected', [{ item: getElem().find('li:eq(' + childindex + ')').data('data')}]);
                    childindex = -1;
                }
            } else {
                if (the.value != "") {
                    if(!getElem().filter(":hidden")[0] && (e.keyCode == 38 || e.keyCode == 40))
                    {
                        return;
                    } 
                    $.get(opt.url, { key: the.value, type: (opt.paramTypeSelector != '' ? $(opt.paramTypeSelector).attr('title') : "") ,time:new Date().toString()}, function (serverdata) {
                        getElem().children("ul").empty();
                        var data = eval(serverdata);
                        $.each(data, function (i) {
                        alert(i);
                            var li = $('<li style="padding:2px 0px 2px 5px; height:16px; line-height:16px; cursor:pointer;overflow:hidden;position:relative;">' + this.label + '</li>');
                            li.data('value', this.value);
                            li.data('label', this.label);
                            li.data('data', this);
                            li.bind('click', function () {
                            alert(item: data[i]);
                                $(the).trigger('selected', [{ item: data[i]}]);
                            });
                            getElem().children("ul").append(li).css("overflow", "auto");
                        });
                        if (getElem().find("li").length == 0) {
                            getElem().css("display", "none");
                            return false;
                        } else {
                            childindex = -1;
                            getElem().find("li").each(function (i) {
                                $(this).hover(function () {
                                    childindex = i;
                                    getElem().find("li").css({ backgroundColor: "", color: "#666666" });
                                    this.style.backgroundColor = "#FA8F5C";
                                    this.style.color = "#FFF";
                                }, function () { });
                            });
                        }
                        if (getElem().filter(":hidden")[0]) {
                            getElem().css({ height: "0px", display: "block" });
                        }
                        var tw = opt.inputWidth != null && opt.inputWidth > 0 ? opt.inputWidth : $(the).outerWidth() + parseInt($(the).css("marginLeft")) - 2;
                        var th = opt.inputHeight != null && opt.inputHeight > 0 ? opt.inputHeight : $(the).outerHeight();
                        var h = Math.min(opt.maxHeight, getElem().find("li").outerHeight() * getElem().find("li").length + 10);
                        var l = parseInt($(the).offset().left) - parseInt($(the).css("marginLeft"));
                        var tt = parseInt($(the).offset().top) - parseInt($(the).css("marginTop"));
                        var t = tt + parseInt(th);
                        var clientH = $(document).height();
                        getElem().css({ width: tw, left: l + 1 }).children("ul").height(h - 10);
                        if (clientH - t >= h) {
                            getElem().stop().css({ top: t }).animate({ height: h }, 0);
                        } else {
                            if (getElem().height() == 0) {
                                getElem().stop().css({ top: tt, height: "0px" }).animate({ top: tt - h - 2, height: h }, 0);
                            } else {
                                getElem().stop().animate({ top: tt - h - 2, height: h }, 0);
                            }
                        }
                    });
                } else {
                    getElem().css("display", "none");
                }
            }
        }
        function search_keydown(e) {
            var len = getElem().find("li").length;
            if (e.keyCode == 38) {
                window.clearInterval(timer);
                if (len > 0) {
                    if (childindex <= 0) {
                        childindex = len - 1;
                    } else {
                        childindex--;
                    }
                    getElem().find("li").css({ backgroundColor: "", color: "#666666" }).eq(childindex).css({ backgroundColor: "#FA8F5C", color: "#FFF" });
                    scrollUL(getElem().children("ul")[0], childindex, e.keyCode);
                    timer = window.setInterval(function () {
                        if (childindex <= 0) {
                            childindex = len - 1;
                        } else {
                            childindex--;
                        }
                        getElem().find("li").css({ backgroundColor: "", color: "#666666" }).eq(childindex).css({ backgroundColor: "#FA8F5C", color: "#FFF" });
                        scrollUL(getElem().children("ul")[0], childindex, e.keyCode);
                    }, 850);
                }
            } else if (e.keyCode == 40) {
                window.clearInterval(timer);
                if (len > 0) {
                    if (childindex >= len - 1) {
                        childindex = 0;
                    } else {
                        childindex++;
                    }
                    getElem().find("li").css({ backgroundColor: "", color: "#666666" }).eq(childindex).css({ backgroundColor: "#FA8F5C", color: "#FFF" });
                    scrollUL(getElem().children("ul")[0], childindex, e.keyCode);
                    timer = window.setInterval(function () {
                        if (childindex >= len - 1) {
                            childindex = 0;
                        } else {
                            childindex++;
                        }
                        getElem().find("li").css({ backgroundColor: "", color: "#666666" }).eq(childindex).css({ backgroundColor: "#FA8F5C", color: "#FFF" });
                        scrollUL(getElem().children("ul")[0], childindex, e.keyCode);
                    }, 850);
                }
            } else if (e.keyCode == 13) {
                if (childindex > -1) {
                    return false;
                }
            }
        }
        function scrollUL(ul, index, keyCode) {
            var liTop = $(ul).find('li').eq(index).offset().top;
            var liHeight = $(ul).find('li').eq(index).outerHeight();
            var ulTop = $(ul).offset().top;
            var ulscroTop = $(ul).scrollTop();
            var ulborderTop = $(ul).css("border-top-width").replace('px', '');
            var ulheight = $(ul).height();
            var lioffsetulTop = liTop - ulTop - ulborderTop + ulscroTop;
            if ($(ul).hasScrollBarY()) {
                if (!(lioffsetulTop > ulscroTop && ulscroTop + ulheight > lioffsetulTop + liHeight)) {
                    switch (keyCode) {
                        case 38:
                            $(ul).scrollTop(lioffsetulTop);
                            break;
                        case 40:
                            $(ul).scrollTop(lioffsetulTop - ulheight + liHeight);
                            break;
                    }
                }
            }
        }

        function getElem() {
            var el = $("#oms_autocomplate");
            if (el.length == 0) {
                el = $('<ul id="oms_autocomplate" style="display:none;position:absolute;list-style-type:none;margin:0;padding:0;border:1px solid #e12b29;overflow:hidden; background-color:#FFFFFF;z-index:10010;max-height:' + opt.maxHeight + 'px;"><ul style="border:5px solid #f8f1cf;margin:0;padding:0;overflow:auto;position:relative;"></ul></ul>').appendTo(document.body);
            }
            return el;
        }

        $('html,body').click(function () {
            getElem().css("display", "none");
            childindex = -1;
        });

        return this.each(function () {
            $(this).keyup(search_keyup).keydown(search_keydown).bind('selected', opt.select);
        });
    };
})(jQuery);
;(function ($) {
    $.fn.oms_autocomplateV2 = function (options) {
        var timer;
        var childindex = -1;
        var _seft = this;
        $(_seft).attr("autocomplete", "off");
        var defaults = { url: null, maxHeight: 412, paramTypeSelector: "", clickDown: false, select: function (event, ui) {
            this.value = ui.item.value;
            if (ui.item.redirecturl != undefined && $.trim(ui.item.redirecturl) != '') {
                window.top.location = $.trim(ui.item.redirecturl);
            }
        }, beforeajaxfunc: function (event, box) {}
        };
        var opt = $.extend({}, defaults, options);
        function search_keyup(e) {
            var the = this;
            var $the = $(the);
            if (e.keyCode == 38 || e.keyCode == 40) {
                window.clearInterval(timer);
            } 
            if (e.keyCode == 13) {
                if (childindex > -1) {
                    getElem().css("display", "none");
                    $(the).trigger('selected', [{ item: getElem().find('li:eq(' + childindex + ')').data('data')}]);
                    childindex = -1;
                }
            } else {
                if (the.value != "" || opt.clickDown) {
                    if(!getElem().filter(":hidden")[0] && (e.keyCode == 38 || e.keyCode == 40))
                    {
                        return;
                    } 
                    $the.trigger('beforeajaxfunc', [getElem()]);
                    var param = $.param({ key: opt.clickDown && (e.keyCode == undefined || e.keyCode == 0) ? "" : the.value , type: (opt.paramTypeSelector != '' ? $(opt.paramTypeSelector).attr('title') : "") ,time:new Date().toString()});
                    if($the.data('param') != '') {
                        param = $.params(param, $the.data('param'));
                    }
                    $.get(opt.url, param, function (serverdata) {
                        getElem().find("ul").empty();
                        var data = eval(serverdata);
                        $.each(data, function (i) {
                            var li = $('<li style="padding:2px 0px 2px 5px; height:16px; line-height:16px; cursor:pointer;overflow:hidden;position:relative;">' + this.label + '</li>');
                            li.data('value', this.value);
                            li.data('label', this.label);
                            li.data('data', this);
                            li.bind('click', function () {
                                $(the).trigger('selected', [{ item: data[i]}]);
                            });
                            getElem().find("ul").append(li).css("overflow", "auto");
                        });
                        if (getElem().find("li").length == 0) {
                            //getElem().css("display", "none");
                            getElem().find("h4").html("找不到相关的选择。");
                            return false;
                        } else {
                            childindex = -1;
                            getElem().find("li").each(function (i) {
                                $(this).hover(function () {
                                    childindex = i;
                                    getElem().find("li").css({ backgroundColor: "", color: "#666666" });
                                    this.style.backgroundColor = "#FA8F5C";
                                    this.style.color = "#FFF";
                                }, function () { });
                            });
                        }
                        if (getElem().filter(":hidden")[0]) {
                            getElem().css({ height: "0px", display: "block" });
                        }
                        var tw = opt.inputWidth != null && opt.inputWidth > 0 ? opt.inputWidth : $(the).outerWidth();
                        var th = opt.inputHeight != null && opt.inputHeight > 0 ? opt.inputHeight : $(the).outerHeight();
                        var h = 250;
                        var l = parseInt($(the).offset().left) - parseInt($(the).css("marginLeft"));
                        var tt = parseInt($(the).offset().top) - parseInt($(the).css("marginTop"));
                        var t = tt + parseInt(th);
                        var clientH = $(document).height();
                        getElem().css({ left: l - (361 - tw) + 1 });
                        if (clientH - t >= h) {
                            getElem().stop().css({ top: t }).animate({ height: h }, 0);
                        } else {
                            if (getElem().height() == 0) {
                                getElem().stop().css({ top: tt, height: "0px" }).animate({ top: tt - h - 2, height: h }, 0);
                            } else {
                                getElem().stop().animate({ top: tt - h - 2, height: h }, 0);
                            }
                        }
                    });
                } else {
                    getElem().css("display", "none");
                }
            }
        }
        function search_keydown(e) {
            var len = getElem().find("li").length;
            if (e.keyCode == 38) {
                window.clearInterval(timer);
                if (len > 0) {
                    if (childindex <= 0) {
                        childindex = len - 1;
                    } else {
                        childindex--;
                    }
                    getElem().find("li").css({ backgroundColor: "", color: "#666666" }).eq(childindex).css({ backgroundColor: "#FA8F5C", color: "#FFF" });
                    scrollUL(getElem().children("div").children("ul")[0], childindex, e.keyCode);
                    timer = window.setInterval(function () {
                        if (childindex <= 0) {
                            childindex = len - 1;
                        } else {
                            childindex--;
                        }
                        getElem().find("li").css({ backgroundColor: "", color: "#666666" }).eq(childindex).css({ backgroundColor: "#FA8F5C", color: "#FFF" });
                        scrollUL(getElem().children("div").children("ul")[0], childindex, e.keyCode);
                    }, 850);
                }
            } else if (e.keyCode == 40) {
                window.clearInterval(timer);
                if (len > 0) {
                    if (childindex >= len - 1) {
                        childindex = 0;
                    } else {
                        childindex++;
                    }
                    getElem().find("li").css({ backgroundColor: "", color: "#666666" }).eq(childindex).css({ backgroundColor: "#FA8F5C", color: "#FFF" });
                    scrollUL(getElem().children("div").children("ul")[0], childindex, e.keyCode);
                    timer = window.setInterval(function () {
                        if (childindex >= len - 1) {
                            childindex = 0;
                        } else {
                            childindex++;
                        }
                        getElem().find("li").css({ backgroundColor: "", color: "#666666" }).eq(childindex).css({ backgroundColor: "#FA8F5C", color: "#FFF" });
                        scrollUL(getElem().children("div").children("ul")[0], childindex, e.keyCode);
                    }, 850);
                }
            } else if (e.keyCode == 13) {
                if (childindex > -1) {
                    return false;
                }
            }
        }
        function scrollUL(ul, index, keyCode) {
            if(keyCode == undefined || keyCode == 0){ return; }
            var liTop = $(ul).find('li').eq(index).offset().top;
            var liHeight = $(ul).find('li').eq(index).outerHeight();
            var ulTop = $(ul).offset().top;
            var ulscroTop = $(ul).scrollTop();
            var ulborderTop = 0;//$(ul).css("border-top-width").replace('px', '');
            var ulheight = $(ul).height();
            var lioffsetulTop = liTop - ulTop - ulborderTop + ulscroTop;
            if ($(ul).hasScrollBarY()) {
                if (!(lioffsetulTop > ulscroTop && ulscroTop + ulheight > lioffsetulTop + liHeight)) {
                    switch (keyCode) {
                        case 38:
                            $(ul).scrollTop(lioffsetulTop);
                            break;
                        case 40:
                            $(ul).scrollTop(lioffsetulTop - ulheight + liHeight);
                            break;
                    }
                }
            }
        }

        function getElem() {
            var el = $("#oms_autocomplateV2");
            if (el.length == 0) {
                var elui ='<div id="oms_autocomplateV2" style="display:none;position:absolute;list-style-type:none;margin:0;padding:0;border:1px solid #e12b29;overflow:hidden; background-color:#FFFFFF;z-index:10010;max-height:350px;width:360px;">';
                elui += '<div class="oms_autoV2_border" style="border:5px solid #f8f1cf;margin:0;padding:0;overflow:hidden;position:relative;max-height:240px; height:240px;">';
                elui += '<h4 style="font-size:12px; height:36px;display:block;line-height:18px;background-color:#FFF7E0;width:330px;margin:2px auto;padding:0px 8px; color:#666;position:relative;">';
                elui += '</h4>';
                elui += '<ul style="margin:0;padding:0;overflow:auto;position:relative;height:200px;">';
                elui += '</ul>';
                elui += "</div>";
                elui += "</div>";
                el = $(elui).appendTo(document.body);
            }
            return el;
        }

        $('html,body').click(function () {
            getElem().css("display", "none");
            childindex = -1;
        });

        return this.each(function () {
            $(this).keydown(search_keydown).keyup(search_keyup).bind('selected', opt.select).bind('beforeajaxfunc', opt.beforeajaxfunc);
            if(opt.clickDown){
                getElem();
                $(this).click(function(e){
                    getElem().css({ left: $(this).offset().left - (361 - (opt.inputWidth != null && opt.inputWidth > 0 ? opt.inputWidth : $(this).outerWidth())),top: $(this).offset().top + $(this).height() + 1,display: 'block'  }).find("ul").empty();
                    $(this).keyup();
                    e.stopPropagation();
                });
            }
        });
    };
})(jQuery);