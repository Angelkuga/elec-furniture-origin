<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.company.MerchantsInfo" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/_headA.ascx" TagName="_headA" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="../ascx/_companynav.ascx" TagName="_companynav" TagPrefix="uc3" %>
<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>
<%@ Register Src="../ascx/_companyproduct.ascx" TagName="_companyproduct" TagPrefix="uc5" %>
<%@ Register Src="../ascx/_companykeys.ascx" TagName="_companykeys" TagPrefix="uc6" %>
<%@ Register Src="../ascx/_AreaSelect.ascx" TagName="AreaSelect" TagPrefix="my" %>
<%@ Register src="../ascx/_teladdress.ascx" tagname="_teladdress" tagprefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <uc6:_companykeys ID="_companykeys1" Title="-厂家品牌" runat="server" />
    <uc2:_resource ID="_resource1" runat="server" />
    <script type="text/javascript">
        myFocus.set({
            id: 'fjwcontainer', //焦点图盒子ID
            pattern: 'mF_taobao2010', //风格应用的名称
            path: '<%=ECommon.WebResourceUrl %>/script/pattern/',
            time: 6, //切换时间间隔(秒)
            trigger: 'mouseover', //触发切换模式:'click'(点击)/'mouseover'(悬停)
            width: 767, //设置图片区域宽度(像素)
            height: 331, //设置图片区域高度(像素)
            txtHeight: 0//文字层高度设置(像素),'default'为默认高度，0为隐藏
        });
    </script>
    <script type="text/javascript">
        $(function () {
            if ("<%=ECommon.QuerySearchBrand %>" == "") {
                $($("#brandNav li:first-child a")).addClass("brandjs1a")
            }
        })
    </script>
    <style>
        .zsmain
        {
            width: 992px;
            height: auto;
            margin: 10px auto;
        }
        .zsl
        {
            float: left;
            width: 760px;
        }
        .zslmain
        {
            border: 1px solid #ccc;
            margin: 10px 0;
            height: 100%;
        }
        .zslmain p
        {
            padding: 10px;
            text-align: center;
        }
        .zsform
        {
            margin-bottom: 55px;
            height: 100%;
        }
        .zsform ul
        {
            padding: 10px 0 0 50px;
            float: left;
        }
        .zsform li
        {
            padding-top: 5px;
        }
    </style>
