using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TREC.Entity;
using TREC.Data;
using TRECommon;


namespace TREC.ECommerce
{
    public class ECBrand
    {

        public static int ExitBrandTitleLetter(string letter)
        {
            return Brands.ExitBrandTitleLetter(letter);
        }

        public static int ExitBrandTitle(string title)
        {
            return Brands.ExitBrandTitle(title);
        }

        public static int ExitBrandsTitle(string title)
        {
            return Brands.ExitBrandsTitle(title);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnAllBrand> GetWebAllBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Brands.GetAllBrandList(PageIndex, PageSize, strWhere, out pageCount);

        }
        
        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="tableName">表</param>
        /// <param name="field">字段</param>
        /// <param name="strWhere">条件  where ''</param>
        /// <param name="sort">排序</param>
        /// <returns></returns>
        public static DataSet GetDataSet(string tableName, string field, string strWhere, string sort)
        {
            return DataCommon.GetDataSet(tableName, field, strWhere, sort);
        }
        /// <summary>
        /// 通过字母获得品牌
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public static List<EnBrand> GetBrandByLetter(string strWhere)
        {
            return Brands.GetBrandByLetter(strWhere);
        }

        public static DataTable GetBrandLetterList()
        {
            object obj = DataCache.GetCache(CacheKey.BrandLetter);
            if (obj != null)
            {
                return (DataTable)obj;
            }
            else
            {
                DataTable brandLetterDt = DataCommon.GetDataTable(TableName.TBBrand, "id,title,substring(letter,1,1) as letter,companyid,material,style,color", " where auditstatus=1", "");
                if (brandLetterDt.Rows.Count > 0)
                {
                    TRECommon.DataCache.SetCache(CacheKey.BrandLetter, brandLetterDt);
                }
                return brandLetterDt;
            }
        }

        public static DataTable GetMarketBrandLetterList(int marketid)
        {
            DataTable brandLetterDt = DataCommon.GetDataTable(TableName.TBBrand, "id,title,substring(letter,1,1) as letter,companyid,material,style,color", " where auditstatus=1 and id in (select brandid from t_shopbrand where shopid in (select shopid from t_marketstoreyshop where marketid=" + marketid + "))", "");
            return brandLetterDt;
        }

        public static DataTable GetMarketBrandLetterList(string field, string strWhere)
        {
            DataTable brandLetterDt = DataCommon.GetDataTable(TableName.TBBrand, field, strWhere, "");
            return brandLetterDt;
        }

        public static int UpConFilePath(string con, int id)
        {
            return DataCommon.UpdateValue(TableName.TBBrand, "descript", con, " where id=" + id);
        }

        public static int UpBrandsConFilePath(string con, int id)
        {
            return DataCommon.UpdateValue(TableName.TBBrands, "descript", con, " where id=" + id);
        }

          /// <summary>
        /// 有求必应
        /// </summary>
        /// <returns></returns>
        public static DataSet BiYing(string pageindex)
        {
            return DataCommon.BiYing(pageindex);
        }

        #region  Method-Brand
        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditBrand(EnBrand model)
        {
            if (model != null)
            {
                model.title = model.title.Trim().Replace(" ", "");
            }
            return Brands.EditBrand(model);
        }

         /// <summary>
        /// 获取品牌数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static DataTable getBrandList(string where)
        {
            return Brands.getBrandList(where);
        }
        /// <summary>
        /// 得到实体
        /// </summary>
        /// <param name="strWhere">where id=1 and ....</param>
        /// <returns></returns>
        public static EnBrand GetBrandInfo(string strWhere)
        {
            return Brands.GetBrandInfo(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnBrand> GetBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Brands.GetBrandList(PageIndex, PageSize, strWhere, out pageCount);
        }
        #region 获取色板列表
         /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<t_colorswatch> GetColorSwtchList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Brands.GetColorSwatchList(PageIndex, PageSize, strWhere, out pageCount);
        }
        #endregion


