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


    public partial class productinfo : WebPageBase
    {
        public EnWebProduct productInfo = new EnWebProduct();
        public EnProductCon m1 = new EnProductCon();
        public EnProductCon m2 = new EnProductCon();
        public EnProductCon m3 = new EnProductCon();
        public EnProductCon m4 = new EnProductCon();
        public EnProductCon m5 = new EnProductCon();
        protected LinqDataContext db = new LinqDataContext();
        protected List<Mpromotions> shoppromotions = new List<Mpromotions>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ECommon.QueryPId != "")
            {
                productInfo = ECProduct.GetWebProducInfo(" where id=" + ECommon.QueryPId);
                if (productInfo == null || productInfo.id == 0)
                {
                    return;//产品未审核和上线。。
                }
                m1 = ECProduct.GetProductConInfo(" where contype =" + (int)EnumProductConType.风格特点 + " and productid=" + productInfo.id);
                m2 = ECProduct.GetProductConInfo(" where contype =" + (int)EnumProductConType.产品细节 + " and productid=" + productInfo.id);
                m3 = ECProduct.GetProductConInfo(" where contype =" + (int)EnumProductConType.材质工艺 + " and productid=" + productInfo.id);
                m4 = ECProduct.GetProductConInfo(" where contype =" + (int)EnumProductConType.保养说明 + " and productid=" + productInfo.id);
                m5 = ECProduct.GetProductConInfo(" where contype =" + (int)EnumProductConType.配送周期 + " and productid=" + productInfo.id);

                var shopids = productInfo.ProductShopList.Select(c => Convert.ToInt32(c.id)).ToArray();
                shoppromotions = db.promotions.Where(c => c.auditstatus == 1 && c.linestatus == 1).GroupJoin(db.promotionsrelated, c => c.id, c => c.promotionsid, (f, k) => new { f, k })
                    .Where(c => c.k.Where(j => j.shopid > 0 && shopids.Contains(j.shopid)).Any()).ToList()
                .Select(c => new Mpromotions
                {
                    id = c.f.id,
                    title = c.f.title,
                    letter = c.f.letter,
                    sort = c.f.sort,
                    IsRecommend = c.f.IsRecommend,
                    lastedmtime = c.f.lastedmtime,
                    promotionsrelated = c.k.ToList()
                }).OrderByDescending(c => c.IsRecommend).ThenByDescending(c => c.lastedmtime).ToList();

                pageTitle = productInfo.brandtitle + " " + productInfo.stylename + " " + productInfo.categorytitle + " (" + productInfo.sku + ") " + " " + productInfo.materialname + "产品信息";
            }


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