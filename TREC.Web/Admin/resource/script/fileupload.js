
//上传事件
function _upfile(i) {
    $(".seeupfile").remove();
    var obj1 = $(i);
    var fid = i.form.id;
    var strUrl = _strBasePath() + "ajaxtools/fileupload.ashx?f=" + $(obj1).attr("name") + "&t=add";
    $("#" + fid).ajaxSubmit({
        beforeSubmit: function (formData, jqForm, options) {
            _fileuploadEffect('display', i);
        },
        success: function (data) {
            _fileuploadEffect('hide', i);
            var isOne = false;
            $.each(data, function (ls) {
                if (isOne) {
                    return;
                }
                isOne = true;
                if (data[ls].msg == "0") {
                    $(obj1).parent().parent().find("input[type='hidden']").val("");
                    $(obj1).parent().find("input.filedisplay").attr("value", "");
                    alert(data[ls].msbox);
                }
                else {
                    if ($(obj1).parent().parent().find("input.filedisplay").attr("value") != "") {
                        $(obj1).parent().parent().parent().find("input[type='hidden']").val().replace($(obj1).parent().parent().find("input.filedisplay").attr("value"), data.msbox);

                    } else {
                        if ($(obj1).parent().parent().parent().find("input[type='hidden']").val() == "") {
                            $(obj1).parent().parent().parent().find("input[type='hidden']").val(data.msbox + ",");
                        }
                        else {
                            $(obj1).parent().parent().parent().find("input[type='hidden']").val($(obj1).parent().parent().parent().find("input[type='hidden']").val() + data.msbox + ",");
                        }
                    }
                    if ($(obj1).parent().parent().parent().hasClass("m")) {
                        $(obj1).parent().parent().parent().append(_jsfileuploadInputHtml(_jsfileuploadGetNewName($(obj1).attr("name"))));
                    }
                    $(obj1).parent().parent().find("input.filedisplay").attr("value", data.msbox);

                    //$(obj1).attr("disabled", "false");
                    getHtmlTools(obj1, "up");
                }
            });
        },
        error: function (data, status, e) {
            alert("上传失败，错误信息：" + e);
        },
        url: strUrl,
        dataType: "json",
        timeout: 600000
    });
}

function _updel(i,t) {
    var obj1 = $(i);
    //$(obj1).parent().find("input[type='file']").attr("disabled", "true");
    var submitUrl = _strBasePath() + "ajaxtools/fileupload.ashx?f=" + $(obj1).parent().find("input.filedisplay").attr("value") + "&t=del&dt=" + t;
    $.ajax({
        url: submitUrl,
        timeout: 600000,
        dataType: "json",
        success: function (data) {
            if (data.msg == "1") {
                $(obj1).parent().parent().find("input[type='hidden']").val($(obj1).parent().parent().find("input[type='hidden']").val().replace($(obj1).parent().find("input.filedisplay").attr("value") + ",", ""));
                if ($(obj1).parent().parent().hasClass("m")) {
                    $(obj1).parent().remove();
                }
                else {
                    $(obj1).parent().parent().find("input[type='hidden']").val("");
                    $(obj1).parent().find("input.filedisplay").attr("value", "");
                    $(i).next().remove();
                    $(i).remove();
                }
            }
            else {
                $(obj1).parent().parent().find("input[type='hidden']").val($(obj1).parent().parent().find("input[type='hidden']").val().replace($(obj1).parent().find("input.filedisplay").attr("value") + ",", ""));
                if ($(obj1).parent().parent().hasClass("m")) {
                    $(obj1).parent().remove();
                }
                else {
                    $(obj1).parent().parent().find("input[type='hidden']").val("");
                    $(obj1).parent().find("input.filedisplay").attr("value", "");
                    $(i).next().remove();
                    $(i).remove();
                }
                alert(data.msbox);
            }
        }
    });
}

