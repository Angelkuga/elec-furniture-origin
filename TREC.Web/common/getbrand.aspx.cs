using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.common
{
    public partial class getbrand : System.Web.UI.Page
    {
        public List<EnWebBrand> brandList = new List<EnWebBrand>();
        protected string c = "";
        protected string v = "";
        protected string t = "";
        protected string m = "";
        protected string mt = "";

        protected void Page_Load(object sender, EventArgs e)
        {
             t = ECommon.QueryType;
             v= ECommon.QueryValue;
             c= ECommon.QueryContorl;
             m = ECommon.QueryMid;
             mt = ECommon.QueryMemberType;
            string strWhere = "";


            if (v != "")
            {
                int count=0;
                v = v.StartsWith(",") ? v.Substring(1, v.Length - 1) : v;
                v = v.EndsWith(",") ? v.Substring(0, v.Length - 1) : v;
                strWhere += " id in(select brandid from t_shopbrand where shopid=" + v + ")";
                brandList = ECBrand.GetWebBrandList(1, 1000, strWhere, out count);
                hfvalue.Value = "";
                if (brandList.Count > 0)
                {
                    foreach (EnWebBrand b in brandList)
                    {
                        hfvalue.Value += b.id + ",";
                    }
                }
            }

        }
    }
}