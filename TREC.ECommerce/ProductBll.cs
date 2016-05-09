using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREC.Entity;
using TREC.Data;
using System.Data;


namespace TREC.ECommerce
{
    /// <summary>
    /// 产品中间类
    /// </summary>
    public class ProductBll
    {

        /// <summary>
        /// 调整产品价格
        /// </summary>
        /// <param name="brandId">品牌id</param>
        /// <param name="seriesId">系列id</param>
        /// <param name="shopId">店铺id</param>
        /// <param name="pricetype">调整类型（1表示根据市场价调整销售价；0表示根据销售价调整市场价）</param>
        /// <param name="pp">百分比</param>
        /// <param name="userName">会员名</param>
        /// <returns></returns>
        public static bool SetProductPrice(int brandId, int seriesId, int shopId, int pricetype, int pp, string userId)
        {
            return ProductDb.SetProductPrice(brandId, seriesId, shopId, pricetype, pp, userId);
        }

       
           #region 获取套组合产品列表
        /// <summary>
        /// 获取套组合产品列表
        /// </summary>
        /// <param name="Where">where id= and ''</param>
        /// <returns></returns>
        public static List<GroupProductModel> QueryGroupProductListByWhere(string strWhere)
        {
            return ProductDb.QueryGroupProductListByWhere(strWhere);
        }
           #endregion

        #region 根据套组合编号获取套组合列表（复制套组合时用）

        /// <summary>
        ///根据套组合编号获取套组合列表（复制套组合时用）
        /// </summary>
        ///  <param name="uName">用户名</param>
        /// <param name="gpno">套组合编号</param>
        /// <returns></returns>
        public static DataTable GetgroupProductCountList(string uName, string gpno)
        {
            return ProductDb.GetgroupProductCountList(uName, gpno);
        }
        #endregion

        #region 获取套组合单品ids

        /// <summary>
        /// 获取套组合单品ids
        /// </summary>
        /// <param name="strWere">where条件，（id=1 and uid= ）</param>
        /// <returns></returns>
        public static List<GroupProductProperty> GetGroupProductPropertyByWhere(string strWere)
        {
            return ProductDb.GetGroupProductPropertyByWhere(strWere);
        }
            #endregion

        #region 得到实体对象
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
        public static GroupProductModel GetModel(int gpId)
        {
            return ProductDb.GetModel(gpId);
        }
        #endregion
        /// <summary>
        /// 保存发布套组合产品
        /// </summary>
        /// <param name="model">套组合产品数据</param>
        /// <param name="singleproductId">单品id</param>
        /// <param name="ShopIdStr">店铺id</param>
        /// <returns></returns>
        public static int SaveIssueGroupProductDb(GroupProductModel model, string singleproductId, string ShopIdStr)
        {
            return ProductDb.SaveIssueGroupProductDb(model, singleproductId, ShopIdStr);
         
        }

        /// <summary>
        /// 保存编辑套组合产品
        /// </summary>
        /// <param name="model">套组合产品数据</param>
        /// <param name="singleproductId">单品id</param>
        /// <param name="ShopIdStr">店铺id</param>
        /// <returns></returns>
        public static int SaveEditorGroupProductDb(GroupProductModel model, string singleproductId, string ShopIdStr)
        {
            return ProductDb.SaveEditorGroupProductDb(model,singleproductId,ShopIdStr);
        }

        /// <summary>
        /// 查询套组合产品
        /// </summary>
        /// <param name="Where">查询条件</param>
        /// <param name="productNo">产品编号</param>
        /// <param name="userName">会员名</param>
        /// <param name="Sale">销量排序(1表示降序；0表示升序)</param>
        /// <param name="Stock">库存排序(1表示降序；0表示升序)</param>
        /// <param name="Sorder">状态排序(1表示降序；0表示升序)</param>
        /// <param name="PageSize">每页显示产品数量</param>
        /// <param name="CurrentPage">当前索引页</param>
        /// <param name="Counts">总产品数</param>
        /// <returns></returns>
        public static List<GroupProductModel> QueryGroupProductListDb(string Where, string productNo, string userName, int Sale, int Stock, int Sorder, int PageSize, int CurrentPage, out int Counts)
        {
            return ProductDb.QueryGroupProductListDb(Where, productNo, userName, Sale, Stock, Sorder, PageSize, CurrentPage, out Counts);
        }

