using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TREC.Entity;
using TREC.Data;
using TRECommon;
using System.Collections;


namespace TREC.ECommerce
{
    public class ECMarket
    {
         /// <summary>
        /// 获取卖场集团
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMarketClique(int pageindex, ref int count)
        {
            return Markets.GetMarketClique(pageindex,ref count);
        }
        public static int ExitMarketLetter(string title)
        {
            return Markets.ExitMarketLetter(title);
        }


        public static int ExitMarket(string title)
        {
            return Markets.ExitMarket(title);
        }


        public static EnWebMarket GetWebMarketInfo(string strWhere)
        {
            return Markets.GetWebMarketInfo(strWhere);
        }

        public static List<EnWebMarket> GetWebMarketList(int PageIndex, int PageSize, string strWhere,string sortkey, string ordertype, out int pageCount)
        {
            return Markets.GetWebMarketList(PageIndex, PageSize, strWhere, sortkey, ordertype, out pageCount);

        }

        public static List<EnWebMarket> GetMarketByLetter(string strWhere)
        {
            return Markets.GetMarketByLetter(strWhere);
        }

        public static DataTable GetMarketLetterList()
        {
            //object obj = DataCache.GetCache(CacheKey.MarketLetter);
            //if (obj != null)
            //{
            //    return (DataTable)obj;
            //}
            //else
            //{

            
            DataTable marketLetterDt = DataCommon.GetDataTable(TableName.TBMarket, " id,mid,title,substring(letter,1,1) as letter,groupid,attribute,industry,productcategory,vip,areacode,address,mapapi,staffsize,regyear,regcity,buy,sell,cbm,lphone,zphone,busroute,hours,linkman,phone,mphone,fax,email,postcode,homepage,domain,domainip,icp,surface,logo,thumb,bannel,desimage,descript,keywords,template,hits,sort,createmid,lastedid,lastedittime,auditstatus,linestatus,sortstr,IsPay", " where auditstatus=1", "");
            if (marketLetterDt.Rows.Count > 0)
            {
                TRECommon.DataCache.SetCache(CacheKey.MarketLetter, marketLetterDt);
            }
            else
            {
                TRECommon.DataCache.Remove(CacheKey.MarketLetter);
            }


                return marketLetterDt;
            //}
        }

        public static DataTable GetMarketSelectByBrand(string marketid, string brandid)
        {
            string bid="0";
            if (brandid == null || brandid == "")
            {
                bid = "0";
            }
            else
            {
                bid = brandid;
            }
            DataTable marketLetterDt = DataCommon.GetDataTable(TableName.TBMarket, " id", " where id in(select marketid from t_marketstoreyshop where shopid in(select shopid from t_shopbrand where brandid in(" + bid + ")))and id=" + marketid, "");
            
            return marketLetterDt;
        }

        public static List<EnSearchItem> GetSearchItem()
        {
            List<EnSearchItem> list = new List<EnSearchItem>();
            List<EnSearchItem> itemList = (List<EnSearchItem>)DataCache.GetCache(CacheKey.MarketSearchItemList);

            if (itemList == null)
            {
                itemList = Markets.GetMarketSearchItem();
                DataCache.SetCache(CacheKey.MarketSearchItemList, itemList);
            }


            foreach (EnSearchItem item in itemList)
            {
                if (item.type == "area" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchArea != "" && ECommon.QuerySearchArea.Split('_').Contains(item.value))
                    {
                        item.isCur = true;
                        list.Add(item);
                        continue;
                    }
                    else
                    {
                        item.isCur = false;
                    }
                }

                list.Add(item);
            }
            return list;
        }


        public static int UpConFilePath(string con, int id)
        {
            return DataCommon.UpdateValue(TableName.TBMarket, "descript", con, " where id=" + id);
        }



        //获取最新注册用户
        public static List<EnMarket> GetTop20MarketList()
        {
            return GetTop20MarketList("");
        }

        public static List<EnMarket> GetTop20MarketList(string name)
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(name))
            {
                strWhere += " where title like '%" + name + "%'";
            }
            return GetMarketList(" top 20 * ", strWhere, " order by id desc");
        }

        public static List<EnAggregation> GetIndexMarketRecommandAd(string typeName)
        {
            return Markets.GetIndexMarketRecommandAd(typeName);
        }

        public static List<EnMarket> GetMarketInfoVSNameAndIdList(string strWhere,string sort)
        {
            DataTable dt = DataCommon.GetDataTable(TableName.TBMarket, "id,title", strWhere, sort);
            List<EnMarket> list = new List<EnMarket>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EnMarket model = new EnMarket();
                    model.id = int.Parse(dt.Rows[i]["id"].ToString());
                    model.title = dt.Rows[i]["title"].ToString();
                    list.Add(model);
                } 
            }
            return list;
        }

        /// <summary>
        /// 根据下拉城市获取卖场信息
        /// </summary>
        /// <param name="citycode"></param>
        /// <returns></returns>
        public static List<EnMarket> GetMarketListByCity2(string citycode)
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(citycode))
            {
                strWhere += " where areacode like '%" + citycode + "%'";
            }
            return GetMarketList(" * ", strWhere, " order by id desc");
        }

        public static EnMarket GetMarketInfoVSNameAndIdInfo(string strWhere)
        {
            List<EnMarket> list = GetMarketInfoVSNameAndIdList(strWhere, "");
            return list.Count > 0 ? list[0] : null;
        }

        #region  Method-Market
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMarket(EnMarket model)
        {
            return Markets.EditMarket(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnMarket GetMarketInfo(string strWhere)
        {
            return Markets.GetMarketInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMarket> GetMarketList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Markets.GetMarketList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnMarket> GetMarketList(string strWhere, out int pageCount)
        {
            return GetMarketList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnMarket> GetMarketList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetMarketList(-1, 0, strWhere, out tmpPageCount);
        }

        ///获取数据列表
        public static List<EnMarket> GetMarketList(string field, string strWhere, string sort)
        {
            return Markets.GetMarketList(field, strWhere, sort);
        }

        //获取数据列表ToDataTable
        public static DataTable GetMarketListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBMarket, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletEnMarket(int id)
        {
            return DeletEnMarket(" where id=" + id);
        }
        ///删除对象
        public static int DeletEnMarketByIdList(string idList)
        {
            return DeletEnMarket(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletEnMarket(string strWhere)
        {
            return DataCommon.Delete(TableName.TBMarket, strWhere);
        }
        #endregion

        #region  Method-MarketGroup
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditMarketGroup(EnMarketGroup model)
        {
            return Markets.EditMarketGroup(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnMarketGroup GetMarketGroupInfo(string strWhere)
        {
            return Markets.GetMarketGroupInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnMarketGroup> GetMarketGroupList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Markets.GetMarketGroupList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnMarketGroup> GetMarketGroupList(string strWhere, out int pageCount)
        {
            return GetMarketGroupList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnMarketGroup> GetMarketGroupList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetMarketGroupList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetMarketGroupListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBMarketGroup, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletEnMarketGroup(int id)
        {
            return DeletEnMarketGroup(" where id=" + id);
        }
        ///删除对象
        public static int DeletEnMarketGroupByIdList(string idList)
        {
            return DeletEnMarketGroup(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletEnMarketGroup(string strWhere)
        {
            return DataCommon.Delete(TableName.TBMarketGroup, strWhere);
        }
        #endregion

        #region 首页数据统计
        public static List<Hashtable> GetMarkCount(string markid)
        {
            return Markets.GetMarkCount(markid);
        }
        #endregion
    }
}
