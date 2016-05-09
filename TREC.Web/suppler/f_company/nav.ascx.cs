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

namespace TREC.Web.Suppler.f_company
{
    public partial class nav : System.Web.UI.UserControl
    {
        protected string s1css = "", s2css = "", s3css = "", s4css = "", s1url = "javascript:;", s2url = "javascript:;", s3url = "javascript:;", s4url = "javascript:;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SupplerPageBase.companyInfo != null && SupplerPageBase.companyInfo.id != 0)
                {
                    bool hasCompany = false, hasBrand = false, hasBrands = false;
                    s1css = "now";
                    s1url = "javascript:;";

                    if (WebUtils.GetPageName() == "setup1.aspx")
                    {
                        hasCompany = true;
                        s1css = "now";
                        s1url = "setup1.aspx";
                    }

                    //品牌
                    if (!string.IsNullOrEmpty(SupplerPageBase.companyInfo.title) &&
                        !string.IsNullOrEmpty(SupplerPageBase.companyInfo.phone) &&
                        !string.IsNullOrEmpty(SupplerPageBase.companyInfo.address) && 
                        WebUtils.GetPageName() == "setup2.aspx")
                    {
                            hasCompany = true;
                            s1css = "has";
                            s1url = "";
                            s2css = "now";
                            s2url = "setup2.aspx";
                    }

                    if (WebUtils.GetPageName() == "setup3.aspx" && SupplerPageBase.brandList != null && SupplerPageBase.brandidlist != "0")
                    {
                        hasBrand = true;
                        s1css = "has";
                        s1url = "";
                        s2css = "has";
                        s3url = "";
                        s3url = "setup3.aspx";
                        s3css = "now";
                        s4css = "";
                        s4url = "../index.aspx";
                    }
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