        /// <summary>
        /// 查询回收站中套组合产品
        /// </summary>
        /// <param name="Where">查询条件</param>
        /// <param name="productNo">产品编号</param>
        /// <param name="userName">会员名</param>
        /// <param name="Sale">销量排序(1表示降序；0表示升序)</param>
        /// <param name="Stock">库存排序(1表示降序；0表示升序)</param>
        /// <param name="Sorder">状态排序(1表示降序；0表示升序)</param>
        /// <param name="PageSize">每页显示产品数量</param>
        /// <param name="CurrentPage">当前索引页</param>
        /// <param name="Counts">总产品数</param>
        /// <returns></returns>
        public static List<GroupProductModel> QueryRecycleGroupProductListDb(string Where, string productNo, string userName, int Sale, int Stock, int Sorder, int PageSize, int CurrentPage, out int Counts)
        {
            return ProductDb.QueryRecycleGroupProductListDb(Where, productNo, userName, Sale, Stock, Sorder, PageSize, CurrentPage, out Counts);
        }

        /// <summary>
        /// 上线（下线、删除）套组合产品
        /// </summary>
        /// <param name="gpId">套组产品id</param>
        /// <param name="Type">类型（up表示上线；down表示下线；delete表示删除）</param>
        /// <returns></returns>
        public static bool DoGroupProduct(string gpId, string Type)
        {
            return ProductDb.DoGroupProduct(gpId, Type);
        }

        #region 保存复制单品到店铺数据
          /// <summary>
        /// 保存复制单品到店铺数据
        /// </summary>
        /// <param name="productId">单品id</param>
        /// <param name="shopId">店铺id</param>
        /// <param name="quantity">成功复制店铺数量</param>
        /// <returns></returns>
        public static bool SaveCopyProductToShopDb(string productId, string shopId, out int quantity)
        {
            return ProductDb.SaveCopyProductToShopDb(productId, shopId,out quantity);
        }
        #endregion

        /// <summary>
        /// 保存复制套组合产品到店铺数据
        /// </summary>
        /// <param name="productId">套组合产品id</param>
        /// <param name="shopId">店铺id</param>
        /// <param name="quantity">成功复制店铺数量</param>
        /// <returns></returns>
        public static bool SaveCopyGroupProductToShopDb(string productId, string shopId, out int quantity)
        {
            return ProductDb.SaveCopyGroupProductToShopDb(productId, shopId, out quantity);
        }

        /// <summary>
        /// 还原（删除）回收站中套组合产品
        /// </summary>
        /// <param name="gpId">套组合产品id</param>
        /// <param name="Type">操作类型（revert表示还原；delete表示删除）</param>
        /// <returns></returns>
        public static bool DoRecycleGroupProduct(string gpId, string Type)
        {
            return ProductDb.DoRecycleGroupProduct(gpId, Type);
        }

        /// <summary>
        /// 查询编辑套组合产品时XML数据
        /// </summary>
        /// <param name="gpId">套组合产品id</param>
        /// <returns></returns>
        public static string QueryEditorGroupProductDbXml(int gpId)
        {
            return ProductDb.QueryEditorGroupProductDbXml(gpId);
        }

        /// <summary>
        /// 查询复制同类套组合产品数据
        /// </summary>
        /// <param name="productNo">套组合产品编号</param>
        /// <param name="gpId">套组合产品属性id</param>
        /// <returns></returns>
        public static string QueryCopyGroupProdcutDbByNo(string productNo )
        {
            return ProductDb.QueryCopyGroupProdcutDbByNo(productNo);
        }
     
     


    }
}