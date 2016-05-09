using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Suppler.f_market
{
    public partial class nav : System.Web.UI.UserControl
    {
        protected string s1css = "", s2css = "", s3css = "", s4css = "", s1url = "javascript:;", s2url = "javascript:;", s3url = "javascript:;", s4url = "javascript:;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (SupplerPageBase.marketInfo != null && SupplerPageBase.marketInfo.id != 0)
                {

                    List<EnMarketStorey> mslist=ECMarketStorey.GetMarketStoreyList(" marketid="+SupplerPageBase.marketInfo.id);
                    bool hasCompany = false, hasBrand = false, hasBrands = false;
                    s1css = "now";
                    s1url = "javascript:;";
                    if (SupplerPageBase.marketInfo.title != null && SupplerPageBase.marketInfo.title != "" && SupplerPageBase.marketInfo.zphone != null && SupplerPageBase.marketInfo.zphone != "" && SupplerPageBase.marketInfo.address != null && SupplerPageBase.marketInfo.address != "")
                    {
                        hasCompany = true;
                        s1css = "has";
                        s1url = "setup1.aspx";
                        s2css = "now";
                        s2url = "setup2.aspx";
                    }

                    if (WebUtils.GetPageName() != "setup1.aspx" && (SupplerPageBase.marketInfo.title == null || SupplerPageBase.marketInfo.title == "" || SupplerPageBase.marketInfo.zphone == null || SupplerPageBase.marketInfo.zphone == "" || SupplerPageBase.marketInfo.address == null || SupplerPageBase.marketInfo.address == ""))
                    {
                        Response.Redirect("setup1.aspx");
                        return;
                    }

                    if (mslist.Count > 0)
                    {
                        hasBrand = true;
                        s2css = "has";
                        s4css = "now";
                        s4url = "../index.aspx";
                    }

                    //if (WebUtils.GetPageName() != "setup2.aspx" && WebUtils.GetPageName() != "setup1.aspx" && (mslist == null || mslist.Count <= 0))
                    //{
                    //    Response.Redirect("setup2.aspx");
                    //    return;
                    //}

                    //if (SupplerPageBase.brandList != null && SupplerPageBase.brandidlist != "0" && mslist.Count > 0)
                    //{
                    //    hasBrands = true;
                    //    s3url = "setup3.aspx";
                    //    s3css = "has";
                    //    s4css = "now";
                    //    s4url = "../index.aspx";
                    //}

                }
                else
                {
                    Response.Redirect("../supplerindex");
                    return;
                }

            }
        }
    }
}