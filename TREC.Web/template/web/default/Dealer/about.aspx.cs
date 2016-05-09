using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Web.Code;
using System.Text;
using Haojibiz;

namespace TREC.Web.template.web.Dealer
{
    public partial class about : DealerPageBase
	{
        public string descrip;
       

  
        
		protected void Page_Load(object sender, EventArgs e)
		{
            StringBuilder _value = new StringBuilder(string.Empty);
            if (DealerInfor != null)
            {
               
                
                if (companylist.Count > 0)
                {
                    foreach (t_company c in companylist)
                    {
                        _value.Append("<h3>"+c.title+"介绍</h3>");
                        _value.Append(" <div class=\"jies\">");
                        _value.Append(c.descript);
                        _value.Append("</div>");
                        _value.Append("<br />");
                        _value.Append("<br />");
                        title = c.title;
                    }
                }
                else
                {
                    _value.Append("<h3>厂商介绍</h3>");
                    _value.Append(" <div class=\"jies\">");
                    _value.Append(DealerInfor.descript);
                    _value.Append("</div>");
                }

                descrip = _value.ToString();
            }
		}
	}
}