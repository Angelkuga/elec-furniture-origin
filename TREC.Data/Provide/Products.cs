using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TREC.Entity;
using TRECommon;
using System.Collections;

namespace TREC.Data
{
    public class Products
    {
        #region 检查产品编号

        public static int ExitBrandSku(string sku)
        {
            SqlParameter[] parames = { 
            new SqlParameter("@sku", SqlDbType.VarChar, 30)};
            parames[0].Value = sku;
            return DataCommon.Exists(TableName.TBProduct, " where sku=@sku", parames);
        }
        #endregion

        #region 删除产品到回收站

        /// <summary>
        /// 删除产品到回收站
        /// </summary>
        /// <param name="pId">产品id</param>
        /// <returns></returns>
        public static bool deleteProduct(string pid)
        {
            #region 插入回收站数据

            #endregion
            string Sql_deleproduct = @" SET IDENTITY_INSERT [dbo].[t_productrecyclerecycle] ON 
                       insert into t_productrecyclerecycle(id,attribute,title,shottitle,tcolor,sku,no,letter,categoryid,categorytitle,subcategoryidlist,subcategorytitlelist,brandid,brandtitle,brandsid,brandstitle,stylevalue,stylename,colorname,colorvalue,materialvalue,materialname,unit,localitycode,shipcode,customize,surface,logo,thumb,bannel,desimage,descript,tob2c,companyid,companyname,createmid,hits,sort,lastedid,lastedittime,auditstatus,linestatus,assemble,fid,shopid) SELECT id,attribute,title,shottitle,tcolor,sku,no,letter,categoryid,categorytitle,subcategoryidlist,subcategorytitlelist,brandid,brandtitle,brandsid,brandstitle,stylevalue,stylename,colorname,colorvalue,materialvalue,materialname,unit,localitycode,shipcode,customize,surface,logo,thumb,bannel,desimage,descript,tob2c,companyid,companyname,createmid,hits,sort,lastedid,lastedittime,auditstatus,linestatus,assemble,fid,shopid FROM t_product WHERE id IN ({0});
                       IF @@ERROR=0
                          BEGIN
                            DELETE FROM t_product WHERE id IN ({0})
                          END
                    ";
            Sql_deleproduct = string.Format(Sql_deleproduct, pid);
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql_deleproduct) > 0;

        }
        #endregion
        #region 还原（删除）回收站中产品


        /// <summary>
        /// 还原（删除）回收站中产品
        /// </summary>
        /// <param name="gpId">产品id</param>
        /// <param name="Type">操作类型（revert表示还原；delete表示删除）</param>
        /// <returns></returns>
        public static bool DoRecycleProduct(string pid, string Type)
        {
            string Sql_DoRecycleProductProperty = string.Empty;
            if (Type == "revert")
            {
                Sql_DoRecycleProductProperty = @"
                   SET IDENTITY_INSERT [dbo].[t_product] ON;
                   INSERT INTO t_product (id,attribute,title,shottitle,tcolor,sku,no,letter,categoryid,categorytitle,subcategoryidlist,subcategorytitlelist,brandid,brandtitle,brandsid,brandstitle,stylevalue,stylename,colorname,colorvalue,materialvalue,materialname,unit,localitycode,shipcode,customize,surface,logo,thumb,bannel,desimage,descript,tob2c,companyid,companyname,createmid,hits,sort,lastedid,lastedittime,auditstatus,linestatus,assemble,fid,shopid) 
                    SELECT id,attribute,title,shottitle,tcolor,sku,no,letter,categoryid,categorytitle,subcategoryidlist,subcategorytitlelist,brandid,brandtitle,brandsid,brandstitle,stylevalue,stylename,colorname,colorvalue,materialvalue,materialname,unit,localitycode,shipcode,customize,surface,logo,thumb,bannel,desimage,descript,tob2c,companyid,companyname,createmid,hits,sort,lastedid,lastedittime,auditstatus,linestatus,assemble,fid,shopid FROM t_productrecyclerecycle WHERE id IN ({0});
                   SET IDENTITY_INSERT [dbo].[t_product] OFF;
                       IF @@ERROR=0
                          BEGIN
                            DELETE FROM t_productrecyclerecycle  WHERE id IN ({0})
                          END                   
                ";
            }
            else
            {
                Sql_DoRecycleProductProperty = @"
                  DELETE FROM t_productrecyclerecycle WHERE id IN ({0});                 
                ";
            }
            Sql_DoRecycleProductProperty = string.Format(Sql_DoRecycleProductProperty, pid);
            return DbHelper.ExecuteNonQuery(CommandType.Text, Sql_DoRecycleProductProperty) > 0;

        }
        #endregion

        #region 获取产品分类(包含某分类产品总数)

        /// <summary>
        /// 获取产品分类(包含某分类产品总数)
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCategoryAndProductCountList()
        {
            string sql = @"select c.id,c.title,c.parentid,isnull(pc.c,0) as c from  t_productcategory  c 
left join (select categoryid,count(categoryid) as c from v_product group by categoryid) pc on c.id=pc.categoryid
where c.linestatus=1
order by lft ";

            return DbHelper.ExecuteDataset(sql).Tables[0];
        }
        #endregion

        #region 获取产品分类(包含某分类产品总数)

        /// <summary>
        /// 获取产品分类(包含某分类产品总数)
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCategoryAndProductCountList(string strWhere)
        {
            string sql = @"select c.id,c.title,c.parentid,isnull(pc.c,0) as c from  t_productcategory  c 
left join (select categoryid,count(categoryid) as c from v_product {0} group by categoryid) pc on c.id=pc.categoryid
where c.linestatus=1
order by lft";

            return DbHelper.ExecuteDataset(string.Format(sql, strWhere != "" ? " where " + strWhere : strWhere)).Tables[0];
        }
        #endregion

        #region 获取产品搜索项

        public static List<EnSearchProductItem> GetProductSearchItem(string strWhere)
        {
            if (strWhere == "") { strWhere = " 1=1"; }

            string sql = @"
                        select t,v,n,c,b,bs,pc
                        from (select 'brand' as t,CONVERT(varchar(20),b.brandid) as v,b.brandtitle as n,count(b.brandid) as c, '0' as b,'0' as bs, '0' as pc
                        from v_product b where linestatus=1 and  {0} group by b.brandid,b.brandtitle
                        )as brand
                        UNION ALL
                        select t,v,n,c,b,bs,pc
                        from (select 'brands' as t,CONVERT(varchar(20),b.brandsid) as v,b.brandstitle as n,count(b.brandsid) as c, b.brandid as b,'0' as bs, '0' as pc
                        from v_product b where linestatus=1 and  {0} group by b.brandsid,b.brandstitle,b.brandid
                        )as brands
                        UNION ALL
                        select distinct t,v,n,c,b,bs,pc
                        from (select 'pcategory' as t,CONVERT(varchar(20),c2.id) as v,c2.title as n,
                        (select count(0) from t_productcategory where id = c.parentid) as c,
                         '0' as b,'0' as bs, '0'as pc
                        from v_product b left join t_productcategory c on c.id=b.categoryid left join t_productcategory c2 on c2.id=c.parentid
                        where b.linestatus=1 and  {0} group by c2.id,c2.title,b.brandid,b.brandsid,c.parentid
                        )as pcategory
                        UNION ALL
                        select distinct t,v,n,c,b,bs,pc
                        from (select 'category' as t,CONVERT(varchar(20),c.id) as v,c.title as n,
                        (select count(0) from t_product where linestatus=1 and  {0} and categoryid=c.id) as c, 
                        '0' as b,'0' as bs, c.parentid as pc
                        from v_product b left join t_productcategory c on c.id=b.categoryid 
                        where b.linestatus=1 and  {0} group by c.id,c.title,b.brandid,b.brandsid,c.parentid
                        )as category";
            List<EnSearchProductItem> list = new List<EnSearchProductItem>();
            IDataReader reader = DbHelper.ExecuteReader(string.Format(sql, strWhere));
            while (reader.Read())
            {
                EnSearchProductItem model = new EnSearchProductItem();
                if (reader["t"] != null && reader["t"].ToString() != "")
                {
                    model.type = reader["t"].ToString();
                }
                if (reader["v"] != null && reader["v"].ToString() != "")
                {
                    model.value = reader["v"].ToString();
                }
                if (reader["n"] != null && reader["n"].ToString() != "")
                {
                    model.title = reader["n"].ToString();
                }
                if (reader["c"] != null && reader["c"].ToString() != "")
                {
                    model.count = int.Parse(reader["c"].ToString());
                }
                if (reader["b"] != null && reader["b"].ToString() != "")
                {
                    model.brandid = reader["b"].ToString();
                }
                if (reader["bs"] != null && reader["bs"].ToString() != "")
                {
                    model.brandsid = reader["bs"].ToString();
                }
                if (reader["pc"] != null && reader["pc"].ToString() != "")
                {
                    model.pcategoryid = reader["pc"].ToString();
                }
                model.isCur = false;
                list.Add(model);
            }
            if (!reader.IsClosed)
                reader.Close();
            return list;

        }


        public static List<EnSearchProductItem> GetProductSearchItem(string strWhere,string companyid)
        {
            if (strWhere == "") { strWhere = " 1=1"; }

            string sql = @"
                       select t,v,n,c,b,bs,pc FROM (       
              SELECT 'brand' as t,t.id AS v,t.title AS n,(SELECT count(b.brandid) FROM v_product b where b.linestatus=1 and   {0} AND b.brandid=t.id ) AS c,'0' as b,'0' as bs, '0' as pc
              FROM dbo.t_brand t WHERE companyid={1}) AS brand
                        UNION ALL
                        select t,v,n,c,b,bs,pc
                        from (select 'brands' as t,CONVERT(varchar(20),b.brandsid) as v,b.brandstitle as n,count(b.brandsid) as c, b.brandid as b,'0' as bs, '0' as pc
                        from v_product b where linestatus=1 and  {0} group by b.brandsid,b.brandstitle,b.brandid
                        )as brands
                        UNION ALL
                        select distinct t,v,n,c,b,bs,pc
                        from (select 'pcategory' as t,CONVERT(varchar(20),c2.id) as v,c2.title as n,
                        (select count(0) from t_productcategory where id = c.parentid) as c,
                         '0' as b,'0' as bs, '0'as pc
                        from v_product b left join t_productcategory c on c.id=b.categoryid left join t_productcategory c2 on c2.id=c.parentid
                        where b.linestatus=1 and  {0} group by c2.id,c2.title,b.brandid,b.brandsid,c.parentid
                        )as pcategory
                        UNION ALL
                        select distinct t,v,n,c,b,bs,pc
                        from (select 'category' as t,CONVERT(varchar(20),c.id) as v,c.title as n,
                        (select count(0) from t_product where linestatus=1 and  {0} and categoryid=c.id) as c, 
                        '0' as b,'0' as bs, c.parentid as pc
                        from v_product b left join t_productcategory c on c.id=b.categoryid 
                        where b.linestatus=1 and  {0} group by c.id,c.title,b.brandid,b.brandsid,c.parentid
                        )as category";
            List<EnSearchProductItem> list = new List<EnSearchProductItem>();
            IDataReader reader = DbHelper.ExecuteReader(string.Format(sql, strWhere,companyid));
            while (reader.Read())
            {
                EnSearchProductItem model = new EnSearchProductItem();
                if (reader["t"] != null && reader["t"].ToString() != "")
                {
                    model.type = reader["t"].ToString();
                }
                if (reader["v"] != null && reader["v"].ToString() != "")
                {
                    model.value = reader["v"].ToString();
                }
                if (reader["n"] != null && reader["n"].ToString() != "")
                {
                    model.title = reader["n"].ToString();
                }
                if (reader["c"] != null && reader["c"].ToString() != "")
                {
                    model.count = int.Parse(reader["c"].ToString());
                }
                if (reader["b"] != null && reader["b"].ToString() != "")
                {
                    model.brandid = reader["b"].ToString();
                }
                if (reader["bs"] != null && reader["bs"].ToString() != "")
                {
                    model.brandsid = reader["bs"].ToString();
                }
                if (reader["pc"] != null && reader["pc"].ToString() != "")
                {
                    model.pcategoryid = reader["pc"].ToString();
                }
                model.isCur = false;
                list.Add(model);
            }
            if (!reader.IsClosed)
                reader.Close();
            return list;

        }


