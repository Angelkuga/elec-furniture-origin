using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TREC.Web.aspx.market
{


    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    using Haojibiz.Model;
    using Haojibiz.DAL;
    #endregion



    public partial class marketcliquesubmarket : MarketCliquePageBase
    {
        protected string _marketid = "";
        protected string _marketcliqueid = ""; //卖场集团ID
       // protected EnMarketClique _marketcliquemodel = new EnMarketClique();
        protected List<EnWebMarket> _marketlist = new List<EnWebMarket>();

        //集团主卖场banner
        protected string[] _marketbanner = new string[] { };

        //卖场推荐品牌id
        protected string brandidList = "0";
        //卖场推荐品牌
        protected List<EnWebBrand> brandList = new List<EnWebBrand>();
        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "-" + "-卖场集团";
            _marketid = ECommon.QueryMid;

           
                //_marketcliquemodel = TREC.ECommerce.ECMarketClique.GetMarketCliqueBySubMainMarketId(int.Parse(_marketid));
                if (_marketcliquemodel != null)
                {
                    pageTitle = "-" + marketInfo.title + "-卖场集团商场";
                    int pc = 0;
                    //string[] marketidArr = TREC.ECommerce.ECMarketClique.GetSubMarketByMarketCliqueId(_marketcliquemodel.Id);
                    _marketlist = ECMarket.GetWebMarketList(1, 300, " and MarketCliqueName='" + _marketcliquemodel.Title + "' ", "hits", "desc", out pc);
                    
                    //string marketIdlist = "0";
                    //foreach (EnWebMarket items in _marketlist)
                    //{
                    //    marketIdlist += ',' + items.id;
                    //}    
                   
                   // _marketlist = ECMarket.GetWebMarketList(1, 30, string.Format(" and auditstatus=1 and linestatus=1 and id in ({0})", marketIdlist), "hits", "desc", out pc);

                }
   
        }
        /// <summary>
        /// 更具活动的mid取卖场ID
        /// </summary>
        /// <param name="promID"></param>
        /// <returns></returns>
        protected int GetMarketIdByPromotions(int promMID)
        {
            EnMarket model = TREC.ECommerce.ECMarket.GetMarketInfo(string.Format(" where mid = {0} ", promMID));
            if (model == null)
            {
                return 0;
            }
            else
            {
                return model.id;
            }
        }
    }
}