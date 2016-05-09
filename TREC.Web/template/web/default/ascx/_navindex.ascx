<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_nav.ascx.cs" Inherits="TREC.Web.aspx.ascx._nav" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register Src="_indexbrandletter.ascx" TagName="_brandletter" TagPrefix="uc5" %>
<div class="topNav992 logo">
    <div class="logo1">
        <a href="<%=TREC.ECommerce.ECommon.WebUrl %>">
            <img src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/index_12.jpg" alt="家具快搜官网" /><img
                src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/index_13.jpg" alt="家具品牌" /></a></div>
             
    <div class="logo-s r">
        <div class="logo-s-t" id="searchTypeList">
            <a id="T_product" title="product" class="Searcha">
                搜产品</a> 
            <a id="T_brand" title="brand" class="">
                搜品牌</a>
            <a id="T_market" title="market" class="">
                    搜卖场</a>
           </div>
        <div class="logo-s-c fix">
            <input name="searchKey" type="text" class="" id="searchKey" placeholder="楷模" />
            <a href="javascript:;" class="on" id="topSearchBtn"></a>
            <a href="http://www.jiajuks.com//product/list.aspx">高级搜索</a>
        </div>
        <div class="indexflye">
            <span>目前共有</span>
            <font><a href="<%=TREC.ECommerce.ECommon.WebUrl %>/company-brand/list.aspx" style="color:#C21F30"><%=_htb["bcount"]%></a></font><span>个品牌</span>
            <!--<font><a href="<%=TREC.ECommerce.ECommon.WebUrl %>/market/list.aspx" style="color:#C21F30"><%=_htb["mcount"]%></a></font><span>座家具卖场</span>-->
            <font><a href="<%=TREC.ECommerce.ECommon.WebUrl %>/product/list.aspx" style="color:#C21F30"><%=_htb["pcount"]%></a></font><span>件产品等待您的挑选。</span>
        </div>
        <script type="text/javascript">
            $(function () {
                var url = document.URL.toLowerCase();
                if ("<%=ECommon.QuerySearchKey %>" != "") {
                    $("#searchKey").val("<%=ECommon.QuerySearchKey %>".replace(/\abc111/g, "-").replace(/\cba222/g, "_"));
                }
                $("#searchKey").oms_autocomplate({ url: "/ajax/search.ashx", inputWidth: 339, inputHeight: 32, paramTypeSelector: "#searchTypeList>a.Searcha" });
                $('.kslkcon>div,.ksbrandcon>div').html('正在加载数据中...');
                GetMarket('A,B,C,D', null); //初始化卖场
                GetBrand('A,B,C', null); //初始化品牌
            })

            function GetMarket(myletter, obj) {
                var myclass = '';
                if (obj != null) {
                    myclass = $(obj).attr('class');
                    if (myclass == undefined) {
                        myclass = '';
                    }
                }
                if (myclass == '') {
                    if (obj != null) {
                        $('#marketmenu .cus').removeClass('cus');
                        $(obj).addClass('cus');
                    }

                    $.ajax({
                        url: '/ajax/ajaxproduct.ashx',
                        data: 'type=getmarketbyletter&v=' + myletter.toString() + '&rnd=' + Math.random(),
                        dataType: 'text',
                        success: function (data) {
                            if (data != null) {
                                if (data == '') {
                                    $('.kslkcon>div').html('抱歉，暂无卖场！');
                                } else {
                                    $('.kslkcon>div').html(data.toString());
                                }
                            }
                        }
                    });
                }
            }

            function GetBrand(myletter, obj) {
                var myclass = '';
                if (obj != null) {
                    myclass = $(obj).attr('class');
                    if (myclass == undefined) {
                        myclass = '';
                    }
                }
                if (myclass == '') {
                    if (obj != null) {
                        $('#brandmenu .cus').removeClass('cus');
                        $(obj).addClass('cus');
                    }

                    $.ajax({
                        url: '/ajax/ajaxproduct.ashx',
                        data: 'type=getbrandbyletter&v=' + myletter.toString() + '&rnd=' + Math.random(),
                        dataType: 'text',
                        success: function (data) {
                            if (data != null) {
                                if (data == '') {
                                    $('.ksbrandcon>div').html('抱歉，暂无品牌！');
                                } else {
                                    $('.ksbrandcon>div').html(data.toString());
                                }
                            }
                        }
                    });                    
                }
            }

            $("#topSearchBtn").click(function () {
                window.top.location = "<%=ECommon.WebUrl %>" + "/search.aspx?type=" + $("#searchTypeList").find("a.Searcha").attr("title") + "&key=" + encodeURIComponent($("#searchKey").val().replace(/\-/g, "abc111"));
            });
        </script>
    </div>