        #region 获取色板列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<t_colorswatch> GetColorSwtchRecycleList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Brands.GetColorSwtchRecycleList(PageIndex, PageSize, strWhere, out pageCount);
        }
        #endregion

        #region 还原回收站中色板数据
          /// <summary>
        /// 还原回收站中色板数据
        /// </summary>
        /// <param name="swId">色板id</param>        
        /// <returns></returns>
        public static int RevertColorSwatchRecycle(string swId )
        {
            return ColorSwatchDb.RevertColorSwatchRecycle(swId);
        }
        #endregion

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnBrand> GetRecycleBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Brands.GetRecycleBrandList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnBrand> GetBrandList(string strWhere, out int pageCount)
        {
            return GetBrandList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnBrand> GetBrandList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetBrandList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetBrandListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBBrand, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnWebBrand> GetWebBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Brands.GetWebBrandList(PageIndex, PageSize, strWhere, out pageCount);

        }
         /// <summary>
        /// 51团购
        /// </summary>
        /// <returns></returns>
        public static DataSet Brand51List()
        {
          return  DataCommon.Brand51List();
        }
         /// <summary>
        /// 已确认订单 意向报名
        /// </summary>
        /// <param name="brandid"></param>
        /// <returns></returns>
        public static DataSet EnterUser(string brandid)
        {
            return DataCommon.EnterUser(brandid);
        }
         /// <summary>
        /// 团购折数计算
        /// </summary>
        /// <param name="brandid"></param>
        /// <returns></returns>
        public static string getEnterSel(string brandid)
        {
            return DataCommon.getEnterSel(brandid);
        }
        public static string GetBrandIdListByCompany(string companyId)
        {
            List<EnBrand> list = GetBrandList(" companyid=" + companyId);
            StringBuilder sb = new StringBuilder();
            foreach (EnBrand b in list)
            {
                sb.Append(b.id + ",");
            }

            return sb.ToString().Length > 0 && sb.ToString().EndsWith(",") ? sb.ToString().Substring(0, sb.ToString().Length - 1) : sb.ToString();
        }

        public static string GetBrandIdListByDealer(string dealerid)
        {
            List<EnAppBrand> list = ECAppBrand.GetAppBrandList(" dealerid=" + dealerid);
            StringBuilder sb = new StringBuilder();
            foreach (EnAppBrand b in list)
            {
                sb.Append(b.brandid + ",");
            }

            return sb.ToString().Length > 0 && sb.ToString().EndsWith(",") ? sb.ToString().Substring(0, sb.ToString().Length - 1) : sb.ToString();
        }


        ///删除对象
        public static int DeleteBrand(int id)
        {
            return DeleteBrand(" where id=" + id);
        }
        ///删除对象
        public static int DeleteBrandByIdList(string idList)
        {
            return DeleteBrand(" where id in (" + idList + ")");
        }

        /// <summary>
        /// 更新上/下线对象
        /// rafer
        /// 5-17
        /// </summary>
        /// <param name="idList"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int ModifyBrandlinestatusByID(string idList, int values)
        {
            return DataCommon.UpdateValue(TableName.TBBrand, "linestatus", values.ToString(), " where ID in (" + idList + ")");
        }

        /// <summary>
        /// 更新上/下线对象/审核通过不过
        /// rafer
        /// 5-17
        /// </summary>
        /// <param name="idList"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int ModifyBrandByID(string idList, string values, string files)
        {
            return DataCommon.UpdateValue(TableName.TBBrand, files, values, " where ID in (" + idList + ")");
        }

        ///删除对象
        public static int DeleteBrand(string strWhere)
        {
            return DataCommon.Delete(TableName.TBBrand, strWhere);
        }

