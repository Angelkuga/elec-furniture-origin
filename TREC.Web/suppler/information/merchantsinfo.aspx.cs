using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;
using System.Collections;


namespace TREC.Web.Suppler.information
{
    public partial class merchantsinfo : SupplerPageBase
    {
        public string areaCode = "";
        public EnMember _memberInfo = null;
        public string IsMarket = "1";
        public List<EnBrand> _lsts = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SupplerPageBase.memberInfo == null)
                {
                    HttpContext.Current.Response.Redirect(ECommon.WebUrl + "loginout.aspx");
                }

                _lsts = brandList.FindAll(delegate(EnBrand x) { return x.auditstatus == 1 && x.linestatus == 1; });
                if (_lsts == null || _lsts.Count <= 0)
                {
                    UiCommon.JscriptPrint(this.Page, "抱歉，您没添加品牌或者您的品牌还没审核上线!", "merchantslist.aspx", "Success");
                    return;
                }
                chkbrandlist.DataSource = _lsts;
                chkbrandlist.DataTextField = "title";
                chkbrandlist.DataValueField = "id";
                chkbrandlist.DataBind();

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
                    txttitle.Text = model.Title;
                    txtdescript.Text = model.Descript;
                    ddllinestatus.SelectedValue = model.Linestatus.ToString();
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
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(chkbrandlist.SelectedValue))
            {
                UiCommon.JscriptPrint(this.Page, "抱歉，请选择品牌!", "merchantslist.aspx", "Success");
                return;
            }
            if (string.IsNullOrEmpty(txttitle.Text))
            {
                UiCommon.JscriptPrint(this.Page, "抱歉，请填写标题!", "merchantslist.aspx", "Success");
                return;
            }
            if (string.IsNullOrEmpty(txtdescript.Text))
            {
                UiCommon.JscriptPrint(this.Page, "抱歉，请填写详细介绍!", "merchantslist.aspx", "Success");
                return;
            }
            EnMerchants model = new EnMerchants();
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model.Id = Convert.ToInt32(ECommon.QueryId);
            }
            model.Cid = SupplerPageBase.companyInfo.id;
            model.Brandid = chkbrandlist.SelectedValue;
            model.Auditstatus = 0;
            model.Linestatus = Convert.ToInt32(ddllinestatus.SelectedValue);
            model.Lastedittime = DateTime.Now;
            model.Title = txttitle.Text;
            model.Descript = txtdescript.Text;
            int aid = ECMerchants.EditMerchants(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "恭喜，编辑成功!", "merchantslist.aspx", "Success");
                return;
            }
            else
            {
                UiCommon.JscriptPrint(this.Page, "抱歉，编辑失败!", "merchantslist.aspx", "Success");
                return;
            }
        }

    }
}