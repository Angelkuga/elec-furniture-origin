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



    public partial class marketcliquebusiness : MarketCliquePageBase
    {
        protected string _marketid = "";
        protected string _marketcliqueid = ""; //卖场集团ID
      
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
                    pageTitle = "-" + _marketcliquemodel.Title + "-卖场集团招商信息";
                    //string[] marketidArr = TREC.ECommerce.ECMarketClique.GetSubMarketByMarketCliqueId(_marketcliquemodel.Id);
                    //string marketIdlist = "";
                    //foreach (string items in marketidArr)
                    //{
                    //    marketIdlist += items + ',';
                    //}
                    //marketIdlist += _marketcliquemodel.MarketId;
                    //int pc = 0;
                    //_marketlist = ECMarket.GetWebMarketList(1, 300, string.Format(" and auditstatus=1 and linestatus=1 and id in ({0})", marketIdlist), "hits", "desc", out pc);

                    int pc = 0;
                    _marketlist = ECMarket.GetWebMarketList(1, 300, " and MarketCliqueName='" + _marketcliquemodel.Title + "' ", "hits", "desc", out pc);

                    string marketIdlist = "0";
                    foreach (EnWebMarket items in _marketlist)
                    {
                        marketIdlist =marketIdlist+ ',' + items.id;
                    }    

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