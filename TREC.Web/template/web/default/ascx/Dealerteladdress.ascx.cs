using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Web.Code;
using Haojibiz;
using System.Text;
using TREC.ECommerce;

namespace TREC.Web.template.web.ascx
{
	public partial class Dealerteladdress : System.Web.UI.UserControl
	{
        public string name, phone, address;
      public  List<t_shop> list = new List<t_shop>();

      /*
         
        <table border="0">
  <tr><td style="width:40px;" valign="top">商家：</td><td><%=name%></td> </tr> 
  <tr><td valign="top">地址：</td><td> <%=address%></td></tr>
  <tr><td valign="top">电话：</td><td><span><%=phone%></span></td> </tr>
      </table>
       */
         public bool isPay = false; 
      Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
      public string showaddress = string.Empty;

		protected void Page_Load(object sender, EventArgs e)
		{
            DealerPageBase _pagebase = new DealerPageBase();
            StringBuilder _value = new StringBuilder(string.Empty);

            if (_pagebase.DealerInfor != null)
            {
                isPay = SupplerPageBase.IsPayMember(_pagebase.DealerInfor.mid.ToString());
                list = EntityOper.t_shop.Where(p => p.mid == _pagebase.DealerInfor.mid).ToList();
                if (_pagebase.companylist.Count > 0)
                {
                    foreach (t_company c in _pagebase.companylist)
                    {
                       string addr = TREC.ECommerce.ECommon.getAreaAll(c.areacode).Replace("市辖区", "") + c.address.Replace(TREC.ECommerce.ECommon.getAreaAll(c.areacode), "").Replace("市辖区", "");
                        _value.Append("<table border='0'>");
                        _value.Append(" <tr><td style=\"width:40px;\" valign=\"top\">厂商：</td><td>" + c.title + "</td> </tr> ");
                        _value.Append(" <tr><td valign=\"top\">地址：</td><td>" + addr + "</td></tr>");
                        _value.Append("<tr><td valign=\"top\">电话：</td><td><span>"+c.phone+"</span></td> </tr>");
                        _value.Append("</table>");
                        _value.Append("<br />");
                        _value.Append("<br />");
                    }
                }
                else
                {
                    name = _pagebase.DealerInfor.title;
                    phone = string.IsNullOrEmpty(_pagebase.DealerInfor.phone) ? _pagebase.DealerInfor.mphone : _pagebase.DealerInfor.phone;
                    address = TREC.ECommerce.ECommon.getAreaAll(_pagebase.DealerInfor.areacode).Replace("市辖区", "") + _pagebase.DealerInfor.address.Replace(TREC.ECommerce.ECommon.getAreaAll(_pagebase.DealerInfor.areacode), "").Replace("市辖区", "");

                    _value.Append("<table border='0'>");
                    _value.Append(" <tr><td style=\"width:40px;\" valign=\"top\">厂商：</td><td>" + name + "</td> </tr> ");
                    _value.Append(" <tr><td valign=\"top\">地址：</td><td>" + address + "</td></tr>");
                    _value.Append("<tr><td valign=\"top\">电话：</td><td><span>" + phone + "</span></td> </tr>");
                    _value.Append("</table>");

                }

                showaddress = _value.ToString();
            }
		}
	}
}