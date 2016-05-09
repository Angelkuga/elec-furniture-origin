using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Web.Code;

namespace TREC.Web.template.web.ascx
{
	public partial class DealerProduct : System.Web.UI.UserControl
	{
        public string getdid
        {
            get
            {
                if (Request["did"] != null)
                {
                    return Request["did"];
                }
                else
                {
                    return "0";
                }
            }
        }
        DealerPageBase _pagebase = new DealerPageBase();
        public string createmid = string.Empty;
        public string setvalue = "-1";
		protected void Page_Load(object sender, EventArgs e)
		{
            if (_pagebase.DealerInfor != null)
            {
                createmid = _pagebase.DealerInfor.mid.ToString();
            }
            else
            {
                createmid = "0"; 
            }
		}
	}
}