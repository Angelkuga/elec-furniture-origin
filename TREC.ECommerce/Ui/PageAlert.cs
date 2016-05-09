using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.ECommerce.Ui
{
    public class PageAlert
    {
        public static string getalert(bool show, string msg,string url)
        {
            string display = "display:none;";
            if (show)
            {
                display = "display:block;";
            }
            string sendurl = "location.href='" + url +"';";

            if (string.IsNullOrEmpty(url))
            {
                sendurl = "document.getElementById('alertku1').style.display = 'none'; document.getElementById('alertku2').style.display = 'none';";
            }
            StringBuilder _value = new StringBuilder(string.Empty);
            _value.Append("<div style=\"position:absolute;top:45%;left:45%;width:240px;height:145px; z-index: 999999;color:#000000;background-color: #ffffff;" + display + "\" id=\"alertku1\">");
            _value.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:240px;height:145px;\">");
            _value.Append(" <tr>");
            _value.Append(" <td style=\"width:100%;height:90px;background-color: #ffffff;font-size:12px;\">");
            _value.Append(" <center id=\"alertmsg\">");
            _value.Append(msg);
            _value.Append("</center>");
            _value.Append(" </td>");
            _value.Append(" </tr>");
            _value.Append("<tr>");
            _value.Append(" <td style=\"width:100%;height:55px;background-color: #F2F2F2\" valign=\"top\">");
            _value.Append("<div style=\"padding-left:130px;padding-top:15px;\"><input type=\"button\"  value=\"确定\" style=\"width:75px;\" onclick=\"" + sendurl + "\"/> </div>");
            _value.Append(" </td>");
            _value.Append(" </tr>");
            _value.Append(" </table>");
            _value.Append(" </div>");
            _value.Append("<div style=\"" + display + "position: absolute; background-color: #000000; left: 0; top: 0; width: 100%; height: 100%; z-index: 99998;filter:alpha(opacity=10);-moz-opacity:0.1;-khtml-opacity: 0.1;opacity: 0.1;\" id=\"alertku2\">");
            _value.Append("</div>");

            return _value.ToString();

        }
    }
}
