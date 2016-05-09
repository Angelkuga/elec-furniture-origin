using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Admin.information
{
    public partial class AddMerchantsInfo : AdminPageBase
    {
        protected string mid = string.Empty;
        protected string cid = string.Empty;
        public static List<EnBrand> brandList = new List<EnBrand>();
        protected void Page_Load(object sender, EventArgs e)
        {
            mid = Request.QueryString["memberid"];
            cid = Request.QueryString["cid"];
            if (string.IsNullOrEmpty(cid))
            {
                if (string.IsNullOrEmpty(mid))
                {
                    UiCommon.JscriptPrint(this.Page, "抱歉，工厂不存在!", Request.Url.AbsoluteUri, "Success");
                    return;
                }
                EnCompany model = ECCompany.GetCompanyInfo(" where mid=" + mid);
                if (model == null)
                {
                    UiCommon.JscriptPrint(this.Page, "抱歉，工厂不存在!", Request.Url.AbsoluteUri, "Success");
                    return;
                }
                cid = model.id.ToString();
            }

            if (!IsPostBack)
            {
                brandList = ECBrand.GetBrandList(" companyid=" + cid + " and auditstatus=1 and linestatus=1");
                if (brandList.Count <= 0)
                {
                    brandList = null;
                }
                if (brandList == null)
                {
                    UiCommon.JscriptPrint(this.Page, "抱歉。该工厂暂无品牌!", Request.Url.AbsoluteUri, "Success");
                    return;
                }
                chkbrandlist.DataSource = brandList;
                chkbrandlist.DataTextField = "title";
                chkbrandlist.DataValueField = "id";
                chkbrandlist.DataBind();

                ddlauditstatus.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumAuditStatus), ddlauditstatus);
                ddlauditstatus.Items.Insert(0, new ListItem("请选择", ""));

                ddllinestatus.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumLineStatus), ddllinestatus);
                ddllinestatus.Items.Insert(0, new ListItem("请选择", ""));

                ShowData();
            }

        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnMerchants model = ECMerchants.GetMerchantsInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    tbTitle.Text = model.Title;
                    tbDescript.Text = model.Descript;
                    ddlauditstatus.SelectedValue = model.Auditstatus.ToString();
                    ddllinestatus.SelectedValue = model.Linestatus.ToString();
                    txxcreattime.Text = model.Lastedittime.ToString("yyyy-MM-dd HH:mm:ss");
                    foreach (ListItem i in chkbrandlist.Items)
                    {
                        if (model.Brandid == i.Value)
                            i.Selected = true;
                    }

                    int pageCount = 0;
                    rptList.DataSource = ECMerchantsMember.GetMerchantsList(ECommon.QueryPageIndex, AspNetPager1.PageSize, " MerchantId=" + ECommon.QueryId, out pageCount);
                    rptList.DataBind();
                    AspNetPager1.RecordCount = pageCount;
                }
                else
                {
                    UiCommon.JscriptPrint(this.Page, "抱歉。该招商信息不存在!", Request.Url.AbsoluteUri, "Success");
                    return;
                }
            }
        }


        /// <summary>
        /// Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EnMerchants model = new EnMerchants();
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model.Id = Convert.ToInt32(ECommon.QueryId);
            }
            model.Cid = Convert.ToInt32(cid);
            model.Brandid = chkbrandlist.SelectedValue;
            model.Auditstatus = Convert.ToInt32(ddlauditstatus.SelectedValue);
            model.Linestatus = Convert.ToInt32(ddllinestatus.SelectedValue);
            model.Lastedittime = DateTime.Now;
            model.Title = tbTitle.Text;
            model.Descript = tbDescript.Text;
            int aid = ECMerchants.EditMerchants(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "恭喜，编辑成功!", Request.Url.AbsoluteUri, "Success");
                return;
            }
            else
            {
                UiCommon.JscriptPrint(this.Page, "抱歉，编辑失败!", Request.Url.AbsoluteUri, "Success");
                return;
            }
        }
    }
}