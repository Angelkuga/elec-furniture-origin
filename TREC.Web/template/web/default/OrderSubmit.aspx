<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderSubmit.aspx.cs" enableviewstatemac="false" Inherits="TREC.Web.template.web.default2.OrderSubmit" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>

<!DOCTYPE HTML>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="/resource/content/js/jquery-1.4.1.min.js"></script>
       <script src="/resource/content/js/core.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" name="form1" method="post" action="OrderNumber.aspx" runat="server">
    <uc1:header ID="header1" runat="server" />
       <link href="/resource/ShoppingCss/shopping.css" rel="stylesheet" type="text/css" />
    

   <div class="site" ><a href="/">首页</a> > 购物车</div>
<div class="contentInner">
  <div class="inner">
    <div class="shopping"> 
      <!--step end--> 
      <!--step start-->
      <div class="buystep buybg02">
        <ul>
          <li class="wordn"><span>1.</span>我的购物车</li>
          <li class="wordh"><span>2.</span>填写核对订单信息</li>
          <li class="wordn"><span>3.</span>成功提交订单</li>
        </ul>
      </div>
      
      <div id="UpdatePanel1">
        <div class="shopInner">
          <h1 class="btitle">填写订单信息</h1>
          <div class="part1" id="fillorderinfo">
            <div class="bd">
              <div class="block1">
                <div class="hd2" id="myfilelist"> <span>收货人信息<a name="step1" class="">&nbsp;</a></span> [
                  <a href="javascript:addreshow()" style="color:#0e6eba;font-size:16px;" id="addreoperA">收起</a>
                  ]
                  &nbsp;&nbsp;[
                  <a href="javascript:Newsaddress()" style="color:#0e6eba;font-size:16px;">新增</a>
                  

                  ] <span id="step1Stip" class="stepErrorTip" style="">请保存收货人信息</span> </div>
                <div class="bd2" id="divaddressList">
                
                </div>
                <div class="bd2" id="divaddressup" style="display:none;">
                  <div id="Div_address" class="shopuserInfo">
                    <table width="100%">
                      <tbody>
                        <tr>
                          <td width="80" style="text-align:right;"> 收货人： </td>
                          <td><input name="add_ID" type="hidden" id="add_ID">
                            <input name="Consignee" type="text" id="Consignee" class="i1" maxlength="10">
                            <font style="color:#8b1e21;font-size:13px;">*</font><span id="RequiredFieldValidator1" style="color:Red;visibility:hidden;"><strong>必填项 </strong></span></td>
                        </tr>
                        <tr>
                          <td style="text-align:right;"> 地址： </td>
                          <td width="470">
                          <select name="SelProvince" onchange="SelPCity()" id="SelProvince" style="width:75px;">
                            </select>
                            <select name="SelCity" onchange="selPArea()" id="SelCity" style="width:75px;">
                              <option selected="selected" value="0">--城市--</option>
                            </select>
                            <select name="selArea"  id="selArea" style="width:75px;">
                              <option selected="selected" value="0">--区--</option>
                            </select>
                            <input name="Address" type="text" id="Address" class="i1" maxlength="50"/>
                            <font style="color:#8b1e21;font-size:13px;">*</font><span id="RequiredFieldValidator3" style="color:Red;visibility:hidden;"><strong>必填项 </strong></span></td>
                          <td> 邮编：
                            <input name="Zipcode" type="text" id="Zipcode" class="i1" style="width:50px;" maxlength="6"/>
                            <span id="RegularExpressionValidator3" style="color:Red;visibility:hidden;"><strong>邮 编</strong></span></td>
                        </tr>
                        <tr>
                          <td style="text-align:right;"> 手机： </td>
                          <td><input name="Mobile" type="text" id="Mobile" class="i1" onblur="JudgeTelephone('Mobile')" maxlength="15">
                            <font style="color:#8b1e21;font-size:13px;">*</font><span id="RequiredFieldValidator4" style="color:Red;visibility:hidden;"><strong>必填项</strong></span> <span id="RegularExpressionValidator1" style="color:Red;visibility:hidden;"><strong>手机格式不正确</strong></span></td>
                        </tr>
                        <tr>
                          <td style="text-align:right;"> 电话： </td>
                          <td><input name="Phone" type="text" id="Phone" class="i1" maxlength="15"/>
                            <span id="RegularExpressionValidator2" style="color:Red;visibility:hidden;"><strong>固定电话格式不正确</strong></span></td>
                        </tr>
                        <tr>
                          <td style="text-align:right;"> 邮箱： </td>
                          <td><input name="Email" type="text" id="Email" class="i1" value="" onblur="JudgeMail('Email')" maxlength="30">
                            <font style="color:#8b1e21;font-size:13px;">*</font><span id="RequiredFieldValidator5" style="color:Red;visibility:hidden;"><strong>必填项</strong></span> <span id="RegularExpressionValidator4" style="color:Red;visibility:hidden;"><strong>邮箱格式不正确</strong></span></td>
                        </tr>
                        <tr>
                          <td style="text-align:right;"> 传真： </td>
                          <td><input name="Fax" type="text" id="Fax" class="i1" maxlength="30"></td>
                        </tr>
                        <tr>
                          <td>&nbsp;</td>
                          <td>
                          <div id="submsg">新增</div>
                          <img src="/resource/content/images/wait.gif"  id="imgwait" style="display:none;"/>
                          <img src="/resource/ShoppingCss/baocun.gif"  onclick="addsubmit()" id="imgsubmit"/>
                          </td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                </div>
              </div>

              <div class="block1 line">
                <div class="hd2"> <span>运费安装费</span></div>
                <div class="bd2">
                 <div style="padding-left:20px;"> 
                 <span style="font-size:12px;">(以跟我们客服销售确认的费用标准为准)</span><br />
                 运费：￥<input type="text" style="width:60px;"  maxlength="6" value="0" id="inputyf1" name="inputyf1" onblur="disFree('1')"/>元
                 安装费：￥<input type="text" style="width:60px;" maxlength="6" value="0" id="inputyf2" name="inputyf2" onblur="disFree('2')"/>元
                 </div>
                </div>
              </div>

              <div class="block1 line">
                <div class="hd2"> <span>配送方式</span></div>
                <div class="bd2">
                  <div style="padding-left:20px;font-size:12px;">
                  <input type="radio"  name="sendgroup" value="1" checked="checked"/>只工作日送货(双休日假日不送货)<br />
                   <input type="radio"  name="sendgroup" value="2" />工作日,双休日与节假日均可送货<br />
                    <input type="radio"  name="sendgroup" value="3" />只双休日节假日送货(工作日不送货)
                  </div>
                </div>
              </div>
              <div class="block1 line">
                <div class="hd2"> <span>发票信息</span></div>
                <div class="bd2">
                  <div style="padding-left:20px;font-size:12px;">
                  <table border="0">
                  <tr>
                  <td>是否开发票:</td><td><input type="checkbox"  id="checkInvoice" name="checkInvoice" checked="checked"/> </td>
                  </tr>

                  <tr>
                  <td>发票抬头：</td><td><input type="text"  id="InvoiceTop" name="InvoiceTop" style="width:300px;" maxlength="100"/> </td>
                  </tr>
                    <tr>
                  <td>快递地址：</td><td><input type="text" id="InvoiceAddress" name="InvoiceAddress" style="width:300px;" maxlength="100"/> </td>
                  </tr>
                       <tr>
                  <td>邮编：</td><td><input type="text" id="InvoiceZipcode" name="InvoiceZipcode"  style="width:100px;" maxlength="6"/> </td>
                  </tr>
                  </table>
                  </div>

                </div>
              </div>
              <div class="block1 line">
                <div class="hd2"> <span>订单备注</span>  </div>
                <div class="bd2">
                  <div style="padding-left:20px;font-size:12px;">
                  
                      <textarea id="Description" name="Description" cols="50"  rows="4"></textarea></div>
                </div>
              </div>
              <div class="block1 line" style="display:none;">
                <div class="hd2"> <span>积分/优惠券</span> [
                  <input type="submit" name="ImageButton7" value="修改" id="ImageButton7">
                  ]<span id="step5Stip" class="stepErrorTip" style=""> 订单积分/优惠券信息</span> </div>
                <div class="bd2">
                  <div id="orderjifen2" class="">
                    <p class="p1"> 积分抵扣：<span id="s15">0</span>元</p>
                    <p class="p1"> 优惠券抵扣： <span id="s16">0</span> </p>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="part1">
            <div class="hd">
              <input name="currentcartitem" type="hidden" id="currentcartitem" value="[{&quot;CarId&quot;:3154,&quot;ID&quot;:6171,&quot;Num&quot;:1,&quot;AttributeProductId&quot;:&quot;7118&quot;,&quot;ProductGroupId&quot;:0,&quot;ProductGroupPrimaryKey&quot;:&quot;&quot;,&quot;Proportion&quot;:0,&quot;MarkInfo&quot;:&quot;&quot;,&quot;pName&quot;:&quot;5A899-A&quot;},{&quot;CarId&quot;:3155,&quot;ID&quot;:6142,&quot;Num&quot;:1,&quot;AttributeProductId&quot;:&quot;7089&quot;,&quot;ProductGroupId&quot;:0,&quot;ProductGroupPrimaryKey&quot;:&quot;&quot;,&quot;Proportion&quot;:0,&quot;MarkInfo&quot;:&quot;&quot;,&quot;pName&quot;:&quot;12E830-3&quot;}]">
              <span class="s1">购物车商品清单：共计商品 = </span><span class="s3"><b style="color:#cf293b">&nbsp;<%=buyCount%> 
              件</b> </span><span class="s2">
              <%--<input type="image" src="/resource/ShoppingCss/shoppingback.jpg" onclick="window.location = '/purchase/shoppingcart.aspx'">--%>
            <a href="/shoppingTrolley.aspx"><img src="/resource/ShoppingCss/shoppingback.jpg" border="0" /></a>
              </span></div>
            <div class="bd" style="width:100%;padding:0;margin:0;">
              <div class="shoppingDetailList" style="padding:0;" id="shoppingDetailList">
                <table width="100%">
                  <tbody>
                    <tr class="shoppingDetailListTRHD">
                      <th width="13%" style="padding-left:20px;" scope="col"> 商品编号 </th>
                      <th width="25%" scope="col"> 产品名称 </th>
                      <th width="15%" scope="col"> 尺寸 </th>
                      <th width="10%" scope="col"> 颜色 </th>
                      <th width="15%" scope="col"> 单价 </th>
                      <th width="10%" scope="col"> 购买数量 </th>
                    </tr>
                      <asp:Repeater ID="Repeater_data" runat="server">
                      <ItemTemplate>
                    <tr>
                      <td style="padding-left:20px;">
                      <span id="span_6171" name="spanproductall"><%#Eval("proid") %></span></td>
                      <td><a target="_blank" class="a1" href='/productinfo.aspx?id=<%#Eval("proid") %>'><%#Eval("Title") %></a></td>
                      <td class=""><%#Eval("Big") %></td>
                      <td class=""> <%#Eval("productcolortitle")%> </td>
                      <td><strong class="gray">￥<span id="spanprice_6171"><%#Eval("resultPrice")%></span></strong></td>
                      <td><span id="spannum_6171"> <%#BuyCount(Eval("Sid").ToString())%> </span></td>
                    </tr>
                       </ItemTemplate>
                      </asp:Repeater>
                    
                    
                  </tbody>
                </table>
                <script>
                    function MarkInfo(id, t) {
                        if (t == "show") {
                            $("#mark_" + id).show();
                            $("#coler_" + id).show();
                            $("#show_" + id).hide();
                        } else if (t == "coler") {
                            $("#mark_" + id).hide();
                            $("#coler_" + id).hide();
                            $("#show_" + id).show();
                        }
                    }
                                                    </script>
                <div> </div>
              </div>
            </div>
          </div>
          <div class="part1" id="accountinfo" style="margin-bottom:0;">
            <div class="hd"> <span class="s1">结算信息</span><span class="s2"></span></div>
            <div class="bd" style="width:100%;padding:0;margin:0;">
              <div class="shoppingDetailLast" style="padding:0;">
                <div class="d1" style="display:block;border-bottom:none;">
                  <p id="P_Calculation" class="p1" style="width:92%;">商品总价：<span id="peicemsg_all_0">￥<%=allprice %></span> 元&nbsp;&nbsp;&nbsp;&nbsp;运费：￥<span id="spanyf1">0</span> 元&nbsp;&nbsp;&nbsp;&nbsp;安装费：￥<span id="spanyf2">0</span>元<br>应付总金额：<span id="peicemsg_all_1">￥<%=allprice%>元</span></strong></p>
                  <p id="P_ScorePoints" class="p2" style=" line-height:50px; font-size:14px; margin-top:0; width:auto; display:none;">本次交易可获得积分：35分。</p>
                </div>
                <div class="d2" style="display:none;">
                  <p id="P_isEarnestmoney" class="p1"> 本次订单支持全额付款和预付定金 ( 定金为总金额的50% )<br>
                    全额付款：￥3,585.00元 全额付款可获得本次交易全部积分 <br>
                    预付定金：￥1,792.50元 预付定金可获得本次交易50%积分</p>
                  <p></p>
                  <p class="p2"> <span id="Div_isEarnestmoney"><strong class="gray">您目前选择的是全额付款：</strong><em class="gray red" id="pricemsg_all">￥3,585.00元</em></span> <br>
                    <input type="submit" name="Button2" value="Button" id="Button2" class="nodisplay">
                    <label>
                      <input value="isEarnestmoney1" name="isEarnestmoney" type="radio" id="isEarnestmoney1" onclick="getElementById('Button2').click()" checked="checked">
                      全额付款</label>
                    &nbsp;&nbsp;
                    <label>
                      <input value="isEarnestmoney2" name="isEarnestmoney" type="radio" id="isEarnestmoney2" onclick="getElementById('Button2').click()">
                      预付定金</label>
                  </p>
                  <p class="p3"> </p>
                </div>
              </div>
            </div>
          </div>
          <div id="mysave" class="part1">
            <li class="r">
           
              <input type="image" name="OrderSave_ImageButton" id="OrderSave_ImageButton" src="/resource/ShoppingCss/tjdd.gif"
               onclick="" style="height:35px;width:110px;border-width:0px;display:none;"  >
             <img src="/resource/ShoppingCss/tjdd.gif"  border="0" onclick="funsubmitdata()"/>
            </li>
          </div>
        </div>
      </div>

    </div>
    <div class="clearfix"> </div>
  </div>
