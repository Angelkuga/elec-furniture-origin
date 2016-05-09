using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Entity;
using TREC.ECommerce;

namespace TREC.Web.aspx.ascx
{
    public partial class _shopnav : System.Web.UI.UserControl
    {
        public static EnMember memberInfo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            EnCompany companyInfo = ECCompany.GetCompanyInfo(" where id=" + ShopPageBase.shopInfo.cid);
            if (companyInfo != null)
            {
                memberInfo = ECMember.GetMemberInfo(" where id= " + companyInfo.mid);
            }
        }
    }
}