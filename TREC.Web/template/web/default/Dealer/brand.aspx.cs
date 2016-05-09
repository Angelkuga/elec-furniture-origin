using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Web.Code;
using Haojibiz;
using TREC.ECommerce;

namespace TREC.Web.template.web.Dealer
{
    public partial class brand : DealerPageBase
	{
        public string BrandDescript;

        public string brnadName, brandStyle, brandId,brandlog;
        public string dname, ddesc="";
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        List<t_brand> _listbrand = new List<t_brand>();

        public int bid
        {
            get
            {
                if (Request["bid"] != null)
                {
                    return SubmitMeth.getInt(Request["bid"]);
                }
                else
                {
                    return 0;
                }
            }
        }
		protected void Page_Load(object sender, EventArgs e)
		{
            if (DealerInfor != null)
            {
                t_brand _brand=new t_brand();
                _brand = EntityOper.t_brand.Where(p => p.createmid == DealerInfor.mid).FirstOrDefault();
                if(bid>0)
                {
                    _listbrand=EntityOper.t_brand.Where(p => p.createmid == DealerInfor.mid&&p.id==bid).ToList();
                }
                else
                {
                _listbrand=EntityOper.t_brand.Where(p => p.createmid == DealerInfor.mid).ToList();
                }
                BrandDescript = _brand.descript;
                brnadName = _brand.title;
                brandStyle = _brand.style;
                ddesc = SubmitMeth.bSubstring(ddesc, 150);
                dname = DealerInfor.title;

                brandId = _brand.id.ToString();
                brandlog = _brand.logo.Replace(",", "");

                Repeater_brand.DataSource = _listbrand;
                Repeater_brand.DataBind();
            }
		}
	}
}