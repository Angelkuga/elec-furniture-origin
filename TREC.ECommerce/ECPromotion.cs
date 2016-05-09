using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TREC.Entity;
using TREC.Data;
using TRECommon;


namespace TREC.ECommerce
{
    public class ECPromotion
    {

        public static List<EnWebPromotion> GetWebPromotionList(int PageIndex, int PageSize, string strWhere, string sortkey, string orderby, out int pageCount)
        {
            return Promotions.GetWebPromotionList(PageIndex, PageSize, strWhere, sortkey, orderby, out pageCount);
        }

        public static List<EnWebPromotion> GetPromotionList(int PageIndex, int PageSize, string strWhere, string sortkey, string orderby, out int pageCount)
        {
            return Promotions.GetPromotionList(PageIndex, PageSize, strWhere, sortkey, orderby, out pageCount);
        }

        public static List<EnWebPromotion> GetWebTopPromotionList(int top, string strWhere, string orderKey, string orderType)
        {
            int pageCount = 0;
            return Promotions.GetWebPromotionList(1, top, strWhere, orderKey, orderType, out pageCount);
        }
        public static List<EnWebPromotion> GetWebTopPromotionList(int top)
        {
            return GetWebTopPromotionList(top, "", "sort", "desc");
        }

        public static List<EnWebPromotion> GetWebTopPromotionListToShop(int top,int shopId)
        {
            //List<EnWebPromotion> list=GetWebTopPromotionList(top, " and shopidlist like '%" + shopId + ",%'", "sort", "desc");
            //if (list.Count < top)
            //{
            //    list = GetWebTopPromotionList(top - list.Count);
            //}
            //return  GetWebTopPromotionList(top, " and shopidlist like '%" + shopId + ",%'", "sort", "desc");
            return GetWebTopPromotionList(top, "", "sort", "desc");
        }

        public static List<EnWebPromotion> GetWebTopPromotionListToCompany(int top, int companyId)
        {
            //List<EnWebPromotion> list=GetWebTopPromotionList(top, " and companyidlist like '%" + companyId + ",%'", "sort", "desc");
            //if (list.Count < top)
            //{
            //    list = GetWebTopPromotionList(top - list.Count);
            //}
            //return GetWebTopPromotionList(top, " and companyidlist like '%" + companyId + ",%'", "sort", "desc");
            return GetWebTopPromotionList(top, "", "sort", "desc");
        }

        public static List<EnWebPromotion> GetWebTopPromotionListToBrand(int top, int brandId)
        {
            //List<EnWebPromotion> list=GetWebTopPromotionList(top, " and brandidlist like '%" + brandId + ",%'", "sort", "desc");
            //if (list.Count < top)
            //{
            //    list = GetWebTopPromotionList(top - list.Count);
            //}
            //return GetWebTopPromotionList(top, " and brandidlist like '%" + brandId + ",%'", "sort", "desc"); ;
            return GetWebTopPromotionList(top, "", "sort", "desc");
        }

        public static List<EnWebPromotion> GetWebTopPromotionListToMarket(int top, int marketId)
        {
            //List<EnWebPromotion> list=GetWebTopPromotionList(top, " and marketidlist like '%" + marketId + ",%'", "sort", "desc");
            //if (list.Count < top)
            //{
            //    list = GetWebTopPromotionList(top - list.Count);
            //}
            //return GetWebTopPromotionList(top, " and marketidlist like '%" + marketId + ",%'", "sort", "desc");
            return GetWebTopPromotionList(top, "", "sort", "desc");
        }

        public static List<EnWebPromotion> GetWebTopPromotionListToProduct(int top, int productId)
        {
            //List<EnWebPromotion> list=GetWebTopPromotionList(top, " and productidlist like '%" + productId + ",%'", "sort", "desc");
            //if (list.Count < top)
            //{
            //    list = GetWebTopPromotionList(top - list.Count);
            //}
            //return GetWebTopPromotionList(top, " and productidlist like '%" + productId + ",%'", "sort", "desc"); ;
            return GetWebTopPromotionList(top, "", "sort", "desc");
        }



        public static List<EnWebPromotion> GetWebTopPromotionListToShopList(int top)
        {
            //List<EnWebPromotion> list=GetWebTopPromotionList(top, " and shopidlist is not null and shopidlist<>''", "sort", "desc");
            //if (list.Count < top)
            //{
            //    list = GetWebTopPromotionList(top - list.Count);
            //}
            //return GetWebTopPromotionList(top, " and shopidlist is not null and shopidlist<>''", "sort", "desc"); 
            return GetWebTopPromotionList(top, "", "sort", "desc");
        }

        public static List<EnWebPromotion> GetWebTopPromotionListToCompanyList(int top)
        {
            //List<EnWebPromotion> list=GetWebTopPromotionList(top, " and companyidlist is not null and companyidlist<>''", "sort", "desc");
            //if (list.Count < top)
            //{
            //    list = GetWebTopPromotionList(top - list.Count);
            //}
            //return GetWebTopPromotionList(top, " and companyidlist is not null and companyidlist<>''", "sort", "desc");
            return GetWebTopPromotionList(top, "", "sort", "desc");
        }

