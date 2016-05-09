using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz.Data;
using Haojibiz.DAL;
using Haojibiz.Model;

namespace TREC.Web.aspx
{


    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    #endregion


    public partial class productinfotzh : WebPageBase
    {
        public EnWebProduct productInfo = new EnWebProduct();
        public EnProductCon m1 = new EnProductCon();
        public EnProductCon m2 = new EnProductCon();
        public EnProductCon m3 = new EnProductCon();
        public EnProductCon m4 = new EnProductCon();
        public EnProductCon m5 = new EnProductCon();
        protected LinqDataContext db = new LinqDataContext();
        protected List<Mpromotions> shoppromotions = new List<Mpromotions>();


        #region
        public string tprice = "";//价格
        public string tcompany = "";//厂商
        public string tcompanyid = "";
        public string tbrand = "";//品牌
        public string tbrandid = "";
        public string tstyle = "";//风格
        public string tcz = "";//caizhi
        public string txl = "";//xilie
        public string tys = "";//yanse
        public string tshop = "";//店铺
        public string logo = "";//品牌logo
        public string sku = "";//sku
        public string thumb = "";
        public string shopid = "";//shopid
        public string address = "";//店铺地址
        public string descript = "";
        public string bannel ="";//细节图片
        public string gpid = "";

        public string nav = "";//面包屑导航 首页>大类>小类>产品名
        public string othershop = "";//其他店铺
        public string shopdisplay = "none";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            #region
            //if (ECommon.QueryPId != "")
            //{
            //    productInfo = ECProduct.GetWebProducInfo(" where id=" + ECommon.QueryPId);
            //    if (productInfo == null || productInfo.id == 0)
            //    {
            //        return;//产品未审核和上线。。
            //    }
            //    m1 = ECProduct.GetProductConInfo(" where contype =" + (int)EnumProductConType.风格特点 + " and productid=" + productInfo.id);
            //    m2 = ECProduct.GetProductConInfo(" where contype =" + (int)EnumProductConType.产品细节 + " and productid=" + productInfo.id);
            //    m3 = ECProduct.GetProductConInfo(" where contype =" + (int)EnumProductConType.材质工艺 + " and productid=" + productInfo.id);
            //    m4 = ECProduct.GetProductConInfo(" where contype =" + (int)EnumProductConType.保养说明 + " and productid=" + productInfo.id);
            //    m5 = ECProduct.GetProductConInfo(" where contype =" + (int)EnumProductConType.配送周期 + " and productid=" + productInfo.id);

            //    var shopids = productInfo.ProductShopList.Select(c => Convert.ToInt32(c.id)).ToArray();
            //    shoppromotions = db.promotions.Where(c => c.auditstatus == 1 && c.linestatus == 1).GroupJoin(db.promotionsrelated, c => c.id, c => c.promotionsid, (f, k) => new { f, k })
            //        .Where(c => c.k.Where(j => j.shopid > 0 && shopids.Contains(j.shopid)).Any()).ToList()
            //    .Select(c => new Mpromotions
            //    {
            //        id = c.f.id,
            //        title = c.f.title,
            //        letter = c.f.letter,
            //        sort = c.f.sort,
            //        IsRecommend = c.f.IsRecommend,
            //        lastedmtime = c.f.lastedmtime,
            //        promotionsrelated = c.k.ToList()
            //    }).OrderByDescending(c => c.IsRecommend).ThenByDescending(c => c.lastedmtime).ToList();

            //    pageTitle = productInfo.brandtitle + " " + productInfo.stylename + " " + productInfo.categorytitle + " (" + productInfo.sku + ") " + " " + productInfo.materialname + "产品信息";
            //}
            #endregion


            int tzhid = string.IsNullOrEmpty(Request.QueryString["tid"]) ? 0 : int.Parse(Request.QueryString["tid"]);

