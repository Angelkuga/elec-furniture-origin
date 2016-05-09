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
    public class MarketPageBase : System.Web.UI.Page
    {
        public static int tmpPageCount = 0;
        public static string webNmame = "家具快搜";

        public string _pageTitle;
        public string pageTitle { get {
            return webNmame + _pageTitle;
        }
            set {
                _pageTitle = value;
            }
        }
       
        public static EnWebMarket marketInfo = new EnWebMarket();

      
        public MarketPageBase()
        {
            
                if (ECommon.QueryMid == "" || ECommon.QueryMid == "0")
                {
                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(),
                        System.Guid.NewGuid().ToString(),
                        "<script>window.top.location.href='" + ECommon.WebUrl + "'</script>"
                        );
                }
                else
                {
                    marketInfo = ECMarket.GetWebMarketInfo(" where id=" + ECommon.QueryMid);
                }


            if (!HttpContext.Current.Request.RawUrl.Contains("index2.aspx"))
            {
                if (marketInfo.template == null || marketInfo.template == "0")
                {
                    HttpContext.Current.Response.Redirect(WebUtils.ResolveUrl("~/" + string.Format(EnUrls.MarketInfoIndex2, marketInfo.id)));
                    return;
                }
            }
        }

        

    }
}
