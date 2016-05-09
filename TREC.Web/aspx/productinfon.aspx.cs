using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz.Data;
using Haojibiz.DAL;
using Haojibiz.Model;
using System.Data;

namespace TREC.Web.aspx
{


    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    using System.Text;
    #endregion


    public partial class productinfon : WebPageBase
    {
        public EnWebProduct productInfo = new EnWebProduct();
        public EnProductCon m1 = new EnProductCon();
        public EnProductCon m2 = new EnProductCon();
        public EnProductCon m3 = new EnProductCon();
        public EnProductCon m4 = new EnProductCon();
        public EnProductCon m5 = new EnProductCon();
        protected LinqDataContext db = new LinqDataContext();
        protected List<Mpromotions> shoppromotions = new List<Mpromotions>();


        public string imgpath = "";
        public string title = "";
        public string title2 = "";
        public string price = "";
        public string company = "";
        public string brand = "";
        public string fg = "";
        public string xl = "";
        public string ys = "";
        public string cz = "";
        public string cc = "";
        public string jg = "";
        public string dp = "";
        public string des = "";
        public string imgs = "";
        public string qtdp = "";
        public string tpbid = string.Empty;

        protected string _prodSKN = "";
        protected string _prodCZ = "";
        protected string _assemble = "";

        public string attrpromotion = "";
        public string nav = "";//面包屑导航 首页>大类>小类>产品名

        public string TitleSEO = string.Empty;
        public string keywordsSEO = string.Empty;
        public string DescriptionSEO = string.Empty;

        public string proid = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            #region
            if (ECommon.QueryPId != "")
            {
                //productInfo = ECProduct.GetWebProducInfo(" where id=" + ECommon.QueryPId);
                //if (productInfo == null || productInfo.id == 0)
                //{
                //    return;//产品未审核和上线。。
                //}
                //m1 = ECProduct.GetProductConInfo(" where contype =" + (int)EnumProductConType.风格特点 + " and productid=" + productInfo.id);
                //m2 = ECProduct.GetProductConInfo(" where contype =" + (int)EnumProductConType.产品细节 + " and productid=" + productInfo.id);
                //m3 = ECProduct.GetProductConInfo(" where contype =" + (int)EnumProductConType.材质工艺 + " and productid=" + productInfo.id);
                //m4 = ECProduct.GetProductConInfo(" where contype =" + (int)EnumProductConType.保养说明 + " and productid=" + productInfo.id);
                //m5 = ECProduct.GetProductConInfo(" where contype =" + (int)EnumProductConType.配送周期 + " and productid=" + productInfo.id);

                //var shopids = productInfo.ProductShopList.Select(c => Convert.ToInt32(c.id)).ToArray();
                //shoppromotions = db.promotions.Where(c => c.auditstatus == 1 && c.linestatus == 1).GroupJoin(db.promotionsrelated, c => c.id, c => c.promotionsid, (f, k) => new { f, k })
                //    .Where(c => c.k.Where(j => j.shopid > 0 && shopids.Contains(j.shopid)).Any()).ToList()
                //.Select(c => new Mpromotions
                //{
                //    id = c.f.id,
                //    title = c.f.title,
                //    letter = c.f.letter,
                //    sort = c.f.sort,
                //    IsRecommend = c.f.IsRecommend,
                //    lastedmtime = c.f.lastedmtime,
                //    promotionsrelated = c.k.ToList()
                //}).OrderByDescending(c => c.IsRecommend).ThenByDescending(c => c.lastedmtime).ToList();

                //pageTitle = productInfo.brandtitle + " " + productInfo.stylename + " " + productInfo.categorytitle + " (" + productInfo.sku + ") " + " " + productInfo.materialname + "产品信息";
            }
            #endregion

