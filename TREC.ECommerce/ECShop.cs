using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TREC.Entity;
using TREC.Data;
using TRECommon;


namespace TREC.ECommerce
{
    public class ECShop
    {

        public static int ExitShopTitle(string title)
        {
            return Shops.ExitShopTitle(title);
        }

        public static EnWebShop GetWebShopInfo(string strWhere)
        {
            return Shops.GetWebShopInfo(strWhere);
        }

        public static int UpConFilePath(string con, int id)
        {
            return DataCommon.UpdateValue(TableName.TBShop, "descript", con, " where id=" + id);
        }

        /// <summary>
        /// 更新上/下线对象/审核通过不过
        /// rafer
        /// 5-17
        /// </summary>
        /// <param name="idList"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int ModifyShopByID(string idList, string values, string files)
        {
            return DataCommon.UpdateValue(TableName.TBShop, files, values, " where ID in (" + idList + ")");
        }

        public static List<EnWebShop> GetWebShopList(int PageIndex, int PageSize, string strWhere,string sortkey,string ordertype, out int pageCount)
        {
            return Shops.GetWebShopList(PageIndex, PageSize, strWhere, sortkey, ordertype, out pageCount);

        }

        public static List<EnWebShopBrand> GetWebShopBrandList(int PageIndex, int PageSize, string strWhere, string sortkey,string ordertype, out int pageCount)
        {
            return Shops.GetWebShopBrandList(PageIndex, PageSize, strWhere, sortkey, ordertype, out pageCount);
        }

