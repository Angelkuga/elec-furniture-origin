using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Suppler.f_dealer
{
    public partial class setup2 : SupplerPageBase
    {
        protected string brandnexturl = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Modify：rafer
                //Date：2012-4-20
                //ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECBrand.GetBrandList("  createmid=" + SupplerPageBase.memberInfo.id).Count > 0)
            {
                brandnexturl = "setup3.aspx";
            }
            else
            {
                brandnexturl = "../index.aspx";
            }

            string strWhere = " id not in (select brandid from " + TableName.TBAppBrand + " where dealerid=" + dealerInfo.id + ")  and auditstatus = 1 ";
            if (txtsearch.Text != "")
            {
                strWhere += "  and  (title like '%" + txtsearch.Text + "%' or stylename like '%" + txtsearch.Text + "%' or companyname like '%" + txtsearch.Text + "%') ";
            }

            
            rptList.DataSource = ECBrand.GetWebBrandList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = tmpPageCount;
        }

        protected void btnAppend_Click(object sender, EventArgs e)
        {
            List<EnAppBrand> list = new List<EnAppBrand>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_id")).Text;
                string brandtitle = ((Label)rptList.Items[i].FindControl("lb_title")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    EnAppBrand model = new EnAppBrand();
                    model.dealerid = dealerInfo.id;
                    model.dealetitle = dealerInfo.title;
                    model.brandid = TypeConverter.StrToInt(id);
                    model.brandtitle = brandtitle;
                    model.companyid = 0;
                    model.companytitle = "";
                    model.shopid = 0;
                    model.shoptitle = "";
                    model.appmodule = (int)EnumAppBrandModule.经销商申请;
                    model.apptype = (int)EnumAppBrandType.申请代理品牌;
                    model.apptime = DateTime.Now;
                    model.createmid = memberInfo.id;
                    model.lastedittime = DateTime.Now;
                    model.auditstatus = 0;
                    list.Add(model);
                }
            }
            if (list.Count > 0)
            {
                if (ECAppBrand.AddAppendBrand(list)>0)
                {
                    Response.Redirect("../index.aspx");
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}