            string strsql = @"
SELECT DISTINCT assemble,categoryid,tpb.id AS tpbid, tp.id AS tpid,tp.letter,tp.tcolor,tpb.productno,tp.categorytitle,tp.title AS tptitle,isnull(tp.sku,'') as sku,tp.no AS tpno,tp.brandid,tp.brandtitle,tp.brandsid,brandstitle,
tp.stylevalue,tp.stylename,tp.colorvalue,tp.colorname,tp.materialvalue,tp.materialname,tp.unit,tpb.ProductAttributePromotion,
tp.thumb,tp.companyid,tp.companyname, tpb.productmaterial,tpb.productcolortitle,tpb.productcolorvalue,
productwidth,productheight,productlength,buyprice,markprice,saleprice ,isnull(tp.bannel,'') as bannel,tp.descript   
FROM dbo.t_product tp 
INNER JOIN dbo.t_productattribute tpb ON tpb.productid = tp.id
INNER JOIN t_brand ON t_brand.id = tp.brandid --AND t_brand.auditstatus=1 AND t_brand.linestatus=1
left JOIN t_company ON t_company.id = tp.companyid AND t_company.auditstatus=1 AND t_company.linestatus=1
WHERE tp.auditstatus =1 AND tp.linestatus =1   ";


            string id = Request.QueryString["id"];

            if (string.IsNullOrEmpty(id))
                id = ECommon.QueryPId;
            proid = id;
            if (id == null || id == "")
            {

                Response.Redirect(TREC.ECommerce.ECommon.WebUrl + "/productinfo2.aspx");
            }

            strsql = strsql + " AND tp.id = " + int.Parse(id) + " ; ";

            strsql += @"SELECT DISTINCT t_shop.id,t_shop.title ,address  FROM dbo.t_shop INNER JOIN t_productshopprice ON t_productshopprice.shopid =t_shop.id 
WHERE auditstatus =1 AND linestatus =1 AND t_productshopprice.productid =  " + int.Parse(id);

            DataSet ds = TREC.ECommerce.ECommerce.GetDataSet(strsql);
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count == 0)
                Response.Redirect(TREC.ECommerce.ECommon.WebUrl + "/productinfo2.aspx");

            imgpath = ECommon.WebUrl + "/upload/product/thumb/" + dt.Rows[0]["tpid"].ToString() + "/" + dt.Rows[0]["thumb"].ToString().TrimEnd(',');

            tpbid = dt.Rows[0]["tpbid"].ToString();
            title = "<span></span>" + dt.Rows[0]["tptitle"];
            title2 = dt.Rows[0]["tptitle"].ToString();
            _assemble = dt.Rows[0]["assemble"].ToString() == "1" ? "是" : "否";
            _prodSKN = dt.Rows[0]["sku"].ToString();
            _prodCZ = dt.Rows[0]["materialname"].ToString();
            if (!string.IsNullOrEmpty(dt.Rows[0]["sku"].ToString()))
            {
                title = title + "(" + dt.Rows[0]["sku"].ToString() + ")";
                title2 = title2 + "(" + dt.Rows[0]["sku"].ToString() + ")";

            }

            company = dt.Rows[0]["companyname"].ToString();
            brand = "<a href='" + ECommon.WebUrl + "/company/" + dt.Rows[0]["companyid"].ToString() + "/index.aspx'>" + dt.Rows[0]["brandtitle"].ToString() + "</a> ";
            fg = dt.Rows[0]["stylename"].ToString();
            xl = dt.Rows[0]["brandstitle"].ToString();
            ys = dt.Rows[0]["colorname"].ToString();
            
            //des = "<b>产品描述</b><br/>";// +dt.Rows[0]["descript"].ToString();
            TitleSEO = "[" + dt.Rows[0]["letter"].ToString() + title.Replace("<span>", "").Replace("</span>", "") + "]" + dt.Rows[0]["brandtitle"].ToString() + dt.Rows[0]["categorytitle"].ToString()+"正品专卖 –家具快搜网";
            keywordsSEO = "\n<meta id=\"keywords\" name=\"keywords\" content=\"" + dt.Rows[0]["brandtitle"].ToString() + dt.Rows[0]["sku"].ToString() + "," + title.Replace("<span>", "").Replace("</span>", "") + "," + dt.Rows[0]["letter"].ToString() + dt.Rows[0]["categorytitle"].ToString() + "\" />\n";
            DescriptionSEO = "<meta id=\"description\" name=\"description\" content=\"家具快搜网(www.jiajuks.com)" + dt.Rows[0]["brandtitle"].ToString() + "专卖店为您提供多款" + dt.Rows[0]["brandtitle"].ToString() + "家具(" + dt.Rows[0]["letter"].ToString() + " " + dt.Rows[0]["sku"].ToString() + "),其中" + title.Replace("<span>", "").Replace("</span>", "") + "是时尚居家品味,买(" + dt.Rows[0]["brandtitle"].ToString() + dt.Rows[0]["productno"].ToString() + ")就上家具快搜\" />";
            
