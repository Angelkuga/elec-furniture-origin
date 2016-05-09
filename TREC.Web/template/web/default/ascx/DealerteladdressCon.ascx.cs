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
    public partial class DealerteladdressCon : System.Web.UI.UserControl
	{
        public string name, phone, address;
        public bool isPay = false; 
      public  List<t_shop> list = new List<t_shop>();

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

                             _value.Append("<p>厂商：" + c.title + "</p>");
                             _value.Append(" <p><span style=\"float:left;\">地址：</span><span style=\"margin-left:41px; display:block;\">" + addr + "</span></p>");
                             _value.Append("  <p>电话： <span style=\"color:#cc0000; font-weight:bold;\">" + c.phone + "</span></p>");

                            
                             _value.Append("<br />");
                             _value.Append("<br />");
                         }
                     }
                     else
                     {
                         name = _pagebase.DealerInfor.title;
                         phone = string.IsNullOrEmpty(_pagebase.DealerInfor.phone) ? _pagebase.DealerInfor.mphone : _pagebase.DealerInfor.phone;
                         address = TREC.ECommerce.ECommon.getAreaAll(_pagebase.DealerInfor.areacode).Replace("市辖区", "") + _pagebase.DealerInfor.address.Replace(TREC.ECommerce.ECommon.getAreaAll(_pagebase.DealerInfor.areacode), "").Replace("市辖区", "");

                         _value.Append("<p>厂商：" + name + "</p>");
                         _value.Append(" <p><span style=\"float:left;\">地址：</span><span style=\"margin-left:41px; display:block;\">" + address + "</span></p>");
                         _value.Append("  <p>电话： <span style=\"color:#cc0000; font-weight:bold;\">" + phone + "</span></p>");

                     }

                     showaddress = _value.ToString();
                 }
             }
	}
}