</div>

<input type="hidden"  id="IdsNumber" name="IdsNumber" value="<%=idsNumber %>"/>
<div style="display:none;" id="divAddressadd">
    <div class="dizhi dizhik"> <a href="javascript:Newsaddress()"><img src="/resource/ShoppingCss/jia.gif" width="51" height="42" alt=""/></a><br />新增收货地址</div>
 </div>
 <input type="hidden" id="addressIdsubmit" value="0"  name="addressIdsubmit"/>

   <uc2:footer runat="server" ID="footer1" />

  

    <script language="javascript" type="text/javascript">
        function getArea(pcode, checkcode, title,id) {
            $.get("/ajax/GetArea.aspx?pcode=" + pcode + "&checkcode=" + checkcode, '', function (data, textStatus) {
                $("#"+id).html(title+data);
         }, null);
        }
        //省份首次加载
       function funselload()
       {
           getArea('0', '', '<option value="0">--省份--</option>', 'SelProvince');
       }
       function SelPCity() {
           var pid = $("#SelProvince").val();
           getArea(pid, '', '<option value="0">--城市--</option>', 'SelCity');
       }
       function selPArea() {
           var pid = $("#SelCity").val();
           getArea(pid, '', '<option value="0">--地区--</option>', 'selArea');
       }
       funselload();

       function addresssubmit(id) {
           $.post("/ajax/DelStrolleyShopping.aspx", { "ids": ids }, function (data, textStatus) {
               $("#adelall").html('删除选中商品');
               var value = data;
               if (value == 'true') {

               }
               else if (value == 'false') {
                   alert('删除失败，请联系管理员');
               }
               else if (value == 'nologin') {
                  
               }
           }, null);
       }

       //地址信息加载
       function addressload() {

           $.get("/ajax/AddressLoad.aspx?ran=" + Math.random(), function (data, textStatus) {
              
               if (data == '') {
                   $("#divaddressup").show();
               }
               else {
                   $("#divaddressup").hide();
               }
               $("#divaddressList").html(data + $("#divAddressadd").html());

           }, null);
       }

       addressload();

       //数据提交
       function addsubmit() {

           var id = $("#addressIdsubmit").val();
           var Consignee =$.trim($("#Consignee").val());
           var ProvinceName = $("#SelProvince").find("option:selected").text();
           var ProvinceCode = $("#SelProvince").val();
           var CityName = $("#SelCity").find("option:selected").text();
           var CityCode = $("#SelCity").val();
         
           var AreaName = $("#selArea").find("option:selected").text();
           var AreaCode = $("#selArea").val();

           var Address = $.trim($("#Address").val());
           var Zipcode = $.trim($("#Zipcode").val());
           var Mobile = $.trim($("#Mobile").val());
           var Phone = $.trim($("#Phone").val());
           var Email = $.trim($("#Email").val());
           var Fax = $.trim($("#Fax").val());

           if (Consignee == '') {
               $("#Consignee").focus(); 
               alert("收货人不能为空");
               return;
           }
           if (AreaCode == '0') {
               $("#selArea").focus();
               alert("请选择省市区");
               return;
           }

           if (Address == '') {
               $("#Address").focus();
               alert("收货地址不能为空");
               return;
           }
           if (Mobile == '') {
               $("#Mobile").focus();
               alert("手机号码不能为空");
               return;
           }
           if (Email == '') {
               $("#Email").focus();
               alert("邮箱不能为空");
               return;
           }

           $("#imgwait").show();
           $("#imgsubmit").hide();

           $.post("/ajax/AddressSubmit.aspx", { "id": id, "Consignee": Consignee, "ProvinceName": ProvinceName, "ProvinceCode": ProvinceCode, "CityName": CityName, "CityCode": CityCode, "AreaName": AreaName, "AreaCode": AreaCode, "Address": Address, "Zipcode": Zipcode, "Mobile": Mobile, "Phone": Phone, "Email": Email, "Fax": Fax }, function (data, textStatus) {
               $("#imgwait").hide();
               $("#imgsubmit").show();
               var value = data;
               addressload();
           }, null);
       }
       //新增
       function Newsaddress() {
           $("#divaddressList").show();
           $("#submsg").html('新增操作');
           $("#addressIdsubmit").val('0');
           addressShow();
       }
       function addressShow() {
           $("#divaddressup").show();
       }

       function addresshide() {
           $("#divaddressup").hide();
       }

       function addressUpdate(id) {
           $("#divaddressList").show();
           $("#submsg").html('修改操作');
           var jsontext = $("#updateId" + id).val();
           var contact = JSON.parse(jsontext);

           $("#addressIdsubmit").val(contact.Id);
           $("#Consignee").val(contact.Consignee);

           $("#Address").val(contact.Address);
           $("#Zipcode").val(contact.Zipcode);
           $("#Mobile").val(contact.Mobile);
           $("#Phone").val(contact.Phone);
           $("#Email").val(contact.Email);
           $("#Fax").val(contact.Fax);

           var ProvinceCode = contact.ProvinceCode;
           var CityCode = contact.CityCode;
           var AreaCode = contact.AreaCode;

           getArea('0', ProvinceCode, '', 'SelProvince');
           getArea(ProvinceCode, CityCode, '', 'SelCity');
           getArea(CityCode, AreaCode, '', 'selArea');
       }

       function addreshow() { 
            if($("#divaddressList")[0].style.display=='none') {
                $("#addreoperA").html('收起');
                $("#divaddressList").show();
            }
            else {
                $("#addreoperA").html('展开');
                $("#divaddressList").hide();
            }
       }
       function DelOrDefault(id, t) {
           if (t == 'del') {
               if (!confirm('确定要删除吗？')) {
                   window.event.returnValue = false;
                   return;
               }
           }

           $.post("/ajax/DefaultOrdel.aspx", { "Id": id,"t":t }, function (data, textStatus) {
               addressload();
           }, null);
       }


       function JudgeTelephone(ButtonName) {

           var reg = new RegExp(/((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/);
           var input = document.getElementById(ButtonName).value;
           if (!reg.test(input) & input != '') {
               alert('电话号码有误');
               window.event.returnValue = false;
           }
       }
       function JudgeMail(ButtonName) {
           var reg = new RegExp(/^[0-9a-zA-Z]+@[0-9a-zA-Z]+[\.]{1}[0-9a-zA-Z]+[\.]?[0-9a-zA-Z]+$/);
           var input = document.getElementById(ButtonName).value;
           if (!reg.test(input) & input != '') {
               alert('邮件格式有误');
               window.event.returnValue = false;
           }
       }

       function disFree(id) {
           //spanyf1 inputyf1
           var reg = new RegExp(/^[0-9]*$/);
           var input = document.getElementById('inputyf' + id).value;
           if (!reg.test(input) & input!='') {
               $("#inputyf" + id).val('0');
               alert('费用只能为整数');
               window.event.returnValue = false;
           }

           $("#spanyf" + id).html($("#inputyf" + id).val());
       }

       function funcheckAddress(id) {
           $("#checkAddressId").val(id);
           $("#divaddressList div[class='dizhi dizhixz']").prop('class', 'dizhi');
           $("#dizhi" + id).prop("class", "dizhi dizhixz");
       }
       function funsubmitdata() {
           if (typeof ($("#checkAddressId").val()) == "undefined") {
               alert('请选择收货人信息');
               return;
           }   

           if ($("#checkAddressId").val() == '0') {
               alert('请选择收货人信息');
               return;
           }
           document.getElementById("form1").submit();
       }
       function funtest() {

           $("#divaddressList").html($("#divaddressList").html() + $("#divAddressadd").html());
          // alert(contact.surname + ", " + contact.firstname)
       }
    </script>

      </form>
</body>
</html>