        public static List<EnWebPromotion> GetWebTopPromotionListToMarketList(int top)
        {
            //List<EnWebPromotion> list=GetWebTopPromotionList(top, " and marketidlist is not null and marketidlist<>''", "sort", "desc");
            //if (list.Count < top)
            //{
            //    list = GetWebTopPromotionList(top - list.Count);
            //}
            //return GetWebTopPromotionList(top, " and marketidlist is not null and marketidlist<>''", "sort", "desc"); 
            return GetWebTopPromotionList(top, "", "sort", "desc");
        }

        public static List<EnWebPromotion> GetWebTopPromotionListToProductList(int top)
        {
            //List<EnWebPromotion> list=GetWebTopPromotionList(top, " and productidlist is not null and productidlist<>''", "sort", "desc");
            //if (list.Count < top)
            //{
            //    list = GetWebTopPromotionList(top - list.Count);
            //}
            //return GetWebTopPromotionList(top, " and productidlist is not null and productidlist<>''", "sort", "desc"); 
            return GetWebTopPromotionList(top, "", "sort", "desc");
        }

        public static string GetPromotionHtml(List<EnWebPromotion> list)
        {
            if(list.Count==0)
                return "暂无促销信息";
            StringBuilder sb = new StringBuilder();
            foreach (EnWebPromotion p in list)
            {
                sb.Append("<div class=\"promotions2\">");
                sb.Append("<h3>"+p.title+"</h3>");
                sb.Append("<p class=\"time\">截至日期：" + DateTime.Parse(p.enddatetime.ToString()).ToShortDateString() + "</p>");
                sb.Append("<p class=\"address\">" + p.address + "</p>");
                //sb.Append("<p class=\"phone\">王丽君 13269291819</p>");
                sb.Append("</div>");
            }
            return sb.ToString();
      
        }

        public static int UpConFilePath(string con, int id)
        {
            return DataCommon.UpdateValue(TableName.TBPromotion, "descript", con, " where id=" + id);
        }

        /// <summary>
        /// 修改商务信息推荐
        /// </summary>
        /// <param name="id">商务信息id</param>
        /// <param name="sort">推荐</param>
        /// <returns></returns>
        public static bool updatePromotionsSortDb(int id,int sort,string memberId)
        {
            string Sql = string.Format(@"UPDATE [t_promotions] SET sort={2} WHERE id={0} AND mid={1} ", id.ToString(), memberId, sort.ToString());
            return DbHelper.ExecuteNonQuery(Sql) > -1 ? true : false;
        }

        /// <summary>
        /// 删除、上（下）线商务信息
        /// </summary>
        /// <param name="Type">操作类型</param>
        /// <param name="idStr">商务信息id</param>
        /// <param name="memberId">会员id</param>
        /// <returns></returns>
        public static bool doPromotionsDb(string Type, string idStr, string memberId)
        {
            string Sql = string.Empty;
            switch (Type)
            {
                case "delete":
                    Sql = "DELETE FROM [t_promotions] ";
                    break;
                case "online":
                    Sql = "UPDATE [t_promotions] SET linestatus=0 ";
                    break;
                case "offline":
                    Sql = "UPDATE [t_promotions] SET linestatus=-1 ";
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(Sql))
            {
                Sql += " WHERE [id] IN ({0}) AND [mid]={1} ";
                Sql = string.Format(Sql, idStr, memberId);
                return DbHelper.ExecuteNonQuery(Sql) > -1 ? true : false;
            }
            else
                return false;
        }

        #region  Method-Promotion
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditPromotion(EnPromotion model)
        {
            return Promotions.EditPromotion(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnPromotion GetPromotionInfo(string strWhere)
        {
            return Promotions.GetPromotionInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnPromotion> GetPromotionList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Promotions.GetPromotionList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnPromotion> GetPromotionList(string strWhere, out int pageCount)
        {
            return GetPromotionList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnPromotion> GetPromotionList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetPromotionList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetPromotionListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBPromotion, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletePromotion(int id)
        {
            return DeletePromotion(" where id=" + id);
        }
        ///删除对象
        public static int DeletePromotionByIdList(string idList)
        {
            return DeletePromotion(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletePromotion(string strWhere)
        {
            return DataCommon.Delete(TableName.TBPromotion, strWhere);
        }
        #endregion

        #region  Method-PromotionDef
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditPromotionDef(EnPromotionDef model)
        {
            return Promotions.EditPromotionDef(model);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnPromotionDef> GetPromotionDefList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Promotions.GetPromotionDefList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnPromotionDef> GetPromotionDefList(string strWhere, out int pageCount)
        {
            return GetPromotionDefList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnPromotionDef> GetPromotionDefList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetPromotionDefList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetPromotionDefListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBPromotionDef, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletePromotionDef(int id)
        {
            return DeletePromotionDef(" where id=" + id);
        }
        ///删除对象
        public static int DeletePromotionDefByIdList(string idList)
        {
            return DeletePromotionDef(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletePromotionDef(string strWhere)
        {
            return DataCommon.Delete(TableName.TBPromotionDef, strWhere);
        }
        #endregion
    }
}
