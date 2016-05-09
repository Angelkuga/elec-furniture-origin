using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using TREC.Entity;
using TREC.ECommerce;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;
using System.Text.RegularExpressions;
using System.Collections;


namespace TREC.Web.ajax
{
    /// <summary>
    /// shen 2015-02-04
    /// </summary>
    public class hdsearch : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var type = context.Request.QueryString["t"];


            switch (type.ToLower())
            {
                case "hd":
                    Searchhd(context);
                    break;
                case "hdnew":
                    SearchhdNew(context);
                    break;
                case "tbb":
                    Searchtbb(context);
                    break;
                case "tzh":
                    Searchtzh(context);
                    break;
                case "ncp":
                    Searchproduct(context);
                    break;
                case "pp":
                    SearchBrand(context);
                    break;
                case "tbbl":
                    Searchproducttbb(context);
                    break;
                case "tzhl":
                    Searchtzhl(context);
                    break;
                case "tjcp":
                    RecommendProduct(context);
                    break;
                case "tjtzh":
                    RecommendProducttzh(context);
                    break;
            }

        }
        /// <summary>
        /// 套组合产品列表中左边下角推荐产品
        /// </summary>
        /// <param name="context"></param>
        private void RecommendProducttzh(HttpContext context)
        {

            int t = string.IsNullOrEmpty(context.Request.QueryString["ty"]) ? 0 : Convert.ToInt32(context.Request.QueryString["ty"]);
            //查询数量
            int count = string.IsNullOrEmpty(context.Request.QueryString["c"]) ? -1 : Convert.ToInt32(context.Request.QueryString["c"]);
            //套组合0,淘宝贝中套组合 3
            int p = string.IsNullOrEmpty(context.Request.QueryString["p"]) ? -1 : Convert.ToInt32(context.Request.QueryString["p"]);
            //大类
            int did = string.IsNullOrEmpty(context.Request.QueryString["did"]) ? -1 : Convert.ToInt32(context.Request.QueryString["did"]);
            //小类
            int xid = string.IsNullOrEmpty(context.Request.QueryString["xid"]) ? -1 : Convert.ToInt32(context.Request.QueryString["xid"]);

            //
            DataTable dt = SqlHelper.ExecuteDataSet(CommandType.Text, "EXEC proc_RecommendProducttzh @did=" + did + ",@xid=" + xid + ", @count =" + count + " ,@ProductAttributePromotion=" + p).Tables[0];


            //EnumAttribute.推荐

            DataTable dttemp;
            DataRow[] rows = dt.Select(" attribute like '%,102,%'  ");
            if (rows.Length > 0)
            {
                dttemp = rows.CopyToDataTable();

            }
            else
                dttemp = new DataTable();

            Response.Write(TRECommon.StringOperation.DataTableToJSON(dttemp, "dt"));
            Response.End();
        }

        /// <summary>
        /// 产品/淘宝贝列表中左边下角推荐产品
        /// </summary>
        /// <param name="context"></param>
        private void RecommendProduct(HttpContext context)
        {

            int t = string.IsNullOrEmpty(context.Request.QueryString["ty"]) ? 0 : Convert.ToInt32(context.Request.QueryString["ty"]);
            //查询数量
            int count = string.IsNullOrEmpty(context.Request.QueryString["c"]) ? -1 : Convert.ToInt32(context.Request.QueryString["c"]);
            //淘宝贝3 ,产品0
            int p = string.IsNullOrEmpty(context.Request.QueryString["p"]) ? -1 : Convert.ToInt32(context.Request.QueryString["p"]);
            //大类
            int did = string.IsNullOrEmpty(context.Request.QueryString["did"]) ? -1 : Convert.ToInt32(context.Request.QueryString["did"]);
            //小类
            int xid = string.IsNullOrEmpty(context.Request.QueryString["xid"]) ? -1 : Convert.ToInt32(context.Request.QueryString["xid"]);

            //
            DataTable dt = SqlHelper.ExecuteDataSet(CommandType.Text, "EXEC proc_RecommendProduct @did=" + did + ",@xid=" + xid + ", @count =" + count + " ,@ProductAttributePromotion=" + p).Tables[0];

            //EnumAttribute.推荐
            //if(t ==3)//淘宝贝

            DataTable dttemp;
            DataRow[] rows = dt.Select(" attribute like '%,102,%'  ");
            if (rows.Length > 0)
            {
                dttemp = rows.CopyToDataTable();

            }
            else
                dttemp = new DataTable();
            Response.Write(TRECommon.StringOperation.DataTableToJSON(dttemp, "dt"));
            Response.End();
        }

        /// <summary>
        /// 淘宝贝套组合查询
        /// </summary>
        /// <param name="context"></param>
        private void Searchtzhl(HttpContext context)
        {
            string strsql = @" SELECT * FROM
(SELECT row_number() OVER (ORDER BY (gpid)) AS rownum, colorid, ISNULL(sh.title,'') AS shoptitle,gp.gpId,gp.Name AS gpname,gp.brandId,gp.thumb,gp.shopid,gp.companyid,gtype,price 
,ISNULL(t_brand.title,'') AS brandtitle,ISNULL(fengge.title,'')  AS fgtitle, ISNULL(caizhi.title,'') AS cztitle,gp.No 
FROM dbo.GroupProduct gp 
left JOIN dbo.t_config fengge ON fengge.value = gp.styleId AND fengge.type=3 AND fengge.module=103
left JOIN dbo.t_config caizhi ON caizhi.value = gp.MaterialId AND caizhi.type=4  AND caizhi.module=103
left JOIN dbo.t_config yanse ON yanse.value = gp.ColorId AND yanse.type=12  AND yanse.module=103
left JOIN dbo.t_brand ON t_brand.id = gp.brandId AND t_brand.auditstatus =1
left JOIN dbo.t_productcategory tpg2 ON tpg2.id = gp.bigCateId   AND tpg2.linestatus=1
LEFT JOIN dbo.t_shop sh ON sh.id = gp.ShopId AND (sh.auditstatus =1  OR sh.auditstatus IS NULL)  
  
WHERE gp.Status =1  AND  GroupProductPromotion = 3 ";

            //符合条件记录总数
            string strsqlB = @"; Select count(0) FROM dbo.GroupProduct gp 
left JOIN dbo.t_config fengge ON fengge.value = gp.styleId AND fengge.type=3 AND fengge.module=103
left JOIN dbo.t_config caizhi ON caizhi.value = gp.MaterialId AND caizhi.type=4  AND caizhi.module=103
left JOIN dbo.t_config yanse ON yanse.value = gp.ColorId AND yanse.type=12  AND yanse.module=103
left JOIN dbo.t_brand ON t_brand.id = gp.brandId AND t_brand.auditstatus =1
left JOIN dbo.t_productcategory tpg2 ON tpg2.id = gp.bigCateId   AND tpg2.linestatus=1
LEFT JOIN dbo.t_shop sh ON sh.id = gp.ShopId AND (sh.auditstatus =1  OR sh.auditstatus IS NULL)  
  
WHERE gp.Status =1  AND  GroupProductPromotion = 3";
            //select productid From t_productattribute where ProductAttributePromotion = (select id from t_promotionstype where title='淘宝贝') ) and id in (SELECT  gpp.ppId FROM dbo.GroupProduct gp INNER JOIN GroupProductProperty gpp ON gp.gpId = gpp.gpId WHERE gp.Status=1 
            //类型
            int leixing = string.IsNullOrEmpty(context.Request.QueryString["lx"]) ? 0 : Convert.ToInt32(context.Request.QueryString["lx"]);
            //风格
            int fengge = string.IsNullOrEmpty(context.Request.QueryString["fg"]) ? 0 : Convert.ToInt32(context.Request.QueryString["fg"]);
            //材质
            int caizhi = string.IsNullOrEmpty(context.Request.QueryString["cz"]) ? 0 : Convert.ToInt32(context.Request.QueryString["cz"]);
            //颜色
            int yanse = string.IsNullOrEmpty(context.Request.QueryString["ys"]) ? 0 : Convert.ToInt32(context.Request.QueryString["ys"]);
            //品牌
            int pinpai = string.IsNullOrEmpty(context.Request.QueryString["pp"]) ? 0 : Convert.ToInt32(context.Request.QueryString["pp"]);
            //大类
            string type = string.IsNullOrEmpty(context.Request.QueryString["type"]) ? "" : context.Request.QueryString["type"];
            //促销类型
            int cuxiao = string.IsNullOrEmpty(context.Request.QueryString["cx"]) ? 0 : Convert.ToInt32(context.Request.QueryString["cx"]);

            //分页大小
            int pg = string.IsNullOrEmpty(context.Request.QueryString["pg"]) ? 10 : Convert.ToInt32(context.Request.QueryString["pg"]);

            //当前页
            int pi = string.IsNullOrEmpty(context.Request.QueryString["pi"]) ? 1 : Convert.ToInt32(context.Request.QueryString["pi"]);
            //小类
            if (leixing != 0)
            {
                strsql += " and smallcateid =" + leixing;
                strsqlB += " and smallcateid =" + leixing;
            }
            if (fengge != 0)
            {
                strsql += " and styleid= " + fengge;
                strsqlB += " and styleid= " + fengge;
            }
            if (caizhi != 0)
            {
                strsql += " and MaterialId = " + caizhi;
                strsqlB += " and MaterialId = " + caizhi;
            }
            if (yanse != 0)
            {
                strsql += " and colorid = " + yanse;
                strsqlB += " and colorid = " + yanse;
            }
            if (pinpai != 0)
            {
                strsql += " and brandid = " + pinpai;
                strsqlB += " and brandid = " + pinpai;
            }
            if (cuxiao > 0)
            {
                strsql += " and groupproductpromotion = " + cuxiao;
                strsqlB += " and groupproductpromotion = " + cuxiao;
            }

            //大类
            if (type.Length > 0 && type.Length < 10)
            {
                //strsql += " AND bigCateId IN (SELECT parentid FROM dbo.t_productcategory WHERE title='" + type.Replace(" ", "") + "') ";
                strsql += " AND bigCateId = " + type;
                strsqlB += " AND bigCateId = " + type;
            }

            strsql += string.Format(")AS T WHERE rownum BETWEEN ({0} - 1) * {1} + 1 AND {0} * {1}", pi, pg);

            DataSet ds = new DataSet();

            ds = SqlHelper.ExecuteDataSet(CommandType.Text, strsql + strsqlB);

            DataTable dt = ds.Tables[0];

            int totalrow = 0;
            if (ds.Tables[1] != null)
            {
                totalrow = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            }

            string josn = TRECommon.StringOperation.DataTableToJSON(dt, "dt");

            josn = josn.Replace("{\"dt\":[", "{\"totalrow\":\"" + totalrow + "\",\"dt\": [");

            Response.Write(josn); 
            Response.End();

        }
        /// <summary>
        /// 查询淘宝贝产品
        /// </summary>
        /// <param name="context"></param>
        private void Searchproducttbb(HttpContext context)
        {

            int xl = string.IsNullOrEmpty(context.Request.QueryString["xl"]) ? 0 : Convert.ToInt32(context.Request.QueryString["xl"]);
            int fg = string.IsNullOrEmpty(context.Request.QueryString["fg"]) ? 0 : Convert.ToInt32(context.Request.QueryString["fg"]);
            int cz = string.IsNullOrEmpty(context.Request.QueryString["cz"]) ? 0 : Convert.ToInt32(context.Request.QueryString["cz"]);
            int ys = string.IsNullOrEmpty(context.Request.QueryString["ys"]) ? 0 : Convert.ToInt32(context.Request.QueryString["ys"]);
            int pp = string.IsNullOrEmpty(context.Request.QueryString["pp"]) ? 0 : Convert.ToInt32(context.Request.QueryString["pp"]);
            int mc = string.IsNullOrEmpty(context.Request.QueryString["mc"]) ? 0 : Convert.ToInt32(context.Request.QueryString["mc"]);
            int pm = string.IsNullOrEmpty(context.Request.QueryString["pm"]) ? 0 : Convert.ToInt32(context.Request.QueryString["pm"]);
            int pg = string.IsNullOrEmpty(context.Request.QueryString["pg"]) ? 10 : Convert.ToInt32(context.Request.QueryString["pg"]);
            int pi = string.IsNullOrEmpty(context.Request.QueryString["pi"]) ? 1 : Convert.ToInt32(context.Request.QueryString["pi"]);
            //t_configtype类型id
            string did = string.IsNullOrEmpty(context.Request.QueryString["did"]) ? "" : context.Request.QueryString["did"];
            string key = string.IsNullOrEmpty(context.Request.QueryString["k"]) ? "" : context.Request.QueryString["k"];
            //大类编号(卧室系列id)
            int bid = string.IsNullOrEmpty(context.Request.QueryString["bid"]) ? 0 : Convert.ToInt32(context.Request.QueryString["bid"]);

            int keytype = 0;

            key = TRECommon.StringOperation.newstr(key);

            string sql = "exec proc_productsearch @promotion=" + pm + ",@bid=" + bid + ", @pagesize =" + pg + ", @pageindex=" + pi + ",@dlid='" + did + "',@key='" + key + "', @keytype=1,@marketid=" + mc + ",@materialvalue='" + cz + "',@categoryid=" + xl + ",@brandid =" + pp + ",@brandsid=0,@stylevalue='" + fg + "',@colorvalue='" + ys + "' ";

            //DataTable dt = SqlHelper.ExecuteDataSet(CommandType.Text, sql).Tables[0];

            //DataRow[] rows = dt.Select(" ProductAttributePromotion =3 ");

            //if (rows.Length > 0)
            //{

            //    DataTable dt2 = rows.CopyToDataTable();

            //    Response.Write(TRECommon.StringOperation.DataTableToJSON(dt2, "dt"));
            //}
            //else
            //{
            //    Response.Write("{\"dt\":[]}");
            //}
            //DataTable dt = SqlHelper.ExecuteDataSet(CommandType.Text, sql).Tables[0];


            DataSet ds = SqlHelper.ExecuteDataSet(CommandType.Text, sql);

            DataTable dt = ds.Tables[0];

            int totalrow = 0;
            if (ds.Tables[1] != null)
            {
                totalrow = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            }

            string josn = TRECommon.StringOperation.DataTableToJSON(dt, "dt");

            josn = josn.Replace("{\"dt\":[", "{\"totalrow\":\"" + totalrow + "\",\"dt\": [");
            Response.Write(josn);
            Response.End();
        }
        /// <summary>
        /// 查询品牌
        /// </summary>
        /// <param name="context"></param>
        private void SearchBrand(HttpContext context)
        {
            // + '&fg=' + $("#hidfg").val() + '&k=
            int mc = string.IsNullOrEmpty(context.Request.QueryString["mc"]) ? 0 : Convert.ToInt32(context.Request.QueryString["mc"]);
            int cz = string.IsNullOrEmpty(context.Request.QueryString["cz"]) ? 0 : Convert.ToInt32(context.Request.QueryString["cz"]);
            int fg = string.IsNullOrEmpty(context.Request.QueryString["fg"]) ? 0 : Convert.ToInt32(context.Request.QueryString["fg"]);
            string k = string.IsNullOrEmpty(context.Request.QueryString["k"]) ? "" : context.Request.QueryString["k"];
            int pg = string.IsNullOrEmpty(context.Request.QueryString["pg"]) ? 10 : Convert.ToInt32(context.Request.QueryString["pg"]);
            int pi = string.IsNullOrEmpty(context.Request.QueryString["pi"]) ? 1 : Convert.ToInt32(context.Request.QueryString["pi"]);
            string brandName = context.Request["brandName"];
            k = TRECommon.StringOperation.newstr(k);

            if (!string.IsNullOrEmpty(brandName))
            {
                k = brandName;
            }
            string sql = " EXEC proc_brandsearch @fg=" + fg + ",@cz=" + cz + ",@mc=" + mc + ",@key='" + k + "',@pageindex=" + pi + ",@pagesize=" + pg + ",@pagecount=1";

            //DataTable dt = SqlHelper.ExecuteDataSet(CommandType.Text, sql).Tables[0];

            //foreach (DataRow dr in dt.Rows)
            //{
            //    dr["descript"] = GetString(dr["descript"].ToString(), 65, "...");
            //}

            //string s = TRECommon.StringOperation.DataTableToJSON(dt, "dt");

            //Response.Write(s);

            DataSet ds = SqlHelper.ExecuteDataSet(CommandType.Text, sql);

            DataTable dt = ds.Tables[0];

            int totalrow = 0;
            if (ds.Tables[1] != null)
            {
                totalrow = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            }

            string josn = TRECommon.StringOperation.DataTableToJSON(dt, "dt");

            josn = josn.Replace("{\"dt\":[", "{\"totalrow\":\"" + totalrow + "\",\"dt\": [");
            Response.Write(josn); 
            Response.End();


        }
        /// <summary>
        /// 查询产品
        /// </summary>
        /// <param name="context"></param>
        private void Searchproduct(HttpContext context)
        {

            int xl = string.IsNullOrEmpty(context.Request.QueryString["xl"]) ? 0 : Convert.ToInt32(context.Request.QueryString["xl"]);
            int fg = string.IsNullOrEmpty(context.Request.QueryString["fg"]) ? 0 : Convert.ToInt32(context.Request.QueryString["fg"]);
            int cz = string.IsNullOrEmpty(context.Request.QueryString["cz"]) ? 0 : Convert.ToInt32(context.Request.QueryString["cz"]);
            int ys = string.IsNullOrEmpty(context.Request.QueryString["ys"]) ? 0 : Convert.ToInt32(context.Request.QueryString["ys"]);
            int pp = string.IsNullOrEmpty(context.Request.QueryString["pp"]) ? 0 : Convert.ToInt32(context.Request.QueryString["pp"]);
            int mc = string.IsNullOrEmpty(context.Request.QueryString["mc"]) ? 0 : Convert.ToInt32(context.Request.QueryString["mc"]);
            int pg = string.IsNullOrEmpty(context.Request.QueryString["pg"]) ? 10 : Convert.ToInt32(context.Request.QueryString["pg"]);
            int pi = string.IsNullOrEmpty(context.Request.QueryString["pi"]) ? 1 : Convert.ToInt32(context.Request.QueryString["pi"]);
            //t_configtype类型id
            string did = string.IsNullOrEmpty(context.Request.QueryString["did"]) ? "" : context.Request.QueryString["did"];
            string key = string.IsNullOrEmpty(context.Request.QueryString["k"]) ? "" : context.Request.QueryString["k"];
            //大类编号(卧室系列id)
            int bid = string.IsNullOrEmpty(context.Request.QueryString["bid"]) ? 0 : Convert.ToInt32(context.Request.QueryString["bid"]);

            int keytype = 0;

            key = TRECommon.StringOperation.newstr(key);

            string sql = "exec proc_productsearch @promotion=0,@bid=" + bid + ", @pagesize =" + pg + ", @pageindex=" + pi + ",@dlid='" + did + "',@key='" + key + "', @keytype=1,@marketid=" + mc + ",@materialvalue='" + cz + "',@categoryid=" + xl + ",@brandid =" + pp + ",@brandsid=0,@stylevalue='" + fg + "',@colorvalue='" + ys + "' ";

            DataSet ds = SqlHelper.ExecuteDataSet(CommandType.Text, sql);

            DataTable dt = ds.Tables[0];

            int totalrow = 0;
            if (ds.Tables[1] != null)
            {
                totalrow = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            }

            string josn = TRECommon.StringOperation.DataTableToJSON(dt, "dt");

            josn = josn.Replace("{\"dt\":[", "{\"totalrow\":\"" + totalrow + "\",\"dt\": [");

            Response.Write(josn);
            Response.End();
        }

        /// <summary>
        /// 套组合查询
        /// </summary>
        /// <param name="context"></param>
        private void Searchtzh(HttpContext context)
        {
            string strsql = @"SELECT * FROM
(SELECT row_number() OVER (ORDER BY (gpid)) AS rownum, colorid, ISNULL(sh.title,'') AS shoptitle,gp.gpId,gp.Name AS gpname,gp.brandId,gp.thumb,gp.shopid,gp.companyid,gtype,price 
,ISNULL(t_brand.title,'') AS brandtitle,ISNULL(fengge.title,'')  AS fgtitle, ISNULL(caizhi.title,'') AS cztitle,gp.No 
FROM dbo.GroupProduct gp 
left JOIN dbo.t_config fengge ON fengge.value = gp.styleId AND fengge.type=3 AND fengge.module=103
left JOIN dbo.t_config caizhi ON caizhi.value = gp.MaterialId AND caizhi.type=4  AND caizhi.module=103
left JOIN dbo.t_config yanse ON yanse.value = gp.ColorId AND yanse.type=12  AND yanse.module=103
left JOIN dbo.t_brand ON t_brand.id = gp.brandId AND t_brand.auditstatus =1
left JOIN dbo.t_productcategory tpg2 ON tpg2.id = gp.bigCateId   AND tpg2.linestatus=1
LEFT JOIN dbo.t_shop sh ON sh.id = gp.ShopId AND (sh.auditstatus =1  OR sh.auditstatus IS NULL)  
LEFT JOIN dbo.t_marketstoreyshop ON t_marketstoreyshop.shopid = gp.ShopId 
WHERE gp.Status =1   ";

            //符合条件记录总数
            string strsqlB = @";SELECT  count(0) FROM dbo.GroupProduct gp 
left JOIN dbo.t_config fengge ON fengge.value = gp.styleId AND fengge.type=3 AND fengge.module=103
left JOIN dbo.t_config caizhi ON caizhi.value = gp.MaterialId AND caizhi.type=4  AND caizhi.module=103
left JOIN dbo.t_config yanse ON yanse.value = gp.ColorId AND yanse.type=12  AND yanse.module=103
left JOIN dbo.t_brand ON t_brand.id = gp.brandId AND t_brand.auditstatus =1
left JOIN dbo.t_productcategory tpg2 ON tpg2.id = gp.bigCateId   AND tpg2.linestatus=1
LEFT JOIN dbo.t_shop sh ON sh.id = gp.ShopId AND (sh.auditstatus =1  OR sh.auditstatus IS NULL)  
LEFT JOIN dbo.t_marketstoreyshop ON t_marketstoreyshop.shopid = gp.ShopId 
WHERE gp.Status =1";
            //类型
            int leixing = string.IsNullOrEmpty(context.Request.QueryString["lx"]) ? 0 : Convert.ToInt32(context.Request.QueryString["lx"]);
            //风格
            int fengge = string.IsNullOrEmpty(context.Request.QueryString["fg"]) ? 0 : Convert.ToInt32(context.Request.QueryString["fg"]);
            //材质
            int caizhi = string.IsNullOrEmpty(context.Request.QueryString["cz"]) ? 0 : Convert.ToInt32(context.Request.QueryString["cz"]);
            //颜色
            int yanse = string.IsNullOrEmpty(context.Request.QueryString["ys"]) ? 0 : Convert.ToInt32(context.Request.QueryString["ys"]);
            //品牌
            int pinpai = string.IsNullOrEmpty(context.Request.QueryString["pp"]) ? 0 : Convert.ToInt32(context.Request.QueryString["pp"]);
            //大类
            string type = string.IsNullOrEmpty(context.Request.QueryString["type"]) ? "" : context.Request.QueryString["type"];
            //促销类型
            int cuxiao = string.IsNullOrEmpty(context.Request.QueryString["cx"]) ? 0 : Convert.ToInt32(context.Request.QueryString["cx"]);
            int mc = string.IsNullOrEmpty(context.Request.QueryString["mc"]) ? 0 : Convert.ToInt32(context.Request.QueryString["mc"]);

            //分页大小
            int pg = string.IsNullOrEmpty(context.Request.QueryString["pg"]) ? 10 : Convert.ToInt32(context.Request.QueryString["pg"]);

            //当前页
            int pi = string.IsNullOrEmpty(context.Request.QueryString["pi"]) ? 1 : Convert.ToInt32(context.Request.QueryString["pi"]);
            //小类
            if (leixing != 0)
            {
                strsql += " and smallcateid =" + leixing;
                strsqlB += " and smallcateid =" + leixing;
            }
            if (fengge != 0)
            {
                strsql += " and styleid= " + fengge;
                strsqlB += " and styleid= " + fengge;
            }
            if (caizhi != 0)
            {
                strsql += " and MaterialId = " + caizhi;
                strsqlB += " and MaterialId = " + caizhi;
            }
            if (yanse != 0)
            {
                strsql += " and colorid = " + yanse;
                strsqlB += " and colorid = " + yanse;
            }
            if (pinpai != 0)
            {
                strsql += " and brandid = " + pinpai;
                strsqlB += " and brandid = " + pinpai;
            }
            if (cuxiao > 0)
            {
                strsql += " and groupproductpromotion = " + cuxiao;
                strsqlB += " and groupproductpromotion = " + cuxiao;
            }
            if (mc != 0)
            {
                strsql += " and t_marketstoreyshop.marketid = " + mc;
                strsqlB += " and t_marketstoreyshop.marketid = " + mc;
            }
            //大类
            if (type.Length > 0 && type.Length < 10)
            {
                //  strsql += " AND bigCateId IN (SELECT parentid FROM dbo.t_productcategory WHERE title='" + type.Replace(" ", "") + "') ";
                strsql += " AND bigCateId =  " + type;
                strsqlB += " AND bigCateId =  " + type;
            }
            strsql += string.Format(")AS T WHERE rownum BETWEEN ({0} - 1) * {1} + 1 AND {0} * {1}", pi, pg);

            DataSet ds = new DataSet();

            ds = SqlHelper.ExecuteDataSet(CommandType.Text, strsql + strsqlB);

            DataTable dt = ds.Tables[0];

            int totalrow = 0;
            if (ds.Tables[1] != null)
            {
                totalrow = int.Parse(ds.Tables[1].Rows[0][0].ToString());
            }

            string josn = TRECommon.StringOperation.DataTableToJSON(dt, "dt");

            josn = josn.Replace("{\"dt\":[", "{\"totalrow\":\"" + totalrow + "\",\"dt\": [");

            Response.Write(josn);
            Response.End();

        }

        /// <summary>
        /// 首页淘宝贝详情
        /// </summary>
        /// <param name="context"></param>
        private void Searchtbb(HttpContext context)
        {
            int pdid = 0;
            int pxid = 0;
            string xlbr = "";
            string xlbttemp = "";

            pdid = string.IsNullOrEmpty(context.Request.QueryString["did"]) ? 0 : Convert.ToInt32(context.Request.QueryString["did"]);
            pxid = string.IsNullOrEmpty(context.Request.QueryString["xid"]) ? 0 : Convert.ToInt32(context.Request.QueryString["xid"]);

            DataSet ds = TREC.ECommerce.ECAdvertisement.TBBSearch(pdid, pxid);

            #region

            DataTable tempdt = ds.Tables[1].Select(" did= " + pdid).CopyToDataTable();

            xlbr = "";


            #region 随机获取淘宝贝里12个产品,不足十二位以0补足
            // int[] rowid = TRECommon.StringOperation.differSamenessRandomNum((tempdt.Rows.Count < 12) ? tempdt.Rows.Count : 12, 0, tempdt.Rows.Count);

            int acount = (tempdt.Rows.Count < 12) ? tempdt.Rows.Count : 12;
            int[] rowid = new int[acount];
            //= TRECommon.StringOperation.differSamenessRandomNum((tempdt.Rows.Count < 12) ? tempdt.Rows.Count : 12, 0, tempdt.Rows.Count);



            for (int k = 0; k < acount; k++)
            {
                rowid[k] = k;
            }


            int[] row1 = new int[4] { 0, 1, 2, 3 };
            int[] row2 = new int[4] { 4, 5, 6, 7 };
            int[] row3 = new int[4] { 8, 9, 10, 11 };
            List<int> alist = rowid.ToList();

            if (alist.Count < 12)
            {
                int c = 12 - alist.Count;
                //for (int i = 0; i < c; i++)
                //{
                //    alist.Add(0);
                //}
                for (int i = 0; i < c; i++)
                {
                    DataRow row = tempdt.NewRow();
                    #region

                    //DataRow dr = tempdt.Rows[0];
                    //dr["rowNum"] = -1;
                    // tempdt.Rows.Add(dr.ItemArray);

                    row["brandid"] = "-1";
                    row["ptitle"] = "-1";
                    row["materialname"] = "-1";
                    row["storage"] = "-1";
                    row["logo"] = "-1";
                    row["buyprice"] = "-1";
                    row["markprice"] = "-1";
                    row["saleprice"] = "-1";
                    row["thumb"] = "-1";
                    row["proid"] = "-1";
                    row["id"] = "-1";
                    row["xtitle"] = "-1";
                    row["dtitle"] = "-1";
                    row["did"] = "-1";
                    row["xid"] = "-1";
                    row["rowNum"] = "-1";
                    tempdt.Rows.Add(row);
                    #endregion
                }
            }


            #endregion

            xlbttemp = "";
            #region
            //1-4
            foreach (int index in row1)
            {
                DataRow dr = tempdt.Rows[index];

                #region


                if (Convert.ToInt32(dr["rowNum"]) == -1)
                {
                    xlbttemp += "<li>" +
                     "<div class='d1'>" +
                     "<a href='#' target='_blank'><img  src='/resource/content/images/nopic.jpg' /></a>" +
                     "</div>" +
                     "<div class='d2 b'>" +
                     "<a href='#' target='_blank'></a></div>" +
                     "<div class='d3'></div>" +
                     "<div class='d4 clearfix'>" +
                     "<div class='price fl yahei'>" +
                     "<p class='p1'></p>" +
                     "<p class='p2'></p>" +
                     "</div>" +
                     "<div class='btn fr'>" +
                     "<a href='' class='block'></a>" +
                     "</div>" +
                     "</div>" +
                     "<div class='d5'>" +
                     "" +
                     "<img style='height:35px' src='' /></div>" +
                     "</li>";
                }
                else
                {
                    xlbttemp += "<li>" +
                         "<div class='d1'>" +
                         "<a href='productinfo.aspx?id=" + dr["proid"].ToString() + "' style='height:195px;width:210px;' target='_blank'><img  src='upload/product/thumb/" + dr["proid"].ToString() + "/" + dr["thumb"].ToString().Replace(",", "").Replace(".", "_230-173.") + "' /></a>" +
                         "</div>" +
                         "<div class='d2 b'>" +
                         "<a href='productinfo.aspx?id=" + dr["proid"].ToString() + "' target='_blank'>" + dr["ptitle"].ToString() + "</a></div>" +
                         "<div class='d3'>" + dr["materialname"].ToString() + "</div>" +
                         "<div class='d4 clearfix'>" +
                         "<div class='price fl yahei'>" +
                         "<p class='p1'>价格：￥" + dr["saleprice"].ToString() + "</p>" +
                         "<p class='p2'>库存：" + dr["storage"].ToString() + "</p>" +
                         "</div>" +
                         "<div class='btn fr'>" +
                         "<a href='javascript:;' onclick=\"addBAOMING(" + dr["id"] + ",'" + context.Server.UrlEncode(dr["ptitle"].ToString()) + "'," + dr["proid"].ToString() + ")\" class='block'>立即抢购</a>" +
                         "</div>" +
                         "</div>" +
                         "<div class='d5'>" +
                         "" +
                         "<img style='height:35px' src='/upload/brand/logo/" + dr["brandid"].ToString() + "/" + dr["logo"].ToString().Replace(",", "") + "' /></div>" +
                         "</li>";
                }
                #endregion

            }

            xlbr = "<div class='list fr' style='margin-top: 0px; float:right' >" +
                  "<ul class='clearfix'>" + xlbttemp +
                  "</ul></div>";

            xlbttemp = "";
            //5-8
            foreach (int index in row2)
            {
                DataRow dr = tempdt.Rows[index];
                #region
                if (Convert.ToInt32(dr["rowNum"]) == -1)
                {
                    xlbttemp += "<li>" +
                           "<div class='d1'>" +
                           "<a href='###' target='_blank'><img  src='/resource/content/images/nopic.jpg' /></a>" +
                           "</div>" +
                           "<div class='d2 b'>" +
                           "<a href='#' target='_blank'></a></div>" +
                           "<div class='d3'></div>" +
                           "<div class='d4 clearfix'>" +
                           "<div class='price fl yahei'>" +
                           "<p class='p1'></p>" +
                           "<p class='p2'></p>" +
                           "</div>" +
                           "<div class='btn fr'>" +
                           "<a href=''   class='block'></a>" +
                           "</div>" +
                           "</div>" +
                           "<div class='d5'>" +
                           "" +
                           "<img style='height:35px' src='' /></div>" +
                           "</li>";
                }
                else
                {
                    xlbttemp += "<li>" +
                         "<div class='d1'>" +
                         "<a href='product/" + dr["proid"].ToString() + "/info.aspx' style='height:195px;width:210px;' target='_blank'><img  src='upload/product/thumb/" + dr["proid"].ToString() + "/" + dr["thumb"].ToString().Replace(",", "").Replace(".", "_230-173.") + "' /></a>" +
                         "</div>" +
                         "<div class='d2 b'>" +
                         "<a href='product/" + dr["proid"].ToString() + "/info.aspx' target='_blank'>" + dr["ptitle"].ToString() + "</a></div>" +
                         "<div class='d3'>" + dr["materialname"].ToString() + "</div>" +
                         "<div class='d4 clearfix'>" +
                         "<div class='price fl yahei'>" +
                         "<p class='p1'>价格：￥" + dr["saleprice"].ToString() + "</p>" +
                         "<p class='p2'>库存：" + dr["storage"].ToString() + "</p>" +
                         "</div>" +
                         "<div class='btn fr'>" +
                         "<a href='javascript:;' onclick=\"addBAOMING(" + dr["id"] + ",'" + context.Server.UrlEncode(dr["ptitle"].ToString()) + "'," + dr["proid"].ToString() + ")\" class='block'>立即抢购</a>" +
                         "</div>" +
                         "</div>" +
                         "<div class='d5'>" +
                         "" +
                         "<img style='height:35px' src='upload/brand/logo/" + dr["brandid"].ToString() + "/" + dr["logo"].ToString().Replace(",", "") + "' /></div>" +
                         "</li>";
                }
                #endregion
            }
            xlbr += "<div class='list fr' style='margin-top: 18px; float:right' >" +
                  "<ul class='clearfix'>" + xlbttemp +
                  "</ul></div>";
            xlbttemp = "";
            //9-12
            foreach (int index in row3)
            {
                DataRow dr = tempdt.Rows[index];
                #region
                if (Convert.ToInt32(dr["rowNum"]) == -1)
                {
                    xlbttemp += "<li>" +
                          "<div class='d1'>" +
                          "<a href='###'><img src='/resource/content/images/nopic.jpg' /></a>" +
                          "</div>" +
                          "<div class='d2 b'>" +
                          "<a href='#' target='_blank'></a></div>" +
                          "<div class='d3'></div>" +
                          "<div class='d4 clearfix'>" +
                          "<div class='price fl yahei'>" +
                          "<p class='p1'></p>" +
                          "<p class='p2'></p>" +
                          "</div>" +
                          "<div class='btn fr'>" +
                          "<a href='###'  class='block'></a>" +
                          "</div>" +
                          "</div>" +
                          "<div class='d5'>" +
                          "" +
                          "<img style='height:35px' src='' /></div>" +
                          "</li>";
                }
                else
                {
                    xlbttemp += "<li>" +
                         "<div class='d1'>" +
                         "<a href='product/" + dr["proid"].ToString() + "/info.aspx' style='height:195px;width:210px;' target='_blank'><img  src='upload/product/thumb/" + dr["proid"].ToString() + "/" + dr["thumb"].ToString().Replace(",", "").Replace(".", "_230-173.") + "' /></a>" +
                         "</div>" +
                         "<div class='d2 b'>" +
                         "<a href='product/" + dr["proid"].ToString() + "/info.aspx' target='_blank'>" + dr["ptitle"].ToString() + "</a></div>" +
                         "<div class='d3'>" + dr["materialname"].ToString() + "</div>" +
                         "<div class='d4 clearfix'>" +
                         "<div class='price fl yahei'>" +
                         "<p class='p1'>价格：￥" + dr["saleprice"].ToString() + "</p>" +
                         "<p class='p2'>库存：" + dr["storage"].ToString() + "</p>" +
                         "</div>" +
                         "<div class='btn fr'>" +
                         "<a href='javascript:;' onclick=\"addBAOMING(" + dr["id"] + ",'" + context.Server.UrlEncode(dr["ptitle"].ToString()) + "'," + dr["proid"].ToString() + ")\" class='block'>立即抢购</a>" +
                         "</div>" +
                         "</div>" +
                         "<div class='d5'>" +
                         "" +
                         "<img style='height:35px' src='upload/brand/logo/" + dr["brandid"].ToString() + "/" + dr["logo"].ToString().Replace(",", "") + "' /></div>" +
                         "</li>";
                }
                #endregion
            }
            #endregion

            xlbr += "<div class='list fr' style='margin-top: 18px; float:right' >" +
                    "<ul class='clearfix'>" + xlbttemp +
                    "</ul></div>";

            #endregion

            Response.Write(xlbr);
            Response.End();
        }

        /// <summary>
        /// 商家活动
        /// </summary>
        private void Searchhd(HttpContext context)
        {
            //当前页数
            int pageindex = string.IsNullOrEmpty(context.Request.QueryString["pi"]) ? 0 : Convert.ToInt32(context.Request.QueryString["pi"]);
            //总页数
            int pagecount = string.IsNullOrEmpty(context.Request.QueryString["pc"]) ? 0 : Convert.ToInt32(context.Request.QueryString["pc"]);
            //每页显示数量
            int pagesize = string.IsNullOrEmpty(context.Request.QueryString["ps"]) ? 0 : Convert.ToInt32(context.Request.QueryString["ps"]);
            //商场id
            int marketid = string.IsNullOrEmpty(context.Request.QueryString["mid"]) ? 0 : Convert.ToInt32(context.Request.QueryString["mid"]);
            //品牌id
            int brandid = string.IsNullOrEmpty(context.Request.QueryString["bid"]) ? 0 : Convert.ToInt32(context.Request.QueryString["bid"]);
            //区域id
            string areaid = string.IsNullOrEmpty(context.Request.QueryString["aid"]) ? "" : context.Request.QueryString["aid"];
            //搜索关键词
            string key = string.IsNullOrEmpty(context.Request.QueryString["k"]) ? "" : context.Request.QueryString["k"];

            //活动发起方 (工厂企业=101,经销商=102,卖场=103,店铺管理员=104,)
            int fqf = string.IsNullOrEmpty(context.Request.QueryString["tf"]) ? 0 : Convert.ToInt32(context.Request.QueryString["tf"]);
            string sorttype = "desc";
            sorttype = context.Request.QueryString["sort"] == "0" ? "asc" : "desc";
            /*
             * 排序类型
             * 
             */
            int sort = Convert.ToInt32(context.Request.QueryString["sort1"]);
            string sortkey = "";
            switch (sort)
            {
                case 2:
                    sortkey = "begintime";
                    break;
                case 3:
                    sortkey = "endtime";
                    break;
                case 4:
                    sortkey = "gzd";
                    break;
                default:
                    sortkey = "";
                    break;
            }

            if (areaid.Replace(" ", "").Length > 8)
            {
                Response.End();
            }

            if (key.Length > 0)
            {
                key = TRECommon.StringOperation.newstr(key.Replace(" ", ""));
            }

            DataTable dt = TREC.ECommerce.ECAdvertisement.HDSearch(pageindex, pagecount, pagesize, marketid, brandid, areaid, key, fqf, sorttype, sortkey);
            string json = TRECommon.StringOperation.DataTableToJSON(dt, "dt");
            Response.Write(json);
            Response.End();


        }


         private void SearchhdNew(HttpContext context)
        {
            //当前页数
            int pageindex = string.IsNullOrEmpty(context.Request.QueryString["pi"]) ? 1 : Convert.ToInt32(context.Request.QueryString["pi"]);
            //总页数
            int pagecount = string.IsNullOrEmpty(context.Request.QueryString["pc"]) ? 0 : Convert.ToInt32(context.Request.QueryString["pc"]);
            //每页显示数量
            int pagesize = string.IsNullOrEmpty(context.Request.QueryString["ps"]) ? 0 : Convert.ToInt32(context.Request.QueryString["ps"]);
            //商场id
            int marketid = string.IsNullOrEmpty(context.Request.QueryString["mid"]) ? 0 : Convert.ToInt32(context.Request.QueryString["mid"]);
            //品牌id
            int brandid = string.IsNullOrEmpty(context.Request.QueryString["bid"]) ? 0 : Convert.ToInt32(context.Request.QueryString["bid"]);
            //区域id
            string areaid = string.IsNullOrEmpty(context.Request.QueryString["aid"]) ? "" : context.Request.QueryString["aid"];
            //搜索关键词
            string key = string.IsNullOrEmpty(context.Request.QueryString["k"]) ? "" : context.Request.QueryString["k"];

            //活动发起方 (工厂企业=101,经销商=102,卖场=103,店铺管理员=104,)
            int fqf = string.IsNullOrEmpty(context.Request.QueryString["tf"]) ? 0 : Convert.ToInt32(context.Request.QueryString["tf"]);
            string sorttype = "desc";
            sorttype = context.Request.QueryString["sort"] == "0" ? "asc" : "desc";
            /*
             * 排序类型
             * 
             */
            int sort = Convert.ToInt32(context.Request.QueryString["sort1"]);
            string sortkey = "";
            StringBuilder condiction = new StringBuilder(string.Empty);

            if (fqf > 0)
            {
                if (fqf == 104)
                {
                    condiction.Append(" and shopid>0 ");
                }
                else
                {
                    condiction.Append(" and membertype=" + fqf);
                }
            }

            if (!string.IsNullOrEmpty(areaid))
            {
                condiction.Append(" and areacode LIKE '%<areacode>" + areaid + "</areacode>%'");
            }

            if (marketid>0)
            {
                condiction.Append(" and market LIKE '%<id>" + marketid + "</id>%'");
            }
            if (brandid > 0)
            {
                condiction.Append(" and brand LIKE '%<id>" + brandid + "</id>%'");
            }
            if (key.Trim().Length > 0)
            {
                condiction.Append(" and (brand LIKE '%<title>" + key + "</title>%' OR  companyname  LIKE '%<title>" + key + "</title>%') ");
            }
            switch (sort)
            {
                case 2:
                    sortkey = " stime desc ";
                    break;
                case 3:
                    sortkey = " etime desc";
                    break;
                case 4:
                    sortkey = " IsHot desc ";
                    break;
                default:
                    sortkey = " id desc ";
                    break;
            }

            if (areaid.Replace(" ", "").Length > 8)
            {
                Response.End();
            }

            if (key.Length > 0)
            {
                key = TRECommon.StringOperation.newstr(key.Replace(" ", ""));
            }

            DataSet ds = TREC.ECommerce.ECAdvertisement.HDSearch(pageindex, 10, condiction.ToString(), sortkey);
            string pagerow = "{\"page\":{\"pageindex\":\"" + pageindex + "\",\"pagerows\":\"" + ds.Tables[2].Rows[0][0].ToString() + "\",\"rows\":\"" + ds.Tables[1].Rows[0][0].ToString() + "\"},\"dt\":";
          //  DataTable dt = TREC.ECommerce.ECAdvertisement.HDSearch(pageindex, pagecount, pagesize, marketid, brandid, areaid, key, fqf, sorttype, sortkey);
             string json = TRECommon.StringOperation.DataTableToJSON(ds.Tables[0], "dt").Replace("{\"dt\":", pagerow);
            Response.Write(json);
            Response.End();


        }

       
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="param">需要截取的字符串</param>
        /// <param name="length">截取的长度(字节)</param>
        /// <param name="end">后置值</param>
        /// <returns></returns>
        public static string GetString(string param, int length, string end)
        {
            if (string.IsNullOrEmpty(param))
                return param;
            int byteLen = Encoding.Default.GetByteCount(param);

            if (byteLen <= length)
                return param;

            string Pattern = null;
            MatchCollection m = null;
            StringBuilder result = new StringBuilder();
            int n = 0;
            char temp;
            bool isCode = false; //是不是HTML代码
            bool isHTML = false; //是不是HTML特殊字符,如&nbsp;
            char[] pchar = param.ToCharArray();
            for (int i = 0; i < pchar.Length; i++)
            {
                temp = pchar[i];
                if (temp == '<')
                    isCode = true;
                else if (temp == '&')
                    isHTML = true;
                else if (temp == '>' && isCode)
                {
                    n = n - 1;
                    isCode = false;
                }
                else if (temp == ';' && isHTML)
                    isHTML = false;

                if (!isCode && !isHTML)
                {
                    n = n + 1;
                    //UNICODE码字符占两个字节
                    if (Encoding.Default.GetBytes(temp + "").Length > 1)
                        n = n + 1;
                }

                result.Append(temp);
                if (n >= length)
                    break;
            }
            result.Append(end);

            string temp_result = Regex.Replace(result.ToString(),
                                                "(>)[^<>]*(<?)",
                                                "$1$2",
                                                RegexOptions.IgnoreCase);
            //去掉不需要结素标记的HTML标记 
            temp_result = Regex.Replace(temp_result,
                                         @"</?(area|base|basefont|body|br|col|colgroup|dd|dt|frame|head|hr|html|img|input|isindex|li|link|meta|option|p|param|tbody|td|tfoot|th|thead|tr)[^<>]*/?>"
                                         ,
                                         "",
                                         RegexOptions.IgnoreCase);
            //去掉成对的HTML标记 
            temp_result = Regex.Replace(temp_result,
                                         @"<([a-zA-Z]+)[^<>]*>(.*?)</\1>",
                                         "",
                                         RegexOptions.IgnoreCase);
            //用正则表达式取出标记 
            Pattern = ("<([a-zA-Z]+)[^<>]*>");
            m = Regex.Matches(temp_result, Pattern);
            ArrayList endHTML = new ArrayList();
            foreach (Match mt in m)
                endHTML.Add(mt.Result("$1"));
            //补全不成对的HTML标记 
            for (int i = endHTML.Count - 1; i >= 0; i--)
            {
                result.Append("</");
                result.Append(endHTML[i]);
                result.Append(">");
            }
            return result.ToString();


        }


        public HttpResponse Response
        {
            get
            {
                return HttpContext.Current.Response;
            }
        }
        public HttpRequest Request
        {
            get
            {
                return HttpContext.Current.Request;
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}