        public static List<EnSearchProductItem> GetProductSearchItemByCreateMid(string strWhere, string createmid)
        {
            if (strWhere == "") { strWhere = " 1=1"; }

            string sql = @"
                       select t,v,n,c,b,bs,pc FROM (       
              SELECT 'brand' as t,t.id AS v,t.title AS n,(SELECT count(b.brandid) FROM v_product b where b.linestatus=1 and  createmid={1} and  {0} AND b.brandid=t.id ) AS c,'0' as b,'0' as bs, '0' as pc
              FROM dbo.t_brand t WHERE createmid={1}) AS brand
                        UNION ALL
                        select t,v,n,c,b,bs,pc
                        from (select 'brands' as t,CONVERT(varchar(20),b.brandsid) as v,b.brandstitle as n,count(b.brandsid) as c, b.brandid as b,'0' as bs, '0' as pc
                        from v_product b where linestatus=1 and createmid={1} and {0} group by b.brandsid,b.brandstitle,b.brandid
                        )as brands
                        UNION ALL
                        select distinct t,v,n,c,b,bs,pc
                        from (select 'pcategory' as t,CONVERT(varchar(20),c2.id) as v,c2.title as n,
                        (select count(0) from t_productcategory where id = c.parentid) as c,
                         '0' as b,'0' as bs, '0'as pc
                        from v_product b left join t_productcategory c on c.id=b.categoryid left join t_productcategory c2 on c2.id=c.parentid
                        where b.linestatus=1 and b.createmid={1} and {0} group by c2.id,c2.title,b.brandid,b.brandsid,c.parentid
                        )as pcategory
                        UNION ALL
                        select distinct t,v,n,c,b,bs,pc
                        from (select 'category' as t,CONVERT(varchar(20),c.id) as v,c.title as n,
                        (select count(0) from t_product where linestatus=1 and  createmid={1} and {0} and categoryid=c.id) as c, 
                        '0' as b,'0' as bs, c.parentid as pc
                        from v_product b left join t_productcategory c on c.id=b.categoryid 
                        where b.linestatus=1 and  b.createmid={1} and {0} group by c.id,c.title,b.brandid,b.brandsid,c.parentid
                        )as category";
            List<EnSearchProductItem> list = new List<EnSearchProductItem>();
            IDataReader reader = DbHelper.ExecuteReader(string.Format(sql, strWhere, createmid));
            while (reader.Read())
            {
                EnSearchProductItem model = new EnSearchProductItem();
                if (reader["t"] != null && reader["t"].ToString() != "")
                {
                    model.type = reader["t"].ToString();
                }
                if (reader["v"] != null && reader["v"].ToString() != "")
                {
                    model.value = reader["v"].ToString();
                }
                if (reader["n"] != null && reader["n"].ToString() != "")
                {
                    model.title = reader["n"].ToString();
                }
                if (reader["c"] != null && reader["c"].ToString() != "")
                {
                    model.count = int.Parse(reader["c"].ToString());
                }
                if (reader["b"] != null && reader["b"].ToString() != "")
                {
                    model.brandid = reader["b"].ToString();
                }
                if (reader["bs"] != null && reader["bs"].ToString() != "")
                {
                    model.brandsid = reader["bs"].ToString();
                }
                if (reader["pc"] != null && reader["pc"].ToString() != "")
                {
                    model.pcategoryid = reader["pc"].ToString();
                }
                model.isCur = false;
                list.Add(model);
            }
            if (!reader.IsClosed)
                reader.Close();
            return list;

        }
        #endregion

        #region 获取产品详细信息

