<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserOrderList.aspx.cs" Inherits="TREC.Web.template.web.Ucenter.UserOrderList" %>
<%@ Register Src="../ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>

<%@ Register src="../ascx/Ucenter.ascx" tagname="Ucenter" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="/resource/content/css/ucerter.css" rel="stylesheet" type="text/css">
    <link href="/resource/content/css/supplier.css" rel="stylesheet" type="text/css">
   <script src="/resource/content/indexnav/jquery.min.js" type="text/javascript"></script>


   <style type="text/css">
   .chpage
   {
       padding:3px 3px 3px 3px;
       text-align:right;
       
   }
   .chpage span
   {
       font-size:13px;
       margin-right:10px;
       cursor:pointer;
    }
   </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:header ID="header1" runat="server" />
    <div class="site"><a href="#">首页</a> &gt; <a href="#">购物车</a> &gt; 用户中心</div>
    
    <div class="contentInner">
  <div class="inner">
    <div class="supplier">
                            
<uc2:Ucenter ID="Ucenter1" runat="server" />

                            <div class="spR">
                            <p class="pwel">
                                    WELCOME,欢迎来到用户管理中心</p>
                            <div class="spTip0">
                                    <strong>提醒您：</strong> 您有&nbsp;&nbsp;&nbsp;
                                    [<em><a class="" href="#"><span id="Label2"><%=noplay %></span></a></em>]个未处理订单
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                <div class="spBox1">
                                    <div id="cld" class="sphd sphdTrim1 spbdTrim3">
                                        <span style="width:120px;" class="s1">我的订单</span>
                                        <div style="float:left;padding-top:8px;">
                                    </div>
                                    </div>
                                    
                                  <div class="spbd spbdTrim1">
                                        <div class="listSeries">
                                            <div class="listSeriesInner">
                                              <div class="bd bdTrim1">
                                                    <div style="display: block;" class="item">
                                                    <table id="tdhideorder">
                                                    <tr>
                                                                        <th width="200" scope="col"><span class="tdStrong">订单号</span></th>
                                                                        <th width="100" class="tdStrong" scope="col">订单金额</th>
                                                                        <th width="180" scope="col">
                                                                            <select id="seltime" name="seltime" onchange="selchange()">
                                                                            <option value="3">最近三个月</option>
                                                                            <option value="12">今年内</option>
                                                                            <option value="0">全部订单</option>
                                                                        </select>
                                                                        </th>  
                                                                        <th width="120" scope="col">
                                                                        
                                                                        <select id="seltype" name="seltype" onchange="selchange()">
                                                                         <option  value="5">全部</option>
                                                                          <option selected="selected" value="0">待付款</option>
                                                                          <option value="1">待付余款</option>
                                                                          <option value="2">备货中</option>
                                                                          <option value="3">送货中</option>
                                                                          <option value="4">已完成</option>
                                                                          <option value="-1">已取消</option>
                                                                        </select>
                                                                        </th>                                                                      
                                                                        <th width="120"  >付款状态</th>                                                                        
                                                                        <th  width='120' align="center" style="padding-left:20px;">操作</th>
                                                                    </tr>       
                                                    </table>
                                                        <table width="960px;" border="0" id="tddatashow">
                                                                    
                                                      </table>
                                                      <div style="display:none;text-align:center;" id="divwaitimg">
                                    <img src="/resource/content/images/wait.gif"   id="imgwait"/>
                                                      
                                                      </div>
                                                      <div class="chpage" id="divpagefoot"><span id="srow">1/5</span> <span id="spre" onclick="funpre()">[上一页]</span><span id="snext" onclick="funnext()">[下一页]</span> </div>
                                                  </div>
                                                    
                                                   
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
  </div>

</div>
<input type="hidden" value="1"  id="pagerow"/>
<input type="hidden"  value="1" id="pageindex"/>

<script language="javascript" type="text/javascript">

    function dataload() {
       // $("#tddatashow").html($("#tdhideorder").html());
        $("#divwaitimg").show();
        $("#divpagefoot").hide();
        $.post("/ajax/ShowOrderList.aspx", { "pageindex": $("#pageindex").val(), "seltime": $("#seltime").val(), "seltype": $("#seltype").val() }, function (data, textStatus) {
            var head = $("#tdhideorder").html();
            $("#divwaitimg").hide();
            $("#divpagefoot").show();
            var str = new Array();
            str = data.split("■");
            $("#pagerow").val(str[1]);
            $("#srow").html($("#pageindex").val() + "/" + str[1]);
            //$("#tddatashow").html(head + str[0]);
            $("#tddatashow").html(str[0]);
        }, null);
    }

    dataload();

    function funpre() {
        var pindex = parseInt($("#pageindex").val());
        var prow = parseInt($("#pagerow").val());
        if (pindex > 1) {
            var p = pindex - 1;
            $("#pageindex").val(p);
            dataload();
        }
    }


    function funnext() {
        var pindex = parseInt($("#pageindex").val());
        var prow = parseInt($("#pagerow").val());
        if (pindex < prow) {
            var p = pindex + 1;
            $("#pageindex").val(p);
            dataload();
        }
    }

    function selchange() {
        $("#pageindex").val('1');
        dataload();
    }

    function orderdel(id) {
        if (!confirm('确定要取消定单吗？')) {
            window.event.returnValue = false;
            return;
        }
        $.post("/ajax/OrderlistDel.aspx", { "id": id}, function (data, textStatus) {
            dataload(); 
        }, null);

        
    }
</script>
    <ucfooter:footer ID="header2" runat="server" />
    </form>
</body>
</html>
