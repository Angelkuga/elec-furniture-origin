using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;
using System.Data.Linq;

namespace TREC.Web.aspx.shop
{


    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    #endregion


    public partial class indexn : ShopPageBase
    {
        public BrandCompanyInfo brandcompanyInfo = new BrandCompanyInfo();
        protected LinqDataContext db = new LinqDataContext();
        protected List<Mpromotions> promotionslist = new List<Mpromotions>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ShopPageBase.setvalue = "-99";
            pageTitle = "-" + shopInfo.title + "-经销店铺-首页";
            #region [李祥加上去的]  加了还是出错，改了
            if (!string.IsNullOrEmpty(shopInfo.ShopBrandInfo.id)) //if (shopInfo.ShopBrandInfo.id != "")
            {
                brandcompanyInfo.BrandInfo = ECBrand.GetBrandInfo("where id=" + shopInfo.ShopBrandInfo.id);
                if (brandcompanyInfo.BrandInfo != null && brandcompanyInfo.BrandInfo.companyid != null)
                {
                    brandcompanyInfo.CompanyInfo = ECCompany.GetCompanyInfo("where id=" + brandcompanyInfo.BrandInfo.companyid.Value.ToString());
                }
            }
            _shopproduct1.brandid = shopInfo.ShopBrandInfo.id;
            promotionslist = db.promotions.Where(c => c.auditstatus == 1 && c.linestatus == 1).GroupJoin(db.promotionsrelated.Where(c => c.shopid > 0 && c.shopid == shopInfo.id), c => c.id, c => c.promotionsid, (f, k) => new { f, k }).Where(c => c.k.Any(j => j.shopid == shopInfo.id)).ToList()
                .Select(c => new Mpromotions
                {
                    id = c.f.id,
                    title = c.f.title,
                    letter = c.f.letter,
                    sort = c.f.sort,
                    startdatetime = c.f.startdatetime,
                    enddatetime = c.f.enddatetime,
                    IsRecommend = c.f.IsRecommend,
                    IsTop = c.f.IsTop,
                    promotionsrelated = c.k.ToList()
                }).OrderByDescending(c => c.IsRecommend).ThenByDescending(c => c.IsTop).ToList();

            #endregion

        }
        protected global::TREC.Web.aspx.ascx._shopproduct _shopproduct1;
    }
    //public class BrandCompanyInfo
    //{
    //    public EnBrand BrandInfo { get; set; }
    //    public EnCompany CompanyInfo { get; set; }
    //}
}