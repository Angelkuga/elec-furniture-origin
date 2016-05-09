using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;

namespace TREC.Web.Suppler
{
    public partial class Settled : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           List<Entity.EnArea> areaList=ECArea.GetAreaList(" parentcode=0");
            ddlMPro.Items.Clear();
            ddlMPro.DataSource = areaList;
            ddlMPro.DataTextField = "areaname";
            ddlMPro.DataValueField = "areacode";
            ddlMPro.DataBind();
            ddlMPro.Items.Insert(0, new ListItem("请选择省份", ""));

            
            ddlDpro.Items.Clear();
            ddlDpro.DataSource = areaList;
            ddlDpro.DataTextField = "areaname";
            ddlDpro.DataValueField = "areacode";
            ddlDpro.DataBind();
            ddlDpro.Items.Insert(0, new ListItem("请选择省份", ""));

            bfProvince.Items.Clear();
            bfProvince.DataSource = areaList;
            bfProvince.DataTextField = "areaname";
            bfProvince.DataValueField = "areacode";
            bfProvince.DataBind();
            bfProvince.Items.Insert(0, new ListItem("请选择省份", ""));

            
            //ddlMregcity.Items.Clear();
           // ddlMregcity.Items.Insert(0, new ListItem("请选择省份", ""));
        }
    }
}