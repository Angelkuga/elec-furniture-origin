<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopBrand.aspx.cs" Inherits="TREC.Web.template.web.ShopBrand" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Collections" %>

<%@ Register Src="ascx/headerbrand.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>家具快搜-品牌</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7;IE=9;IE=8">
 <ucnewresource:newresource ID="newresource1" runat="server" />
 
    <script src="/resource/script/jquery-1.7.1.min.js" type="text/javascript"></script>
      <script src="/resource/page/page.js" type="text/javascript"></script>
       <link href="../../../resource/content/css/brand/brand.css" rel="stylesheet" type="text/css" />
    <link href="/resource/page/page.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .tab_con
        {
            padding: 10px;
            display: none;
            overflow: hidden;
            height: 80px;
        }
        .nbrand_c
        {
            width:464px;
            height:214px;
            border-width : 1px;
	border-color : #E7E3E7;
	border-style : solid;
        }
        .nbrand_c1
        {
    border-right-width : 1px;
	border-right-color : #E7E3E7;
	border-right-style : solid;
	width:240px;
	height:214px;
        }
        .nbrand_c1right
        {
            width:223px;
            height:55px;
             border-bottom-width : 1px;
	        border-bottom-color : #E7E3E7;
	        border-bottom-style :dashed;
        }
        .nbrand_c1rightspan
        {
            color:#CC0000;font-size:14px;font-weight:bold;
            margin-top:2px;
            margin-right:5px;
        }
        .nbrand_c1rightdiv
        {
            float:left;
            margin-left:5px;
            margin-right:5px;
            padding-top:2px;
            padding-bottom:2px;
            padding-left:2px;
            background-color:#F5F5F5;
            margin-top:5px;
            width:210px;
        }
        .nbrand_c2r
        {
             border-bottom-width : 1px;
	        border-bottom-color : #E7E3E7;
	        border-bottom-style :solid;
	        width:700px;
	        margin-left:30px;
        }
        .nbrand_c2r1
        {
              border-width : 1px;
	        border-color : #E7E3E7;
	        border-style :solid;
	        
	          border-bottom-width : 0px;
	        
            background-color:#B9003C;
            padding:6px 12px 6px 12px;
            width:60px;
            color:White;
            font-size:13px;
            font-weight:bold;
        }
        .nbrand_c2rlist
        {
            margin-top:12px;
        }
         .nbrand_c2rlist img
         {
             width:125px;
             height:62px;
         }
        .nbrand_c2rlist li
        {
            float:left;
             width:125px;
             height:62px;
             margin-top:20px;
             margin-right:20px;
             margin-left:15px
        }
        .shoptop
        {
            width:1200px;
            height:30px;
            margin-top:10px;
             border-bottom-width : 2px;
	        border-bottom-color : #333333;
	        border-bottom-style :solid;
	        float:left;
        }
         .shoptop td
         {
             height:30px;
             padding-left:10px;
             padding-right:10px;
         }
         .shoptopcheck
         {
             background-color:#B9003C;
             color:White;
         }
         .shopli
         {
             min-height:20px;
             width:1200px;
             height:auto;
             margin-top:10px;
             float:left;
         }
         .shopli ul
         {
             float:left;
         }
         .shopli li
         {
             
             width:550px;
             height:190px;
             float:left;
               border-width : 1px;
	border-color : #E7E3E7;
	border-style : solid;
	margin:5px 20px 5px 20px;
         }
      
          .shopli li table
          {
              margin:2px 2px 2px 2px;
          }
         .shopli_td2
         {
             width:330px;
         }
         .shopli_td2_t
         {
             font-size:15px;
             font-weight:bold;
             color:#B50000;
             padding-left:5px;
             padding-top:4px;
             
         }
         .shopli_td2_t div
         {
            float:right;
          }
         .shopli_td2_t a
         {
           color:#B50000;
         }
         .shopli_td2_s
         {
              font-size:13px;
             font-weight:bold;
             padding-left:5px;
             padding-top:4px;
             color:#5D5D5D;
          
         }
         .shopli_td2_s span
         {
             color:#FB864D;
         }
         .divnopay
         {
             font-size:13px;
             font-weight:bold;
             padding-left:5px;
             padding-top:4px;
             padding-bottom:4px;
             color:#fff; 
             background-color:#fb864d;
             width:150px;
             margin-left:10px;
             cursor:pointer;
             margin-top:40px;
         }
           .shopli_td2_h
         {
              font-size:13px;
             font-weight:bold;
             padding-left:5px;
             padding-top:8px;
             color:#333399;
          
         }
          .shopli_td2_h a
          {
                 color:#333399;
          }
          
          .shoppro
          {
              width:970px;
          }
           .shoppro ul
           {
               width:100%;
            }
            .shopproul
            {
                float:left;
            }
            .shopproul li
            {
                width:230px;
                height:273px;
                float:left;
                  border-width : 1px;
	            border-color : #E7E3E7;
	            border-style : solid;
	            margin:5px 5px 5px 5px;
            }
            .shoppro img
            {
                max-width:218px;
                margin-top:3px;
                max-height:161px;
            }
            .shoppro_title
            {
              font-size:12px;
              color:#333333;
              padding-left:5px;
              padding-top:2px;
            }
            .shoppro_p1
           {
                font-size:12px;
              color:#BFBFBF;
              padding-left:5px;
              padding-top:2px;
           }
             .shoppro_p2
           {
                font-size:12px;
              color:#B80B0F;
              padding-left:5px;
               padding-top:2px;
           }
          .shoppro_adver
          {
             
          }
          .shoppro_adver img
          {
               margin-bottom:5px;
                margin-top:5px;
          }
    .tipmessage
    {
        position:absolute;
         width:160px;
            height:25px;
	 padding:5px; 
    border: 1px solid #FFC176;
    -moz-border-radius: 5px;      /* Gecko browsers */
    -webkit-border-radius: 5px;   /* Webkit browsers */
    border-radius:5px;            /* W3C syntax */
    background-color:#FFFCED;
    display:none;
    z-index:1000;
        }
    </style>

       <link href="/resource/page/page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc1:header ID="header1" runat="server" />
     <div class="brand-mod w clearfix">
        <div class="cont-l fl">
        <div class="tab" id="j_brandTab" style="width: 1200px;">
                <div class="hd clearfix">
                    <ul class="fl">
                        <%=hletter%>
                    </ul>
                   
                </div>
                
            </div>
            <!---店铺独立 begin-------->
            <div style="margin-top:10px;">
            <table border="0" cellpadding="0" cellspacing="0">
            <tr>
            <td style="width:464px;" align="left" valign="top">
            <div class="nbrand_c">
           <table border="0" cellpadding="0" cellspacing="0"><tr>
           <td  align="center" class="nbrand_c1">
         <img src="http://www.jiajuks.com<%=companyLog %>"  style="width:218px;margin-top:8px;height:47px;"/>
          <%=companybrand%>
           </td>
           <td  valign="top">
           <div class="nbrand_c1right">
            <span class="nbrand_c1rightspan" style="margin-left:5px;margin-top:2px;">厂商</span>
             <span class="nbrand_c1rightspan" style="font-size:13px;margin-top:2px;float:right;"><%=companyjr%></span>
            <div class="nbrand_c1rightdiv">
         <%=companytitle %>
            </div>
           </div>

           <div class="nbrand_c1right">
           <div style="padding-left:4px;padding-top:5px;line-height:25px;padding-bottom:2px;">
           <strong>风格：</strong><%=companystyle %><br />
           <strong >材质：</strong><%=companymaterial%>
           </div>
           </div>
            
            <div  style="width:100%;">
            <div class="nbrand_c1rightdiv" style="padding-top:3px;padding-bottom:3px;margin-top:10px;">
           <div>地址：<%=companyaddress%></div>
            <div style="margin-top:8px;">电话：<span style="color:#D70D00;"><%=companyphone%></span></div>
            </div>

            
            </div>
           </td>
           </tr> </table>
            </div>
             </td> <td align="left" valign="top">
             <div class="nbrand_c2r">
             <div class="nbrand_c2r1">旗下品牌</div>
             <div class="nbrand_c2rlist">
             <ul>
                 <asp:Repeater ID="Repeater_companybrand" runat="server">
                 <ItemTemplate>
                  <li><a href="<%=companyurl %>"  target="_blank"><img src="http://www.jiajuks.com/upload/brand/logo/<%#Eval("id") %>/<%#Eval("logo").ToString().Replace(",","") %>" /></a> </li>
                 </ItemTemplate>
                 </asp:Repeater>
            
             </ul>
             </div>
              </div>
             </td> </tr>
            </table>
            </div>

            <div class="shoptop">
            <table border="0" cellpadding="0" cellspacing="0" id="tab_brand"><tr>
            <td class="shoptopcheck" onmouseover="checkareacode('0')" id="btable_td0">
            销售店铺
            </td> 
            <%=tdarea%>
            </tr> </table>
            </div>

            <div class="shopli">
            <ul id="ulshoplist">
                <asp:Repeater ID="Repeater_brandshop" runat="server">
                <ItemTemplate>
            <li areacode='<%#Eval("areacode") %>'>
            <table border="0" cellpadding="0" cellspacing="0"><tr>
            <td>
           
            <a href="/shop/<%#Eval("Id") %>/index.aspx" target="_blank">
            <img src="http://www.jiajuks.com/upload/shop/thumb/<%#Eval("Id") %>/<%#Eval("thumb").ToString().Replace(",","") %>"  style="width:256px;height:185px;"/>
            </a>
          
             </td>
             <td class="shopli_td2" align="left" valign="top">
             <div style="width:100%;float:left;display:none;"><span style="float:right;margin-right:5px;"><%#Eval("ctypename") %></span></div>
             <div class="shopli_td2_t"><a href="/shop/<%#Eval("Id") %>/index.aspx" target="_blank"> <%#Eval("Title") %></a>
               <asp:Panel ID="Panel_qq" runat="server" Visible='<%#ispay(Eval("companyispay"),"1") %>'>
              <%#getqq(Eval("qq"))%>
                </asp:Panel>
               </div>
             <div class="shopli_td2_s">经销品牌：<span><%=bname%></span>品牌风格：<span><%#Eval("stylename")%></span></div>
                 <asp:Panel ID="Panel_address" runat="server" Visible='<%#ispay(Eval("companyispay"),"1") %>'>
             <div class="shopli_td2_s" ><table border="0" cellpadding="0" cellspacing="0"><tr><td style="width:42px;" valign="top"> 地址：</td><td ><%#getAddress(Eval("areacode"), Eval("Address"))%></td> </tr> </table></div>
             <div class="shopli_td2_s" >电话：<%#Eval("phone")%></div>
             <div> <%#gethd(Eval("promotion"))%></div>
               </asp:Panel>

               <div style="display:none;">
               <asp:Panel ID="Panel_nopay" runat="server" Visible='<%#ispay(Eval("companyispay"),"0") %>'>
              <div class="divnopay" onclick="messagedshow(event)">查看展位号,联系方式</div>
               </asp:Panel>
               </div>
              </td>
              </tr> </table>
            </li>
            
                </ItemTemplate>
                </asp:Repeater>
            </ul>
            </div>

       
            <div class="shoptop">
            <table border="0" cellpadding="0" cellspacing="0" id="tableprolist"><tr>
            <td class="shoptopcheck" id="tdprotitle1" onmouseover="proselect(1)">
            推荐产品
            </td> 
            <td id="tdprotitle2" onmouseover="proselect(2)">
            促销产品
            </td>
            <td style="display:none;">
            活动信息
            </td>
            
            </tr> </table>
            </div>

            <div style="width:1200px;height:auto;float:left;">
            <table border="0" cellpadding="0" cellspacing="0">
            <tr>
            <td  class="shoppro" align="left" valign="top">
            <ul id="ulshopproc" class="shopproul">


          

            </ul>
          <center><br />
          <span id="paging1" class="page" ></span></center>
             </td>
             <td align="left" valign="top" class="shoppro_adver">
                 <asp:Repeater ID="Repeater_adver" runat="server">
                 <ItemTemplate>
             <a href="<%#Eval("linkurl") %>" target="_blank"><img src="/upload/show/thumb/<%#Eval("Id") %>/<%#Eval("imgurl").ToString().Replace(",","") %>"  style="width:230px;height:258px;"/> </a>
              </ItemTemplate>
                 </asp:Repeater>
             </td>
            </tr>
             </table>
            </div>
            <!----店铺独立 end------->
        </div>
        </div>
          <div class="tipmessage" id="diverrorshow">对不起，商家权限尚未开放</div>
        <input type="hidden" id="protype"  value="1"/>
        <uc2:footer runat="server" ID="footer1" />
        <script language="javascript">
            function checkareacode(code) {
                $("#tab_brand td").attr("class", "");
                $("#btable_td" + code).attr("class", "shoptopcheck");
                if (code == '0') {
                    $("#ulshoplist li").show();
                }
                else {
                    $("#ulshoplist li").hide();
                    $("#ulshoplist li").each(
                function (i) {
                    if ($(this).attr("areacode") == code) {
                        $(this).show();
                    }
                }
                );
                }
        }

        function proselect(id) {
            $("#protype").val(id);
            $("#tableprolist td").attr("class", "");
            $("#tdprotitle" + id).attr("class", "shoptopcheck");
            showlist(1);
        }
        function showlist(p) {
            $.post("/ajax/ShopBrandData.aspx", { "brandtitle": "<%=bname %>", "pageindex": p, "t": $("#protype").val() }, function (data, textStatus) {
                $("#ulshopproc").html(data.split('■')[0]);
                if (parseInt(data.split('■')[1]) > 40) {
                    $("#paging1").pagination({
                        items: data.split('■')[1],
                        cssStyle: 'light-theme',
                        itemsOnPage: 40,
                        callFn: "showlist",
                        currentPage: p
                    });
                }
            }, null);
        }
        showlist(1);


        function showp() {
            $("#divshowpay").show();
            setTimeout("showpout()", 4000);
        }
        function showpout() {
            $("#divshowpay").hide(1000);
        }


        function messagedshow(e) {
            $("#diverrorshow").show();
            var pointX = e.pageX;
            var pointY = e.pageY;
            $("#diverrorshow")[0].style.top = pointY + 'px';
            $("#diverrorshow")[0].style.left = pointX + 'px';
            setTimeout("messagedhide()", 3000)
        }

        function messagedhide() {
            $("#diverrorshow").hide(500);
        }

        </script>
    </form>
</body>
</html>
