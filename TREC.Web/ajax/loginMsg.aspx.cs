using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace TREC.Web.ajax
{
    public partial class loginMsg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder _value=new StringBuilder("<li>欢迎您来到家具快搜 &nbsp;|&nbsp;</li>");

             if (TRECommon.CookiesHelper.GetCookieCustomer("cid") != "")
              {
                 _value.Append("<li><strong style=\"color: #0000FF;\">"+TRECommon.CookiesHelper.GetCookieCustomer("cname"));
               _value.Append("</strong></li>");
                 _value.Append("<li></li>");
                _value.Append("<a href=\""+TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')+"/logoutuser.aspx\">[退出]</a>");
               
            }
              else if (TRECommon.CookiesHelper.GetCookie("mid") != "" && TRECommon.CookiesHelper.GetCookie("mname") != "")
              { 
                  _value.Append("<li><a href=\""+TREC.ECommerce.ECommon.WebSupplerUrl.TrimEnd('/')+"/suppler/index.aspx\">");
                    _value.Append("<strong>["+TRECommon.CookiesHelper.GetCookie("mname") != "" && TRECommon.CookiesHelper.GetCookie("mname").Length > 7 ? TRECommon.CookiesHelper.GetCookie("mname").Substring(0, 7) + ".." : TRECommon.CookiesHelper.GetCookie("mname")+"]</strong>");
                    _value.Append("</a></li>");
                    _value.Append("<li></li>");
                    _value.Append("<a href=\"");
                    _value.Append(TREC.ECommerce.ECommon.WebUrl.TrimEnd('/'));
                  _value.Append("/loginout.aspx\">[退出]</a></li>");
               
           
              }else{
                  _value.Append("<li><a href=\"/loginuser.aspx\">登录</a> &nbsp;|&nbsp;</li><li><a href=\"/reguser.aspx\">注册</a> </li>");  
            }

             Response.Write(_value.ToString());
        }
    }
}