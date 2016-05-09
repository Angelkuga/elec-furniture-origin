using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;

namespace TREC.Web.template.web
{
	public partial class AreaDrop : System.Web.UI.Page
	{
        public string txtname
        {
            get
            {
                if (Request["txtname"] != null)
                {
                    return Request["txtname"];
                }
                else
                {
                    return string.Empty;
                }
            }
        }
		protected void Page_Load(object sender, EventArgs e)
		{

            ddlPro.Items.Clear();
            ddlPro.DataSource = ECArea.GetAreaList(" parentcode=0");
            ddlPro.DataTextField = "areaname";
            ddlPro.DataValueField = "areacode";
            ddlPro.DataBind();
            ddlPro.Items.Insert(0, new ListItem("--省--", "0"));

            ddlregcity.Items.Clear();
            ddlregcity.Items.Insert(0, new ListItem("--城市--", "0"));
		}
	}
}