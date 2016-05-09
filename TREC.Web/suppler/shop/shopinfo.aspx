<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shopinfo.aspx.cs" MasterPageFile="../Member.Master"
    Inherits="TREC.Web.Suppler.shop.shopinfo" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Import Namespace="TREC.ECommerce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/DropDownListMenu.css" />
    <script type="text/javascript" src="../script/formValidator-4.1.1.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../script/formValidatorRegex.js" charset="UTF-8"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/')%>/script/ymPrompt.js"
        type="text/javascript"></script>
    <link href="../resource/css/ymPrompt/simple_gray/ymPrompt.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/fileupload.js"></script>
    <script type="text/javascript">
    $(function () {        
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('#<%=txtdescript.ClientID %>', {
                allowPreviewEmoticons: true,
                allowImageUpload: true,
                allowFileManager: true,
                <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                { %>
                    fileManagerJson:"<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/editor/kindeditor/ashx/file_manager_json.ashx?m=company&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                <%} %>
                allowMediaUpload: true,
                items: [
				    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
				    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
				    'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
            });
        });
    });
    </script>
    <style type="text/css">
        .w350
        {
            width: 350px;
        }
        .brandlist input
        {
            margin-right: 1px;
            margin-left: 8px;
        }
        .nortip
        {
            margin-left: 5px;
        }
        .tip
        {
            color: Red;
        }
        .navNew
        {
            position:relative;    
        }
      
