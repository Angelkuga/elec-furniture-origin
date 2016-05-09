using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using System.Collections;

namespace TREC.Web.aspx.ascx
{
    public class headermarketClique : System.Web.UI.UserControl
    {
        public Hashtable _htb = new Hashtable();//数据统计
        public string _marketid = "";
        protected string _marketcliqueid = ""; //卖场集团ID
        protected string _marketcliquetitle = "";//卖场集团名称


        public int Clique
        {
            get
            {
                if (Request["id"] != null)
                {
                    return Int32.Parse(Request["id"]);
                }
                else
                {
                    return 0;
                }
            }
        }

        public int mid
        {
            get
            {
                if (Request["mid"] != null)
                {
                    return Int32.Parse(Request["mid"]);
                }
                else
                {
                    return 0;
                }
            }
        }

        public string title
        {
            get
            {
                if (Request["title"] != null)
                {
                    return Request["title"].Trim();
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public EnMarketClique _marketcliquemodel = new EnMarketClique();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            _htb = ECProduct.GetIndexCount().FirstOrDefault();
           // _marketid = ECommon.QueryMid;
            _marketid = "0";
            if (Clique > 0)
            {
                _marketcliquemodel = TREC.ECommerce.ECMarketClique.GetMarketCliqueByWhere(" where id=" + Clique + " and Auditstatus=1");
            }
            else if (mid > 0)
            {
                EnMarket _marketinfor = ECMarket.GetMarketInfo(" where id=" + mid);
                _marketcliquemodel = TREC.ECommerce.ECMarketClique.GetMarketCliqueByWhere(" where MarketCliqueName='" + _marketinfor.Stitle + ", and Auditstatus=1");
            }
            else if (!string.IsNullOrEmpty(title))
            {
                _marketcliquemodel = TREC.ECommerce.ECMarketClique.GetMarketCliqueByWhere(" where title='" + title + "' and Auditstatus=1");
            }


               // EnMarketClique model = ECommerce.ECMarketClique.GetMarketCliqueBySubMainMarketId(int.Parse(_marketid));
            if (_marketcliquemodel != null && _marketcliquemodel.Auditstatus == 1)
                {
                    _marketid = _marketcliquemodel.Id.ToString();
                    _marketcliqueid = _marketcliquemodel.Id.ToString();
                    _marketcliquetitle = _marketcliquemodel.Title;
                }
            
        }
    }
}