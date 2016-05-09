<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true"
    CodeBehind="issuegroupproduct.aspx.cs" Inherits="TREC.Web.Suppler.product.issuegroupproduct" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/fileupload.js"></script>
    <script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/')%>/script/ymPrompt.js" type="text/javascript"></script>
    <link href="../resource/css/ymPrompt/simple_gray/ymPrompt.css" rel="stylesheet" type="text/css" />
    <script src="../script/myPublic.js" type="text/javascript"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript">
    $(function () {        
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('#<%=txtdescript.ClientID %>', {
                allowPreviewEmoticons: true,
                allowImageUpload: true,
                allowFileManager: true,
                <%if (Request["gpId"] != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                { %>
                    fileManagerJson:"<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=company&id=<%=Request["gpId"] %>",
                <%} %>
                allowMediaUpload: true,
                items: [
					'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
					'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
					'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
            });
        });
    });
    
       //select all
        function chkboxAll(th,t_class) {        
            if ($("."+t_class).find("input[type=checkbox]:checked").length > 0) {
                $("."+t_class).find("input[type=checkbox]").attr('checked', false);
               // $(th).text("全选")
            } else {
                $("."+t_class).find("input[type=checkbox]").attr('checked', "checked");
               // $(th).text("取消")
            }
        }          
        
    </script>
    <style type="text/css">
        #MaterialId, #SeriesId
        {
            width: 72px;
        }
        .pages a
        {
            cursor: pointer;
        }
        .pop
        {
            position: absolute;
        }
        .guishudp input
        {
            margin-right: 10px;
        }
        #typeId, #MaterialId, #SeriesId
        {
            width: 72px;
        }
        .addcm
        {
            position: relative;
        }
        .wait
        {
            position: absolute;
            z-index: 100;
            background: #ccc;
            width: 94%;
            top: 0;
            height: 246px;
            line-height: 246px;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            opacity: 0.8;
            color: #000;
            font-size: 14px;
        }
        #copyproductdiv
        {
            width: 450px;
        }
        #copyproductdiv .popcon
        {
            width: 410px;
        }
        #copyproductdiv td
        {
            font-size: 13px;
            padding-left: 0;
        }
        .tip
        {
            color: Red;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maintitle">
        <h1>
            <u>添加套组合</u></h1>
    </div>
    <div class="maincon">
        <div class="maintabcor">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="35" align="right">
                        组合编号
                    </td>
                    <td colspan="7" style="text-align: left;">
                        <input name="groupProductNo" id="groupProductNo" type="text" value="<%=productNo %>"
                            maxlength="100" size="34" /><span class="tip">*</span>
                        <input type="button" class="btnadd btncopy" onclick="CopyGroupProduct()" value="复制同类产品" />
                        <span class="nortip">（输入单品编号或者关键字，可以调出对应的产品数据）</span>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        组合名称
                    </td>
                    <td colspan="3" style="text-align: left;">
                        <input name="groupProductName" value="<%=gpName %>" maxlength="100" type="text" size="34" /><span
                            class="tip">*</span>
                    </td>
                    <td height="35" align="right">
                        
                    </td>
                    <td colspan="3" style="text-align: left;">
                        
                    </td>
                </tr>
                <tr>
                    <td width="10%" height="35" align="right">
                        品牌<span id="brandClkLoad"></span>
                    </td>
                    <td width="100" style="text-align: left;">
                        <asp:DropDownList ID="ddlbrand" runat="server" CssClass="select" Width="85">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlspread" runat="server" Style="display: none;">
                        </asp:DropDownList>
                        <a target="_blank" onclick="addBrandYmprompt()">
                            <img width="16" height="16" border="0" alt="添加" src="../Images/jiahao.jpg"></a>
                        <span class="tip">*</span>
                    </td>
                    <td width="8%" align="right">
                        大类
                    </td>
                    <td width="17%" style="text-align: left;">
                        <asp:DropDownList ID="ddlBigCategory" runat="server" CssClass="select" Width="80">
                        </asp:DropDownList>
                        <span class="tip">*</span>
                    </td>
                    <td width="10%" align="right">
                        风格
                    </td>
                    <td width="15%" style="text-align: left;">
                        <asp:DropDownList ID="ddlstyle" runat="server" CssClass="select" Width="85">
                        </asp:DropDownList>
                    </td>
                    <td width="8%" align="right">
                        材质
                    </td>
                    <td width="17%" style="text-align: left;">
                        <asp:DropDownList ID="ddlmaterial" runat="server" CssClass="select" Width="85">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        系列
                    </td>
                    <td style="text-align: left;">
                        <asp:DropDownList ID="SeriesId" runat="server" CssClass="select" Width="85">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="hiddBrands" runat="server" />
                        <asp:HiddenField ID="hiddBrandsName" runat="server" />
                        <%--   <select id="SeriesId" name="SeriesId">
        <option value="">请选择</option>
        <asp:Repeater ID="RptSeries" runat="server">
           <ItemTemplate><option value="<%#Eval("SeriesId")%>"><%#Eval("SeriesName")%></option></ItemTemplate>
        </asp:Repeater>
      </select>--%>
                    </td>
                    <td align="right">
                        小类
                    </td>
                    <td style="text-align: left;">
                        <asp:DropDownList ID="smallCateId" runat="server" CssClass="select" Width="85">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="hiddSmallCate" runat="server" />
                        <asp:HiddenField ID="hiddSmallName" runat="server" />
                        <%--  <select id="smallCateId" name="smallCateId">
        <option value="">请选择</option></select>--%>
                    </td>
                    <td align="right">
                        是否组装
                    </td>
                    <td style="text-align: left;">
                        <input type="radio" name="IsGroup" value="1" <% if(isGroup==1){%> checked="checked"
                            <%} %> />&nbsp;是&nbsp;&nbsp;<input name="IsGroup" <% if(isGroup==0){%> checked="checked"
                                <%} %> type="radio" value="0" />&nbsp;否
                    </td>
                    <td align="right">
                        色系
                    </td>
                    <td style="text-align: left;">
                        <asp:DropDownList ID="ddlcolor" runat="server" CssClass="select" Width="80">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        单品编号
                    </td>
                    <td colspan="4" style="text-align: left;">
                        <input name="productNo" id="productNo" maxlength="100" type="text" size="30" />
                    </td>
                    <td colspan="3">
                        <div class="choicedp bordtop" style="text-align: left;">
                            <span>搜索单品</span>
                            <input type="button" class="btnlitl" onclick="searchProduct(1)" value="搜索" />
                            <input type="hidden" name="singleproduct" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="selectProdect" class="msgtableSelect" style="margin-top: 0; display: none;">
            已加入单品&nbsp; <a class="bome" onclick="delSeleProID()">删除</a>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <th width="50" align="center">
                        <a onclick="chkboxAll(this,'msgtableSelect');">选择</a>
                    </th>
                    <th width="50" align="center">
                        编号
                    </th>
                    <th align="center" width="100">
                        分类名称
                    </th>
                    <th align="center" width="120">
                        图片
                    </th>
                    <th align="center" width="230" class="l">
                        名称
                    </th>
                    <th align="center" width="100">
                        尺寸
                    </th>
                    <th align="center" width="50">
                        状态
                    </th>
                    <th align="center" width="50">
                        上/下线
                    </th>
                </tr>
            </table>
        </div>
        <div class="msgtable" style="margin-top: 0;">
            搜索的单品
            <table width="100%" border="0" id="productlist" cellspacing="0" cellpadding="0">
                <tr>
                    <th width="50" align="center">
                        <a onclick="chkboxAll(this,'msgtable');">选择</a>
                    </th>
                    <th width="50" align="center">
                        编号
                    </th>
                    <th align="center" width="100">
                        分类名称
                    </th>
                    <th align="center" width="120">
                        图片
                    </th>
                    <th align="center" width="230" class="l">
                        名称
                    </th>
                    <th align="center" width="100">
                        尺寸
                    </th>
                    <th align="center" width="50">
                        状态
                    </th>
                    <th align="center" width="50">
                        上/下线
                    </th>
                </tr>
            </table>
            <a class="bome" onclick="addSeleProID()">添加</a>
            <asp:HiddenField ID="hiddSingProductID" runat="server" />
        </div>
    </div>
    <div class="maintabcor bordtop bordbottom">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="35" width="12%" align="right">
                    套餐价
                </td>
                <td width="88%" style="text-align: left;">
                    <input name="groupPrice" id="groupPrice" value="<%=price %>" type="text" maxlength="8"
                        size="20" /><span class="tip">*</span> 
                    促销价 <input name="promotionPrice" id="promotionPrice" value="<%=price %>" type="text" maxlength="8"
                        size="20" /> 
                    参加活动 <asp:DropDownList ID="ddlGroupProductPromotion" runat="server" CssClass="select">
                        </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <div class="maintabcor">
        <asp:HiddenField ID="hflogo" runat="server" />
        <asp:HiddenField ID="hfdesimage" runat="server" />
        <asp:HiddenField ID="hiddgpid" runat="server" />
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="12%" height="35" align="right">
                    <img src="../Images/wenhao.jpg" align="absmiddle" width="16" height="16" align="middle" />&nbsp;整体图
                </td>
                <td width="88%" style="text-align: left;">
                    <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Product, Request["gpId"], TREC.Entity.EnFilePath.Thumb)%>">
                        <asp:HiddenField ID="hfthumb" runat="server" />
                        <div class="fileTools" style="width: 310px">
                            <input type="text" class="input w160 filedisplay" id="thumb" />
                            <a href="javascript:;" class="files">
                                <input id="File3" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                            <span class="uploading">上传中</span>
                        </div>
                        <label>
                            (请上传一张本产品的外观图，尺寸：宽550 * 高410像素)</label>
                    </div>
                </td>
            </tr>
            <tr>
                <td height="35" align="right">
                    <img src="../Images/wenhao.jpg" align="absmiddle" width="16" height="16" align="middle" />&nbsp;局部图
                </td>
                <td style="text-align: left;">
                    <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Product, Request["gpId"], TREC.Entity.EnFilePath.Banner)%>">
                        <asp:HiddenField ID="hfbannel" runat="server" />
                        <div class="fileTools" style="width: 310px">
                            <input type="text" id="bannel" class="input w160 filedisplay" />
                            <a href="javascript:;" class="files">
                                <input id="File5" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                            <span class="uploading">上传中</span>
                        </div>
                        <label>
                            (请上传多张本产品的细节图，尺寸：宽不超过750像素)</label>
                    </div>
                </td>
            </tr>
            <tr>
                <td height="133" align="right" valign="top">
                    产品描述<span class="tip">*</span>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea required" TextMode="MultiLine"
                        Rows="5" Width="600" Height="200"></asp:TextBox>
                    <%--<uc2:SimpleEdit ID="SimpleEdit1" runat="server" />--%>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left;">
                    <%if (!string.IsNullOrEmpty(shopStr))
                      {%>
                    <div class="guishudp" style="padding-top: 10px;">
                        你是否同时要把此产品归属到以下店铺？<ul>
                            <%=shopStr%></ul>
                        <%} %>
                        <div class="clear">
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left;">
                    <div class="btnone">
                        <asp:Button ID="BtnSaveGroupProduct" CssClass="btnl" runat="server" Text="提 交" OnClientClick="return chkGroupProductForm(this);"
                            OnClick="BtnSaveGroupProduct_Click" /><input type="reset" value="重 填" class="btnr" /></div>
                    <input type="hidden" name="PropertyName" />
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript" src="../script/myPublic.js"></script>
    <script src="../script/formValidatorRegex.js" type="text/javascript"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/')%>/script/jquery.form.js"></script>
    <script type="text/javascript">
