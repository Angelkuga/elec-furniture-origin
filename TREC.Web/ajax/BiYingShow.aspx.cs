using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TREC.ECommerce;
using System.Text;

namespace TREC.Web.ajax
{
    public partial class BiYingShow : System.Web.UI.Page
    {

        public string curstring(string s, int len)
        {
            if (s.Length > (len / 2))
            {
                return SubmitMeth.bSubstring(s, len) + "....";
            }
            else
            {
                return s;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string pageindex = Request["p"];
            DataSet ds = new DataSet();
            ds = ECBrand.BiYing(pageindex);

            StringBuilder _value = new StringBuilder(string.Empty);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                _value.Append(DateTime.Parse(r["CreateTime"].ToString()).ToString("yyyy-MM-dd hh:mm") + " <a href=\"javascript:byshow('" + r["id"].ToString() + "')\">" + curstring(r["Description"].ToString(), 35) + "</a><br>");
                _value.Append("<div class=\"biyingList\" id=\"by" + r["id"].ToString() + "\">" + r["Description"].ToString() + " </div>");
            }

            Response.Write(_value.ToString());
            
        }
    }
}