            string categoryid = dt.Rows[0]["categoryid"].ToString();

            //如果con有值,则显示con内容; 如果con为空,des不为空,则显示des内容; 两者都不为空,显示con

            //m1 = ECProduct.GetProductConInfo("   contype =" + (int)EnumProductConType.风格特点 + " and productid=" + productInfo.id);
            //m2 = ECProduct.GetProductConInfo("   contype =" + (int)EnumProductConType.产品细节 + " and productid=" + productInfo.id);
            //m3 = ECProduct.GetProductConInfo("   contype =" + (int)EnumProductConType.材质工艺 + " and productid=" + productInfo.id);
            //m4 = ECProduct.GetProductConInfo("   contype =" + (int)EnumProductConType.保养说明 + " and productid=" + productInfo.id);
            //m5 = ECProduct.GetProductConInfo("   contype =" + (int)EnumProductConType.配送周期 + " and productid=" + productInfo.id);


            DataTable dtcon = ECommerce.GetTable("select  * from t_ProductCon where productid =  " + int.Parse(id));
            if (dtcon.Rows.Count != 0)
            {
                des += "<br /><br />";
                DataRow[] rows = dtcon.Select("   contype =" + (int)EnumProductConType.风格特点);

                if (rows.Length == 1)
                {
                    des += "<b>风格特点</b><br />" + rows[0]["con"].ToString() + "<br /><br />";
                }
                rows = dtcon.Select("   contype =" + (int)EnumProductConType.产品细节);

                if (rows.Length == 1)
                {
                    des += "<b>产品细节</b><br />" + rows[0]["con"].ToString() + "<br /><br />";
                }
                rows = dtcon.Select("   contype =" + (int)EnumProductConType.材质工艺);

                if (rows.Length == 1)
                {
                    des += "<b>材质工艺</b><br />" + rows[0]["con"].ToString() + "<br /><br />";
                }
                rows = dtcon.Select("   contype =" + (int)EnumProductConType.保养说明);

                if (rows.Length == 1)
                {
                    des += "<b>保养说明</b><br />" + rows[0]["con"].ToString() + "<br /><br />";
                }
                rows = dtcon.Select("   contype =" + (int)EnumProductConType.配送周期);

                if (rows.Length == 1)
                {
                    des += "<b>配送周期</b><br />" + rows[0]["con"].ToString() + "<br /><br />";
                }
            }



            string[] bannels = dt.Rows[0]["bannel"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in bannels)
            {
                imgs += "<img src='" + ECommon.WebUrl + "/upload/product/banner/" + dt.Rows[0]["tpid"].ToString() + "/" + item + "' class='block g10' alt='' />";
            }

            Dictionary<string, double> _dicprice = new Dictionary<string, double>();

           
                _dicprice.Add("市场参考价", double.Parse(dt.Rows[0]["markprice"].ToString()));
                _dicprice.Add("销售价", double.Parse(dt.Rows[0]["saleprice"].ToString()));
                _dicprice.Add("促销价", double.Parse(dt.Rows[0]["buyprice"].ToString()));


            //_dicprice.Values.Min();

            StringBuilder _jgvalue = new StringBuilder(string.Empty);
            int dicount=0;
            foreach (var item in _dicprice)
            {
                string css = "price1";
                dicount = dicount + 1;
                if (item.Value > 0 && item.Key == "促销价")
                {
                    css = "f16";
                }
                if (item.Value > 0 && item.Key == "销售价" && double.Parse(dt.Rows[0]["buyprice"].ToString())==0)
                {
                    css = "f16";
                }

                string keyname = item.Key;
                if (item.Key == "促销价")
                {
                    keyname = ECProduct.CheckbuypriceName(id);
                }

                if (item.Value > 0)
                {

                    _jgvalue.Append("<span id='price" + dicount + "' class='" + css + "'>" + keyname + "：￥" + item.Value + "</span></br>");
                }
                else
                {
                    _jgvalue.Append("<span id='price" + dicount + "' class='" + css + "' style='display:none;'>" + keyname + "：￥" + item.Value + "</span></br>");
                }
            }
            jg = _jgvalue.ToString();
            //double pricecheck = 0;
            //pricecheck = double.Parse(dt.Rows[0]["buyprice"].ToString()) > 0 ? double.Parse(dt.Rows[0]["buyprice"].ToString()) : double.Parse(dt.Rows[0]["markprice"].ToString());
            //string price1css = string.Empty, price2css = string.Empty;
          