</div>
   	<div class="topNav992 nav pr">
    	<div class="pa nav-m">
            <div class="nav-t"><a href="http://www.jiajuks.com//product/list.aspx" target="_blank">全部产品分类</a></div>
            <div class="nav-c">
            	<ul>
                <li><p><u class="u1"></u><a href="/market/list.aspx"><b>家具卖场</b></a>
                	  <span style=" color:#E1BE6A;">(按字母索引)</span>
                    </p>
                    <div class="menu fix">
                    	<div class="menu-bd l">
                            <dl>
                                <dd id="marketmenu">
                                    <a class="cus" onmouseover="GetMarket('A,B,C,D',this);">ABCD</a>
                                    <a onmouseover="GetMarket('E,F,G,H',this);">EFGH</a>
                                    <a onmouseover="GetMarket('I,J,K,L',this);">IJKL</a>
                                    <a onmouseover="GetMarket('M,N,O,P',this);">MNOP</a>
                                    <a onmouseover="GetMarket('Q,R,S,T,U',this);">QRSTU</a>
                                    <a onmouseover="GetMarket('V,W,X,Y,Z',this);">VWXYZ</a>
                                    <div class="clear"></div>
                                </dd>
                                <dd class="kslkcon"><div class="myletter"></div></dd>
                            </dl>                          
                        </div>
                        <div class="menu-img r">
                          <a href="http://www.jiajuks.com/market/14/index.aspx"><img style="width:120px; height:45px;" src="http://www.jiajuks.com/upload/market/logo/14/20130608175750105503.jpg"/></a>
                            <a href="http://www.jiajuks.com/market/list.aspx"><img src="http://www.jiajuks.com/upload/market/logo/8/20130608144234216136.jpg"/></a>
                            <a href="http://www.jiajuks.com/market/list.aspx"><img src="http://www.jiajuks.com/upload/market/logo/41/20130608174628497316.jpg"/></a>
                            <a href="http://www.jiajuks.com/market/list.aspx"><img src="http://www.jiajuks.com/upload/market/logo/43/20130608145015418676.jpg"/></a>
                            <a href="http://www.jiajuks.com/market/list.aspx"><img src="http://www.jiajuks.com/upload/market/logo/45/20130608145353002055.jpg"/></a>
                            <a href="http://www.jiajuks.com/market/list.aspx"><img src="http://www.jiajuks.com/upload/market/logo/46/20130608150014577812.jpg"/></a>
                            <a href="http://www.jiajuks.com/market/list.aspx"><img src="http://www.jiajuks.com/upload/market/logo/52/20130608150641921687.jpg"/></a>
                            <a href="http://www.jiajuks.com/market/list.aspx"><img src="http://www.jiajuks.com/upload/market/logo/56/20130608174958084551.jpg"/></a>
                        </div>
                    </div>
                </li>
                <li><p><u class="u1"></u><a href="/company-brand/list.aspx"><b>家具品牌</b></a>
                	   <a href="/company/198/index.aspx">玉庭</a>
                       <a href="/company/195/index.aspx">法朗仕</a>
                       <a href="/company/84/index.aspx">大普</a>
                    </p>
                    <div class="menu fix">
                    	<div class="menu-bd l">
                            <dl>
                                <dd id="brandmenu">
                                    <a class="cus" onmouseover="GetBrand('A,B,C',this);">ABC</a>
                                    <a onmouseover="GetBrand('D,E,F,G',this);">DEFG</a>
                                    <a onmouseover="GetBrand('H,I,J,K',this);">HIJK</a>
                                    <a onmouseover="GetBrand('L,M,N,O',this);">LMNO</a>
                                    <a onmouseover="GetBrand('P,Q,R,S,T',this);">PQRST</a>
                                    <a onmouseover="GetBrand('U,V,W,X,Y,Z',this);">UVWXYZ</a>
                                    <div class="clear"></div>
                                </dd>
                                <dd class="ksbrandcon"><div class="myletter"></div></dd>
                            </dl>                          
                        </div>
                        <div class="menu-img r">
                            <a href="http://www.jiajuks.com/company/136/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/340/20130607172438841210.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/84/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/26/20130607163039796565.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/84/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/27/20130607163926744345.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/84/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/28/20130607163837507808.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/285/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/479/20130607170959064141.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/84/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/454/20130607162434373504.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/197/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/401/20130607170000134017.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/202/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/318/20130607164839988311.jpg"/></a>
                        </div>
                    </div>
                </li>
            	<li><p><u class="u1"></u><a href="/product/list.aspx"><b>卧室系列</b></a>
                	   <a href="/product/list---------1--7-8.aspx">床</a>
                       <a href="/product/list---------1--7-13.aspx">床头柜</a>
                       <a href="/product/list---------1--7-14.aspx">衣柜</a>
                    </p>
                    <div class="menu fix">
                    	<div class="menu-bd l">
                            <dl>
                                <dt><a href="/product/list---------1--7-8.aspx">床</a></dt>
                                <dd>
                                    <a title="四尺床(宽1.2m)" href="/product/list---------1-57-7-8.aspx">四尺床(宽1.2m)</a>
                                    <a title="五尺床(宽1.5m)" href="/product/list---------1-58-7-8.aspx">五尺床(宽1.5m)</a>
                                    <a title="六尺床(宽1.8m)" href="/product/list---------1-106-7-8.aspx">六尺床(宽1.8m)</a>
                                    <a title="加大床" href="/product/list---------1-59-7-8.aspx">加大床</a>
                                    <a title="上下床" href="/product/list---------1-61-7-8.aspx">上下床</a>
                                    <a title="折叠床" href="/product/list---------1-60-7-8.aspx">折叠床</a>
                                </dd>
                            </dl>
                            <dl>
                                <dt><a href="/product/list---------1--7-14.aspx">衣柜</a></dt>
                                <dd>
                                    <a title="单门衣柜" href="/product/list---------1-91-7-14.aspx">单门衣柜</a>
                                    <a title="二门衣柜" href="/product/list---------1-77-7-14.aspx"> 二门衣柜</a>
                                    <a title="三门衣柜" href="/product/list---------1-76-7-14.aspx">三门衣柜</a>
                                    <a title="四门衣柜" href="/product/list---------1-75-7-14.aspx">四门衣柜</a>
                                    <a title="五门衣柜" href="/product/list---------1-92-7-14.aspx">五门衣柜</a>
                                    <a title="六门衣柜" href="/product/list---------1-74-7-14.aspx">六门衣柜</a>
                                    <a title="组合衣柜" href="/product/list---------1-127-7-14.aspx">组合衣柜</a>
                               </dd>
                            </dl>
                            <dl>
                                <dt><a href="/product/list---------1--7-15.aspx">斗柜</a></dt>
                                <dd>
                                    <a title="二斗柜" href="/product/list---------1-120-7-15.aspx">二斗柜</a>
                                    <a title="三斗柜" href="/product/list---------1-85-7-15.aspx">三斗柜</a>
                                    <a title="四斗柜" href="/product/list---------1-86-7-15.aspx">四斗柜</a>
                                    <a title="五斗柜" href="/product/list---------1-87-7-15.aspx">五斗柜</a>
                                    <a title="六斗柜" href="/product/list---------1-88-7-15.aspx">六斗柜</a>
                                    <a title="七斗柜" href="/product/list---------1-89-7-15.aspx">七斗柜</a>
                                </dd>
                            </dl>
                            <dl>
                                <dt><a href="/product/list---------1--7-16.aspx">梳妆</a></dt>
                                <dd>
                                    <a title="梳妆台/镜" href="/product/list---------1-129-7-16.aspx">梳妆台/镜</a>
                                    <a title="梳妆镜" href="/product/list---------1-125-7-16.aspx">梳妆镜</a>
                                    <a title="梳妆台" href="/product/list---------1-124-7-16.aspx">梳妆台</a>
                                </dd>
                            </dl>
                            <dl>
                                <dt><a href="/product/list---------1--7-21.aspx">床垫</a></dt>
                                <dd>
                                    <a title="很软" href="/product/list---------1-113-7-21.aspx">很软</a>
                                    <a title="中软" href="/product/list---------1-112-7-21.aspx">中软</a>
                                    <a title="柔软" href="/product/list---------1-111-7-21.aspx">柔软</a>
                                    <a title="中硬" href="/product/list---------1-110-7-21.aspx">中硬</a>
                                </dd>
                            </dl>
                        </div>
                        <div class="menu-img r">
                            <a href="http://www.jiajuks.com/company/210/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/414/20130608105907455896.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/136/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/340/20130607172438841210.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/121/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/61/20130608140415624904.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/198/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/322/20130607160115855265.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/162/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/365/20130608142529164872.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/275/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/470/20130608140035934460.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/84/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/26/20130607163039796565.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/196/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/400/20130607173842112509.jpg"/></a>
                        </div>
                    </div>
                </li>
                <li><p><u class="u2"></u><a href="http://www.jiajuks.com/product/list.aspx"><b>客厅系列</b></a>
                       <a href="http://www.jiajuks.com/product/list---------1--9-25.aspx">沙发</a>
                       <a href="http://www.jiajuks.com/product/list---------1--9-28.aspx">电视柜</a>
                       <a href="http://www.jiajuks.com/product/list---------1--9-26.aspx">茶几</a>
                     </p>
                     <div class="menu fix">
                    	<div class="menu-bd l">
                            <dl>
                                <dt><a href="/product/list---------1--9-25.aspx">沙发</a></dt>
                                <dd>
                                    <a title="单人沙发" href="/product/list---------1-69-9-25.aspx">单人沙发</a>
                                    <a title="二人沙发" href="/product/list---------1-70-9-25.aspx">二人沙发</a>
                                    <a title="三人沙发" href="/product/list---------1-71-9-25.aspx">三人沙发</a>
                                    <a title="四人沙发" href="/product/list---------1-121-9-25.aspx">四人沙发</a>
                                    <a title="转角沙发" href="/product/list---------1-114-9-25.aspx">转角沙发</a>
                                    <a title="功能沙发" href="/product/list---------1-73-9-25.aspx">功能沙发</a>
                                    <a title="组合沙发" href="/product/list---------1-72-9-25.aspx">组合沙发</a>
                                    <a title="沙发床" href="/product/list---------1-62-9-25.aspx">沙发床</a>
                                </dd>
                            </dl>
                            <dl>
                                <dt><a href="/product/list---------1--9-26.aspx">茶几</a></dt>
                                <dd>
                                    <a title="椭圆茶几" href="/product/list---------1-105-9-26.aspx">椭圆茶几</a>
                                    <a title="长茶几" href="/product/list---------1-94-9-26.aspx">长茶几</a>
                                    <a title="圆茶几" href="/product/list---------1-84-9-26.aspx"> 圆茶几</a>
                                    <a title="方茶几" href="/product/list---------1-83-9-26.aspx">方茶几</a>
                                    <a title="茶几" href="/product/list---------1-16-9-26.aspx">茶几</a>
                                </dd>
                            </dl>
                            <dl>
                                <dt><a href="/product/list---------1--9-27.aspx">角几</a></dt>
                                <dd>
                                    <a title="长角几" href="/product/list---------1-97-9-27.aspx">长角几</a>
                                    <a title="圆角几" href="/product/list---------1-96-9-27.aspx"> 圆角几</a>
                                    <a title="方角几" href="/product/list---------1-95-9-27.aspx">方角几</a>
                                    <a title="角几" href="/product/list---------1-17-9-27.aspx">角几</a>
                                </dd>
                            </dl>
                            <dl>
                                <dt><a href="/product/list---------1--9-30.aspx">酒柜</a></dt>
                                <dd>
                                    <a title="单门酒柜" href="/product/list---------1-115-9-30.aspx"> 单门酒柜</a>
                                    <a title="二门酒柜" href="/product/list---------1-116-9-30.aspx">二门酒柜</a>
                                    <a title="三门酒柜" href="/product/list---------1-117-9-30.aspx">三门酒柜</a>
                                    <a title="四门酒柜" href="/product/list---------1-118-9-30.aspx">四门酒柜</a>
                                </dd>
                            </dl>
                            <dl>
                                <dt><a href="/product/list---------1--9-34.aspx">玄关</a></dt>
                                <dd>
                                    <a title="玄关" href="/product/list---------1-126-9-34.aspx">玄关</a>
                                    <a title="玄关/镜" href="/product/list---------1-22-9-34.aspx">玄关/镜</a>
                                </dd>
                            </dl>
                        </div>
                        <div class="menu-img r">
                            <a href="http://www.jiajuks.com/company/196/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/400/20130607173842112509.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/84/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/26/20130607163039796565.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/85/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/29/20130607174721238574.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/195/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/398/20130608094403236623.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/198/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/322/20130607160115855265.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/102/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/45/20130607175726151527.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/173/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/376/20130608134905541115.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/231/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/436/20130608134241482229.jpg"/></a>
                        </div>
                    </div>
                </li>
                <li><p><u class="u3"></u><a href="http://www.jiajuks.com/product/list.aspx"><b>餐厅系列</b></a>
                	   <a href="http://www.jiajuks.com/product/list---------1--10-40.aspx">餐桌</a>
                       <a href="http://www.jiajuks.com/product/list---------1--10-41.aspx">餐椅</a>
                       <a href="http://www.jiajuks.com/product/list---------1--10-42.aspx">餐边柜</a>
                    </p>
                    <div class="menu fix">
                    	<div class="menu-bd l">
                            <dl>
                                <dt><a href="/product/list---------1--10-40.aspx">餐桌</a></dt>
                                <dd>
                                    <a title="椭圆餐桌" href="/product/list---------1-102-10-40.aspx">椭圆餐桌</a>
                                    <a title="方餐桌" href="/product/list---------1-101-10-40.aspx">方餐桌</a>
                                    <a title="圆餐桌" href="/product/list---------1-100-10-40.aspx">圆餐桌</a>
                                    <a title="长餐桌" href="/product/list---------1-99-10-40.aspx">长餐桌</a>
                                </dd>
                            </dl>
                            <dl>
                                <dt><a href="/product/list---------1--10-41.aspx">餐椅</a></dt>
                                <dd>
                                    <a title="无扶手椅" href="/product/list---------1-68-10-41.aspx">无扶手椅</a>
                                    <a title="扶手椅" href="/product/list---------1-67-10-41.aspx">扶手椅</a>
                                    <a title="餐椅" href="/product/list---------1-27-10-41.aspx">餐椅</a>
                               </dd>
                            </dl>
                            <dl>
                                <dt><a href="/product/list---------1--10-42.aspx">餐边柜</a></dt>
                                <dd>
                                    <a title="餐边柜" href="/product/list---------1-123-10-42.aspx">餐边柜</a>
                                    <a title="餐边柜/镜" href="/product/list---------1-28-10-42.aspx">餐边柜/镜</a>
                                </dd>
                            </dl>
                        </div>
                        <div class="menu-img r">
                            <a href="http://www.jiajuks.com/company/210/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/414/20130608105907455896.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/84/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/26/20130607163039796565.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/199/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/317/20130608133400293966.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/198/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/322/20130607160115855265.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/300/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/496/20130608115735281486.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/77/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/19/20130608115103371717.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/120/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/60/20130608113729786518.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/116/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/56/20130608110953431966.jpg"/></a>
                        </div>
                    </div>
                </li>
                <li><p><u class="u4"></u><a href="http://www.jiajuks.com/product/list.aspx"><b>书房系列</b></a>
                       <a href="http://www.jiajuks.com/product/list---------1--11-48.aspx">书桌</a>
                       <a href="http://www.jiajuks.com/product/list---------1--11-49.aspx">书椅</a>
                       <a href="http://www.jiajuks.com/product/list---------1--11-50.aspx">书柜</a>
                    </p>
                    <div class="menu fix">
                    	<div class="menu-bd l">
                            <dl>
                                <dt><a href="/product/list---------1--11-50.aspx">书柜</a></dt>
                                <dd>
                                    <a title="单门书柜" href="/product/list---------1-98-11-50.aspx">单门书柜</a>
                                    <a title="二门书柜" href="/product/list---------1-81-11-50.aspx">二门书柜</a>
                                    <a title="三门书柜" href="/product/list---------1-80-11-50.aspx">三门书柜</a>
                                    <a title="四门书柜" href="/product/list---------1-79-11-50.aspx">四门书柜</a>
                                    <a title="五门书柜" href="/product/list---------1-93-11-50.aspx">五门书柜</a>
                                    <a title="六门书柜" href="/product/list---------1-78-11-50.aspx">六门书柜</a>
                                    <a title="组合书柜" href="/product/list---------1-82-11-50.aspx">组合书柜</a>
                                </dd>
                            </dl>
                        </div>
                        <div class="menu-img r">
                            <a href="http://www.jiajuks.com/company/195/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/398/20130608094403236623.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/84/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/26/20130607163039796565.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/210/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/414/20130608105907455896.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/198/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/322/20130607160115855265.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/169/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/372/20130608103014994939.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/271/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/466/20130608102345565733.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/204/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/405/20130608101326443832.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/228/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/433/20130608095204333815.jpg"/></a>
                        </div>
                    </div>
                </li>
                <li><p><u class="u5"></u>
                       <a href="http://www.jiajuks.com/product/list.aspx"><b>儿童系列</b></a>
                       <a href="http://www.jiajuks.com/product/list---------1--12-55.aspx">儿童床</a>
                       <a href="http://www.jiajuks.com/product/list---------1--12-56.aspx">儿童桌</a>
              	   </p>
                   <div class="menu fix">
                    	<div class="menu-bd l">
                            <dl>
                                <dt><a href="/product/list---------1--12-55.aspx">儿童床</a></dt>
                                <dd>
                                    <a title="上下床" href="/product/list---------1-61-12-55.aspx">上下床</a>
                                    <a title="四尺床(宽1.2m)" href="/product/list---------1-57-12-55.aspx">四尺床(宽1.2m)</a>
                                    <a title="儿童床" href="/product/list---------1-39-12-55.aspx">儿童床</a>
                                    <a title="婴儿床" href="/product/list---------1-5-12-55.aspx">婴儿床</a>
                                </dd>
                            </dl>
                            <dl>
                                <dt><a href="/product/list---------1--12-58.aspx">儿童衣柜</a></dt>
                                <dd>
                                    <a title="二门衣柜" href="/product/list---------1-77-12-58.aspx">二门衣柜</a>
                                    <a title="三门衣柜" href="/product/list---------1-76-12-58.aspx">三门衣柜</a>
                                    <a title="儿童衣柜" href="/product/list---------1-42-12-58.aspx">儿童衣柜</a>
                                    <a title="衣柜" href="/product/list---------1-6-12-58.aspx">衣柜</a>
                               </dd>
                            </dl>
                        </div>
                        <div class="menu-img r">
                            <a href="http://www.jiajuks.com/company/196/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/400/20130607173842112509.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/159/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/363/20130608092356693629.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/162/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/365/20130608142529164872.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/80/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/21/20130608142313421317.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/162/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/366/20130608142637606838.jpg"/></a>
                            <a href="http://www.jiajuks.com/company/197/index.aspx"><img src="http://www.jiajuks.com/upload/brand/logo/401/20130607170000134017.jpg"/></a>
                        </div>
                    </div>
                </li>
                </ul>
            </div>
       	</div>
        <uc5:_brandletter ID="_brandletter1" runat="server"/>
        <script>
            function showhideabc() {
                $("#abcshowid").val("1");
                showhideALl();
            }

            function hideshowabc() {
                $("#abcshowid").val("0");
                setTimeout(showhideALl, 200);
            }
            function showhideALl() {
                var t = $("#abcshowid").val();
                if (t == "0")
                    $("#m-prlifl1").hide();
                else
                    $("#m-prlifl1").show();
            }
        </script>
        <!---nav-m-end-->
    	<ul class="nav1"> 
            <li><a href="/">首页</a></li>
            <li><a href="<%=TREC.ECommerce.ECommon.WebUrl %>company-brand/list.aspx"  class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName","companylist.aspx,companybrandlist.aspx","","active") %>" onmousemove="showhideabc();" onmouseout="hideshowabc()">家具品牌</a>
                <input type="hidden" id="abcshowid" value="0" />
            </li>
           <li><a href="<%=TREC.ECommerce.ECommon.WebUrl %>market/list.aspx">家具卖场</a></li>
           <li><a>促销活动</a></li>
            <li><a href="<%=TREC.ECommerce.ECommon.WebUrl %><%=EnUrls.NewsList %>" class="<%=UiCommon.QueryStringCur("pageName", "news.aspx,newsinfo.aspx", "", "active") %>">行业资讯</a></li>
        </ul>
    </div>
</div> 