<!--
        $(function () {
            $(window).scroll(function () {
                if ($('.pop').size() != 0) {
                    $('.pop').css('top', ($(window).height() - $('.pop').height()) / 2 + $(document).scrollTop() + 'px');
                    $('.pop').css('left', ($(window).width() - $('.pop').width()) / 2 + 'px');
                }
            });
            //产品输入框点击事件
            //            $("#groupProductNo").click(function () {
            //                if (this.value == "亲，请先添加品牌，再添加产品") {
            //                    this.value = "";
            //                }
            //            });
            //            $("#groupProductNo").blur(function () {
            //                if (this.value == "") {
            //                    this.value = "亲，请先添加品牌，再添加产品";
            //                }
            //            });
            //iframe子窗口品牌添加后调用这个重载品牌数据
            $("#brandClkLoad").click(function () {
                loadTheBrands();
            });
            //brand change click
            $("#<%=ddlbrand.ClientID %>").change(function () {
                if (this.value != "") {
                    $.ajax({
                        url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                        data: 'type=getbrands&v=' + this.value + "&ram=" + Math.random(),
                        dataType: 'json',
                        success: function (data) {
                            $("#<%=SeriesId.ClientID %>").html("").hide().show();
                            $("#<%=SeriesId.ClientID %>").append("<option value=\"\">请选择</option>");
                            $.each(data, function (i) {
                                if (data[i].id != "" && data[i].title != "") {
                                    $("#<%=SeriesId.ClientID %>").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                                }
                            });
                        }
                    });
                    searchProduct(1);
                }

            });

            $("#<%=SeriesId.ClientID %>").change(function () {

                if (this.value != "") {
                    $('#<%=hiddBrands.ClientID %>').val(this.value);
                    $('#<%=hiddBrandsName.ClientID %>').val($("#<%=SeriesId.ClientID %>  option:selected").text());
                    //加载系列相关的风格，色系和材质
                    $.ajax({
                        url: '../ajax/MemberHandler.ashx',
                        data: 'Action=getbrandsmodel&brandsid=' + this.value + "&ram=" + Math.random(),
                        dataType: 'html',
                        success: function (data) {
                            var json = eval("(" + data + ")");
                            $('#<%=ddlstyle .ClientID %>').val(json.style);
                            $('#<%=ddlmaterial .ClientID %>').val(json.material);
                            $('#<%=ddlcolor .ClientID %>').val(json.color);

                        }
                    });
                } else {
                    $("#<%=hiddBrands.ClientID %>").val(0);
                }
            });
            $("#<%=smallCateId.ClientID %>").change(function () {
                if (this.value != "") {
                    $("#<%=hiddSmallCate.ClientID %>").val(this.value);
                    $('#<%=hiddSmallName.ClientID %>').val($("#<%=smallCateId.ClientID %>  option:selected").text());
                } else {
                    $("#<%=hiddSmallCate.ClientID %>").val(0);
                }
            });
            //big categroy change click
            $('#<%=ddlBigCategory.ClientID %>').change(function () {
                if (this.value != "") {
                    $.ajax({
                        url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                        data: 'type=getsmallcatagory&v=' + this.value + "&ram=" + Math.random(),
                        dataType: 'json',
                        success: function (data) {
                            $("#<%=smallCateId.ClientID %>").html("").hide().show();
                            $("#<%=smallCateId.ClientID %>").append("<option value=\"\">请选择</option>");
                            $.each(data, function (i) {
                                if (data[i].id != "" && data[i].title != "") {
                                    $("#<%=smallCateId.ClientID %>").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                                }
                            });
                        }
                    });
                    searchProduct(1);
                }

            });
            var brandsId = '<%=brandsId %>';
            var smallCateId = '<%=smallCategoryId %>';
            var brandId = $.trim($('#<%=ddlbrand.ClientID %> option:selected').val());
            var bigCateId = $.trim($('#<%=ddlBigCategory.ClientID %> option:selected').val());
            //绑定系列

            if (brandsId != 0 && brandId != "") {
                $.ajax({
                    url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                    data: 'type=getbrands&v=' + brandId + "&ram=" + Math.random(),
                    dataType: 'json',
                    success: function (data) {
                        $("#<%=SeriesId.ClientID %>").html("").hide().show();
                        $("#<%=SeriesId.ClientID %>").append("<option value=\"\">请选择</option>");
                        $.each(data, function (i) {
                            if (data[i].id != "" && data[i].title != "") {
                                $("#<%=SeriesId.ClientID %>").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                            }
                        });
                        $("#<%=SeriesId.ClientID %>").val(brandsId);
                    }
                });
            }

            if (smallCateId != 0 && bigCateId != "") {
                $.ajax({
                    url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                    data: 'type=getsmallcatagory&v=' + bigCateId + "&ram=" + Math.random(),
                    dataType: 'json',
                    success: function (data) {
                        $("#<%=smallCateId.ClientID %>").html("").hide().show();
                        $("#<%=smallCateId.ClientID %>").append("<option value=\"\">请选择</option>");
                        $.each(data, function (i) {
                            if (data[i].id != "" && data[i].title != "") {
                                $("#<%=smallCateId.ClientID %>").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                            }
                        });
                        $("#<%=smallCateId.ClientID %>").val(smallCateId);
                    }
                });

            }


            //加载单品数据
            var gpId = '<%=gpId %>';
            //加载单品数据

            if (gpId != "" && gpId != 0) {
                loadEditProduct(gpId.toString());
            } else {
                //searchProduct(1);
            }


            // LoadEditorGroupDb(gpId.toString());
            // LoadSingleProductDb(gpId.toString());      


        });


        //获得店铺数据
        function ProductBelongShop() {
            $.get('../MemberAjax/ProductHandler.ashx', { Action: 'copyshop' }, function (data) {
                if (data != null) {
                    if (data.toString() == '') {
                        $('.guishudp').remove();
                    } else {
                        $('.guishudp ul').html(data);
                    }
                }
            });
        }
        //保存已选择的单品
        function addSeleProID() {
            if ($(".msgtable").find("input[type=checkbox]:checked").length == 0) {
                alert("请选择单品");
                return;
                //  $(".msgtable").find("input[type=checkbox]").attr('checked', false);
                //  $(th).text("全选")
            } else {
                var hiddValue = $("#<%=hiddSingProductID.ClientID %>");
                var checked = [];
                var selectPro = "";
                //            for (var i = 0; i < checked.length; i++) {
                //                alert("隐藏的值"+hiddValue.val());
                //                alert("选择的"+i+checked[i]);
                //                alert(hiddValue.val().indexOf(checked[i]) >=0);
                //                if (hiddValue.val().indexOf(checked[i]) >=0) {
                //                    selectPro += "," + checked[i];
                //                }
                //            }


                $(".msgtable").find("input[type=checkbox]:checked").each(function () {
                    checked.push($(this).val());
                    if (hiddValue.val().indexOf($(this).val()) >= 0) {
                        if (selectPro == "") {
                            selectPro = $(this).parent().next().text();
                        } else {
                            selectPro += "," + $(this).parent().next().text();
                        }

                    } else {
                        $("<tr>" + $(this).parent().parent().html() + "</tr>").insertAfter($('#selectProdect tr:eq(0)'));
                    }

                });

                if (selectPro != "") {
                    alert("编号为" + selectPro + "单品已经加入，请重新选择");
                    $('.msgtable tr:gt(0)').remove();
                    return;
                }

                if (hiddValue.val() != "") {
                    hiddValue.val(hiddValue.val() + "," + checked);
                } else {
                    hiddValue.val(checked);
                }
                //显示已添加单品
                $("#selectProdect").show("slow");
                //取消选中的单品
                $(".msgtable").find("input[type=checkbox]:checked").attr('checked', false);
                $('.msgtable tr:gt(0)').remove();
                var mysize = $('.msgtable .pages').size();
                if (mysize == 1) {
                    $('.msgtable .pages').remove();
                }
                alert("添加成功");
            }
        }

        //删除已选择单品
        function delSeleProID() {
            if ($("#selectProdect").find("input[type=checkbox]:checked").length == 0) {
                alert("请选择单品");
                return;
            } else {
                var hiddValue = $("#<%=hiddSingProductID.ClientID %>");
                var nhiddValue = "";
                $("#selectProdect").find("input[type=checkbox]:checked").each(function () {
                    //nhiddValue = hiddValue.val().replace($(this).val(), "");
                    if (hiddValue.val().split(',').length > 0) {
                        if (hiddValue.val().indexOf($(this).val() + ",") >= 0) {
                            nhiddValue = hiddValue.val().replace($(this).val() + ",", "");
                        } else {
                            nhiddValue = hiddValue.val().replace("," + $(this).val(), "");
                        }
                    } else {
                        nhiddValue = hiddValue.val().replace($(this).val(), "");
                    }
                    $($(this).parent().parent()).remove();
                });
                hiddValue.val(nhiddValue);
                var mySize = $('#selectProdect tr').size();
                if (mySize <= 1) {
                    $("#<%=hiddSingProductID.ClientID %>").val("");
                    $("#selectProdect").hide("slow");
                }
            }
        }
        function clearSingleProductValue() {
            $('input[name=singleproduct]').val('');
        }
        //搜索单品
        function searchProduct(Page) {
            var gpId = '<%=gpId %>';
            if (gpId == 0) {
                gpId = "";
            }
            var productNo = $("#productNo").val();
            $('.msgtable tr:gt(0)').remove();
            $('<tr><td colspan="8" style="color:#999;text-align:center;line-height:40px;height:40px;">正在读取数据中...</td></tr>').insertAfter($('.msgtable tr:eq(0)'));
            $('.msgtable .pages').html('');
            var brandId = $.trim($('#<%=ddlbrand.ClientID %> option:selected').val());
            var bigCateId = $.trim($('#<%=ddlBigCategory.ClientID %> option:selected').val());
            var styleId = $.trim($('#<%=ddlstyle.ClientID %> option:selected').val());
            var MaterialId = $.trim($('#<%=ddlmaterial.ClientID %> option:selected').val());
            var SeriesId = $.trim($('#<%=SeriesId.ClientID %> option:selected').val());
            var smallCateId = $.trim($('#<%=smallCateId.ClientID %> option:selected').val());
            var IsGroup = $('input[name=IsGroup]:checked').val();
            if (IsGroup == undefined) {
                IsGroup = '';
            }
            var ColorId = $.trim($('#<%=ddlcolor.ClientID %> option:selected').val());
            $.get('../ajax/MemberHandler.ashx',
         { Action: 'searchgroupproduct', brandId: brandId.toString(), bigCateId: bigCateId.toString(), styleId: styleId.toString(), MaterialId: MaterialId.toString(), SeriesId: SeriesId.toString(), smallCateId: smallCateId.toString(), IsGroup: IsGroup.toString(), ColorId: ColorId.toString(), productNo: escape(productNo.toString()), Page: Page.toString(), gpId: gpId.toString(), ran: Math.random() },
         function (data) {
             if (data != null) {
                 if (data.toString() == 'no' || data.toString() == '$0') {
                     $('.msgtable tr:eq(1) td').html('抱歉，暂无找到您要的单品！');
                     var mysize = $('.msgtable .pages').size();
                     if (mysize == 1) {
                         $('.msgtable .pages').remove();
                     }

                 } else {
                     var phtml = data.toString().substring(0, data.toString().indexOf('$'));
                     $('.msgtable tr:eq(1)').remove();
                     $(phtml).insertAfter($('.msgtable tr:eq(0)'));
                     //页数
                     var totalpage = data.toString().substring(data.toString().lastIndexOf('$') + 1);
                     if (1 < parseInt(totalpage.toString(), 10)) {
                         singleProductPage(totalpage, Page);
                     }
                     //选中单品
                     // checkedSingleProduct();
                 }
             }
         });
        }

        //编辑是加载套组合信息
        function loadEditProduct(gpId) {
            $('.msgtableSelect tr:gt(0)').remove();
            $('<tr><td colspan="8" style="color:#999;text-align:center;line-height:40px;height:40px;">正在读取数据中...</td></tr>').insertAfter($('.msgtableSelect tr:eq(0)'));
            $.get('../ajax/MemberHandler.ashx',
         { Action: 'editgroupproduct', Page: "1", gpId: gpId.toString(), ran: Math.random() },
         function (data) {
             if (data != null) {
                 if (data.toString() == 'no' || data.toString() == '$0') {
                     $('.msgtableSelect tr:eq(1) td').html('抱歉，暂无找到您要的单品！');
                     var mysize = $('.msgtable .pages').size();
                     if (mysize == 1) {
                         $('.msgtableSelect .pages').remove();
                     }
                 } else {
                     var phtml = data.toString().substring(0, data.toString().indexOf('$'));
                     $('.msgtableSelect tr:eq(1)').remove();
                     $(phtml).insertAfter($('.msgtableSelect tr:eq(0)'));
                     //页数
                     //                     var totalpage = data.toString().substring(data.toString().lastIndexOf('$') + 1);
                     //                     if (1 < parseInt(totalpage.toString(), 10)) {
                     //                         singleProductPage(totalpage, Page);
                     //                     }
                     //显示已添加单品
                     $("#selectProdect").show();
                     //选中单品
                     // checkedSingleProduct();
                 }
             }
         });
        }
        //分页
        function singleProductPage(totalPage, currentPage) {
            var mysize = $('.msgtable .pages').size();
            if (mysize == 0) {
                $('<div class="pages"></div>').insertAfter($('#productlist'));
            }
            var epage = currentPage + 3;
            var spage = currentPage - 2;
            if (spage <= 0 || totalPage <= 5) {
                spage = 1;
            }
            if (totalPage < epage) {
                epage = totalPage;
            }
            var pagehtml = '';
            for (var i = spage; i <= epage; i++) {
                if (i == currentPage) {
                    pagehtml += '<span class="current">' + i + '</span>';
                } else {
                    pagehtml += '<a onclick="searchProduct(' + i + ');">' + i + '</a>';
                }
            }
            //上一页
            if (currentPage == 1) {
                pagehtml = '<span class="disabled"> &lt; </span>' + pagehtml;
            } else {
                pagehtml = '<a onclick="searchProduct(' + (currentPage - 1) + ');"> &lt; </a>' + pagehtml;
            }
            //下一页
            if (currentPage == totalPage) {
                pagehtml += '<span class="disabled"> &gt; </span>';
            } else {
                pagehtml += '<a onclick="searchProduct(' + (currentPage + 1) + ');"> &gt; </a>';
            }
            $('.msgtable .pages').html(pagehtml);
        }
        //    function LoadSingleProductDb(gpId) {
        //        $('<tr><td colspan="8" style="color:#999;text-align:center;line-height:40px;height:40px;">正在读取数据中...</td></tr>').insertAfter($('.msgtable tr:eq(0)'));
        //        $.get('../MemberAjax/ProductHandler.ashx', { Action: 'searchgroupproduct', gpId: gpId.toString() }, function (data) {
        //            if (data != null) {
        //                if (data.toString() == 'no') {
        //                    $('.msgtable tr:eq(1) td').html('抱歉，暂无找到您要的单品！');
        //                    var mysize = $('.msgtable .pages').size();
        //                    if (mysize == 1) {
        //                        $('.msgtable .pages').remove();
        //                    }
        //                } else {
        //                    var phtml = data.toString().substring(0, data.toString().indexOf('$'));
        //                    $('.msgtable tr:gt(0)').remove();
        //                    $(phtml).insertAfter($('.msgtable tr:eq(0)'));
        //                    //页数
        //                    var page = data.toString().substring(data.toString().lastIndexOf('$') + 1);
        //                    if (1 < parseInt(page.toString(), 10)) {
        //                        singleProductPage(page, 1);
        //                    }
        //                    //选中单品
        //                    checkedSingleProduct();
        //                }
        //            }
        //        });
        //    }


        //选中单品
        function checkedSingleProduct() {
            //var singleproduct = $('input[name=singleproduct]').val();
            //        if (singleproduct != '') {
            //            singleproduct = ',' + singleproduct + ',';
            //        }
            $('#productlist input').each(function () {
                //选中
                if (singleproduct != '') {
                    if (-1 < singleproduct.indexOf(',' + $(this).val() + ',')) {
                        $(this).attr('checked', true);
                    }
                }
                //单击事件
                $(this).click(function () {
                    singleproduct = $('input[name=singleproduct]').val();
                    if (singleproduct != '') {
                        singleproduct = ',' + singleproduct + ',';
                    }
                    if (this.checked) {
                        singleproduct = singleproduct.toString() + this.value.toString();
                    } else {
                        singleproduct = singleproduct.toString().replace(',' + this.value.toString() + ',', ',');
                    }
                    //去除前面一个“,”号          
                    if (singleproduct.toString().substring(0, 1) == ',') {
                        singleproduct = singleproduct.toString().substring(1, singleproduct.toString().length);
                    }
                    //去除最后一个“,”号
                    if (singleproduct.toString().substr(singleproduct.length - 1) == ',') {
                        singleproduct = singleproduct.toString().substring(0, singleproduct.toString().length - 1);
                    }
                    $('input[name=singleproduct]').val(singleproduct);
                });
            });
        }




        //验证组合产品表单
        function chkGroupProductForm(obj) {

            var groupProductNo = $.trim($('input[name=groupProductNo]').val());
            if (groupProductNo == '' || groupProductNo == "亲，请先添加品牌，再添加产品") {
                alert('请输入套组合产品编号！');
                $('input[name=groupProductNo]').select();
                return false;
            }

            var groupProductName = $.trim($('input[name=groupProductName]').val());
            if (groupProductName == '') {
                alert('请输入套组合产品名称！');
                $('input[name=groupProductName]').focus();
                return false;
            }
            var brandId = $.trim($('#<%=ddlbrand.ClientID %> option:selected').val());
            if (brandId == '') {
                alert('请选择品牌！');
                $('#<%=ddlbrand.ClientID %>').focus();
                return false;
            }
            var bigCateId = $.trim($('#<%=ddlBigCategory.ClientID %> option:selected').val());
            if (bigCateId == '') {
                alert('请选择大类！');
                $('#ddlBigCategory').focus();
                return false;
            }
            
            //        var smallCateId = $.trim($('#smallCateId option:selected').val());
            //        if (smallCateId == '') {
            //            alert('请选择小类！');
            //            $('#smallCateId').focus();
            //            return false;
            //        }
            //           var styleID = $.trim($('#<%=ddlstyle .ClientID %> option:selected').val());
            //        if (styleID == '') {
            //            alert('请选择风格！');
            //            $('#<%=ddlstyle .ClientID %>').focus();
            //            return false;
            //        }
            //             var materialId = $.trim($('#<%=ddlmaterial .ClientID %> option:selected').val());
            //        if (materialId == '') {
            //            alert('请选择材质！');
            //            $('#<%=ddlmaterial .ClientID %>').focus();
            //            return false;
            //        }

            //至少需要选择一个单品
            //        var singleproduct = $('input:checkbox:checked');

            //        if (singleproduct.length <= 1) {
            //            alert('至少需要选择两个单品！');
            //            return false;
            //        }
            if ($("#thumb").val() != "") {
                $("#<%=hfthumb.ClientID %>").val($("#thumb").val());
            }
            var hiddValue = $("#<%=hiddSingProductID.ClientID %>");
            if (hiddValue.val() == "" || hiddValue.val().split(",").length <= 1) {
                alert('至少需要选择两个单品！');
                return false;
            }


            var groupPrice = $("#groupPrice").val();
            if (groupPrice == "" || groupPrice == 0) {
                alert('请输入套餐价！');
                $('#groupPrice').focus();
                return false;
            }

            var reg = new RegExp(regexEnum.decmal1);
            if (!reg.test(groupPrice)) {
                alert('请输入有效套餐价！');
                $('#groupPrice').focus();
                return false;
            }

            if ($('#<%=ddlGroupProductPromotion.ClientID %> option:selected').val() != '' && $('#promotionPrice').val() == '') {
                alert('参加活动请输入促销价！');
                $('#promotionPrice').focus();
                return false;
            }

            var reg = new RegExp(regexEnum.decmal1);
            if ($('#promotionPrice').val() != '' && !reg.test($('#promotionPrice').val())) {
                alert('请输入有效促销价！');
                $('#promotionPrice').focus();
                return false;
            }
            //产品描述
            var descript = $.trim($(document.getElementsByTagName('iframe')[0].contentWindow.document.body).html());
            if (descript.toString() == '' || descript == '<br>') {
                alert('抱歉，请输入产品描述！');
                return false;
            }
            $('#txtKE').val(descript);
            getPropertyName();
            return true;
        }

        //获得产品组合属性名称
        function getPropertyName() {
            var PropertyName = '';
            var brandName = $.trim($('#brandId option:selected').text());
            if (brandName != '请选择') {
                PropertyName = brandName;
            }

            var bigCateName = $.trim($('#bigCateId option:selected').text());
            if (bigCateName != '请选择') {
                PropertyName += bigCateName;
            }

            var smallCateName = $.trim($('#<%=smallCateId.ClientID %> option:selected').text());
            if (smallCateName != '请选择') {
                PropertyName += smallCateName;
            }

            var SeriesName = $.trim($('#<%=SeriesId.ClientID %> option:selected').text());
            if (SeriesName != '请选择') {
                PropertyName += SeriesName;
            }

            var styleName = $.trim($('#styleId option:selected').text());
            if (styleName != '请选择') {
                PropertyName += styleName;
            }

            var MaterialName = $.trim($('#MaterialId option:selected').text());
            if (MaterialName != '请选择') {
                PropertyName += MaterialName;
            }

            var ColorName = $.trim($('#ColorId option:selected').text());
            if (ColorName != '请选择') {
                PropertyName += ColorName;
            }
            $('input[name=PropertyName]').val(PropertyName);
        }

        //加载编辑时套组合产品数据
        function LoadEditorGroupDb(gpId) {
            $.get('../MemberAjax/ProductHandler.ashx', { Action: 'editorgroupproduct', gpId: gpId.toString() }, function (data) {
                if (data == null) {
                    //alert('抱歉，未找到您要套组合产品！');
                    //history.back();
                } else {
                    if (data.toString() == '') {
                        //alert('抱歉，未找到您要套组合产品！');
                        //history.back();
                    } else {
                        //套组合编号
                        var No = $(data).find('No').text();
                        $('input[name=groupProductNo]').val(No);
                        //套组合名称
                        var Name = $(data).find('Name').text();
                        $('input[name=groupProductName]').val(Name);
                        //品牌
                        var brandId = $(data).find('brandId').text();
                        if (brandId.toString() != '0' && brandId.toString() != '') {
                            selectDdlByValue('brandId', brandId);
                            $('#<%=SeriesId.ClientID %>').empty();
                            $('<option>读取数据中</option>').appendTo($('#<%=SeriesId.ClientID %>'));
                            $.get('../MemberAjax/ProductHandler.ashx', { Action: 'series', brandId: brandId }, function (sdata) {
                                if (sdata != null) {
                                    $('#<%=SeriesId.ClientID %>').empty();
                                    sdata = '<option value="">请选择</option>' + sdata;
                                    $(sdata).appendTo($('#<%=SeriesId.ClientID %>'));
                                    var SeriesId = $(data).find('SeriesId').text();
                                    if (SeriesId.toString() != '0') {
                                        selectDdlByValue('SeriesId', SeriesId);
                                    }
                                }
                            });
                        }
                        //大类
                        var bigCateId = $(data).find('bigCateId').text();
                        if (bigCateId.toString() != '0') {
                            selectDdlByValue('bigCateId', bigCateId);
                            $('#<%=smallCateId.ClientID %>').empty();
                            $('<option>读取数据中</option>').appendTo($('#<%=smallCateId.ClientID %>'));
                            $.get('../MemberAjax/ProductHandler.ashx', { Action: 'categroy', bigCategroyId: bigCateId.toString() }, function (cdata) {
                                if (data != null) {
                                    $('#<%=smallCateId.ClientID %>').empty();
                                    cdata = '<option value="">请选择</option>' + cdata;
                                    $(cdata).appendTo($('#<%=smallCateId.ClientID %>'));
                                }
                            });
                        }
                        //风格
                        var styleId = $(data).find('styleId').text();
                        if (styleId.toString() != '0') {
                            selectDdlByValue('styleId', styleId);
                        }
                        //材质
                        var MaterialId = $(data).find('MaterialId').text();
                        if (MaterialId.toString() != '0') {
                            selectDdlByValue('MaterialId', MaterialId);
                        }
                        //色系
                        var ColorId = $(data).find('ColorId').text();
                        if (ColorId.toString() != '0') {
                            selectDdlByValue('ColorId', ColorId);
                        }
                        //是否组装
                        var IsGroup = $(data).find('IsGroup').text();
                        if (IsGroup.toString() == '1') {
                            $('input[name=IsGroup][value=\'1\']').attr('checked', true);
                        } else {
                            $('input[name=IsGroup][value=\'0\']').attr('checked', true);
                        }
                        //套餐价
                        var Price = $(data).find('Price').text();
                        $('input[name=groupPrice]').val(Price);
                        //整体图
                        var OverallPicture = $(data).find('OverallPicture').text();
                        if (OverallPicture.toString() != '') {
                            $('#Overall').val(OverallPicture);
                            $('#OverallPictrue').val(OverallPicture);
                        }
                        //局部图
                        var PartPicture = $(data).find('PartPicture').text();
                        if (PartPicture.toString() != '') {
                            $('#Part').val(PartPicture + ',');
                            var picArray = PartPicture.split(',');
                            for (var i = (picArray.length - 1); -1 < i; i--) {
                                //添加一个上传区域                        
                                $(getUploadHtml(picArray[i].toString())).insertBefore($('#Part').parent().find('.fileTools:eq(0)'));
                            }
                        }
                        //产品描述
                        var Descript = $(data).find('Descript').text();
                        if (Descript.toString() != '') {
                            $(document.getElementsByTagName('iframe')[0].contentWindow.document.body).html(Descript.toString());
                            $('#txtKE').val(Descript.toString());
                        }
                        //属性名称
                        var PropertyName = $(data).find('PropertyName').text();
                        if (PropertyName.toString() != '') {
                            $('input[name=PropertyName]').val(PropertyName);
                        }
                        //店铺
                        var ShopId = $(data).find('ShopId').text();
                        if (ShopId.toString() != '0') {
                            setTimeout("checkedShop('" + ShopId.toString() + "');", 500);
                        }
                        //选择的单品
                        var spId = $(data).find('spId').text();
                        $('input[name=singleproduct]').val(spId);
                    }
                }
            });
        }

        function getUploadHtml(imgPath) {
            var html = '<div class="fileTools">';
            html += '            <input type="text" readonly="readonly" id="PartPictrue" value="' + imgPath + '" class="input w200 filedisplay">';
            html += '            <a href="javascript:;" class="files">';
            html += '                <input type="file" name="FilePartProduct" id="FilePartProduct" class="upload" onchange="_upfile(this)"></a>';
            html += '            <span class="uploading"></span>';
            html += '        </div>';
            return html;
        }

        //选中下拉菜单
        function selectDdlByValue(objId, objValue) {
            $('#' + objId.toString() + ' option[value=\'' + objValue.toString() + '\']').attr('selected', true);
        }

        //选中店铺
        function checkedShop(ShopId) {
            $('input[name=shopId][value=\'' + ShopId.toString() + '\']').attr('checked', true);
        }

        //复制同类套组合产品
        function CopyGroupProduct() {
            var groupProductNo = $("input[name=groupProductNo]").val();

            if (groupProductNo.toString() == '' || groupProductNo.toString() == "亲，请先添加品牌，再添加产品") {
                alert('请输入套组合编号！');
                $("input[name=groupProductNo]").select();
                return;
            }


            if (0 < $('.pop').size()) {
                $('.pop').remove();
            }

            //创建类别盒子
            var html = '<div class="pop bord" id="copyproductdiv">';
            html += '  <h1><u>复制套组合</u><i>X</i></h1>';
            html += '  <div class="popcon">';
            html += '   <table width="100%" border="0" cellpadding="0" cellspacing="0">';
            html += '      <tr>';
            html += '        <td>正在读取数据中...</td>';
            html += '      </tr>';
            html += '    </table>';
            html += '    <div class="btnone">';
            html += '  <input type="button" value="确定" onclick="CopyGroupProductDb(this);" class="btnlitl" />';
            html += '  <input type="reset" value="取消" class="btnlitr" />';
            html += '  </div>';
            html += '  </div>';
            html += '</div>';
            $(html).insertAfter($('.mainbox'));
            PositionBox();
            $.get('../ajax/MemberHandler.ashx', { Action: 'copygroupproduct', productNo: escape(groupProductNo.toString()), ran: Math.random() }, function (data) {

                if (data != null) {
                    if (data == 'no') {
                        $('#copyproductdiv td').html('抱歉，未找到编号：' + productNo.toString() + '的产品！');
                    } else {
                        var myhtml = '<table width="100%" border="0" cellspacing="0" cellpadding="0"><tr><td>选择</td><td>名称</td><td>编号</td></tr>';
                        myhtml += data;
                        myhtml += '</table>';
                        $('#copyproductdiv td').html(myhtml);
                    }
                }
            });
        }

        function PositionBox() {
            $('.pop').css('top', ($(window).height() - $('.pop').height()) / 2 + $(document).scrollTop() + 'px');
            $('.pop').css('left', ($(window).width() - $('.pop').width()) / 2 + 'px');
            $('.pop i').click(function () {
                $('.pop').remove();
            });
            if (0 < $('.pop .btnlitr').size()) {
                $('.pop .btnlitr').click(function () {
                    $('.pop').remove();
                });
            }
        }

        function CopyGroupProductDb(obj) {
            var mysize = $('input[type=radio]:checked').size();
            if (mysize == 0) {
                alert('请选择套组合产品！');
                return;
            }
            if (confirm('您确定要复制该套组合产品吗？')) {
                var gpId = $('input[type=radio]:checked').val();
                var mysize = $('.msgtable .pages').size();
                if (mysize != 0) {
                    $('.msgtable .pages').remove();
                }
                //获取选择组合信息
                $.get('../ajax/MemberHandler.ashx', { Action: 'getcopygroupproduct', gpId: gpId.toString(), ran: Math.random() }, function (data) {
                    if (data != "") {
                        var json = eval("(" + data + ")");
                        $("input[name=groupProductNo]").val(json.gpNo);
                        $("input[name=groupProductName]").val(json.gpName);
                        $('#<%=ddlbrand.ClientID %>').val(json.gpBrandId);
                        $('#<%=ddlBigCategory.ClientID %>').val(json.gpBigCateId);
                        $('#<%=ddlstyle.ClientID %>').val(json.gpStyleId);
                        $('#<%=ddlmaterial.ClientID %> ').val(json.gpMaterialId);
                        $('#<%=hiddgpid.ClientID %> ').val(json.gpId);

                        //绑定系列                   
                        $.ajax({
                            url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                            data: 'type=getbrands&v=' + json.gpBrandId + "&ram=" + Math.random(),
                            dataType: 'json',
                            success: function (data) {
                                $("#<%=SeriesId.ClientID %>").html("").hide().show();
                                $("#<%=SeriesId.ClientID %>").append("<option value=\"\">请选择</option>");
                                $.each(data, function (i) {
                                    if (data[i].id != "" && data[i].title != "") {
                                        $("#<%=SeriesId.ClientID %>").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                                    }
                                });
                                $('#<%=SeriesId.ClientID %>').val(json.gpBrandsId);
                            }
                        });

                        $('#<%=smallCateId.ClientID %>').val(json.gpsmallCateId);

                        $('#<%=ddlcolor.ClientID %>').val(json.gpColorId);
                        $("#groupPrice").val(json.gpPrice);

                        //小类
                        $.ajax({
                            url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                            data: 'type=getsmallcatagory&v=' + json.gpBigCateId + "&ram=" + Math.random(),
                            dataType: 'json',
                            success: function (data) {
                                $("#<%=smallCateId.ClientID %>").html("").hide().show();
                                $("#<%=smallCateId.ClientID %>").append("<option value=\"\">请选择</option>");
                                $.each(data, function (i) {
                                    if (data[i].id != "" && data[i].title != "") {
                                        $("#<%=smallCateId.ClientID %>").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                                    }
                                });


                            }
                        });
                        //单品                  
                        loadEditProduct(json.gpId);
                        $('#<%=hiddSingProductID.ClientID %>').val(json.gpSingePids);
                        $('.msgtable tr:gt(0)').remove();

                        //产品描述，由于描述里面可能包含html代码，所有单独加载数据
                        $.get('../ajax/MemberHandler.ashx', { Action: 'getcopygroupproductDescript', gpId: gpId.toString(), ran: Math.random() },
                       function (dataDescript) {
                           if (dataDescript.toString() != '') {
                               $(document.getElementsByTagName('iframe')[0].contentWindow.document.body).html(dataDescript.toString());
                               $('#txtKE').val(dataDescript.toString());
                           }
                       });

                        //店铺
                        var shopids = json.gpShopId;
                        if (shopids != "") {
                            if (shopids.split(',').length > 1) {
                                for (var i = 0; i < shopids.split(',').length; i++) {
                                    $('input[name=shopId][value=\'' + shopids[i] + '\']').attr('checked', true);
                                }
                            } else {
                                $('input[name=shopId][value=\'' + shopids + '\']').attr('checked', true);
                            }
                        }
                        //是否组装
                        var IsGroup = json.gpIsGroup;
                        if (IsGroup.toString() == '1') {
                            $('input[name=IsGroup][value=\'1\']').attr('checked', true);
                        } else {
                            $('input[name=IsGroup][value=\'0\']').attr('checked', true);
                        }

                        //整体图
                        var OverallPicture = json.gpThumb;
                        //  alert(OverallPicture);
                        if (OverallPicture.toString() != '') {
                            $('#<%=hfthumb.ClientID %>').attr("value", OverallPicture.replace(",", ""));
                            $('#thumb').val(OverallPicture.replace(",", ""));
                            // $('#<%=File3.ClientID %>').parent().find('input.filedisplay]').val(OverallPicture);
                            // $('#OverallPictrue').val(OverallPicture);
                        }
                        // 局部图
                        var PartPicture = json.gpBannel;
                        if (PartPicture.toString() != '') {
                            $('#<%=hfbannel.ClientID %> ').val(PartPicture);
                            if (PartPicture.substring(PartPicture.length - 1, PartPicture.length) == ',') {
                                PartPicture = PartPicture.substring(0, PartPicture.length - 1);
                            }
                            var picArray = PartPicture.split(',');
                            for (var i = (picArray.length - 1); -1 < i; i--) {
                                //添加一个上传区域                        
                                $(getUploadHtml(picArray[i].toString())).insertBefore($('#<%=hfbannel.ClientID%>').parent().find('.fileTools:eq(0)'));
                            }
                        } 
                    }
                });
                $('.pop').remove();
            }
        }
        //添加品牌
        function addBrand() {
            if (0 < $('.pop').size()) {
                $('.pop').remove();
            }
            var html = '<div class="pop bord">';
            html += '  <h1><u>添加品牌</u><i>X</i></h1>';
            html += '  <div class="popcon"    style="width:280px">';
            html += '   <table width="100%" border="0" cellpadding="0" cellspacing="0">';
            html += '      <tr>';
            html += '        <td height="35" align="right">品牌名称</td>';
            html += '        <td style="text-align:left;"><input id="brandNames" type="text"/>';
            html += '              </td>';
            html += '      </tr>';
            html += '      <tr>';
            html += '        <td height="35" align="right">品牌档位</td>';
            html += '        <td style="text-align:left;"><select id="brandSpread">';
            html += '              </select></td>';
            html += '      </tr>';
            html += '        <tr><td height="35" align="right">品牌介绍</td>';
            html += '        <td style="text-align:left;"><textarea id="brandInfo" style="height:100px;"></textarea>';
            html += '              </td>';
            html += '      </tr>';
            html += '    </table>';
            html += '    <div class="btnone">';
            html += '  <input type="button" value="确定" onclick="SaveBrand(this);" class="btnlitl" />';
            html += '  <input type="reset" value="取消" class="btnlitr" />';
            html += '  </div>';
            html += '  </div>';
            html += '</div>';
            $(html).insertAfter($('.mainbox'));
            //填充品牌档位
            $($("#<%=ddlspread.ClientID %>").html()).appendTo($('#brandSpread'));
            PositionBox();
        }

        //保存品牌
        function SaveBrand(obj) {
            var brandNames = $("#brandNames").val();
            var brandSpread = $("#brandSpread").val();
            var brandInfo = $("#brandInfo").val();

            if (brandNames == "") {
                alert("请输入品牌名称");
                $("#brandNames").focus();
                return;
            }
            if (brandSpread == "") {
                alert("请选择品牌档位");
                return;
            }
            if (brandInfo == "") {
                alert("请输入品牌介绍");
                $("#brandInfo").focus();
                return;
            }
            $(obj).val('处理中');
            $(obj).attr('disabled', 'disabled');
            $.ajax({
                url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxproduct.ashx',
                data: 'type=savethebrand&companyid=<%=companyid %>&brandNames=' + escape(brandNames) + '&brandSpread=' + brandSpread + '&brandInfo=' + escape(brandInfo) + '&ram=' + Math.random(),
                dataType: 'json',
                success: function (data) {
                    $(obj).val('确定');
                    $(obj).removeAttr('disabled');
                    if (data != "") {
                        alert("添加系列成功!");
                        //重新加载品牌
                        loadTheBrands();
                        if (0 < $('.pop').size()) {
                            $('.pop').remove();
                        }
                    } else {
                        alert("添加系列失败!");
                    }
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
                    $("#<%=ddlbrand.ClientID %>").empty();
                    $("#<%=ddlbrand.ClientID %>").append("<option value=\"\">请选择</option>");
                    $("#<%=SeriesId.ClientID %>").empty();
                    $("#<%=SeriesId.ClientID %>").append("<option value=\"\">请选择</option>");
                    $.each(data, function (i) {
                        if (data[i].id != "" && data[i].title != "") {
                            $("#<%=ddlbrand.ClientID %>").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
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
//-->  
    </script>
</asp:Content>
