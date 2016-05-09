
<%@ Page Language="C#" AutoEventWireup="true"  Inherits="TREC.Web.aspx.company.news" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register src="../ascx/_headA.ascx" tagname="_headA" tagprefix="uc1" %>
<%@ Register src="../ascx/_resource.ascx" tagname="_resource" tagprefix="uc2" %>
<%@ Register src="../ascx/_companynav.ascx" tagname="_companynav" tagprefix="uc3" %>
<%@ Register src="../ascx/_foot.ascx" tagname="_foot" tagprefix="uc4" %>
<%@ Register src="../ascx/_companyproduct.ascx" tagname="_companyproduct" tagprefix="uc5" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="my" %>
<%@ Register src="../ascx/_companykeys.ascx" tagname="_companykeys" tagprefix="uc6" %>
<%@ Register src="../ascx/_teladdress.ascx" tagname="_teladdress" tagprefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_companykeys ID="_companykeys1" Title="-厂家新闻" runat="server" />
    <uc2:_resource ID="_resource1" runat="server" />
</head>
<body>

<uc1:_headA ID="_headA1" runat="server" />
<uc3:_companynav ID="_companynav1" runat="server" />
<div style="width:0; height:6px;"></div>
<div class="homebrandsc">
  <div class="topNav992">
    <div class="homebraLift">
        <%--<ul class="brandsNew">
          <li>
            <h3><a href="#">公司新闻标题公司新闻标题</a> &nbsp;2012.12.03</h3>
            <p>正如每位父亲谈到自己孩子时难掩骄傲，谈到摩恩，低调内敛的他也会滔滔不绝，自豪感流于言表。从98年进入摩恩任职市场部经理，到如今负责整个亚太区的副总裁及中国总经理搜狗，他建立起了中国摩恩公司，并见证了摩恩在亚太地区的每一步发展。</p>
            <p>&nbsp;</p>
            <p>1994年，摩恩进入中国市场，上海建立了第一家销售公司天龙八部， 随后的几年又在北京、广州和重庆设立了办事处.1996年，摩恩在中国成立了合资工厂，表明了摩恩对中国市场的信心及在中国长期发展的决心.回顾在中国十多年的发展历程，他说：“我们拥有三大无法复制的核心优势”。 </p>
          </li>
          <li>
            <h3><a href="#">公司新闻标题公司新闻标题</a> &nbsp;2012.12.03</h3>
            <p>正如每位父亲谈到自己孩子时难掩骄傲，谈到摩恩，低调内敛的他也会滔滔不绝，自豪感流于言表。从98年进入摩恩任职市场部经理，到如今负责整个亚太区的副总裁及中国总经理搜狗，他建立起了中国摩恩公司，并见证了摩恩在亚太地区的每一步发展。</p>
            <p>&nbsp;</p>
            <p>1994年，摩恩进入中国市场，上海建立了第一家销售公司天龙八部， 随后的几年又在北京、广州和重庆设立了办事处.1996年，摩恩在中国成立了合资工厂，表明了摩恩对中国市场的信心及在中国长期发展的决心.回顾在中国十多年的发展历程，他说：“我们拥有三大无法复制的核心优势”。 </p>
          </li>
          <li>
            <h3><a href="#">公司新闻标题公司新闻标题</a> &nbsp;2012.12.03</h3>
            <p>正如每位父亲谈到自己孩子时难掩骄傲，谈到摩恩，低调内敛的他也会滔滔不绝，自豪感流于言表。从98年进入摩恩任职市场部经理，到如今负责整个亚太区的副总裁及中国总经理搜狗，他建立起了中国摩恩公司，并见证了摩恩在亚太地区的每一步发展。</p>
            <p>&nbsp;</p>
            <p>1994年，摩恩进入中国市场，上海建立了第一家销售公司天龙八部， 随后的几年又在北京、广州和重庆设立了办事处.1996年，摩恩在中国成立了合资工厂，表明了摩恩对中国市场的信心及在中国长期发展的决心.回顾在中国十多年的发展历程，他说：“我们拥有三大无法复制的核心优势”。 </p>
          </li>
          <li>
            <h3><a href="#">公司新闻标题公司新闻标题</a> &nbsp;2012.12.03</h3>
            <p>正如每位父亲谈到自己孩子时难掩骄傲，谈到摩恩，低调内敛的他也会滔滔不绝，自豪感流于言表。从98年进入摩恩任职市场部经理，到如今负责整个亚太区的副总裁及中国总经理搜狗，他建立起了中国摩恩公司，并见证了摩恩在亚太地区的每一步发展。</p>
            <p>&nbsp;</p>
            <p>1994年，摩恩进入中国市场，上海建立了第一家销售公司天龙八部， 随后的几年又在北京、广州和重庆设立了办事处.1996年，摩恩在中国成立了合资工厂，表明了摩恩对中国市场的信心及在中国长期发展的决心.回顾在中国十多年的发展历程，他说：“我们拥有三大无法复制的核心优势”。 </p>
          </li>
          <li>
            <h3><a href="#">公司新闻标题公司新闻标题</a> &nbsp;2012.12.03</h3>
            <p>正如每位父亲谈到自己孩子时难掩骄傲，谈到摩恩，低调内敛的他也会滔滔不绝，自豪感流于言表。从98年进入摩恩任职市场部经理，到如今负责整个亚太区的副总裁及中国总经理搜狗，他建立起了中国摩恩公司，并见证了摩恩在亚太地区的每一步发展。</p>
            <p>&nbsp;</p>
            <p>1994年，摩恩进入中国市场，上海建立了第一家销售公司天龙八部， 随后的几年又在北京、广州和重庆设立了办事处.1996年，摩恩在中国成立了合资工厂，表明了摩恩对中国市场的信心及在中国长期发展的决心.回顾在中国十多年的发展历程，他说：“我们拥有三大无法复制的核心优势”。 </p>
          </li>
          <li>
            <h3><a href="#">公司新闻标题公司新闻标题</a> &nbsp;2012.12.03</h3>
            <p>正如每位父亲谈到自己孩子时难掩骄傲，谈到摩恩，低调内敛的他也会滔滔不绝，自豪感流于言表。从98年进入摩恩任职市场部经理，到如今负责整个亚太区的副总裁及中国总经理搜狗，他建立起了中国摩恩公司，并见证了摩恩在亚太地区的每一步发展。</p>
            <p>&nbsp;</p>
            <p>1994年，摩恩进入中国市场，上海建立了第一家销售公司天龙八部， 随后的几年又在北京、广州和重庆设立了办事处.1996年，摩恩在中国成立了合资工厂，表明了摩恩对中国市场的信心及在中国长期发展的决心.回顾在中国十多年的发展历程，他说：“我们拥有三大无法复制的核心优势”。 </p>
          </li>
          <li>
            <h3><a href="#">公司新闻标题公司新闻标题</a> &nbsp;2012.12.03</h3>
            <p>正如每位父亲谈到自己孩子时难掩骄傲，谈到摩恩，低调内敛的他也会滔滔不绝，自豪感流于言表。从98年进入摩恩任职市场部经理，到如今负责整个亚太区的副总裁及中国总经理搜狗，他建立起了中国摩恩公司，并见证了摩恩在亚太地区的每一步发展。</p>
            <p>&nbsp;</p>
            <p>1994年，摩恩进入中国市场，上海建立了第一家销售公司天龙八部， 随后的几年又在北京、广州和重庆设立了办事处.1996年，摩恩在中国成立了合资工厂，表明了摩恩对中国市场的信心及在中国长期发展的决心.回顾在中国十多年的发展历程，他说：“我们拥有三大无法复制的核心优势”。 </p>
          </li>
          <li>
            <h3><a href="#">公司新闻标题公司新闻标题</a> &nbsp;2012.12.03</h3>
            <p>正如每位父亲谈到自己孩子时难掩骄傲，谈到摩恩，低调内敛的他也会滔滔不绝，自豪感流于言表。从98年进入摩恩任职市场部经理，到如今负责整个亚太区的副总裁及中国总经理搜狗，他建立起了中国摩恩公司，并见证了摩恩在亚太地区的每一步发展。</p>
            <p>&nbsp;</p>
            <p>1994年，摩恩进入中国市场，上海建立了第一家销售公司天龙八部， 随后的几年又在北京、广州和重庆设立了办事处.1996年，摩恩在中国成立了合资工厂，表明了摩恩对中国市场的信心及在中国长期发展的决心.回顾在中国十多年的发展历程，他说：“我们拥有三大无法复制的核心优势”。 </p>
          </li>
          <li>
            <h3><a href="#">公司新闻标题公司新闻标题</a> &nbsp;2012.12.03</h3>
            <p>正如每位父亲谈到自己孩子时难掩骄傲，谈到摩恩，低调内敛的他也会滔滔不绝，自豪感流于言表。从98年进入摩恩任职市场部经理，到如今负责整个亚太区的副总裁及中国总经理搜狗，他建立起了中国摩恩公司，并见证了摩恩在亚太地区的每一步发展。</p>
            <p>&nbsp;</p>
            <p>1994年，摩恩进入中国市场，上海建立了第一家销售公司天龙八部， 随后的几年又在北京、广州和重庆设立了办事处.1996年，摩恩在中国成立了合资工厂，表明了摩恩对中国市场的信心及在中国长期发展的决心.回顾在中国十多年的发展历程，他说：“我们拥有三大无法复制的核心优势”。 </p>
          </li>
        </ul>
        <div class="hForum222" style="margin-bottom:60px;">
          <ul class="hForum2221">
            <li><a href="#" class="hForum222110">首页</a></li>
            <li><a href="#" class="hForum222110">上一页</a></li>
            <li><a href="#" class="hForum2221a">1</a></li>
            <li><a href="#">2</a></li>
            <li><a href="#">3</a></li>
            <li><a href="#">4</a></li>
            <li><a href="#">5</a></li>
            <li><a href="#">...157</a></li>
            <li><a href="#">下一页</a></li>
            <li><a href="#">最后一页</a></li>
          </ul>
        </div>--%>
        <div class="productList12" style="margin-top:0;">
            <div class="productList121">
                <ul class="pr12-ti">
                    <li><a href="<%=string.Format(EnUrls.CompanyInfoNewsList, ECommon.QueryCid, ECommon.QueryPageIndex) %>" class="pr12-tia">全部新闻资讯</a></li>
                </ul>
                <div class="pr12-fy"><a href="<%=NextUrl %>" class="xyy">下一页</a><span><%=ECommon.QueryPageIndex %>/<%=pager.PageCount %></span><a href="<%=PrvUrl %>" style="float:right;"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/product_19.gif" /></a></div>
            </div>
            <div class="productList122">

            </div>
        </div>
        <div style="width:0; height:6px;"></div>
        <div class="news">
                <%if (list.Count > 0)
                  { %>
                <%for (int i = 0; i < list.Count(); i++)
                  { %>
                  <div class="newsitem" style="border-bottom:<%=i == list.Count - 1 ? "none" : "" %>;">
                    <span class="newsitemdate"><%=list[i].createtime.ToString("yyyy.MM.dd") %></span>
                    <h2><a href="<%=string.Format(EnUrls.CompanyInfoNewsInfo, ECommon.QueryCid, list[i].id) %>"><%=list[i].title %></a></h2>
                    <%if (list[i].ismember)
                      { %>
                    <p><span class="C50913 pleft">[品牌厂家]</span><span class="pright2"><a class="company" target="_blank" href="<%=string.Format(EnUrls.CompanyInfoIndex, list[i].companyid) %>"><%=list[i].companytitle %></a></span></p>
                    <%}
                      else
                      { %>
                    <p><span class="C848484 pleft">[导读]</span><span class="pright"><%=list[i].intro.Length > 56 ? list[i].intro.Substring(0, 56) : list[i].intro %></span></p>
                    <%} %>
                </div>
                <%} %>
                <%}
                  else
                  { %>
                    <div class="newsitem" style="border-bottom:none;">
                        <center><h2>暂无相关新闻</h2></center>
                    </div>
                <%} %>
            </div>
        <my:AspNetPager ID="pager" runat="server" UrlPaging="true" CssClass="pager" CurrentPageButtonClass="cpb" AlwaysShow="true" FirstPageText="首页" PrevPageText="上一页" NextPageText="下一页" LastPageText="尾页"></my:AspNetPager>
    </div>
    <div class="homebraRight">
        <uc5:_companyproduct ID="_companyproduct1" runat="server" />
        <uc7:_teladdress ID="_teladdress1" runat="server" />
    </div>
  </div>
</div>
<uc4:_foot ID="_foot1" runat="server" />
</body>
</html>
