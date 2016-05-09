<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setroleaction.aspx.cs" Inherits="TREC.Web.Admin.permission.setroleaction" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设置角色权限</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../script/admin.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".msgtable tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
            $(".msgtable tr").hover(
			    function () {
			        $(this).addClass("tr_hover_col");
			    },
			    function () {
			        $(this).removeClass("tr_hover_col");
			    }
		    );

            if ("<%=ECommon.QueryRoleId %>" == "") {
                $(".actionPannel > ul > li:first-child a").addClass("cur");
            }

            $(".nav").each(function () {
                if ($(this).hasClass("cur")) {
                    $("#hfRoleId").attr("value", $(this).attr("id"));
                }
            })

            $("a.n_chk,a.n_chkcur").live("click", function () {
                if ($(this).hasClass("n_chk")) {
                    $(this).removeClass("n_chk");
                    $(this).addClass("n_chkcur");
                }
                else {
                    if ($(this).hasClass("n_chkcur")) {
                        $(this).removeClass("n_chkcur");
                        $(this).addClass("n_chk");
                    }
                }
            });

            $(".node > a.n_chk").live("click", function () {
                var subNodeObj = $(this).parent().next(".subNode");
                $(subNodeObj).find("li > a.n_chk").addClass("n_chkcur");
                $(subNodeObj).find("li > a.n_chk").removeClass("n_chk");
            })

            $(".node > a.n_chkcur").live("click", function () {
                var subNodeObj = $(this).parent().next(".subNode");
                $(subNodeObj).find("li > a.n_chkcur").addClass("n_chk");
                $(subNodeObj).find("li > a.n_chkcur").removeClass("n_chkcur");
            })

            $(".subNode > ul> li > a.n_chkcur").live("click", function () {
                var boolisAllF = false;
                $(this).parent().parent().find("li").each(function () {
                    if ($(this).find("a.linkselect").hasClass("n_chk")) {
                        boolisAllF = true;
                    }
                })
                if (boolisAllF) {
                    $(this).parent().parent().parent().prev().find("a.linkselect").removeClass("n_chkcur");
                    if (!$(this).parent().parent().parent().prev().find("a.linkselect").hasClass("n_chk")) {
                        $(this).parent().parent().parent().prev().find("a.linkselect").addClass("n_chk");
                    }

                }
            })

            $(".subNode > ul> li > a.n_chk").live("click", function () {
                var boolisAllF = true;
                $(this).parent().parent().find("li").each(function () {
                    if ($(this).find("a.linkselect").hasClass("n_chk")) {
                        boolisAllF = false;
                    }
                })
                if (boolisAllF) {
                    $(this).parent().parent().parent().prev().find("a.linkselect").removeClass("n_chk");
                    if (!$(this).parent().parent().parent().prev().find("a.linkselect").hasClass("n_chkcur")) {
                        $(this).parent().parent().parent().prev().find("a.linkselect").addClass("n_chkcur");
                    }

                }
            })

            $(".node > span.n_r").live("click", function () {
                if ($(this).parent().hasClass("open")) {
                    $(this).parent().removeClass("open");
                    $(this).parent().addClass("close");
                    //$(this).parent().next(".subNode").animate({ height: '0px' });
                    $(this).parent().next(".subNode").hide(100);
                }
                else {
                    if ($(this).parent().hasClass("close")) {
                        $(this).parent().removeClass("close");
                        $(this).parent().addClass("open");
                        //$(this).parent().next(".subNode").animate({ height: 'auto' });
                        $(this).parent().next(".subNode").show(100);
                    }
                }
            })

            $("#lbtnUpAction").click(function () {
                var idList = "";
                $(".actionPannel").find(".module").each(function () {
                    if ($(this).find("a.linkselect").hasClass("n_chkcur")) {
                        idList += $(this).find("a.linkselect").attr("id") + ",";
                    }
                    else {
                        $(this).next(".subNode").find("a.n_chkcur").each(function () {
                            idList += $(this).attr("id") + ",";
                        })

                    }
                })
                $("#hfactionValue").attr("value", idList);
            })
        })
    </script>
    
    <style type="text/css">
        .actionPannel{width:100%; float:left;}
        .actionPannel ul{display:block; width:100%; float:left;}
        .actionPannel ul li{float:left; border-bottom:1px solid #E4E1FF; height:24px; line-height:24px; text-align:center;cursor:pointer;}
        .actionPannel ul li a{ border:1px solid #E4E1FF; display:block; margin:0px 5px 0px 5px; border-bottom:none; padding:0px 8px;}
        .actionPannel ul li a:Hover,.actionPannel ul li a.cur{background:url("../images/nav_bg.gif") repeat-x scroll 0 0 transparent; border:1px solid #E4E1FF; border-bottom:none;}
        
        .actionPannel .module{ float:left; display:block; height:24px; line-height:24px; font-weight:bold; float:left; padding-left:10px; width:100%; margin-top:10px; }
        .node span,.node a.n_chk,.node a.n_chkcur,.subNode a.n_chk,.subNode a.n_chkcur,.subNode span{width:16px; height:16px; display:block; float:left; background:url("../images/tree.gif"); background-repeat:no-repeat;}
        .node span.n_r{ background-position:-62px 0; cursor:pointer;}
        .close span.n_r{background-position:-44px 0}
        .node a.n_chk{ height:13px; width:13px; background-position:0px 0px; margin:3px 0px 0px 3px;}
        .node span.n_ico{ background-position:-80px -16px; margin:1px 0px 0px 3px;}
        .node a.n_t{display:block; float:left; height:18px; line-height:16px; margin-left:5px;}
        .node a.n_t:hover,.node a.n_t_cur{ background:#FFE6B0; border:1px solid #FFB951;}
        
        .subNode{margin-left:20px;}
        .subNode span.n_r{ background-position:-26px -18px;}
        .subNode a.n_chk{ height:13px; width:13px; background-position:0px 0px; margin:3px 0px 0px 3px; padding:0px;}
        .subNode span.n_ico{ background-position:-80px -32px; margin:1px 0px 0px 3px;}
        .node a.n_chk:hover,.subNode a.n_chk:hover{ background:url("../images/tree.gif"); background-repeat:no-repeat;background-position:0 -12px }
        .node a.n_chkcur:hover,.subNode a.n_chkcur:hover{background:url("../images/tree.gif"); background-repeat:no-repeat;background-position:0 -36px}
        
        .node a.n_chkcur,.subNode a.n_chkcur{height:13px; width:13px; background-position:0 -24px;  margin:3px 0px 0px 3px; padding:0px;}
        .subNode ul li{display:block; background:none;}
        .subNode ul li a{display:block;text-align:left; line-height:16px; float:left; margin-left:0px;}
        .subNode ul li,.subNode ul li a,.subNode ul li a:hover{border:none; background:none;}
    </style>
</head>
<body style="padding:10px;">
<form id="form1" runat="server">
<div class="navigation">
    <span class="add">&nbsp;</span><b>您当前的位置：首页 &gt; 系统管理 &gt; 设置角色权限</b>
</div>
<div class="spClear"></div>
<div class="actionPannel">
    <ul>
        <%foreach (EnRole r in RoleList)
          { %>
            <li><a href="setroleaction.aspx?rid=<%=r.id %>" class="<%=UiCommon.QueryStringCur("rid", r.id.ToString(), "", "cur")%> nav" id="<%=r.id %>"><%=r.title %></a></li>
        <%} %>
    </ul>
    <%foreach(EnModule m in ModuleList){ %>
    <div class="module node open"><span class="n_r"></span><a class="linkselect <%=m.isRoleHas == 1 ? "n_chkcur" : "n_chk"%>" id="m_<%=m.id %>"></a><span class="n_ico"></span><a href="javascript:;" class="n_t"><%=m.title %></a></div>
    <div class="subNode">
        <ul>
            <%foreach (EnAction a in ActionList.Where(x=>x.mid==m.id).ToList())
              { %>
                <li><span class="n_r"></span><a class="linkselect <%=a.isActionHas == 1 ? "n_chkcur" : "n_chk"%>" id="s_<%=a.id %>_<%=m.id %>"></a><span class="n_ico"></span><a href="javascript:;"><%=a.title %></a></li>
            <%} %>
            
        </ul>
    </div>
    <%} %>
</div>
<div class="spClear"></div>
&nbsp;&nbsp;
<span class="btn_bg">
     <asp:LinkButton ID="lbtnUpAction" runat="server"  
    OnClientClick="return confirm( '确定要更新该角色的权限？ ');" onclick="lbtnUpAction_Click" >更新</asp:LinkButton>&nbsp;&nbsp;     
</span>
<asp:HiddenField ID="hfactionValue" runat="server" />
<asp:HiddenField ID="hfRoleId" runat="server" />
</form>
</body>
</html>