        public static List<EnSearchItem> GetSearchItem()
        {
            List<EnSearchItem> list = new List<EnSearchItem>();
            List<EnSearchItem> itemList = (List<EnSearchItem>)DataCache.GetCache(CacheKey.ShopSearchItemList);

            if (itemList == null)
            {
                itemList = Shops.GetShopSearchItem();
                DataCache.SetCache(CacheKey.ShopSearchItemList, itemList);
            }


            foreach (EnSearchItem item in itemList)
            {
                if (item.type == "brand" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchBrand != "" && ECommon.QuerySearchBrand.Split('_').Contains(item.value))
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
                if (item.type == "style" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchStyle != "" && ECommon.QuerySearchStyle.Split('_').Contains(item.value))
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
                if (item.type == "material" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchMaterial != "" && ECommon.QuerySearchMaterial.Split('_').Contains(item.value))
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
                if (item.type == "spread" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchSpread != "" && ECommon.QuerySearchSpread.Split('_').Contains(item.value))
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
                if (item.type == "staffsize" && !string.IsNullOrEmpty(item.value))
                {
                    if (ECommon.QuerySearchStaffsize != "" && ECommon.QuerySearchStaffsize.Split('_').Contains(item.value))
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


        #region  Method-ShopBrand

        public static List<EnShopBrand> GetReaderShopBrandList(string strWhere)
        {
            return Shops.GetShopBrandList(strWhere);
        }

        public static List<Hashtable> GetReaderShopBrandList(int shopid)
        {
            return Shops.GetShopBrandList(shopid);
        }

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditShopBrand(List<EnShopBrand> list)
        {
            return Shops.EditShopBrand(list);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnShopBrand> GetShopBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Shops.GetShopBrandList(PageIndex, PageSize, strWhere, out pageCount);
        }
          /// 获取品牌推荐店铺
        /// </summary>
        /// <param name="brandTitle"></param>
        /// <returns></returns>
        public static DataSet GetBrandShop(string brandTitle)
        {
            return Shops.GetBrandShop(brandTitle);
        }

         /// <summary>
        /// 获取厂商信息
        /// </summary>
        /// <param name="brandTitle"></param>
        /// <returns></returns>
        public static DataSet getBrandCompany(string brandTitle)
        {
            return Shops.getBrandCompany(brandTitle);
        }
        ///获取数据列表
        public static List<EnShopBrand> GetShopBrandList(string strWhere, out int pageCount)
        {
            return GetShopBrandList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnShopBrand> GetShopBrandList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetShopBrandList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetShopBrandListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBShopBrand, PageIndex, PageSize, strWhere, "shopid", 1, out pageCount);
        }

        ///删除对象
        public static int DeletEnShopBrandByShopId(int shopid)
        {
            return DeletEnShopBrand(" where shopid=" + shopid);
        }
        ///删除对象
        public static int DeletEnShopBrandByIdListByShopId(string idList)
        {
            return DeletEnShopBrand(" where shopid in (" + idList + ")");
        }

        ///删除对象
        public static int DeletEnShopBrandByBrandId(int brandid)
        {
            return DeletEnShopBrand(" where brandid=" + brandid);
        }
        ///删除对象
        public static int DeletEnShopBrandByIdListByBrandId(string idList)
        {
            return DeletEnShopBrand(" where brandid in (" + idList + ")");
        }



        ///删除对象
        public static int DeletEnShopBrand(string strWhere)
        {
            return DataCommon.Delete(TableName.TBShopBrand, strWhere);
        }
        #endregion


        #region  Method-Shop
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditShop(EnShop model)
        {
            return Shops.EditShop(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnShop GetShopInfo(string strWhere)
        {
            return Shops.GetShopInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnShop> GetShopList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Shops.GetShopList(PageIndex, PageSize, strWhere, out pageCount);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnShop> GetRecycleShopList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Shops.GetRecycleShopList(PageIndex, PageSize, strWhere, out pageCount);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnShop> GetShopList(int PageIndex, int PageSize, string strWhere, out int pageCount, int marketid)
        {
            return Shops.GetShopList(PageIndex, PageSize, strWhere, out pageCount, marketid);
        }

        ///获取数据列表
        public static List<EnShop> GetShopList(string strWhere, out int pageCount)
        {
            return GetShopList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnShop> GetShopList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetShopList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetShopListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBShop, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletEnShop(int id)
        {
            return DeletEnShop(" where id=" + id);
        }
        ///删除对象
        public static int DeletEnShopByIdList(string idList)
        {
            return DeletEnShop(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletEnShop(string strWhere)
        {
            return DataCommon.Delete(TableName.TBShop, strWhere);
        }

        /// <summary>
        /// 处理店铺数据
        /// </summary>
        /// <param name="shopId">店铺id</param>
        /// <param name="Type">操作类型(up表示上线申请；down表示下线操作；delete表示将店铺删除至回收站中)</param>
        /// <returns></returns>
        public static bool handleShopDb(string shopId, string Type)
        {
            string Sql = string.Empty;
            if (Type != "delete")
            {
                Sql = "UPDATE [t_shop] SET [linestatus] = ";
                if (Type == "down")
                    Sql += " -99 ";
                else
                    Sql += " 0 ";
                Sql += " WHERE [id] IN ({0}) ";
            }
            else
            {
                Sql = @"INSERT INTO [t_shoprecycle] (
                    [id],
                    [mid],
                    [title],
                    [letter],
                    [groupid],
                    [attribute],
                    [industry],
                    [productcategory],
                    [vip],
                    [areacode],
                    [address],
                    [mapapi],
                    [staffsize],
                    [regyear],
                    [regcity],
                    [buy],
                    [sell],
                    [linkman],
                    [phone],
                    [mphone],
                    [fax],
                    [email],
                    [postcode],
                    [homepage],
                    [domain],
                    [domainip],
                    [icp],
                    [surface],
                    [logo],
                    [thumb],
                    [bannel],
                    [desimage],
                    [descript],
                    [keywords],
                    [template],
                    [hits],
                    [sort],
                    [marketid],
                    [cid],
                    [ctype],
                    [createmid],
                    [lastedid],
                    [lastedittime],
                    [auditstatus],
                    [linestatus],
                    [qq],
                    [sortstr] ,
                    [IsPay],
                    [ShopContact],
                    [FirstClerkMobile],
                    [SecondClerk],
                    [SecondClerkMobile]
                ) 
                SELECT  [id],
                        [mid],
                        [title],
                        [letter],
                        [groupid],
                        [attribute],
                        [industry],
                        [productcategory],
                        [vip],
                        [areacode],
                        [address],
                        [mapapi],
                        [staffsize],
                        [regyear],
                        [regcity],
                        [buy],
                        [sell],
                        [linkman],
                        [phone],
                        [mphone],
                        [fax],
                        [email],
                        [postcode],
                        [homepage],
                        [domain],
                        [domainip],
                        [icp],
                        [surface],
                        [logo],
                        [thumb],
                        [bannel],
                        [desimage],
                        [descript],
                        [keywords],
                        [template],
                        [hits],
                        [sort],
                        [marketid],
                        [cid],
                        [ctype],
                        [createmid],
                        [lastedid],
                        [lastedittime],
                        [auditstatus],
                        [linestatus],
                        [qq],
                        [sortstr] ,
                        [IsPay],
                        [ShopContact],
                        [FirstClerkMobile],
                        [SecondClerk],
                        [SecondClerkMobile] FROM [t_shop] WHERE [id] IN ({0});
                 IF @@ERROR = 0
                    BEGIN
                        DELETE FROM [t_shop] WHERE [id] IN ({0});
                    END
               ";
            }
            Sql = string.Format(Sql, shopId);
            return DbHelper.ExecuteNonQuery(Sql) > -1 ? true : false;
        }

        /// <summary>
        /// 处理店铺数据
        /// </summary>
        /// <param name="shopId">店铺id</param>
        /// <param name="Type">操作类型(delete表示删除；revert表示还原)</param>
        /// <returns></returns>
        public static bool handleRecycleShopDb(string shopId, string Type)
        {
            string Sql = string.Empty;
            if (Type == "revert")
            {
                Sql = @"
                SET IDENTITY_INSERT [dbo].[t_shop] ON;
                INSERT INTO [t_shop] (
                    [id],
                    [mid],
                    [title],
                    [letter],
                    [groupid],
                    [attribute],
                    [industry],
                    [productcategory],
                    [vip],
                    [areacode],
                    [address],
                    [mapapi],
                    [staffsize],
                    [regyear],
                    [regcity],
                    [buy],
                    [sell],
                    [linkman],
                    [phone],
                    [mphone],
                    [fax],
                    [email],
                    [postcode],
                    [homepage],
                    [domain],
                    [domainip],
                    [icp],
                    [surface],
                    [logo],
                    [thumb],
                    [bannel],
                    [desimage],
                    [descript],
                    [keywords],
                    [template],
                    [hits],
                    [sort],
                    [marketid],
                    [cid],
                    [ctype],
                    [createmid],
                    [lastedid],
                    [lastedittime],
                    [auditstatus],
                    [linestatus],
                    [qq],
                    [sortstr] ,
                    [IsPay],
                    [ShopContact],
                    [FirstClerkMobile],
                    [SecondClerk],
                    [SecondClerkMobile]
                ) 
                SELECT  [id],
                        [mid],
                        [title],
                        [letter],
                        [groupid],
                        [attribute],
                        [industry],
                        [productcategory],
                        [vip],
                        [areacode],
                        [address],
                        [mapapi],
                        [staffsize],
                        [regyear],
                        [regcity],
                        [buy],
                        [sell],
                        [linkman],
                        [phone],
                        [mphone],
                        [fax],
                        [email],
                        [postcode],
                        [homepage],
                        [domain],
                        [domainip],
                        [icp],
                        [surface],
                        [logo],
                        [thumb],
                        [bannel],
                        [desimage],
                        [descript],
                        [keywords],
                        [template],
                        [hits],
                        [sort],
                        [marketid],
                        [cid],
                        [ctype],
                        [createmid],
                        [lastedid],
                        [lastedittime],
                        [auditstatus],
                        [linestatus],
                        [qq],
                        [sortstr] ,
                        [IsPay],
                        [ShopContact],
                        [FirstClerkMobile],
                        [SecondClerk],
                        [SecondClerkMobile] FROM [t_shoprecycle] WHERE [id] IN ({0});
                 IF @@ERROR = 0
                    BEGIN
                        DELETE FROM [t_shoprecycle] WHERE [id] IN ({0});
                    END
                 SET IDENTITY_INSERT [dbo].[t_shop] OFF;
               ";
            }
            else
            {
                Sql = @"
                    DELETE FROM [t_shoprecycle] WHERE [id] IN ({0});
                    IF @@ERROR=0
                       BEGIN
                          DELETE FROM [t_shopbrand] WHERE [shopid] IN ({0});
                       END
                ";
            }
            Sql = string.Format(Sql, shopId);

            return DbHelper.ExecuteNonQuery(Sql) > -1 ? true : false;
        }
        #endregion

        #region  Method-ShopGroup
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditShopGroup(EnShopGroup model)
        {
            return Shops.EditShopGroup(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnShopGroup GetShopGroupInfo(string strWhere)
        {
            return Shops.GetShopGroupInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnShopGroup> GetShopGroupList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Shops.GetShopGroupList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnShopGroup> GetShopGroupList(string strWhere, out int pageCount)
        {
            return GetShopGroupList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnShopGroup> GetShopGroupList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetShopGroupList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetShopGroupListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBShopGroup, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        ///删除对象
        public static int DeletEnShopGroup(int id)
        {
            return DeletEnShopGroup(" where id=" + id);
        }
        ///删除对象
        public static int DeletEnShopGroupByIdList(string idList)
        {
            return DeletEnShopGroup(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeletEnShopGroup(string strWhere)
        {
            return DataCommon.Delete(TableName.TBShopGroup, strWhere);
        }
        #endregion
    }
}
