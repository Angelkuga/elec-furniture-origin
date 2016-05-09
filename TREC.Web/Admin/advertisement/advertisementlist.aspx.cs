using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Admin.advertisement
{
    public partial class advertisementlist : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategory.Items.Clear();
                List<EnAdvertisementCategory> list = ECAdvertisementCategory.GetAdvertisementCategoryList(" isopen=1").OrderBy(c=>c.title).ToList();
                foreach (EnAdvertisementCategory ac in list)
                {
                    if (ac.parentid != 0)
                    {
                        ac.title = "|--" + ac.title;
                    }

                }
                ddlCategory.DataSource = list;
                ddlCategory.DataTextField = "title";
                ddlCategory.DataValueField = "id";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("请选择", "0"));

                raOpen.Items.Insert(0, new ListItem("请选择", "-1"));
                raOpen.Items.Insert(1, new ListItem("是", "1"));
                raOpen.Items.Insert(2, new ListItem("否", "0"));

                #region 分页条件设置
                if (!string.IsNullOrEmpty(Request["ddlCategory"]))
                    ddlCategory.SelectedValue = Request["ddlCategory"].ToString();
                if (!string.IsNullOrEmpty(Request["txttitle"]))
                    txttitle.Text = Request["txttitle"].ToString();
                if (!string.IsNullOrEmpty(Request["txtstarttime"]))
                    txtstarttime.Text = Request["txtstarttime"].ToString();
                if (!string.IsNullOrEmpty(Request["txtendtime"]))
                    txtendtime.Text = Request["txtendtime"].ToString(); ;
                if (!string.IsNullOrEmpty(Request["raOpen"]))
                    raOpen.SelectedValue = Request["raOpen"].ToString();
                #endregion
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryEdit == "2" && ECommon.QueryId != "")
            {
                ECAdvertisement.DeletEnAdvertisement(TypeConverter.StrToInt(ECommon.QueryId));
            }
            string strwhere = "1=1";
            if (ddlCategory.SelectedValue != "0")
            {
                strwhere += string.Format(" and categoryid={0}", ddlCategory.SelectedValue);
            }
            if (!string.IsNullOrEmpty(txttitle.Text))
            {
                strwhere += string.Format(" and title Like '%{0}%'", txttitle.Text);
            }
            if (raOpen.SelectedValue != "-1")
            {
                strwhere += string.Format(" and isopen={0}", raOpen.SelectedValue);
            }
            if (txtstarttime.Text != "")
            {
                strwhere += string.Format(" and endtime>='{0}'", txtstarttime.Text);
            }
            if (txtendtime.Text != "")
            {
                strwhere += string.Format(" and endtime<='{0}'", txtendtime.Text);
            }
            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlRewritePattern =
                string.Format("advertisementlist.aspx?ddlCategory={0}&txttitle={1}&txtstarttime={2}&txtendtime={3}&raOpen={4}&page={5}",
                ddlCategory.SelectedValue, txttitle.Text, txtstarttime.Text, txtendtime.Text, raOpen.SelectedValue, "{0}");
            rptList.DataSource = ECAdvertisement.GetAdvertisementList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strwhere, out tmpPageCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = tmpPageCount;
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            string idlist = "";
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_id")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    idlist += id + ",";
                }
            }
            if (idlist.Length > 0)
            {
                ECAdvertisement.DeletEnAdvertisementByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                Response.Redirect("advertisementlist.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}