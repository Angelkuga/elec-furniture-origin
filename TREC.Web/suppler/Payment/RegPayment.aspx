<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegPayment.aspx.cs" MasterPageFile="../Member.Master" Inherits="TREC.Web.Suppler.Payment.RegPayment" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <style>
    .box{border:solid #d1d4d8 1px; font-size:12px; padding-bottom:110px; margin:0 auto; width:770px;}
    .box_top{padding:7px 0 7px 10px;background-color:f4f4f4; border-bottom:solid #d1d4d8 1px; font-weight:bold;}
    .box_main{ border-bottom: dotted #ccc 1px; padding:15px 10px 15px 10px; margin:0 5px;}
	.box_main span{padding-right:15px; color:#009;}
    .box_main .box_la span{padding-left:20px; color:#000;}
    .box_main ul{*zoom: 1;}
    .box_main ul:after{content: '\20';display: block;height: 0;clear: both;}
    .box_main ul li{ float:left; padding:10px 8px 10px 15px; display:block; height:25px; line-height:25px;}
    .box_main label{ margin:-4px 6px 0px 0px; padding:0px; }
    .box_main input{ margin:0px 6px 0px 0px; padding:0px;vertical-align:middle;}
    .box_main li img{ vertical-align:middle; width:135px; height:37px;}
	.box_la{margin-left:10px;}
	.box_la input{  margin:-4px 10px 0px 0px; vertical-align:middle;padding:0px;}
	.box_hy{ border-bottom: dotted #ccc 1px; padding:0px 9px 20px 15px ;}
	.box_hy span{padding-left:10px; color:#CC3333;}
	.box_hy p{ padding:0 0 10px 0;}
    .button{ margin:45px auto; text-align:center;}
	.footer{ text-align:center;}
    .footer img{ vertical-align:middle;}
    .zfb{ border:1px solid #FFCC66; padding-left:20px; margin-top:20px; height:37px;line-height:37px;}
	.zfb span{ color:#CC0000; padding-left:5px; position:absolute; margin:auto;}
	.zfb input{ margin-left:33px; margin-bottom:26px;}
	
	   /*弹出框*/
        .topstyle
        {
            position: absolute;
            background-color: #000000;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            z-index: 9999998;
            display: none;
           filter:alpha(opacity=10);-moz-opacity:0.1;-khtml-opacity: 0.1;opacity: 0.1;
        }
        .divopenv22
        {
            width: 300px;
            height: 300px;
            position: fixed;
            z-index: 9999999998;
            display: none;
            background-color:White;
         
        }
        /*弹出框*/
        
    </style>
    <script>
        function ShowPrice() {
            var istype = $("#istype").val();
            if (istype == "1") {
                var jevalue = $('input:radio[name="jeprice"]:checked').val();
                if (jevalue == "1") {
                    $("#pricemark").text("1000"); $("#priceout").text("2000");
                }
                else if (jevalue == "2") {
                    $("#pricemark").text("2000"); $("#priceout").text("3000");
                }
            }
            else if (jevalue == "0") {
                var jevalue = $('input:radio[name="jeprice"]:checked').val();
                if (jevalue == "1") {
                    $("#pricemark").text("1500"); $("#priceout").text("1500");
                }
                else if (jevalue == "2") {
                    $("#pricemark").text("2500"); $("#priceout").text("2500");
                }
            }
        }

        $(function () {
            $('input:radio[name="ctl00$ContentPlaceHolder1$radio_usertype"]').change(function () {
                if ($(this).val() == "0") {
                    $("#tdshichang1").show();
                    $("#tdshichang2").show();
                    $("#pserverprice").show();
                    $("#potherprice").hide();
                    $("#ptime").show();
                }
                else {
                    $("#tdshichang1").hide();
                    $("#tdshichang2").hide();
                    $("#pserverprice").hide();
                    $("#potherprice").show();
                    $("#ptime").hide();
                }
            });


            $('input:radio[name="ctl00$ContentPlaceHolder1$Radio_time"]').change(function () {
                countprice();
            });

        });


        function funbgopen() {
            $("#divop").height($(document).height());
            $("#divop").show();
            $("#divop").animate({ opacity: 0.6 }, "slow");

        }
        //frameurl
        function funopen(id, t) {

            $("#frameurl1").hide();
            $("#frameurl2").hide();

            $("#frameurl"+t).show();
            $("#divop").show();

            var w = $("#" + id).width();
            var h = $("#" + id).height();

            var winwid = $(window).width();
            var winheight = $(window).height();
            var sw = (winwid - w) / 2;
            var sh = (winheight - h) / 2;

            $("#" + id).css("left", sw);
            $("#" + id).css("top", sh);
            $("#" + id).show();
           // $("#" + id).animate({ opacity: 1.0 }, "slow");


        }
        //addBaoMing.aspx?Pid=&Ptitle=康帝星&prodcon=1&brandid=53&brandName=康帝星
        function funclose(id) {
            $("#divop").hide();
            $("#" + id).hide();
           
        }
        function pcheck() {
            if ($("#checkagree").attr("checked")) {
                $("#divsubmit").show();
            }
            else {
                $("#divsubmit").hide();
            }
        }

        function countprice() {
            //spanprice
            var value = $('input:radio[name="ctl00$ContentPlaceHolder1$Radio_time"]:checked').val();
            var t = 0;

            if (value == "1") {
                t = 2000;
            }
            else if (value == "2") {
                t = 3500;
            }
            else if (value == "3") {
                t = 6000;
            }

            var c = 0;
            if ($("#ctl00_ContentPlaceHolder1_check_other").attr("checked")) {
                c = 500;
            }
            else {
                c = 0;
            }

            $("#spanprice").html(t + c);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <asp:HiddenField runat="server" ID="istype" Value="0" />

     <!--弹出窗口-->
      <div class="divopenv22" id="divsj" style="display:none;width:700px;height:550px;">
      <div style="width:100%;height:30px; background-color: #A6A6A6;">
      <span style="color:White;float:right;cursor:pointer;margin-right:10px;" onclick="funclose('divsj')">[关闭]</span>
      </div>
      <iframe src="RegPayMsginfor.aspx" id="frameurl1" frameborder="0" style="width:700px;height:530px;overflow-x:hidden;display:none;"></iframe>
       <iframe src="RegPayMsg.aspx" id="frameurl2" frameborder="0" style="width:700px;height:520px;overflow-x:hidden;display:none;"></iframe></div>
    <div class="topstyle" id="divop" style="display:none;"></div> 
   
    <!--弹出窗口-->

    <div class="box" style="text-align:left;height:600px;">
        <div class="box_main">
            支付的帐号：<span>
                <%=username%></span> <%=RegEndTime%></div>
        <div class="box_hy">
           
         <table style="margin-left:0px;" border="0">
         <tr>
         <td style="width:64px;">会员类型：</td>
         <td>
          <asp:RadioButtonList ID="radio_usertype" runat="server"  RepeatDirection="Horizontal">
                    <asp:ListItem Value="0" Selected="True">新会员</asp:ListItem>
                    <asp:ListItem Value="10">增值服务</asp:ListItem>
                </asp:RadioButtonList>
         </td>
         </tr>
         </table>
                
               
                   
               
                   <table border="0" id="tdshichang1"><tr>
                   <td style="width:64px;">
                   开通时长：
                   </td> 
                   <td>
                    <asp:RadioButtonList ID="Radio_time" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">3个月(2000元)&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem Value="2">半年(3500元)&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem Selected="True" Value="3">1年(6000元)</asp:ListItem>
                    </asp:RadioButtonList>
                   </td>
                   </tr> </table>
                 <table  id="tdshichang2"> 
                 <tr>
                 <td style="width:64px;">其它：</td>
                 <td >
                     <asp:CheckBox ID="check_other" Text="是否需要协助上传资料(500元)" runat="server"  
                         onchange="countprice()" ForeColor="#333333"/></td>
                 </tr>
                 </table>
               

                <p id="pserverprice">
                    开通费用：
                    <span id="spanprice">6000元</span>
                </p>
                <div id="potherprice" style="text-align:left;display:none;">
                <table style="margin-left:0px;" border="0">
                <tr>
                <td>充值金额：</td><td><asp:TextBox ID="txt_prce" runat="server"></asp:TextBox> </td>
                </tr>
                  <tr>
                <td>备注：</td><td style="padding-top:10px;"><asp:TextBox ID="txt_descript" runat="server" MaxLength="100" 
                          TextMode="MultiLine" Height="58px" placeholder="请说明增值服务的内容如：产品拍摄，店铺建立等" 
                          Width="323px"></asp:TextBox> </td>
                </tr>
                </table>
                </div>
            <%--<p>
                付款金额：<span style="color: Black;" id="pricemark"><%=markprice %></span>元，优惠<span id="priceout"><%=outprice %></span>元</p>--%>
                
        </div>
         <div class="box_main" style="width: 750px;">
         <table border="0" cellpadding="0" cellspacing="0"><tr><td><input type="checkbox"  checked="checked" id="checkagree" onchange="pcheck()"/> </td> 
         <td>我已认真阅读并同意<a href="javascript:funopen('divsj','2');" >《家具快搜在线服务协议》</a>及其附件<a href="javascript:funopen('divsj','1');">《会员服务明细条款》</a></td>
         </tr> </table>
         </div>

        <div class="box_main" style="width: 750px;">
            选择支付银行：<div class="zfb">
                <input type="radio" name="je" id="jineALIPAY" checked="checked" value="ALIPAY" /><img src="../images/bank/Alipay.jpg" />
                <span style="display:none;">推荐！使用支付宝支付可以赠送1-7天的广告位一个。提示：无支付宝账户也可用此方式支付。</span>
                </div>
            <ul style="display:none;">
                <li>
                    <input type="radio" name="je" id="jineICBC" value="ICBC" /><img src="../images/bank/ICBC.jpg"></li>
                <li>
                    <input type="radio" name="je" id="jineCCB" value="CCB" /><img src="../images/bank/CCB.jpg"></li>
                <li>
                    <input type="radio" name="je" id="jineABC" value="ABC" /><img src="../images/bank/ABC.jpg"></li>
                <li>
                    <input type="radio" name="je" id="jineBOC" value="BOC" /><img src="../images/bank/BOC.jpg"></li>
                <li>
                    <input type="radio" name="je" id="jineBOCSH" value="BOCSH" /><img src="../images/bank/BOCSH.jpg"></li>
                <li>
                    <input type="radio" name="je" id="jineCMB" value="CMB" /><img src="../images/bank/CMB.jpg"></li>
                <li>
                    <input type="radio" name="je" id="jineSPDB" value="SPDB" /><img src="../images/bank/SPDB.jpg"></li>
                <li>
                    <input type="radio" name="je" id="jineGDB" value="GDB" /><img src="../images/bank/GDB.jpg"></li>
                <li>
                    <input type="radio" name="je" id="jinePSBC" value="PSBC" /><img src="../images/bank/PSBC.jpg"></li>
                <li>
                    <input type="radio" name="je" id="jineBOCOM" value="BOCOM" /><img
                        src="../images/bank/BOCOM.jpg" /></li>
                <li>
                    <input type="radio" name="je" id="jineCNCB" value="CNCB" /><img src="../images/bank/CNCB.jpg"></li>
                <li>
                    <input type="radio" name="je" id="jineCEB" value="CEB" /><img src="../images/bank/CEB.jpg"></li>
                <li>
                    <input type="radio" name="je" id="jineHXB" value="HXB" /><img src="../images/bank/HXB.jpg"></li>
                <li>
                    <input type="radio" name="je" id="jineCMBC" value="CMBC" /><img src="../images/bank/CMBC.jpg"></li>
                <li>
                    <input type="radio" name="je" id="jineCIB" value="CIB" /><img src="../images/bank/CIB.jpg"></li>
                <li>
                    <input type="radio" name="je" id="jineOTHERS" value="OTHERS" />&nbsp;&nbsp;<span style="color:#999">其他支付方式</span></li>
            </ul>
        </div>
       <!-- <div style="width: 650px; padding-left: 100px;">
            <textarea name="textarea" cols="" rows="" style="width: 440px; height: 130px; font-size: 12px;
                line-height: 24px; color: #666; margin-top: 12px;">
注册协议 
尊敬的客户，欢迎您注册成为家具快搜会员用户，在注册前请您仔细阅读如下服务条款：
1、家具快搜服务条款的确认和接纳
本网站各项服务的所有权和运作权归家具快搜拥有。

2、用户在家具快搜交易平台上不得发布下列违法信息：
(1)反对宪法所确定的基本原则的；
(2)危害国家安全，泄露国家秘密，颠覆国家政权，破坏国家统一的；
(3)损害国家荣誉和利益的；
(4)煽动民族仇恨、民族歧视，破坏民族团结的；
(5)破坏国家宗教政策，宣扬邪教和封建迷信的；
(6)散布谣言，扰乱社会秩序，破坏社会稳定的；
(7)散布淫秽、色情、赌博、暴力、凶杀、恐怖或者教唆犯罪的；
(8)侮辱或者诽谤他人，侵害他人合法权益的；
(9)含有法律、行政法规禁止的其他内容的。
(10)进行商业广告行为的。

3、有关用户隐私制度
本站未经用户同意不会向第三方透露用户的注册资料及保存在家具快搜各项服务中的非公开内容，但不包括用户在使用网站中某些功能上自己公开的信息。 

会员用户注意事项： 
(1) 请提供及时、详尽及准确的个人资料(如有变动请及时更新)，以确保您能顺利的参加本站各项活动，以及您在本站订购货品发送的准确性。
(2) 同意接收来自本网站的信息。 
(3) 用户在注册时应当选择稳定性及安全性相对较好的电子邮箱。 (4) 注册时请注意注册密码的安全。

4、用户的帐号、密码和安全性
您一旦注册成为家具快搜用户，您将得到一个密码和帐号。如果您未保管好自己的帐号或密码而对您、家具快搜或第三方造成的损害，您将负全部责任。另外，每个用户都要对其帐户中的所有活动和事件负全责。您可随时改变您的密码，也可以结束旧的帐户重开一个新帐户。用户若发现任何非法使用用户帐号或安全漏洞的情况，请立即通告家具快搜客服人员（热线电话：400 6066 818）。

5、服务条款的修改
家具快搜有权在必要时修改服务条款，家具快搜服务条款一旦发生变动，将第一时间在重要页面上告知修改内容。如果不同意所改动的内容，用户可以主动取消获得的家具快搜的服务。如果用户继续享用家具快搜服务，则视为接受服务条款的变动。家具快搜保留随时修改或中断服务而不需通知用户的权利，且不需对用户或第三方负责。

6、结束服务一项或多项服务。
家具快搜不需因中断服务对任何个人或第三方负责。用户若反对任何服务条款的建议或对后来的条款修改有异议，或对家具快搜服务不满，用户可以行使如下权利： 
(1) 不再使用家具快搜的服务。 
(2) 通知家具快搜停止对该用户的服务。 结束用户服务后，用户使用家具快搜服务的权利马上中止。从那时起，用户没有权利，家具快搜也没有义务传送任何未处理的信息或未完成的服务给用户或第三方。

7、保障
用户同意保障和维护家具快搜的利益，不得恶意注册，或恶意诽谤、攻击、损害家具快搜的声誉，如发生上述行为,家具快搜具有对用户通过法律手段追究责任的权利。

8、通告
所有发给用户的通告都会通过重要页面的公告或电子邮件或常规的信件传送。服务条款的修改、服务变更、或其它重要事件的通告都会以此形式进行。

9、信息内容的所有权
家具快搜定义的信息内容包括：文字、图片、软件、声音、视频、图表；在广告中全部内容；本网站为用户提供的其它信息。所有这些内容受版权、商标、标签和其它财产所有权法律的保护。所以，用户只能在本网站和广告商授权下才能使用这些内容，而不能擅自复制、再造这些内容、或创造与内容有关的派生产品。

10、不可抗拒因素
本网站对由互联网故障，机房升级，以系统升级，设备升设，以及一些外在的不可抗拒的因素造成的网站暂停，本网站不承担责任。

11、法律
家具快搜信息服务条款要与中华人民共和国的相关法律法规解释一致。用户和家具快搜一致同意服从家具快搜所在地有管辖权的法院管辖。如发生家具快搜服务条款与中华人民共和国法律相抵触时，则这些条款将完全按法律规定重新解释，而其它条款则依旧保持对用户的约束力。

本服务协议双方为家具快搜与家具快搜会员用户，本服务协议具有合同效力。 您确认本服务协议后，本服务协议即在您和家具快搜之间产生法律效力。请您务必在注册之前认真阅读上述全部服务协议内容，如有任何疑问，请向本站咨询。 无论您事实上是否在注册之前认真阅读了本服务协议，只要您勾选 我已经看过并同意《家具快搜会员注册条款 》 并按照家具快搜注册程序成功注册为用户，您的行为仍然表示您同意并签署了本服务协议。 

      </textarea>
        </div>-->
        <div class="button" style="margin-top:10px;margin-bottom:10px;" id="divsubmit">
            <asp:ImageButton ID="btn_OK" runat="server" ImageUrl="../images/bank/cz.jpg" Width="154" Height="36" OnClick="btn_OK_Click" />
        </div>

        
<center>
        <div class="footer" style="width:300px;">
            <img src="../images/cztp.jpg" style=" padding-right:5px;">温馨提示：如有疑问，请拨打 4000019211
        </div>
        </center>
        <div style="height:auto;">
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable" style="float:left">
    <tr>
    <th width="40px" align="center">编号</th>
    <th width="240px" align="center">定单号</th>
    
    <th align="left" width="80px">成功支付金额</th>  
     <th align="left"" width="120px">定购年数</th>  
      <th align="left"">提交类型</th>
    <th align="left">提交时间</th>
   
  
    </tr>
    <asp:Repeater ID="rptList" runat="server" >
        <ItemTemplate>
            <tr>
            <td align="center"><%#Eval("Id")%></td>
           
               
             <td align="left"><%#Eval("OrderNumber") %></td>

              <td><%#Eval("total_fee")%></td> 
               <td align="left"><%#Eval("BuyYearLen")%></td>
                     
              <td align="left"><%#getusertype(Eval("ViPType").ToString())%></td>
              <td><%#Eval("CreateTime", "{0:yyyy-MM-dd HH:mm}")%></td>      
           
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
        
        </div>

    </div> 
    </div>
    </div>
</asp:Content>
