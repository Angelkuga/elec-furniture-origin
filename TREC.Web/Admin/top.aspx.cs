using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Admin
{
    public partial class top :AdminPageBase
    {
        protected List<EnModule> list = new List<EnModule>();

        protected void Page_Load(object sender, EventArgs e)
        {
            list = ECModule.GetModuleList(" type=" + (int)EnumModuleType.后台 + " or type=" + (int)EnumModuleType.系统);
            list.Sort(new EnModuleDescSort());
        }
    }
}