</head>
<body>
    <uc1:_headA ID="_headA1" runat="server" />
    <uc3:_companynav ID="_companynav1" runat="server" />
    <div class="homebrandsc">
        <div class="topNav992">
            <div class="homebraLift">
                <div class="shopindex0">
                    <div class="Brand">
                        <div class="BrandLeft">
                            <p>
                                <span>品牌：</span><a target="_blank" href="<%=string.Format(EnUrls.CompanyInfoIndex, companyInfo.id) %>"><strong><%=currentBrand.title %></strong></a></p>
                            <p style="border-bottom: 1px dotted #C0C0C0;">
                                <span>厂商：</span><%=companyInfo != null ? companyInfo.title : "暂无" %>
                                &nbsp;&nbsp;&nbsp;<span>风格：</span><%=ECConfig.GetConfigInfoNew(" type=3 and value in(" + StyleString + ")")%></p>
                            <p>
                                <%=TRECommon.HTMLUtils.GetAllTextFromHTML(companyInfo.descript).Length > 76 ? TRECommon.HTMLUtils.GetAllTextFromHTML(companyInfo.descript).Substring(0, 76) + "..." : TRECommon.HTMLUtils.GetAllTextFromHTML(companyInfo.descript)%></p>
                        </div>
                        <div class="BrandRight" style="position: relative;">
                            <div style="height: 70px;">
                                <img alt="<%=currentBrand.title %>" src="<%=EnFilePath.GetBrandLogoPath(currentBrand.id, currentBrand.logo) %>"
                                    width="196" height="70" />
                            </div>
                            <div class="productView" style="display: block; margin-top: 3px; width: 197px; position: relative;
                                right: 0;">
                                <div class="br-gcs">
                                    <ul>
                                        <li style="margin-right: 2px;"><a href="<%=string.Format(EnUrls.CompanyInfoProduct, companyInfo.id) %>"
                                            class="btn">所有产品</a> </li>
                                        <li><a href="<%=string.Format(EnUrls.CompanyInfoAddress, companyInfo.id) %>" class="btn">
                                            所有店铺</a> </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%if (Model != null)
                  { %>
                <div class="homebraLi2" style="position: relative; overflow: visible; margin-top: 8px;">
                    <div class="zslmain">
                        <div style="border-bottom: 1px #ccc dotted; margin: 10px 5px; line-height: 30px;">
                            <h1 style="padding: 0 10px; color: #903; font: bold 22px/40px '微软雅黑'">
                                <%=Model.Title%>
                                <span style="float: right; color: #999; font-size: 12px;">
                                    <%=Model.Createtime%>
                                </span>
                            </h1>
                        </div>
                        <div style="padding-bottom: 45px;">
                            <%=Model.Descript%>
                        </div>
                    </div>
                    <div class="zslmain clearfix">
                        <div style="margin: 10px 5px; line-height: 30px; border-bottom: 1px #ccc dotted;">
                            <h1 style="padding: 0 10px; color: #903; font-weight: bold;">
                                如果您对该项目感兴趣，并希望得到详细资料，请立即留言！</h1>
                        </div>
                        <div class="zsform clearfix">
                            <input type="hidden" id="hid_val" value="postval" />
                            <ul>
                                <li>姓&nbsp;&nbsp;&nbsp;&nbsp;名：&nbsp;<input id="name" type="text" /><span style="color: #903">*</span></li>
                                <li>联系电话：&nbsp;<input id="phone" type="text" /><span style="color: #903">*</span></li>
                                <li>所在地区：<my:AreaSelect ID="txtarea" runat="server" />
                                    <span style="color: #903">*</span></li>
                            <li>留言内容：<br>
                                    <textarea cols="47" maxlength="100" id="descript" rows="8"></textarea></li>
                                <li style="text-align: right;">
                                    <input type="button" value="提交" onclick="subSave();" />
                                </li>
                                
                            </ul>
                            <script>
                                function subSave() {
                                    var n = $("#name").val();
                                    var h = $("#hid_val").val();
                                    var p = $("#phone").val();
                                    var c = $("#Selectedvalue").val().replace("$0", "");
                                    var d = $("#descript").val();
                                    d = escape(d);
                                    if (n == "" || p == "" || c == "") {
                                        alert('请填写信息！');
                                    }
                                    else {
//                                        var pattern = /(^[0-9]{3,4}\-[0-9]{3,8}$)|(^[0-9]{3,8}$)|(^\([0-9]{3,4}\)[0-9]{3,8}$)|(^0{0,1}13[0-9]{9}$)/;
//                                        if (p.search(/^(((13[0-9]{1})|(15[0-9]{1}))+\d{8})$/) != -1 || p.search(/^(([0\+]\d{2,3}-)?(0\d{2,3})-)?(\d{7,8})(-(\d{3,}))?$/) != -1) {
                                            var url = "<%=TREC.ECommerce.ECommon.WebUrl %>/company/<%=ECommon.QueryCid %>/MerchantsInfo-<%=ECommon.QueryMerchantid %>-" + h + "-" + n + "-" + p + "-" + c + "-" + d + ".aspx";
                                            window.location = url;
//                                        }
//                                        else {
//                                            alert('联系方式格式不正确！');
//                                        } 

                                       
                                    }
                                }
                            </script>
                        </div>
                    </div>
                    <%} %>
                </div>
            </div>
            <div class="homebraRight">
                <uc5:_companyproduct ID="_companyproduct1" runat="server" />
                <uc7:_teladdress ID="_teladdress1" runat="server" />
            </div>
        </div>
    </div>
    <uc4:_foot ID="_foot1" runat="server" />
</body>
</html>
