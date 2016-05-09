using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz;
using TREC.ECommerce;
using System.Text;

namespace TREC.Web.Suppler.ajax
{
    
    public partial class PavilionData : System.Web.UI.Page
    {
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        public int selectid
        {
            get
            {
                if (Request["selectid"] != null)
                {
                    return SubmitMeth.getInt(Request["selectid"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        public int marketid
        {
            get
            {
                if (Request["marketid"] != null)
                {
                    return SubmitMeth.getInt(Request["marketid"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<t_Pavilion> _list = new List<t_Pavilion>();

            StringBuilder _value = new StringBuilder(string.Empty);
            string sel = "";
            if (marketid > 0)
            {
                _list = EntityOper.t_Pavilion.Where(p => p.MarketId == marketid).OrderByDescending(p => p.Id).ToList();

                foreach (t_Pavilion pa in _list)
                {
                    if (pa.Id == selectid)
                    {
                        sel = "selected=\"selected\"";
                    }
                    else
                    {
                        sel = "";
                    }

                    _value.Append("<option  " + sel + " value=\"" + pa.Id + "\">" + pa.Title + "</option>");

                }

                if (_list.Count > 0)
                {
                    Response.Write(_value.ToString());
                }
                else
                {
                    Response.Write("<option  value=\"0\">--无--</option>");
                }
            }
            else
            {
                Response.Write("<option  value=\"0\">--无--</option>");
            }

        }
    }
}