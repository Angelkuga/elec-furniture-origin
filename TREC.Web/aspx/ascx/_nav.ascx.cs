using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using TREC.ECommerce;

namespace TREC.Web.aspx.ascx
{
    public partial class _nav : System.Web.UI.UserControl
    {
        public Hashtable _htb = new Hashtable();//数据统计
        protected void Page_Load(object sender, EventArgs e)
        {
            _htb = ECProduct.GetIndexCount()[0];
        }
    }
}