<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoppingTrolley.aspx.cs" Inherits="TREC.Web.template.web.default2.shoppingTrolley" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE HTML>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <ucnewresource:newresource ID="newresource1" runat="server" />
    <title>购物车</title>
     <script src="/resource/content/js/jquery-1.4.1.min.js"></script>
       <script src="/resource/content/js/core.js" type="text/javascript"></script>
      
</head>
<body>
    <form id="form1" runat="server" action="OrderSubmit.aspx" method="post">
    <input type="hidden" id="ShoppingIds" name="ShoppingIds" value=""/>
     <uc1:header ID="header1" runat="server" />
       <link href="/resource/ShoppingCss/shopping.css" rel="stylesheet" type="text/css" />
      
     <div class="site" ><a href="/">首页</a> > 购物车</div>
<DIV class=contentInner>
  <DIV class=inner>
    <DIV class=shopping>
      <DIV class="buystep buybg01">
        <UL>
          <LI class=wordh><SPAN>1.</SPAN>我的购物车</LI>
          <LI class=wordn><SPAN>2.</SPAN>填写核对订单信息</LI>
          <LI class=wordn><SPAN>3.</SPAN>成功提交订单</LI>
        </UL>
      </DIV>
      <DIV class="buycon shopcart">
        <DIV class=buyoo>
          <table width="100%" border="0" id="tbshopping">
            <tbody>
              <tr>
            <th scope="col" class="style1" align="center"><input type="checkbox"  value="0" price="0" onclick="checkall('tbcheckall1')" id="tbcheckall1"/></th>
                <th scope="col" class="style1" align="center"> 产品图片 </th>
                <th scope="col" class="style1" align="center"> 产品名称 </th>
                <th scope="col" class="style1" align="center"> 尺寸(长×宽×高)mm </th>
                <th scope="col" class="style1" align="center"> 颜色 </th>
                <th scope="col" class="style1" align="center"> 单价 </th>
                <th scope="col" class="style1" align="center"> 数量(件） </th>
                 <th scope="col" class="style1" align="center"> 小计 </th>
                <th scope="col" class="style1" align="center"> 删除 </th>
              </tr>
                <asp:Repeater ID="Repeater_shopping" runat="server">
                <ItemTemplate>
                <tr  id="trid<%#Eval("sid") %>">
                <td ><input type="checkbox"  value="<%#Eval("sid") %>"  price="<%#Eval("resultPrice")%>"/></td>
                <td align="center"><a target="_blank" href="/productinfo.aspx?id=<%#Eval("proid") %>" class=""> <img src="/upload/product/thumb/<%#Eval("proid") %>/<%#Eval("thumb") %>" alt="<%#Eval("title") %>" width="64" height="60" class="tttpic" original="/upload/product/thumb/<%#Eval("proid") %>/<%#Eval("thumb") %>"></a></td>
                <td align="center"><a target="_blank" class="a1" href="/productinfo.aspx?id=<%#Eval("proid") %>"> <%#Eval("title") %> </a></td>
                <td  align="center" id="Volume_<%#Eval("sid") %>" value="<%#Eval("Volume")%>"><%#Eval("big")%></td>
                <td align="center"> <%#Eval("productcolortitle")%> </td>
                <td align="center"><strong class="gray">￥<b>
                <%#Eval("resultPrice")%>
                </strong></td>
                <td class="" align="center"><div class="num" >
                    <div class="l">
                      <input id="num_<%#Eval("sid") %>" type="text" maxlength="2"  value="<%#Eval("ProCount") %>"  onblur="checkcount('num_<%#Eval("sid") %>')">
                    </div>
                    <div class="r"> <a title="增加" onclick="buycount('num_<%#Eval("sid") %>','+');" class=""><img src="/resource/ShoppingCss/shopping27.jpg" alt="" original="/resource/ShoppingCss/shopping27.jpg"></a> <a title="减少" onclick="buycount('num_<%#Eval("sid") %>','-')"; class=""><img src="/resource/ShoppingCss/shopping28.jpg" alt="" original="/resource/ShoppingCss/shopping28.jpg"></a> </div>
                  </div></td>
                  <td align="center" id="tdxj<%#Eval("sid") %>">
                  <%#Eval("xiaoji")%>
                  </td>
                <td class="tdControl" align="center"><a href="javascript:void(0);" onclick="deleteone('<%#Eval("sid") %>');" class=""> <img src="/resource/ShoppingCss/del.gif" id="delimg<%#Eval("sid") %>" alt="删除" original="/resource/ShoppingCss/del.gif"></a></td>
              </tr>
                </ItemTemplate>
                </asp:Repeater>
            </tbody>
          </table>
        </DIV>
        <DIV style="PADDING-BOTTOM: 0px" class=block1>
          <DIV class=bd>
            <DIV class="shoppingDetailLast shoppingDetailLastTrim1">
              <DIV class=d1>
                <P id=Div_Calculation class=p1></P>
                <P style="DISPLAY: none" id=Div_ScorePoints class=p2></P>
              </DIV>
              <div class="buytotal"> 
              
              <span class="col" style="width:200px;font-weight:normal;font-size:14px;">
              <input type="checkbox"  onclick="checkall('tbcheckall2')" id="tbcheckall2" price="0" value="0"/> 全选<a href="javascript:deleteall();" style="margin-left:30px;" id="adelall">删除选中商品</a>
              </span>
              
               <span class="com">产品：<i id="result_count">0</i>件，     体积：<i id="result_v">0</i>m³</span> <span class="cor">总计：<u class="prisl">￥</u><b id="result_price">0.00</b></span> <span class="cob" style="display:none;">优惠：-<u class="prisl">￥</u><b>0.00</b></span> </div>
              <DIV class=buyzong>
                <DIV class=tol>温馨<BR>
                  提示</DIV>
                <DIV class=tom>
                  <H1>您在购物过程中有任何疑问，请查阅 <A style="FONT-SIZE: 14px; FONT-WEIGHT: bold" class=ftx04 
href="#" target=_blank>帮助中心</A> 或与在线客服联系</H1>
                  为方便您提交订单，您添加到购物车里的尚未提交订单的产品清单，我们将为您保留90天，在这期间， 
                  您所选择的商品价格，优惠政策，库存，配送时间等信息可能会发生变化，请以网页最新信息为准。</DIV>
                <DIV class=tor>总计（不含运费）： <span><u class="prisl">￥</u><span id="result_price2">0</span></span></DIV>
              </DIV>
            </DIV>
          </DIV>
        </DIV>
      </DIV>
      <DIV class=buybtn>
        <P class=p3>
        <img src="/resource/ShoppingCss/rebuy.gif" title="继续购物"  onclick="javascript:location.href='/productlisttbb.aspx'"/>
          <%--<INPUT style="MARGIN-RIGHT: 15px" title="继续购物" onclick="VolumeCount()" src="/resource/ShoppingCss/rebuy.gif" type="button">
          <INPUT title=去结算 onclick=gotopay() src="/resource/ShoppingCss/overbuy.gif" type=image>
          --%>
          <img title="去结算" onclick="submitdata()" src="/resource/ShoppingCss/overbuy.gif" />
        </P>
      </DIV>
      <DIV class=clearfix></DIV>
    </DIV>
  </DIV>
  <DIV style="DISPLAY: none" id=cartnoproduct align=center>
    <DIV class=nopro>
      <H1>我的购物车</H1>
      <DIV class=noprocon>
        <DIV class=chebg><IMG src="/resource/ShoppingCss/chebg.gif"></DIV>
        购物车内暂时没有产品，您可以<A 
href="http://www.jiajuks.com/">去首页</A>挑选喜欢的产品。</DIV>
    </DIV>
  </DIV>
</DIV>

<script language="javascript" type="text/javascript">
    function checkall(id) {
        $("#tbshopping input[type='checkbox']").prop("checked", $("#" + id).prop("checked"));
        VolumeAndPriceCount();
    }
    $("#tbshopping input[type='checkbox']").click(
   function () {
       VolumeAndPriceCount();
   }
    );
    function buycount(id, t) { 
         var c=parseInt($("#"+id).val());
       
        if (t == '+') { 
        c=c+1;
        $("#" + id).val(c);
    }
    if (t == '-') {
        if (c > 1) {
            c = c - 1;
            $("#" + id).val(c);
        }
    }
    VolumeAndPriceCount();

}

function checkcount(id) {
    var c = parseInt($("#" + id).val());
    if (c < 1 || isNaN(c)) {
        $("#" + id).val('1');
    }
    VolumeAndPriceCount();
}
//相乘
function accMul(arg1, arg2) {
    var m = 0, s1 = arg1.toString(), s2 = arg2.toString();
    try { m += s1.split(".")[1].length } catch (e) { }
    try { m += s2.split(".")[1].length } catch (e) { }
    return Number(s1.replace(".", "")) * Number(s2.replace(".", "")) / Math.pow(10, m)
}
//小数
function accAdd(arg1, arg2) {
    var r1,
    r2,
    m;
    try {
        r1 = arg1.toString().split(".")[1].length
    } catch (e) {
        r1 = 0
    }
    try {
        r2 = arg2.toString().split(".")[1].length
    } catch (e) {
        r2 = 0
    }
    m = Math.pow(10, Math.max(r1, r2))
    return (arg1 * m + arg2 * m) / m
}
//体积,价格计算
function VolumeAndPriceCount() {
    var vo = 0; //体积
    var pri = 0; //价格
    var allcount = 0;
    $("#tbshopping input[type='checkbox']").each(
    function (i) {
        var id = $(this).val();
          var price = $(this).attr("price"); //价格
           var s = parseInt($("#num_" + id).val()); //数量
        $("#tdxj"+id).html( accMul(s, price));//小计
        if ($(this).prop("checked") && $(this).val() != '0') {
            var Volume = $("#Volume_" + id).attr("value"); //体积
            var von = accMul(s, Volume);
            var pricen = accMul(s, price);
            vo = accAdd(vo, von);
            pri = accAdd(pri, pricen);
            allcount = allcount + s;
        }

    }
    );

    $("#result_count").html('' + allcount);
    $("#result_v").html('' + funksj(vo));
    $("#result_price").html('' + pri);
    $("#result_price2").html('' + pri);
}
//---------------科学计数法------------
function funksj(v) {
    datastr =''+ v;
    var str = new Array();
    var s = '0.';
    str = datastr.split("e");
   if (str.length > 1) {
               for (var i = 0; i < parseInt(str[1].replace('-','')); i++) {
            s = s + "0";


        }
        return s + str[0];
   }
   else
   {
    return v;
   }
}
//---------------科学计数法------------
function deleteone(id) {
    if (!confirm('确定要删除吗？')) {
        window.event.returnValue = false;
        return;
    }

    $("#delimg" + id).attr("src", "/resource/content/images/wait.gif");


    $.post("/ajax/DelStrolleyShopping.aspx", { "ids": id }, function (data, textStatus) {
        var value = data;
        if (value == 'true') {
            VolumeAndPriceCount();
            $("#trid" + id).hide(500);
        }
        else if (value == 'false') {
            $("#delimg" + id).attr("src", "/resource/ShoppingCss/del.gif");
            alert('删除失败，请联系管理员');
        }
        else if (value == 'nologin') {
            $("#delimg" + id).attr("src", "/resource/ShoppingCss/del.gif");
            alert("登陆超时，请重新重新登陆");
            location.href = '/loginuser.aspx';
        }
    }, null);

}

function deleteall() {
    if (!confirm('确定要删除吗？')) {
        window.event.returnValue = false;
        return;
    }
    var ids = '0';
    $("#tbshopping input[type='checkbox']").each(
    function (i) {
        if ($(this).prop("checked") && $(this).val() != '0') {
            var id = $(this).val();
            ids = ids + ',' + id;
        }

    }
    );
    if (ids != '0') {
        $("#adelall").html('删除中...');
        $.post("/ajax/DelStrolleyShopping.aspx", { "ids": ids }, function (data, textStatus) {
            $("#adelall").html('删除选中商品');
            var value = data;
            if (value == 'true') {
                var str = new Array();

                str = ids.split(",");
                for (i = 0; i < str.length; i++) {
                    if (str[i] != '0') {
                        $("#trid" + str[i]).hide(500);
                    }
                }


            }
            else if (value == 'false') {
                alert('删除失败，请联系管理员');
            }
            else if (value == 'nologin') {
                alert("登陆超时，请重新重新登陆");
                location.href = '/loginuser.aspx';
            }
        }, null);

    }
    else {
        alert('请先选择需要删除的商品');
    }
}

function submitdata() { 
  var ids = '0';
    $("#tbshopping input[type='checkbox']").each(
    function (i) {
        if ($(this).prop("checked") && $(this).val() != '0') {
            var id = $(this).val();
            var s = parseInt($("#num_" + id).val()); //数量
            ids = ids  + id+','+s+';';
        }

    }
    );
    if (ids != '0') {
        $("#ShoppingIds").val(ids);
        document.getElementById("form1").submit(); 
    }
    else {
        alert('请先选择购物车中的商品，然后提交');
    }
}
$(document).ready(function () {
    $("#tbcheckall1")[0].click();
})

</script>
     <uc2:footer runat="server" ID="footer1" />
    </form>
</body>
</html>
