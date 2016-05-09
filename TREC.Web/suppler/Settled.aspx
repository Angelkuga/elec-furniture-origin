<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Settled.aspx.cs" Inherits="TREC.Web.Suppler.Settled" %>

<%@ Register Src="ascx/head.ascx" TagName="MemberHeader" TagPrefix="uc2" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/Base.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #bfProvince, #mProvince, #bfCity, #cfDistrict, #mCity, #mDistrict
        {
            width: 65px;
        }
        .tipSpan
        {
            color: Red;
        }
        .titletb
        {
            margin:0px 0px 0px 0px;
            padding:0px 0px 0px 0px;
        }
        titletb td
        {
            margin:0px 0px 0px 0px;
            padding:0px 0px 0px 0px;
         }
         select
         {
             width:65px;
          }
    </style>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/formValidatorRegex.js"
        charset="UTF-8"></script>
    <script>
        function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
        $(function () {
            var type;
            var sid = getQueryString("sid");
            var ut = 1;
            switch (sid) {
                case "101":
                    type = "品牌厂商";
                    ut = 1;
                    break;
                case "102":
                    type = "经销商";
                    ut = 2;
                    break;
                case "103":
                    type = "卖场";
                    ut = 3;
                    break;
            }
            $("#utype").html(type + "入住");
            submitShieldedBt(0);
            $('.spocon').hide();
            $('.spocon:eq(' + (parseInt(ut, 10) - 1) + ')').show();
        }
        );
        //屏蔽或恢复提交按钮
        function submitShieldedBt(type) {
            //判断是否存在
            var mydisabled = $('.btnl').attr('disabled');
            if (type == 1) {
                if (mydisabled == undefined) {
                    $('.btnl').attr('disabled', 'disabled');
                }
            } else {
                if (mydisabled != undefined) {
                    if (mydisabled.toString() == 'disabled') {
                        $('.btnl').removeAttr('disabled');
                    }
                }
            }
        }
    </script>
