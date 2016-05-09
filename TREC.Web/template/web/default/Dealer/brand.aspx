<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="brand.aspx.cs" Inherits="TREC.Web.template.web.Dealer.brand" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="System.Linq" %>

<%@ Register Src="../ascx/HeadDealer.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/new_companyproduct.ascx" TagName="_companyproduct" TagPrefix="uc5" %>
<%@ Register src="../ascx/DealerProduct.ascx" tagname="DealerProduct" tagprefix="uc2" %>

<%@ Register src="../ascx/DealerteladdressCon.ascx" tagname="DealerteladdressCon" tagprefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title><%=title +"-品牌介绍"+ seoword %></title>
    <link href="/resource/content/css/core.css" rel="stylesheet" />
    <link href="/resource/content/css/factory/factory.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />
    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/factory/factory.js"></script>
    <script type="text/javascript">
        myFocus.set({
            id: 'fjwcontainer', //焦点图盒子ID
            pattern: 'mF_taobao2010', //风格应用的名称
            path: '<%=ECommon.WebResourceUrl %>/script/pattern/',
            time: 6, //切换时间间隔(秒)
            trigger: 'mouseover', //触发切换模式:'click'(点击)/'mouseover'(悬停)
            width: 767, //设置图片区域宽度(像素)
            height: 331, //设置图片区域高度(像素)
            txtHeight: 0//文字层高度设置(像素),'default'为默认高度，0为隐藏
        });
    </script>
    <script type="text/javascript">
        $(function () {
            if ("<%=ECommon.QuerySearchBrand %>" == "") {
                $($("#brandNav li:first-child a")).addClass("brandjs1a")
            }
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <uc1:header ID="header1" runat="server" />
    <div class="site"><a href="/">家具快搜</a> > <a href="/companybrandlist.aspx">品牌</a> >  品牌介绍</div>
    <div class="homebrandsc">
        <div class="topNav992">

        <div class="homebraLift">
                <div class="homebraLi2">
                    <h3>
                    品牌介绍</h3>
                    <div class="jies">
                        <asp:Repeater ID="Repeater_brand" runat="server">
                        <ItemTemplate>
                        
                    <div class="shopindex0">
                    <div class="Brand">
                        <div class="BrandLeft">
                            <p>
                                <span>品牌：</span><a target="_blank" href="/Dealer/<%=did %>/product-<%#Eval("Id") %>--------1-----.aspx"><strong><%#Eval("title")%></strong></a></p>
                            <p style="border-bottom: 1px dotted #C0C0C0;">
                                <span>厂商：</span><%=dname%>&nbsp;&nbsp;&nbsp;<span>风格：</span><%#Eval("style")%></p>
                            <p>
                               <%#Eval("descript")%></p>
                        </div>
                        <div class="BrandRight" style="position: relative;">
                            <div style="height: 70px;">
                                <img alt="<%#Eval("title")%>" src="<%#EnFilePath.GetBrandLogoPath(Eval("Id").ToString(), Eval("logo").ToString()) %>"
                                    width="196" height="70" />
                            </div>
                            <div class="productView" style="display: block; margin-top: 3px; width: 197px; position: relative;
                                right: 0;">
                                <div class="br-gcs">
                                    <ul>
    <li style="margin-right: 2px;"><a href="/Dealer/<%=did %>/product-<%#Eval("Id") %>--------1-----.aspx" class="btn">所有产品</a> </li>
    <li><a href="/Dealer/address.aspx?did=<%=did %>&bid=<%#Eval("Id")%>&page=1" class="btn">所有店铺</a> </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <br />
                       <%=BrandDescript %>
                        </ItemTemplate>
                        </asp:Repeater>


                    </div>
                   
                    
                </div>
            </div>

            <div class="homebraRight">
              <uc2:DealerProduct ID="DealerProduct1" runat="server" />
               <uc3:DealerteladdressCon ID="DealerteladdressCon1" runat="server" />
                
            </div>
        </div>
    </div>
    <ucfooter:footer ID="header2" runat="server" />
    </form>
</body>
</html>
