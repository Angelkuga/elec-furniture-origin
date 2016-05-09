using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;
using System.Data;

namespace TREC.ECommerce
{
    public class CompanyPageBase : System.Web.UI.Page
    {
        public static int tmpPageCount = 0;
        public static string webNmame = "家具快搜";

        public static string setvalue = "-1";
        public static string StyleString = string.Empty;//品牌下系列的id

        public string _pageTitle;
        public string pageTitle
        {
            get
            {
                return webNmame + _pageTitle;
            }
            set
            {
                _pageTitle = value;
            }
        }

        public static EnWebCompany _companyInfo = new EnWebCompany();

        public static EnWebCompany companyInfo
        {
            get
            {
                if (ECommon.QueryCId == "" || ECommon.QueryCId == "0")
                {

                }
                else
                {
                    _companyInfo = ECCompany.GetWebCompanyInfo(" where id=" + ECommon.QueryCId);
                }
                return _companyInfo;
            }
            set
            {
                _companyInfo = value;
            }
        }

        public static bool IsCount = true;
        
        public CompanyPageBase()
        {
            if (ECommon.QueryCId == "" || ECommon.QueryCId == "0")
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(),
                    System.Guid.NewGuid().ToString(),
                    "<script>window.top.location.href='" + ECommon.WebUrl + "'</script>"
                    );
            }
            else
            {
                companyInfo = ECCompany.GetWebCompanyInfo(" where id=" + ECommon.QueryCId);
                List<EnBrands> list = new List<EnBrands>();
                if (companyInfo != null && companyInfo.CompanyBrandInfo != null && !string.IsNullOrEmpty(companyInfo.CompanyBrandInfo.id))
                {
                    IsCount = true;
                    list = ECBrand.GetBrandsList(" brandid=" + companyInfo.CompanyBrandInfo.id);
                }
                else
                {
                    list = new List<EnBrands>();
                    IsCount = false;
                }

                if (list.Count > 0)
                {
                    int i = 0;
                    foreach (EnBrands item in list)
                    {
                        if (string.IsNullOrEmpty(item.style))
                        {
                            continue;
                        }
                        if (i == 0)
                        {
                            StyleString = item.style;
                        }
                        else
                        {
                            StyleString += "," + item.style;
                        }
                        i++;
                    }
                }
                if (string.IsNullOrEmpty(StyleString))
                {
                    StyleString = "0";
                }
            }

            if (!HttpContext.Current.Request.RawUrl.Contains("index2.aspx"))
            {
               // if (companyInfo == null || companyInfo.id == 0 || companyInfo.template == null || companyInfo.template == "0")
                if (companyInfo == null || companyInfo.id == 0 )
                {
                    HttpContext.Current.Response.Redirect(WebUtils.ResolveUrl("~/" + string.Format(EnUrls.CompanyInfoIndex2, companyInfo.id)));
                    return;
                }
            }

        }



    }
}
