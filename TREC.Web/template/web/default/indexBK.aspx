<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.index" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="Haojibiz.Model" %>
<%@ Import Namespace="Haojibiz.Data" %>
<%@ Import Namespace="Haojibiz.DAL" %>

<%@ Register src="ascx/_resource.ascx" tagname="_resource" tagprefix="uc1" %>
<%@ Register src="ascx/_head.ascx" tagname="_head" tagprefix="uc2" %>
<%@ Register src="ascx/_foot.ascx" tagname="_foot" tagprefix="uc3" %>
<%@ Register src="ascx/_navindex.ascx" tagname="_nav" tagprefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>家具快搜-中国品牌家具信息发布官网_最全的家具品牌、厂商、店铺、家居卖场信息发布和搜索！</title>
<meta name="keywords" content="家具品牌,家具品牌排名,家具十大品牌,品牌家具,实木家具十大品牌,儿童家具十大品牌,板式家具十大品牌">
<meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！">
    <uc1:_resource ID="_resource1" runat="server" />
</head>
<body>
<%--<uc2:_head ID="_head1" runat="server" />--%>
<div class="topNav">
	<uc2:_head ID="_head2" runat="server" />
    <uc4:_nav ID="_nav1" runat="server" />
</div>

<!---topNav-end-->
<div class="top-main">
    <div class="m l">
        <div class="ban">
            <ul>
                <li><a href="/reg.aspx?r=l"><img src="/resource/web/images/home/home56.jpg" alt="入住家具快搜"/></a></li>
            </ul>
        </div> 
        <!---xs-end-->        
    </div>
    <!---m-end-->
    <div class="side l">
        <div class="nsubright">
        <div class="login-nav">
        <ul>
        <li><a href="/reg.aspx?r=l" target="_blank" title="供应商登录" class="register-btn">供应商登录</a></li>
        <li><a href="/reg.aspx" target="_blank" title="申请入驻" class="login-btn">申请入驻</a></li>
        </ul>
        <div class="clear"></div>
        </div>
        <div class="zhinfo snline">
          <h1>
            <p>综合信息</p>
            <span><a href="/promotions/list.aspx" target="_blank">更多>></a></span></h1>
          <ul>
            <li><i>·</i><a href="/promotions/19/info.aspx" target="_blank">家具快搜入驻优惠活动最低1000元</a></li>
            <li><i>·</i><a href="/promotions/20/info.aspx" target="_blank">红枣木卧房四件套 15800！</a></li>
            <li><i>·</i><a href="/promotions/7/info.aspx" target="_blank">红星美凯龙汶水店端午缤纷礼</a></li>
            <li><i>·</i><a href="/promotions/5/info.aspx" target="_blank">玉庭哈尔滨市旗舰店7月13日开业！</a></li>
            <li><i>·</i><a href="/promotions/41/info.aspx" target="_blank">纯核桃木 无辅料 无贴面 卧房四件套14800！</a></li>
            <li><i>·</i><a href="/promotions/3/info.aspx" target="_blank">美特龙6月纳凉特惠季</a></li>
          </ul>
        </div>
        <a href="http://www.jiajuks.com/company/84/index.aspx" target="_blank"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/adv1.jpg" /></a></div>
        <div class="clear"></div>
    </div>
    <!---aside-end-->    
