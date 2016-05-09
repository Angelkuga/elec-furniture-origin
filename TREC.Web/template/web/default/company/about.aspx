<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.company.about" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/headerCompany.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/_companyproduct.ascx" TagName="_companyproduct" TagPrefix="uc5" %>
<%@ Register src="../ascx/_companykeys.ascx" tagname="_companykeys" tagprefix="uc6" %>
<%@ Register src="../ascx/_teladdress.ascx" tagname="_teladdress" tagprefix="uc7" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=pageTitle %></title>
     <ucnewresource:newresource ID="newresource1" runat="server" />
    <uc6:_companykeys ID="_companykeys1" Title="-厂家介绍" runat="server" />
    <link href="/resource/content/css/core.css" rel="stylesheet" />
    <link href="/resource/content/css/factory/factory.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/jjcss/index_new.css">
    <link rel="Stylesheet" type="text/css" href="/resource/jjcss/common.css">
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
</head>
<body>    
    <uc1:header ID="header1" runat="server" />
    <div class="site"><a href="/">家具快搜</a> > <a href="/companybrandlist.aspx">品牌</a> > 厂商介绍</div>
    <div class="homebrandsc">
        <div class="topNav992">
            


            <div class="homebraLift">
                <div class="homebraLi2">
                    <h3>厂商介绍</h3>
                    <div class="jies">
                    
                      <%=companyInfo.descript %>

                    </div>
                   
                    
                </div>
            </div>


            <div class="homebraRight">
                <uc5:_companyproduct ID="_companyproduct1" runat="server" />
               <uc7:_teladdress ID="_teladdress1" runat="server" />
            </div>
        </div>
    </div>
    <ucfooter:footer ID="header2" runat="server" />
</body>
</html>
