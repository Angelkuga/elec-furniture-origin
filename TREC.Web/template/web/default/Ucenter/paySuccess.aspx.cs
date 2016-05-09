using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TREC.Web.template.web.Ucenter
{
	public partial class paySuccess : System.Web.UI.Page
	{
        public string ordernumber
        {
            get
            {
                if (Request["ordernumber"] != null)
                {
                    return Request["ordernumber"];
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string m
        {
            get
            {
                if (Request["m"] != null)
                {
                    return Request["m"];
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public string pid
        {
            get
            {
                if (Request["pid"] != null)
                {
                    return "&pid="+Request["pid"];
                }
                else
                {
                    return string.Empty;
                }
            }
        }
		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}