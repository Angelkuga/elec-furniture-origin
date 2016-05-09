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
    public partial class _companynav : System.Web.UI.UserControl
    {
        public static EnMember memberInfo = null;
        public EnWebCompany companyInfo = new EnWebCompany();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ECommon.QueryCId == "" || ECommon.QueryCId == "0")
            {
                Response.Redirect(ECommon.WebUrl);
            }

            companyInfo = ECCompany.GetWebCompanyInfo(" where id=" + ECommon.QueryCId);

            if (companyInfo != null)
            {
                memberInfo = ECMember.GetMemberInfo(" where id= " + CompanyPageBase.companyInfo.mid);
            }
        }
    }
}