</div>
<div align="center">
<div class="maichangmk snline">
<h1>推荐卖场<span><a href="/market/list.aspx" target="_blank">更多>></a></span></h1>
<%if (marketQhAd != null)
  {
      if (0 < marketQhAd.Count)
      {%><div class="msubleft"><div id="indexfocus">
<ul>
<%
    foreach (EnAggregation model in marketQhAd)
        Response.Write("<li><div><a href=\""+model.url+"\" target=\"_blank\"><img src=\"/upload/aggregation/thumb/" + model.id + "/" + model.thumb.TrimEnd(',').Trim() + "\" alt=\""+model.title+"\" /></a></div></li>");
           %>
</ul><%if(1 < marketQhAd.Count){ %><script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/script/rotationpic.js"></script><%} %>
</div></div><%}
  } %>
<div class="msubright">
<ul>
<%if (marketRightAd != null)
  {
      if (0 < marketRightAd.Count)
      {
          int i = 1;
          int j = marketRightAd.Count / 2;          
          if (marketRightAd.Count % 2 != 0)
              ++j;
          int m = 1;
          foreach (EnAggregation model in marketRightAd)
          {
              if (i % 2 == 1)
              {
                  if (m == j)
                      Response.Write("<li style=\"border-bottom:0;\">");
                  else
                      Response.Write("<li>");
                  ++m;
              }
              Response.Write("<a href=\"" + model.url + "\" target=\"_blank\"><img src=\"/upload/aggregation/thumb/" + model.id + "/" + model.thumb.TrimEnd(',').Trim() + "\" alt=\"" + model.title + "\" border=\"0\" /></a>");
              if (i % 2 == 0 || i == marketRightAd.Count)
                  Response.Write("</li>");
              ++i;
          }
      }
  }%>
</ul></div>
<div class="clear"></div>
</div>
</div>
<div class="brandlist">
    <div class="hot">
        <h2>推荐品牌</h2>
        <ul class="fix">
            <li class="hot-i1">
                <a href="http://www.jiajuks.com/company/210/index.aspx" target="_blank">
                    <img alt="北欧E家" src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/hot-1.jpg"/><p>北欧E家</p></a>
                <a href="http://www.jiajuks.com/company/136/index.aspx" target="_blank">
                    <img alt="雅梦莎" src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/hot-2.jpg"/><p>雅梦莎</p></a>
            </li>
            <li class="hot-i2">
                <a href="http://www.jiajuks.com/company/84/index.aspx" target="_blank">
                    <img alt="楷模" src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/hot-3.jpg"/><p>楷模</p></a>
                <a href="http://www.jiajuks.com/company/198/index.aspx" target="_blank">
                    <img alt="玉庭" src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/hot-4.jpg"/><p>玉庭</p></a>
            </li>
            <li class="hot-i3">
                <a href="http://www.jiajuks.com/company/195/index.aspx" target="_blank">
                <img alt="法朗仕" src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/hot-5.jpg"/><p>法朗仕</p></a>
            </li>
        </ul>
    </div>
    <!--hot-end-->
    <div class="s-rq">
        <h3>人气品牌</h3>
        <ul>
            <li><span class="bgred">1</span><a href="http://www.jiajuks.com/company/196/index.aspx">全友家私</a><s class="s1"></s></li>
            <li><span class="bgred">2</span><a href="http://www.jiajuks.com/company/84/index.aspx">大普</a><s class="s2"></s></li>
            <li><span class="bgred">3</span><a href="http://www.jiajuks.com/company/84/index.aspx">楷模</a><s class="s3"></s></li>
            <li><span>4</span><a href="http://www.jiajuks.com/company/201/index.aspx">KBH</a><s class="s4"></s></li>
            <li><span>5</span><a href="http://www.jiajuks.com/company/197/index.aspx">爱凡</a><s class="s5"></s></li>
            <li><span>6</span><a href="http://www.jiajuks.com/company/85/index.aspx">锐驰</a><s class="s6"></s></li>
            <li><span>7</span><a href="http://www.jiajuks.com/company/198/index.aspx">玉庭</a><s class="s7"></s></li>
            <li><span>8</span><a href="http://www.jiajuks.com/company/210/index.aspx">北欧E家</a><s class="s8"></s></li>
            <li><span>9</span><a href="http://www.jiajuks.com/company/195/index.aspx">法朗仕</a><s class="s9"></s></li>
            <li class="last"><span>10</span><a href="http://www.jiajuks.com/company/136/index.aspx ">雅梦莎</a><s class="s10"></s></li>
        </ul>
   </div>
</div>
<div class="w">
    	<div class="w-t">
        	<span class="s1"><a href="http://www.jiajuks.com//company-brand/list.aspx" target="_blank">更多<u></u></a></span>
        	<strong>卧室系列</strong>
            <span class="s2">
            	<b>热卖品牌推荐：</b>
                <a href="http://www.jiajuks.com/company/84/index.aspx" target="_blank">楷模</a>
                <a href="http://www.jiajuks.com/company/84/index.aspx" target="_blank">大普</a>
                <a href="http://www.jiajuks.com/company/198/index.aspx" target="_blank">玉庭</a>
                <a href="http://www.jiajuks.com/company/196/index.aspx" target="_blank">全友</a>
            </span>
        </div>
        <!---w-t-end-->
        <div class="w-c fix">
        	<div class="w-c-l l">
            	<div class="">
                    <a href="/product/list---------1--7-8.aspx" target="_blank">床 </a>
                    <a href="/product/list---------1--7-13.aspx" target="_blank">床头柜</a>
                    <a href="/product/list---------1--7-14.aspx" target="_blank">衣柜 </a>
                    <a href="/product/list---------1--7-15.aspx" target="_blank">斗柜 </a>
                    <a href="/product/list---------1--7-16.aspx" target="_blank">梳妆台/镜</a>
                    <a href="/product/list---------1--7-17.aspx" target="_blank">梳妆凳</a>
                    <a href="/product/list---------1--7-18.aspx" target="_blank">床尾凳</a>
                    <a href="/product/list---------1--7-19.aspx" target="_blank">衣架</a>
                    <a href="/product/list---------1--7-20.aspx" target="_blank">穿衣镜</a>
                    <a href="/product/list---------1--7-21.aspx" target="_blank">床垫</a>
                    <a href="/product/list---------1--7-22.aspx" target="_blank">床屏</a>
                    <a href="/product/list---------1--7-23.aspx" target="_blank">床头板</a>
                    <a href="/product/list---------1--7-24.aspx" target="_blank">卧室其他</a>
                </div>
            </div>
            <!---w-c-l-end-->
            <div class="w-c-c l">
            	<ul>
                	<li><a href="http://www.jiajuks.com/product/18009/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload/show/home/yuting.jpg"/></a></li>
                </ul>
            </div>
            <!---w-c-c-end-->
            <div class="w-c-r l">
            	<h3><b>推荐</b>商品</h3>
                <div>
                	<span>1</span><a href="http://www.jiajuks.com/product/15071/info.aspx" target="_blank">锐驰现代床（C0310019）金属</a>
                    <p><a href="http://www.jiajuks.com/product/15071/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/15071//20110301113355.jpeg"/></a><b>&yen;15730.00</b></p>
                </div>
                <div>
                	<span>2</span><a href="http://www.jiajuks.com/product/14564/info.aspx" target="_blank">楷模现代梳妆台/镜B02SZT爱丽丝</a>
                    <p><a href="http://www.jiajuks.com/product/14564/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/14564/20130530134950493637.jpg"/></a><b>&yen;5500.00</b></p>
                </div>
                <div>
                	<span>3</span><a href="http://www.jiajuks.com/product/17161/info.aspx" target="_blank">雅梦莎 现代 床（AMSA-J-109）</a>
                    <p><a href="http://www.jiajuks.com/product/17161/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/17161//20120417202923.jpg"/></a><b>&yen;6040.00</b></p>
                </div>
                <div>
                	<span>4</span><a href="http://www.jiajuks.com/product/16870/info.aspx" target="_blank">法朗仕法式衣柜（FR014）</a>
                    <p><a href="http://www.jiajuks.com/product/16870/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/16870//20120504174755.jpg"/></a><b>&yen;23000.00</b></p>
                </div>
                <div>
                	<span>5</span><a href="http://www.jiajuks.com/product/21177/info.aspx" target="_blank">北欧E家简欧斗柜（P-906六斗柜）</a>
                    <p><a href="http://www.jiajuks.com/product/21177/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/21177/20130530140147238148.jpg"/></a><b>&yen;13000.00</b></p>
                </div>
                <div>
                	<span>6</span><a href="http://www.jiajuks.com/product/14586/info.aspx" target="_blank">楷模现代床（B10AMC奥米）</a>
                    <p><a href="http://www.jiajuks.com/product/14586/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/14586/20130530135313163488.jpg"/></a><b>&yen;11000.00</b></p>
                </div>
                <div>
                	<span>7</span><a href="http://www.jiajuks.com/product/16055/info.aspx" target="_blank">全友家私现代床（83905-1LCC）</a>
                    <p><a href="http://www.jiajuks.com/product/16055/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/16055//20110921114931.jpeg"/></a><b>&yen;2665.00</b></p>
                </div>
               
            </div>
            <!---w-c-r-end-->
        </div>
        <!---w-c-end-->
        <div class="w-f">
        	<ol class="fix">
            	<li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/17314/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/17314//20120417201002.jpg"/></a>
                        <h3>雅梦莎现代床（AMSA8065）板式</h3>
                        <p>市场参考价：&yen;14435.00<br/>售价：&yen;<em>5774.00</em></p>
                        <span class="dn">特价：&yen;<em>6200.00</em></span>
                        <img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/tj.png"/ class="tj dn">
                    </div>
                </li>
                <li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/21309/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/21309//20130530100926861908.jpg"/></a>
                        <h3>北欧E家 简欧 五门衣柜</h3>
                        <p>市场参考价：&yen;40500.00<br/>售价：&yen;<em>40500.00</em></p>
                        <span class="dn">特价：&yen;<em>6200.00</em></span>
                    </div>
                </li>
                <li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/15035/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/15035//20110402151614.jpeg"/></a>
                        <h3>大普 现代 床（DB12CA）</h3>
                        <p>市场参考价：&yen;13200.00<br/>售价：&yen;<em>13200.00</em></p>
                        <span class="dn">特价：&yen;<em>6200.00</em></span>
                    </div>
                </li>
                <li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/17632/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/17632//20120427200849.jpg"/></a>
                        <h3>法朗仕法式斗柜（FR05）</h3>
                        <p>市场参考价：&yen;8250.00<br/>售价：&yen;<em>8250.00</em></p>
                        <span class="dn">特价：&yen;<em>6200.00</em></span>
                    </div>
                </li>
                <li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/15079/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/15079//20130530113559635049.jpg"/></a>
                        <h3>大普现代梳妆台/镜</h3>
                        <p>市场参考价：&yen;5600.00<br/>售价：&yen;<em>5600.00</em></p>
                        <span class="dn">特价：&yen;<em>6200.00</em></span>
                        <img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/tj.png"/ class="tj dn">
                    </div>
                </li>
            </ol>
        </div>
        <!---w-f-end-->
     </div>
<!---w-end-->
<!---卧室-end-->
<div class="w">
    	<div class="w-t">
        	<span class="s1"><a href="http://www.jiajuks.com//company-brand/list.aspx" target="_blank">更多<u></u></a></span>
        	<strong>餐厅系列</strong>
            <span class="s2">
            	<b>热卖品牌推荐：</b>
                <a href="http://www.jiajuks.com/company/84/index.aspx" target="_blank">楷模</a>
                <a href="http://www.jiajuks.com/company/84/index.aspx" target="_blank">大普</a>
                <a href="http://www.jiajuks.com/company/198/index.aspx" target="_blank">玉庭</a>
                <a href="http://www.jiajuks.com/company/196/index.aspx" target="_blank">全友</a>
            </span>
        </div>
        <!---w-t-end-->
        <div class="w-c fix">
        	<div class="w-c-l w-2 l">
            	<div class="">
                    <a href="/product/list---------1--10-40.aspx" target="_blank">餐桌 </a>  
                    <a href="/product/list---------1--10-41.aspx" target="_blank">餐椅 </a>  
                    <a href="/product/list---------1--10-42.aspx" target="_blank">餐边柜/镜 </a>  
                    <a href="/product/list---------1--10-43.aspx" target="_blank">橱柜 </a>  
                    <a href="/product/list---------1--10-44.aspx" target="_blank">吧台 </a>  
                    <a href="/product/list---------1--10-45.aspx" target="_blank">吧椅 </a>  
                    <a href="/product/list---------1--10-46.aspx" target="_blank">餐车 </a>  
                    <a href="/product/list---------1--10-47.aspx" target="_blank">餐厅其他</a> 
                </div>
            </div>
            <!---w-c-l-end-->
            <div class="w-c-c l">
            	<ul>
                	<li><a href="http://www.jiajuks.com/product/14184/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload/show/home/teaote.jpg"/></a></li>
                </ul>
            </div>
            <!---w-c-c-end-->
            <div class="w-c-r l">
            	<h3><b>推荐</b>商品</h3>
                <div>
                	<span>1</span><a href="http://www.jiajuks.com/product/21101/info.aspx" target="_blank">北欧E家简欧（S-5吧台）</a>
                    <p><a href="http://www.jiajuks.com/product/21101/info.aspx" target="_blank">
                    <img src="http://www.jiajuks.com/upload//product/thumb/21101/20130530140306375832.jpg"/></a>
                    <b>&yen;7500.00</b></p>
                </div>
                <div>
                	<span>2</span><a href="http://www.jiajuks.com/product/16403/info.aspx" target="_blank">玉庭 现代 餐桌（12C810）</a>
                    <p><a href="http://www.jiajuks.com/product/16403/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/16403//20110905151049.jpeg"/></a><b>&yen;3975.00</b></p>
                </div>
                <div>
                	<span>3</span><a href="http://www.jiajuks.com/product/15074/info.aspx" target="_blank">大普现代吧椅（DC10BY）</a>
                    <p><a href="http://www.jiajuks.com/product/15074/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/15074/20130530115524407214.jpg"/></a><b>&yen;4500.00</b></p>
                </div>
                <div>
                	<span>4</span><a href="http://www.jiajuks.com/product/16847/info.aspx" target="_blank">法朗仕法式餐桌（FC054）</a>
                    <p><a href="http://www.jiajuks.com/product/16847/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/16847//20120427192927.jpg"/></a><b>&yen;14000.00</b></p>
                </div>
                <div>
                	<span>5</span><a href="http://www.jiajuks.com/product/14869/info.aspx" target="_blank">锐驰 现代 餐椅（C0210042）</a>
                    <p><a href="http://www.jiajuks.com/product/14869/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/14869//20110706180643.jpeg"/></a><b>&yen;1780.00</b></p>
                </div>
                <div>
                	<span>6</span><a href="http://www.jiajuks.com/product/18351/info.aspx" target="_blank">全友家私田园餐边柜（87973CBG）</a>
                    <p><a href="http://www.jiajuks.com/product/18351/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/18351//20110921102145.jpeg"/></a><b>&yen;5376.00</b></p>
                </div>
                <div>
                	<span>7</span><a href="http://www.jiajuks.com/product/17695/info.aspx" target="_blank">斯曼克田园餐车（C510）</a>
                    <p><a href="http://www.jiajuks.com/product/17695/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/17695//20110811140907.jpeg"/></a><b>&yen;2380.00</b></p>
                </div>
               
            </div>
            <!---w-c-r-end-->
        </div>
        <!---w-c-end-->
        <div class="w-f">
        	<ol class="fix">
            	<li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/14778/info.aspx" target="_blank">
                        <img src="http://www.jiajuks.com/upload//product/thumb/14778/20130530141014787069.jpg"/></a>
                        <h3>楷模现代餐桌（D03AFCZ）</h3>
                        <p>市场参考价：&yen;7600.00<br/>售价：&yen;<em>7600.00</em></p>
                        <span class="dn">特价：&yen;<em>6200.00</em></span>
                        <img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/tj.png"/ class="tj dn">
                    </div>
                </li>
                <li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/16865/info.aspx" target="_blank">
                        <img src="http://www.jiajuks.com/upload//product/thumb/16865//20120427210003.jpg"/></a>
                        <h3>法朗仕法式餐椅（FR071）</h3>
                        <p>市场参考价：&yen;4100.00<br/>售价：&yen;<em>4100.00</em></p>
                        <span class="dn">特价：&yen;<em>6200.00</em></span>
                    </div>
                </li>
                <li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/17698/info.aspx" target="_blank">
                        <img src="http://www.jiajuks.com/upload//product/thumb/17698//20110811151853.jpeg"/></a>
                        <h3>斯曼克田园餐桌（C501）</h3>
                        <p>市场参考价：&yen;4080.00<br/>售价：&yen;<em>4080.00</em></p>
                        <span class="dn">特价：&yen;<em>6200.00</em></span>
                    </div>
                </li>
                <li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/15070/info.aspx" target="_blank">
                        <img src="http://www.jiajuks.com/upload//product/thumb/15070//20110616105808.jpeg"/></a>
                        <h3>锐驰 现代 餐桌（C053350）</h3>
                        <p>市场参考价：&yen;5950.00<br/>售价：&yen;<em>5950.00</em></p>
                        <span class="dn">特价：&yen;<em>6200.00</em></span>
                    </div>
                </li>
                <li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/14619/info.aspx" target="_blank">
                        <img src="http://www.jiajuks.com/upload//product/thumb/14619//20130530114416437972.jpg"/></a>
                        <h3>大普现代餐桌（DT16YCZ）</h3>
                        <p>市场参考价：&yen;7300.00<br/>售价：&yen;<em>7300.00</em></p>
                        <span class="dn">特价：&yen;<em>6200.00</em></span>
                        <img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/tj.png"/ class="tj dn">
                    </div>
                </li>
            </ol>
        </div>
        <!---w-f-end-->
     </div>
<!--餐厅-end-->
<div class="w">
    	<div class="w-t">
        	<span class="s1"><a href="http://www.jiajuks.com//company-brand/list.aspx" target="_blank">更多<u></u></a></span>
        	<strong>客厅系列</strong>
            <span class="s2">
            	<b>热卖品牌推荐：</b>
                <a href="http://www.jiajuks.com/company/84/index.aspx" target="_blank">楷模</a>
                <a href="http://www.jiajuks.com/company/84/index.aspx" target="_blank">大普</a>
                <a href="http://www.jiajuks.com/company/85/index.aspx" target="_blank">锐驰</a>
                <a href="http://www.jiajuks.com/company/195/index.aspx" target="_blank">法朗仕</a>
            </span>
        </div>
        <!---w-t-end-->
        <div class="w-c fix">
        	<div class="w-c-l w-3 l">
            	<div class="">
                    <a href="/product/list---------1--9-25.aspx" target="_blank">沙发 </a>
                    <a href="/product/list---------1--9-26.aspx" target="_blank">茶几 </a>
                    <a href="/product/list---------1--9-27.aspx" target="_blank">角几 </a>
                    <a href="/product/list---------1--9-28.aspx" target="_blank">电视柜 </a>
                    <a href="/product/list---------1--9-29.aspx" target="_blank">展示柜 </a>
                    <a href="/product/list---------1--9-30.aspx" target="_blank">酒柜 </a>
                    <a href="/product/list---------1--9-31.aspx" target="_blank">休闲椅 </a>
                    <a href="/product/list---------1--9-32.aspx" target="_blank">脚踏 </a>
                    <a href="/product/list---------1--9-33.aspx" target="_blank">贵妃椅 </a>
                    <a href="/product/list---------1--9-34.aspx" target="_blank">玄关/镜 </a>
                    <a href="/product/list---------1--9-35.aspx" target="_blank">鞋柜 </a> 
                    <a href="/product/list---------1--9-36.aspx" target="_blank">话几 </a> 
                    <a href="/product/list---------1--9-37.aspx" target="_blank">花架 </a>  
                    <a href="/product/list---------1--9-38.aspx" target="_blank">屏风 </a>  

                </div>
            </div>
            <!---w-c-l-end-->
            <div class="w-c-c l">
            	<ul>
                	<li><a href="http://www.jiajuks.com/product/17669/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload/show/home/falangshi.jpg"/></a></li>
                </ul>
            </div>
            <!---w-c-c-end-->
            <div class="w-c-r l">
            	<h3><b>推荐</b>商品</h3>
                <div>
                	<span>1</span><a href="http://www.jiajuks.com/product/18153/info.aspx" target="_blank">全友家私简欧电视柜</a>
                    <p><a href="http://www.jiajuks.com/product/18153/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/18153//20111018143855.jpeg"/></a><b>&yen;5915.00</b></p>
                </div>
                <div>
                	<span>2</span><a href="http://www.jiajuks.com/product/14839/info.aspx" target="_blank">锐驰 现代 沙发（C013060Y）</a>
                    <p><a href="http://www.jiajuks.com/product/14839/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/14839//20110628173700.jpeg"/></a><b>&yen;12100.00</b></p>
                </div>
                <div>
                	<span>3</span><a href="http://www.jiajuks.com/product/14789/info.aspx" target="_blank">楷模 现代 沙发（C01LRSF2）</a>
                    <p><a href="http://www.jiajuks.com/product/14789/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/14789//20110224102508.jpeg"/></a><b>&yen;14200.00</b></p>
                </div>
                <div>
                	<span>4</span><a href="http://www.jiajuks.com/product/14583/info.aspx" target="_blank">楷模 现代 酒柜（KM3）</a>
                    <p><a href="http://www.jiajuks.com/product/14583/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/14583/20130530135635404919.jpg"/></a><b>&yen;5120.00</b></p>
                </div>
                <div>
                	<span>5</span><a href="http://www.jiajuks.com/product/21276/info.aspx" target="_blank">北欧E家 简欧抽拉茶几</a>
                    <p><a href="http://www.jiajuks.com/product/21276/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/21276/20130530140437898276.jpg"/></a><b>&yen;6800.00</b></p>
                </div>
                <div>
                	<span>6</span><a href="http://www.jiajuks.com/product/17636/info.aspx" target="_blank">百谷布艺沙发组合</a>
                    <p><a href="http://www.jiajuks.com/product/17636/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/17636//20120427202422.jpg"/></a><b>&yen;16400.00</b></p>
                </div>
                <div>
                	<span>7</span><a href="http://www.jiajuks.com/product/17261/info.aspx" target="_blank">斯曼克 田园 电视柜（D401）</a>
                    <p><a href="http://www.jiajuks.com/product/17261/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/17261//20110811140546.jpeg"/></a><b>&yen;5260.00</b></p>
                </div>
               
            </div>
            <!---w-c-r-end-->
        </div>
        <!---w-c-end-->
        <div class="w-f">
        	<ol class="fix">
            	<li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/21290/info.aspx" target="_blank">
                        <img src="http://www.jiajuks.com/upload//product/thumb/21290//20130530101604779771.jpg"/></a>
                        <h3>北欧E家 简欧 茶几（BLT-5茶几）</h3>
                        <p>市场参考价：&yen;11400.00<br/>售价：&yen;<em>11400.00</em></p>
                        <span class="dn">特价：&yen;<em>11400.00</em></span>
                        <img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/tj.png"/ class="tj dn">
                    </div>
                </li>
                <li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/15059/info.aspx" target="_blank">
                        <img src="http://www.jiajuks.com/upload//product/thumb/15059//20130530114647631526.jpg"/></a>
                        <h3>大普 现代 沙发（DA11SF3迪奥）</h3>
                        <p>市场参考价：&yen;21600.00<br/>售价：&yen;<em>21600.00</em></p>
                        <span class="dn">特价：&yen;<em>21600.00</em></span>
                    </div>
                </li>
                <li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/14786/info.aspx" target="_blank">
                        <img src="http://www.jiajuks.com/upload//product/thumb/14786/20130530120236942791.jpg"/></a>
                        <h3>楷模现代沙发（C17BDLRSF）</h3>
                        <p>市场参考价：&yen;10800.00<br/>售价：&yen;<em>10800.00</em></p>
                        <span class="dn">特价：&yen;<em>10800.00</em></span>
                    </div>
                </li>
                <li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/14850/info.aspx" target="_blank">
                        <img src="http://www.jiajuks.com/upload//product/thumb/14850//20110628175840.jpeg"/></a>
                        <h3>锐驰 现代 沙发（C0104002）</h3>
                        <p>市场参考价：&yen;15614.00<br/>售价：&yen;<em>15614.00</em></p>
                        <span class="dn">特价：&yen;<em>15614.00</em></span>
                    </div>
                </li>
                <li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/16862/info.aspx" target="_blank">
                        <img src="http://www.jiajuks.com/upload//product/thumb/16862//20120427203519.jpg"/></a>
                        <h3>法朗仕 法式 茶几（FR026）</h3>
                        <p>市场参考价：&yen;7400.00<br/>售价：&yen;<em>7400.00</em></p>
                        <span class="dn">特价：&yen;<em>7400.00</em></span>
                        <img src="<%=TREC.ECommerce.ECommon.WebResourceUrl %>/web/images/tj.png"/ class="tj dn">
                    </div>
                </li>
            </ol>
        </div>
        <!---w-f-end-->
     </div>
<!--客厅-end-->
<div class="w">
    	<div class="w-t">
        	<span class="s1"><a href="http://www.jiajuks.com//company-brand/list.aspx" target="_blank">更多<u></u></a></span>
        	<strong>书房系列</strong>
            <span class="s2">
            	<b>热卖品牌推荐：</b>
                <a href="http://www.jiajuks.com/company/84/index.aspx" target="_blank">楷模</a>
                <a href="http://www.jiajuks.com/company/84/index.aspx" target="_blank">大普</a>
                <a href="http://www.jiajuks.com/company/198/index.aspx" target="_blank">玉庭</a>
                <a href="http://www.jiajuks.com/company/196/index.aspx" target="_blank">全友</a>
            </span>
        </div>
        <!---w-t-end-->
        <div class="w-c fix">
        	<div class="w-c-l w-4 l">
            	<div class="">
                     <a href="/product/list---------1--11-48.aspx" target="_blank">书桌 </a>  
                     <a href="/product/list---------1--11-49.aspx" target="_blank">书椅 </a>  
                     <a href="/product/list---------1--11-50.aspx" target="_blank">书柜 </a>  
                     <a href="/product/list---------1--11-51.aspx" target="_blank">书架 </a>  
                     <a href="/product/list---------1--11-52.aspx" target="_blank">书报架 </a>  
                     <a href="/product/list---------1--11-53.aspx" target="_blank">电脑桌 </a>  
                     <a href="/product/list---------1--11-54.aspx" target="_blank">书房其他 </a>  
                     <a href="/product/list---------1--11-63.aspx" target="_blank">办公椅 </a> 
                </div>
            </div>
            <!---w-c-l-end-->
            <div class="w-c-c l">
            	<ul>
                	<li><a href="http://www.jiajuks.com/product/17145/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload/show/home/simanke.jpg"/></a></li>
                </ul>
            </div>
            <!---w-c-c-end-->
            <div class="w-c-r l">
            	<h3><b>推荐</b>商品</h3>
                <div>
                	<span>1</span><a href="http://www.jiajuks.com/product/14570/info.aspx" target="_blank">楷模 现代 书桌（AMXZTXG奥米）</a>
                    <p><a href="http://www.jiajuks.com/product/14570/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/14570/20130530135903035248.jpg"/></a><b>&yen;4500.00</b></p>
                </div>
                <div>
                	<span>2</span><a href="http://www.jiajuks.com/product/14633/info.aspx" target="_blank">大普 现代 书柜（DG13）</a>
                    <p><a href="http://www.jiajuks.com/product/14633/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/14633//20130530115254463598.jpg"/></a><b>&yen;14900.00</b></p>
                </div>
                <div>
                	<span>3</span><a href="http://www.jiajuks.com/product/16435/info.aspx" target="_blank">玉庭 现代 书桌（5Z139-1）</a>
                    <p><a href="http://www.jiajuks.com/product/16435/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/16435//20110905161725.jpeg"/></a><b>&yen;2751.00</b></p>
                </div>
                <div>
                	<span>4</span><a href="http://www.jiajuks.com/product/21250/info.aspx" target="_blank">北欧E家 简欧 书桌（G-971书桌）</a>
                    <p><a href="http://www.jiajuks.com/product/21250/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/21250/20130530140551436628.jpg"/></a><b>&yen;9200.00</b></p>
                </div>
                <div>
                	<span>5</span><a href="http://www.jiajuks.com/product/14370/info.aspx" target="_blank">锐驰 现代 书桌（C055358）</a>
                    <p><a href="http://www.jiajuks.com/product/14370/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/14370//20110620094838.jpeg"/></a><b>&yen;6600.00</b></p>
                </div>
                <div>
                	<span>6</span><a href="http://www.jiajuks.com/product/18151/info.aspx" target="_blank">全友家私 简欧 书桌（85521SZ）</a>
                    <p><a href="http://www.jiajuks.com/product/18151/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/18151//20111018144055.jpeg"/></a><b>&yen;3892.00</b></p>
                </div>
                <div>
                	<span>7</span><a href="http://www.jiajuks.com/product/14373/info.aspx" target="_blank">锐驰 现代 书柜（C0416017）</a>
                    <p><a href="http://www.jiajuks.com/product/14373/info.aspx" target="_blank"><img src="http://www.jiajuks.com/upload//product/thumb/14373//20110721093507.jpeg"/></a><b>&yen;6560.00</b></p>
                </div>
               
            </div>
            <!---w-c-r-end-->
        </div>
        <!---w-c-end-->
        <div class="w-f">
        	<ol class="fix">
            	<li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/14608/info.aspx" target="_blank">
                        <img src="http://www.jiajuks.com/upload//product/thumb/14608//20130530114905013104.jpg"/></a>
                        <h3>大普 现代 书桌（DY12ST）</h3>
                        <p>市场参考价：&yen;7200.00<br/>售价：&yen;<em>7200.00</em></p>
                        
                    </div>
                </li>
                <li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/16425/info.aspx" target="_blank">
                        <img src="http://www.jiajuks.com/upload//product/thumb/16425//20110905142312.jpeg"/></a>
                        <h3>玉庭 现代 书桌（13Z980B）</h3>
                        <p>市场参考价：&yen;4600.00<br/>售价：&yen;<em>4600.00</em></p>
                        <span class="dn">特价：&yen;<em>6200.00</em></span>
                    </div>
                </li>
                <li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/16070/info.aspx" target="_blank">
                        <img src="http://www.jiajuks.com/upload//product/thumb/16070//20110921103936.jpeg"/></a>
                        <h3>全友家私 田园 电脑桌</h3>
                        <p>市场参考价：&yen;5124.00<br/>售价：&yen;<em>2613.00</em></p>
                        <span class="dn">特价：&yen;<em>6200.00</em></span>
                    </div>
                </li>
                <li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/21249/info.aspx" target="_blank">
                        <img src="http://www.jiajuks.com/upload//product/thumb/21249//20130530102517103764.jpg"/></a>
                        <h3>北欧E家 简欧 书柜（H-981书柜）</h3>
                        <p>市场参考价：&yen;15500.00<br/>售价：&yen;<em>15500.00</em></p>
                        <span class="dn">特价：&yen;<em>6200.00</em></span>
                    </div>
                </li>
                <li>
                	<div class="list">
                    	<a href="http://www.jiajuks.com/product/17280/info.aspx" target="_blank">
                        <img src="http://www.jiajuks.com/upload//product/thumb/17280//20110922141750.jpeg"/></a>
                        <h3>斯曼克 田园 书柜（E303）</h3>
                        <p>市场参考价：&yen;19400.00<br/>售价：&yen;<em>19400.00</em></p>
                        
                    </div>
                </li>
            </ol>
        </div>
        <!---w-f-end-->
     </div>
     <div class="topNav992 ad1">
	 <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=12"></script></div>
     <div style="width:970px; border:#ccc solid 1px; margin:0 auto; padding:10px 10px 20px 10px;">友情链接：
                        <%
                            foreach (EnLinks item in _link)
                          { 
                                %>
                             <a href="<%=item.Link %>" title="福家网" target="_blank"><%=item.Title %></a>|
                        <%} %>
						<a href="##" title="更多友情链接" target="_blank">更多>></a> 
	</div>
<!--书房-end-->

<uc3:_foot ID="_foot1" runat="server" />

</body>
</html>