            //if (pricecheck >= double.Parse(dt.Rows[0]["saleprice"].ToString()))
            //{
            //    price2css = "price1";
            //    price1css = "f16";
            //}
            //else
            //{
            //    price1css = "price1";
            //    price2css = "f16";
            //}
            //string cxj = double.Parse(dt.Rows[0]["buyprice"].ToString()) > 0 ? "<span id='price2' class='" + price2css + "' style='price b'>促销价：￥" + dt.Rows[0]["buyprice"].ToString() + "</span>" : "<span id='price2' style='price b'  class='" + price2css + "'>市场价：￥" + dt.Rows[0]["markprice"].ToString() + "</span>";
            //if (pricecheck < double.Parse(dt.Rows[0]["saleprice"].ToString()))
            //{
            //    jg = "<span id='price1' class='" + price1css + "'>销售价：￥" + dt.Rows[0]["saleprice"].ToString() + "</span></br>" + cxj;
            //}
            //else
            //{
            //    jg = cxj + "</br><span id='price1' class='" + price1css + "'>销售价：￥" + dt.Rows[0]["saleprice"].ToString() + "</span>";
            //}


            //材质
            cz = "<select id='selcz'>";
            cc = "<select id='selcc'>";

            int attrcont = 0;
            foreach (DataRow dr in dt.Rows)
            {
                //if (attrcont == 0  )
                //{
                //     attrcont++;
                if (dr["ProductAttributePromotion"].ToString() == "1")
                    attrpromotion = "<img src='/resource/content/images/qg.jpg' onclick='addBAOMING(" + dr["tpid"].ToString() + ",\"" + Server.UrlEncode(title.Replace("<span></span>", "")) + "\"," + dr["tpid"].ToString() + ");' />";
                //cz += "<option value='" + dr["tpbid"].ToString() + "' tpid='" + dr["tpid"].ToString() + "' pt='" + dr["ProductAttributePromotion"].ToString() + "' price1= '" + dr["buyprice"].ToString() + "'  price2= '" + dr["saleprice"].ToString() + "' >" + dr["productmaterial"].ToString() + "</option>";
                //cc += "<option value='" + dr["tpbid"].ToString() + "' tpid='" + dr["tpid"].ToString() + "' pt='" + dr["ProductAttributePromotion"].ToString() + "' price1= '" + dr["buyprice"].ToString() + "'  price2= '" + dr["saleprice"].ToString() + "' >" + dr["productlength"].ToString() + "*" + dr["productwidth"].ToString() + "*" + dr["productheight"].ToString() + "</option>";
                //}
                //else
                //{
                // attrpromotion = "";
                cz += "<option value='" + dr["tpbid"].ToString() + "' tpid='" + dr["tpid"].ToString() + "' pt='" + dr["ProductAttributePromotion"].ToString() + "' price1= '" + dr["markprice"].ToString() + "'  price2= '" + dr["saleprice"].ToString() + "'   price3= '" + dr["buyprice"].ToString() + "'>" + dr["productmaterial"].ToString() + "</option>";
                cc += "<option value='" + dr["tpbid"].ToString() + "' tpid='" + dr["tpid"].ToString() + "' pt='" + dr["ProductAttributePromotion"].ToString() + "' price1= '" + dr["markprice"].ToString() + "'  price2= '" + dr["saleprice"].ToString() + "'   price3= '" + dr["buyprice"].ToString() + "'>" + dr["productlength"].ToString() + "*" + dr["productwidth"].ToString() + "*" + dr["productheight"].ToString() + "</option>";
                //}
            }
            cz = cz + "</select>";
            cc = cc + "</select>";



            dt = ds.Tables[1];

