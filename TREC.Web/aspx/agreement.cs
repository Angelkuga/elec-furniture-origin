using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TREC.Web.aspx
{

    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    #endregion

    public partial class agreement : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "注册协议-家具快搜";     
        }
    }
}