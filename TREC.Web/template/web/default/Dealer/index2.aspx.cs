using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TRECommon;
using TREC.Web.Code;
using Haojibiz;
using System.Text;
namespace TREC.Web.template.web.Dealer
{
    public partial class index2 : System.Web.UI.Page
	{

        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();

        public string getthumbImg(string id, object thumb)
        {
            if (thumb == null)
            {
                return string.Empty;
            }
            else
            {
                return "/upload/brand/thumb/" + id + "/" + thumb.ToString().Replace(",","");
            }
        }
        public string getlogImg(string id, object log)
        {
            if (log == null)
            {
                return string.Empty;
            }
            else
            {
                return "/upload/brand/logo/" + id + "/" + log.ToString().Replace(",","");
            }
        }
        public string getdescript(object des)
        {
            if (des == null)
            {
                return string.Empty;
            }
            else
            {
                return SubmitMeth.bSubstring(SubmitMeth.DisposeHtml(des.ToString()), 200);
            }
        }

        public string getcreatemid="-1";
       
        public int procunt = 0;

        public int did
        {
            get
            {
                if (Request["did"] != null)
                {
                    return SubmitMeth.getInt(Request["did"]);
                }
                else
                {
                    return 0;
                }
            }
        }

		protected void Page_Load(object sender, EventArgs e)
		{
            List<t_brand> _blist = new List<t_brand>();

		}
	}
}