            foreach (DataRow dr in dt.Rows)
            {
                dp += "<h4><span>[店铺]</span><a target='_blank' href='" + ECommon.WebUrl + "/shop/" + dr["id"].ToString() + "/index.aspx' class='b f14'>" + dr["title"].ToString() + "</a></h4>";
                dp += "<p class='address'>" + dr["address"].ToString() + "</p>";
                //1.产品促销价格和指导价不同为促销
                //2.店铺参加促销活动
                //<p class='phone'><span class='prom'>[优惠]</span>欢迎来电咨询促销优惠信息 </p>
            }


            strsql = @" SELECT DISTINCT TOP 4 t_shop.id,dbo.t_shop.title,dbo.t_shop.address,dbo.t_shop.phone,t_shop.thumb ,
 t_marketstoreyshop.markettitle,t_marketstoreyshop.marketid
 FROM dbo.t_product 
 INNER JOIN dbo.t_shopbrand ON t_shopbrand.brandid = t_product.brandid 
 INNER JOIN dbo.t_shop ON dbo.t_shop.id = dbo.t_shopbrand.shopid
INNER JOIN dbo.t_marketstoreyshop ON t_marketstoreyshop.shopid = dbo.t_shop.id 
WHERE dbo.t_product.id =" + int.Parse(id);


            dt = TREC.ECommerce.ECommerce.GetTable(strsql);


            System.Text.StringBuilder strb = new System.Text.StringBuilder();

            DataRow row;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = dt.Rows[i];
                if (i == 0)
                    strb.Append("<tr>");
                else if (i % 2 == 0 && i != 0 && i != dt.Rows.Count)
                    strb.Append("</tr><tr>");
                else
                    strb.Append("</tr>");

                strb.Append("<td>");
                strb.Append("<div class='bd-t f14 b'>" + row["title"].ToString() + " <span>" + row["phone"].ToString() + "</span></div>");
                strb.Append("<div class='clearfix'>");
                strb.Append("<div class='fl image'>");
                strb.Append("<img src='" + ECommon.WebUrl + "/upload/shop/thumb/" + row["id"].ToString() + "/" + row["thumb"].ToString().TrimEnd(',') + "' />");
                strb.Append("</div>");
                strb.Append("<div class='fl bd-c-r'>");
                strb.Append("<div>所在卖场：<span>" + row["markettitle"].ToString() + "</span></div>");
                strb.Append("<div>" + row["address"].ToString() + "</div>");
                //参加了活动,则显示活动内容 select top 1 * from 促销信息表/活动表
                strb.Append("<div class='div-on' style='display:none'>[促销]<span>玉庭哈儿滨点开业</span></div>");
                strb.Append("</div>");
                strb.Append("</div>");
                strb.Append("</td>");
            }
            qtdp = "<table class='g10'>" + strb.ToString() + "</table>";


            List<producttype> listcategory2 = TRECommon.DataCache.GetCache("producttypeall") as List<TREC.Entity.producttype>;
            if (listcategory2 == null)
                listcategory2 = TREC.ECommerce.ECProduct.GetProductTypeAll();

            producttype pt = listcategory2.Find(x => x.tpid.ToString() == categoryid);
            // tp2id,tpid ,tp2title, tptitle
            //产品productlist,淘宝贝productlisttbb

            string url = "productlist";
            if (Request.UrlReferrer != null)
                if (Request.UrlReferrer.AbsoluteUri.Contains("tbb.aspx"))//从淘宝贝点击到详情页
                    url = "productlisttbb";

            nav = "<a href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/" + url + ".aspx?did=" + pt.tp2id + "'>" + pt.tp2title + "</a> &gt; <a href='" + TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/" + url + ".aspx?did=" + pt.tp2id + "&xid=" + pt.tpid + "'>" + pt.tptitle + "</a> &gt; " + title;


        }

        /// <summary>
        /// 本品牌其它产品
        /// </summary>
        public List<EnWebProduct> BrandProductList
        {
            get
            {
                if (brandProductList == null)
                    brandProductList = ECProduct.GetWebProductList(1, 3, " and (brandid=" + productInfo.brandid + " and categoryid=" + productInfo.categoryid + ")", "", "", out tmpPageCount);
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
                    othenBrandProductList = ECProduct.GetWebProductList(1, 3, " and (brandid!=" + productInfo.brandid + " and categoryid=" + productInfo.categoryid + ")", "", "", out tmpPageCount);
                return othenBrandProductList;
            }
        }

        List<EnWebProduct> brandProductList = null, othenBrandProductList = null;
    }
}