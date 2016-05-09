
//select all
function chkAll(obj, listobjId) {
    var isSelected = $(obj).attr('id').toString() == 'off' ? true : false;
    $(obj).attr('id', (isSelected == true ? 'on' : 'off'));
    $('#' + listobjId.toString() + ' input[type=checkbox]').attr('checked', isSelected);
}

//check is selected checkbox
function checkSelectedObj(listobjId) {
    var objId=$('#' + listobjId.toString() + ' input[type=checkbox]:checked');
    var squantity = objId.size();
    if (squantity == 0) {
        return '';
    }
    else {
        var infoId = '';
        objId.each(function () {
            if (infoId != '') {
                infoId += ',';
            }
            infoId += $(this).val();
        });
        return infoId;
    }
}

//cancel checkbox checked
function cancelCheckBoxChecked(listobjId) {
    $('#' + listobjId.toString() + ' input[type=checkbox]').attr('checked', false);
}

//go to page
function goPage(objId, totalpage, url) {
    var page = $.trim($('#' + objId.toString()).val());
    if (page == '') { return; }
    else if (page == '0') { page = 1; }
    else {
        if (parseInt(totalpage.toString(), 10) < parseInt(page.toString(), 10)) {
            page = totalpage;
        }
    }    
    location.href = url+'Page='+page.toString();
}

function changeUrlPara(obj, paraName, controlType) {
    var myvalue = '';
    if (controlType == 'select') {
        myvalue = obj.value;
    } else {
        myvalue = $.trim($(obj).val());
    }
    changeUrl(paraName, myvalue);
}

function changeUrl(paraName, myvalue) {
    var myurl = $.trim(location.href.toString());
    if (-1 < myurl.indexOf('?')) {
        myurl = myurl.substring(myurl.lastIndexOf('?') + 1);
        //转换小写
        myurl = myurl.toLowerCase();
        paraName = paraName.toLowerCase();
        var myArr = myurl.split('&');
        var newurl = '';
        var isFind = false;
        for (var i = 0; i < myArr.length; i++) {
            if (-1 < myArr[i].toString().indexOf(paraName.toString() + '=')) {
                newurl += paraName.toString() + '=' + myvalue.toString() + '&';
                isFind = true;
            } else {
                newurl += myArr[i].toString() + '&';
            }
        }
        if (isFind) {
            newurl = newurl.substring(0, newurl.length - 1);
        } else {
            newurl += paraName + '=' + myvalue;
        }
        location.href = '?' + newurl;
    } else {
        location.href = '?' + paraName.toString() + '=' + myvalue.toString();
    }
}

function showDelBoxHtml(message,idStr,type,mytitle) {
    var bhtml = '<div class="pop bord">';
    bhtml += '<h1><u>' + mytitle + '</u><i>X</i></h1>';
    bhtml += '<div class="popcon">';
    bhtml += '<p class="deltip">'+message+'</p>';
    bhtml += '<div class="btnone"><input type="button" value="确定" class="btnlitl" onclick="doAboutDb(\'' + idStr + '\',\'' + type + '\');" /><input name="button" type="button" value="取消" class="btnlitr" /></div>';
    bhtml += '</div></div>';
    return bhtml;
}

function hideDelBox(){
   $('.pop').remove();
}

$.fn.numeral = function () {
    $(this).css("ime-mode", "disabled");
    this.bind("keypress", function (event) {
        var isie = (document.all) ? true : false; //判断是IE内核还是Mozilla
        var keyCode = '';
        if (isie) {
            keyCode = event.keyCode;
        }
        else {
            keyCode = event.which;
            if (keyCode == 0 || keyCode == 8) {
                return true;
            }
        }

        if (keyCode == 46) {
            if (this.value.indexOf(".") != -1) {
                return false;
            }
        } else {
            return keyCode >= 46 && keyCode <= 57;
        }
    });
    this.bind("blur", function () {
        if (this.value.lastIndexOf(".") == (this.value.length - 1)) {
            this.value = this.value.substr(0, this.value.length - 1);
        } else if (isNaN(this.value)) {
            this.value = "";
        }
    });
    this.bind("paste", function () {
        var s = clipboardData.getData('text');
        if (!/\D/.test(s));
        value = s.replace(/^0*/, '');
        return false;
    });
    this.bind("dragenter", function () {
        return false;
    });
    this.bind("keyup", function () {
        if (/(^0+)/.test(this.value)) this.value = this.value.replace(/^0*/, '');
    });
};

function selectDdlByValue(objId, objValue) {
    $('#' + objId.toString() + ' option[value=\'' + objValue.toString() + '\']').attr('selected', true);
}
