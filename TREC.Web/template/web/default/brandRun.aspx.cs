using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz;
using TREC.ECommerce;
using System.Text;


namespace TREC.Web.template.web
{
	public partial class brandRun : System.Web.UI.Page
	{
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();

        private void run()
        {
            List<t_brand> _list = new List<t_brand>();

            _list = EntityOper.t_brand.Where(p => p.letter == "").ToList();

            foreach (t_brand b in _list)
            {
                b.letter = Hz2Py.Convert(b.title);
            }
            EntityOper.SubmitChanges();

            Response.Write("完成");
        }

        public string getalert(bool show,string msg)
        {
            string display = "display:none;";
            if (show)
            {
                display = "display:block;";
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
            _value.Append("<div style=\"padding-left:130px;padding-top:15px;\"><input type=\"button\"  value=\"确定\" style=\"width:75px;\" onclick=\"document.getElementById('alertku1').style.display = 'none'; document.getElementById('alertku2').style.display = 'none';\"/> </div>");
            _value.Append(" </td>");
            _value.Append(" </tr>");
            _value.Append(" </table>");
            _value.Append(" </div>");
            _value.Append("<div style=\"" + display + "position: absolute; background-color: #000000; left: 0; top: 0; width: 100%; height: 100%; z-index: 99998;filter:alpha(opacity=10);-moz-opacity:0.1;-khtml-opacity: 0.1;opacity: 0.1;\" id=\"alertku2\">");
            _value.Append("</div>");

            return _value.ToString();

        }
       public string alert = "";
		protected void Page_Load(object sender, EventArgs e)
		{
            DateTime t = DateTime.Parse("0001/1/1 0:00:00");
          //  Response.Write(getalert(true,"测试提示信息"));
		}

        protected void Button1_Click(object sender, EventArgs e)
        {
           // alert = getalert(true, "测试提示信息");
        }
	}
}