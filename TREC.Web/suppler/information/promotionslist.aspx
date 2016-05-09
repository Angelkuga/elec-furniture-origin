<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotionslist.aspx.cs" MasterPageFile="../Member.Master" Inherits="TREC.Web.Suppler.information.promotionslist" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Import Namespace="TREC.ECommerce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../script/myPublic.js"></script>    
<style type="text/css">
 .pop{position:absolute;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maintitle"><h1><u>商务信息发布</u></h1></div>
<div class="maincon">
<div class="sobox"><table width="100%" cellspacing="0" cellpadding="0" border="0">
  <tbody><tr>
    <td height="40" align="right">发布时间</td>
    <td class="textleft"><input type="text" onclick="WdatePicker({skin:'whyGreen'});" value="<%if (issueDate != null) { Response.Write(DateTime.Parse(issueDate.ToString()).ToString("yyyy-MM-dd")); } %>" size="16" maxlength="10" id="issueDate">
    <span class="nortip">（例：2012-06-09）</span></td>
    <td align="right" rowspan="2">关键字</td>
    <td class="textleft" rowspan="2"><input type="text" size="24" value="<%=keyWord %>" maxlength="50" id="keyWord"></td>
    <td rowspan="2"><input type="button" class="btnso" onclick="searchBussinessInfo();" value="搜索"></td>
    </tr>
  <tr>
    <td height="40" align="right">剩余时间</td>
    <td class="textleft"><span style="font-family:simsun;">≤</span>
      <input type="text" size="13" value="<%if(0 < sDay){Response.Write(sDay);} %>" maxlength="4" id="sDay" style="ime-mode: disabled;">
      天</td>
    </tr>  
</tbody></table>
</div>
<div class="msgtable">
  <input type="button" onclick="location.href='promotionsinfo.aspx';" value="添加新信息" class="btnadd marbtm">
  查看  
  <select id="infoType" onchange="changeUrlPara(this,'Type','select');"><option value="">不限</option><option value="1">促销</option><option value="2">活动</option><option value="3">新闻</option><option value="4">招商</option></select>
  &nbsp;&nbsp;最近
  <select onchange="changeUrlPara(this,'Day','select');" id="msday">
    <option value="">不限</option>
    <option value="3">3天</option>
    <option value="7">1周</option>
    <option value="30">1个月</option>
    <option value="90">3个月</option>
    <option value="180">半年</option>
    <option value="365">1年</option></select>
  <table width="100%" cellspacing="0" cellpadding="0" border="0" id="infolist">
  <tr class="titlecor">
    <th>选择</th>
    <th>编号</th>
    <th>类别</th>
    <th>标题</th>
    <th>发布时间</th>
    <th>剩余<img width="11" height="11" align="absmiddle" src="../images/xldown.gif"></th>
    <th>关注数<img width="11" height="11" align="absmiddle" src="../images/xldown.gif"></th>
    <th>推荐</th>
    <th>状态<img width="11" height="11" align="absmiddle" src="../images/xlup.gif"></th>
    <th>编辑</th>
    <th>删除</th>
  </tr>  
  <asp:Repeater ID="rptList" runat="server">
  <ItemTemplate>
  <tr>
    <td style="height:36px;"><input type="checkbox" value="<%#Eval("id")%>" name="checkbox"></td>
    <td><%#Eval("id")%></td>
    <td><%#Eval("attribute") == null ? "其他" : Eval("attribute")%></td>
    <td style="width:260px;"><%#Eval("title")%></td>
    <td><%#Eval("lastedittime","{0:yyyy-MM-dd}")%></td>
    <td><%#GetSurplusDay(Eval("enddatetime")==null?"":Eval("enddatetime").ToString())%></td>
    <td><%#Eval("hits") == null ? "&mdash;" : Eval("hits").ToString()%></td>
    <td><input type="text" class="tjwd" size="6" value="<%#Eval("sort") %>" id="recommand162" style="ime-mode: disabled;"></td>
    <td><%#GetInfoStatus(Eval("linestatus").ToString())%></td>
    <td><a href="promotionsinfo.aspx?id=<%#Eval("id")%>"><img width="16" height="16" border="0" alt="编辑" src="../images/bianji.png"></a></td>
    <td><a onclick="deleteSingleInfo(<%#Eval("id")%>);" href="javascript:void();"><img width="16" height="16" border="0" alt="删除" src="../images/del.png"></a></td>
    </tr>
  </ItemTemplate>
  </asp:Repeater>  
</table>
</div>
<%=pageStr %>
<div class="btmenu">
<p>
<a onclick="chkAll(this,'infolist');" id="off" class="bome">全选</a><a href="promotionsinfo.aspx" class="bome">添加</a><a onclick="doBussinessInfo(this,'online');" class="bome">上线</a><a onclick="doBussinessInfo(this,'offline');" class="bome">下线</a>
<a onclick="doBussinessInfo(this,'delete');" class="bome">删除</a>&nbsp;&nbsp;<span class="lookdel">注：推荐里所填数据越大，信息显示越靠前。</span></p>
</div>
</div>
<script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="../script/formValidatorRegex.js"></script>
<script type="text/javascript">
   <!--
    $(function () {
        //弹出的删除提示框始终位于屏幕中间
        $(window).scroll(function () {
            if ($('.mainbox .pop').size() != 0) {
                $('.mainbox .pop').css('top', ($(window).height() - $('.mainbox .pop').height()) / 2 + $(document).scrollTop() + 'px');
                $('.mainbox .pop').css('left', ($(window).width() - $('.mainbox .pop').width()) / 2 + 'px');
            }
        });

        $('#sDay').numeral();
        $('.tjwd').numeral();
        $('.tjwd').change(function () {
            var myvalue = $.trim($(this).val());
            var infoId = $(this).attr('id').toString().replace('recommand', '');
            $.ajax({
                url: '../ajax/MemberHandler.ashx',
                dataType: 'text',
                data: 'infoId=' + infoId.toString() + '&Action=updaterc&Recommend=' + myvalue.toString() + '&rnd=' + Math.random(),
                success: function (data) { }
            });
        });
        var day = '<%=day %>';
        if (day.toString() != '0') {
            $('#msday option[value=' + day.toString() + ']').attr('selected',true);
        }
        var type = '<%=Type %>';
        if (type.toString() != '0') {
            $('#infoType option[value=' + type.toString() + ']').attr('selected', true);
        }
        var pagequantity = '<%=pagequantity %>';
        if (pagequantity.toString() != '10') {
            $('.pages select option[value=' + pagequantity.toString() + ']').attr('selected', true);
        }
    })

    function searchBussinessInfo() {
        var myurl = 'promotionslist.aspx?';
        //发布时间
        var issueDate = $.trim($('#issueDate').val());
        if (issueDate != '') {
            if (isDate(issueDate)) {
                myurl += 'issueDate=' + issueDate.toString() + '&amp;';
            }
        }
        //剩余时间
        var sDay = $.trim($('#sDay').val());
        if (sDay != '') {
            myurl += 'sDay=' + sDay.toString() + '&amp;';
        }
        //关键字
        var keyWord = $.trim($('#keyWord').val());
        if (keyWord != '') {
            myurl += 'keyWord=' + escape(keyWord.toString()) + '&amp;';
        }
        myurl = myurl.substring(0, myurl.length - 1);
        location.href = myurl;
    }    

    //单条删除商务信息
    function deleteSingleInfo(infoId) {
        if ($('.mainbox .pop').size() == 0) {
            var message = '您将把商务信息从这里移除，点击确定，商务信息将彻底删除不可还原。';
            var myhtml = showDelBoxHtml(message, infoId, 'delete', '删除确认');
            $(myhtml).insertAfter($('.mainbox .maincon'));
            $('.mainbox .pop').css('top', ($(window).height() - $('.mainbox .pop').height()) / 2 + $(document).scrollTop() + 'px');
            $('.mainbox .pop').css('left', ($(window).width() - $('.mainbox .pop').width()) / 2 + 'px');
            $('.pop i').click(function () {
                hideDelBox();
            });
            $('.pop .btnlitr').click(function () {
                hideDelBox();
            });
        }
    }

    //上线、下线、删除
    function doBussinessInfo(obj,type) {
        var typeName = $(obj).html();
        var infoId = checkSelectedObj('infolist');
        if (infoId=='') {
            alert('抱歉，请选择您要' + typeName.toString() + '的商务信息！');
            return;
        }
        var message = '';
        switch (type.toString()) {
            case 'delete':
                message = '您将把商务信息从这里移除，点击确定，商务信息将彻底删除不可还原。';
                break;
            case 'online':
                message = '您将把这个商务信息从这里上线，需要等待管理员审核，审核后才能在前台显示。';
                break;
            default:
                message = '您将把这个商务信息从这里下线，下线后该商务信息将不在前台显示。';
                break;
        }
        if ($('.mainbox .pop').size() == 0) {
            var myhtml = showDelBoxHtml(message, infoId, type, typeName + '确认');
            $(myhtml).insertAfter($('.mainbox .maincon'));
            $('.mainbox .pop').css('top', ($(window).height() - $('.mainbox .pop').height()) / 2 + $(document).scrollTop() + 'px');
            $('.mainbox .pop').css('left', ($(window).width() - $('.mainbox .pop').width()) / 2 + 'px');
            $('.pop i').click(function () {
                hideDelBox();
            });
            $('.pop .btnlitr').click(function () {
                hideDelBox();
            });
        }
    }

    //上线（下线、删除）商务信息
    function doAboutDb(infoId, type) {
        $.get('../ajax/MemberHandler.ashx', { infoId: infoId.toString(), type: type.toString(), Action: 'handleinfo', rnd: Math.random() }, function (data) {           
            if (data != null) {
                var TypeName = "删除";
                if (type.toString() == 'online') {
                    TypeName = '上线';
                } else if (type.toString() == 'offline') {
                    TypeName = '下线';
                }
                if (data == 'success') {
                    alert('商务信息' + TypeName.toString() + '成功！');
                    cancelCheckBoxChecked('infolist');
                    location.reload();
                } else if (data == 'exception') {
                    alert('抱歉，系统正忙' + TypeName.toString() + '商务信息失败！');
                }
            }
        });
    }
   //-->
</script>
<div class="clear"></div>
</asp:Content>