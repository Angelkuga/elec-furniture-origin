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



    public partial class marketclique : MarketCliquePageBase
    {
        protected string _marketid = "";
        protected string _marketcliqueid = ""; //卖场集团ID
       
        protected List<EnWebMarket> _marketlist = new List<EnWebMarket>();
        protected Mpromotions[] _promotion = new Mpromotions[] { };

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

            //if (_marketid != "")
            //{
          
            if (_marketcliquemodel != null)
            {
                    pageTitle = "-" + _marketcliquemodel.Title + "-卖场集团首页";
                  //  string[] marketidArr = TREC.ECommerce.ECMarketClique.GetSubMarketByMarketCliqueId(_marketcliquemodel.Id);
                   
               
                    //marketIdlist += _marketcliquemodel.MarketId;
                    int pc = 0;
                    //_marketlist = ECMarket.GetWebMarketList(1, 30, string.Format(" and auditstatus=1 and linestatus=1 and id in ({0})", marketIdlist), "hits", "desc", out pc);

                    _marketlist = ECMarket.GetWebMarketList(1, 300, " and MarketCliqueName='" + _marketcliquemodel.Title + "' ", "hits", "desc", out pc);
                    string marketIdlist = "0";
                    foreach (EnWebMarket items in _marketlist)
                    {
                        marketIdlist =marketIdlist+  ','+items.id ;
                    }    
                string strWhere = string.Format(" id in ( select brandid from t_shopbrand where shopid in (select shopid from t_marketstoreyshop where linestatus=2 and marketid in ({0}))) ", marketIdlist);
                   
                brandList = TREC.ECommerce.ECBrand.GetWebBrandList(1, 8, strWhere, out pc);


                    Dpromotions dpromotions = new Dpromotions();


                    List<EnMarket> submarket = TREC.ECommerce.ECMarket.GetMarketList(string.Format(" id in ({0})", marketIdlist));
                    List<int> midlist = new List<int>();
                    foreach (EnMarket items in submarket)
                    {
                        midlist.Add(items.mid);
                    }
                    _promotion = dpromotions.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1 && (midlist.ToArray()).Contains(c.mid)).OrderByDescending(c => c.id).Take(4).ToArray();

                    EnMarket mbanner = ECMarket.GetMarketInfo(string.Format(" where id = {0}", _marketcliquemodel.MarketId));
                    if (mbanner != null && mbanner.bannel != null)
                    {
                        _marketbanner = mbanner.bannel.TrimEnd(',').Split(',');
                    }
                }
           // }
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