.navNew{ position:relative;}
.navNew ul {line-height:27px;list-style-type:none;text-align:left;width:255px;position:absolute;height:300px;overflow-y:scroll;overflow-x:hidden;} 
.navNew ul li{float:left;width:255px;background:#ccc;} 
.navNew ul a{width:156px;text-align:left;padding-left:20px;} 
.navNew ul a:link{color:#666; text-decoration:none;} 
.navNew ul a:visited{color:#666;text-decoration:none;} 
.navNew ul a:hover{color:#F3F3F3;text-decoration:none;font-weight:normal;}
.navNew ul li.mychecked{background:#008CD4;}
.navNew ul li.mychecked a{color:#F3F3F3;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="IsAdd" runat="server" Value="search" />
    <div class="maintitle">
        <h1>
            <u>
                <%=myTitle %>店铺</u></h1>
    </div>
    <div class="maincon">
        <div class="maintabcor">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tr>
                    <td width="11%" height="35" align="right">
                        店铺名称
                    </td>
                    <td width="89%" style="text-align: left;">
                        <asp:TextBox ID="txttitle" runat="server" CssClass="input required w350"></asp:TextBox><span
                            class="nortip"><span class="tip">*</span>（例：全友家私红星美凯龙宝山汶水路店）</span>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        销售品牌<span id="brandClkLoad"></span>
                    </td>
                    <td class="brandlist" style="text-align: left;">
                        <span id="BrandItemList">
                            <%=BrandItem %></span> <a target="_blank" onclick="addBrandYmprompt()">
                                <img src="../Images/jiahao.jpg" align="absmiddle" width="16" height="16" border="0" />
                            </a><span class="tip">*</span><span class="nortip">（至少选择一个品牌）</span>
                    </td>
                </tr>
                
                <tr>
                    <td height="35" align="right">
                        归属卖场
                    </td>
                    <td style="text-align: left;">
                        <input type="radio" name="isMarket" value="1" <%if(SellerId!=0) {%>checked="checked"
                            <%} %> />&nbsp;是&nbsp;&nbsp;<input name="isMarket" type="radio" value="0" <%if(SellerId==0) {%>checked="checked"
                                <%} %> />&nbsp;否
                    </td>
                </tr>
                <%if (ispay)
                  { %>
                <tr id="cityid">
                    <td align="right" class="mtag">
                        <%if (SellerId != 0) { Response.Write("选择卖场"); } else { Response.Write("地址"); } %>
                    </td>
                    <td style="text-align: left;">
                       
                        <div  style="float:left;"  class="navNew">
                 <asp:DropDownList ID="ddlPro" runat="server" CssClass="select" Width="75">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlregcity" runat="server" CssClass="select selectNone" Width="75">
                </asp:DropDownList>
                <select name="ddlareacode_district"  id="ddlareacode_district" style="width:75px;">
                             <%=droparea%>
                            </select>


                            <input type="hidden"  value="<%=areaCode %>" name="ddlareacode_value" id="ddlareacode_value"/><span class="tip">*</span>
                </div>

                <div style="float:left;" id="addressid">
                    <div style="float:left;padding-left:3px;display:none;" class="maddress"> <%if (SellerId != 0) { Response.Write("地址"); } %></div>
                    <div style="float:left;padding-left:3px;">
                      <asp:TextBox ID="txtaddress" placeholder="请输入路名" runat="server" CssClass="input required" Style="width: 350px"></asp:TextBox><span class="tip">*</span>
                            <input type="hidden" value="<%=SellerId %>" name="marketId" id="marketId"  onchange="funPavilion()" onpropertychange="funPavilion()"/>
                    </div>
                    </div>
                    </td>
                </tr>
                <%}
                  else
                  { %>
                <tr  >
                    <td align="right" >
                       店铺地址：
                    </td>
                    <td style="text-align: left;color:#FF4864;">
                      您的会员权限不够，不能填写店铺地址，请<a href="/suppler/Payment/RegPayment.aspx">点击这里</a>进行充值。
                    </td>
                </tr>
                <%} %>
                <tr id="trPavilion" style="display:none;">
                <td height="35" align="right">
                场馆
                </td>
                <td style="text-align: left;">
                <select id="selPavilion" name="selPavilion">
                </select>
                </td>
                </tr>
            </table>
        </div>
        <div class="maintabcor bordtop">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="11%" height="35" align="right">
                        店铺电话
                    </td>
                    
                    <td width="32%" style="text-align: left;">
                        <asp:TextBox ID="txtphone" runat="server" CssClass="input w160" Width="192"></asp:TextBox><span
                            class="tip">*</span>
                    </td>

                    <td width="13%" align="right">
                        店铺传真
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="txtfax" runat="server" CssClass="input w160" Width="192"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        客服QQ
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="txtqq" runat="server" MaxLength="13" CssClass="input w160" Width="192"></asp:TextBox>
                    </td>
                    <td align="right">
                        其他联系方式
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="txtemail" runat="server" CssClass="input w160" Width="192"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div class="maintabcor bordtop bordbottom">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="11%" height="35" align="right">
                        店长
                    </td>
                    <td width="32%" style="text-align: left;">
                        <label>
                            <input name="ShopContact" type="text" size="26" value="<%=Contact %>" maxlength="20" /><span
                                class="tip">*</span>
                        </label>
                    </td>
                    <td width="13%" align="right">
                        手机
                    </td>
                    <td style="text-align: left;">
                        <input name="ShopContactMobile" id="ShopContactMobile" type="text" size="26" value="<%=ContactMobile %>"
                            maxlength="30" /><span class="tip">*</span>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        营业员1
                    </td>
                    <td style="text-align: left;">
                        <input name="FirstClerk" type="text" size="26" value="<%=FirstClerk %>" maxlength="20" />
                    </td>
                    <td align="right">
                        手机
                    </td>
                    <td style="text-align: left;">
                        <input name="FirstClerkMobile" id="FirstClerkMobile" type="text" size="26" value="<%=FirstClerkMobile %>"
                            maxlength="30" />
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        营业员2
                    </td>
                    <td style="text-align: left;">
                        <input name="SecondClerk" type="text" size="26" value="<%=SecondClerk %>" maxlength="20" />
                    </td>
                    <td align="right">
                        手机
                    </td>
                    <td style="text-align: left;">
                        <input name="SecondClerkMobile" id="SecondClerkMobile" type="text" size="26" value="<%=SecondClerkMobile %>"
                            maxlength="30" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="maintabcor">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right" width="11%">
                        <img src="../Images/wenhao.jpg" alt="提示" width="16" height="16" align="absmiddle" />&nbsp;店铺外景
                    </td>
                    <td>
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Shop, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
                            <asp:HiddenField ID="hfthumb" runat="server" />
                            <div class="fileTools" style="width: auto;">
                                <input type="text" class="input w160 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File3" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div>
                        </div>
                        <div class="nortip" style="float: left;">
                            (尺寸：宽X高 550*400px)</div>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <img src="../Images/wenhao.jpg" alt="提示" width="16" height="16" align="absmiddle" />广告轮播图
                    </td>
                    <td>
                        <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Shop, ECommon.QueryId, TREC.Entity.EnFilePath.Banner)%>">
                            <asp:HiddenField ID="hfbannel" runat="server" />
                            <div class="fileTools" style="width: auto;">
                                <input type="text" class="input w160 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File4" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        店铺介绍<span class="tip">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea required" TextMode="MultiLine"
                            Rows="5" Width="600" Height="200"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="right">
                        排序：
                    </td>
                    <td>
                        <asp:TextBox ID="txtsort" runat="server" CssClass="input w160 required digits">0</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: left;">
                        <br />
                        <div class="guishudp">
                            <input name="IsShare" type="checkbox" <%if(isshopshare==1){%>checked<%} %> value="1" />
                            启用店铺资源共享功能（推荐）
                            <br />
                            <span class="nortip">（启用的情况下，该品牌的其他店铺可以看到产品的内容，并可以复制使用产品。不启用的情况下，只有客户和店铺管理人员可以查看产品信息）</span>
                            <div class="clear">
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="btnone">
                            <asp:Button ID="btnSave" runat="server" Text="提 交" CssClass="btnl" OnClientClick="return chkShopForm();"
                                OnClick="btnSave_Click" />
                            <input name="myresetbt" type="reset" class="btnr" value="重 填" /></div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            //        $('#ddlareacode_province').change(function () {          
            //            loadDdlMarket();
            //        });

            //        $('#ddlareacode_city').change(function () {
            //            loadDdlMarket();
            //        });

            $('#ddlareacode_district').change(function () {
               // loadDdlMarket();
            });

            //iframe子窗口品牌添加后调用这个重载品牌数据
            $("#brandClkLoad").click(function () {
                loadTheBrands();
            });
        });

        if (0 < $('.brandlist input').size()) {
            $('.brandlist input:eq(0)').css('margin-left', '0px');
        }

        function loadAddress(address, marketId) {
            $('#<%=txtaddress.ClientID %>').val(address);
            $('input[name=marketId]').val(marketId);
            funPavilion();
            $('.navNew ul').remove();
        }

        function loadDdlMarket() {
            if ($('input[name=isMarket]:checked').val() == "1") {

                var pcode = $('#ctl00_ContentPlaceHolder1_ddlPro').val();
                var ccode = $('#ctl00_ContentPlaceHolder1_ddlregcity').val();
                var dcode = $('#ddlareacode_district').val();

                if (pcode != '' || ccode != '' || dcode != '') {
                    $.ajax({
                        url: '../ajax/MemberHandler.ashx',
                        dataType: 'text',
                        data: 'Action=market&pcode=' + pcode + '&ccode=' + ccode + '&dcode=' + dcode + '&rnd=' + Math.random(),
                        success: function (data) {
                            if (data != null && data != '') {

                                if ($('.navNew ul').size() == 0) {
                                    $('<ul></ul>').insertAfter($('#ddlareacode_district'));
                                }
                                $('.navNew ul').html(data);
                                var height = 0;
                                $('.navNew ul li').each(function () {
                                    height = height + $(this).height();
                                });
                                if (height < 300) {
                                    $('.navNew ul').css('overflow', 'hidden');
                                } else {
                                    $('.navNew ul').css({ 'overflow-y': 'scroll', 'overflow-x': 'hidden' });
                                }
                                //归属卖场
                                var SellerName = '<%=SellerName %>';
                                if (SellerName.toString() != '') {
                                    SelctedMarket(SellerName);
                                }
                                menuHover();
                            } else {
                                if (0 < $('.navNew ul').size()) {
                                    $('.navNew ul').remove();
                                }
                            }
                        }
                    });
                }

            }

        }

        function menuHover() {
            $('.navNew ul li').hover(function () { $(this).addClass('mychecked'); }, function () { $(this).removeClass('mychecked'); });
        }

        function SelctedMarket(SellerName) {
            $('.navNew li a').each(function () {
                if ($(this).html().toString() == SellerName) {
                    $(this).parent().addClass('mychecked');
                    return false;
                }
            });
        }

        $('input[name=isMarket]').click(function () {
            $('input[name=marketId]').val($(this).val().toString());
            if ($(this).val().toString() == '0') {
                $('.mtag').html('地址');
                $('.maddress').html('');
                if (0 < $('.navNew ul').size()) {
                    $('.navNew ul').remove();
                }
            } else {
                $('.mtag').html('选择卖场');
                $('.maddress').html('地址');
                // loadDdlMarket();
            }
        });

        function chkShopForm() {
            var ShopName = $.trim($('#<%=txttitle.ClientID %>').val());
            if (ShopName == '') {
                alert('抱歉，请输入店铺名称！');
                $('#<%=txttitle.ClientID %>').focus();
                return false;
            }
            var quantity = $('input[name=brand]:checked').size();
            if (quantity == 0) {
                alert('抱歉，请选择品牌！');
                return false;
            }
            if (10 < quantity) {
                alert('抱歉，您选择的品牌不能超过10个！');
                return false;
            }
            if($("#ddlareacode_district").val()==''||$("#ddlareacode_district").val()=='0')
            {
              alert('抱歉，请选择地区！');
                return false;
            }
            var ShopAddess = $.trim($('#<%=txtaddress.ClientID %>').val());
            if (ShopAddess == '') {
                alert('抱歉，请输入店铺地址！');
                $('#<%=txtaddress.ClientID %>').focus();
                return false;
            }
            var reg = null;
            var ShopTelphone = $.trim($('#<%=txtphone.ClientID %>').val());
            if (ShopTelphone == '') {
                alert('抱歉，请输入店铺电话！');
                $('#<%=txtphone.ClientID %>').focus();
                return false;
            } else {
                reg = new RegExp(regexEnum.tel);
                if (!reg.test(ShopTelphone.toString())) {
                    alert('抱歉，您输入的店铺电话有误！');
                    $('#<%=txtphone.ClientID %>').focus();
                    return false;
                }
            }
            var ShopFax = $.trim($('#<%=txtfax.ClientID %>').val());
            if (ShopFax != '') {
                reg = new RegExp(regexEnum.tel);
                if (!reg.test(ShopFax.toString())) {
                    alert('抱歉，您输入的店铺传真有误！');
                    $('#<%=txtfax.ClientID %>').focus();
                    return false;
                }
            }

            var ShopContact = $.trim($('input[name=ShopContact]').val());
            if (ShopContact == '') {
                alert('抱歉，请输入店长！');
                $('input[name=ShopContact]').focus();
                return false;
            }

            var ShopContactMobile = $.trim($('input[name=ShopContactMobile]').val());
            if (ShopContactMobile == '') {
                alert('抱歉，请输入店长手机！');
                $('input[name=ShopContactMobile]').focus();
                return false;
            } else {
                reg = new RegExp(regexEnum.mobile);
                if (!reg.test(ShopContactMobile.toString())) {
                    alert('抱歉，输入的店长手机有误！');
                    $('input[name=ShopContactMobile]').focus();
                    return false;
                }
            }
            //营业员1手机
            var FirstClerkMobile = $.trim($('input[name=FirstClerkMobile]').val());
            if (FirstClerkMobile != '') {
                reg = new RegExp(regexEnum.mobile);
                if (!reg.test(FirstClerkMobile.toString())) {
                    alert('抱歉，输入的营业员1手机有误！');
                    $('input[name=FirstClerkMobile]').focus();
                    return false;
                }
            }

            //营业员2手机
            var SecondClerkMobile = $.trim($('input[name=SecondClerkMobile]').val());
            if (SecondClerkMobile != '') {
                reg = new RegExp(regexEnum.mobile);
                if (!reg.test(SecondClerkMobile.toString())) {
                    alert('抱歉，输入的营业员2手机有误！');
                    $('input[name=SecondClerkMobile]').focus();
                    return false;
                }
            }

            //店铺介绍
            var descript = $.trim($(document.getElementsByTagName('iframe')[0].contentWindow.document.body).html());
            if (descript.toString() == '' || descript == '<br>') {
                alert('抱歉，请输入店铺介绍！');
                return false;
            } else {
                $('#<%=txtdescript.ClientID %>').val(descript);
            }

            return true;
        }

        function SelectSaleBrand(brandId) {
            $('.brandlist input').each(function () {
                if (-1 < brandId.indexOf(',' + $(this).val() + ',')) {
                    $(this).attr('checked', true);
                }
            });
        }

        //加载ajax品牌
        function loadTheBrands() {
            $.ajax({
                url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                data: 'type=getthebrand&v=<%=companyid %>&ram=' + Math.random(),
                dataType: 'json',
                async: false,
                success: function (data) {
                    $("#BrandItemList").empty();
                    $.each(data, function (i) {
                        if (data[i].id != "" && data[i].title != "") {
                            $("#BrandItemList").append("<label><input name=\"brand\" type=\"checkbox\" value=\"" + data[i].id + "\" />\r\n" + data[i].title + "</label>");
                        }
                    });
                }
            });
        }
        //添加品牌 弹出iframe
        function addBrandYmprompt() {
            //ymPrompt.win({ message: "/suppler/brand/addBrandYM.aspx?time=" + (new Date()).getTime(), width: 500, height: 600, title: '添加品牌',
            ymPrompt.win({ message: "/suppler/brand/addBrandYM.aspx", width: 600, height: 530, title: '添加品牌', handler: function () { }, iframe: true });
        }
        //场馆
        function funPavilion() {
            var marketid = $("#marketId").val();
            if (marketid != '' && marketid != '0') {
                $("#trPavilion").show();
                $("#selPavilion").load("../ajax/PavilionData.aspx?marketid=" + marketid + "&selectid=<%=selPavilionId %>");
            }
            
        }
        funPavilion();
    </script>

    
    <script language="javascript" type="text/javascript">
        $("#ctl00_ContentPlaceHolder1_ddlPro").live("change", function () {
            if ($(this).val() != "" && $(this).val() != "0") {
                $("#ctl00_ContentPlaceHolder1_ddlregcity").html("<option selected='selected' value='0'>--城市--</option>");
                $.ajax({
                    url: "/ajaxtools/ajaxarea.ashx",
                    data: "type=c&p=" + $(this).val(),
                    success: function (data) {
                        $("#ctl00_ContentPlaceHolder1_ddlregcity").html(data);
                        $("#ddlareacode_district").html("<option selected='selected' value='0'>--区--</option>");
                    },
                    error: function (d, m) {
                        alert(m);
                    }
                });
            }
        })

        $("#ctl00_ContentPlaceHolder1_ddlregcity").live("change", function () {
            if ($(this).val() != "" && $(this).val() != "0") {
                $("#ddlareacode_district").html("<option selected='selected' value='0'>--区--</option>");
                $.ajax({
                    url: "/ajaxtools/ajaxarea.ashx",
                    data: "type=c&p=" + $(this).val(),
                    success: function (data) {
                        $("#ddlareacode_district").html(data);
                    },
                    error: function (d, m) {
                        alert(m);
                    }
                });
            }
        })


        $("#ddlareacode_district").live("change", function () {
            if ($(this).val() != "" && $(this).val() != "0") {
                $("#ddlareacode_value").val($(this).val());
                loadDdlMarket();
            }
        })

        
        function getArea(pcode, checkcode, title, id) {
            $.get("/ajax/GetArea.aspx?pcode=" + pcode + "&checkcode=" + checkcode, '', function (data, textStatus) {
                $("#" + id).html(title + data);
            }, null);
        }

        function selPArea() {
            var pid = $("#ctl00_ContentPlaceHolder1_ddlregcity").val();
            if (pid != '') {
                getArea(pid, '', '', 'ddlareacode_district');
            }
            else {
                $("#ddlareacode_district").html("<option selected=\"selected\" value=\"0\">--区--</option>")
            }
        }

    </script>


</asp:Content>
