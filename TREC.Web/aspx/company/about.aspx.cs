using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TREC.Web.aspx.company
{


    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    #endregion
      
      
    public partial class about :CompanyPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CompanyPageBase.setvalue = "-99";
            pageTitle = "-" + companyInfo.title + "-厂家介绍";
        }
    }
}