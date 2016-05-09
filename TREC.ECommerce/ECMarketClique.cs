using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREC.Entity;
using TREC.Data;
using TRECommon;

namespace TREC.ECommerce
{
    /// <summary>
    /// 卖场集团BLL类
    /// </summary>
    public class ECMarketClique
    {
        /// <summary>
        /// 更新卖场集团对像
        /// </summary>
        public static int EditMarketClique(EnMarketClique model)
        {
            return MarketClique.EditMarketClique(model);
        }
        /// <summary>
        /// 卖场集团分页数据
        /// </summary>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="strWhere">条件</param>
        /// <param name="pagecount">总页数</param>
        /// <returns></returns>
        public static List<EnMarketClique> GetMarketCliqueList(int pageindex, int pagesize, string strWhere, out int pagecount)
        {
            return MarketClique.GetMarketCliqueList(pageindex, pagesize, strWhere, out pagecount);
        }

        /// <summary>
        /// 按idlist条件删除卖场集团
        /// </summary>
        /// <param name="idlist">id列表</param>
        /// <returns></returns>
        public static int DeleteMarketClique(string idlist)
        {
            return MarketClique.DeleteMarketClique(idlist);
        }
        /// <summary>
        /// 更具sql条件获取卖场集团对象
        /// </summary>
        /// <param name="strWhere">where条件(要写where关键字)</param>
        /// <returns></returns>
        public static EnMarketClique GetMarketClique(string strWhere)
        {
            return MarketClique.GetMarketClique(strWhere);
        }
        /// <summary>
        /// 更具集团id获取卖场集团对象
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static EnMarketClique GetMarketCliqueById(int marketCliqueId)
        {
            return MarketClique.GetMarketCliqueById(marketCliqueId);
        }
        /// <summary>
        /// 更具主卖场id获取卖场集团对象
        /// </summary>
        /// <param name="marketId">主卖场id</param>
        /// <returns></returns>
        public static EnMarketClique GetMarketCliqueByMainMarketId(int marketId)
        {
            return MarketClique.GetMarketCliqueByMainMarketId(marketId);
        }
        /// <summary>
        /// 通过登陆ID获取集团信息
        /// </summary>
        /// <param name="Mid"></param>
        /// <returns></returns>
        public static EnMarketClique GetMarketCliqueByMid(int Mid)
        {
            return MarketClique.GetMarketCliqueByMid(Mid);
        }
        public static EnMarketClique GetMarketCliqueByWhere(string Where)
        {
            return MarketClique.GetMarketCliqueByWhere(Where);
        }
        /// <summary>
        /// 更具子卖场id获取卖场集团对象
        /// </summary>
        /// <param name="submarketId">子卖场id</param>
        /// <returns></returns>
        public static EnMarketClique GetMarketCliqueBySubMarketId(int submarketId)
        {
            return MarketClique.GetMarketCliqueBySubMarketId(submarketId);
        }
        /// <summary>
        /// 更具子卖场id或主卖场id获取卖场集团对象
        /// </summary>
        /// <param name="submarketId">子卖场id或主卖场id</param>
        /// <returns></returns>
        public static EnMarketClique GetMarketCliqueBySubMainMarketId(int submarketId)
        {
            EnMarketClique models = ECMarketClique.GetMarketCliqueByMainMarketId(submarketId);
            if (models != null && models.Auditstatus == 1)
            {
                return models;
            }
            else
            {
                models = ECMarketClique.GetMarketCliqueBySubMarketId(submarketId);
                if (models != null && models.Auditstatus == 1)
                {
                    return models;
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 更具集团对象返回审核通过的集团对象
        /// </summary>
        /// <param name="paramodel">集团对象</param>
        /// <returns></returns>
        public static EnMarketClique GetMarketCliqueByModel(EnMarketClique paramodel)
        {
            return MarketClique.GetMarketCliqueByModel(paramodel);
        }

        /// <summary>
        /// 按子卖场id列表和集团id设置卖场和集团关系表
        /// </summary>
        /// <param name="marketCliqueId">集团id</param>
        /// <param name="idList">子卖场id列表字符串(123,456,789)</param>
        public static void SetSubMarket(int marketCliqueId, string idList)
        {
            MarketClique.SetSubMarket(marketCliqueId, idList);
        }

        /// <summary>
        /// 更具集团id删除所有子卖场
        /// </summary>
        /// <param name="marketCliqueId"></param>
        public static void DeleteSubMarket(int marketCliqueId)
        {
            MarketClique.DeleteSubMarket(marketCliqueId);
        }

        /// <summary>
        /// 更具集团id获取卖场
        /// </summary>
        /// <param name="marketCliqueId">集团id</param>
        /// <returns></returns>
        public static string[] GetSubMarketByMarketCliqueId(int marketCliqueId)
        {
            return MarketClique.GetSubMarketByMarketCliqueId(marketCliqueId);
        }

        /// <summary>
        /// 更具 集团id列表设置审核状态
        /// </summary>
        /// <param name="marketCliquelistId">集团id列表</param>
        /// <param name="auditstatus">审核状态</param>
        public static void SetMarketCliqueAuditstatus(string marketCliquelistId, int auditstatus)
        {
            MarketClique.SetMarketCliqueAuditstatus(marketCliquelistId, auditstatus);
        }
    }
}
