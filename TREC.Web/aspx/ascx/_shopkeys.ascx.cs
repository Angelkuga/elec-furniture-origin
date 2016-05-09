using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.aspx.ascx
{
    public partial class _shopkeys : System.Web.UI.UserControl
    {
        protected string title = "";
        protected string keywords = "";
        protected string description = "";

        private string _title = string.Empty;
        /// <summary>
        /// title后带字符
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ECommon.QuerySId) || ECommon.QuerySId != "0")
            {
                EnShop enshop = ECShop.GetShopInfo(" where id=" + ECommon.QuerySId);
                if (enshop != null && !string.IsNullOrEmpty(enshop.keywords))
                {
                    string[] str = enshop.keywords.Split('|');
                    if (str.Length > 0)
                    {
                        title = str[0] + _title;
                    }
                    else
                    {
                        title = enshop.title + "-家具快搜";
                    }
                    if (str.Length > 1)
                    {
                        keywords = str[1];
                    }
                    if (str.Length > 2)
                    {
                        description = str[2];
                    }
                }
            }
        }
    }
}