function _upsee(i, t) {
    if ($(i).text() == "预览") {
        $("a._filesee").text("预览");
        $(i).text("关闭");
        $(".seeupfile").remove();
        var obj1 = $(i);
        var cHtml = "";
        var objImg;
        if (t.indexOf("edit_") < 0) {
            objImg = _strBasePath() + "/upload/temp/" + $(obj1).parent().find("input.filedisplay").attr("value");
        }
        else {
            objImg = _strBasePath() + t.replace("edit_", "") + $(obj1).parent().find("input.filedisplay").attr("value");
        }
        


        var ni = new Image();
        ni.onload = function () {
            var width = ni.width;
        }
        ni.src = objImg;

        cHtml = "<div class=\"seeupfile\" name=\"1\" width='" + ni.width + "' height='" + ni.width + "' >";
        cHtml += "<img src=\"" + objImg + "\" alter=\"点击关闭\" />";
        cHtml += "</div>"
        $(obj1).append(cHtml);
    } else {
        if ($(i).text() == "关闭") {
            $($(i)).find("div").remove();
            $(i).text("预览")
        }
    }
}


$(function () {
    var j = 0;
    $.each($(".fileUpload"), function () {
        //alert($(this).html())
        if ($(this).find("input[type='hidden']").attr("value") != "" && $(this).find("input[type='hidden']").attr("value").length > 0) {
            var arrFileList = new Array();
            arrFileList = $(this).find("input[type='hidden']").attr("value").split(",");
            //alert($(this).html())
            if (!$(this).hasClass("m")) {
                $(this).find(".filedisplay").val(arrFileList[0]);
                getHtmlTools($(this).find("input[type='file']"), "edit_" + $(this).attr("path"));
            } else {
                for (var n = 0; n < arrFileList.length; n++) {

                    if (arrFileList[n] != "") {
                        $(_jsfileuploadInputHtml("nf" + "_" + j + "_" + n)).insertBefore($(this).find(".fileTools:eq(" + n + ")"));
                        //$(this).append();
                        //$(this).parent().find(".filedisplay").attr("value", arrFileList[n]);
                        $(this).find("input[name='" + "nf" + "_" + j + "_" + n + "']").parent().parent().find(".filedisplay").val(arrFileList[n]);
                        getHtmlTools($(this).find("input[name='" + "nf" + "_" + j + "_" + n + "']"), "edit_" + $(this).attr("path"));
                    }
                }
            }
        }
        j++;
    });
})

///生成新的上传工具
function _jsfileuploadInputHtml(o) {

    var inputHtml = "<div class=\"fileTools\">";
    inputHtml += "<input type=\"text\" class=\"input w160 filedisplay\" />";
    inputHtml += "<a href=\"javascript:void(0);\" class=\"files\">";
    inputHtml += "<input type=\"file\" onchange=\"_upfile(this)\" class=\"upload\" name=\"" + o + "\" runat=\"server\" />";
    inputHtml += "上传</a>";
    inputHtml += "<span class=\"uploading\">正在上传，请稍候...</span>";
    inputHtml += "</div>";
    return inputHtml;
}


///多个上传时生成新地ID
function _jsfileuploadGetNewName(name) {
    if (name == null) {
        name = "newt";
    }
    var lastPlace = name.lastIndexOf("_");
    var oldname = name.substr(lastPlace + 1, name.length - lastPlace - 1);

    var r = /^[0-9]*[1-9][0-9]*$/; //正整数
    if (!r.test(oldname)) {
        newName = name + "_1";
    }
    else {
        var _name = name.substr(0, lastPlace);
        if (!isNaN(parseInt(oldname))) {
            var i = parseInt(oldname);
            newName = _name + "_" + (i + 1).toString();
        }
        else {
            newName = name + "_1";
        }
    }
    return newName;
}


//loading按钮
function _fileuploadEffect(type, i) {
    if (type == 'display') {
        //隐藏上传按钮
        $($(i)).parent().nextAll(".files").eq(0).hide();
        //显示LOADING图片
        $($(i)).parent().nextAll(".uploading").eq(0).show();
    }
    if (type == 'hide') {
        $($(i)).parent().nextAll(".files").eq(0).show();
        $($(i)).parent().nextAll(".uploading").eq(0).hide();
    }
}


//工具
function getHtmlTools(o,t) {
    $(o).parent().parent().find("a._filedel,a._filesee").remove();
    $(o).parent().parent().append("<a href=\"javascript:;\" class=\"_filedel\" onclick=\"_updel(this,'" + t + "')\">删除</a><a href=\"javascript:;\" class=\"_filesee\"  onclick=\"_upsee(this,'" + t + "')\">预览</a>");
}

///上传ajax处理文件路径
function _strBasePath() {
    var baseUrl = document.domain;
    var port = document.location.port;
    if (port != "") {
        port = ":" + port;
    }
    return "http://" + baseUrl + port + "/";
}