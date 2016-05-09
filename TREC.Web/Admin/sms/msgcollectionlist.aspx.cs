using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Admin.sms
{
    public partial class msgcollectionlist : System.Web.UI.Page
    {
        int tmpPageCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ddlPromtype.Items.Clear();
                ddlPromtype.Items.Add(new ListItem("请选择", ""));
                ddlPromtype.Items.Add(new ListItem("抢购报名", "1"));
                ddlPromtype.Items.Add(new ListItem("团购报名", "3"));

                #region 分页条件设置
                if (!string.IsNullOrEmpty(Request["txtname"]))
                    txtname.Text = Request["txtname"].ToString();
                if (!string.IsNullOrEmpty(Request["txtmobile"]))
                    txtmobile.Text = Request["txtmobile"].ToString();
                if (!string.IsNullOrEmpty(Request["txtprod"]))
                    txtprod.Text = Request["txtprod"].ToString();
                if (!string.IsNullOrEmpty(Request["txtcode"]))
                    txtcode.Text = Request["txtcode"].ToString();
                if (!string.IsNullOrEmpty(Request["txtstarttime"]))
                    txtstarttime.Text = Request["txtstarttime"].ToString();
                if (!string.IsNullOrEmpty(Request["txtendtime"]))
                    txtendtime.Text = Request["txtendtime"].ToString();
                if (!string.IsNullOrEmpty(Request["ddlPromtype"]))
                    ddlPromtype.SelectedValue = Request["ddlPromtype"].ToString();
                #endregion
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryEdit == "2" && ECommon.QueryId != "")
            {
                ECMsgCollection.DeleteMsgCollection(" where id=" + ECommon.QueryId);
            }
            string strwhere = "1=1";
            if (!string.IsNullOrEmpty(ddlPromtype.SelectedValue))
            {
                strwhere += string.Format(" and prodcon = {0}", ddlPromtype.SelectedValue);
            }
            if (txtname.Text != "")
            {
                strwhere += string.Format(" and Name like '%{0}%'", txtname.Text);
            }
            if (txtmobile.Text != "")
            {
                strwhere += string.Format(" and Contact like '%{0}%'", txtmobile.Text);
            }
            if (txtprod.Text != "")
            {
                strwhere += string.Format(" and msginfo like '%{0}%'", txtprod.Text);
            }
            if (txtcode.Text != "")
            {
                strwhere += string.Format(" and Code like '%{0}%'", txtcode.Text);
            }
            if (txtstarttime.Text != "")
            {
                strwhere += string.Format(" and CreateTime>='{0}'", txtstarttime.Text);
            }
            if (txtendtime.Text != "")
            {
                strwhere += string.Format(" and CreateTime<='{0}'", txtendtime.Text);
            }
            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlRewritePattern =
                string.Format("msgcollectionlist.aspx?txtname={0}&txtmobile={1}&txtprod={2}&txtcode={3}&txtstarttime={4}&txtendtime={5}&ddlPromtype=&{6}page={7}",
                txtname.Text, txtmobile.Text, txtprod.Text, txtcode.Text, txtstarttime.Text, txtendtime.Text, ddlPromtype.SelectedValue, "{0}");
            rptList.DataSource = ECMsgCollection.GetMsgCollectionList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strwhere, out tmpPageCount);
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
            idlist = idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist;
            if (idlist.Length > 0)
            {
                ECMsgCollection.DeleteMsgCollection(" where id in(" + idlist + ")");
                UiCommon.JscriptPrint(this.Page, "批量删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