</head>
<body style="background: #CCC">
    <form id="form1" runat="server" >
    <div class="steponebox bord" style="position: absolute; left: 50%; top: 45%; margin: -195px 0px 0px -360px;
        display: block; width: 700px; z-index: 1986; background: #FFFFFF" class="aui_state_focus aui_state_lock">
        （第②步）提交您公司信息 
        
        <h1>
            <span id="utype"></span><i>1分钟注册成为家具快搜的优质商家</i></h1>
        <%--<div class="choice_leixing"><span>请选择商家类型</span>
  <select id="UserType">
    <option value="1">厂商</option>
    <option value="2">经销商</option>
    <option value="3">卖场</option>
  </select></div>--%>
        <!--品牌厂商资料-->
        <div class="spocon bord">
            <table width="650" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        工厂名称
                    </td>
                    <td colspan="3" align="left">
                        <input id="bFactoryName" class="novalie" type="text" maxlength="200" style="width: 418px;" /><span
                            class="tipSpan" id="tipbFactoryName">*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        工厂地区
                    </td>
                    <td colspan="3" align="left">
                        <%--<select id="bfProvince"><option value="">请选择</option><asp:Repeater ID="RptFp" runat="server"><ItemTemplate><option value="<%#Eval("Code") %>"><%#Eval("Name") %></option></ItemTemplate></asp:Repeater></select>
        &nbsp;
        <select id="bfCity"><option value="">请选择</option></select>
        &nbsp;
        <select id="cfDistrict"><option value="">请选择</option></select><span class="tipSpan">*</span>
        &nbsp;--%>
                        <asp:DropDownList ID="bfProvince" runat="server" CssClass="select">
                        </asp:DropDownList>
                        <select id="bfCity" onchange="bindArea(this,'d','c','cfDistrict')">
                            <option value="">请选择</option>
                        </select>
                        &nbsp;
                        <select id="cfDistrict">
                            <option value="">请选择</option>
                        </select>
                        <input id="cfAddress" type="text" maxlength="100" style="width: 200px;"  placeholder="请输入街道地址"/><span id="tipcfAddress"
                            class="tipSpan">*</span>
                    </td>
                </tr>
                <tr style="display:none;">
                    <td align="right">
                        详细地址
                    </td>
                    <td colspan="3" align="left">
                       
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        品牌名称
                    </td>
                    <td colspan="3" align="left">
                        <input type="text" maxlength="100" style="width: 418px" id="bfBrand" /><span id="tipbfBrand"
                            class="tipSpan">*</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        联系人
                    </td>
                    <td align="left">
                        <input type="text" id="cfContact" maxlength="20" /><span id="tipcfContact" class="tipSpan">*</span>
                    </td>
                    <td align="right">
                        职位
                    </td>
                    <td align="left">
                        <select id="cfDuty">
                            <option value="1">总经理</option>
                            <option value="2">总监</option>
                            <option value="3">经理</option>
                            <option value="4">主管</option>
                            <option value="5">业务员</option>
                        </select>
                        <%-- <input type="text" id="cfDuty" maxlength="20" /></td>--%>
                </tr>
                <tr>
                    <td align="right">
                        手机
                    </td>
                    <td align="left">
                        <input type="text" id="cfMobile" maxlength="12" /><span id="tipcfMobile" class="tipSpan">*</span>
                    </td>
                    <td align="right">
                        或固定电话
                    </td>
                    <td align="left">
                        <input type="text" maxlength="4" style="width: 30px;" id="cfTelCode"  />-
                        <input type="text" maxlength="10" style="width: 80px;" id="cfTelPhone" />-
                        <input type="text" maxlength="6" style="width: 30px;" id="cfTelEXT" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        QQ
                    </td>
                    <td align="left" colspan="3">
                        <input type="text" id="cfQQWeiBo" maxlength="15" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        默认联系邮箱
                    </td>
                    <td align="left" colspan="3">
                        <input type="text" id="cfEmail" maxlength="50" style="color: #c1c1c1;" />
                    </td>
                </tr>
            </table>
        </div>
        <!--经销商资料-->
        <div class="spocon bord" style="display: none;">
            <table width="650" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        代理品牌名称
                    </td>
                    <td colspan="3" align="left">
                        <input id="dBrandName" maxlength="100" type="text" style="width: 418px;" /><span
                            id="tipdBrandName" class="tipSpan">*</span>
                    </td>
                </tr>
                <tr>
                    <td height="40" align="right">
                        实体店地址
                    </td>
                    <td colspan="3" align="left">
                        <asp:DropDownList ID="ddlDpro" runat="server" CssClass="select">
                        </asp:DropDownList>
                        <select id="dCity" onchange="bindArea(this,'d','c','dDistrict')">
                            <option value="">请选择</option>
                        </select>
                        &nbsp;
                        <select id="dDistrict">
                            <option value="">请选择</option>
                        </select>
                        <input id="dAddress" type="text" maxlength="100" style="width: 200px;" placeholder="请输入街道地址"/><span id="Span3"
                            class="tipSpan">*</span>
                    </td>
                </tr>
                <tr style="display:none;">
                    <td align="right">
                        详细地址
                    </td>
                    <td colspan="3" align="left">
                       
                    </td>
                </tr>
                <%--<tr>
        <td align="right" valign="top">店铺名称</td>
        <td colspan="3" align="left"><textarea id="dShopName" style="width:420px;" rows="3"></textarea><span id="tipdShopName" class="tipSpan">*</span>
          <br />
          <span class="biaozhu">（例：红星美凯龙宝山区汶水路店，可填多个。）</span></td>
      </tr>--%>
                <tr>
                    <td align="right" valign="top">
                        经销商性质
                    </td>
                    <td colspan="3" align="left">
                        <asp:RadioButtonList ID="radioDType" RepeatDirection="Horizontal" runat="server">
                            <asp:ListItem Value="1">个体</asp:ListItem>
                            <asp:ListItem Value="2">企业</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        负责人
                    </td>
                    <td align="left">
                        <input type="text" id="dContact" maxlength="20" /><span id="tipdContact" class="tipSpan">*</span>
                    </td>
                    <td align="right">
                        职位
                    </td>
                    <td align="left">
                        <select id="dDuty">
                            <option value="1">总经理</option>
                            <option value="2">总监</option>
                            <option value="3">经理</option>
                            <option value="4">主管</option>
                            <option value="5">业务员</option>
                        </select>
                        <%-- <input type="text" id="dDuty" maxlength="50" /></td>--%>
                </tr>
                <tr>
                    <td align="right">
                        手机
                    </td>
                    <td align="left">
                        <input type="text" id="dMobile" maxlength="12" /><span id="tipdMobile" class="tipSpan">*</span>
                    </td>
                    <td align="right">
                        电话
                    </td>
                    <td align="left">
                        <input type="text" maxlength="4" style="width: 30px;" id="dTelCode" />-
                        <input type="text" maxlength="10" style="width: 80px;" id="dTelPhone" />-
                        <input type="text" maxlength="6" style="width: 30px;" id="dTelEXT" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        QQ
                    </td>
                    <td align="left" colspan="3">
                        <input type="text" id="dQQWeiBo" maxlength="15" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        默认联系邮箱
                    </td>
                    <td align="left" colspan="3">
                        <input type="text" id="dEmail" maxlength="50" style="color: #c1c1c1;" />
                    </td>
                </tr>
            </table>
        </div>
        <!--卖场资料-->
        <div class="spocon bord" style="display: none;">
            <table width="650" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        子卖场名称
                    </td>
                    <td colspan="3" align="left" style="padding-left:0px;">

                    <table border="0" class="titletb">
                    <tr>
                    <td valign="middle" style="width:125px;padding-left:2px;"><input id="mMarkName" placeholder="如：红星美凯龙" maxlength="200" type="text" style="width: 118px;" onblur="funmarketCheck()"/></td>
                    <td style="width:12px;padding-left:2px;" valign="middle">+</td>
                    <td valign="middle" style="width:125px;padding-left:2px;"><input id="stitle" maxlength="200" type="text" style="width: 118px;" placeholder="吴中路"  onblur="funmarketCheck()"/></td>
                  <td style="width:20px;padding-left:2px;" valign="middle">店<span id="tipmMarkName" class="tipSpan">*</span></td>
                   <td valign="middle" style="padding-left:2px;">
                    <div style="float:left;font-size:13px;font-weight:normal;" id="divmarketmsg"></div>
                       
                   </td>
                    </tr>
                    </table>
                        
                    </td>
                </tr>
                <tr style="display:none;">
                    <td align="right">
                        是否是集团身份
                    </td>
                    <td colspan="3" align="left">
                        <label>
                            <input id="mMarketClique" type="checkbox" />是卖场集团</label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        卖场地区
                    </td>
                    <td colspan="3" align="left">
                        <asp:DropDownList ID="ddlMPro" runat="server" CssClass="select">
                        </asp:DropDownList>
                        <select id="mCity" onchange="bindArea(this,'d','c','mDistrict')">
                            <option value="">请选择</option>
                        </select>
                        &nbsp;
                        <select id="mDistrict">
                            <option value="">请选择</option>
                        </select>
                         <input id="mAddress" maxlength="100" style="width: 200px;" type="text" placeholder="请输入街道地址"/><span id="tipmAddress"
                            class="tipSpan">*</span>
                    </td>
                </tr>
                <tr style="display:none;">
                    <td align="right">
                        详细地址
                    </td>
                    <td colspan="3" align="left">
                      
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        联系人
                    </td>
                    <td align="left">
                        <input type="text" id="mContact" maxlength="20" /><span id="tipmContact" class="tipSpan">*</span>
                    </td>
                    <td align="right">
                        职位
                    </td>
                    <td align="left">
                        <select id="mDuty">
                            <option value="1">总经理</option>
                            <option value="2">总监</option>
                            <option value="3">经理</option>
                            <option value="4">主管</option>
                            <option value="5">业务员</option>
                        </select>
                    </td>
                    <%--<input type="text" id="mDuty" maxlength="50" /></td>--%>
                </tr>
                <tr>
                    <td align="right">
                        手机
                    </td>
                    <td align="left">
                        <input type="text" id="mMobile" maxlength="12" /><span id="tipmMobile" class="tipSpan">*</span>
                    </td>
                    <td align="right">
                        或固定电话
                    </td>
                    <td align="left">
                        <input type="text" maxlength="4" style="width: 30px;" id="mTelCode" />-
                        <input type="text" maxlength="10" style="width: 80px;" id="mTelPhone" />-
                        <input type="text" maxlength="6" style="width: 30px;" id="mTelEXT" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        QQ
                    </td>
                    <td align="left" colspan="3">
                        <input type="text" id="mQQWeiBo" maxlength="15" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        默认联系邮箱
                    </td>
                    <td align="left" colspan="3">
                        <input type="text" id="mEmail" maxlength="50" style="color: #c1c1c1;" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
        <div class="btnone">
            <input type="button" value="提 交" class="btnl" />
            <input type="reset" value="重 填" class="btnr" />
        </div>
    </div>
    </form>
    <script type="text/javascript">
       <!--

        $(function () {
            //添加要验证的控件id
            var checkInput = [
            "bFactoryName", "cfAddress", "bfBrand", "cfContact", "cfMobile",
             "dBrandName", "dFactoryName", "dShopName", "dContact", "dMobile",
             "mMarkName", "mAddress", "mContact", "mMobile"
            ];
            $.each(checkInput, function (key, val) {
                //alert(key+"asd"+val);
                $("#" + val).bind("blur", function () {
                    // alert(this.value);
                    if (this.value != "") {
                        if ($(this).parent().find("span[class='error success']").length == 0) {
                            // $("#tip" + this.id).html('<span class="error success"> </span>');
                            $("#tip" + this.id).hide();
                            $('<span class="error success"> </span>').insertAfter(this);
                            //$(this).append('<span class="error success"> </span>');
                        }

                    } else {
                        if ($(this).parent().find("span[class='error success']").length > 0) {
                            $(this).parent().find("span[class='error success']").remove();
                            $("#tip" + this.id).show();
                        }

                    }
                });
            });
            //工厂qq
            $("#cfQQWeiBo").bind("blur", function () {
                if (this.value != "") {
                    $("#cfEmail").val(this.value + "@qq.com");
                }
            });
            //经销商qq绑定邮箱
            $("#dQQWeiBo").bind("blur", function () {
                if (this.value != "") {
                    $("#dEmail").val(this.value + "@qq.com");
                }
            });
            //卖场商qq绑定邮箱
            $("#mQQWeiBo").bind("blur", function () {
                if (this.value != "") {
                    $("#mEmail").val(this.value + "@qq.com");
                }
            });
        });

        $(function () {
            $('#UserType').change(function () {
                var myvalue = $(this).val();
                submitShieldedBt(0);
                $('.spocon').hide();
                $('.spocon:eq(' + (parseInt(myvalue.toString(), 10) - 1) + ')').show();
            });
            $('.btnl').click(function () {
                //get settled type
                var mytype = getQueryString("sid");
                switch (mytype.toString()) {
                    case '101':
                        brandFactorySettled();
                        break;
                    case '102':
                        DealerSettled();
                        break;
                    case '103':
                        MarketSettled();
                        break;
                }
            });





            //             $('#mCity').change(function () {
            //                 loadCityDb(this.value, 'mDistrict');
            //             });

            var reg = null;
            //            $('#cfTel,#dTel,#mTel').blur(function () {
            //                var myvalue = $.trim($(this).val());
            //                if (myvalue != '') {
            //                    reg = new RegExp(regexEnum.tel);
            //                    if (!reg.test(myvalue.toString())) {
            //                        submitShieldedBt(1);
            //                        alert('抱歉，输入的电话有误！');
            //                    } else {
            //                        submitShieldedBt(0);
            //                    }
            //                }
            //            });

            $('#cfMobile,#dMobile,#mMobile').blur(function () {
                var myvalue = $.trim($(this).val());
                if (myvalue != '') {
                    reg = new RegExp(regexEnum.mobile);
                    if (!reg.test(myvalue.toString())) {
                        submitShieldedBt(1);
                        alert('抱歉，输入的手机号码有误！');
                    } else {
                        submitShieldedBt(0);
                    }
                }
            });

            $('#cfQQWeiBo,#dQQWeiBo,#mQQWeiBo').blur(function () {
                var myvalue = $.trim($(this).val());
                if (myvalue != '') {
                    reg = new RegExp(regexEnum.qq);
                    if (!reg.test(myvalue.toString())) {
                        submitShieldedBt(1);
                        alert('抱歉，输入的QQ号码格式有误！');
                    } else {
                        submitShieldedBt(0);
                    }
                }
            });

            $('#cfEmail,#dEmail,#mEmail').blur(function () {
                var myvalue = $.trim($(this).val());
                if (myvalue != '') {
                    reg = new RegExp(regexEnum.email);
                    if (!reg.test(myvalue.toString())) {
                        submitShieldedBt(1);
                        alert('抱歉，输入的E-mail有误！');
                    } else {
                        submitShieldedBt(0);
                    }
                }
            });
        })

        //屏蔽或恢复提交按钮
        function submitShieldedBt(type) {
            //判断是否存在
            var mydisabled = $('.btnl').attr('disabled');
            if (type == 1) {
                if (mydisabled == undefined) {
                    $('.btnl').attr('disabled', 'disabled');
                }
            } else {
                if (mydisabled != undefined) {
                    if (mydisabled.toString() == 'disabled') {
                        $('.btnl').removeAttr('disabled');
                    }
                }
            }
        }

        //品牌厂商入驻
        function brandFactorySettled() {
            var bFactoryName = $.trim($('#bFactoryName').val());
            if (bFactoryName == '') {
                alert('抱歉，请输入工厂名称！');
                $('#bFactoryName').focus();
                return;
            }
            var cfDuty = $.trim($('#cfDuty  option:selected').text());
            var cfQQWeiBo = $.trim($('#cfQQWeiBo').val());
            var cfAddress = "";

            var bfProvince = $.trim($('#<%=bfProvince.ClientID %> option:selected').val());
            var bfCity = $.trim($('#bfCity option:selected').val());
            var cfDistrict = $.trim($('#cfDistrict option:selected').val());
            if (bfProvince != '') {
                var bfProvinceName = $.trim($('#<%=bfProvince.ClientID %> option:selected').text());
                cfAddress += bfProvinceName;
            } else {
                alert('抱歉，请选择省份！');
                return;
            }
            if (bfCity != '') {
                var bfCityName = $.trim($('#bfCity option:selected').text());
                cfAddress += ' ' + bfCityName;
            } else {
                alert('抱歉，请选择城市！');
                return;
            }
            if (cfDistrict != '') {
                var cfDistrictName = $.trim($('#cfDistrict option:selected').text());
                cfAddress += ' ' + cfDistrictName;
            } else {
                alert('抱歉，请选择区或县！');
                return;
            }
            if ($.trim($('#cfAddress').val()) != '') {
                cfAddress += ' ' + $.trim($('#cfAddress').val());
            } else {
                alert('抱歉，请输入工厂地址！');
                $('#cfAddress').focus();
                return;
            }
            var bfBrand = $.trim($('#bfBrand').val());
            if (bfBrand == '') {
                alert('抱歉，请输入品牌名称！');
                $('#bfBrand').focus();
                return;
            }

            var cfContact = $.trim($('#cfContact').val());
            if (cfContact == '') {
                alert('抱歉，请输入联系人！');
                $('#cfContact').focus();
                return;
            }

            var cfTelCode = $.trim($('#cfTelCode').val()); //区号
            var cfTelPhone = $.trim($('#cfTelPhone').val()); //电话
            var cfTelEXT = $.trim($('#cfTelEXT').val()); //分机
            var cfTel = "";
            if (cfTelCode != "" || cfTelPhone != "") {
                cfTel = cfTelCode + "-" + cfTelPhone;
            }

            var cfMobile = $.trim($('#cfMobile').val());
            if (cfTel == '' && cfMobile == '') {
                alert('抱歉，电话跟手机至少输入一处，请输入！');
                $('#cfTel').focus();
                return;
            }
            if (cfMobile != '') {
                reg = new RegExp(regexEnum.mobile);
                cfr = reg.test(cfMobile);
                if (!cfr) {
                    alert('抱歉，您输入正确的手机号码！');
                    $('#cfMobile').focus();
                    return;
                }
            }

            var cfr = false;
            var reg = null;
            if (cfTel != "") {
                reg = new RegExp(regexEnum.tel);
                cfr = reg.test(cfTel);
                if (!cfr) {
                    alert('抱歉，您输入正确的电话号码！');
                    return;
                }
            }

            if (cfTel != "") {
                if (cfTelEXT != "" && new RegExp(regexEnum.num).test(cfTelEXT)) {
                    cfTel = cfTel + "-" + cfTelEXT;
                }
            }

            var cfEmail = $.trim($('#cfEmail').val());
            //            if (cfEmail == '') {
            //                alert('抱歉，请输入E-mail！');
            //                $('#cfEmail').focus();
            //                return;
            //            }
            if (cfEmail != '') {
                reg = new RegExp(regexEnum.email);
                cfr = reg.test(cfEmail);
                if (!cfr) {
                    alert('抱歉，请输入正确的E-mail！');
                    $('#cfEmail').focus();
                    return;
                }
            }

            var db = 'bFactoryName=' + escape(bFactoryName.toString()) + '&cfAddress=' + escape(cfAddress.toString()) + '&bfBrand=' + escape(bfBrand.toString()) + '&';
            db += 'cfContact=' + escape(cfContact.toString()) + '&cfDuty=' + escape(cfDuty.toString()) + '&cfTel=' + cfTel.toString() + '&cfMobile=' + cfMobile.toString() + '&';
            db += 'cfQQWeiBo=' + cfQQWeiBo.toString() + '&cfEmail=' + escape(cfEmail.toString()) + '&bfProvince=' + bfProvince.toString() + '&bfCity=' + bfCity.toString() + '&';
            db += 'cfDistrict=' + cfDistrict.toString() + '&Action=bfs&rnd=' + Math.random();
            //save db            
            SaveSettledDb(db);
            //alert(cfAddress);
        }

        //经销商入驻
        function DealerSettled() {
            var dBrandName = $.trim($('#dBrandName').val());
            if (dBrandName == '') {
                alert('抱歉，请输入代理品牌！');
                $('#dBrandName').focus();
                return;
            }
            var dAddress = $("#dAddress");
            if (dAddress.val() == "") {
                alert('抱歉，请输入详细地址！');
                dAddress.focus();
                return;
            }
            var dProvince = $.trim($('#<%=ddlDpro.ClientID %> option:selected').val());
            var dCity = $.trim($('#dCity option:selected').val());
            var dDistrict = $.trim($('#dDistrict option:selected').val());
            var ddAddress = "";
            if (dProvince != '') {
                var dProvinceName = $.trim($('#<%=ddlDpro.ClientID %> option:selected').text());
                ddAddress += dProvinceName;
            } else {
                alert('抱歉，请选择省份！');
                return;
            }
            if (dCity != '') {
                var dCityName = $.trim($('#dCity option:selected').text());
                ddAddress += ' ' + dCityName;
            } else {
                alert('抱歉，请选择城市！');
                return;
            }
            if (dDistrict != '') {
                var dDistrictName = $.trim($('#dDistrict option:selected').text());
                ddAddress += ' ' + dDistrictName;
            } else {
                alert('抱歉，请选择区或县！');
                return;
            }
            ddAddress += ' ' + $("#dAddress").val();
            var dType = $("input[name=radioDType]:checked");
            if (dType.length == 0) {
                alert("请选择经销商性质");
                return false;
            }
            var dContact = $.trim($('#dContact').val());
            if (dContact == '') {
                alert('抱歉，请输入负责人！');
                $('#dContact').focus();
                return;
            }
            var dTelCode = $.trim($('#dTelCode').val()); //区号
            var dTelPhone = $.trim($('#dTelPhone').val()); //电话
            var dTelEXT = $.trim($('#dTelEXT').val()); //分机
            var dTel = "";
            if (dTelCode != "" || dTelPhone != "") {
                dTel = dTelCode + "-" + dTelPhone;
            }

            var dMobile = $.trim($('#dMobile').val());
            if (dTel == '' && dMobile == '') {
                alert('抱歉，电话跟手机至少输入一处，请输入！');
                $('#dTel').focus();
                return;
            }
            if (dMobile != '') {
                reg = new RegExp(regexEnum.mobile);
                cfr = reg.test(dMobile);
                if (!cfr) {
                    alert('抱歉，您输入正确的手机号码！');
                    $('#dMobile').focus();
                    return;
                }
            }

            var cfr = false;
            var reg = null;
            if (dTel != "") {
                reg = new RegExp(regexEnum.tel);
                cfr = reg.test(dTel);
                if (!cfr) {
                    alert('抱歉，您输入正确的电话号码');
                    return;
                }
            }
            //追加区号
            if (dTel != "") {
                if (dTelEXT != "" && new RegExp(regexEnum.num).test(dTelEXT)) {
                    dTel = dTel + "-" + dTelEXT;
                }
            }

            var dEmail = $.trim($('#dEmail').val());
            if (dEmail != '') {
                //                alert('抱歉，请输入E-mail！');
                //                $('#dEmail').focus();
                //                return;
                //            }
                //            
                reg = new RegExp(regexEnum.email);
                cfr = reg.test(dEmail);
                if (!cfr) {
                    alert('抱歉，请输入正确的E-mail！');
                    $('#dEmail').focus();
                    return;
                }
            }

            var dDuty = $.trim($('#dDuty  option:selected').text());
            var dQQWeiBo = $.trim($('#dQQWeiBo').val());
            //             var db = 'dBrandName=' + escape(dBrandName.toString()) + '&dFactoryName=' + escape(dFactoryName.toString()) + '&dShopName=' + escape(dShopName.toString()) + '&';
            //             db += 'dContact=' + escape(dContact.toString()) + '&dDuty=' + escape(dDuty.toString()) + '&dTel=' + dTel.toString() + '&dMobile=' + dMobile.toString() + '&dQQWeiBo=' + dQQWeiBo.toString() + '&';
            //             db += 'dEmail=' + dEmail.toString() + '&dCity=' + dCity + '&dDtype=' + dType.val() + '&dAreacode=' + dDistrict + '&ddAddress=' + dAddress + '&Action=ds&rnd=' + Math.random();

            var db = 'dBrandName=' + escape(dBrandName.toString()) + '&';
            db += 'dContact=' + escape(dContact.toString()) + '&dDuty=' + escape(dDuty.toString()) + '&dTel=' + dTel.toString() + '&dMobile=' + dMobile.toString() + '&dQQWeiBo=' + dQQWeiBo.toString() + '&';
            db += 'dEmail=' + dEmail.toString() + '&dCity=' + dCity + '&dDtype=' + dType.val() + '&dAreacode=' + dDistrict + '&ddAddress=' + ddAddress + '&Action=ds&rnd=' + Math.random();
            //save db            
            SaveSettledDb(db);
            //alert(ddAddress);
        }

        //卖场入驻
        function MarketSettled() {
            var mMarkName = $.trim($('#mMarkName').val());
            if (mMarkName == '') {
                alert('抱歉，请输入集团名称！');
                $('#mMarkName').focus();
                return;
            }
            var stitle = $.trim($("#stitle").val());
            if (stitle == '') {
                alert('抱歉，请输入卖场名称！');
                $('#stitle').focus();
                return;
            }
            var ismMarketClique = 0;
            if ($("#mMarketClique").is(":checked")) {
                ismMarketClique = 1;
            }
            var mAddress = '';

            var mProvince = $.trim($('#<%=ddlMPro.ClientID %> option:selected').val());
            var mCity = $.trim($('#mCity option:selected').val());
            var mDistrict = $.trim($('#mDistrict option:selected').val());
            if (mProvince != '') {
                var mProvinceName = $.trim($('#<%=ddlMPro.ClientID %> option:selected').text());
               // mAddress += ' ' + mProvinceName;
            } else {
                alert('抱歉，请选择省份！');
                return;
            }
            if (mCity != '') {
                var mCityName = $.trim($('#mCity option:selected').text());
               // mAddress += ' ' + mCityName;
            } else {
                alert('抱歉，请选择城市！');
                return;
            }
            if (mDistrict != '') {
                var mDistrictName = $.trim($('#mDistrict option:selected').text());
               // mAddress += ' ' + mDistrictName;
            } else {
                alert('抱歉，请选择区或县！');
                return;
            }
            if ($.trim($('#mAddress').val()) != '') {
                mAddress = $.trim($('#mAddress').val());
            } else {
                alert('抱歉，请输入卖场地址！');
                $('#mAddress').focus();
                return;
            }
            var mContact = $.trim($('#mContact').val());
            if (mContact == '') {
                alert('抱歉，请输入联系人！');
                $('#mContact').focus();
                return;
            }
            var mTelCode = $.trim($('#mTelCode').val());
            var mTelPhone = $.trim($('#mTelPhone').val());
            var mTelEXT = $.trim($('#mTelEXT').val());
            var mTel = "";
            if (mTelCode != "" || mTelPhone != "") {
                mTel = mTelCode + "-" + mTelPhone;
            }

            var mMobile = $.trim($('#mMobile').val());
            if (mTel == '' && mMobile == '') {
                alert('抱歉，电话跟手机至少输入一处，请输入！');
                $('#mTel').focus();
                return;
            }

            var cfr = false;
            var reg = null;


            if (mMobile != '') {
                reg = new RegExp(regexEnum.mobile);
                cfr = reg.test(mMobile);
                if (!cfr) {
                    alert('抱歉，您输入正确的手机号码！');
                    $('#mMobile').focus();
                    return;
                }
            }
            if (mTel != "") {
                reg = new RegExp(regexEnum.tel);
                cfr = reg.test(mTel);
                if (!cfr) {
                    alert('抱歉，您输入正确的电话号码！');
                    $('#mTel').focus();
                    return;
                }
            }
            if (mTel != "" && new RegExp(regexEnum.num).test(mTelEXT)) {
                mTel = +mTel + "-" + mTelEXT
            }
            var mEmail = $.trim($('#mEmail').val());
            if (mEmail != '') {
                //                alert('抱歉，请输入E-mail！');
                //                $('#mEmail').focus();
                //                return;
                //            }
                reg = new RegExp(regexEnum.email);
                cfr = reg.test(mEmail);
                if (!cfr) {
                    alert('抱歉，请输入正确的E-mail！');
                    $('#mEmail').focus();
                    return;
                }
            }
            var mDuty = $.trim($('#mDuty  option:selected').text());
            
            var mQQWeiBo = $.trim($('#mQQWeiBo').val());
            var db = 'mMarkName=' + escape(mMarkName.toString()) + '&stitle=' + stitle + '&mAddress=' + escape(mAddress.toString()) + '&mContact=' + escape(mContact.toString()) + '&mDuty=' + escape(mDuty.toString()) + '&';
            db += 'mTel=' + mTel.toString() + '&mMobile=' + mMobile.toString() + '&mQQWeiBo=' + mQQWeiBo.toString() + '&mEmail=' + mEmail.toString() + '&';
            db += 'mProvince=' + mProvince.toString() + '&mCity=' + mCity.toString() + '&mDistrict=' + mDistrict.toString() + '&Action=ms&ismMarketClique=' + ismMarketClique + '&rnd=' + Math.random();
            //save db            
            SaveSettledDb(db);
            //alert(mAddress);
        }

        function clearDistrict(objId) {
            $('#' + objId.toString() + ' option:gt(0)').remove();
        }

        function loadCityDb(pcode, objId) {
            $('#' + objId.toString()).empty();
            if (pcode != '') {
                $('<option value="">加载数据中</option>').appendTo($('#' + objId.toString()));
                $.getJSON('../Ajax/AreaHandler.ashx?Action=area&pcode=' + pcode.toString() + '&rnd=' + Math.random(), function (data) {
                    $('#' + objId.toString()).empty();
                    $('<option value="">请选择</option>').appendTo($('#' + objId.toString()));
                    if (data != '') {
                        $.each(data, function (i) {
                            $('<option value="' + data[i].AreaCode + '">' + data[i].AreaName + '</option>').appendTo($('#' + objId.toString()));
                        });
                    }
                });
            } else {
                $('#' + objId.toString() + ' option:gt(0)').remove();
            }
        }
        var ctime = '0';
        function SaveSettledDb(db) {
            $('.btnl').attr('disabled', 'disabled');
            $('.btnl').val('保存数据中');
            ctime = '0';
            setTimeout("timelogin()", 9000);
            $.ajax({
                url: 'ajax/MemberHandler.ashx',
                dataType: 'text',
                data: db,
                success: function (data) {
                    ctime = '1';
                    if (data = 'Success') {
                       // alert('注册成功，恭喜您！请到会员中心完善您的资料和发布您的信息。如有问题，请及时联系我们的客服。');
                        location.href = 'index.aspx';
                    } else if (data == 'Fail') {
                        $('.btnl').removeAttr('disabled');
                        $('.btnl').val('提 交');
                        alert('抱歉，服务器正忙，请稍后提交驻入资料！');
                    }
                    else {
                        $('.btnl').removeAttr('disabled');
                        $('.btnl').val('提 交');
                        alert(data);
                    }
                }
            });
        }
        function timelogin() {
            if (ctime == '0') {
                location.href = 'index.aspx';
            }
        }
        //卖场省份
        $("#<%=ddlMPro.ClientID %>").live("change", function () {
            if ($(this).val() != "" && $(this).val() != "0") {
                $.ajax({
                    url: "<%=ECommon.WebSupplerUrl %>/ajaxtools/ajaxarea.ashx",
                    data: "type=c&p=" + $(this).val(),
                    success: function (data) {
                        $("#mCity").html(data)
                    },
                    error: function (d, m) {
                        alert(m);
                    }
                });
            }
        })

        //经销商省份
        $("#<%=ddlDpro.ClientID %>").live("change", function () {
            if ($(this).val() != "" && $(this).val() != "0") {
                $.ajax({
                    url: "<%=ECommon.WebSupplerUrl %>/ajaxtools/ajaxarea.ashx",
                    data: "type=c&p=" + $(this).val(),
                    success: function (data) {
                        $("#dCity").html(data)
                    },
                    error: function (d, m) {
                        alert(m);
                    }
                });
            }
        })
        //品牌厂商省份
        $("#<%=bfProvince.ClientID %>").live("change", function () {
            if ($(this).val() != "" && $(this).val() != "0") {
                $.ajax({
                    url: "<%=ECommon.WebSupplerUrl %>/ajaxtools/ajaxarea.ashx",
                    data: "type=c&p=" + $(this).val(),
                    success: function (data) {
                        $("#bfCity").html(data)
                    },
                    error: function (d, m) {
                        alert(m);
                    }
                });
            }
        })

        //p,c,d 省，市，县 typeid=p，c,d th=当前对象，typeid:加载数据类型，did当前对象类型，cid是要绑定对象的id
        function bindArea(th, typeid, did, cid) {
            //alert(th.value);
            //alert("type=" + typeid + "&" + did + "=" + $(th).val() + "&ram=" + Math.random());
            if ($(th).val() != "" && $(th).val() != "0") {
                $.ajax({
                    url: "<%=ECommon.WebSupplerUrl %>/ajaxtools/ajaxarea.ashx",
                    data: "type=" + typeid + "&" + did + "=" + $(th).val() + "&ram=" + Math.random(),
                    success: function (data) {
                        $("#" + cid).html(data)
                    },
                    error: function (d, m) {
                        alert(m);
                    }
                });
            }
        }


        function funmarketCheck() {
            var title = '';
            var mtitle = $.trim($("#mMarkName").val());
            var stitle = $.trim($("#stitle").val());
            if (mtitle == '') {
                return;
            }
            if (stitle == '') {
                return;
            }
            title = mtitle + stitle;
            $.ajax({
                async: false, //是否异步
                url: '/Suppler/ajax/MarketCheck.aspx?title=' + title + '&m=' + Math.random(),
                type: 'post', //post方法
                dataType: 'json', //返回json格式数据
                success: function (data) {

                    if (data.msg == "1") {
                        $("#divmarketmsg").html("卖场名称可以使用");
                    }
                    else if (data.msg == "0") {
                        $("#divmarketmsg").html("<span style='color:red;'>卖场名已存在，不可使用</span>");
                    }
                    else if (data.msg == "2") {
                        $("#divmarketmsg").html("卖场名称可以使用");
                        $("#mAddress").val(data.address);
                        $("#mDistrict").html(data.droparea3);
                        $("#mCity").html(data.droparea2);
                        $("#ddlMPro").val(data.droparea1);
                    }
                   
                }
            })
        }
       //-->
    </script>
</body>
</html>
