<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Member.Master" CodeBehind="productinfo.aspx.cs"
    Inherits="TREC.Web.Suppler.product.productinfo" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/')%>/script/ymPrompt.js"
        type="text/javascript"></script>
    <link href="../resource/css/ymPrompt/simple_gray/ymPrompt.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../script/myPublic.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/')%>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript">

    $(function () {        
        var editor;
        KindEditor.ready(function (K) {
            <%-- %>editor = K.create('#<%=txtdescript.ClientID %>', {
                allowPreviewEmoticons: true,
                allowImageUpload: true,
                allowFileManager: true,
                <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                { %>
                    fileManagerJson:"<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/')%>/editor/kindeditor/ashx/file_manager_json.ashx?m=company&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                <%} %>
                allowMediaUpload: true,
                items: [
					'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
					'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
					'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
            });--%>
            editor1 = K.create('#<%=txt101.ClientID %>', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/editor/kindeditor/ashx/file_manager_json.ashx?m=product&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|','link', 'fullscreen']
                });
                editor2 = K.create('#<%=txt102.ClientID %>', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/editor/kindeditor/ashx/file_manager_json.ashx?m=product&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'link', 'fullscreen']
                });
                editor3 = K.create('#<%=txt103.ClientID %>', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/editor/kindeditor/ashx/file_manager_json.ashx?m=product&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|','link', 'fullscreen']
                });
                editor4 = K.create('#<%=txt104.ClientID %>', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/editor/kindeditor/ashx/file_manager_json.ashx?m=product&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|','link', 'fullscreen']
                });
                editor5 = K.create('#<%=txt105.ClientID %>', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/editor/kindeditor/ashx/file_manager_json.ashx?m=product&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|',  'link', 'fullscreen']
                });
        });
    });
    </script>
    <style type="text/css">
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
            <u>添加产品</u></h1>
    </div>
    <div class="maincon">
        <div class="maintabcor">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td height="35" align="right">
                            产品编号
                        </td>
                        <td style="text-align: left;" colspan="7">
                            <%--<asp:TextBox ID="productNo" runat="server" CssClass="input"></asp:TextBox>--%>
                            <input type="text" size="34" name="productNo" value="" id="productNo" class="input"
                                runat="server" /><span class="tip">*</span>
                            <input type="button" value="复制同类产品" onclick="CopyProduct(0);" class="btnadd btncopy" />
                            <span class="nortip">(输入单品编号或者关键字,可以调出对应的产品数据)</span>
                        </td>
                    </tr>
                    <tr>
                        <td height="35" align="right">
                            产品名称
                        </td>
                        <td style="text-align: left;" colspan="7">
                            <input type="text" size="34" name="productName" id="productName" runat="server" /><span
                                class="tip">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td width="9%" height="35" align="right">
                            品牌<span id="brandClkLoad"></span>
                        </td>
                        <td width="22%" style="text-align: left;">
                            <asp:DropDownList ID="ddlbrand" runat="server" CssClass="select" Width="85">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlspread" runat="server" Style="display: none;">
                            </asp:DropDownList>
                            <a target="_blank" onclick="addBrandYmprompt()">
                                <img width="16" height="16" border="0" alt="添加" src="../Images/jiahao.jpg"></a>
                            <span class="tip">*</span>
                        </td>
                        <td width="6%" align="right">
                            大类
                        </td>
                        <td width="20%" style="text-align: left;">
                            <asp:DropDownList ID="ddlBigCategory" runat="server" CssClass="select" Width="80">
                            </asp:DropDownList>
                            <span class="tip">*</span>
                        </td>
                        <td width="6%" align="right">
                            风格
                        </td>
                        <td width="15%" style="text-align: left;">
                            <asp:DropDownList ID="ddlstyle" runat="server" CssClass="select" Width="85">
                            </asp:DropDownList>
                        </td>
                        <td width="6%" align="right">
                            色系
                        </td>
                        <td width="16%" style="text-align: left;">
                            <asp:DropDownList ID="ddlcolor" runat="server" CssClass="select" Width="80">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="35" align="right">
                            系列
                        </td>
                        <td style="text-align: left;">
                            <%--<select name="ddlbrands" runat="server" id="ddlbrands"><option>请选择</option>  </select>--%>
                            <asp:DropDownList ID="ddlbrands" runat="server" CssClass="select" Width="85">
                                <asp:ListItem Value="">请选择</asp:ListItem>
                            </asp:DropDownList>
                            <asp:HiddenField ID="hiddBrands" runat="server" />
                            <asp:HiddenField ID="hiddBrandsName" runat="server" />
                            <a target="_blank" onclick="addBrands()">
                                <img width="16" height="16" border="0" alt="添加" src="../Images/jiahao.jpg"></a><span
                                    class="tip">*</span>
                        </td>
                        <td align="right">
                            小类
                        </td>
                        <td style="text-align: left;">
                            <%--  <select name="smallCateId" runat="server" id="smallCateId">
        <option value="">请选择</option></select>--%>
                            <asp:DropDownList ID="smallCateId" runat="server" CssClass="select" Width="85">
                                <asp:ListItem Value="">请选择</asp:ListItem>
                            </asp:DropDownList>
                            <span class="tip">*</span>
                            <asp:HiddenField ID="hiddSmallCate" runat="server" />
                            <asp:HiddenField ID="hiddSmallName" runat="server" />
                            <%--<a class="myhander" onclick="showIssueCategroyBox();"><img width="16" height="16" border="0" alt="添加" src="../Images/jiahao.jpg"></a>--%>
                        </td>
                        <td align="right">
                            材质
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlmaterial" runat="server" CssClass="select" Width="85">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                        </td>
                        <td style="text-align: left;">
                        </td>
                    </tr>
                    <tr>
                        <td height="35" align="right">
                            是否组装
                        </td>
                        <td style="text-align: left;">
                            <asp:RadioButtonList ID="radAssemble" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                <asp:ListItem Text="否" Value="0"></asp:ListItem>
                                <asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td align="right">
                            色板
                        </td>
                        <td style="text-align: left;" colspan="5">
                            <span id="colorSwatch">
                                <%=ColorSwatch %></span>
                            <input type="button" value="上传色板" onclick="UploadColorSwatch(this);" class="btnadd">
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Product, ECommon.QueryId, TREC.Entity.EnFilePath.ProductAttributeColorImg)%>">
                                <asp:HiddenField ID="hfsurface" runat="server" />
                                <%--<div class="fileTools" style="width:310px">
                        <input type="text" class="input w160 filedisplay" style="width:100px;" />
                        <a href="javascript:;" class="files">
                            <input id="File1" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>--%>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="addcm bord">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td style="text-align: right;font-weight:bolder;">产品属性</td>
                    </tr>
                    <tr>
                        <td style="height: 35px; text-align: right;">
                            类型
                        </td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddltype" runat="server" CssClass="select selectNone">
                            </asp:DropDownList>
                            <input id="rowNum" type="hidden" value="0" /><input id="attrid" type="hidden" value="0" />
                            <%--<a onclick="addPpType();" class="myhander"><img width="16" height="16" border="0" src="../Images/jiahao.jpg"></a>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="35" align="right">
                            尺寸<span class="tip">*</span>
                        </td>
                        <td style="text-align: left;">
                            <input type="text" size="10" id="txtalength">
                            X
                            <input type="text" size="10" id="txtawidth">
                            X
                            <input type="text" size="10" id="txtaheight">
                            （长X宽X高，单位mm）
                        </td>
                    </tr>
                    <tr>
                        <td height="35" align="right">
                            体积<span class="tip">*</span>
                        </td>
                        <td style="text-align: left;">
                            <input type="text" size="10" id="txtacbm">
                            （打包体积，单位m<sup>3</sup><span class="smarl">库存</span>
                            <input type="text" size="10" id="Stock" style="ime-mode: disabled;">
                            <span class="smarl">颜色</span>
                            <select id="hfacolor">
                                <option value="0">请选择</option>
                                <%=myColorOption%>
                            </select>
                            <a onclick="addMemberColor();" class="myhander">
                                <img width="16" height="16" border="0" src="../Images/jiahao.jpg"></a>
                        </td>
                    </tr>
                    <tr>
                        <td height="35" align="right">
                            详细材质说明<span class="tip">*</span>
                        </td>
                        <td style="text-align: left;">
                            <input type="text" size="40" maxlength="500" id="txtamaterial">
                            （例：榆木框架+多层板+白腊木贴面）
                        </td>
                    </tr>
                    <tr>
                        <td height="50" align="right">
                            市场价
                        </td>
                        <td style="text-align: left;">
                            <input type="text" size="10" id="txtmarketprice">
                            <span class="smarl">销售价 </span>
                            <input type="text" size="10" id="SalePrice">
                            <span class="smarl">促销价 </span>
                            <input type="text" size="10" id="PromoPrice">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 35px; text-align: right;">
                            参加活动
                        </td>
                       
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlProductAttributePromotion" runat="server" CssClass="select selectNone">
                            </asp:DropDownList>
                        </td>
                      
                    </tr>
                    <tr>
                        <td height="73" style="height: 60px;" class="bordtop">
                            &nbsp;
                        </td>
                        <td style="text-align: left;" class="bordtop">
                            <input type="button" value="添加" class="btnlitl">
                            <span class="nortip">（例：提交完一个尺寸等信息之后，可以再次添加其他尺寸。）</span>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div style="margin-top: 0;" class="msgtable">
            <asp:HiddenField ID="hfproductattribute" runat="server" />
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr class="titlecor">
                        <th>
                            尺寸(mm)
                        </th>
                        <th>
                            体积(m<sup>3</sup>)
                        </th>
                        <th>
                            选材
                        </th>
                        <th>
                            颜色
                        </th>
                        <th>
                            库存
                        </th>
                        <th>
                            市场价
                        </th>
                        <th>
                            销售价
                        </th>
                        <th>
                            促销价
                        </th>
                        <th>
                            活动
                        </th>
                        <th>
                            删除
                        </th>
                    </tr>
                    <%--  <%if (listproductattribute != null)
                      { %>
                    <%foreach (EnProductAttribute pa in listproductattribute)
                      { %>
         <tr>
         <td> <%=Convert.ToInt32(pa.productlength) %>* <%=Convert.ToInt32(pa.productwidth) %>*  <%=Convert.ToInt32(pa.productheight)%></td>
         <td> <%=pa.productcbm%></td>
         <td><%=pa.productmaterial%></td>
         <td><%=pa.productcolortitle%></td>
         <td><%=pa.storage%></td>
         <td>￥<%=pa.markprice%></td>
         <td>￥<%=pa.saleprice%></td>
         <td>￥<%=pa.buyprice%></td>        
         <td><a class="myhander" onclick="DeleteProductProp(this);"><img src="../Images/del.png" alt="删除" width="16" height="16" border="0" /></a></td>
         </tr>
    <%}
    } %>--%>
                </tbody>
            </table>
        </div>
        <div style="padding-top: 0;" class="maintabcor">
            <asp:HiddenField ID="hiddpid" runat="server" />
            <asp:HiddenField ID="hflogo" runat="server" />
            <asp:HiddenField ID="hfdesimage" runat="server" />
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td align="right" width="70">
                            &nbsp;&nbsp;缩略图：
                        </td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Product, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
                                <asp:HiddenField ID="hfthumb" runat="server" />
                                <div class="fileTools" style="width: 310px">
                                    <input type="text" class="input w160 filedisplay" name="thumb" id="thumb" />
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
                        <td align="right" valign="top">
                            &nbsp;&nbsp; 详细图：
                        </td>
                        <td>
                            <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Product, ECommon.QueryId, TREC.Entity.EnFilePath.Banner)%>">
                                <asp:HiddenField ID="hfbannel" runat="server" />
                                <div class="fileTools" style="width: 310px">
                                    <input type="text" class="input w160 filedisplay" />
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
                    <td valign="middle" align="right" >
                    产品描述：
                    </td>
                    <td >
                    <style> 
                        .box{ margin:20px; } 
                        .container{background:#FFF; width:500px; clear:both; margin-top:1px; _margin-top:-1px;} 
                        .sub-con{height:300px; width:610px;border:1px solid #3CF; background:#FFF; display:none;} 
                        .cur-sub-con{ display:block;} 
                        .sub-con a{ line-height:40px} 
                        .sub-con p{ text-align:center} 
                        .nav{ width:450px; height:28px; margin-left:10px;} 
                        .nav ul{width:450px; height:28px;} 
                        .nav ul li{ list-style:none; display:inline-block;width:80px; height:28px;line-height:28px; text-align:center;margin-left:-9px;*float:left;*margin-left:-1px;} 
                        .nav ul li a{ background:#fff;border:1px solid #3CF; text-decoration:none; color:#000; height:28px;display:block;} 
                        .nav ul li a:hover{ background:#CCEDFB} 
                        .nav ul li a.cur{ z-index:9999;border-bottom:1px solid #FFF; color:#F00;} 
                    </style> 
                    <script>
                        $(document).ready(function () {
                            var intervalID;
                            var curLi;
                            $(".nav li a").mouseover(function () {
                                curLi = $(this);
                                intervalID = setInterval(onMouseOver, 250); //鼠标移入的时候有一定的延时才会切换到所在项，防止用户不经意的操作 
                            });
                            function onMouseOver() {
                                $(".cur-sub-con").removeClass("cur-sub-con");
                                $(".sub-con").eq($(".nav li a").index(curLi)).addClass("cur-sub-con");
                                $(".cur").removeClass("cur");
                                curLi.addClass("cur");
                            }
                            $(".nav li a").mouseout(function () {
                                clearInterval(intervalID);
                            });

                            $(".nav li a").click(function () {//鼠标点击也可以切换 
                                clearInterval(intervalID);
                                $(".cur-sub-con").removeClass("cur-sub-con");
                                $(".sub-con").eq($(".nav li a").index(curLi)).addClass("cur-sub-con");
                                $(".cur").removeClass("cur");
                                curLi.addClass("cur");
                            });

                        }); 
                    </script>
                    <div class="box"> 
                        <div class="nav"> 
                        <ul> 
                        <%--<li><a href="javascript:void(0)">产品描述<span class="tip">*</span></a></li>--%> 
                        <li><a href="javascript:void(0)" class="cur">风格特点</a></li> 
                        <li><a href="javascript:void(0)">产品细节</a></li> 
                        <li><a href="javascript:void(0)">材质工艺</a></li> 
                        <li><a href="javascript:void(0)">保养说明</a></li>
                        <li><a href="javascript:void(0)">配送周期</a></li>
                        </ul> 
                        </div> 
                        <div class="container"> 
                        <%--<div class="sub-con cur-sub-con">
                        <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea required" TextMode="MultiLine"
                                Rows="5" Width="600" Height="260"></asp:TextBox>
                        </div>--%> 
                        <div class="sub-con cur-sub-con">
                        <asp:TextBox ID="txt101" runat="server" CssClass="textarea required" TextMode="MultiLine"
                                Rows="5" Width="600" Height="260"></asp:TextBox>
                        </div> 
                        <div class="sub-con">
                        <asp:TextBox ID="txt102" runat="server" CssClass="textarea required" TextMode="MultiLine"
                                Rows="5" Width="600" Height="260"></asp:TextBox>
                        </div> 
                        <div class="sub-con">
                        <asp:TextBox ID="txt103" runat="server" CssClass="textarea required" TextMode="MultiLine"
                                Rows="5" Width="600" Height="260"></asp:TextBox>
                        </div> 
                        <div class="sub-con">
                        <asp:TextBox ID="txt104" runat="server" CssClass="textarea required" TextMode="MultiLine"
                                Rows="5" Width="600" Height="260"></asp:TextBox>
                        </div>
                        <div class="sub-con">
                        <asp:TextBox ID="txt105" runat="server" CssClass="textarea required" TextMode="MultiLine"
                                Rows="5" Width="600" Height="260"></asp:TextBox>
                        </div>
                        </div> 
                    </div> 
                    </td>
                    </tr>
                    <%if (!string.IsNullOrEmpty(shopStr))
                      {%><tr>
                          <td style="text-align: left;" colspan="2">
                              <div style="padding-top: 10px;" class="guishudp">
                                  你是否同时要把此产品归属到以下店铺？<ul>
                                      <%=shopStr%></ul>
                                  <div class="clear">
                                  </div>
                              </div>
                          </td>
                      </tr>
                    <%} %>
                    <tr>
                        <td style="text-align: left;" colspan="2">
                            <div class="btnone">
                                <asp:Button ID="btnSave" runat="server" OnClientClick="return chkProdcutForm();"
                                    Text="保存" CssClass="btnl" OnClick="btnSave_Click" />
                                <input name="重置" type="reset" class="btnl" id="btnRequest" value="重置" runat="server" />
                                
                                <%--<input type="submit" class="btnl" id="ctl00_ContentPlaceHolder1_BtnSaveProduct" onclick="return chkProdcutForm();" value="提 交" name="ctl00$ContentPlaceHolder1$BtnSaveProduct"><input type="reset" class="btnr" value="重 填" name="button">--%>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/')%>/script/fileupload.js"></script>
    <script type="text/javascript" src="../script/myPublic.js"></script>
    <script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/')%>/script/formValidatorRegex.js"
        type="text/javascript"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/')%>/script/jquery.form.js"></script>
    <script type="text/javascript">
    <!--

        $(function () {

            //添加属性按钮绑定事件
            $('.addcm .btnlitl').bind("click", SaveProductProperty);

            //  $('.addcm .btnlitl').click(SaveProductProperty(''));
            //产品输入框点击事件
//            $("#<%= productNo.ClientID%>").click(function () {
//                if (this.value == "亲，请先添加品牌，再添加产品") {
//                    this.value = "";
//                }
//            });
//            $("#<%= productNo.ClientID%>").blur(function () {
//                if (this.value == "") {
//                    this.value = "亲，请先添加品牌，再添加产品";
//                }
//            });

            //品牌下拉。获得系列及绑定品牌数据  
            $("#<%=ddlbrand.ClientID %>").change(function () {
                loadBrands(this.value, "getbrands");
            });

            $("#<%=ddlbrands.ClientID %>").change(function () {
                if (this.value != "") {
                    $('#<%=hiddBrands.ClientID %>').val(this.value);
                    $('#<%=hiddBrandsName.ClientID %>').val($("#<%=ddlbrands.ClientID %>  option:selected").text());
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
            //大类下拉。获得小类数据  
            $("#<%=ddlBigCategory.ClientID %>").change(function () {
                $.ajax({
                    url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                    data: 'type=getsmallcatagory&v=' + this.value + "&ram=" + Math.random(),
                    dataType: 'json',
                    success: function (data) {
                        $("#<%=smallCateId.ClientID %>").empty(); //清除小类以便重新加载
                        $("#<%=ddltype.ClientID %>").empty(); //清除类型以便重新加载
                        // $("#<%=smallCateId.ClientID %>").html("").hide().show();
                        $("#<%=smallCateId.ClientID %>").append("<option value=\"\">请选择</option>");
                        $.each(data, function (i) {
                            if (data[i].id != "" && data[i].title != "" && data[i].title.indexOf("套组合") == -1) {
                                $("#<%=smallCateId.ClientID %>").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                            }
                        });
                    }
                });
            });
            //小类改变，绑定类型
            $("#<%=smallCateId.ClientID %>").change(function () {
                if (this.value != "") {
                    $("#<%=ddltype.ClientID %>").empty();
                    $("#<%=hiddSmallCate.ClientID %>").val(this.value);
                    $('#<%=hiddSmallName.ClientID %>').val($("#<%=smallCateId.ClientID %>  option:selected").text());
                    $.ajax({
                        url: '../ajax/MemberHandler.ashx',
                        data: 'Action=gettype&smallCID=' + this.value + "&ram=" + Math.random(),
                        dataType: 'json',
                        success: function (data) {
                            $('#<%=ddltype.ClientID %>').empty(); //清除类型以便重新加载
                            $("#<%=ddltype.ClientID %>").append("<option value=\"\">请选择</option>");
                            $.each(data, function (i) {
                                if (data[i].id != "" && data[i].title != "") {
                                    $("#<%=ddltype.ClientID %>").append("<option value=\"" + data[i].value + "\">" + data[i].title + "</option>");
                                }
                            });
                        }
                    });
                } else {
                    $("#<%=hiddSmallCate.ClientID %>").val(0);
                }
            });
            //编辑产品时用已有小类绑定类型
            if ($("#<%=hiddSmallCate.ClientID %>").val() != "") {
                $.ajax({
                    url: '../ajax/MemberHandler.ashx',
                    data: 'Action=gettype&smallCID=' + $("#<%=hiddSmallCate.ClientID %>").val() + "&ram=" + Math.random(),
                    dataType: 'json',
                    success: function (data) {
                        $('#<%=ddltype.ClientID %>').empty(); //清除类型以便重新加载
                        $("#<%=ddltype.ClientID %>").append("<option value=\"\">请选择</option>");
                        $.each(data, function (i) {
                            if (data[i].id != "" && data[i].title != "") {
                                $("#<%=ddltype.ClientID %>").append("<option value=\"" + data[i].value + "\">" + data[i].title + "</option>");
                            }
                        });
                    }
                });
            }
            //iframe子窗口品牌添加后调用这个重载品牌数据
            $("#brandClkLoad").click(function () {
                loadTheBrands();
            });
            //绑定系列
            function loadBrands(id, type) {
                $.ajax({
                    url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                    data: 'type=' + type + '&v=' + id + "&ram=" + Math.random(),
                    dataType: 'json',
                    success: function (data) {
                        $("#<%=ddlbrands.ClientID %>").html("").hide().show();
                        $("#<%=ddlbrands.ClientID %>").append("<option value=\"\">请选择</option>");
                        $.each(data, function (i) {
                            if (data[i].id != "" && data[i].title != "") {
                                $("#<%=ddlbrands.ClientID %>").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                            }
                        });
                    }
                });
            }



            //弹出的删除提示框始终位于屏幕中间
            $(window).scroll(function () {
                if ($('.pop').size() != 0) {
                    $('.pop').css('top', ($(window).height() - $('.pop').height()) / 2 + $(document).scrollTop() + 'px');
                    $('.pop').css('left', ($(window).width() - $('.pop').width()) / 2 + 'px');
                }
            });

            //ProductBelongShop(); //店铺

            //big categroy change click
            $('#bigCateId').change(function () {
                var bigId = $(this).val();
                if (bigId == '') {
                    $('#smallCateId option:gt(0)').remove();
                } else {
                    $('#typeId').empty();
                    $('<option value="0">请选择</option>').appendTo($('#typeId'));
                    $('#smallCateId').empty();
                    $('<option>读取数据中</option>').appendTo($('#smallCateId'));
                    $.get('../MemberAjax/ProductHandler.ashx', { Action: 'categroy', bigCategroyId: bigId }, function (data) {
                        if (data != null) {
                            $('#smallCateId').empty();
                            data = '<option value="">请选择</option>' + data;
                            $(data).appendTo($('#smallCateId'));
                        }
                    });
                }
            });
            //smallCateId change click
            $('#smallCateId').change(function () {
                fillTypeBySmallCateId($(this).val().toString());
            });
            //load color dropdownlist
            //LoadColorDownMenu();

            //库存/#Stock,#Long/
            var intObj = '#Stock';
            //        $(intObj).numeral();

            var productId = '0';
            var ppId = '<%=ppId %>';
            //产品属性        
            LoadProductProp(ppId);

            //显示产品数据
            //ShowProductDb(productId.toString(), ppId.toString());
        });

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
        //添加品牌 弹出iframe
        function addBrandYmprompt() {
            //ymPrompt.win({ message: "/suppler/brand/addBrandYM.aspx?time=" + (new Date()).getTime(), width: 500, height: 600, title: '添加品牌',
            ymPrompt.win({ message: "/suppler/brand/addBrandYM.aspx", width: 600, height: 530, title: '添加品牌', handler: function () { }, iframe: true });
        }

        //添加系列
        function addBrands() {
            if (0 < $('.pop').size()) {
                $('.pop').remove();
            }
            var html = '<div class="pop bord">';
            html += '  <h1><u>添加系列</u><i>X</i></h1>';
            html += '  <div class="popcon"    style="width:280px">';
            html += '   <table width="100%" border="0" cellpadding="0" cellspacing="0">';
            html += '      <tr>';
            html += '        <td height="35" align="right">品牌</td>';
            html += '        <td style="text-align:left;"><select id="tbrandSelect">';
            html += '              </select></td>';
            html += '      </tr>';
            html += '        <tr><td height="35" align="right">系列名称</td>';
            html += '        <td style="text-align:left;"><input type="text" id="tBrandsName" name="tBrandsName" value="" maxlength="30" /></tr>';
            html += '      <tr>';
            html += '        <td height="35" align="right">材质</td>';
            html += '        <td style="text-align:left;"><select id="materialSelect">';
            html += '              </select></td>';
            html += '      </tr>';
            html += '      <tr>';
            html += '        <td height="35" align="right">风格</td>';
            html += '        <td style="text-align:left;"><select id="StyleSelect">';
            html += '              </select></td>';
            html += '      </tr>';
            html += '        <tr><td height="35" align="right">色系</td>';
            html += '        <td style="text-align:left;"><select id="ColorStyleSelect">';
            html += '              </select></td>';
            html += '      </tr>';
            html += '    </table>';
            html += '    <div class="btnone">';
            html += '  <input type="button" value="确定" onclick="SaveBrands(this);" class="btnlitl" />';
            html += '  <input type="reset" value="取消" class="btnlitr" />';
            html += '  </div>';
            html += '  </div>';
            html += '</div>';
            $(html).insertAfter($('.mainbox'));
            //填充品牌
            $($("#<%=ddlbrand.ClientID %>").html()).appendTo($('#tbrandSelect'));
            //填充材质
            $($("#<%=ddlmaterial.ClientID %>").html()).appendTo($('#materialSelect'));
            //填充风格
            $($("#<%=ddlstyle.ClientID %>").html()).appendTo($('#StyleSelect'));
            //填充色系
            $($("#<%=ddlcolor.ClientID %>").html()).appendTo($('#ColorStyleSelect'));
            PositionBox();
        }

        //保存系列
        function SaveBrands(obj) {
            var brand = $("#tbrandSelect option:selected").val();
            var brandsName = $("#tBrandsName").val();
            var materialSelect = $("#materialSelect").val();
            var StyleSelect = $("#StyleSelect").val();
            var ColorStyleSelect = $("#ColorStyleSelect").val();

            if (brand == "") {
                alert("请选择品牌");
                return;
            }
            if (brandsName == "") {
                alert("请输入系列名称");
                $("#tBrandsName").focus();
                return;
            }
            if (materialSelect == "") {
                alert("请选择材质");
                return;
            }
            if (StyleSelect == "") {
                alert("请选择风格");
                return;
            }
            if (ColorStyleSelect == "") {
                alert("请选择色系");
                return;
            }
            $(obj).val('处理中');
            $(obj).attr('disabled', 'disabled');
            $.ajax({
                url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxproduct.ashx',
                data: 'type=savebrands&brandid=' + brand + '&brandsName=' + escape(brandsName) + '&material=' + materialSelect + '&StyleSelect=' + StyleSelect + '&ColorStyleSelect=' + ColorStyleSelect + '&ram=' + Math.random(),
                dataType: 'json',
                success: function (data) {
                    $(obj).val('确定');
                    $(obj).removeAttr('disabled');
                    if (data != "") {
                        alert("添加系列成功!");
                        //重新加载系列
                        // loadBrands(brand, "getbrands");
                        $.ajax({
                            url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                            data: 'type=getbrands&v=' + brand + "&ram=" + Math.random(),
                            dataType: 'json',
                            success: function (data) {
                                $("#<%=ddlbrands.ClientID %>").html("").hide().show();
                                $("#<%=ddlbrands.ClientID %>").append("<option value=\"\">请选择</option>");
                                $.each(data, function (i) {
                                    if (data[i].id != "" && data[i].title != "") {
                                        $("#<%=ddlbrands.ClientID %>").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                                    }
                                });
                            }
                        });
                        if (0 < $('.pop').size()) {
                            $('.pop').remove();
                        }
                    } else {
                        alert("添加系列失败!");
                    }
                }
            });
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
                    $("#<%=ddlbrands.ClientID %>").empty();
                    $("#<%=ddlbrands.ClientID %>").append("<option value=\"\">请选择</option>");
                    $.each(data, function (i) {
                        if (data[i].id != "" && data[i].title != "") {
                            $("#<%=ddlbrand.ClientID %>").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                        }
                    });
                }
            });
        }

        function showIssueCategroyBox() {
            if (0 < $('.pop').size()) {
                $('.pop').remove();
            }
            //创建类别盒子
            var html = '<div class="pop bord">';
            html += '  <h1><u>添加类别</u><i>X</i></h1>';
            html += '  <div class="popcon">';
            html += '   <table width="100%" border="0" cellpadding="0" cellspacing="0">';
            html += '      <tr>';
            html += '        <td height="35" align="right">大类</td>';
            html += '        <td style="text-align:left;"><select id="issuebigcategroy">';
            html += '              </select></td>';
            html += '      </tr>';
            html += '      <tr>';
            html += '        <td height="35" align="right">小类</td>';
            html += '        <td style="text-align:left;"><input type="text" id="smallCategroyName" maxlength="50" />';
            html += '        </td>';
            html += '      </tr>';
            html += '    </table>';
            html += '    <div class="btnone">';
            html += '  <input type="button" value="确定" onclick="SaveSmallCategory(this);" class="btnlitl" />';
            html += '  <input type="reset" value="取消" class="btnlitr" />';
            html += '  </div>';
            html += '  </div>';
            html += '</div>';
            $(html).insertAfter($('.mainbox'));
            //填充大类
            $($('#bigCateId').html()).appendTo($('#issuebigcategroy'))
            PositionBox();
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

        //发布小类
        function SaveSmallCategory(obj) {
            var bigCateId = $('#issuebigcategroy option:selected').val();
            if (bigCateId == '') {
                alert('抱歉，请选择大类！');
                $('#issuebigcategroy').focus();
                return;
            }
            var smallCategroyName = $.trim($('#smallCategroyName').val());
            if (smallCategroyName == '') {
                alert('抱歉，请输入小类名称！');
                $('#smallCategroyName').focus();
                return;
            }
            $(obj).val('处理中');
            $(obj).attr('disabled', 'disabled');
            $.get('../MemberAjax/ProductHandler.ashx', { Action: 'smallcate', bigCateId: bigCateId, smallCateName: escape(smallCategroyName) }, function (data) {
                $(obj).val('确定');
                $(obj).removeAttr('disabled');
                if (data != null) {
                    if (data == 'success') {
                        alert('添加小类成功，请等待审核！');
                    } else {
                        alert('抱歉，该名称的小类已存在！');
                        $('#smallCategroyName').focus();
                    }
                }
            });
        }

        //上传色板
        function UploadColorSwatch(obj) {
            if (0 < $('.pop').size()) {
                $('.pop').remove();
            }
            $.get('IssueProductColorSwatch.htm', function (data) {
                $(data).insertAfter($('.mainbox'));

                PositionBox();
            });
        }

        //保存上传色板数据
        function SaveColorSwatch(obj) {
            var SwatchName = $.trim($('input[name=SwatchName]').val());
            if (SwatchName == '') {
                alert('请输入色板名称！');
                $('input[name=SwatchName]').focus();
                return;
            }
            var myCategroy = $('#myCategroy option:selected').val();
            if (myCategroy.toString() == '0') {
                alert('请选择类别！');
                $('#myCategroy').focus();
                return;
            }
            var picture = $.trim($('#hfthumb').val());
            if (picture == '') {
                alert('请上传色板图片！');
                return;
            }
            $.get('../ajax/MemberHandler.ashx', { Action: 'saveswatch', SeriesName: escape(SwatchName.toString()), SeriesId: '0', myCategroy: myCategroy.toString(), hfthumb: picture.toString() }, function (data) {
                if (data != null) {
                    $("#colorSwatch").empty();
                    $("#colorSwatch").html(" ");
                    // $(data).insertAfter($('#colorSwatch'));
                    $("#colorSwatch").html(data);
                    alert('上传色板成功！');
                    $('.pop').remove();
                } else {
                    alert('抱歉，系统正忙请稍后上传色板！');
                }
            });
        }

        //加载颜色下拉菜单
        function LoadColorDownMenu() {
            $.get('../MemberAjax/ProductHandler.ashx', { Action: 'color' }, function (data) {
                if (data != null) {
                    $(data).appendTo($('#myColor'));
                }
            });
        }

        //定义全局变量，添加产品属性使用
        var _this = null; //执行方法是传递的当前对象EditorProductProp（this）
        var _rowCount = 0; //添加产品属性的当前行号
        var _attrid = 0; //产品属性id
        //保存产品属性
        function SaveProductProperty(th) {

            //长
            var Long = $.trim($('#txtalength').val());
            if (Long == '') {
                alert('请输入产品尺寸长！');
                $('#txtalength').focus();
                return;
            }
            var reg = new RegExp(regexEnum.decmal1);
            if (!reg.test(Long)) {
                alert('请输入有效产品尺寸长！');
                $('#txtalength').focus();
                return;
            }
            //宽
            var Width = $.trim($('#txtawidth').val());
            if (Width == '') {
                alert('请输入产品尺寸宽！');
                $('#txtawidth').focus();
                return;
            }
            if (!reg.test(Width)) {
                alert('请输入有效产品尺寸宽！');
                $('#txtawidth').focus();
                return;
            }
            //高
            var Height = $.trim($('#txtaheight').val());
            if (Height == '') {
                alert('请输入产品尺寸高！');
                $('#txtaheight').focus();
                return;
            }
            if (!reg.test(Height)) {
                alert('请输入有效产品尺寸高！');
                $('#txtaheight').focus();
                return;
            }
            //体积
            var Volume = $.trim($('#txtacbm').val());
            if (Volume == '') {
                alert('请输入产品打包后的体积！');
                $('#txtacbm').focus();
                return;
            }
            if (!reg.test(Volume)) {
                alert('请输入有效产品打包后的体积！');
                $('#txtacbm').focus();
                return;
            }
            //库存
            var Stock = $.trim($('#Stock').val());


            //详细材质说明
            var MaterialDescript = $.trim($('#txtamaterial').val());
            if (MaterialDescript == '') {
                alert('请输入详细材质说明！');
                $('#txtamaterial').focus();
                return;
            }
            //市场价
            var regA = new RegExp(regexEnum.num);
            var MarketPrice = $.trim($('#txtmarketprice').val());
            if ($('#<%=ddlProductAttributePromotion.ClientID %>').val() != "" && MarketPrice == '') {
                alert('参加活动的请输入市场价！');
                $('#txtmarketprice').focus();
                return;
            }
            if (MarketPrice != '' && !regA.test(MarketPrice)) {
                alert('请输入有效市场价');
                $('#txtmarketprice').focus();
                return;
            }
            //销售价
            var SalePrice = $.trim($('#SalePrice').val());
            if ($('#<%=ddlProductAttributePromotion.ClientID %>').val() != "" && SalePrice == '') {
                alert('参加活动的请输入销售价！');
                $('#SalePrice').focus();
                return;
            }
            if (SalePrice != "" && !regA.test(SalePrice)) {
                alert('请输入有效销售价！');
                $('#SalePrice').focus();
                return;
            }
            //促销价
            var PromoPrice = $.trim($('#PromoPrice').val());
            if ($('#<%=ddlProductAttributePromotion.ClientID %>').val() != "" && PromoPrice == '') {
                alert('参加活动的请输入促销价！');
                $('#PromoPrice').focus();
                return;
            }
            if (PromoPrice != "" && !regA.test(PromoPrice)) {
                alert('请输入有效促销价！');
                $('#PromoPrice').focus();
                return;
            }
            var colorId = $.trim($('#myColor option:selected').val());
            var ppId = 0;
            if (0 < $('#myppId').size()) {
                ppId = $.trim($('#myppId').val());
            }
            //类型
            var typeId = $.trim($('#typeId option:selected').val());
            var htmlJson = "";
            var listHtml = "";

            var productType = "";
            var productTypeName = "";
            var productMaterial = "";
            var phfacolor = "";
            var pcolortitle = "";
            var pacolorimg = "";
            var plength = "";
            var pawidth = "";
            var paheight = "";
            var pacbm = "";
            var pmarketprice = "";
            var ProductAttributePromotion = "";
            var ProductAttributePromotionName = "";

            //add 提示
            if ($("#txtamaterial").val() == "") {
                $("#txtamaterial").focus();
                alert("请填写选材!");
                return false;
            }
            var mySize = $('.msgtable tr').size();
            //alert(mySize);
            var rowcount = 0;
            if ($("#rowNum").val() != "" && $("#rowNum").val() != "0")
                rowcount = $("#rowNum").val();
            else
                rowcount = mySize;
            //alert(rowcount);
            var rowNum = "\"rowNum\":\"" + rowcount + "\","
            var attrid = "\"attrid\":\"" + $("#attrid").val() + "\","
            if ($("#ddltype").val() != "" && $("#ddltype").val() != "0") {
                productType = "\"typeid\":\"" + $("#<%= ddltype.ClientID%>").val() + "\",";
                productTypeName = "\"typename\":\"" + $("#<%= ddltype.ClientID%>").find("option:selected").text() + "\",";
                listHtml += "<span  class=\"t\">" + $("#<%= ddltype.ClientID%>").find("option:selected").text() + "</span>";
            }
            else {
                productType = "\"typeid\":\"0\",";
                productTypeName = "\"typename\":\"" + $("#txtatypename").val() + "\",";
                listHtml += "<span class=\"t\">" + $("#txtatypename").val() + "</span>";
            }
            if ($("#<%= ddlProductAttributePromotion.ClientID%>").val() != "" && $("#<%= ddlProductAttributePromotion.ClientID%>").val() != "0") {
                ProductAttributePromotion = "\"productAttributePromotion\":\"" + $("#<%= ddlProductAttributePromotion.ClientID%>").val() + "\",";
                ProductAttributePromotionName = "\"productAttributePromotionName\":\"" + $("#<%= ddlProductAttributePromotion.ClientID%>").find("option:selected").text() + "\",";
                listHtml += "<span  class=\"t\">" + $("#<%= ddlProductAttributePromotion.ClientID%>").find("option:selected").text() + "</span>";
            }
            else {
                ProductAttributePromotion = "\"productAttributePromotion\":\"0\",";
                ProductAttributePromotionName = "\"productAttributePromotionName\":\"\",";
                listHtml += "<span class=\"t\"></span>";
            }
            var pcolortile = $("#hfacolor  option:selected").text();
            if (pcolortile == "请选择") {
                pcolortile = '无';
            }
            productMaterial = "\"pmaterial\":\"" + $("#txtamaterial").val() + "\",";
            phfacolor = "\"pacolor\":\"" + $("#hfacolor  option:selected").val() + "\",";
            pcolortitle = "\"pcolortitle\":\"" + pcolortile + "\",";
            //  pacolorimg = "\"pcimg\":\"" + $("#hfacolorimg").val() + "\",";
            plength = "\"plength\":\"" + $("#txtalength").val() + "\",";
            pawidth = "\"pwidth\":\"" + $("#txtawidth").val() + "\",";
            paheight = "\"pheight\":\"" + $("#txtaheight").val() + "\",";
            pacbm = "\"pcbm\":\"" + $("#txtacbm").val() + "\",";
            pmarketprice = "\"pmprice\":\"" + $("#txtmarketprice").val() + "\",";
            SalePrice = "\"SalePrice\":\"" + $("#SalePrice").val() + "\",";
            PromoPrice = "\"PromoPrice\":\"" + $("#PromoPrice").val() + "\",";
            Stock = "\"Stock\":\"" + $("#Stock").val() + "\"";
            htmlJson = '{' + rowNum + attrid + productType + productTypeName + ProductAttributePromotion + ProductAttributePromotionName + productMaterial + phfacolor + pcolortitle + pacolorimg + plength + paheight + pawidth + pacbm + pmarketprice + SalePrice + PromoPrice + Stock + '},';

            if (_this == null) {
                $('#<%=hfproductattribute.ClientID %>').val($('#<%=hfproductattribute.ClientID %>').val() + htmlJson);
                var html = '';
                html += '<tr id=' + rowcount + ' txttitle=' + htmlJson + '><td height="40">' + $("#txtalength").val() + '*' + $("#txtawidth").val() + '*' + $("#txtaheight").val() + '</td>';
                html += '<td>' + $("#txtacbm").val() + '</td>';
                html += '<td>' + $("#txtamaterial").val() + '</td>';
                html += '<td>' + pcolortile + '</td>';
                html += '<td>' + $("#Stock").val() + '</td>';
                html += '<td>' + $("#txtmarketprice").val() + '</td>';
                html += '<td>' + $("#SalePrice").val() + '</td>';
                html += '<td>' + $("#PromoPrice").val() + '</td>';
                if ($("#<%= ddlProductAttributePromotion.ClientID%>").val != "0" && $("#<%= ddlProductAttributePromotion.ClientID%>").val() != "")
                    html += '<td>' + $("#<%= ddlProductAttributePromotion.ClientID%>").find("option:selected").text() + '</td>';
                else
                    html += '<td></td>';
                html += '<td><a class="myhander" onclick="EditorProductProp(this);"><img src="../Images/bianji.png" alt="编辑" width="16" height="16" border="0" /></a><a class="myhander" onclick="DeleteProductProp(this);"><img src="../Images/del.png" alt="删除" width="16" height="16" border="0" /></a></td></tr>';
                $(html).insertAfter($('.msgtable tr:eq(0)'));
                alert("添加成功");
            } else {
                var html = '';
                html += '<td height="40">' + $("#txtalength").val() + '*' + $("#txtawidth").val() + '*' + $("#txtaheight").val() + '</td>';
                html += '<td>' + $("#txtacbm").val() + '</td>';
                html += '<td>' + $("#txtamaterial").val() + '</td>';
                html += '<td>' + pcolortile + '</td>';
                html += '<td>' + $("#Stock").val() + '</td>';
                html += '<td>' + $("#txtmarketprice").val() + '</td>';
                html += '<td>' + $("#SalePrice").val() + '</td>';
                html += '<td>' + $("#PromoPrice").val() + '</td>';
                if ($("#<%= ddlProductAttributePromotion.ClientID%>").val != "0" && $("#<%= ddlProductAttributePromotion.ClientID%>").val() != "")
                    html += '<td>' + $("#<%= ddlProductAttributePromotion.ClientID%>").find("option:selected").text() + '</td>';
                else
                    html += '<td></td>';
                html += '<td><a class="myhander" onclick="EditorProductProp(this);"><img src="../Images/bianji.png" alt="编辑" width="16" height="16" border="0" /></a><a class="myhander" onclick="DeleteProductProp(this);"><img src="../Images/del.png" alt="删除" width="16" height="16" border="0" /></a></td>';
                $(_this).parent().parent().html(html);
                //修改隐藏域的值
                var hiddValue = $('#<%=hfproductattribute.ClientID %>').val();
                //$("#<%=hfproductattribute.ClientID %>").val($("#<%=hfproductattribute.ClientID %>").val().replace($("#" + _rowCount).attr("title"), htmlJson));
                $("#" + _rowCount).attr("txttitle", htmlJson);
                $('.addcm .btnlitl').val('保存');
                _this = null;
                _rowCount = 0;
                var fulljson = "";
                $(".msgtable tr").each(function () {
                    if ($(this).attr("txttitle"))
                        fulljson += $(this).attr("txttitle");
                });
                $("#<%=hfproductattribute.ClientID %>").val(fulljson);

                alert("修改成功");
            }
            ResetPA();
        }

        //编辑产品属性
        function EditorProductProp(th) {
            var editPro = $(th).parent().parent().attr("txttitle");
            if (editPro.substring(editPro.length - 1, editPro.length) == ',') {
                editPro = editPro.substring(0, editPro.length - 1);
            }
            var json = eval("(" + editPro + ")");
            $("#rowNum").val(json.rowNum);
            $("#attrid").val(json.attrid);

            //重绑类型数据
            $.ajax({
                url: '../ajax/MemberHandler.ashx',
                data: 'Action=gettype&smallCID=' + $('#<%=smallCateId.ClientID %>').val() + "&ram=" + Math.random(),
                dataType: 'json',
                success: function (data) {
                    $('#<%=ddltype.ClientID %>').empty(); //清除类型以便重新加载
                    $("#<%=ddltype.ClientID %>").append("<option value=\"\">请选择</option>");
                    $.each(data, function (i) {
                        if (data[i].id != "" && data[i].title != "") {
                            $("#<%=ddltype.ClientID %>").append("<option value=\"" + data[i].value + "\">" + data[i].title + "</option>");
                        }
                        $("#<%= ddltype.ClientID%>").val(json.typeid);
                    });
                }
            });

            $("#hfacolor").val(json.pacolor)
            $("#txtalength").val(json.plength);
            $("#txtawidth").val(json.pwidth);
            $("#txtaheight").val(json.pheight);
            $("#txtamaterial").val(json.pmaterial);

            $("#txtacbm").val(json.pcbm);
            $("#txtmarketprice").val(json.pmprice);
            $("#SalePrice").val(json.SalePrice);
            $("#PromoPrice").val(json.PromoPrice);
            $("#Stock").val(json.Stock);
            $("#<%= ddlProductAttributePromotion.ClientID%>").val(json.productAttributePromotion);
            //改变按钮功能
            $('.addcm .btnlitl').val('修改');
            //全局变量赋值，保存产品属性时使用          
            _this = th;
            _rowCount = json.rowNum;
            _attrid = json.attrid;
        }


        //删除产品属性
        function DeleteProductProp(th) {
            if (confirm("确定删除吗？")) {
                ResetPA();
                $("#<%=hfproductattribute.ClientID %>").val($("#<%=hfproductattribute.ClientID %>").val().replace($(th).parent().parent().attr("txttitle"), ""));
                $(th).parent().parent().remove();
            }
        }
        //重置产品属性表单
        function ResetPA() {
            $("#<%= ddltype.ClientID%>").val("");
            $("#rowNum").val(0);
            $("#attrid").val(0);
            $("#txtalength").val("");
            $("#txtawidth").val("");
            $("#txtaheight").val("");
            $("#txtacbm").val("");
            $("#Stock").val("");
            $("#hfacolor").val("");
            $("#txtamaterial").val("");
            $("#txtmarketprice").val("");
            $("#SalePrice").val("");
            $("#PromoPrice").val("");
            $("#<%=ddlProductAttributePromotion.ClientID %>").val("");
            $('.addcm .btnlitl').val('添加');
        }
        //编辑时加载产品属性
        function LoadProductProp(ppId) {
            $.get('../ajax/MemberHandler.ashx', { Action: 'getproductattr', pid: ppId, rnd: Math.random() },
                     function (dataproAttr) {
                         $(dataproAttr).insertAfter($('.msgtable tr:eq(0)'));
                     });
        }



        function getPpCode(ppId) {
            if (ppId < 10) {
                ppId = '00' + ppId.toString();
            } else if (ppId < 100) {
                ppId = '0' + ppId.toString();
            }
            return ppId;
        }


        //操作相关数据
        function doAboutDb(myid, type) {
            var productId = $('input[name=productId]').val();
            $.get('../MemberAjax/ProductHandler.ashx', { Action: type.toString(), ppId: myid.toString(), productId: productId.toString(), rnd: Math.random() }, function (data) {
                if (data != null) {
                    if (type == 'delpp') {
                        //删除产品属性
                        if (data.toString() == 'success') {
                            alert('删除产品属性成功！');
                            $('#pp-' + myid.toString()).remove();
                        } else {
                            alert('系统正忙，请稍后删除产品属性！');
                        }
                    }
                }
            });
        }



        //发布产品表单
        function chkProdcutForm() {
            var productNo = $.trim($('#<%=productNo.ClientID %>').val());

            if (productNo == '') {
                alert('抱歉，请输入产品编号！');
                $('#<%=productNo.ClientID %>').focus();
                return false;
            }
            var productName = $.trim($('#<%=productName.ClientID %>').val());
            if (productName == '') {
                alert('抱歉，请输入产品名称！');
                $('#<%=productName.ClientID %>').focus();
                return false;
            }
            var brandId = $.trim($('#<%=ddlbrand.ClientID %> option:selected').val());
            if (brandId.toString() == '') {
                alert('抱歉，请选择产品品牌！');
                $('#<%=ddlbrand.ClientID %>').focus();
                return false;
            }
            var bigCateId = $.trim($('#<%=ddlBigCategory .ClientID %> option:selected').val());
            if (bigCateId.toString() == '') {
                alert('抱歉，请选择产品大类！');
                $('#<%=ddlBigCategory .ClientID %>').focus();
                return false;
            }
            var smallCateId = $.trim($('#<%=smallCateId .ClientID %> option:selected').val());
            if (smallCateId.toString() == '') {
                alert('抱歉，请选择产品小类！');
                $('#<%=smallCateId .ClientID %>').focus();
                return false;
            }

            //        var smallCateId = $.trim($('#<%=ddlstyle .ClientID %> option:selected').val());
            //        if (smallCateId.toString() == '') {
            //            alert('抱歉，请选择产品风格！');
            //            $('#<%=ddlstyle .ClientID %>').focus();
            //            return false;
            //        }
            //        var smallCateId = $.trim($('#<%=ddlcolor .ClientID %> option:selected').val());
            //        if (smallCateId.toString() == '') {
            //            alert('抱歉，请选择产品色系！');
            //            $('#<%=ddlcolor .ClientID %>').focus();
            //            return false;
            //        }

            var brandsId = $.trim($('#<%=ddlbrands .ClientID %> option:selected').val());
            if (brandsId.toString() == '') {
                alert('抱歉，请选择产品系列！');
                $('#<%=ddlbrands .ClientID %>').focus();
                return false;
            }

            //        var ddlmaterial = $.trim($('#<%=ddlmaterial .ClientID %> option:selected').val());
            //        if (ddlmaterial.toString() == '') {
            //            alert('抱歉，请选择产品材质！');
            //            $('#<%=ddlmaterial .ClientID %>').focus();
            //            return false;
            //        }
            //避免分类名称不保存问题
            $("#<%=hiddSmallCate.ClientID %>").val($("#<%=smallCateId.ClientID %>  option:selected").val());
            $('#<%=hiddSmallName.ClientID %>').val($("#<%=smallCateId.ClientID %>  option:selected").text());
            if ($("#thumb").val() != "") {
                $("#<%=hfthumb.ClientID %>").val($("#thumb").val());
            }



            //产品属性
            var mySize = $('.msgtable tr').size();
            if (mySize == 1) {
                alert('抱歉，请添加产品属性！');
                return false;
            }
       

            //产品描述
//            var descript = $.trim($(document.getElementsByTagName('iframe')[0].contentWindow.document.body).html());
//            if (descript.toString() == '' || descript == '<br>') {
//                alert('抱歉，请输入产品描述！');
//                return false;
//            }
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

            var smallCateName = $.trim($('#smallCateId option:selected').text());
            if (smallCateName != '请选择') {
                PropertyName += smallCateName;
            }

            var SeriesName = $.trim($('#SeriesId option:selected').text());
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

        //显示产品数据
        function ShowProductDb(productId, ppId) {
            $.get('../MemberAjax/ProductHandler.ashx', { Action: 'geteditorproductdb', productId: productId.toString(), ppId: ppId.toString() }, function (data) {
                if (data == '') {
                    //alert('抱歉，未找到您要的产品！');
                    //history.back();
                } else {
                    data = $($.parseXML(data));
                    //产品编号
                    var No = $(data).find('No').text();
                    if (ppId.toString() != '0') {
                        $('input[name=productNo]').val(No);
                    }
                    //产品名称
                    var Name = $(data).find('Name').text();
                    $('input[name=productName]').val(Name);
                    //品牌、系列
                    var brandId = $(data).find('brandId').text();
                    if (brandId.toString() != '0') {
                        selectDdlByValue('brandId', brandId);
                        $('#SeriesId').empty();
                        $('<option>读取数据中</option>').appendTo($('#SeriesId'));
                        $.get('../MemberAjax/ProductHandler.ashx', { Action: 'series', brandId: brandId }, function (sdata) {
                            if (sdata != null) {
                                $('#SeriesId').empty();
                                sdata = '<option value="">请选择</option>' + sdata;
                                $(sdata).appendTo($('#SeriesId'));
                                var SeriesId = $(data).find('SeriesId').text();
                                if (SeriesId.toString() != '0') {
                                    selectDdlByValue('SeriesId', SeriesId);
                                }
                            }
                        });
                    }
                    //大类、小类
                    var bigCateId = $(data).find('bigCateId').text();
                    if (bigCateId.toString() != '0') {
                        selectDdlByValue('bigCateId', bigCateId);
                        $('#smallCateId').empty();
                        $('<option>读取数据中</option>').appendTo($('#smallCateId'));
                        $.get('../MemberAjax/ProductHandler.ashx', { Action: 'categroy', bigCategroyId: bigCateId.toString() }, function (cdata) {
                            if (data != null) {
                                $('#smallCateId').empty();
                                cdata = '<option value="">请选择</option>' + cdata;
                                $(cdata).appendTo($('#smallCateId'));
                                var smallCateId = $(data).find('smallCateId').text();
                                selectDdlByValue('smallCateId', smallCateId);
                                //填充类型
                                fillTypeBySmallCateId(smallCateId.toString());
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
                    }
                    //色板
                    var pcsxml = $(data).find('pcsxml').text();
                    if (pcsxml != '') {
                        var csvalue = '';
                        $(pcsxml).each(function (i, pdata) {
                            csvalue = $(pdata).find('csId').text();
                            $('input[name=ColorSwatch][value=\'' + csvalue + '\']').attr('checked', true);
                        });
                    }
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
                        //$('#PartPictrue').val(PartPicture);
                        var picArray = PartPicture.split(',');
                        for (var i = (picArray.length - 1); -1 < i; i--) {
                            //添加一个上传区域                        
                            $(getUploadHtml(picArray[i].toString())).insertBefore($('#Part').parent().find('.fileTools:eq(0)'));
                        }
                    }
                    //产品描述
//                    var Descript = $(data).find('Descript').text();
//                    if (Descript.toString() != '') {
//                        $(document.getElementsByTagName('iframe')[0].contentWindow.document.body).html(Descript.toString());
//                        $('#txtKE').val(Descript.toString());
//                    }
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
                    //产品id
                    if (ppId.toString() != '0') {
                        var ProductId = $(data).find('ProductId').text();
                        $('input[name=productId]').val(ProductId);
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

        function selectDdlByValue(objId, objValue) {
            $('#' + objId.toString() + ' option[value=\'' + objValue.toString() + '\']').attr('selected', true);
        }

        function checkedShop(ShopId) {
            $('input[name=shopId][value=\'' + ShopId.toString() + '\']').attr('checked', true);
        }

        //复制产品
        function CopyProduct(ppId) {

            var productNo = $.trim($("#<%=productNo.ClientID %>").val());

            if (productNo.toString() == '' || productNo.toString() == "亲，请先添加品牌，再添加产品") {
                alert('请输入产品编号！');
                $("#<%=productNo.ClientID %>").select();
                return;
            }

            if (0 < $('.pop').size()) {
                $('.pop').remove();
            }
            //创建类别盒子
            var html = '<div class="pop bord" id="copyproductdiv" style="width:600px; height:500px;">';
            html += '  <h1><u>复制产品</u><i>X</i></h1>';
            html += '  <div class="popcon"  style="width:600px; height:500px; overflow:auto; ">';
            html += '   <table width="100%" border="0"  cellpadding="0" cellspacing="0">';
            html += '      <tr>';
            html += '        <td>正在读取数据中...</td>';
            html += '      </tr>';
            html += '    </table>';
            html += '    <div class="btnone">';
            html += '  <input type="button" value="确定" onclick="CopyProductProperty(this);" class="btnlitl" />';
            html += '  <input type="reset" value="取消" class="btnlitr" />';
            html += '  </div>';
            html += '  </div>';
            html += '</div>';
            $(html).insertAfter($('.mainbox'));
            PositionBox();
            $.get('../ajax/MemberHandler.ashx', { Action: 'copyproduct', ppId: ppId.toString(), productNo: escape(productNo.toString()), ram: Math.random() }, function (data) {
                if (data != null) {
                    if (data == 'no') {
                        $('#copyproductdiv td').html('抱歉，未找到编号：' + productNo.toString() + '的产品！');
                    } else {
                        var myhtml = '<table width="100%" border="0" cellspacing="0" cellpadding="0"><tr><td width="10%">选择</td><td  width="30%">名称</td><td  width="10%">编号</td>';
                        myhtml += data;
                        myhtml += '</table>';
                        $('#copyproductdiv td').html(myhtml);
                    }
                }
            }); 
        }
        //开始复制单品
        function CopyProductProperty(obj) {
            var mysize = $('input[name=mypId]:checked').size();
            if (mysize == 0) {
                alert('请选择产品！');
                return;
            }
            if (confirm('您确定要复制该产品吗？')) {
                var productId = $('input[name=mypId]:checked').val();
                //alert(productId);
                //编辑产品时
                // var productId = $('input[name=productId]').val();
                $.get('../ajax/MemberHandler.ashx', { Action: 'copypptopp', productId: productId.toString(), rnd: Math.random() }, function (data) {
                    if (data != '') {
                        var json = eval("(" + data + ")");

                        $('#<%=productNo.ClientID %>').val(json.pSku);
                        $('#<%=productName.ClientID %>').val(json.pName);

                        $('#<%=ddlbrand.ClientID %>').val(json.pBrandId);

                        $('#<%=ddlstyle .ClientID %>').val(json.pStyleId);
                        $('#<%=ddlmaterial .ClientID %>').val(json.pMaterialId);
                        $('#<%=ddlcolor .ClientID %>').val(json.pColorId);

                        //为隐藏域赋值
                        $('#<%=hiddpid .ClientID %>').val(json.pId);
                        $("#<%=hiddSmallCate.ClientID %>").val(json.pSmallCateId);
                        $("#<%=hiddSmallName.ClientID %>").val(json.pCategorytitle);
                        $("#<%=hiddBrands.ClientID %>").val(json.pBrandsId);
                        //产品属性隐藏域赋值
                        $('#<%=hfproductattribute.ClientID %>').val(json.pProductAttr);

                        $.get('../ajax/MemberHandler.ashx', { Action: 'getproductattr', pid: json.pId, rnd: Math.random() },
                     function (dataproAttr) {
                         $('.msgtable tr:eq(0)').empty();
                         $(dataproAttr).insertAfter($('.msgtable tr:eq(0)'));
                     });

                        //alert(json.pBrandId);
                        //绑定系列
                        // loadBrands(json.pBrandId, "getbrands");
                        $.ajax({
                            url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                            data: 'type=getbrands&v=' + json.pBrandId + "&ram=" + Math.random(),
                            dataType: 'json',
                            success: function (dataBrands) {

                                $("#<%=ddlbrands.ClientID %>").append("<option value=\"\">请选择</option>");
                                $.each(dataBrands, function (i) {
                                    if (dataBrands[i].id != "" && dataBrands[i].title != "") {
                                        $("#<%=ddlbrands.ClientID %>").append("<option value=\"" + dataBrands[i].id + "\">" + dataBrands[i].title + "</option>");
                                    }
                                });
                                if (json.pBrandsId != 0) {
                                    $("#<%=ddlbrands.ClientID %>").val(json.pBrandsId);
                                }
                            }
                        });

                        $('#<%=ddlBigCategory .ClientID %>').val(json.pBigCateId);

                        //加载小类
                        $.ajax({
                            url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                            data: 'type=getsmallcatagory&v=' + json.pBigCateId + "&ram=" + Math.random(),
                            dataType: 'json',
                            success: function (dataCate) {

                                $("#<%=smallCateId.ClientID %>").html("").hide().show();
                                $("#<%=smallCateId.ClientID %>").append("<option value=\"\">请选择</option>");
                                $.each(dataCate, function (i) {

                                    if (dataCate[i].id != "" && dataCate[i].title != "" && dataCate[i].title.indexOf("套组合") == -1) {
                                        
                                        $("#<%=smallCateId.ClientID %>").append("<option value=\"" + dataCate[i].id + "\">" + dataCate[i].title + "</option>");
                                    }
                                });
                                if (json.pSmallCateId != 0) {
                               
                                    $("#<%=smallCateId.ClientID %>").val(json.pSmallCateId);
                                }
                            }
                        });
                        //复制产品时用已有小类绑定类型 
                        if ($("#<%=hiddSmallCate.ClientID %>").val() != "") {
                            $.ajax({
                                url: '../ajax/MemberHandler.ashx',
                                data: 'Action=gettype&smallCID=' + $("#<%=hiddSmallCate.ClientID %>").val() + "&ram=" + Math.random(),
                                dataType: 'json',
                                success: function (data) {
                                    $('#<%=ddltype.ClientID %>').empty(); //清除类型以便重新加载
                                    $("#<%=ddltype.ClientID %>").append("<option value=\"\">请选择</option>");
                                    $.each(data, function (i) {
                                        if (data[i].id != "" && data[i].title != "") {
                                            $("#<%=ddltype.ClientID %>").append("<option value=\"" + data[i].value + "\">" + data[i].title + "</option>");
                                        }
                                    });
                                }
                            });
                        }
                        //是否组装
                        var IsGroup = json.pIsGroup;
                        if (IsGroup.toString() == '1') {
                            $('input[name=radAssemble][value=\'1\']').attr('checked', true);
                        } else {
                            $('input[name=radAssemble][value=\'0\']').attr('checked', true);
                        }
                        //整体图
                        var OverallPicture = json.pThumb;
                        //  alert(OverallPicture);
                        if (OverallPicture.toString() != '') {
                            $('#<%=hfthumb.ClientID %>').attr("value", OverallPicture.replace(",", ""));
                            $('#thumb').val(OverallPicture.replace(",", ""));
                            // $('#<%=File3.ClientID %>').parent().find('input.filedisplay]').val(OverallPicture);
                            // $('#OverallPictrue').val(OverallPicture);
                        }
                        // 局部图
                        var PartPicture = json.pBannel;
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
                        //pShopids 店铺
                        var shopids = json.pShopids;
                        if (shopids != "") {
                            if (shopids.split(',').length > 1) {
                                for (var i = 0; i < shopids.split(',').length; i++) {
                                    $('input[name=shopId][value=\'' + shopids[i] + '\']').attr('checked', true);
                                }
                            } else {
                                $('input[name=shopId][value=\'' + shopids + '\']').attr('checked', true);
                            }
                        }

                        //产品描述，由于描述里面可能包含html代码，所有单独加载数据
                        //                        $.get('../ajax/MemberHandler.ashx', { Action: 'getcopyproductdescript', productId: json.pId, ran: Math.random() },
                        //                       function (dataDescript) {
                        //                           if (dataDescript.toString() != '') {
                        //                               $(document.getElementsByTagName('iframe')[0].contentWindow.document.body).html(dataDescript.toString());
                        //                               $('#txtKE').val(dataDescript.toString());
                        //                           }
                        //                       });
                        $('.pop').remove();
                    }
                });
            }
        }

        //添加类型
        function addPpType() {
            if (0 < $('.pop').size()) {
                $('.pop').remove();
            }
            //创建类别盒子
            var html = '<div class="pop bord">';
            html += '  <h1><u>添加类型</u><i>X</i></h1>';
            html += '  <div class="popcon">';
            html += '   <table width="100%" border="0" cellpadding="0" cellspacing="0">';
            html += '      <tr>';
            html += '        <td height="35" align="right">名称</td>';
            html += '        <td style="text-align:left;"><input type="text" id="ppTypeName" style="width:180px;" maxlength="100" /></td>';
            html += '      </tr>';
            html += '      <tr>';
            html += '        <td height="35" align="right">说明</td>';
            html += '        <td style="text-align:left;"><textarea id="ppTypeInfo" style="width:183px;font-size:13px;"></textarea></td>';
            html += '      </tr>';
            html += '    </table>';
            html += '    <div class="btnone">';
            html += '  <input type="button" value="确定" onclick="SavePpType(this);" class="btnlitl" />';
            html += '  <input type="reset" value="取消" class="btnlitr" />';
            html += '  </div>';
            html += '  </div>';
            html += '</div>';
            $(html).insertAfter($('.mainbox'));
            PositionBox();
        }

        //保存类型
        function SavePpType(obj) {
            var ppTypeName = $.trim($('#ppTypeName').val());
            if (ppTypeName == '') {
                alert('请输入类型名称！');
                $('#ppTypeName').focus();
                return;
            }
            var ppTypeInfo = $.trim($('#ppTypeInfo').val());
            //产品小类id
            var smallCateId = $.trim($('#smallCateId option:selected').val());
            if (smallCateId.toString() == '') {
                smallCateId = '0';
            }
            $(obj).val('保存中');
            $(obj).attr('disabled', 'disabled');
            $.get('../ajax/MemberHandler.ashx', { Action: 'savetype', ppTypeName: escape(ppTypeName), ppTypeInfo: escape(ppTypeInfo), smallCateId: smallCateId.toString(), rnd: Math.random() }, function (data) {
                $(obj).val('确定');
                $(obj).removeAttr('disabled');
                if (data != null) {
                    if (data.toString() == 'success') {
                        alert('添加类型成功，请等待管理员审核！');
                    } else {
                        alert('系统正忙请稍后添加类型！');
                    }
                }
            });
        }

        //添加颜色
        function addMemberColor() {
            if (0 < $('.pop').size()) {
                $('.pop').remove();
            }
            //创建类别盒子
            var html = '<div class="pop bord">';
            html += '  <h1><u>添加颜色</u><i>X</i></h1>';
            html += '  <div class="popcon">';
            html += '   <table width="100%" border="0" cellpadding="0" cellspacing="0">';
            html += '      <tr>';
            html += '        <td height="35" align="right">名称</td>';
            html += '        <td style="text-align:left;"><input type="text" id="ppTypeName" style="width:180px;" maxlength="100" /></td>';
            html += '      </tr>';
            html += '      <tr>';
            html += '        <td height="35" align="right">说明</td>';
            html += '        <td style="text-align:left;"><textarea id="ppTypeInfo" style="width:183px;font-size:13px;"></textarea></td>';
            html += '      </tr>';
            html += '    </table>';
            html += '    <div class="btnone">';
            html += '  <input type="button" value="确定" onclick="SaveMemberColor(this);" class="btnlitl" />';
            html += '  <input type="reset" value="取消" class="btnlitr" />';
            html += '  </div>';
            html += '  </div>';
            html += '</div>';
            $(html).insertAfter($('.mainbox'));
            PositionBox();
        }

        function SaveMemberColor(obj) {
            var ppTypeName = $.trim($('#ppTypeName').val());
            if (ppTypeName == '') {
                alert('请输入颜色名称！');
                $('#ppTypeName').focus();
                return;
            }
            var ppTypeInfo = $.trim($('#ppTypeInfo').val());
            $(obj).val('保存中');
            $(obj).attr('disabled', 'disabled');
            $.get('../ajax/MemberHandler.ashx', { Action: 'savecolor', ppTypeName: escape(ppTypeName), ppTypeInfo: escape(ppTypeInfo), rnd: Math.random() }, function (data) {
                $(obj).val('确定');
                $(obj).removeAttr('disabled');
                if (data != null) {
                    if (data.toString() == 'success') {
                        alert('添加颜色成功！');
                        if (0 < $('.pop').size()) {
                            $('.pop').remove();
                        }
                        loadColor(obj);
                    } else {
                        alert('系统正忙请稍后添加颜色！');
                    }
                }
            });
        }
        function loadColor(obj) {
            $.get('../ajax/MemberHandler.ashx', { Action: 'getcolor', rnd: Math.random() }, function (data) {
                $(obj).removeAttr('disabled');
                if (data != null) {
                    if (data != '') {
                        $('#hfacolor').empty();
                        data = '<option value="">请选择</option>' + data;
                        $(data).appendTo($('#hfacolor'));
                    } else {
                        data = '<option value="">请选择</option>';
                        $(data).appendTo($('#smallCateId'));
                    }
                }
            });
        }

 
  
    //-->
    </script>
</asp:Content>
