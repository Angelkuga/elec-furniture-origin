using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;

namespace TREC.Web.aspx.company
{


    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    using System.Data;
    #endregion


    public partial class address : CompanyPageBase
    {
        public string GetPromotionsInfor(int companyid, string phone)
        {
            DataTable dt = new DataTable();

            dt = ECCompany.GetPromotionsInfor(companyid);

            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["title"].ToString()+ "<a hef='/company/" + companyid + "/promotions/" + dt.Rows[0]["Id"].ToString() + "/info.aspx' style='color:red;'>更多</a>";
            }
            else
            {
                return "欢迎致电:" + phone;
            }
        }
        public int BrandId = 0;
        public string BrandTitle = "";
        public List<EnWebShop> list = new List<EnWebShop>();
        public string shopMaps = "";
        protected Dpromotions dpromotions = new Dpromotions();
        protected List<Mpromotions> promotionslist = new List<Mpromotions>();

        public bool isPay = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            CompanyPageBase.setvalue = "-99";
            rows = darea.Select();
            pageTitle = "-" + companyInfo.title + "-店铺地址";
            string strWhere = "";

            string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);

            if (companyInfo != null)
            {
                isPay = SupplerPageBase.IsPayMember(CompanyPageBase.companyInfo.mid.ToString());
            }
            if (strqsb == "" && companyInfo.CompanyBrandList.Count > 0)
            {
                //BrandId = TypeConverter.StrToInt(companyInfo.CompanyBrandList[0].id);
                BrandId = SubmitMeth.getInt(companyInfo.CompanyBrandList[0].id);
                BrandTitle = companyInfo.CompanyBrandList[0].title;
                strWhere += " and (brandxml like '%<id>" + BrandId + "</id>%'";
                for (var i = 1; i < companyInfo.CompanyBrandList.Count; i++)
                {
                    strWhere += " or brandxml like '%<id>" + companyInfo.CompanyBrandList[i].id + "</id>%'";
                }
                strWhere += ") ";
            }
            else
            {
                if (companyInfo.CompanyBrandList.Count == 0)
                {
                    ScriptUtils.ShowAndRedirect("暂无品牌!", ECommon.WebUrl + "/company/" + companyInfo.id + "/index.aspx");
                    return;
                }

                //companyInfo.CompanyBrandList.Find(x=>x.id.ToString()==ECommon.QuerySearchBrand).descript
                BrandId = TypeConverter.StrToInt(companyInfo.CompanyBrandList.Find(x => x.id.ToString() == strqsb).id);
                BrandTitle = companyInfo.CompanyBrandList.Find(x => x.id.ToString() == strqsb).title;
                strWhere = " and brandxml like '%<id>" + BrandId + "</id>%'";
            }
            if (ECommon.QuerySearchArea != "" && ECommon.QuerySearchArea != "0")
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder("'" + ECommon.QuerySearchArea + "'");
                froe(sb, ECommon.QuerySearchArea);
                strWhere += " and areacode in(" + sb.ToString() + ")";
            }
            int pageCount = 0;
            string sortKey = "lastedittime";
            string orderType = "desc";
            //string strWhere = " and brandxml like '%<id>" + BrandId + "</id>%'";

            list = ECShop.GetWebShopList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, sortKey, orderType, out pageCount);
            AspNetPager1.RecordCount = pageCount;
            AspNetPager1.EnableUrlRewriting = true;

            AspNetPager1.UrlRewritePattern = string.Format(EnUrls.CompanyInfoAddressList, ECommon.QueryCid, strqsb, "{0}");

            myareaselect.SelectedAreaID = ECommon.QuerySearchArea;

            var shopids = list.Select(c => c.id).ToArray();
            promotionslist = dpromotions.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1).GroupJoin(dpromotions.LinqData<Mpromotionsrelated>().Where(c => c.shopid > 0 && shopids.Contains(c.shopid)), c => c.id, c => c.promotionsid, (f, k) => new { f, k }).Where(c => c.k.Any(j => shopids.Contains(j.shopid))).ToList().Select(c => new Mpromotions
            {
                id = c.f.id,
                title = c.f.title,
                letter = c.f.letter,
                sort = c.f.sort,
                IsRecommend = c.f.IsRecommend,
                IsTop = c.f.IsTop,
                promotionsrelated = c.k.ToList()
            }).OrderByDescending(c => c.IsRecommend).ThenByDescending(c => c.IsTop).ToList();
        }
        Haojibiz.DAL.Darea darea = new Haojibiz.DAL.Darea();
        MareaCollection rows = new MareaCollection();
        void froe(System.Text.StringBuilder s, string p)
        {
            foreach (var item in rows.Where(c => c.parentcode == p))
            {
                s.AppendFormat(",'{0}'", item.areacode);
                froe(s, item.areacode);
            }
        }

        /// <summary>
        /// AspNetPager1 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::Wuqi.Webdiyer.AspNetPager AspNetPager1;

        List<EnArea> _AreaList = null;
        protected List<EnArea> AreaList
        {
            get
            {
                if (_AreaList == null)
                {
                    var areas = list.Select(c => c.areacode).Distinct().ToArray();
                    string s = "";
                    for (var i = 0; i < areas.Length; i++)
                    {
                        if (i != 0)
                        {
                            s += ",";
                        }
                        s += areas[i];
                    }
                    if (s == "")
                    {
                        s = "0";
                    }
                    _AreaList = ECArea.GetAreaList(" areacode in(" + s + ")");
                }
                return _AreaList;
            }
        }

        protected global::TREC.Web.aspx.ascx._AreaSelect myareaselect;
    }
}