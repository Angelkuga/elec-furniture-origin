using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREC.Entity;
using TRECommon;

namespace TREC.ECommerce
{
    public class MarketCliquePageBase : System.Web.UI.Page
    {

        public string Clique
        {
            get
            {
                return WebRequest.GetQueryString("id");
            }
        }

        public string mid
        {
            get
            {
                return WebRequest.GetQueryString("mid");
            }
        }

        public string title
        {
            get
            {
                return WebRequest.GetQueryString("title");
            }
        }
       public EnMarketClique _marketcliquemodel = new EnMarketClique();
       public int cliqueId = 0;


       public static int tmpPageCount = 0;
       public static string webNmame = "家具快搜";

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
       public  EnWebMarket marketInfo = new EnWebMarket();
        public MarketCliquePageBase()
        {
            if (!string.IsNullOrEmpty(Clique))
                {
                    _marketcliquemodel = TREC.ECommerce.ECMarketClique.GetMarketCliqueByWhere(" where id=" + Clique + " and Auditstatus=1");
                }
            else if (!string.IsNullOrEmpty(mid))
                {
                    EnMarket _marketinfor = ECMarket.GetMarketInfo(" where id=" + mid);
                    _marketcliquemodel = TREC.ECommerce.ECMarketClique.GetMarketCliqueByWhere(" where stitle='" + _marketinfor.Stitle + "' and Auditstatus=1");
                }
             else if (!string.IsNullOrEmpty(title))
             {
                 _marketcliquemodel = TREC.ECommerce.ECMarketClique.GetMarketCliqueByWhere(" where title='" + title + "' and Auditstatus=1");
             }

             if (_marketcliquemodel!=null)
             {
                 cliqueId = _marketcliquemodel.Id;
             }
        }

    }
}
