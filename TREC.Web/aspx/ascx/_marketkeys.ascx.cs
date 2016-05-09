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
    public partial class _marketkeys : System.Web.UI.UserControl
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
            if (!string.IsNullOrEmpty(ECommon.QueryMid) || ECommon.QueryMid != "0")
            {
                EnMarket enmarket = ECMarket.GetMarketInfo(" where id=" + ECommon.QueryMid);
                if (enmarket != null && !string.IsNullOrEmpty(enmarket.keywords))
                {
                    string[] str = enmarket.keywords.Split('|');
                    if (str.Length > 0)
                    {
                        title = str[0] + _title;
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

                if (string.IsNullOrEmpty(title))
                {
                    title = "【" + enmarket.title + "官网】" + enmarket.title + "卖场," + enmarket.title + "网上商城," + enmarket.title + "团购,上海" + enmarket.title + " - 家具快搜网";
                }
            }
        }
    }
}