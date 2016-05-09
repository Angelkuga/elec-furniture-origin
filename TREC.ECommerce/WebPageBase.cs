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
    public class WebPageBase:System.Web.UI.Page
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

        

    }
}
