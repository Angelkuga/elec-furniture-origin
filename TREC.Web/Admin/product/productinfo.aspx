<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productinfo.aspx.cs" Inherits="TREC.Web.Admin.product.productinfo"
    EnableEventValidation="false" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="<%="\""+TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/')%>/altdialog/skins/default.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/fileupload.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/altdialog/artDialog.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/altdialog/plugins/iframeTools.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/json2.js"></script>
    <style type="text/css">
        .formTable
        {
            border: 1px solid #ccc;
        }
        .formTable tr th
        {
            background: #ededed;
            text-align: left;
        }
        .formTable tr td
        {
            border: none;
            padding-top: 8px;
            padding-bottom: 8px;
        }
        #productattributelist ul
        {
            margin-left: 36px;
        }
        #productattributelist ul li
        {
            background: #f3f3f3;
            display: block;
            float: left;
            height: 30px;
            line-height: 30px;
            border-bottom: dotted 1px #bbbbbb;
            margin-bottom: 2px;
            width: 100%;
        }
        #productattributelist ul li span
        {
            display: block;
            float: left;
            padding: 0px 5px;
            line-height: 30px;
            height: 30px;
            width: 100px;
            overflow: hidden;
        }
    </style>
    <script type="text/javascript">
        $(function () {

            //分类下拉绑定产品类型
            $("#ddlproductcategory").live("change",function(){
                if($("#ddlproductcategory").val()!="")
                {
                    $.ajax({
                        url:'<%=TREC.ECommerce.ECommon.WebAdminUrl %>/ajax/ajaxproduct.ashx',
                        data:'type=getcategorytype&v='+$("#ddlproductcategory").val(),
                        dataType:'json',
                        success:function(data){
                            $("#ddltype").html("").hide().show();
                            $("#ddltype").append("<option value=\"\">请选择</option>");
                            $.each(data,function(i){
                                $("#ddltype").append("<option value=\""+data[i].id+"\">"+data[i].title+"</option>");
                            });
                        }
                    });
                }
            });

            //品牌下拉。获得系列及绑定品牌数据
            $("#ddlbrand").live("change",function(){
                $.ajax({
                        url:'<%=TREC.ECommerce.ECommon.WebAdminUrl %>/ajax/ajaxuser.ashx',
                        data:'type=getbrands&v='+$("#ddlbrand").val(),
                        dataType:'json',
                        success:function(data){
                            $("#ddlbrands").html("").hide().show();
                            $("#ddlbrands").append("<option value=\"\">请选择</option>");
                            var m="";
                            var s="";
                            var c="";
                            $.each(data,function(i){
                                if(data[i].id!=""&& data[i].title!="")
                                {
                                    $("#ddlbrands").append("<option value=\""+data[i].id+"\">"+data[i].title+"</option>");
                                }
                                s=data[i].s;
                                m=data[i].m;
                                c=data[i].c;
                            });
                            $("#ddlstyle").val(s);
                            $("#ddlmaterial").val(m);
                            $("#ddlcolor").val(c);
                        }
                    });
            })

            //表单验证JS
            $("#form1").validate({
                //出错时添加的标签
                errorElement: "span",
                showErrors: function (errorMap, errorList) {
                    if (errorList.length > 0) {
                        if ($("#" + errorList[0].element.id).next() != null) {
                            $("#" + errorList[0].element.id).next().remove();
                        }
                    }
                    this.defaultShowErrors();
                },
                success: function (label) {
                    //正确时的样式
                    label.text(" ").addClass("success");
                }
            });

            //编辑器
            var editor1,editor2,editor3,editor4,editor5;
            KindEditor.ready(function (K) {
                editor1 = K.create('#txt101', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=product&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
                });
                editor2 = K.create('#txt102', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=product&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
                });
                editor3 = K.create('#txt103', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=product&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
                });
                editor4 = K.create('#txt104', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=product&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
                });
                editor5 = K.create('#txt105', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=product&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
                });
                editordescript = K.create('#txtdescript', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=product&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
                });
            });
            
            //类型名新增js操作效果
            $("#selecttypename").toggle(function(){
                 $("#txtatypename").css("display","block");
                 $(this).text("关闭添加").css("color","#f60");
                 $("#ddltype").val("0");
                 $("#ddltype").val("");
            },function(){
                $("#txtatypename").css("display","none");
                $(this).text("添加其它").css("color","#282828");
            });

            //属性添加按钮
            $("#btnAddAttribute").click(function(){
                var htmlJson="";
                var listHtml="";

                var productType="";
                var productTypeName="";
                var productMaterial="";
                var phfacolor="";
                var pcolortitle="";
                var pacolorimg="";
                var plength="";
                var pawidth="";
                var paheight="";
                var pacbm="";
                var pmarketprice="";

                if(($("#ddltype").val()==""||$("#ddltype").val()=="0") && $("#txtatypename").val()=="")
                {
                    alert("请选择分类-->选择类型,或点击其它新增");
                    return false;
                }

                if($("#ddltype").val()!="" && $("#ddltype").val()!="0"){
                    productType="\"typeid\":\""+$("#ddltype").val()+"\",";
                    productTypeName="\"typename\":\""+$("#ddltype").find("option:selected").text()+"\",";
                    listHtml+="<span>"+$("#ddltype").find("option:selected").text()+"<strong>[类型]</strong></span>";
                }
                else
                {
                    productType="\"typeid\":\"0\",";
                    productTypeName="\"typename\":\""+$("#txtatypename").val()+"\",";
                    listHtml+="<span>"+$("#txtatypename").val()+"<strong>[类型]</strong></span>";
                }
                productMaterial="\"pmaterial\":\""+$("#txtamaterial").val()+"\",";
                phfacolor="\"pacolor\":\""+$("#hfacolor").val()+"\",";
                pcolortitle="\"pcolortitle\":\""+$("#hfacolortitle").val()+"\",";
                pacolorimg="\"pcimg\":\""+$("#hfacolorimg").val()+"\",";
                plength="\"plength\":\""+$("#txtalength").val()+"\",";
                pawidth="\"pwidth\":\""+$("#txtawidth").val()+"\",";
                paheight="\"pheight\":\""+$("#txtaheight").val()+"\",";
                pacbm="\"pcbm\":\""+$("#txtacbm").val()+"\",";
                pmarketprice="\"pmprice\":\""+$("#txtmarketprice").val()+"\"";

                htmlJson='{'+productType+productTypeName+productMaterial+phfacolor+pcolortitle+pacolorimg+plength+paheight+pawidth+pacbm+pmarketprice+'},';
                $("#hfproductattribute").attr("value",$("#hfproductattribute").attr("value")+htmlJson);
                
                listHtml+="<span>"+$("#txtamaterial").val()+"<strong>[材质]</strong></span>";
                listHtml+="<div style=\"float:left; background:#ccc;  width:140px; margin-right:20px; height:30px; line-height:30px;\">";
                listHtml+="<img src=\"<%=ECommon.WebUploadTempUrl %>/"+$("#hfacolorimg").val().substring(0,$("#hfacolorimg").val().length-1)+"\" width='24' line-height:24px; height='24' style='display:block; float:left' />";
                listHtml+="<span style='display:block; float:left; width:60px;  color:"+$("#hfacolor").val()+"; margin-left:3px;'>"+$("#hfacolortitle").val()+"</span>";
                listHtml+="<strong>[颜色]</strong></div>";
                listHtml+="<span>"+$("#txtalength").val()+"<strong>[长]</strong></span>";
                listHtml+="<span>"+$("#txtawidth").val()+"<strong>[宽]</strong></span>";
                listHtml+="<span>"+$("#txtaheight").val()+"<strong>[高]</strong></span>";
                listHtml+="<span>"+$("#txtacbm").val()+"<strong>[体积]</strong></span>";
                listHtml+="<span>"+$("#txtmarketprice").val()+"<strong>[市场价]</strong></span>";

                $("#productattributelist >ul").append("<li title='"+htmlJson+"'>"+listHtml+"<span style='width:20px; color:#f60; text-decoration:underline; cursor:pointer' class='del'  onclick='delattribute(this)' >删</span><span style='width:20px; color:#f60; text-decoration:underline; cursor:pointer'></span></li>");
                //alert($("#hfproductattribute").attr("value"));
            });

        });


        //设置图片信息
        function openImg(i)
        {
            art.dialog.open('productattribute.aspx', {
            title: '设置颜色',
            width:'380px',
            height:'150px',
            ok: function () {
    	        var iframe = this.iframe.contentWindow;
    	        if (!iframe.document.body) {
        	        alert('iframe还没加载完毕呢')
        	        return false;
                };
    	        var form = iframe.document.getElementById('form1'),
                ctitle = iframe.document.getElementById('ctitle'),
    		    cvalue = iframe.document.getElementById('cvalue'),
    		    cimg = iframe.document.getElementById('hfsurface');
                
                $("#hfacolor").attr("value",$(cvalue).val())
                $("#hfacolortitle").attr("value",$(ctitle).val())
                $("#hfacolorimg").attr("value",$(cimg).attr("value"));
                
                var nHtml="";
                nHtml="<img src=\"<%=ECommon.WebUploadTempUrl %>/"+$(cimg).attr("value").substring(0,$(cimg).attr("value").length-1)+"\" width='24' line-height:24px; height='24' style='display:block; float:left' />";
                nHtml+="<span' style='display:block; float:left;  color:"+$(cvalue).val()+"; margin-left:3px;'>"+$(ctitle).val()+"</span>";
                $($(i)).parent().find(".colorSee").html("").hide().show();
                $($(i)).parent().find(".colorSee").html(nHtml);
       	        return true;
            },
            cancel: true});
        }

        //删除属性
        function delattribute(i)
        {
            if($($(i)).attr("title")=='undefined'||$($(i)).attr("title")==null ||$($(i)).attr("title")=="")
            {
                if(confirm("是否确认删除规格!")){
                    $("#hfproductattribute").attr("value",$("#hfproductattribute").attr("value").replace($($(i)).parent().attr("title"),""));
                    $($(i)).parent().remove();
                }
                return false;
            }
            if($($(i)).attr("title")!="" && $($(i)).attr("title")!='undefined')
            {
                if(confirm("是否确认删除规格,该数据原保存，删除后不可恢复! 且与该数据相关店铺价格也会清除!"))
                {
                     $.ajax({
                        url:'<%=TREC.ECommerce.ECommon.WebAdminUrl %>/ajax/ajaxproduct.ashx',
                        data:'type=deleteproductattribute&v='+$($(i)).attr("title"),
                        success:function(data){
                            if(data=="1")
                            {
                                $($(i)).parent().remove();
                            }
                            else
                            {
                                alert("删除错误，找不到数据");
                            }
                        }
                    });
                }
            }
        }

        function editattribute(i)
        {
            if($("#ddlproductcategory").val()=="")
            {
                alert("请选择产品所属分类再修改规格");
                return false;
            }
            art.dialog.data('categoryid', $("#ddlproductcategory").val());
            art.dialog.data('productattributeid',$($(i)).attr("title"));
            art.dialog.open('productattributeedit.aspx?id='+$($(i)).attr("title")+"&c="+$("#ddlproductcategory").val(), {
            title: '修改规格',
            width:'500px',
            height:'400px',
            ok: function () {
    	        var iframe = this.iframe.contentWindow;
    	        if (!iframe.document.body) {
        	        alert('页面正在加载……')
        	        return false;
                };
    	        var form = iframe.document.getElementById('form1'),
                ctitle = iframe.document.getElementById('ctitle'),
    		    cvalue = iframe.document.getElementById('cvalue'),
    		    cimg = iframe.document.getElementById('hfcimg');
                ctypeid=iframe.document.getElementById('ddltype');
                ctypetxtname=iframe.document.getElementById('txttypename');
                ctypl=iframe.document.getElementById('txtlength');
                ctypw=iframe.document.getElementById('txtwidth');
                ctyph=iframe.document.getElementById('txtheight');
                ctypcbm=iframe.document.getElementById('txtcbm');
                ctypmp=iframe.document.getElementById('hfcimg');



                $("#hfacolor").attr("value",$(cvalue).val())
                $("#hfacolortitle").attr("value",$(ctitle).val())
                $("#hfacolorimg").attr("value",$(cimg).attr("value"));
                
                var nHtml="";


                $($(i)).parent().find(".colorSee").html("").hide().show();
                $($(i)).parent().find(".colorSee").html(nHtml);
       	        return true;
            },
            cancel: true});
        }
    </script>