            if (tzhid < 1)
            {
                Response.Redirect(TREC.ECommerce.ECommon.WebUrl + "/productinfo2.aspx");

                //if (Request.UrlReferrer != null)
                //    Response.Redirect(Request.UrlReferrer.ToString());
                //else
                //    Response.Redirect("index.aspx");
            }


            string sql = @"
SELECT  gp.thumb,gp.bannel,gp.No,gp.gpId,gp.Name AS gpname, ISNULL(tpg2.title,'') AS bigtitle,bigCateId,SeriesId,gp.brandId,ISNULL(dbo.t_brand.title,'') AS brandtitle,
gp.styleId,ISNULL(fengge.title,'') AS fenggetitle, ISNULL(caizhi.title,'') AS caizhititle,gp.MaterialId ,ColorId,ISNULL(yanse.title,'') AS yansetitle,
ISNULL(tpg.id,0) AS smallcateid,ISNULL(tpg.title,'') AS smalltitle,gp.Price,gp.SeriesId,ISNULL(t_brands.title,'') AS xilietitle ,
gp.ShopId ,ISNULL(dbo.t_shop.title,'') AS shoptitle ,gp.Descript
,ISNULL( a.companytitle,'') AS companytitle, ISNULL(a.sku,'') AS sku,a.companyid,t_brand.logo,dbo.t_shop.address ,isnull(gp.Descript,'') as Descript
 FROM GroupProduct gp 
left JOIN dbo.t_config fengge ON fengge.value = gp.styleId AND fengge.type=3 AND fengge.module=103
left JOIN dbo.t_config caizhi ON caizhi.value = gp.MaterialId AND caizhi.type=4  AND caizhi.module=103
left JOIN dbo.t_config yanse ON yanse.value = gp.ColorId AND yanse.type=12  AND yanse.module=103
left JOIN dbo.t_brand ON t_brand.id = gp.brandId AND t_brand.auditstatus =1
left JOIN dbo.t_productcategory tpg2 ON tpg2.id = gp.bigCateId   AND tpg2.linestatus=1 
--left JOIN dbo.t_productcategory tpg on tpg.id = gp.smallcateid and tpg.linestatus=1 
left JOIN dbo.t_productcategory tpg on tpg.parentid = tpg2.id and tpg.linestatus=1 AND tpg.ptype =2 
LEFT JOIN dbo.t_brands ON t_brands.id = gp.SeriesId AND t_brands.auditstatus=1 AND t_brands.linestatus=1
LEFT JOIN dbo.t_shop ON t_shop.id = gp.ShopId AND t_shop.auditstatus=1 AND t_shop.linestatus=1 
inner JOIN (
 
SELECT top 1 t_company.title AS companytitle ,dbo.t_product.sku,groupproduct.gpid,t_company.id AS companyid
FROM dbo.t_company INNER JOIN dbo.t_product ON t_product.companyid = dbo.t_company.id
INNER JOIN GroupProductProperty ON GroupProductProperty.ppId = t_product.id
INNER JOIN dbo.GroupProduct ON groupproduct.gpId = GroupProductProperty.gpId
WHERE dbo.t_company.auditstatus = 1 AND t_company.linestatus =1 
 and groupproduct.gpId = " + tzhid +") a ON a.gpId= gp.gpId WHERE gp.Status =1  ";

            sql = sql + " and gp.gpid= " + tzhid.ToString();


            System.Data.DataTable dt = SqlHelper.ExecuteDataSet(System.Data.CommandType.Text, sql).Tables[0];


