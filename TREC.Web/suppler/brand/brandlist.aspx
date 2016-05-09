<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Member.Master" CodeBehind="brandlist.aspx.cs" Inherits="TREC.Web.Suppler.brand.brandlist" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Import Namespace="TREC.ECommerce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../script/myPublic.js"></script>    
<style type="text/css">
    .pop{position:absolute; }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maintitle"><h1><u>品牌管理</u></h1></div>
<div class="maincon"><div>
<div class="cpTitle">
	<ul><li style="position:relative;cursor:default;" class="tabActive" id="two1"><a>品牌管理</a></li>
	<li onclick="location.href='brandslist.aspx';" style="position:relative;" class="tabNormal" id="two2"><a href="brandslist.aspx">系列管理</a></li>
	</ul> 
</div>
<div style="DISPLAY: block" id="con_two_1" class="cplist"> <br>

<input type="button" onclick="location.href='<%=brandUrl %>';" value="添加新品牌" class="btnadd marbtm">
  <div class="msgtable">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="brandlist">
      <tbody><tr class="titlecor">
        <th width="9%">选择</th>
            <th width="13%">编号</th>
            <th width="26%">LOGO图片</th>
            <th width="16%">品牌名称</th>
            <th width="18%">状态<img width="11" align="absmiddle" height="11" src="../Images/xlup.gif"></th>
            <th width="9%">编辑</th>
            <th width="9%">删除</th>
          </tr>
          <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <input type="checkbox"  value="<%#Eval("Id")%>">  </td>
                    <td><%#Eval("Id")%></td>
                    <td><img width="100" border="0" height="60" style="margin:5px 0;" src="<%#TREC.Entity.EnFilePath.GetBrandLogoPath(Eval("Id")!=null?Eval("Id").ToString():"",Eval("logo")!=null?Eval("logo").ToString():"") %>"></td>
                    <td><%#Eval("title") %></td>
                    <td><%#GetStatusStr(Eval("linestatus"))%></td>
                    <td><a href="brandinfo.aspx?edit=1&id=<%#Eval("id") %>"><img width="16" border="0" height="16" alt="编辑" src="../Images/bianji.png"></a></td>
                    <td><a onclick="delSingleBrand(<%#Eval("Id")%>);" href="Javascript:void();"><img width="16" border="0" height="16" alt="删除" src="../Images/del.png"></a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>            
      </tbody></table>
  </div>
  <%if (!string.IsNullOrEmpty(pageStr)) { Response.Write(pageStr); } %>
  <div class="btmenu">
    <p> <a onclick="chkAll(this,'brandlist');" id="off" class="bome">全选</a><a href="<%=brandUrl %>" class="bome">添加</a><a class="bome" onclick="doBrandStatus('up');">上线</a>
    <a class="bome" onclick="doBrandStatus('down');">下线</a>
       
    <a onclick="showDelBox('');" class="bome">删除</a>&nbsp;&nbsp;<span class="lookdel"><img width="11" align="absmiddle" height="13" alt="回收站" src="../Images/ljt.gif">&nbsp;<a href="recyclebrandlist.aspx">&nbsp;查看已删除品牌</a></span></p>
  </div>
</div>
</div>

	<!-- 标签切换 end -->
</div>
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

        var pagequantity = '<%=pagequantity %>';
        if (pagequantity.toString() != '10') {
            $('.pages select option[value=' + pagequantity.toString() + ']').attr('selected', true);
        }
    });
    function showDelBox(brandId) {
        if (brandId == '') {
            //判断是否选择了品牌
            brandId = checkSelectedObj('brandlist');
            if (brandId == '') {
                alert('抱歉，请选择您要删除的品牌！');
                return;
            }
        }

        if ($('.mainbox .pop').size() == 0) {
            var myhtml = showDelBoxHtml('您将把这个品牌从这里移除，点击右下角的“查看已删除品牌”可进行还原。', brandId, 'del', '删除确认');
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

    function delSingleBrand(brandId) {
        showDelBox(brandId);
    }

    //品牌（上、下）线
    function doBrandStatus(Type) {
        var TypeName = Type == 'down' ? '下线' : '上线';
        //判断是否选择了产品
        var brandId = checkSelectedObj('brandlist');
        if (brandId == '') {
            alert('抱歉，请选择您要' + TypeName + '的品牌！');
            return;
        }
        var myhtml = showDelBoxHtml('您将把这个品牌从这里' + TypeName + '，' + (Type == 'down' ? '下线后该品牌将不在前台显示' : '需要等待管理员审核，审核后才能在前台显示') + '。', brandId, Type, TypeName + '确认');
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

    //删除品牌
    function doAboutDb(brandId, type) {
        $.ajax({
            url: '../ajax/MemberHandler.ashx',
            dataType: 'text',
            data: 'brandId=' + brandId.toString() + '&Action=' + type.toString() + '&rnd=' + Math.random(),
            success: function (data) {
                if (data.toString() == 'sccuess') {
                    cancelCheckBoxChecked('brandlist');
                    var message = '';
                    switch (type.toString()) {
                        case 'up':
                            message = '品牌上线正在申请中，请等待审核！';
                            break;
                        case 'down':
                            message = '品牌下线成功！';
                            break;
                        default:
                            message = '品牌已删除至品牌回收站，您可以到品牌回收站查看！';
                            break;
                    }
                    alert(message);
                    location.reload();
                } else if (data.toString() == 'fail') {
                    if (type == 'up') {
                        alert('抱歉，系统正忙品牌上线申请失败！');
                    }
                    else {
                        alert('抱歉，系统正忙' + TypeName.toString() + '品牌失败！');
                    }
                }
            }
        });
    }
   //-->
</script>
</asp:Content>