</head>
<body style="padding: 10px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="back"><a href="productlist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 产品管理
            &gt; 产品管理</b>
    </div>
    <div class="spClear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="3" align="left">
                产品信息
            </th>
        </tr>
        <tr>
            <td width="770px" valign="top">
                <table class="formTable" width="770px">
                    <tr>
                        <th colspan="2">
                            基本信息：
                        </th>
                    </tr>
                    <tr>
                        <td align="right" width="70">
                            产品名称：
                        </td>
                        <td>
                            <asp:TextBox ID="txttitle" runat="server" CssClass="input"></asp:TextBox>
                            <label>
                                &nbsp;&nbsp;&nbsp;&nbsp;产品编号：</label>
                            <asp:TextBox ID="txtsku" runat="server" CssClass="input required"></asp:TextBox>
                            <label>
                                &nbsp;&nbsp;&nbsp;&nbsp;定制：</label>
                            <asp:RadioButtonList ID="racustomize" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                <asp:ListItem Text="否" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="是" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            产品分类：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlproductcategory" runat="server" CssClass="select selectNone">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            福家网对应ID：
                        </td>
                        <td>
                            <asp:TextBox ID="txtFID" runat="server">0</asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="spClear">
                </div>
                <table class="formTable" width="770px">
                    <tr>
                        <th colspan="2">
                            品牌信息:
                        </th>
                    </tr>
                    <tr>
                        <td width="70" align="right">
                            选择品牌：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlbrand" runat="server" CssClass="select selectNone">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlstyle" runat="server" CssClass="select selectNone">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlmaterial" runat="server" CssClass="select selectNone">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlcolor" runat="server" CssClass="select selectNone">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="70" align="right">
                            系列：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlbrands" runat="server" CssClass="select selectNone">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">
                            图片信息:
                        </th>
                    </tr>
                    <tr>
                        <td align="right">
                            缩略图：
                        </td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Product, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
                                <asp:HiddenField ID="hfthumb" runat="server" />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files">
                                        <input id="File3" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            详细图：
                        </td>
                        <td>
                            <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Product, ECommon.QueryId, TREC.Entity.EnFilePath.Banner)%>">
                                <asp:HiddenField ID="hfbannel" runat="server" />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files">
                                        <input id="File4" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            首页展示：
                        </td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Product, ECommon.QueryId, TREC.Entity.EnFilePath.HomePageImg)%>">
                                <asp:HiddenField ID="hfhomepageimg" runat="server" />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files">
                                        <input id="File6" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            形&nbsp;象&nbsp;&nbsp;图：
                        </td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Product, ECommon.QueryId, TREC.Entity.EnFilePath.Surface)%>">
                                <asp:HiddenField ID="hfsurface" runat="server" />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files">
                                        <input id="File1" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="70px" align="right">
                            企业标志：
                        </td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Product, ECommon.QueryId, TREC.Entity.EnFilePath.Logo)%>">
                                <asp:HiddenField ID="hflogo" runat="server" />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files">
                                        <input id="File2" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            企业展示：
                        </td>
                        <td>
                            <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Product, ECommon.QueryId, TREC.Entity.EnFilePath.DesImage)%>">
                                <asp:HiddenField ID="hfdesimage" runat="server" />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files">
                                        <input id="File5" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="spClear">
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="spClear">
                </div>
                <table class="formTable" width="1150px">
                    <tr>
                        <th>
                            规格信息:<asp:HiddenField ID="hfproductattribute" runat="server" />
                        </th>
                    </tr>
                    <tr>
                        <td align="right" style="position: relative; display: block; height: 30px;">
                            <label>
                                类型：</label><asp:DropDownList ID="ddltype" runat="server" Width="100" CssClass="select">
                                </asp:DropDownList>
                            <a href="javascript:;" id="selecttypename" style="display: block; float: left; width: 48px;
                                line-height: 24px;">添加其它</a>
                            <input type="text" class="input" id="txtatypename" style="width: 94px; display: none;
                                border-color: #f60; position: absolute; left: 39px; top: 8px;" />
                            <label style="margin-left: 10px;">
                                &nbsp;选材：</label><input type="text" class="input" id="txtamaterial" />
                            <label style="margin-left: 10px;">
                                &nbsp;颜色：</label>
                            <div class="colorSee" style="float: left; background: #ccc; width: 100px; height: 24px;
                                line-height: 24px;">
                            </div>
                            <a href="javascript:;" style="display: block; float: left; width: 30px; line-height: 24px;"
                                onclick="openImg(this)">设置</a>
                            <input type="hidden" class="input" id="hfacolor" style="width: 60px; display: none;" />
                            <input type="hidden" class="input" id="hfacolortitle" style="display: none; width: 60px;" />
                            <input type="hidden" class="input" id="hfacolorimg" style="display: none; width: 60px;" />
                            <label style="margin-left: 10px;">
                                &nbsp;长：</label><input type="text" class="input" id="txtalength" value="0" style="width: 45px;" />
                            <label>
                                &nbsp;宽：</label><input type="text" class="input" id="txtawidth" value="0" style="width: 45px" />
                            <label>
                                &nbsp;高：</label><input type="text" class="input" id="txtaheight" value="0" style="width: 45px" />
                            <label>
                                &nbsp;体积：</label><input type="text" class="input" id="txtacbm" value="0" style="width: 45px" />
                            <label>
                                &nbsp;市场价：</label><input type="text" class="input" id="txtmarketprice" value="0"
                                    style="width: 45px" />
                            <input type="button" class="submit" value="增加" id="btnAddAttribute" />
                        </td>
                    </tr>
                    <tr>
                        <td id="productattributelist">
                            <ul>
                                <%if (listproductattribute != null)
                                  { %>
                                <li><span><strong>[类型]</strong></span> <span><strong>[材质]</strong></span>
                                    <div style="float: left; background: #ccc; width: 140px; margin-right: 20px; height: 30px;
                                        line-height: 30px;">
                                        <span style="display: block; float: left; margin-left: 3px; width: 60px;"></span>
                                        <strong>[颜色]</strong></div>
                                    <span><strong>[长]</strong></span> <span><strong>[宽]</strong></span> <span><strong>[高]</strong></span>
                                    <span><strong>[体积]</strong></span> <span><strong>[市场价]</strong></span> <span><strong>
                                        [活动]</strong></span> <span style='width: 10px; color: #f60; text-decoration: underline;
                                            cursor: pointer' class='del'>操</span> <span style='width: 10px; color: #f60; text-decoration: underline;
                                                cursor: pointer' class='edit'>作</span> </li>
                                <%foreach (EnProductAttribute pa in listproductattribute)
                                  { %>
                                <li><span>
                                    <%=pa.typename%></span> <span>
                                        <%=pa.productmaterial %></span>
                                    <div style="float: left; background: #ccc; width: 140px; margin-right: 20px; height: 30px;
                                        line-height: 30px;">
                                        <img src="<%=string.Format(TREC.Entity.EnFilePath.Product, ECommon.QueryId, TREC.Entity.EnFilePath.ProductAttributeColorImg)%>/<%=pa.productcolorimg %>"
                                            width='24' height='24' style="line-height: 24px; display: block; float: left" />
                                        <span style="display: block; float: left; color: <%=pa.productcolorvalue %>; margin-left: 3px;
                                            width: 60px;">
                                            <%=pa.productcolortitle %></span>
                                    </div>
                                    <span>
                                        <%=pa.productlength %></span> <span>
                                            <%=pa.productwidth %></span> <span>
                                                <%=pa.productheight %></span> <span>
                                                    <%=pa.productcbm %></span> <span>
                                                        <%=pa.markprice %></span> <span>
                                                            <%=GetProdAttrPromName(pa.productAttributePromotion)%></span>
                                    <span style='width: 10px; color: #f60; text-decoration: underline; cursor: pointer'
                                        class='del' onclick='delattribute(this)' title="<%=pa.id %>">删</span> <span style='width: 10px;
                                            color: #f60; text-decoration: underline; cursor: pointer' class='edit' onclick='editattribute(this)'
                                            title="<%=pa.id %>">改</span> </li>
                                <%}
                                  } %>
                            </ul>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table class="formTable">
                    <tr>
                        <th colspan="3">
                            产品描述:
                        </th>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea required kinkeditor"
                                TextMode="MultiLine" Rows="5" Width="960"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="382" align="left">
                            风格特点：
                        </td>
                        <td width="382" align="left">
                            产品细节：
                        </td>
                        <td align="left">
                            材质工艺：
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txt101" runat="server" CssClass="textarea required kinkeditor" TextMode="MultiLine"
                                Rows="5" Width="360"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txt102" runat="server" CssClass="textarea required kinkeditor" TextMode="MultiLine"
                                Rows="5" Width="360"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txt103" runat="server" CssClass="textarea required kinkeditor" TextMode="MultiLine"
                                Rows="5" Width="360"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            保养说明：
                        </td>
                        <td align="left">
                            配送周期：
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txt104" runat="server" CssClass="textarea required kinkeditor" TextMode="MultiLine"
                                Rows="5" Width="360"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txt105" runat="server" CssClass="textarea required kinkeditor" TextMode="MultiLine"
                                Rows="5" Width="360"></asp:TextBox>
                        </td>
                        <td>
                            <table class="formTable" width="380">
                                <tr>
                                    <th colspan="2">
                                        产品分类状态:
                                    </th>
                                </tr>
                                <tr>
                                    <td align="right">
                                        推荐属性：
                                    </td>
                                    <td>
                                        <asp:CheckBoxList ID="chkattribute" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        审核状态：
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlauditstatus" runat="server" CssClass="select selectNone"
                                            Width="160">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        上/下线：
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddllinestatus" runat="server" CssClass="select selectNone"
                                            Width="160">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        排序 ：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtsort" runat="server" CssClass="input w160 required digits">0</asp:TextBox>
                                    </td>
                                </tr>
                                <%if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
                                  { %>
                                <tr>
                                    <td align="right">
                                        点击量 ：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txthits" runat="server" CssClass="input w160 required digits">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        最后修改 ：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtlastedittime" runat="server" CssClass="input Wdate w160 required"
                                            onfocus="WdatePicker()"></asp:TextBox>
                                    </td>
                                </tr>
                                <%} %>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div style="margin-top: 10px; margin-left: 180px">
        <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" OnClick="btnSave_Click" /><input
            name="重置" type="reset" class="submit" value="重置" />
    </div>
    </form>
</body>
</html>