            if (dt.Rows.Count != 1)
            {
                Response.Redirect(TREC.ECommerce.ECommon.WebUrl + "/productinfo2.aspx");
                //if (Request.UrlReferrer != null)
                //    Response.Redirect(Request.UrlReferrer.ToString());
                //else
                //    Response.Redirect("index.aspx");
            }
            else
            {
                System.Data.DataRow dr = dt.Rows[0];

                tprice = dr["price"].ToString();
                tcompany = dr["companytitle"].ToString();
                thumb = TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/upload/productgroup/thumb/" + dr["gpid"] + "/" + dr["thumb"].ToString();
                tcompanyid = dr["companyid"].ToString();
                tbrand = dr["brandtitle"].ToString();
                tbrandid = dr["brandId"].ToString();
                tstyle = dr["fenggetitle"].ToString();
                tcz = dr["caizhititle"].ToString();
                txl = dr["xilietitle"].ToString();
                tys = dr["yansetitle"].ToString();
                tshop = dr["shoptitle"].ToString();
                shopid = dr["ShopId"].ToString();
                logo = dr["logo"].ToString();
                sku = dr["sku"].ToString();
                address = dr["address"].ToString();
                descript = dr["Descript"].ToString();
                if (sku.Length > 0)
                    sku = "("+sku+")";

                string banimg = dr["bannel"].ToString();

                string[] banimgs = banimg.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in banimgs)
                {
                    bannel += "<img src= '" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/upload/productgroup/banner/" + dr["gpid"] + "/" + item + "' /><br />";
                }
                gpid = dr["gpId"].ToString();


                //  bigCateId bigtitle gpname 001
                //产品productlist,淘宝贝productlisttbb,套组合productlist2

                string url = "productlist2";
                if (Request.UrlReferrer != null)
                    if (Request.UrlReferrer.AbsoluteUri.Contains("tbb2.aspx"))//从淘宝贝点击到详情页
                        url = "productlisttbb2";

                nav = "<a href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/" + url + ".aspx?did=" + dr["bigCateId"].ToString() + "'>" + dr["bigtitle"].ToString() + "</a> &gt; <a href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/" + url + ".aspx?did=" + dr["bigCateId"].ToString() + "'>" + dr["smalltitle"].ToString() + "</a> &gt; " + dr["gpname"].ToString() + "(" + dr["no"].ToString() + ")";


            }


            string sql2 = @"SELECT top 5 * FROM dbo.t_shop 
INNER JOIN t_productshopprice ON t_productshopprice.shopid = dbo.t_shop.id
WHERE t_shop.id IN (
SELECT shopid FROM t_shopbrand  WHERE brandid=" + tbrandid + "  )";


            System.Data.DataTable dtshop = SqlHelper.ExecuteDataSet(System.Data.CommandType.Text, sql2).Tables[0];


            othershop="";
            foreach (System.Data.DataRow dr in dtshop.Rows)
            {
                othershop += "<a href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/shop/"+dr["id"]+"/index.aspx' target='_blank' >" + dr["title"].ToString() + "</a><br />";
    
            }
            if (othershop.Length > 0)
                shopdisplay = "";

            //获取相关产品
            sql2 = @"SELECT  tp.id,tp.title,tp.thumb FROM dbo.t_product tp INNER JOIN GroupProductProperty ON GroupProductProperty.ppid = tp.id 
 WHERE tp.auditstatus =1 AND tp.linestatus =1 AND  gpId=" + gpid;

           

        }

        /// <summary>
        /// 本品牌其它产品
        /// </summary>
        public List<EnWebProduct> BrandProductList
        {
            get
            {
                if (brandProductList == null)
                    brandProductList = ECProduct.GetWebProductList(1, 3, " and (brandid=" + tbrandid +   ")", "", "", out tmpPageCount);
                return brandProductList;
            }
        }

        /// <summary>
        /// 其它品牌产品
        /// </summary>
        public List<EnWebProduct> OthenBrandProductList
        {
            get
            {
                if (othenBrandProductList == null)
                    othenBrandProductList = ECProduct.GetWebProductList(1, 3, " and (brandid!=" + tbrandid +    ")", "", "", out tmpPageCount);
                return othenBrandProductList;
            }
        }

        List<EnWebProduct> brandProductList = null, othenBrandProductList = null;
    }
}