        /// <summary>
        /// 将品牌删除到品牌回收站表中
        /// </summary>
        /// <param name="brandId">品牌id</param>
        /// <returns></returns>
        public static bool DeleteBrandToRecycle(string brandId)
        {
            string Sql = string.Format(@"
                INSERT INTO [t_brandrecycle] ([id]
           ,[companyid]
           ,[title]
           ,[letter]
           ,[groupid]
           ,[attribute]
           ,[productcategory]
           ,[homepage]
           ,[productcount]
           ,[spread]
           ,[material]
           ,[style]
           ,[color]
           ,[surface]
           ,[logo]
           ,[thumb]
           ,[bannel]
           ,[desimage]
           ,[descript]
           ,[keywords]
           ,[template]
           ,[hits]
           ,[sort]
           ,[createmid]
           ,[lasteditid]
           ,[lastedittime]
           ,[auditstatus]
           ,[linestatus]
           ,[Createtime]
           ,[sortstr]
           ,[IsPay]) SELECT [id]
           ,[companyid]
           ,[title]
           ,[letter]
           ,[groupid]
           ,[attribute]
           ,[productcategory]
           ,[homepage]
           ,[productcount]
           ,[spread]
           ,[material]
           ,[style]
           ,[color]
           ,[surface]
           ,[logo]
           ,[thumb]
           ,[bannel]
           ,[desimage]
           ,[descript]
           ,[keywords]
           ,[template]
           ,[hits]
           ,[sort]
           ,[createmid]
           ,[lasteditid]
           ,[lastedittime]
           ,[auditstatus]
           ,[linestatus]
           ,[Createtime]
           ,[sortstr]
           ,[IsPay] FROM [t_brand] WHERE [id] IN ({0});
            IF @@ERROR = 0
               BEGIN
                  DELETE FROM [t_brand] WHERE [id] IN ({0}) AND [id] IN (SELECT [id] FROM [t_brandrecycle])
               END;
            ", brandId);
            try
            {
                return DbHelper.ExecuteNonQuery(Sql) > -1 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        /// <summary>
        /// 删除回收站品牌数据
        /// </summary>
        /// <param name="brandId">品牌ID(存在多个)</param>
        /// <returns></returns>
        public static bool delBrandRecycle(string brandId)
        {
            string Sql = "DELETE FROM t_brandrecycle WHERE id IN (" + brandId + ") ";
            try
            {
                return DbHelper.ExecuteNonQuery(Sql) > -1 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        /// <summary>
        /// 将品牌回收站中品牌还原到品牌数据表中
        /// </summary>
        /// <param name="brandId">品牌id</param>
        /// <returns></returns>
        public static bool revertBrandRecycle(string brandId)
        {
            string Sql = string.Format(@"
               SET IDENTITY_INSERT [dbo].[t_brand] ON;
               INSERT INTO [t_brand] ([id]
               ,[companyid]
               ,[title]
               ,[letter]
               ,[groupid]
               ,[attribute]
               ,[productcategory]
               ,[homepage]
               ,[productcount]
               ,[spread]
               ,[material]
               ,[style]
               ,[color]
               ,[surface]
               ,[logo]
               ,[thumb]
               ,[bannel]
               ,[desimage]
               ,[descript]
               ,[keywords]
               ,[template]
               ,[hits]
               ,[sort]
               ,[createmid]
               ,[lasteditid]
               ,[lastedittime]
               ,[auditstatus]
               ,[linestatus]
               ,[Createtime]
               ,[sortstr]
               ,[IsPay]) SELECT [id]
               ,[companyid]
               ,[title]
               ,[letter]
               ,[groupid]
               ,[attribute]
               ,[productcategory]
               ,[homepage]
               ,[productcount]
               ,[spread]
               ,[material]
               ,[style]
               ,[color]
               ,[surface]
               ,[logo]
               ,[thumb]
               ,[bannel]
               ,[desimage]
               ,[descript]
               ,[keywords]
               ,[template]
               ,[hits]
               ,[sort]
               ,[createmid]
               ,[lasteditid]
               ,[lastedittime]
               ,[auditstatus]
               ,[linestatus]
               ,[Createtime]
               ,[sortstr]
               ,[IsPay] FROM [t_brandrecycle] WHERE [id] IN ({0});
               IF @@ERROR=0
                  Begin
                    DELETE FROM [t_brandrecycle] WHERE [id] IN ({0});
                  End
               SET IDENTITY_INSERT [dbo].[t_brand] OFF;
            ", brandId);
            try
            {
                return DbHelper.ExecuteNonQuery(Sql) > -1 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        /// <summary>
        /// 验证同一品牌下系列是否同名
        /// </summary>
        /// <param name="SeriesId">系列id</param>
        /// <param name="SeriesName">系列名称</param>
        /// <param name="brandId">品牌id</param>
        /// <returns></returns>
        public static bool checkBrandSeriesNameIsExists(int SeriesId, string SeriesName, int brandId)
        {
            string andWhere =(SeriesId != 0 ? "" : (" AND [id] <> "+SeriesId.ToString()));
            string Sql = string.Format(@"
               SELECT 1 FROM t_brands WHERE [title]='{1}' AND [brandid]={2} {0}
            ", andWhere, SeriesName, brandId);
            return DbHelper.ExecuteNonQuery(Sql) > -1 ? true : false;
        }

        /// <summary>
        /// 保存色板数据
        /// </summary>
        /// <param name="bSeriesId">系列id</param>
        /// <param name="SwatchName">色板名称</param>
        /// <param name="CategroyId">分类id</param>
        /// <param name="Picture">图片</param>
        /// <param name="CreateId">创建人id</param>
        /// <param name="csid">色板id</param>
        /// <returns></returns>
        public static bool saveColorSwatchDb(int bSeriesId, string SwatchName, string CategroyId, string Picture, string CreateId, int csid)
        {
            string Sql = string.Empty;
            if (csid==0)
            {
                Sql = "INSERT INTO [t_colorswatch] (SwatchName,CategroyId,Picture,CreateId,bSeriesId) VALUES ('" + SwatchName + "'," + CategroyId + ",'" + Picture + "'," + CreateId + "," + bSeriesId + ")";
            }
            else
            {
                Sql = "UPDATE [t_colorswatch] SET SwatchName='" + SwatchName + "',CategroyId=" + CategroyId + ",Picture='" + Picture + "' WHERE CreateId=" + CreateId + " AND csid= " + csid.ToString();
            }
            return DbHelper.ExecuteNonQuery(Sql) > -1 ? true : false;
        }

        /// <summary>
        /// 保存色板数据
        /// </summary>
        /// <param name="bSeriesId">系列id</param>
        /// <param name="SwatchName">色板名称</param>
        /// <param name="CategroyId">分类id</param>
        /// <param name="Picture">图片</param>
        /// <param name="CreateId">创建人id</param>
        /// <param name="csid">色板id</param>
        /// <returns></returns>
        public static bool saveColorSwatchDb(t_colorswatch model)
        {
            string Sql = string.Empty;
            if (model.csid == 0)
            {
                Sql = "INSERT INTO [t_colorswatch] (SwatchName,CategroyId,Picture,CreateId,bSeriesId,brandid) VALUES ('" + model.SwatchName + "'," + model.CategroyId + ",'" + model.Picture + "'," + model.CreateId + "," + model.bSeriesId + ","+model.brandid+")";
            }
            else
            {
                Sql = "UPDATE [t_colorswatch] SET SwatchName='" + model.SwatchName + "',CategroyId=" + model.CategroyId + ",Picture='" + model.Picture + "',brandid="+model.brandid+" WHERE CreateId=" + model.CreateId + " AND csid= " + model.csid;
            }
            return DbHelper.ExecuteNonQuery(Sql) > -1 ? true : false;
        }

        /// <summary>
        /// 获得最大色板id
        /// </summary>
        /// <param name="CreateId">创建人id</param>
        /// <returns></returns>
        public static int GetMaxColorSwatchId(string CreateId)
        {
            string Sql = "SELECT MAX(csid) FROM [t_colorswatch] WHERE CreateId = " + CreateId;
            return (int)DbHelper.ExecuteScalar(Sql);
        }

        /// <summary>
        /// 获得系列下面的色板
        /// </summary>
        /// <param name="CreateId">创建人id</param>
        /// <param name="bSeriesId">系列id</param>
        /// <returns></returns>
        public static Dictionary<int, string> GetSwatchName(string CreateId, int bSeriesId)
        {
            Dictionary<int, string> SwatchDic = new Dictionary<int, string>();
            string Sql = "SELECT [csid],[SwatchName] FROM [t_colorswatch] WHERE [CreateId]=" + CreateId;
            if (0 < bSeriesId)
                Sql += " AND bSeriesId = " + bSeriesId.ToString();
            using (IDataReader sdr = DbHelper.ExecuteReader(Sql))
            {
                while (sdr.Read())
                {
                    SwatchDic.Add(int.Parse(sdr[0].ToString()), sdr[1].ToString());
                }
            }
            return SwatchDic;
        }

        /// <summary>
        /// 修改色板对应的系列id
        /// </summary>
        /// <param name="SeriesId">系列id</param>
        /// <param name="memberId">创建人id</param>
        /// <returns></returns>
        public static bool updateSwatchSeriesId(int SeriesId, string memberId)
        {
            string Sql = "UPDATE [t_colorswatch] SET [bSeriesId]=" + SeriesId + " WHERE CreateId = " + memberId + " AND [bSeriesId] = 0 ";
            return DbHelper.ExecuteNonQuery(Sql) > -1 ? true : false;
        }

        /// <summary>
        /// 将品牌系列删除至回收站中
        /// </summary>
        /// <param name="seriesId">系列id</param>
        /// <param name="memberId">创建人id</param>
        /// <returns></returns>
        public static bool deleteBrandSeriesToRecycle(string seriesId, string memberId)
        {
            string Sql = @"
                INSERT INTO t_brandsrecycle ([id],
	            [brandid],
	            [title],
	            [letter],
	            [attribute],
	            [productcount],
	            [spread],
	            [material],
	            [style],
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
	            [createmid],
	            [lasteditid],
	            [lastedittime],
	            [auditstatus],
	            [linestatus],
	            [color])
                SELECT [id],
	            [brandid],
	            [title],
	            [letter],
	            [attribute],
	            [productcount],
	            [spread],
	            [material],
	            [style],
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
	            [createmid],
	            [lasteditid],
	            [lastedittime],
	            [auditstatus],
	            [linestatus],
	            [color] FROM [t_brands] WHERE [id] IN ({0}) AND createmid={1} ;
                IF @@ERROR=0
                  Begin
                    DELETE FROM [t_brands] WHERE [id] IN ({0}) AND createmid={1};
                  End
            ";
            Sql = string.Format(Sql, seriesId, memberId);
            return DbHelper.ExecuteNonQuery(Sql) > -1 ? true : false;
        }

        /// <summary>
        /// 删除品牌系列回收站中数据
        /// </summary>
        /// <param name="recycleId">系列id</param>
        /// <returns></returns>
        public static bool delBrandSeriesRecycleDb(string recycleId)
        {
            string Sql = @"
                   DELETE FROM [t_brandsrecycle] WHERE [id] IN ({0});
                   IF @@ERROR=0
                      Begin
                        DELETE FROM [t_colorswatch] WHERE [bSeriesId] IN ({0});
                      End
            ";
            Sql = string.Format(Sql, recycleId);
            return DbHelper.ExecuteNonQuery(Sql) > -1 ? true : false;
        }

        /// <summary>
        /// 将系列回收站中数据还原到系列数据表中
        /// </summary>
        /// <param name="recycleId">系列id</param>
        /// <returns></returns>
        public static bool revertBrandSeriesRecycle(string recycleId, string memberId)
        {
            string Sql = @"
                SET IDENTITY_INSERT [t_brands] ON;
                INSERT INTO [t_brands] ([id],
	            [brandid],
	            [title],
	            [letter],
	            [attribute],
	            [productcount],
	            [spread],
	            [material],
	            [style],
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
	            [createmid],
	            [lasteditid],
	            [lastedittime],
	            [auditstatus],
	            [linestatus],
	            [color])
                SELECT [id],
	            [brandid],
	            [title],
	            [letter],
	            [attribute],
	            [productcount],
	            [spread],
	            [material],
	            [style],
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
	            [createmid],
	            [lasteditid],
	            [lastedittime],
	            [auditstatus],
	            [linestatus],
	            [color] FROM [t_brandsrecycle] WHERE [id] IN ({0}) AND createmid={1} ;
                IF @@ERROR=0
                  Begin
                    DELETE FROM [t_brandsrecycle] WHERE [id] IN ({0}) AND createmid={1};
                  End
                SET IDENTITY_INSERT [t_brands] OFF;
            ";
            Sql = string.Format(Sql, recycleId, memberId);
            return DbHelper.ExecuteNonQuery(Sql) > -1 ? true : false;
        }

        /// <summary>
        /// 查询店铺数据
        /// </summary>
        /// <param name="pcode">省份编码</param>
        /// <param name="ccode">城市编码</param>
        /// <param name="dcode">地区编码</param>
        /// <returns></returns>
        public static List<EnMarket> queryShopMarketDb(string pcode, string ccode, string dcode)
        {
            string Where = " where a.areacode is not null and a.areacode <> '' ";
            if (!string.IsNullOrEmpty(dcode))
                Where += " and a.areacode = '" + dcode + "' ";
            else
            {
                if (!string.IsNullOrEmpty(ccode))
                    Where += " and b.parentcode = '" + ccode + "' ";
                else
                    Where += " and b.parentcode in (select areacode from t_area where parentcode = '" + pcode + "' ) ";
            }
            string Sql = "select a.id,a.title,a.address from t_market a join t_area b on a.areacode=b.areacode " + Where;
            //Dictionary<int, string> marketDict = new Dictionary<int, string>();
            List<EnMarket> marketList = new List<EnMarket>();
            EnMarket model = null;
            using (IDataReader sdr = DbHelper.ExecuteReader(Sql))
            {
                while (sdr.Read())
                {
                     model = new EnMarket();
                    model.id=int.Parse(sdr[0].ToString());
                    model.title = sdr[1].ToString();
                    if(sdr[2]!=null && sdr[2].ToString()!="")
                    {
                        model.address = sdr[2].ToString();
                    }
                    else
                    {
                        model.address = "";
                    }
                    marketList.Add(model);
                    model = null;
                    //marketDict.Add(int.Parse(sdr[0].ToString()), sdr[1].ToString());
                }
            }
            return marketList;
            //string Where = " where a.areacode is not null and a.areacode <> '' ";
            //if (!string.IsNullOrEmpty(dcode))
            //    Where += " and a.areacode = '" + dcode + "' ";
            //else
            //{
            //    if (!string.IsNullOrEmpty(ccode))
            //        Where += " and b.parentcode = '" + ccode + "' ";
            //    else
            //        Where += " and b.parentcode in (select areacode from t_area where parentcode = '"+pcode+"' ) ";
            //}
            //string Sql = "select a.id,a.title from t_market a join t_area b on a.areacode=b.areacode " + Where;
            //Dictionary<int, string> marketDict = new Dictionary<int, string>();
            //using (IDataReader sdr = DbHelper.ExecuteReader(Sql))
            //{
            //    while (sdr.Read())
            //    {
            //        marketDict.Add(int.Parse(sdr[0].ToString()), sdr[1].ToString());
            //    }
            //}

           
        }
        #endregion

        #region 后台列表查询
        /// <summary>
        /// 后台Brand列表查询
        /// </summary>
        public static List<EnBrand> GetAdminBrandList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Brands.GetAdminBrandList(PageIndex, PageSize, strWhere, out pageCount);
        }
        #endregion

        #region  Method-Brands
        /// <summary>
        /// 更新对像
        /// Modify:rafer
        /// Msg   :新增T_Brands同时，修改对应的T_Brand(改为sql—触发器执行。。所以注释了)
        /// Date  :2012-5-22
        /// </summary>
        public static int EditBrands(EnBrands model)
        {
            int _ref = 0;
            //bool IsModify = false;
            //if (model.id == 0)
            //{
            //    IsModify = true;
            //}
            _ref = Brands.EditBrands(model);
            //if (_ref > 0 && IsModify)
            //{
            //    EnBrand _enb = GetBrandInfo(" where id=" + model.brandid);
            //    if (_enb != null)
            //    {
            //        _enb.material = model.material;
            //        _enb.style = model.style;
            //        _enb.color = model.color;
            //    }
            //}
            return _ref;
        }


         /// <summary>
        /// 首页商家品牌展示
        /// </summary>
        /// <returns></returns>
        public static DataSet Brandindex()
        {
            return Brands.Brandindex();
        }
         /// <summary>
        /// 高端品牌
        /// </summary>
        /// <returns></returns>
        public static DataTable BrandAdver()
        {
            return Brands.BrandAdver();
        }
         /// <summary>
        /// 卖场广告
        /// </summary>
        /// <returns></returns>
        public static DataTable brandAdverMarket()
        {
            return Brands.brandAdverMarket();
        }
           /// <summary>
        /// 通过父节点获取广告位
        /// </summary>
        /// <param name="top"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static DataTable getBrandByPid(string top, string pid)
        {
            return Brands.getBrandByPid(top, pid);
        }
          /// <summary>
        /// 首页品牌推荐
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public static DataTable BrandIndextop(int top, string where, string orderby)
        {
            return Brands.BrandIndextop(top, where, orderby);
        }
        /// <summary>
        /// 得到一个对象实体
        /// Modify:rafer 处理异常
        /// </summary>
        public static EnBrands GetBrandsInfo(string strWhere)
        {
            EnBrands enb = new EnBrands();
            try
            {
                enb = Brands.GetBrandsInfo(strWhere);
                if (enb == null)
                {
                    enb = new EnBrands();
                }
            }
            catch
            {
                enb = new EnBrands();
            }
            return enb;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnBrands> GetBrandsList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Brands.GetBrandsList(PageIndex, PageSize, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnBrands> GetBrandsList(string strWhere, out int pageCount)
        {
            return GetBrandsList(-1, 0, strWhere, out pageCount);
        }

        ///获取数据列表
        public static List<EnBrands> GetBrandsList(string strWhere)
        {
            int tmpPageCount = 0;
            return GetBrandsList(-1, 0, strWhere, out tmpPageCount);
        }

        //获取数据列表ToDataTable
        public static DataTable GetBrandsListToTable(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBBrands, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        public static DataTable GetBrandsListToTableByView(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBViewBrands, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        public static DataTable GetBrandsListToTableByRecycleView(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return DataCommon.GetPageDataTable(TableName.TBViewRecycleBrands, PageIndex, PageSize, strWhere, "id", 1, out pageCount);
        }

        public static DataTable GetBrandsListToTableByBrandId(string brandId)
        {
            return DataCommon.GetDataTable(TableName.TBBrands, " bs.*,b.title as brandtitle ", " bs left join " + TableName.TBBrand + " b on bs.brandid=b.id where b.id in(" + brandId + ")", " order by sort desc,id desc");
        }



        ///删除对象
        public static int DeleteBrands(int id)
        {
            return DeleteBrands(" where id=" + id);
        }
        ///删除对象
        public static int DeleteBrandsByIdList(string idList)
        {
            return DeleteBrands(" where id in (" + idList + ")");
        }
        ///删除对象
        public static int DeleteBrands(string strWhere)
        {
            return DataCommon.Delete(TableName.TBBrands, strWhere);
        }
        #endregion

        #region  
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnBrands> GetAdminBrandsList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            return Brands.GetAdminBrandsList(PageIndex, PageSize, strWhere, out pageCount);
        }
        #endregion



        /// <summary>
        /// shen 2015-02-03
        /// </summary>
        public static void GetBrand() {
            Brands.GetBrand();
        }
    }
}
