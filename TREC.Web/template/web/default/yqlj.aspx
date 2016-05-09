<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yqlj.aspx.cs" Inherits="TREC.Web.template.web.yqlj" %>
 
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>友情链接</title>
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <script src="/resource/content/libs/jquery-1.11.0.min.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/index/index.js"></script>
    <style>
        .serviceColumn
        {
            width: 220px;
            border: 0;
        }
        .serviceColumn h2
        {
            background: #828282;
            color: #fff;
            height: 20px;
            line-height: 20px;
            border-bottom: 0;
            position: relative;
        }
        .serviceColumn .block1 .d1
        {
            padding-bottom: 30px;
        }
        .serviceColumn .block1
        {
            padding-bottom: 0;
        }
        .serviceColumn h2 span
        {
            position: absolute;
            bottom: -4px;
            left: 35px;
        }
        .serviceCenter .hd
        {
            border: 1px solid #d0d0d0;
            height: 40px;
            padding-left: 25px;
            line-height: 40px;
            font-weight: bold;
        }
        .serviceCenter .bd
        {
            border: 1px solid #cacaca;
            border-top: 1px solid #5c070f;
            padding: 19px;
            min-height: 646px;
            _height: 646px;
        }
        .serviceCenter .bd .strong
        {
            font-weight: bold;
        }
        .serviceCenter .bd .red
        {
            color: #981120;
        }
        .serviceCenter .bd .underline
        {
            text-decoration: underline;
        }
        .serviceCenter .bd a:hover
        {
            text-decoration: underline;
        }
        .serviceCenter .bd p
        {
            margin-bottom: 25px;
            line-height: 24px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:header ID="header1" runat="server" />
    <div style="width:1000px;margin:0 auto">
        <table id='tab1' border="1" align="center" style="text-align: center; ">
            <tr>
                <td colspan='2' style="width:220px">
                    <img alt="关于我们" src="/resource/content/images/about/about1.jpg" original="/images/about/about1.jpg">
                </td>
            </tr>
            <tr>
                <td style="vertical-align:top" >
                    <div class="spL" style="border: 1px solid #cacaca; margin-right: 10px;margin-top:10px;">
                        <div class="spColumn serviceColumn" id="Div1">
                            <div class="block1">
                                <h2 style="background: #b82935; font-size: 12px;">
                                    关于我们<span><img src="/resource/content/images/about/about1.gif" alt="" original="/images/about/about1.gif"></span></h2>
                                <div class="d1" style="min-height: 707px; _height: 707px;">
                                    <p><a class="a1 cur" href="gywm.aspx">公司简介</a></p>
                                    <p><a class="a1 cur" href="lxwm.aspx">联系我们</a></p>
                                    <p><a class="a1 cur" href="yqlj.aspx">友情链接</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
                <td style="vertical-align:top" >
                    <div class="spR" style="margin-top:10px; ">
                        <div class="serviceCenter">
                        
                            <div class="hd">
                                友情链接</div>
                              <div class="bd" style="line-height: 21px; padding-top: 60px; color: #6c6c6c;">
                                <table style="text-align: left;width:715px;">
                                     
                                    <tr>
                                        <td>
                                         
                                          <a href="http://www.fujiawang.com/" title="福家网" target="_blank">福家网</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
                             <a href="http://www.hzruida.com/" title="福家网" target="_blank">KTV装修</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
                             <a href="http://www.jmshongwei.com/" title="福家网" target="_blank">实木家具</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
                             <a href="http://www.jujiaju.cn/" title="福家网" target="_blank">聚家具</a>


                                        </td>
                                    </tr>
                                </table>
                            </div>    
 
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <ucfooter:footer ID="header2" runat="server" />
    </form>
    <script>
//        var width = (screen.width - 988) / 2;
//        $("#tab1").css({ 'margin-left': width });
    </script>
</body>
</html>
