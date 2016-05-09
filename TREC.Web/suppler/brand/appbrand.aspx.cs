using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Suppler.brand
{
    public partial class appbrand :SupplerPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Modify：rafer
                //Date：2012-4-23
                //ShowData();
            }
        }

        protected void ShowData()
        {
            string strWhere = " id not in (select brandid from " + TableName.TBAppBrand + " where dealerid=" + dealerInfo.id + ") and auditstatus = 1 ";
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
                ECAppBrand.AddAppendBrand(list);
                UiCommon.JscriptPrint(this.Page, "已成功添加代理品牌，请等候审核!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}