using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using System.Data;

namespace TREC.Web.template.web
{
	public partial class BiYingList : System.Web.UI.Page
	{

        public string curstring(string s,int len)
        {
            if (s.Length > (len/2))
            {
                return SubmitMeth.bSubstring(s, len) + "....";
            }
            else
            {
                return s;
            }
        }
        public string pagerow = "1";
             
		protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds= ECBrand.BiYing("1");
            pagerow = ds.Tables[2].Rows[0][0].ToString();
            Repeater_list.DataSource = ds.Tables[0];
            Repeater_list.DataBind();
		}
	}
}