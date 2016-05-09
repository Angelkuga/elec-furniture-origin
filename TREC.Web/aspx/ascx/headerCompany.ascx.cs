using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using System.Collections;
using TREC.Entity;

namespace TREC.Web.aspx.ascx
{
    public class headerCompany : System.Web.UI.UserControl
    {
        public static EnMember memberInfo = null;
        public EnWebCompany companyInfo = new EnWebCompany();
        public Hashtable _htb = new Hashtable();//数据统计
        protected void Page_Load(object sender, EventArgs e)
        {
            _htb = ECProduct.GetIndexCount().FirstOrDefault();
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