        public static string CheckbuypriceName(string proid)
        {
            return DataCommon.CheckbuypriceName(proid);
        }
        public static EnWebProduct GetWebProducInfo(string strWhere)
        {
            EnWebProduct model = new EnWebProduct();
            IDataReader reader = DataCommon.GetDataIReader(TableName.TVProduct, "", strWhere, "");
            while (reader.Read())
            {
                if (reader["shopxml"] != null && reader["shopxml"].ToString() != "")
                {
                    model.shopxml = reader["shopxml"].ToString();
                }
                if (reader["attributexml"] != null && reader["attributexml"].ToString() != "")
                {
                    model.attributexml = reader["attributexml"].ToString();
                }
                if (reader["shopprice"] != null && reader["shopprice"].ToString() != "")
                {
                    model.shopprice = reader["shopprice"].ToString();
                }
                if (reader["spreadname"] != null && reader["spreadname"].ToString() != "")
                {
                    model.spreadname = reader["spreadname"].ToString();
                }
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["shottitle"] != null && reader["shottitle"].ToString() != "")
                {
                    model.shottitle = reader["shottitle"].ToString();
                }
                if (reader["tcolor"] != null && reader["tcolor"].ToString() != "")
                {
                    model.tcolor = reader["tcolor"].ToString();
                }
                if (reader["sku"] != null && reader["sku"].ToString() != "")
                {
                    model.sku = reader["sku"].ToString();
                }
                if (reader["no"] != null && reader["no"].ToString() != "")
                {
                    model.no = reader["no"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["categoryid"] != null && reader["categoryid"].ToString() != "")
                {
                    model.categoryid = int.Parse(reader["categoryid"].ToString());
                }
                if (reader["categorytitle"] != null && reader["categorytitle"].ToString() != "")
                {
                    model.categorytitle = reader["categorytitle"].ToString();
                }
                if (reader["subcategoryidlist"] != null && reader["subcategoryidlist"].ToString() != "")
                {
                    model.subcategoryidlist = reader["subcategoryidlist"].ToString();
                }
                if (reader["subcategorytitlelist"] != null && reader["subcategorytitlelist"].ToString() != "")
                {
                    model.subcategorytitlelist = reader["subcategorytitlelist"].ToString();
                }
                if (reader["brandid"] != null && reader["brandid"].ToString() != "")
                {
                    model.brandid = int.Parse(reader["brandid"].ToString());
                }
                if (reader["brandtitle"] != null && reader["brandtitle"].ToString() != "")
                {
                    model.brandtitle = reader["brandtitle"].ToString();
                }
                if (reader["brandlogo"] != null && reader["brandlogo"].ToString() != "")
                {
                    model.brandlogo = reader["brandlogo"].ToString();
                }
                if (reader["brandsid"] != null && reader["brandsid"].ToString() != "")
                {
                    model.brandsid = int.Parse(reader["brandsid"].ToString());
                }
                if (reader["brandstitle"] != null && reader["brandstitle"].ToString() != "")
                {
                    model.brandstitle = reader["brandstitle"].ToString();
                }
                if (reader["stylevalue"] != null && reader["stylevalue"].ToString() != "")
                {
                    model.stylevalue = reader["stylevalue"].ToString();
                }
                if (reader["stylename"] != null && reader["stylename"].ToString() != "")
                {
                    model.stylename = reader["stylename"].ToString();
                }
                if (reader["colorname"] != null && reader["colorname"].ToString() != "")
                {
                    model.colorname = reader["colorname"].ToString();
                }
                if (reader["colorvalue"] != null && reader["colorvalue"].ToString() != "")
                {
                    model.colorvalue = reader["colorvalue"].ToString();
                }
                if (reader["materialvalue"] != null && reader["materialvalue"].ToString() != "")
                {
                    model.materialvalue = reader["materialvalue"].ToString();
                }
                if (reader["materialname"] != null && reader["materialname"].ToString() != "")
                {
                    model.materialname = reader["materialname"].ToString();
                }
                if (reader["unit"] != null && reader["unit"].ToString() != "")
                {
                    model.unit = reader["unit"].ToString();
                }
                if (reader["localitycode"] != null && reader["localitycode"].ToString() != "")
                {
                    model.localitycode = reader["localitycode"].ToString();
                }
                if (reader["shipcode"] != null && reader["shipcode"].ToString() != "")
                {
                    model.shipcode = reader["shipcode"].ToString();
                }
                if (reader["customize"] != null && reader["customize"].ToString() != "")
                {
                    model.customize = int.Parse(reader["customize"].ToString());
                }
                if (reader["surface"] != null && reader["surface"].ToString() != "")
                {
                    model.surface = reader["surface"].ToString();
                }
                if (reader["logo"] != null && reader["logo"].ToString() != "")
                {
                    model.logo = reader["logo"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["bannel"] != null && reader["bannel"].ToString() != "")
                {
                    model.bannel = reader["bannel"].ToString();
                }
                if (reader["desimage"] != null && reader["desimage"].ToString() != "")
                {
                    model.desimage = reader["desimage"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["tob2c"] != null && reader["tob2c"].ToString() != "")
                {
                    model.tob2c = reader["tob2c"].ToString();
                }
                if (reader["companyid"] != null && reader["companyid"].ToString() != "")
                {
                    model.companyid = int.Parse(reader["companyid"].ToString());
                }
                if (reader["companyname"] != null && reader["companyname"].ToString() != "")
                {
                    model.companyname = reader["companyname"].ToString();
                }
                if (reader["createmid"] != null && reader["createmid"].ToString() != "")
                {
                    model.createmid = int.Parse(reader["createmid"].ToString());
                }
                if (reader["hits"] != null && reader["hits"].ToString() != "")
                {
                    model.hits = int.Parse(reader["hits"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["lastedid"] != null && reader["lastedid"].ToString() != "")
                {
                    model.lastedid = int.Parse(reader["lastedid"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["auditstatus"] != null && reader["auditstatus"].ToString() != "")
                {
                    model.auditstatus = int.Parse(reader["auditstatus"].ToString());
                }
                if (reader["linestatus"] != null && reader["linestatus"].ToString() != "")
                {
                    model.linestatus = int.Parse(reader["linestatus"].ToString());
                }
                if (reader["FID"] != null && reader["FID"].ToString() != "")
                {
                    model.FID = int.Parse(reader["FID"].ToString());
                }
            }
            if (!reader.IsClosed)
                reader.Close();
            return model;
        }
        /// <summary>
        /// ShopBrand.aspx页面店铺数据
        /// </summary>
        /// <returns></returns>
        public static DataSet getShopProduct(int pageIndex, int pagesize, string condiction, string table)
        {
            //string sql = "EXEC sp_TablePage 1,10,' and brandtitle=''欧莱思特'' AND auditstatus=1 AND linestatus=1','t_product'";

            SqlParameter[] parameters = {
                    new SqlParameter("@pageIndex", SqlDbType.Int),
                    new SqlParameter("@pagesize", SqlDbType.Int),
                    new SqlParameter("@condiction", SqlDbType.VarChar,200),
                    new SqlParameter("@table", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = pageIndex;
            parameters[1].Value = pagesize;
            parameters[2].Value = condiction;
            parameters[3].Value = table;

            return DbHelper.ExecuteDataset(CommandType.StoredProcedure, "sp_TablePage", parameters);

           
        }
        #endregion

        #region    产品列表

        public static List<EnWebProduct> GetWebProductList(int PageIndex, int PageSize, string strWhere, string sortkey, string ordertype, out int pageCount)
        {
            List<EnWebProduct> list = new List<EnWebProduct>();
            IDataReader reader = DataCommon.GetPageDataReader(TableName.TVProduct, PageIndex, PageSize, strWhere, sortkey, ordertype, out pageCount);

            while (reader.Read())
            {
                EnWebProduct model = new EnWebProduct();

                if (reader["shopxml"] != null && reader["shopxml"].ToString() != "")
                {
                    model.shopxml = reader["shopxml"].ToString();
                }
                if (reader["attributexml"] != null && reader["attributexml"].ToString() != "")
                {
                    model.attributexml = reader["attributexml"].ToString();
                }
                if (reader["shopprice"] != null && reader["shopprice"].ToString() != "")
                {
                    model.shopprice = reader["shopprice"].ToString();
                }
                if (reader["spreadname"] != null && reader["spreadname"].ToString() != "")
                {
                    model.spreadname = reader["spreadname"].ToString();
                }
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["shottitle"] != null && reader["shottitle"].ToString() != "")
                {
                    model.shottitle = reader["shottitle"].ToString();
                }
                if (reader["tcolor"] != null && reader["tcolor"].ToString() != "")
                {
                    model.tcolor = reader["tcolor"].ToString();
                }
                if (reader["sku"] != null && reader["sku"].ToString() != "")
                {
                    model.sku = reader["sku"].ToString();
                }
                if (reader["no"] != null && reader["no"].ToString() != "")
                {
                    model.no = reader["no"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["categoryid"] != null && reader["categoryid"].ToString() != "")
                {
                    model.categoryid = int.Parse(reader["categoryid"].ToString());
                }
                if (reader["categorytitle"] != null && reader["categorytitle"].ToString() != "")
                {
                    model.categorytitle = reader["categorytitle"].ToString();
                }
                if (reader["subcategoryidlist"] != null && reader["subcategoryidlist"].ToString() != "")
                {
                    model.subcategoryidlist = reader["subcategoryidlist"].ToString();
                }
                if (reader["subcategorytitlelist"] != null && reader["subcategorytitlelist"].ToString() != "")
                {
                    model.subcategorytitlelist = reader["subcategorytitlelist"].ToString();
                }
                if (reader["brandid"] != null && reader["brandid"].ToString() != "")
                {
                    model.brandid = int.Parse(reader["brandid"].ToString());
                }
                if (reader["brandtitle"] != null && reader["brandtitle"].ToString() != "")
                {
                    model.brandtitle = reader["brandtitle"].ToString();
                }
                if (reader["brandlogo"] != null && reader["brandlogo"].ToString() != "")
                {
                    model.brandlogo = reader["brandlogo"].ToString();
                }
                if (reader["brandsid"] != null && reader["brandsid"].ToString() != "")
                {
                    model.brandsid = int.Parse(reader["brandsid"].ToString());
                }
                if (reader["brandstitle"] != null && reader["brandstitle"].ToString() != "")
                {
                    model.brandstitle = reader["brandstitle"].ToString();
                }
                if (reader["stylevalue"] != null && reader["stylevalue"].ToString() != "")
                {
                    model.stylevalue = reader["stylevalue"].ToString();
                }
                if (reader["stylename"] != null && reader["stylename"].ToString() != "")
                {
                    model.stylename = reader["stylename"].ToString();
                }
                if (reader["colorname"] != null && reader["colorname"].ToString() != "")
                {
                    model.colorname = reader["colorname"].ToString();
                }
                if (reader["colorvalue"] != null && reader["colorvalue"].ToString() != "")
                {
                    model.colorvalue = reader["colorvalue"].ToString();
                }
                if (reader["materialvalue"] != null && reader["materialvalue"].ToString() != "")
                {
                    model.materialvalue = reader["materialvalue"].ToString();
                }
                if (reader["materialname"] != null && reader["materialname"].ToString() != "")
                {
                    model.materialname = reader["materialname"].ToString();
                }
                if (reader["unit"] != null && reader["unit"].ToString() != "")
                {
                    model.unit = reader["unit"].ToString();
                }
                if (reader["localitycode"] != null && reader["localitycode"].ToString() != "")
                {
                    model.localitycode = reader["localitycode"].ToString();
                }
                if (reader["shipcode"] != null && reader["shipcode"].ToString() != "")
                {
                    model.shipcode = reader["shipcode"].ToString();
                }
                if (reader["customize"] != null && reader["customize"].ToString() != "")
                {
                    model.customize = int.Parse(reader["customize"].ToString());
                }
                if (reader["surface"] != null && reader["surface"].ToString() != "")
                {
                    model.surface = reader["surface"].ToString();
                }
                if (reader["logo"] != null && reader["logo"].ToString() != "")
                {
                    model.logo = reader["logo"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["bannel"] != null && reader["bannel"].ToString() != "")
                {
                    model.bannel = reader["bannel"].ToString();
                }
                if (reader["desimage"] != null && reader["desimage"].ToString() != "")
                {
                    model.desimage = reader["desimage"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["tob2c"] != null && reader["tob2c"].ToString() != "")
                {
                    model.tob2c = reader["tob2c"].ToString();
                }
                if (reader["companyid"] != null && reader["companyid"].ToString() != "")
                {
                    model.companyid = int.Parse(reader["companyid"].ToString());
                }
                if (reader["companyname"] != null && reader["companyname"].ToString() != "")
                {
                    model.companyname = reader["companyname"].ToString();
                }
                if (reader["createmid"] != null && reader["createmid"].ToString() != "")
                {
                    model.createmid = int.Parse(reader["createmid"].ToString());
                }
                if (reader["hits"] != null && reader["hits"].ToString() != "")
                {
                    model.hits = int.Parse(reader["hits"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["lastedid"] != null && reader["lastedid"].ToString() != "")
                {
                    model.lastedid = int.Parse(reader["lastedid"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["auditstatus"] != null && reader["auditstatus"].ToString() != "")
                {
                    model.auditstatus = int.Parse(reader["auditstatus"].ToString());
                }
                if (reader["linestatus"] != null && reader["linestatus"].ToString() != "")
                {
                    model.linestatus = int.Parse(reader["linestatus"].ToString());
                }
                if (reader["FID"] != null && reader["FID"].ToString() != "")
                {
                    model.FID = int.Parse(reader["FID"].ToString());
                }
                list.Add(model);
            }

            if (!reader.IsClosed)
                reader.Close();
            return list;
        }
        #endregion

        #region  产品列表 增加返回brandIdList

        /// <summary>
        /// 产品列表 增加返回brandIdList
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="strWhere"></param>
        /// <param name="sortkey"></param>
        /// <param name="ordertype"></param>
        /// <param name="pageCount"></param>
        /// <param name="brandidlist"></param>
        /// <returns></returns>
        public static List<EnWebProduct> GetWebProductList(int PageIndex, int PageSize, string strWhere, string sortkey, string ordertype, string bstrWhere, string brstrWhere, string bidWhere, bool blBrandSearch, bool isfristshow, out int pageCount, out List<int> brandList, out List<int> brandidlist, out List<int> marketList)
        {
            List<EnWebProduct> list = new List<EnWebProduct>();
            IDataReader reader = null;
            if (isfristshow)
            {
                reader = DataCommon.GetPageDataReader(TableName.TVProduct, PageIndex, PageSize, bstrWhere, sortkey, ordertype, out pageCount);
            }
            else
            {
                reader = DataCommon.GetPageDataReader(TableName.TVProduct, PageIndex, PageSize, strWhere + bstrWhere, sortkey, ordertype, out pageCount);
            }
            while (reader.Read())
            {
                EnWebProduct model = new EnWebProduct();
                if (reader["shopxml"] != null && reader["shopxml"].ToString() != "")
                {
                    model.shopxml = reader["shopxml"].ToString();
                }
                if (reader["attributexml"] != null && reader["attributexml"].ToString() != "")
                {
                    model.attributexml = reader["attributexml"].ToString();
                }
                if (reader["shopprice"] != null && reader["shopprice"].ToString() != "")
                {
                    model.shopprice = reader["shopprice"].ToString();
                }
                if (reader["spreadname"] != null && reader["spreadname"].ToString() != "")
                {
                    model.spreadname = reader["spreadname"].ToString();
                }
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["shottitle"] != null && reader["shottitle"].ToString() != "")
                {
                    model.shottitle = reader["shottitle"].ToString();
                }
                if (reader["tcolor"] != null && reader["tcolor"].ToString() != "")
                {
                    model.tcolor = reader["tcolor"].ToString();
                }
                if (reader["sku"] != null && reader["sku"].ToString() != "")
                {
                    model.sku = reader["sku"].ToString();
                }
                if (reader["no"] != null && reader["no"].ToString() != "")
                {
                    model.no = reader["no"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["categoryid"] != null && reader["categoryid"].ToString() != "")
                {
                    model.categoryid = int.Parse(reader["categoryid"].ToString());
                }
                if (reader["categorytitle"] != null && reader["categorytitle"].ToString() != "")
                {
                    model.categorytitle = reader["categorytitle"].ToString();
                }
                if (reader["subcategoryidlist"] != null && reader["subcategoryidlist"].ToString() != "")
                {
                    model.subcategoryidlist = reader["subcategoryidlist"].ToString();
                }
                if (reader["subcategorytitlelist"] != null && reader["subcategorytitlelist"].ToString() != "")
                {
                    model.subcategorytitlelist = reader["subcategorytitlelist"].ToString();
                }
                if (reader["brandid"] != null && reader["brandid"].ToString() != "")
                {
                    model.brandid = int.Parse(reader["brandid"].ToString());
                }
                if (reader["brandtitle"] != null && reader["brandtitle"].ToString() != "")
                {
                    model.brandtitle = reader["brandtitle"].ToString();
                }
                if (reader["brandlogo"] != null && reader["brandlogo"].ToString() != "")
                {
                    model.brandlogo = reader["brandlogo"].ToString();
                }
                if (reader["brandsid"] != null && reader["brandsid"].ToString() != "")
                {
                    model.brandsid = int.Parse(reader["brandsid"].ToString());
                }
                if (reader["brandstitle"] != null && reader["brandstitle"].ToString() != "")
                {
                    model.brandstitle = reader["brandstitle"].ToString();
                }
                if (reader["stylevalue"] != null && reader["stylevalue"].ToString() != "")
                {
                    model.stylevalue = reader["stylevalue"].ToString();
                }
                if (reader["stylename"] != null && reader["stylename"].ToString() != "")
                {
                    model.stylename = reader["stylename"].ToString();
                }
                if (reader["colorname"] != null && reader["colorname"].ToString() != "")
                {
                    model.colorname = reader["colorname"].ToString();
                }
                if (reader["colorvalue"] != null && reader["colorvalue"].ToString() != "")
                {
                    model.colorvalue = reader["colorvalue"].ToString();
                }
                if (reader["materialvalue"] != null && reader["materialvalue"].ToString() != "")
                {
                    model.materialvalue = reader["materialvalue"].ToString();
                }
                if (reader["materialname"] != null && reader["materialname"].ToString() != "")
                {
                    model.materialname = reader["materialname"].ToString();
                }
                if (reader["unit"] != null && reader["unit"].ToString() != "")
                {
                    model.unit = reader["unit"].ToString();
                }
                if (reader["localitycode"] != null && reader["localitycode"].ToString() != "")
                {
                    model.localitycode = reader["localitycode"].ToString();
                }
                if (reader["shipcode"] != null && reader["shipcode"].ToString() != "")
                {
                    model.shipcode = reader["shipcode"].ToString();
                }
                if (reader["customize"] != null && reader["customize"].ToString() != "")
                {
                    model.customize = int.Parse(reader["customize"].ToString());
                }
                if (reader["surface"] != null && reader["surface"].ToString() != "")
                {
                    model.surface = reader["surface"].ToString();
                }
                if (reader["logo"] != null && reader["logo"].ToString() != "")
                {
                    model.logo = reader["logo"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["bannel"] != null && reader["bannel"].ToString() != "")
                {
                    model.bannel = reader["bannel"].ToString();
                }
                if (reader["desimage"] != null && reader["desimage"].ToString() != "")
                {
                    model.desimage = reader["desimage"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["tob2c"] != null && reader["tob2c"].ToString() != "")
                {
                    model.tob2c = reader["tob2c"].ToString();
                }
                if (reader["companyid"] != null && reader["companyid"].ToString() != "")
                {
                    model.companyid = int.Parse(reader["companyid"].ToString());
                }
                if (reader["companyname"] != null && reader["companyname"].ToString() != "")
                {
                    model.companyname = reader["companyname"].ToString();
                }
                if (reader["createmid"] != null && reader["createmid"].ToString() != "")
                {
                    model.createmid = int.Parse(reader["createmid"].ToString());
                }
                if (reader["hits"] != null && reader["hits"].ToString() != "")
                {
                    model.hits = int.Parse(reader["hits"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["lastedid"] != null && reader["lastedid"].ToString() != "")
                {
                    model.lastedid = int.Parse(reader["lastedid"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["auditstatus"] != null && reader["auditstatus"].ToString() != "")
                {
                    model.auditstatus = int.Parse(reader["auditstatus"].ToString());
                }
                if (reader["linestatus"] != null && reader["linestatus"].ToString() != "")
                {
                    model.linestatus = int.Parse(reader["linestatus"].ToString());
                }
                if (reader["FID"] != null && reader["FID"].ToString() != "")
                {
                    model.FID = int.Parse(reader["FID"].ToString());
                }
                list.Add(model);
            }
            reader.Close();
            if (!reader.IsClosed)
            {
                reader.Close();
            }

            string ostrWhere = strWhere == "" ? " where 1=1 " : " where 1=1 " + strWhere;
            string brandstrWhere = bstrWhere == "" ? " where 1=1 " : " where 1=1 " + bstrWhere;
            string obrstrWhere = brstrWhere == "" ? " where 1=1 " : " where 1=1 " + brstrWhere;
            string obidWhere = bidWhere == "" ? " where 1=1 " : " where 1=1 " + bidWhere;
            string ostrbrandlistwhere = "";
            if (!blBrandSearch)
            {

                ostrbrandlistwhere = @"select DISTINCT brandid as id from v_product "
                    + ostrWhere;
                //+ "  union  select DISTINCT id as id from t_brand  "
                //+ obrstrWhere;

            }
            else
            {
                if (isfristshow)
                {
                    //ostrbrandlistwhere = @"select DISTINCT id as id from t_brand " + obidWhere;
                    //ostrbrandlistwhere = @"select DISTINCT id as id from t_brand ";
                    ostrbrandlistwhere = @"select DISTINCT brandid as id from v_product ";
                }
                else
                {
                    ostrbrandlistwhere = @"select DISTINCT brandid as id from v_product "
                        + ostrWhere
                        + " UNION  select DISTINCT brandid as id from v_product "
                        + brandstrWhere;
                    //+ " UNION  select DISTINCT id from t_brand  "
                    //+ obidWhere
                    //+ "  union  select DISTINCT id as id from t_brand  "
                    //+ obrstrWhere;
                }
            }

            IDataReader brandListReader = DbHelper.ExecuteReader(string.Format(ostrbrandlistwhere.ToString(), brandstrWhere, ostrWhere, TableName.TVProduct));
            List<int> brl = new List<int>();
            while (brandListReader.Read())
            {
                int brandid = 0;
                if (brandListReader["id"] != null && brandListReader["id"].ToString() != "")
                {
                    brandid = int.Parse(brandListReader["id"].ToString());
                }
                brl.Add(brandid);
            }
            brandListReader.Close();
            if (!brandListReader.IsClosed)
            {
                brandListReader.Close();
            }
            brandList = brl;

            string ostrWhere1 = (strWhere + bstrWhere) == "" ? " where 1=1 " : " where 1=1 " + strWhere + bstrWhere;

            string selectBrandId = @"SELECT DISTINCT brandid FROM (select {1} from "
                           + "(select {1} from {0}  {2})a"
                           + ")a";
            IDataReader brandidReader = DbHelper.ExecuteReader(string.Format(selectBrandId.ToString(), TableName.TVProduct, "*", ostrWhere1));
            List<int> bl = new List<int>();
            while (brandidReader.Read())
            {
                int brandid = 0;
                if (brandidReader["brandid"] != null && brandidReader["brandid"].ToString() != "")
                {
                    brandid = int.Parse(brandidReader["brandid"].ToString());
                }
                bl.Add(brandid);
            }
            if (!brandidReader.IsClosed)
                brandidReader.Close();
            brandidlist = bl;

            //string selectMarketId = @"select DISTINCT t_ms.marketid as id from t_marketstoreyshop as t_ms join ("
            //    + "select DISTINCT t_ps.shopid from t_shopbrand as t_ps join( "
            //                + "select {1} from {0} {2}) as v_p on t_ps.brandid=v_p.brandid "
            //                + ") as t_v_p on t_ms.shopid =t_v_p.shopid";

            //string selectMarketId = @"select id from t_market where id in( "
            //    + "select DISTINCT marketid from t_marketstoreyshop where shopid in( "
            //                + "select DISTINCT shopid from t_shopbrand  "
            //                + "where brandid in("
            //                + ostrbrandlistwhere
            //                + " ))) and auditstatus=1";

            string selectMarketId = @"select id from t_market where id in("
                + " select marketid from t_marketstoreyshop where shopid in( "
                + "select shopid from t_shopbrand where brandid in("
                + ostrbrandlistwhere
                + ")))";

            IDataReader marketidReader = DbHelper.ExecuteReader(string.Format(selectMarketId.ToString(), TableName.TVProduct, "*", ostrWhere1));
            List<int> ml = new List<int>();
            while (marketidReader.Read())
            {
                int marketid = 0;
                if (marketidReader["id"] != null && marketidReader["id"].ToString() != "")
                {
                    marketid = int.Parse(marketidReader["id"].ToString());
                }
                ml.Add(marketid);
            }
            if (!marketidReader.IsClosed)
                marketidReader.Close();
            marketList = ml;

            return list;
        }
        #endregion

        #region 获取产品搜索项

        public static List<EnSearchItem> GetMarketProductSearchItem(string marketId)
        {
            string strSql = @"SELECT     t, v, n, c
FROM         (SELECT     'brand' AS t, CONVERT(varchar(30), brandid) AS v, brandtitle AS n, COUNT(brandid) AS c
                       FROM          dbo.v_product
                       WHERE      (linestatus = 1) and brandid in (select brandid from t_shopbrand where shopid in(select shopid from t_marketstoreyshop where marketid={0}))
                       GROUP BY brandid, brandtitle) AS brand
UNION ALL
SELECT     t, v, n, c
FROM         (SELECT     'style' AS t, CONVERT(varchar(30), stylevalue) AS v, stylename AS n, COUNT(stylevalue) AS c
                       FROM          dbo.v_product AS v_product_3
                       WHERE      (linestatus = 1) and brandid in (select brandid from t_shopbrand where shopid in(select shopid from t_marketstoreyshop where marketid={0}))
                       GROUP BY stylevalue, stylename) AS style
UNION ALL
SELECT     t, v, n, c
FROM         (SELECT     'material' AS t, CONVERT(varchar(30), materialvalue) AS v, materialname AS n, COUNT(materialvalue) AS c
                       FROM          dbo.v_product AS v_product_2
                       WHERE      (linestatus = 1) and brandid in (select brandid from t_shopbrand where shopid in(select shopid from t_marketstoreyshop where marketid={0}))
                       GROUP BY materialvalue, materialname) AS material
UNION ALL
SELECT     t, v, n, c
FROM         (SELECT     'color' AS t, CONVERT(varchar(30), colorvalue) AS v, colorname AS n, COUNT(colorvalue) AS c
                       FROM          dbo.v_product AS v_product_1
                       WHERE      (linestatus = 1) and brandid in (select brandid from t_shopbrand where shopid in(select shopid from t_marketstoreyshop where marketid={0}))
                       GROUP BY colorvalue, colorname) AS color
UNION ALL
SELECT     t, v, n, c
FROM         (SELECT     'spread' AS t, CONVERT(varchar(30), g.value) AS v, g.title AS n, COUNT(g.value) AS c
                       FROM          dbo.v_product AS p LEFT OUTER JOIN
                                              dbo.t_brand AS t ON p.brandid = t.id LEFT OUTER JOIN
                                              dbo.t_config AS g ON g.value = t.spread AND g.type = 5 AND g.module = 103
                       WHERE      (p.linestatus = 1) and brandid in (select brandid from t_shopbrand where shopid in(select shopid from t_marketstoreyshop where marketid={0}))
                       GROUP BY g.value, g.title) AS spread
UNION ALL
SELECT     t, v, n, c
FROM         (SELECT     'type' AS t, CONVERT(varchar(30), a.typevalue) AS v, a.typename AS n, COUNT(p.id) AS c
                       FROM          dbo.v_product AS p LEFT OUTER JOIN
                                              dbo.t_productattribute AS a ON p.id = a.productid
                       WHERE      (p.linestatus = 1) and brandid in (select brandid from t_shopbrand where shopid in(select shopid from t_marketstoreyshop where marketid={0}))
                       GROUP BY a.typevalue, a.typename) AS type";
            List<EnSearchItem> list = new List<EnSearchItem>();
            IDataReader reader = DbHelper.ExecuteReader(string.Format(strSql, marketId));
            while (reader.Read())
            {
                EnSearchItem model = new EnSearchItem();
                if (reader["t"] != null && reader["t"].ToString() != "")
                {
                    model.type = reader["t"].ToString();
                }
                if (reader["v"] != null && reader["v"].ToString() != "")
                {
                    model.value = reader["v"].ToString();
                }
                if (reader["n"] != null && reader["n"].ToString() != "")
                {
                    model.title = reader["n"].ToString();
                }
                if (reader["c"] != null && reader["c"].ToString() != "")
                {
                    model.count = int.Parse(reader["c"].ToString());
                }
                model.isCur = false;
                list.Add(model);
            }
            if (!reader.IsClosed)
                reader.Close();

            return list;

        }
        #endregion

        #region 企业搜索选项

        public static List<EnSearchItem> GetProductSearchItem()
        {
            List<EnSearchItem> list = new List<EnSearchItem>();
            IDataReader reader = DbHelper.ExecuteReader(" select * from " + TableName.TVProductSearchItem);
            while (reader.Read())
            {
                EnSearchItem model = new EnSearchItem();
                if (reader["t"] != null && reader["t"].ToString() != "")
                {
                    model.type = reader["t"].ToString();
                }
                if (reader["v"] != null && reader["v"].ToString() != "")
                {
                    model.value = reader["v"].ToString();
                }
                if (reader["n"] != null && reader["n"].ToString() != "")
                {
                    model.title = reader["n"].ToString();
                }
                if (reader["c"] != null && reader["c"].ToString() != "")
                {
                    model.count = int.Parse(reader["c"].ToString());
                }
                model.isCur = false;
                list.Add(model);
            }
            if (!reader.IsClosed)
                reader.Close();
            return list;
        }
        #endregion

        #region 获取产品搜索项
        public static List<EnSearchItem> GetProductSearchTypeItem(string strWhere)
        {
            string sql = @"SELECT     'type' AS t, CONVERT(varchar(30), a.typevalue) AS v, a.typename AS n, COUNT(p.id) AS c
                       FROM          dbo.v_product AS p LEFT OUTER JOIN
                                              dbo.t_productattribute AS a ON p.id = a.productid
                       WHERE      (p.linestatus = 1) {0} 
                       GROUP BY a.typevalue, a.typename";
            strWhere = strWhere != "" ? " and " + strWhere : strWhere;
            List<EnSearchItem> list = new List<EnSearchItem>();
            IDataReader reader = DbHelper.ExecuteReader(string.Format(sql, strWhere));
            while (reader.Read())
            {
                EnSearchItem model = new EnSearchItem();
                if (reader["t"] != null && reader["t"].ToString() != "")
                {
                    model.type = reader["t"].ToString();
                }
                if (reader["v"] != null && reader["v"].ToString() != "")
                {
                    model.value = reader["v"].ToString();
                }
                if (reader["n"] != null && reader["n"].ToString() != "")
                {
                    model.title = reader["n"].ToString();
                }
                if (reader["c"] != null && reader["c"].ToString() != "")
                {
                    model.count = int.Parse(reader["c"].ToString());
                }
                model.isCur = false;
                list.Add(model);
            }
            if (!reader.IsClosed)
                reader.Close();
            return list;

        }
        #endregion

        #region 更新对像

        /// <summary>
        /// 更新对像
        /// </summary>
        public static int EditProduct(EnProduct model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_product(");
                strSql.Append("attribute,title,shottitle,tcolor,sku,no,letter,categoryid,categorytitle,subcategoryidlist,subcategorytitlelist,brandid,brandtitle,brandsid,brandstitle,stylevalue,stylename,colorname,colorvalue,materialvalue,materialname,unit,localitycode,shipcode,customize,surface,logo,thumb,bannel,desimage,descript,tob2c,companyid,companyname,createmid,hits,sort,lastedid,lastedittime,auditstatus,linestatus,assemble,fid,shopid,homepageimg)");
                strSql.Append(" values (");
                strSql.Append("@attribute,@title,@shottitle,@tcolor,@sku,@no,@letter,@categoryid,@categorytitle,@subcategoryidlist,@subcategorytitlelist,@brandid,@brandtitle,@brandsid,@brandstitle,@stylevalue,@stylename,@colorname,@colorvalue,@materialvalue,@materialname,@unit,@localitycode,@shipcode,@customize,@surface,@logo,@thumb,@bannel,@desimage,@descript,@tob2c,@companyid,@companyname,@createmid,@hits,@sort,@lastedid,@lastedittime,@auditstatus,@linestatus,@assemble,@fid,@shopid,@homepageimg)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@attribute", SqlDbType.VarChar,100),
					new SqlParameter("@title", SqlDbType.NVarChar,80),
					new SqlParameter("@shottitle", SqlDbType.NVarChar,20),
					new SqlParameter("@tcolor", SqlDbType.Char,7),
					new SqlParameter("@sku", SqlDbType.VarChar,50),
					new SqlParameter("@no", SqlDbType.VarChar,50),
					new SqlParameter("@letter", SqlDbType.VarChar,30),
					new SqlParameter("@categoryid", SqlDbType.Int,4),
					new SqlParameter("@categorytitle", SqlDbType.NVarChar,50),
					new SqlParameter("@subcategoryidlist", SqlDbType.VarChar,50),
					new SqlParameter("@subcategorytitlelist", SqlDbType.NVarChar,200),
					new SqlParameter("@brandid", SqlDbType.Int,4),
					new SqlParameter("@brandtitle", SqlDbType.NVarChar,50),
					new SqlParameter("@brandsid", SqlDbType.Int,4),
					new SqlParameter("@brandstitle", SqlDbType.NVarChar,50),
					new SqlParameter("@stylevalue", SqlDbType.NVarChar,50),
					new SqlParameter("@stylename", SqlDbType.NVarChar,50),
					new SqlParameter("@colorname", SqlDbType.NVarChar,50),
					new SqlParameter("@colorvalue", SqlDbType.NVarChar,50),
					new SqlParameter("@materialvalue", SqlDbType.NVarChar,50),
					new SqlParameter("@materialname", SqlDbType.NVarChar,50),
					new SqlParameter("@unit", SqlDbType.NVarChar,4),
					new SqlParameter("@localitycode", SqlDbType.VarChar,12),
					new SqlParameter("@shipcode", SqlDbType.VarChar,12),
					new SqlParameter("@customize", SqlDbType.Int,4),
					new SqlParameter("@surface", SqlDbType.VarChar,200),
					new SqlParameter("@logo", SqlDbType.VarChar,40),
					new SqlParameter("@thumb", SqlDbType.VarChar,40),
					new SqlParameter("@bannel", SqlDbType.VarChar,300),
					new SqlParameter("@desimage", SqlDbType.VarChar,400),
					new SqlParameter("@descript", SqlDbType.NVarChar,500),
					new SqlParameter("@tob2c", SqlDbType.VarChar,50),
					new SqlParameter("@companyid", SqlDbType.Int,4),
					new SqlParameter("@companyname", SqlDbType.NVarChar,50),
					new SqlParameter("@createmid", SqlDbType.Int,4),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@lastedid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@auditstatus", SqlDbType.Int,4),
					new SqlParameter("@linestatus", SqlDbType.Int,4),
                    new SqlParameter("@assemble", SqlDbType.Bit,4),
                    new SqlParameter("@fid", SqlDbType.Int,4),
                    new SqlParameter("@shopid", SqlDbType.Int,4),
                new SqlParameter("@homepageimg", SqlDbType.VarChar,100)
                                            };

                parameters[0].Value = model.attribute;
                parameters[1].Value = model.title;
                parameters[2].Value = model.shottitle;
                parameters[3].Value = model.tcolor;
                parameters[4].Value = model.sku;
                parameters[5].Value = model.no;
                parameters[6].Value = model.letter;
                parameters[7].Value = model.categoryid;
                parameters[8].Value = model.categorytitle;
                parameters[9].Value = model.subcategoryidlist;
                parameters[10].Value = model.subcategorytitlelist;
                parameters[11].Value = model.brandid;
                parameters[12].Value = model.brandtitle;
                parameters[13].Value = model.brandsid;
                parameters[14].Value = model.brandstitle;
                parameters[15].Value = model.stylevalue;
                parameters[16].Value = model.stylename;
                parameters[17].Value = model.colorname;
                parameters[18].Value = model.colorvalue;
                parameters[19].Value = model.materialvalue;
                parameters[20].Value = model.materialname;
                parameters[21].Value = model.unit;
                parameters[22].Value = model.localitycode;
                parameters[23].Value = model.shipcode;
                parameters[24].Value = model.customize;
                parameters[25].Value = model.surface;
                parameters[26].Value = model.logo;
                parameters[27].Value = model.thumb;
                parameters[28].Value = model.bannel;
                parameters[29].Value = model.desimage;
                parameters[30].Value = model.descript;
                parameters[31].Value = model.tob2c;
                parameters[32].Value = model.companyid;
                parameters[33].Value = model.companyname;
                parameters[34].Value = model.createmid;
                parameters[35].Value = model.hits;
                parameters[36].Value = model.sort;
                parameters[37].Value = model.lastedid;
                parameters[38].Value = model.lastedittime;
                parameters[39].Value = model.auditstatus;
                parameters[40].Value = model.linestatus;
                parameters[41].Value = model.assemble;
                parameters[42].Value = model.FID;
                parameters[43].Value = model.shopid;
                parameters[44].Value = model.HomePageImg;
                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_product set ");
                strSql.Append("attribute=@attribute,");
                strSql.Append("title=@title,");
                strSql.Append("shottitle=@shottitle,");
                strSql.Append("tcolor=@tcolor,");
                strSql.Append("sku=@sku,");
                strSql.Append("no=@no,");
                strSql.Append("letter=@letter,");
                strSql.Append("categoryid=@categoryid,");
                strSql.Append("categorytitle=@categorytitle,");
                strSql.Append("subcategoryidlist=@subcategoryidlist,");
                strSql.Append("subcategorytitlelist=@subcategorytitlelist,");
                strSql.Append("brandid=@brandid,");
                strSql.Append("brandtitle=@brandtitle,");
                strSql.Append("brandsid=@brandsid,");
                strSql.Append("brandstitle=@brandstitle,");
                strSql.Append("stylevalue=@stylevalue,");
                strSql.Append("stylename=@stylename,");
                strSql.Append("colorname=@colorname,");
                strSql.Append("colorvalue=@colorvalue,");
                strSql.Append("materialvalue=@materialvalue,");
                strSql.Append("materialname=@materialname,");
                strSql.Append("unit=@unit,");
                strSql.Append("localitycode=@localitycode,");
                strSql.Append("shipcode=@shipcode,");
                strSql.Append("customize=@customize,");
                strSql.Append("surface=@surface,");
                strSql.Append("logo=@logo,");
                strSql.Append("thumb=@thumb,");
                strSql.Append("bannel=@bannel,");
                strSql.Append("desimage=@desimage,");
                strSql.Append("descript=@descript,");
                strSql.Append("tob2c=@tob2c,");
                strSql.Append("companyid=@companyid,");
                strSql.Append("companyname=@companyname,");
                strSql.Append("createmid=@createmid,");
                strSql.Append("hits=@hits,");
                strSql.Append("sort=@sort,");
                strSql.Append("lastedid=@lastedid,");
                strSql.Append("lastedittime=@lastedittime,");
                strSql.Append("auditstatus=@auditstatus,");
                strSql.Append("linestatus=@linestatus,");
                strSql.Append("assemble=@assemble,");
                strSql.Append("shopid=@shopid,");
                strSql.Append("fid=@fid,");
                strSql.Append("homepageimg=@homepageimg");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@attribute", SqlDbType.VarChar,100),
					new SqlParameter("@title", SqlDbType.NVarChar,80),
					new SqlParameter("@shottitle", SqlDbType.NVarChar,20),
					new SqlParameter("@tcolor", SqlDbType.Char,7),
					new SqlParameter("@sku", SqlDbType.VarChar,50),
					new SqlParameter("@no", SqlDbType.VarChar,50),
					new SqlParameter("@letter", SqlDbType.VarChar,30),
					new SqlParameter("@categoryid", SqlDbType.Int,4),
					new SqlParameter("@categorytitle", SqlDbType.NVarChar,50),
					new SqlParameter("@subcategoryidlist", SqlDbType.VarChar,50),
					new SqlParameter("@subcategorytitlelist", SqlDbType.NVarChar,200),
					new SqlParameter("@brandid", SqlDbType.Int,4),
					new SqlParameter("@brandtitle", SqlDbType.NVarChar,50),
					new SqlParameter("@brandsid", SqlDbType.Int,4),
					new SqlParameter("@brandstitle", SqlDbType.NVarChar,50),
					new SqlParameter("@stylevalue", SqlDbType.NVarChar,50),
					new SqlParameter("@stylename", SqlDbType.NVarChar,50),
					new SqlParameter("@colorname", SqlDbType.NVarChar,50),
					new SqlParameter("@colorvalue", SqlDbType.NVarChar,50),
					new SqlParameter("@materialvalue", SqlDbType.NVarChar,50),
					new SqlParameter("@materialname", SqlDbType.NVarChar,50),
					new SqlParameter("@unit", SqlDbType.NVarChar,4),
					new SqlParameter("@localitycode", SqlDbType.VarChar,12),
					new SqlParameter("@shipcode", SqlDbType.VarChar,12),
					new SqlParameter("@customize", SqlDbType.Int,4),
					new SqlParameter("@surface", SqlDbType.VarChar,200),
					new SqlParameter("@logo", SqlDbType.VarChar,40),
					new SqlParameter("@thumb", SqlDbType.VarChar,40),
					new SqlParameter("@bannel", SqlDbType.VarChar,300),
					new SqlParameter("@desimage", SqlDbType.VarChar,400),
					new SqlParameter("@descript", SqlDbType.NVarChar,500),
					new SqlParameter("@tob2c", SqlDbType.VarChar,50),
					new SqlParameter("@companyid", SqlDbType.Int,4),
					new SqlParameter("@companyname", SqlDbType.NVarChar,50),
					new SqlParameter("@createmid", SqlDbType.Int,4),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@sort", SqlDbType.Int,4),
					new SqlParameter("@lastedid", SqlDbType.Int,4),
					new SqlParameter("@lastedittime", SqlDbType.DateTime),
					new SqlParameter("@auditstatus", SqlDbType.Int,4),
					new SqlParameter("@linestatus", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@assemble", SqlDbType.Bit,4),
                    new SqlParameter("@fid", SqlDbType.Int,4),
                    new SqlParameter("@shopid", SqlDbType.Int,4),
                    new SqlParameter("@homepageimg", SqlDbType.VarChar,100)
                                            };
                parameters[0].Value = model.attribute;
                parameters[1].Value = model.title;
                parameters[2].Value = model.shottitle;
                parameters[3].Value = model.tcolor;
                parameters[4].Value = model.sku;
                parameters[5].Value = model.no;
                parameters[6].Value = model.letter;
                parameters[7].Value = model.categoryid;
                parameters[8].Value = model.categorytitle;
                parameters[9].Value = model.subcategoryidlist;
                parameters[10].Value = model.subcategorytitlelist;
                parameters[11].Value = model.brandid;
                parameters[12].Value = model.brandtitle;
                parameters[13].Value = model.brandsid;
                parameters[14].Value = model.brandstitle;
                parameters[15].Value = model.stylevalue;
                parameters[16].Value = model.stylename;
                parameters[17].Value = model.colorname;
                parameters[18].Value = model.colorvalue;
                parameters[19].Value = model.materialvalue;
                parameters[20].Value = model.materialname;
                parameters[21].Value = model.unit;
                parameters[22].Value = model.localitycode;
                parameters[23].Value = model.shipcode;
                parameters[24].Value = model.customize;
                parameters[25].Value = model.surface;
                parameters[26].Value = model.logo;
                parameters[27].Value = model.thumb;
                parameters[28].Value = model.bannel;
                parameters[29].Value = model.desimage;
                parameters[30].Value = model.descript;
                parameters[31].Value = model.tob2c;
                parameters[32].Value = model.companyid;
                parameters[33].Value = model.companyname;
                parameters[34].Value = model.createmid;
                parameters[35].Value = model.hits;
                parameters[36].Value = model.sort;
                parameters[37].Value = model.lastedid;
                parameters[38].Value = model.lastedittime;
                parameters[39].Value = model.auditstatus;
                parameters[40].Value = model.linestatus;
                parameters[41].Value = model.id;
                parameters[42].Value = model.assemble;
                parameters[43].Value = model.FID;
                parameters[44].Value = model.shopid;
                parameters[45].Value = model.HomePageImg;
                if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    return model.id;
                }
            }

            return 0;

        }
        #endregion

        #region 得到一个对象实体

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnProduct GetProductInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_Product ");
            strSql.Append(strWhere);


            EnProduct model = new EnProduct();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["attribute"] != null && reader["attribute"].ToString() != "")
                {
                    model.attribute = reader["attribute"].ToString();
                }
                if (reader["title"] != null && reader["title"].ToString() != "")
                {
                    model.title = reader["title"].ToString();
                }
                if (reader["shottitle"] != null && reader["shottitle"].ToString() != "")
                {
                    model.shottitle = reader["shottitle"].ToString();
                }
                if (reader["tcolor"] != null && reader["tcolor"].ToString() != "")
                {
                    model.tcolor = reader["tcolor"].ToString();
                }
                if (reader["sku"] != null && reader["sku"].ToString() != "")
                {
                    model.sku = reader["sku"].ToString();
                }
                if (reader["no"] != null && reader["no"].ToString() != "")
                {
                    model.no = reader["no"].ToString();
                }
                if (reader["letter"] != null && reader["letter"].ToString() != "")
                {
                    model.letter = reader["letter"].ToString();
                }
                if (reader["categoryid"] != null && reader["categoryid"].ToString() != "")
                {
                    model.categoryid = int.Parse(reader["categoryid"].ToString());
                }
                if (reader["categorytitle"] != null && reader["categorytitle"].ToString() != "")
                {
                    model.categorytitle = reader["categorytitle"].ToString();
                }
                if (reader["subcategoryidlist"] != null && reader["subcategoryidlist"].ToString() != "")
                {
                    model.subcategoryidlist = reader["subcategoryidlist"].ToString();
                }
                if (reader["subcategorytitlelist"] != null && reader["subcategorytitlelist"].ToString() != "")
                {
                    model.subcategorytitlelist = reader["subcategorytitlelist"].ToString();
                }
                if (reader["brandid"] != null && reader["brandid"].ToString() != "")
                {
                    model.brandid = int.Parse(reader["brandid"].ToString());
                }
                if (reader["brandtitle"] != null && reader["brandtitle"].ToString() != "")
                {
                    model.brandtitle = reader["brandtitle"].ToString();
                }
                if (reader["brandsid"] != null && reader["brandsid"].ToString() != "")
                {
                    model.brandsid = int.Parse(reader["brandsid"].ToString());
                }
                if (reader["brandstitle"] != null && reader["brandstitle"].ToString() != "")
                {
                    model.brandstitle = reader["brandstitle"].ToString();
                }
                if (reader["stylevalue"] != null && reader["stylevalue"].ToString() != "")
                {
                    model.stylevalue = reader["stylevalue"].ToString();
                }
                if (reader["stylename"] != null && reader["stylename"].ToString() != "")
                {
                    model.stylename = reader["stylename"].ToString();
                }
                if (reader["colorname"] != null && reader["colorname"].ToString() != "")
                {
                    model.colorname = reader["colorname"].ToString();
                }
                if (reader["colorvalue"] != null && reader["colorvalue"].ToString() != "")
                {
                    model.colorvalue = reader["colorvalue"].ToString();
                }
                if (reader["materialvalue"] != null && reader["materialvalue"].ToString() != "")
                {
                    model.materialvalue = reader["materialvalue"].ToString();
                }
                if (reader["materialname"] != null && reader["materialname"].ToString() != "")
                {
                    model.materialname = reader["materialname"].ToString();
                }
                if (reader["unit"] != null && reader["unit"].ToString() != "")
                {
                    model.unit = reader["unit"].ToString();
                }
                if (reader["localitycode"] != null && reader["localitycode"].ToString() != "")
                {
                    model.localitycode = reader["localitycode"].ToString();
                }
                if (reader["shipcode"] != null && reader["shipcode"].ToString() != "")
                {
                    model.shipcode = reader["shipcode"].ToString();
                }
                if (reader["customize"] != null && reader["customize"].ToString() != "")
                {
                    model.customize = int.Parse(reader["customize"].ToString());
                }
                if (reader["surface"] != null && reader["surface"].ToString() != "")
                {
                    model.surface = reader["surface"].ToString();
                }
                if (reader["logo"] != null && reader["logo"].ToString() != "")
                {
                    model.logo = reader["logo"].ToString();
                }
                if (reader["thumb"] != null && reader["thumb"].ToString() != "")
                {
                    model.thumb = reader["thumb"].ToString();
                }
                if (reader["bannel"] != null && reader["bannel"].ToString() != "")
                {
                    model.bannel = reader["bannel"].ToString();
                }
                if (reader["desimage"] != null && reader["desimage"].ToString() != "")
                {
                    model.desimage = reader["desimage"].ToString();
                }
                if (reader["descript"] != null && reader["descript"].ToString() != "")
                {
                    model.descript = reader["descript"].ToString();
                }
                if (reader["tob2c"] != null && reader["tob2c"].ToString() != "")
                {
                    model.tob2c = reader["tob2c"].ToString();
                }
                if (reader["companyid"] != null && reader["companyid"].ToString() != "")
                {
                    model.companyid = int.Parse(reader["companyid"].ToString());
                }
                if (reader["companyname"] != null && reader["companyname"].ToString() != "")
                {
                    model.companyname = reader["companyname"].ToString();
                }
                if (reader["createmid"] != null && reader["createmid"].ToString() != "")
                {
                    model.createmid = int.Parse(reader["createmid"].ToString());
                }
                if (reader["hits"] != null && reader["hits"].ToString() != "")
                {
                    model.hits = int.Parse(reader["hits"].ToString());
                }
                if (reader["sort"] != null && reader["sort"].ToString() != "")
                {
                    model.sort = int.Parse(reader["sort"].ToString());
                }
                if (reader["lastedid"] != null && reader["lastedid"].ToString() != "")
                {
                    model.lastedid = int.Parse(reader["lastedid"].ToString());
                }
                if (reader["lastedittime"] != null && reader["lastedittime"].ToString() != "")
                {
                    model.lastedittime = DateTime.Parse(reader["lastedittime"].ToString());
                }
                if (reader["auditstatus"] != null && reader["auditstatus"].ToString() != "")
                {
                    model.auditstatus = int.Parse(reader["auditstatus"].ToString());
                }
                if (reader["linestatus"] != null && reader["linestatus"].ToString() != "")
                {
                    model.linestatus = int.Parse(reader["linestatus"].ToString());
                }
                if (reader["assemble"] != null && reader["assemble"].ToString() != "")
                {
                    model.assemble = bool.Parse(reader["assemble"].ToString());
                }
                if (reader["FID"] != null && reader["FID"].ToString() != "")
                {
                    model.FID = int.Parse(reader["FID"].ToString());
                }
                if (reader["shopid"] != null && reader["shopid"].ToString() != "")
                {
                    model.shopid = int.Parse(reader["shopid"].ToString());
                }
                if (reader["homepageimg"] != null && reader["homepageimg"].ToString() != "")
                {
                    model.HomePageImg = reader["homepageimg"].ToString();
                }
                reader.Close();
                if (!reader.IsClosed)
                {
                    reader.Close();
                }
                return model;
            }
            else
            {
                reader.Close();
                if (!reader.IsClosed)
                {
                    reader.Close();
                }

                return null;
            }
        }
        #endregion

        #region 获得数据列表

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnProduct> GetproductrecyclerecycleList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnProduct> modelList = new List<EnProduct>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBproductrecyclerecycle, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnProduct model;
                #region model赋值

                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnProduct();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["attribute"] != null && dt.Rows[n]["attribute"].ToString() != "")
                    {
                        model.attribute = dt.Rows[n]["attribute"].ToString();
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["shottitle"] != null && dt.Rows[n]["shottitle"].ToString() != "")
                    {
                        model.shottitle = dt.Rows[n]["shottitle"].ToString();
                    }
                    if (dt.Rows[n]["tcolor"] != null && dt.Rows[n]["tcolor"].ToString() != "")
                    {
                        model.tcolor = dt.Rows[n]["tcolor"].ToString();
                    }
                    if (dt.Rows[n]["sku"] != null && dt.Rows[n]["sku"].ToString() != "")
                    {
                        model.sku = dt.Rows[n]["sku"].ToString();
                    }
                    if (dt.Rows[n]["no"] != null && dt.Rows[n]["no"].ToString() != "")
                    {
                        model.no = dt.Rows[n]["no"].ToString();
                    }
                    if (dt.Rows[n]["letter"] != null && dt.Rows[n]["letter"].ToString() != "")
                    {
                        model.letter = dt.Rows[n]["letter"].ToString();
                    }
                    if (dt.Rows[n]["categoryid"] != null && dt.Rows[n]["categoryid"].ToString() != "")
                    {
                        model.categoryid = int.Parse(dt.Rows[n]["categoryid"].ToString());
                    }
                    if (dt.Rows[n]["categorytitle"] != null && dt.Rows[n]["categorytitle"].ToString() != "")
                    {
                        model.categorytitle = dt.Rows[n]["categorytitle"].ToString();
                    }
                    if (dt.Rows[n]["subcategoryidlist"] != null && dt.Rows[n]["subcategoryidlist"].ToString() != "")
                    {
                        model.subcategoryidlist = dt.Rows[n]["subcategoryidlist"].ToString();
                    }
                    if (dt.Rows[n]["subcategorytitlelist"] != null && dt.Rows[n]["subcategorytitlelist"].ToString() != "")
                    {
                        model.subcategorytitlelist = dt.Rows[n]["subcategorytitlelist"].ToString();
                    }
                    if (dt.Rows[n]["brandid"] != null && dt.Rows[n]["brandid"].ToString() != "")
                    {
                        model.brandid = int.Parse(dt.Rows[n]["brandid"].ToString());
                    }
                    if (dt.Rows[n]["brandtitle"] != null && dt.Rows[n]["brandtitle"].ToString() != "")
                    {
                        model.brandtitle = dt.Rows[n]["brandtitle"].ToString();
                    }
                    if (dt.Rows[n]["brandsid"] != null && dt.Rows[n]["brandsid"].ToString() != "")
                    {
                        model.brandsid = int.Parse(dt.Rows[n]["brandsid"].ToString());
                    }
                    if (dt.Rows[n]["brandstitle"] != null && dt.Rows[n]["brandstitle"].ToString() != "")
                    {
                        model.brandstitle = dt.Rows[n]["brandstitle"].ToString();
                    }
                    if (dt.Rows[n]["stylevalue"] != null && dt.Rows[n]["stylevalue"].ToString() != "")
                    {
                        model.stylevalue = dt.Rows[n]["stylevalue"].ToString();
                    }
                    if (dt.Rows[n]["stylename"] != null && dt.Rows[n]["stylename"].ToString() != "")
                    {
                        model.stylename = dt.Rows[n]["stylename"].ToString();
                    }
                    if (dt.Rows[n]["colorname"] != null && dt.Rows[n]["colorname"].ToString() != "")
                    {
                        model.colorname = dt.Rows[n]["colorname"].ToString();
                    }
                    if (dt.Rows[n]["colorvalue"] != null && dt.Rows[n]["colorvalue"].ToString() != "")
                    {
                        model.colorvalue = dt.Rows[n]["colorvalue"].ToString();
                    }
                    if (dt.Rows[n]["materialvalue"] != null && dt.Rows[n]["materialvalue"].ToString() != "")
                    {
                        model.materialvalue = dt.Rows[n]["materialvalue"].ToString();
                    }
                    if (dt.Rows[n]["materialname"] != null && dt.Rows[n]["materialname"].ToString() != "")
                    {
                        model.materialname = dt.Rows[n]["materialname"].ToString();
                    }
                    if (dt.Rows[n]["unit"] != null && dt.Rows[n]["unit"].ToString() != "")
                    {
                        model.unit = dt.Rows[n]["unit"].ToString();
                    }
                    if (dt.Rows[n]["localitycode"] != null && dt.Rows[n]["localitycode"].ToString() != "")
                    {
                        model.localitycode = dt.Rows[n]["localitycode"].ToString();
                    }
                    if (dt.Rows[n]["shipcode"] != null && dt.Rows[n]["shipcode"].ToString() != "")
                    {
                        model.shipcode = dt.Rows[n]["shipcode"].ToString();
                    }
                    if (dt.Rows[n]["customize"] != null && dt.Rows[n]["customize"].ToString() != "")
                    {
                        model.customize = int.Parse(dt.Rows[n]["customize"].ToString());
                    }
                    if (dt.Rows[n]["surface"] != null && dt.Rows[n]["surface"].ToString() != "")
                    {
                        model.surface = dt.Rows[n]["surface"].ToString();
                    }
                    if (dt.Rows[n]["logo"] != null && dt.Rows[n]["logo"].ToString() != "")
                    {
                        model.logo = dt.Rows[n]["logo"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["bannel"] != null && dt.Rows[n]["bannel"].ToString() != "")
                    {
                        model.bannel = dt.Rows[n]["bannel"].ToString();
                    }
                    if (dt.Rows[n]["desimage"] != null && dt.Rows[n]["desimage"].ToString() != "")
                    {
                        model.desimage = dt.Rows[n]["desimage"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["tob2c"] != null && dt.Rows[n]["tob2c"].ToString() != "")
                    {
                        model.tob2c = dt.Rows[n]["tob2c"].ToString();
                    }
                    if (dt.Rows[n]["companyid"] != null && dt.Rows[n]["companyid"].ToString() != "")
                    {
                        model.companyid = int.Parse(dt.Rows[n]["companyid"].ToString());
                    }
                    if (dt.Rows[n]["companyname"] != null && dt.Rows[n]["companyname"].ToString() != "")
                    {
                        model.companyname = dt.Rows[n]["companyname"].ToString();
                    }
                    if (dt.Rows[n]["createmid"] != null && dt.Rows[n]["createmid"].ToString() != "")
                    {
                        model.createmid = int.Parse(dt.Rows[n]["createmid"].ToString());
                    }
                    if (dt.Rows[n]["hits"] != null && dt.Rows[n]["hits"].ToString() != "")
                    {
                        model.hits = int.Parse(dt.Rows[n]["hits"].ToString());
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    if (dt.Rows[n]["lastedid"] != null && dt.Rows[n]["lastedid"].ToString() != "")
                    {
                        model.lastedid = int.Parse(dt.Rows[n]["lastedid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["Createtime"] != null && dt.Rows[n]["Createtime"].ToString() != "")
                    {
                        model.createtime = DateTime.Parse(dt.Rows[n]["Createtime"].ToString());
                    }

                    if (dt.Rows[n]["auditstatus"] != null && dt.Rows[n]["auditstatus"].ToString() != "")
                    {
                        model.auditstatus = int.Parse(dt.Rows[n]["auditstatus"].ToString());
                    }
                    if (dt.Rows[n]["linestatus"] != null && dt.Rows[n]["linestatus"].ToString() != "")
                    {
                        model.linestatus = int.Parse(dt.Rows[n]["linestatus"].ToString());
                    }
                    if (dt.Rows[n]["assemble"] != null && dt.Rows[n]["assemble"].ToString() != "")
                    {
                        model.assemble = bool.Parse(dt.Rows[n]["assemble"].ToString());
                    }
                    if (dt.Rows[n]["FID"] != null && dt.Rows[n]["FID"].ToString() != "")
                    {
                        model.FID = int.Parse(dt.Rows[n]["FID"].ToString());
                    }

                    if (dt.Rows[n]["shopid"] != null && dt.Rows[n]["shopid"].ToString() != "")
                    {
                        model.shopid = int.Parse(dt.Rows[n]["shopid"].ToString());
                    }
                    modelList.Add(model);
                #endregion

                }
            }
            return modelList;
        }
        #endregion

        #region 获得数据列表

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnProduct> GetProductList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnProduct> modelList = new List<EnProduct>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBProduct, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnProduct model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnProduct();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["attribute"] != null && dt.Rows[n]["attribute"].ToString() != "")
                    {
                        model.attribute = dt.Rows[n]["attribute"].ToString();
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["shottitle"] != null && dt.Rows[n]["shottitle"].ToString() != "")
                    {
                        model.shottitle = dt.Rows[n]["shottitle"].ToString();
                    }
                    if (dt.Rows[n]["tcolor"] != null && dt.Rows[n]["tcolor"].ToString() != "")
                    {
                        model.tcolor = dt.Rows[n]["tcolor"].ToString();
                    }
                    if (dt.Rows[n]["sku"] != null && dt.Rows[n]["sku"].ToString() != "")
                    {
                        model.sku = dt.Rows[n]["sku"].ToString();
                    }
                    if (dt.Rows[n]["no"] != null && dt.Rows[n]["no"].ToString() != "")
                    {
                        model.no = dt.Rows[n]["no"].ToString();
                    }
                    if (dt.Rows[n]["letter"] != null && dt.Rows[n]["letter"].ToString() != "")
                    {
                        model.letter = dt.Rows[n]["letter"].ToString();
                    }
                    if (dt.Rows[n]["categoryid"] != null && dt.Rows[n]["categoryid"].ToString() != "")
                    {
                        model.categoryid = int.Parse(dt.Rows[n]["categoryid"].ToString());
                    }
                    if (dt.Rows[n]["categorytitle"] != null && dt.Rows[n]["categorytitle"].ToString() != "")
                    {
                        model.categorytitle = dt.Rows[n]["categorytitle"].ToString();
                    }
                    if (dt.Rows[n]["subcategoryidlist"] != null && dt.Rows[n]["subcategoryidlist"].ToString() != "")
                    {
                        model.subcategoryidlist = dt.Rows[n]["subcategoryidlist"].ToString();
                    }
                    if (dt.Rows[n]["subcategorytitlelist"] != null && dt.Rows[n]["subcategorytitlelist"].ToString() != "")
                    {
                        model.subcategorytitlelist = dt.Rows[n]["subcategorytitlelist"].ToString();
                    }
                    if (dt.Rows[n]["brandid"] != null && dt.Rows[n]["brandid"].ToString() != "")
                    {
                        model.brandid = int.Parse(dt.Rows[n]["brandid"].ToString());
                    }
                    if (dt.Rows[n]["brandtitle"] != null && dt.Rows[n]["brandtitle"].ToString() != "")
                    {
                        model.brandtitle = dt.Rows[n]["brandtitle"].ToString();
                    }
                    if (dt.Rows[n]["brandsid"] != null && dt.Rows[n]["brandsid"].ToString() != "")
                    {
                        model.brandsid = int.Parse(dt.Rows[n]["brandsid"].ToString());
                    }
                    if (dt.Rows[n]["brandstitle"] != null && dt.Rows[n]["brandstitle"].ToString() != "")
                    {
                        model.brandstitle = dt.Rows[n]["brandstitle"].ToString();
                    }
                    if (dt.Rows[n]["stylevalue"] != null && dt.Rows[n]["stylevalue"].ToString() != "")
                    {
                        model.stylevalue = dt.Rows[n]["stylevalue"].ToString();
                    }
                    if (dt.Rows[n]["stylename"] != null && dt.Rows[n]["stylename"].ToString() != "")
                    {
                        model.stylename = dt.Rows[n]["stylename"].ToString();
                    }
                    if (dt.Rows[n]["colorname"] != null && dt.Rows[n]["colorname"].ToString() != "")
                    {
                        model.colorname = dt.Rows[n]["colorname"].ToString();
                    }
                    if (dt.Rows[n]["colorvalue"] != null && dt.Rows[n]["colorvalue"].ToString() != "")
                    {
                        model.colorvalue = dt.Rows[n]["colorvalue"].ToString();
                    }
                    if (dt.Rows[n]["materialvalue"] != null && dt.Rows[n]["materialvalue"].ToString() != "")
                    {
                        model.materialvalue = dt.Rows[n]["materialvalue"].ToString();
                    }
                    if (dt.Rows[n]["materialname"] != null && dt.Rows[n]["materialname"].ToString() != "")
                    {
                        model.materialname = dt.Rows[n]["materialname"].ToString();
                    }
                    if (dt.Rows[n]["unit"] != null && dt.Rows[n]["unit"].ToString() != "")
                    {
                        model.unit = dt.Rows[n]["unit"].ToString();
                    }
                    if (dt.Rows[n]["localitycode"] != null && dt.Rows[n]["localitycode"].ToString() != "")
                    {
                        model.localitycode = dt.Rows[n]["localitycode"].ToString();
                    }
                    if (dt.Rows[n]["shipcode"] != null && dt.Rows[n]["shipcode"].ToString() != "")
                    {
                        model.shipcode = dt.Rows[n]["shipcode"].ToString();
                    }
                    if (dt.Rows[n]["customize"] != null && dt.Rows[n]["customize"].ToString() != "")
                    {
                        model.customize = int.Parse(dt.Rows[n]["customize"].ToString());
                    }
                    if (dt.Rows[n]["surface"] != null && dt.Rows[n]["surface"].ToString() != "")
                    {
                        model.surface = dt.Rows[n]["surface"].ToString();
                    }
                    if (dt.Rows[n]["logo"] != null && dt.Rows[n]["logo"].ToString() != "")
                    {
                        model.logo = dt.Rows[n]["logo"].ToString();
                    }
                    if (dt.Rows[n]["thumb"] != null && dt.Rows[n]["thumb"].ToString() != "")
                    {
                        model.thumb = dt.Rows[n]["thumb"].ToString();
                    }
                    if (dt.Rows[n]["bannel"] != null && dt.Rows[n]["bannel"].ToString() != "")
                    {
                        model.bannel = dt.Rows[n]["bannel"].ToString();
                    }
                    if (dt.Rows[n]["desimage"] != null && dt.Rows[n]["desimage"].ToString() != "")
                    {
                        model.desimage = dt.Rows[n]["desimage"].ToString();
                    }
                    if (dt.Rows[n]["descript"] != null && dt.Rows[n]["descript"].ToString() != "")
                    {
                        model.descript = dt.Rows[n]["descript"].ToString();
                    }
                    if (dt.Rows[n]["tob2c"] != null && dt.Rows[n]["tob2c"].ToString() != "")
                    {
                        model.tob2c = dt.Rows[n]["tob2c"].ToString();
                    }
                    if (dt.Rows[n]["companyid"] != null && dt.Rows[n]["companyid"].ToString() != "")
                    {
                        model.companyid = int.Parse(dt.Rows[n]["companyid"].ToString());
                    }
                    if (dt.Rows[n]["companyname"] != null && dt.Rows[n]["companyname"].ToString() != "")
                    {
                        model.companyname = dt.Rows[n]["companyname"].ToString();
                    }
                    if (dt.Rows[n]["createmid"] != null && dt.Rows[n]["createmid"].ToString() != "")
                    {
                        model.createmid = int.Parse(dt.Rows[n]["createmid"].ToString());
                    }
                    if (dt.Rows[n]["hits"] != null && dt.Rows[n]["hits"].ToString() != "")
                    {
                        model.hits = int.Parse(dt.Rows[n]["hits"].ToString());
                    }
                    if (dt.Rows[n]["sort"] != null && dt.Rows[n]["sort"].ToString() != "")
                    {
                        model.sort = int.Parse(dt.Rows[n]["sort"].ToString());
                    }
                    if (dt.Rows[n]["lastedid"] != null && dt.Rows[n]["lastedid"].ToString() != "")
                    {
                        model.lastedid = int.Parse(dt.Rows[n]["lastedid"].ToString());
                    }
                    if (dt.Rows[n]["lastedittime"] != null && dt.Rows[n]["lastedittime"].ToString() != "")
                    {
                        model.lastedittime = DateTime.Parse(dt.Rows[n]["lastedittime"].ToString());
                    }
                    if (dt.Rows[n]["Createtime"] != null && dt.Rows[n]["Createtime"].ToString() != "")
                    {
                        model.createtime = DateTime.Parse(dt.Rows[n]["Createtime"].ToString());
                    }

                    if (dt.Rows[n]["auditstatus"] != null && dt.Rows[n]["auditstatus"].ToString() != "")
                    {
                        model.auditstatus = int.Parse(dt.Rows[n]["auditstatus"].ToString());
                    }
                    if (dt.Rows[n]["linestatus"] != null && dt.Rows[n]["linestatus"].ToString() != "")
                    {
                        model.linestatus = int.Parse(dt.Rows[n]["linestatus"].ToString());
                    }
                    if (dt.Rows[n]["assemble"] != null && dt.Rows[n]["assemble"].ToString() != "")
                    {
                        model.assemble = bool.Parse(dt.Rows[n]["assemble"].ToString());
                    }
                    if (dt.Rows[n]["FID"] != null && dt.Rows[n]["FID"].ToString() != "")
                    {
                        model.FID = int.Parse(dt.Rows[n]["FID"].ToString());
                    }
                    if (dt.Rows[n]["shopid"] != null && dt.Rows[n]["shopid"].ToString() != "")
                    {
                        model.shopid = int.Parse(dt.Rows[n]["shopid"].ToString());
                    }
                    if (dt.Rows[n]["homepageimg"] != null && dt.Rows[n]["homepageimg"].ToString() != "")
                    {
                        model.HomePageImg = dt.Rows[n]["homepageimg"].ToString();
                    }
                    //if (dt.Rows[n]["ShopName"] != null && dt.Rows[n]["ShopName"].ToString() != "")
                    //{
                    //    model.shopName = dt.Rows[n]["ShopName"].ToString();
                    //}
                    model.sale = 0;//后期如果有订单，可以根据订单获取销量
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region 产品内容
        public static int EditProductCon(EnProductCon model)
        {
            if (model.id == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_productcon(");
                strSql.Append("productid,contype,con)");
                strSql.Append(" values (");
                strSql.Append("@productid,@contype,@con)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@productid", SqlDbType.Int,4),
					new SqlParameter("@contype", SqlDbType.Int,4),
					new SqlParameter("@con", SqlDbType.NText)};
                parameters[0].Value = model.productid;
                parameters[1].Value = model.contype;
                parameters[2].Value = model.con;


                object obj = DbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
                if (obj != null)
                {
                    return TypeConverter.ObjectToInt(obj);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_productcon set ");
                strSql.Append("productid=@productid,");
                strSql.Append("contype=@contype,");
                strSql.Append("con=@con");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@productid", SqlDbType.Int,4),
					new SqlParameter("@contype", SqlDbType.Int,4),
					new SqlParameter("@con", SqlDbType.NText),
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters[0].Value = model.productid;
                parameters[1].Value = model.contype;
                parameters[2].Value = model.con;
                parameters[3].Value = model.id;

                if (DbHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters) > 0)
                {
                    return model.id;
                }
            }

            return 0;

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static EnProductCon GetProductConInfo(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from t_ProductCon ");
            strSql.Append(strWhere);


            EnProductCon model = new EnProductCon();
            IDataReader reader = DbHelper.ExecuteReader(CommandType.Text, strSql.ToString());

            if (reader.Read())
            {
                if (reader["id"] != null && reader["id"].ToString() != "")
                {
                    model.id = int.Parse(reader["id"].ToString());
                }
                if (reader["productid"] != null && reader["productid"].ToString() != "")
                {
                    model.productid = int.Parse(reader["productid"].ToString());
                }
                if (reader["contype"] != null && reader["contype"].ToString() != "")
                {
                    model.contype = int.Parse(reader["contype"].ToString());
                }
                if (reader["con"] != null && reader["con"].ToString() != "")
                {
                    model.con = reader["con"].ToString();
                }

                reader.Close();
                if (!reader.IsClosed)
                {
                    reader.Close();
                }
                return model;
            }
            else
            {
                reader.Close();
                if (!reader.IsClosed)
                {
                    reader.Close();
                }

                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<EnProductCon> GetProductConList(int PageIndex, int PageSize, string strWhere, out int pageCount)
        {
            List<EnProductCon> modelList = new List<EnProductCon>();
            DataTable dt = DataCommon.GetPageDataTable(TableName.TBProductCon, PageIndex, PageSize, strWhere, "", 1, out pageCount);
            if (dt.Rows.Count > 0)
            {
                EnProductCon model;
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    model = new EnProductCon();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["productid"] != null && dt.Rows[n]["productid"].ToString() != "")
                    {
                        model.productid = int.Parse(dt.Rows[n]["productid"].ToString());
                    }
                    if (dt.Rows[n]["contype"] != null && dt.Rows[n]["contype"].ToString() != "")
                    {
                        model.contype = int.Parse(dt.Rows[n]["contype"].ToString());
                    }
                    if (dt.Rows[n]["con"] != null && dt.Rows[n]["con"].ToString() != "")
                    {
                        model.con = dt.Rows[n]["con"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion

        #region 首页有效数据统计
        public static List<Hashtable> GetIndexCount()
        {
            List<Hashtable> list = new List<Hashtable>();
            IDataReader reader = DbHelper.ExecuteReader("select (select count(0) from v_companylistByB) as bcount,(select count(0) from t_company  where auditstatus=1 and linestatus=1) as ccount,(select count(0) from t_dealer where auditstatus=1 and linestatus=1) as dcount,(select count(0) from t_market where auditstatus=1 and linestatus=1) as mcount,count(1) as pcount from v_product");
            while (reader.Read())
            {
                Hashtable model = new Hashtable();
                if (reader["bcount"] != null && reader["bcount"].ToString() != "")
                {
                    model["bcount"] = reader["bcount"].ToString();
                }
                if (reader["ccount"] != null && reader["ccount"].ToString() != "")
                {
                    model["ccount"] = reader["ccount"].ToString();
                }
                if (reader["dcount"] != null && reader["dcount"].ToString() != "")
                {
                    model["dcount"] = reader["dcount"].ToString();
                }
                if (reader["mcount"] != null && reader["mcount"].ToString() != "")
                {
                    model["mcount"] = reader["mcount"].ToString();
                }
                if (reader["pcount"] != null && reader["pcount"].ToString() != "")
                {
                    model["pcount"] = reader["pcount"].ToString();
                }
                list.Add(model);
            }
            if (!reader.IsClosed)
                reader.Close();
            return list;
        }
        #endregion


        /// <summary>
        /// 小类对应的属性
        /// </summary>
        /// <returns></returns>
        public static List<producttype> GetProductType()
        {
            List<producttype> list = new List<producttype>();
            try
            {
                DataSet ds = DbHelper.ExecuteDataset(CommandType.Text, "exec proc_producttype ");

                DataTable dt = ds.Tables[0];

                producttype pt;
                foreach (DataRow dr in dt.Rows)
                {
                    pt = new producttype();
                    pt.tp2id = DBNull.Value == dr["id"] ? default(int) : Convert.ToInt32(dr["id"]);
                    pt.tp2title = DBNull.Value == dr["title"] ? default(string) : Convert.ToString(dr["title"]);
                    pt.tpshow = DBNull.Value == dr["isshow"] ? default(int) : Convert.ToInt32(dr["isshow"]);
                    list.Add(pt);
                }
                dt = ds.Tables[1];
                DataTable dttemp = ds.Tables[2];
                foreach (producttype item in list)
                {
                    DataRow[] dr = dt.Select(" parentid =  " + item.tp2id);

                    foreach (DataRow row in dr)
                    {
                        pt = new producttype();
                        pt.tpid = DBNull.Value == row["id"] ? default(int) : Convert.ToInt32(row["id"]);
                        pt.tptitle = DBNull.Value == row["title"] ? default(string) : Convert.ToString(row["title"]);
                        pt.tp2id = DBNull.Value == row["parentid"] ? default(int) : Convert.ToInt32(row["parentid"]);
                        pt.tpshow = DBNull.Value == row["isshow"] ? default(int) : Convert.ToInt32(row["isshow"]);
                        pt.ptype = DBNull.Value == row["ptype"] ? default(int) : Convert.ToInt32(row["ptype"]);
                        //DataRow[] dr2 = dttemp.Select(" tp2id =" + pt.tp2id + "  AND tpid =  " + pt.tpid);


                        item.listxl.Add(pt);
                    }

                    foreach (DataRow dr3 in dttemp.Rows)
                    {
                        tconfigtype tp = new tconfigtype();
                        tp.cid = DBNull.Value == dr3["cid"] ? default(string) : Convert.ToString(dr3["cid"]);
                        tp.ctitle = DBNull.Value == dr3["ctitle"] ? default(string) : dr3["ctitle"].ToString();

                        tp.cttitle = DBNull.Value == dr3["cttitle"] ? default(string) : Convert.ToString(dr3["cttitle"]);
                        tp.cttype = DBNull.Value == dr3["cttype"] ? default(string) : Convert.ToString(dr3["cttype"]);
                        tp.id = DBNull.Value == dr3["id"] ? default(int) : Convert.ToInt32(dr3["id"]);
                        tp.tpshow = DBNull.Value == dr3["isshow"] ? default(int) : Convert.ToInt32(dr3["isshow"]);

                        item.listtconfigtype.Add(tp);
                    }

                }



            }
            catch (Exception err)
            {
            }
            return list;
        }
        /// <summary>
        /// 获取所有属性
        /// </summary>
        /// <returns></returns>
        public static List<producttype> GetProductTypeAll()
        {
            List<producttype> list = new List<producttype>();
            try
            {
                DataTable dttemp = DbHelper.ExecuteDataset(CommandType.Text, "exec proc_configtype_product ").Tables[0];

                producttype pt;
                foreach (DataRow dr1 in dttemp.Rows)
                {
                    producttype pt2 = new producttype();
                    pt2.configtitle = DBNull.Value == dr1["configtitle"] ? default(string) : dr1["configtitle"].ToString();
                    pt2.configtype = DBNull.Value == dr1["configtype"] ? default(string) : dr1["configtype"].ToString();
                    pt2.configtypeid = DBNull.Value == dr1["configtypeid"] ? default(string) : dr1["configtypeid"].ToString();
                    pt2.configtypetitle = DBNull.Value == dr1["configtypetitle"] ? default(string) : dr1["configtypetitle"].ToString();
                    pt2.tpid = DBNull.Value == dr1["tpid"] ? default(int) : Convert.ToInt32(dr1["tpid"]);
                    pt2.tptitle = DBNull.Value == dr1["tptitle"] ? default(string) : dr1["tptitle"].ToString();
                    pt2.value = DBNull.Value == dr1["value"] ? default(string) : dr1["value"].ToString();
                    pt2.tp2id = DBNull.Value == dr1["tp2id"] ? default(int) : Convert.ToInt32(dr1["tp2id"]);
                    pt2.tp2title = DBNull.Value == dr1["tp2title"] ? default(string) : dr1["tp2title"].ToString();
                    pt2.configid = DBNull.Value == dr1["configid"] ? default(string) : dr1["configid"].ToString();
                    pt2.configshow = DBNull.Value == dr1["configshow"] ? default(int) : Convert.ToInt32(dr1["configshow"]);
                    pt2.tpshow = DBNull.Value == dr1["tpshow"] ? default(int) : Convert.ToInt32(dr1["tpshow"]);
                    pt2.parentid = DBNull.Value == dr1["parentid"] ? default(int) : Convert.ToInt32(dr1["parentid"]);
                    pt2.ptype = DBNull.Value == dr1["ptype"] ? default(int) : Convert.ToInt32(dr1["ptype"]);
                    list.Add(pt2);

                }
            }
            catch (Exception err)
            {
            }
            return list;
        }
        /// <summary>
        /// 复制所有店铺数据
        /// </summary>
        /// <returns></returns>
        public static DataTable copyShopproduct(string where)
        {
            string sql = "SELECT s.*,b.companyid,b.title FROM t_shopbrand s LEFT JOIN dbo.t_brand b ON s.brandid=b.id where 1=1  " + where;

            return DbHelper.ExecuteDataset(sql).Tables[0];
        }
    }
}
