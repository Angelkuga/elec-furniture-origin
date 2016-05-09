<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_head.ascx.cs" Inherits="TREC.Web.aspx.ascx._head" %>
<div class="topNav">
	<div class="topNav992 top">
    	<div class="topCity"><span>上海</span>
            <div class="topCity1"><a href="#" class="a1"></a>
            <ul class="topCity12"><span>全国</span><span>上海</span><span>广州</span><span>深圳</span></ul>
            </div>
        </div>
        <div class="topLogin"><%--<img src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/index_04.gif" alt="联系电话"/>--%>
        <%if (TRECommon.CookiesHelper.GetCookie("mid") != "" && TRECommon.CookiesHelper.GetCookie("mname") != "" && TRECommon.CookiesHelper.GetCookie("mpwd") != "")
              { %>
               您好：<a href="<%=TREC.ECommerce.ECommon.WebUrl %>/suppler/index.aspx"><strong>[<%=TRECommon.CookiesHelper.GetCookie("mname") != "" && TRECommon.CookiesHelper.GetCookie("mname").Length > 7 ? TRECommon.CookiesHelper.GetCookie("mname").Substring(0, 7) + ".." : TRECommon.CookiesHelper.GetCookie("mname") %>]</strong></a>
              <%--<a href="<%=TREC.ECommerce.ECommon.WebUrl %>/suppler/index.aspx">[系统]</a>--%>
              <a href="<%=TREC.ECommerce.ECommon.WebUrl %>/loginout.aspx">[退出]</a>
            <%}else{ %>            
            <a href="<%=TREC.ECommerce.ECommon.WebUrl %>reg.aspx?r=l">供应商登录</a> &nbsp;/&nbsp; 
            <a href="<%=TREC.ECommerce.ECommon.WebUrl %>reg.aspx">申请入驻</a> 
			
            <%} %>
    </div>
    </div> 