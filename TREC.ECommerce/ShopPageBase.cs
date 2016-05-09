using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.ECommerce
{
    public class ShopPageBase : System.Web.UI.Page
    {
        public static int tmpPageCount = 0;
        public static string webNmame = "家具快搜";
        public static string setvalue = "-1";

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

        public static EnWebShop shopInfo = new EnWebShop();
        public static bool IsCount = true;
        public static string StyleString = string.Empty;//品牌下系列的id
        public ShopPageBase()
        {
            if (ECommon.QuerySId == "" || ECommon.QuerySId == "0")
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(),
                    System.Guid.NewGuid().ToString(),
                    "<script>window.top.location.href='" + ECommon.WebUrl + "'</script>"
                    );
            }
            else
            {
                shopInfo = ECShop.GetWebShopInfo(" where id=" + ECommon.QuerySId);
                List<EnBrands> list = new List<EnBrands>();
                if (shopInfo != null && shopInfo.ShopBrandInfo != null && !string.IsNullOrEmpty(shopInfo.ShopBrandInfo.id))
                {
                    IsCount = true;
                    ECBrand.GetBrandsList(" brandid=" + shopInfo.ShopBrandInfo.id);
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
                if (shopInfo.template == null || shopInfo.template == "0")
                {
                    HttpContext.Current.Response.Redirect(WebUtils.ResolveUrl("~/" + string.Format(EnUrls.ShopInfoIndex2, shopInfo.id)));
                    return;
                }
            }
        }





    }
}
