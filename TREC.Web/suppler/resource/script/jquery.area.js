$(function () {
    var baseUrl = document.domain;
    var port = document.location.port;
    if (port != "") {
        port = ":" + port;
    }
    baseurl = "http://" + baseUrl + port + "/";

    $("._droparea").html();
    var objid = $("._droparea").attr("id");
    var pid = $("._droparea").attr("id") + "_province";
    var cid = $("._droparea").attr("id") + "_city";
    var did = $("._droparea").attr("id") + "_district";
    var tid = $("._droparea").attr("id") + "_town";
    var vid = $("._droparea").attr("id") + "_value";

    $("._droparea").html("<select id=\"" + pid + "\" name=\"" + pid + "\" ></select>");
    $("._droparea").append("<select id=\"" + cid + "\" name=\"" + cid + "\" ></select>");
    $("._droparea").append("<select id=\"" + did + "\" name=\"" + did + "\" ></select>");
    $("._droparea").append("<select id=\"" + tid + "\" name=\"" + tid + "\" ></select>");
    $("._droparea").append("<input type=\"hidden\" id=\"" + vid + "\" name=\"" + vid + "\" value=\"" + $("#" + objid).attr("title") + "\" runat=\"server\" />");

    $.ajax({
        url: baseurl + "/ajaxtools/ajaxarea.ashx",
        data: "type=p&s=" + $("#" + objid).attr("title"),
        async: false,
        success: function (data) {
            $("#" + pid).html(data);
            $("#" + tid).hide();
            $("#" + cid).html("<option value=\"\">请选择城市</option>");
            $("#" + did).html("<option value=\"\">请选择地区</option>");
            $("#" + cid).hide();
            $("#" + did).hide();
        },
        error: function (d, m) {
            alert(m);
        }
    });

    if ($("#" + objid).attr("title") != null && $("#" + objid).attr("title") != "" && $("#" + objid).attr("title").length == 6) {
        $.ajax({
            url: baseurl + "/ajaxtools/ajaxarea.ashx",
            data: "type=edit&s=" + $("#" + objid).attr("title"),
            dataType: "json",
            async: false,
            success: function (data) {
                $.each(data, function (i) {
                    if (data[i].type == "city") {
                        $("#" + cid).show();
                        $("#" + cid).append("<option value=\"" + data[i].areacode + "\" selected=\"true\">" + data[i].areaname + "</option>");
                    }
                    if (data[i].type == "district") {
                        $("#" + did).show();
                        $("#" + did).append("<option value=\"" + data[i].areacode + "\" selected=\"true\">" + data[i].areaname + "</option>");
                    }
                    if (data[i].type != null && data[i].type == "town") {
                        $("#" + tid).show();
                        $("#" + tid).append("<option value=\"" + data[i].areacode + "\" selected=\"true\">" + data[i].areaname + "</option>");
                    }
                    else {
                        $("#" + tid).hide();
                    }
                });
            },
            error: function (d, m) {
                alert(d + m);
            }
        });
    }

    $("#" + pid).live("change", function () {
        if ($(this).val() != "" && $(this).val() != "0") {
            $.ajax({
                url: baseurl + "/ajaxtools/ajaxarea.ashx",
                data: "type=c&p=" + $(this).val(),
                success: function (data) {
                    if (data == null || data == "null") {
                        $("#" + cid).html("<option value=\"\">请选择城市</option>");
                        $("#" + did).html("<option value=\"\">请选择地区</option>");
                        $("#" + tid).html("");
                        $("#" + cid).hide();
                        $("#" + did).hide();
                        $("#" + tid).hide();
                    }
                    else {
                        $("#" + cid).hide();
                        $("#" + cid).show();
                        $("#" + cid).html("");
                        $("#" + cid).html(data);
                        $("#" + did).html("");
                        $("#" + did).hide();
                        $("#" + tid).html("");
                        $("#" + tid).hide();
                    }
                },
                error: function (d, m) {
                    alert(m);
                }
            });
            $("#" + vid).attr("value", $(this).val());
        }
    })

    $("#" + cid).live("change", function () {
        if ($(this).val() != "" && $(this).val() != "0") {
            $.ajax({
                url: baseurl + "/ajaxtools/ajaxarea.ashx",
                data: "type=d&c=" + $(this).val(),
                success: function (data) {
                    if (data == null || data == "null") {
                        $("#" + did).html("<option value=\"\">请选择地区</option>");
                        $("#" + tid).html("");
                        $("#" + did).hide();
                        $("#" + tid).hide();
                    }
                    else {
                        $("#" + did).hide();
                        $("#" + did).show();
                        $("#" + did).html("");
                        $("#" + did).html(data);
                        $("#" + tid).html("");
                        $("#" + tid).hide();
                    }
                },
                error: function (d, m) {
                    alert(m);
                }
            });

            $("#" + vid).attr("value", $(this).val());
        }
    })
    $("#" + did).live("change", function () {
        if ($(this).val() != "" && $(this).val() != "0") {
            //            $.ajax({
            //                url: baseurl + "/ajaxtools/ajaxarea.ashx",
            //                data: "type=t&d=" + $(this).val(),
            //                success: function (data) {
            //                    if ($(data).html() != null || $(data).html() != "") {
            //                        $("#" + tid).html("");
            //                        $("#" + tid).hide();
            //                        $("#" + tid).show();
            //                        $("#" + tid).html(data);
            //                    } else {
            //                        $("#" + tid).hide();
            //                    }
            //                },
            //                error: function (d, m) {
            //                    alert(m);
            //                }
            //            });

            $("#" + vid).attr("value", $(this).val());
        }
        else {
            $("#" + tid).hide();
        }
    });
    $("#" + tid).live("change", function () {
        if ($(this).val() != "" && $(this).val() != "0") {
            $("#" + vid).attr("value", $(this).val());
        }
    });

})