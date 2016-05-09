using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using System.Collections;
using Haojibiz;

namespace TREC.Web.template.web.ascx
{
	public partial class Headpavilion : System.Web.UI.UserControl
	{

        public Hashtable _htb = new Hashtable();//数据统计
        protected string _marketid = "";
        public string _marketcliqueid = "0"; //卖场集团ID
        public string cid = "0";
        public string paid
        {
            get
            {
                if (Request["paid"] != null)
                {
                    return Request["paid"];
                }
                else
                {
                    return "0";
                }
            }
        }
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
       public string title = string.Empty;
       public string pimg = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            _htb = ECProduct.GetIndexCount().FirstOrDefault();
            _marketid = ECommon.QueryMid;

            if (_marketid != "")
            {
                EnMarket _marketinfor = ECMarket.GetMarketInfo(" where id=" + _marketid);
                EnMarketClique model = ECommerce.ECMarketClique.GetMarketCliqueByWhere(" where title='" + _marketinfor.MarketCliqueName + "'");
                if (model != null && model.Auditstatus == 1)
                {
                    _marketcliqueid = model.Id.ToString();


                }
            }

            t_Pavilion _pav = new t_Pavilion();
            _pav = EntityOper.t_Pavilion.Where(p => p.Id == SubmitMeth.getInt(paid)).FirstOrDefault();

            if (_pav != null)
            {
                title = _pav.Title;
                pimg = _pav.Bannel;
            }
        }
	}
}