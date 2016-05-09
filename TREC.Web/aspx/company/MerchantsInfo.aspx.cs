using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TREC.Web.aspx.company
{


    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    #endregion


    public partial class MerchantsInfo : CompanyPageBase
    {
        public int BrandId = 0;
        public string BrandDescript = "";
        protected CompanyBrand currentBrand = new CompanyBrand();
        protected EnMerchants Model = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "-" + companyInfo.title + "-招商信息";
            CompanyPageBase.setvalue = "-99";

            string strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_a") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);
            strqsb = (ECommon.QuerySearchBrand.ToLower().Contains("_b") ? ECommon.QuerySearchBrand.Substring(0, ECommon.QuerySearchBrand.Length - 2) : ECommon.QuerySearchBrand);


            if (strqsb == "" && companyInfo.CompanyBrandList.Count > 0)
            {
                BrandId = TypeConverter.StrToInt(companyInfo.CompanyBrandList[0].id);
                BrandDescript = companyInfo.CompanyBrandList[0].descript;
                currentBrand = companyInfo.CompanyBrandList[0];
            }
            else
            {
                //companyInfo.CompanyBrandList.Find(x=>x.id.ToString()==ECommon.QuerySearchBrand).descript
                if (companyInfo.CompanyBrandList.Count == 0)
                {
                    ScriptUtils.ShowAndRedirect("暂无品牌!", ECommon.WebUrl + "/company/" + companyInfo.id + "/index.aspx");
                    return;
                }
                currentBrand = companyInfo.CompanyBrandList.Find(x => x.id.ToString() == strqsb);
                BrandId = TypeConverter.StrToInt(currentBrand.id);
                BrandDescript = currentBrand.descript;
            }

            if (!string.IsNullOrEmpty(ECommon.QueryMerchantid))
            {
                Model = ECMerchants.GetMerchantsInfo(" where id=" + ECommon.QueryMerchantid);

                string dd = WebRequest.GetQueryString("h");
                if (dd == "postval")
                {

                    string name = Request.QueryString["n"];
                    string phone = Request.QueryString["p"];
                    string Selectedvalue = Request.QueryString["c"];
                    string descript = Request.QueryString["d"];

                    if (Validator.IsSafeSqlString(Selectedvalue) && Validator.IsSafeSqlString(descript) && Validator.IsSafeSqlString(name) && Validator.IsSafeSqlString(phone))
                    {
                        EnMerchantsMember models = new EnMerchantsMember();
                        models.Cid = Convert.ToInt32(ECommon.QueryCid);
                        models.CityCode = Selectedvalue;
                        models.CreateTime = DateTime.Now;
                        models.Descript = descript;
                        models.MerchantId = Convert.ToInt32(ECommon.QueryMerchantid);
                        models.Name = name;
                        models.Phone = phone;
                        int aid = ECMerchantsMember.EditMerchants(models);
                        if (aid > 0)
                        {
                            EnMerchants modelss = new EnMerchants();
                            modelss.Id = models.MerchantId;
                            modelss.Membercount = 1;
                            ECMerchants.EditMerchantsCount(modelss);
                        }
                    }
                    HttpContext.Current.Response.Redirect(ECommon.WebUrl + "company/" + ECommon.QueryCid + "/MerchantsInfo-" + ECommon.QueryMerchantid + ".aspx");
                }
                else
                {

                }
            }

        }
    }
}