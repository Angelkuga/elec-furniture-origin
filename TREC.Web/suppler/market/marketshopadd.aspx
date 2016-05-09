<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true"
    CodeBehind="marketshopadd.aspx.cs" Inherits="TREC.Web.Suppler.market.marketshopadd" %>

<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Import Namespace="TREC.ECommerce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"
        type="text/javascript"></script>
    <script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/ymPrompt.js"
        type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../css/DropDownListMenu.css" />
    <link href="../resource/css/ymPrompt/simple_gray/ymPrompt.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../script/myPublic.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/editor/kindeditor/kindeditor-min.js"></script>
    <script src="../script/oms_autocomplate.js" type="text/javascript"></script>
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
            <u>添加商家</u></h1>
    </div>
    <div class="maincon">
        <div class="maintabcor">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                    <td height="35" style="width: 5%" align="left">
                            场馆
                        </td>
                        <td>
                            <asp:DropDownList ID="drop_pav" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td height="35" style="width: 5%" align="left">
                            楼层
                        </td>
                        <td align="left" style="width: 12%" class="l">
                            <asp:DropDownList ID="ddlmarketstory" runat="server">
                            </asp:DropDownList>
                            <span class="tip">*</span> <a onclick="setMarketStroey()" title="点击设置楼层数" class="myhander">
                                <img width="16" height="16" border="0" src="../Images/fatcow_466.png"></a>
                        </td>
                        <td style="width: 12%" align="right">
                            商家店铺编号
                        </td>
                        <td style="width: 20%">
                            <input type="text" maxlength="15" name="marketshopposition" id="marketshopposition"
                                class="input" style="width: 120px" runat="server" /><span class="tip">*</span>
                        </td>
                        <td height="35" style="width: 8%" align="left">
                            品牌名称
                        </td>
                        <td style="text-align: left;" colspan="3">
                            <div class="nav">
                                <input type="text" size="34" name="brandName" id="brandName" maxlength="50" style="width: 150px"
                                    runat="server" /><span class="tip">*</span>
                                <script type="text/javascript">
                                    $('#<%=brandName.ClientID %>').oms_autocomplate({ url: '../ajax/MemberHandler.ashx?Action=searchbrand&key=' + $('#<%=brandName.ClientID %>').val() + '&ram=' + Math.random(), inputWidth: 304, inputHeight: 27, paramTypeSelector: "#<%=brandName.ClientID %>" });
                                </script>
                            </div>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="btnone">
                <asp:Button ID="btnSave" runat="server" OnClientClick="return checkInput();" Text="保存"
                    CssClass="btnl" OnClick="btnSave_Click" />
                <input name="重置" type="reset" class="btnl" id="btnRequest" value="重置" runat="server" />
            </div>
        </div>
    </div>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/fileupload.js"></script>
    <script type="text/javascript" src="../script/myPublic.js"></script>
    <script type="text/javascript" src="../script/formValidatorRegex.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript">
     $( function () {
     
        //弹出的删除提示框始终位于屏幕中间
        $(window).scroll(function () {
            if ($('.pop').size() != 0) {
                $('.pop').css('top', ($(window).height() - $('.pop').height()) / 2 + $(document).scrollTop() + 'px');
                $('.pop').css('left', ($(window).width() - $('.pop').width()) / 2 + 'px');
            }
        });
         $("#<%=marketshopposition.ClientID %> ").click(function () {
             var msk = $("#<%=ddlmarketstory.ClientID %> option:selected");
             if (msk.val() == "") {
                 alert("请先选择楼层");
                 $("#<%=ddlmarketstory.ClientID %>").focus();
                 return false;
             }
         });

         $("#<%=marketshopposition.ClientID %> ").blur(function () {
             var msk = $("#<%=ddlmarketstory.ClientID %> option:selected");
             var msposition = $("#<%=marketshopposition.ClientID %> ");
             if (msk.val()!="" && msposition.val()!="") {  
             
             var marketid=<%=marketid %>;
             if (marketid!=0) {    
             $.ajax({
                 url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl.TrimEnd('/') %>/ajax/ajaxproduct.ashx',
                 data: 'type=checkmarketposition&v=' + msk.val() + "&v2=" + msposition.val() + "&v3="+marketid+"&ram=" + Math.random(),
                 dataType: 'html',
                 success: function (data) {
                     if (data == "ok") {
                         alert("该楼层下编号已经有商家店铺入住，请更改!");                      
                         msposition.val("");
                         msposition.focus();
                     }
                     }
             });
             } 
              }  
         });
         
     });

     function setMarketStroey()
     {     
       if (0 < $('.pop').size()) {
            $('.pop').remove();
        }
        var html = '<div class="pop bord">';
        html += '  <h1><u>请输入您的卖场一共有多少层</u><i>X</i></h1>';
        html += '  <div class="popcon"    style="width:280px">';
        html += '   <table width="100%" border="0" cellpadding="0" cellspacing="0">';
        html += '      <tr>';
        html += '        <td height="35" align="right">总层数</td>';
        html += '        <td style="text-align:left;"><input type="text" style="width:40px" id="storeynum" name="storeynum" value="" maxlength="2" /><span class="tip">*</span></td>';         
             html += '      </tr>';
        html += '    </table>';
           html += '    <div class="btnone">';
          html += '  <input type="button" value="确定" onclick="saveMarketStorey(this);" class="btnlitl" />';
        html += '  <input type="reset" value="取消" class="btnlitr" />';
        html += '  </div>';
        html += '  </div>';
        html += '</div>';
                $(html).insertAfter($('.mainbox'));
         PositionBox();
     }

       function PositionBox() {
        $('.pop').css('top', ($(window).height() - $('.pop').height()) / 4 + $(document).scrollTop() + 'px');
        $('.pop').css('left', ($(window).width() - $('.pop').width()) /2 + 'px');
        $('.pop i').click(function () {
            $('.pop').remove();
        });
        if (0 < $('.pop .btnlitr').size()) {
            $('.pop .btnlitr').click(function () {
                $('.pop').remove();
            });
        }
    }
    function saveMarketStorey(th)
    {     
    var marketStorey=$("#storeynum");
      if (marketStorey.val()=="") {
    alert("请输入楼层数！");
    marketStorey.focus();
    return ;
}
 var reg = new RegExp(regexEnum.intege1);
 if (!reg.test(marketStorey.val())) {
    alert("请输入正确的楼层数！");
    marketStorey.focus();
    return ;
}
if (confirm("如果已经设置过楼层数，此操作将会删除已经设置的楼层数并重新设置楼层数！确定吗?")) {
      //保存楼层数
   $.ajax({
                 url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxproduct.ashx',
                 data: 'type=setmarketstorey&v=' + marketStorey.val()+"&ram=" + Math.random(),
                 dataType: 'html',
                 success: function (data) {
                     if (data == "ok") {
                         alert("设置楼层成功!");   
                         $('.pop').remove();       
                         window.location.reload();                                     
                     }else {
                    alert("设置楼层失败!");   
                        }
                     }
             });
}


    }

     function loadId(id,title)
     {  
         $("#<%=brandName.ClientID %>").val(title);
         }

     function checkInput() {
         var msk = $("#<%=ddlmarketstory.ClientID %> option:selected");
         if (msk.val() == "") {
             alert("请选择楼层");
             $("#<%=ddlmarketstory.ClientID %>").focus();
             return false;
         }
         var msposition = $("#<%=marketshopposition.ClientID %> ");
         if (msposition.val() == "") {
             alert("请输入商家店铺编号");
             msposition.focus();
             return false;
         }
       
         var brandName = $("#<%=brandName.ClientID %> ");
         if (brandName.val() == "") {
             alert("请输入品牌名称");
             brandName.focus();
             return false;
         }
         return true;
     }
    </script>
</asp:Content>
