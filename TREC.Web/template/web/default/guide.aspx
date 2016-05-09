<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.guide" %>

<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="Haojibiz.Model" %>
<%@ Import Namespace="Haojibiz.Data" %>
<%@ Import Namespace="Haojibiz.DAL" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7;IE=9;IE=8">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>商家活动导购</title>
    <link href="/resource/content/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/css/guide/guide.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/indexnav/yx_rotaion.css" rel="stylesheet" type="text/css" />
    <script src="/resource/content/js/core.js" type="text/javascript"></script>
    <script src="/resource/content/js/guide.js" type="text/javascript"></script>
    <script src="/resource/page/page.js" type="text/javascript"></script>
    <link href="/resource/page/page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .guide-left .option dl
        {
            width: 670px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:header ID="header1" runat="server" />
    <div class="guide-cont clearfix w">
        <div class="guide-left fl">
            <div class="guide-hot" id='navindex3'>
                <a href="#">
                    <img class="block" alt="" src="../../../resource/content/img/index/h5.jpg" /></a>
            </div>
            <div class="option">
                <div class="hd">
                    <input class="text vm" type="text" id='txtkey' placeholder="请输入卖场/品牌/厂商名称查询" />
                    <input class="button vm" type="button" onclick='hd(1);' value="搜 索" />
                </div>
                <ul>
                    <li class="bd clearfix" style="max-height:180px;height:auto;min-height:110px;">
                        <table border="1" style="">
                            <tr>
                                <td style="vertical-align: top; padding-top: 2px; width: 50px; text-align: right">
                                    品牌：
                                </td>
                                <td>
                                    <div class="listy2" style='float: right;'>
                                        <dl style='border-bottom: 0px solid #e7e3e7;'>
                                            <dd id="ddpp">
                                                <div class="pplm">
                                                    <ul class="tabs" id="tabs2">
                                                        <li><a href="###" onclick='setchk(this,"ddpp","bid","");' class="hove" style='padding: 0 8px;'
                                                            id='ddppall'>不限</a></li>
                                                        <%=brandlet %>
                                                    </ul>
                                                    <ul class="tab_conbox" id="tab_conbox2" style='width: 668px'>
                                                        <%=recbrand %>
                                                        <%=brand %>
                                                    </ul>
                                                </div>
                                            </dd>
                                        </dl>
                                        <%--<div class="fl left">
                            卖场</div>
                        <dl class="clearfix fl" id='dlmid'>
                            <dd>
                                <a href="###" onclick='setchk(this,"dlmid","mid","");'><label style='color:#f89a05'>不限</label></a></dd>
                            
                            <%
                                    int midcount = 0;
                                    foreach (t_market item in listmarket)
                                    { 
                                        if (midcount < 10)
                                        {  %>
                             
                            <dd>
                                <a href="###" onclick='setchk(this,"dlmid","mid","<%=item.id %>");'>
                                    <%=item.title%></a></dd>
                            <%}
                                    }%>
                        </dl>--%>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </li>
                    <li class="bd clearfix" style="max-height:180px;height:auto;min-height:110px;">
                        <table border="1" style="">
                            <tr>
                                <td style="vertical-align: top; padding-top: 2px; width: 50px; text-align: right">
                                    卖场：
                                </td>
                                <td>
                                    <div class="listy2" style='float: right;'>
                                        <dl style='border: 0px solid #e7e3e7;'>
                                            <dd id="dd1">
                                                <div class="pplm">
                                                    <ul class="tabs" id='tabs'>
                                                        <li><a href="###" onclick='setchk(this,"dd1","bid","");' class="hove" style='padding: 0 8px;'
                                                            id='ddmcall'>不限</a></li>
                                                        <%=marketlet %>
                                                    </ul>
                                                    <ul class="tab_conbox" id="tab_conbox" style='width: 668px'>
                                                        <%=recmarket %>
                                                        <%=market %>
                                                    </ul>
                                                </div>
                                            </dd>
                                        </dl>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </li>
                    <li class="bd clearfix">
                        <table border="1" style="">
                            <tr>
                                <td style="vertical-align: top; padding-top: 2px; width: 50px; text-align: right;">
                                    区域：
                                </td>
                                <td>
                                    <div class="listy2" style='float: right;'>
                                        <dl style='border-bottom: 0px solid #e7e3e7;'>
                                            <dd id="dd2">
                                                <div class="pplm" style='border-top: 0px solid #e7e3e7;'>
                                                    <ul class="tab_conbox" id="dlaid" style="width: 668px; border: none">
                                                        <li><a style='color: #fff; background-color: #b9003c' href="###" onclick='setchk(this,"dlaid","aid","");'>
                                                            不限</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310101");'>黄浦区</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310104");'>徐汇区</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310105");'>长宁区</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310106");'>静安区</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310107");'>普陀区</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310108");'>闸北区</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310109");'>虹口区</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310110");'>杨浦区</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310112");'>闵行区</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310113");'>宝山区</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310114");'>嘉定区</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310115");'>浦东新区</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310116");'>金山区</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310117");'>松江区</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310118");'>青浦区</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310120");'>奉贤区</a></li>
                                                        <li><a href="###" onclick='setchk(this,"dlaid","aid","310230");'>崇明县</a></li>
                                                    </ul>
                                                </div>
                                            </dd>
                                        </dl>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </li>
                    <li class="bd clearfix">
                        <table border="1" style="">
                            <tr>
                                <td style="vertical-align: top; padding-top: 2px; width: 50px; text-align: right;">
                                    类型：
                                </td>
                                <td>
                                    <div class="listy2" style='float: right;'>
                                        <dl style='border-bottom: 0px solid #e7e3e7; border-top: 0px solid #e7e3e7;'>
                                            <dd id="dd3">
                                                <div class="pplm" style='border-top: 0px solid #e7e3e7;'>
                                                    <ul class="tab_conbox" id="dltype" style="width: 668px; border: none">
                                                        <li><a style='color: #fff; background-color: #b9003c' href="###" onclick='setchk(this,"dltype","tid","0");'>
                                                            不限</a></li>
                                                        <li><a href="javascript:setchk(this,'dltype','tid','103');" >卖场</a></li>
                                                        <li><a href="javascript:setchk(this,'dltype','tid','104');" >店铺</a></li>
                                                        <li><a href="javascript:setchk(this,'dltype','tid','101');">工厂</a></li>
                                                         <li><a href="javascript:setchk(this,'dltype','tid','102');">经销商</a></li>
                                                    </ul>
                                                </div>
                                            </dd>
                                        </dl>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <%--  <div class="fl left">
                            类型</div>
                        <dl class="clearfix fl" id='dltype'>
                            <dd>
                                <a href="###" onclick='setchk(this,"dltype","tid","0");'>
                                    <label style='color: #f89a05' class="hove">
                                        不限</label></a></dd>
                            <dd>
                                <a href="###" onclick='setchk(this,"dltype","tid","103");'>卖场</a></dd>
                            <dd>
                                <a href="###" onclick='setchk(this,"dltype","tid","104");'>店铺</a></dd>
                            <dd>
                                <a href="###" onclick='setchk(this,"dltype","tid","101");'>工厂</a></dd>
                        </dl>--%>
                    </li>
                </ul>
            </div>
            <br />
            <div class="activity" id="j_activity">
                <ul class="hd clearfix">
                    <li class="on" onclick='sort(0);'>所有活动</li>
                    <li onclick='sort(2);'>按开始时间</li>
                    <li onclick='sort(3);'>按结束时间</li>
                    <li onclick='sort(4);'>按关注度</li>
                    <li id='licount'></li>
                </ul>
                <div class="bd">
                    <div class="item">
                        <ul id='ulinfo'>
                            <%--<li class="clearfix">
                                <div class="left fl">
                                    <h4>
                                        <a href="#"><span>【品牌】</span>全友家私上海周年庆</a></h4>
                                    <p class="time">
                                        <span>时间：</span><span>2015.01.14</span>-<span>2015.02.14</span><span class="surplus">[还有3天]</span></p>
                                    <div class="address">
                                        <span>地址:</span><span>上海市宝山区春雷路9号15楼</span></div>
                                </div>
                                <div class="fr right">
                                    5折</div>
                            </li>--%>
                        </ul>
                    </div>
                </div>
                <br />
                <span id="paging1" class="page"></span>
                <br />
            </div>
        </div>
        <div class="guide-right fr">
            <ul>
                <%foreach (t_advertising item in list1)
                  { %>
                <li><a href="<%=item.linkurl %>" title="<%=item.title %>" target="_blank">
                    <img src='<%=item.imgurl %>' style='width: 392px; height: 298px;' alt="<%=item.title %>"
                        class="block" /></a></li>
                <%} %>
            </ul>
        </div>
    </div>
    <ucfooter:footer ID="header2" runat="server" />
    <input type="hidden" id='hidmid' value='' />
    <input type="hidden" id='hidbid' value='' />
    <input type="hidden" id='hidaid' value='' />
    <input type="hidden" id='hidtid' value='' />
    <input type="hidden" id='hidsid1' value='' />
    <input type="hidden" id='hidsid2' value='0' />
    </form>
    <script src="../../../resource/content/js/js.js" type="text/javascript"></script>
    <script src="../../../resource/content/indexnav/jquery.yx_rotaion.js" type="text/javascript"></script>
    <script type="text/javascript">
    
   hddg(   <%=stradv %>  );//hddg(  eval('(' + <%=stradv %> + ')')   );

    $("#txtkey").val("") ;
    $("#hidmid").val("") ;
    $("#hidbid").val("") ;
    $("#hidaid").val("") ;
    $("#hidtid").val("") ;
    $("#hidsid1").val("") ;
    $("#hidsid2").val("0") ;

  var pagesize= 10;
  
  function setchk(obj,id0,id1, id2) {
  
      $("#"+id0 +" a").each(function(i){ 
        $(this).css("background-color","");
        $(this).css("color","#4a4a4a");  
      });
      $(obj).css("background-color","#B9003C");
      $(obj).css("color","#FFF");

      $("#hid"+id1).val(id2);
        hd(1);
    }

    if (getQueryString("mid") != null)
          $("#hidmid").val(getQueryString("mid"));
      if (getQueryString("bid") != null)
          $("#hidbid").val(getQueryString("bid"));

      if (getQueryString("cid") != null) {
          //厂商id
          $("#txtkey").val(getQueryString("cid"));
      }
  
  function sort(t){
    $("#hidsid2").val(t);
    hd(1);
  }

      function hd(index) {
      

          $.ajax({
              async: false, //是否异步
              url: '../../../ajax/hdsearch.ashx?t=hdnew&mid=' + $("#hidmid").val() + '&bid=' + $("#hidbid").val() + '&aid=' + $("#hidaid").val() + '&k=' + $("#txtkey").val() + '&tf=' + $("#hidtid").val() + '&sort=' + $("#hidsid1").val() + '&sort1=' + $("#hidsid2").val() + '&pi='+index+'&m=' + Math.random(),
              type: 'post', //post方法
              dataType: 'json', //返回json格式数据
              success: function (data) {

                  var s = "";
                  for (var i = 0; i <data.dt.length; i++) {
                      s += '<li class="clearfix">';
                      s += '<div class="left fl">';
                      s += '<h4><a href="'+data.dt[i].url+'" target="_blank"><span></span>' + data.dt[i].title + '</a></h4>';
                      s += '<p class="time">';
                      var txtday=' [还有' + GetDateDiff(data.dt[i].datanow, data.dt[i].enddatetime, "day") + '天]';
                      if(GetDateDiff(data.dt[i].datanow, data.dt[i].enddatetime, "day")<=0)
                        txtday=" [活动已结束]";
                      s += '<span>时间：</span><span>' + data.dt[i].startdatetime + '</span>---<span>' + data.dt[i].enddatetime + '</span><span class="surplus">'+txtday+'</span></p>';
                      s += '<div class="address">';
                      s += '<span>地址:</span><span>'+ data.dt[i].address+'</span></div>';
                      s += '</div>';
                      s += '<div class="fr right" style="display:none;">5折</div>';
                      s += '</li>';
                  }
                  
                  if(s.length==0)
                       s = '<br />暂无信息<br />';
                  $("#ulinfo").html(s);
                  
                  $("#licount").html("共 <label style='color:red'>&nbsp;"+data.page.rows+"&nbsp;</label>条");

                  //分页
                  if(data.dt.length<pagesize)
                    $("#paging1").html('');
                 else
                  $("#paging1").pagination({
                    items: data.page.rows,
                    cssStyle: 'light-theme',
                    itemsOnPage: pagesize,
                    callFn: "hd",
                    currentPage:index
                });

              },
              //error: function () { alert('错误'); }
          });
      }


          hd(1);

    function getQueryString(name) 
    { 
        var reg = new RegExp("(^|&|\\?)"+ name +"=([^&]*)(&|$)"), r; 
        if (r=window.location.href.match(reg)) return unescape(r[2]); return null; 
    }; 
        
        /*
* 获得时间差,时间格式为 年-月-日 小时:分钟:秒 或者 年/月/日 小时：分钟：秒
* 其中，年月日为全格式，例如 ： 2010-10-12 01:00:00
* 返回精度为：秒，分，小时，天
*/

function GetDateDiff(startTime, endTime, diffType) {
//将xxxx-xx-xx的时间格式，转换为 xxxx/xx/xx的格式
startTime = startTime.replace(/\-/g, "/");
endTime = endTime.replace(/\-/g, "/");

//将计算间隔类性字符转换为小写
diffType = diffType.toLowerCase();
var sTime =new Date(startTime); //开始时间
var eTime =new Date(endTime); //结束时间
//作为除数的数字
var divNum =1;
switch (diffType) {
case"second":
divNum =1000;
break;
case"minute":
divNum =1000*60;
break;
case"hour":
divNum =1000*3600;
break;
case"day":
divNum =1000*3600*24;
break;
default:
break;
}
return parseInt((eTime.getTime() - sTime.getTime()) / parseInt(divNum));
}
    </script>
</body>
</html>
