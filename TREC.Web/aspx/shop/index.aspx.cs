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
    using System.Collections;
    using System.Text;
    #endregion


    public partial class index : ShopPageBase
    {
        public BrandCompanyInfo brandcompanyInfo = new BrandCompanyInfo();
        protected LinqDataContext db = new LinqDataContext();
        protected List<Mpromotions> promotionslist = new List<Mpromotions>();
        public Hashtable _htb = new Hashtable();//数据统计


        public string getdid
        {
            get
            {
                if (Request["did"] != null)
                {
                    return Request["did"];
                }
                else
                {
                    return "0";
                }
            }
        }
        public string adv = "";
        public string advstyle = "none";


        public string getbannelImg
        {
            get
            {
                try
                {
                    if (shopInfo != null)
                    {
                        if (shopInfo.bannel.Length > 5)
                        {
                            StringBuilder _value = new StringBuilder(string.Empty);

                            foreach (string s in shopInfo.bannel.Split(','))
                            {
                                if (s.Length > 2)
                                {
                                    _value.Append(" <div class=\"item\">");
                                    _value.Append("<a href=\"#\" title=\"" + shopInfo.title + "\" class=\"block\">");
                                    _value.Append(" <img class=\"block\" src=\"/upload/shop/banner/" + shopInfo.id + "/" + s + "\" alt=\"" + shopInfo.title + "\" width=\"947\" height=\"449\" style=\"width: 947px; height: 449px;\" /></a>");
                                    _value.Append("</div>");
                                }
                            }
                            return _value.ToString();
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                catch
                {
                    return string.Empty;
                }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            _htb = ECProduct.GetIndexCount().FirstOrDefault();


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


            System.Data.DataTable dt = TREC.ECommerce.ECommerce.GetTable("exec proc_shoppromotions " + shopInfo.id + ", 3 ");

            System.Text.StringBuilder strb = new System.Text.StringBuilder();

            foreach (System.Data.DataRow dr in dt.Rows)
            {
                strb.Append("<div class='item'>");
                strb.Append("<a href='#' class='block img fl'>");
                strb.Append("<img class='block' style='width:606px;height:304px;' src='"+TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')+"/upload/promotion/surface/"+dr["id"]+"/" + dr["surface"] + "' alt='' /></a>");
                strb.Append("<div class='txt fl'>");
                strb.Append("<p class='p1'>");
                strb.Append("<a href='#' class='block f18 yahei lh3'>"+dr["title"]+"</a></p>");
                strb.Append(dr["descript"]);
                strb.Append("</div>");
                strb.Append("</div>");
            }
            adv = strb.ToString();
            if (dt.Rows.Count > 0)
                advstyle = "block";
        }
        protected global::TREC.Web.aspx.ascx._shopproduct _shopproduct1;
    }
    public class BrandCompanyInfo
    {
        public EnBrand BrandInfo { get; set; }
        public EnCompany CompanyInfo { get; set; }
    }
}