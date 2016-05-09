using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Admin.member
{
    public partial class customerlist : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //账号类型
                ddltype.Items.Clear();
                ddltype.Items.Insert(0, new ListItem("请选择", ""));
                ddltype.Items.Insert(1, new ListItem("手机", "1"));
                ddltype.Items.Insert(2, new ListItem("邮箱", "2"));

                ddlstatus.Items.Clear();
                ddlstatus.Items.Insert(0, new ListItem("请选择", ""));
                ddlstatus.Items.Insert(1, new ListItem("激活", "1"));
                ddlstatus.Items.Insert(2, new ListItem("未激活", "0"));

                #region 分页条件设置
                if (!string.IsNullOrEmpty(Request["txtUserName"]))
                    txtUserName.Text = Request["txtUserName"].ToString();
                if (!string.IsNullOrEmpty(Request["txtIP"]))
                    txtIP.Text = Request["txtIP"].ToString();
                if (!string.IsNullOrEmpty(Request["txtstarttime"]))
                    txtstarttime.Text = Request["txtstarttime"].ToString();
                if (!string.IsNullOrEmpty(Request["txtendtime"]))
                    txtendtime.Text = Request["txtendtime"].ToString(); ;
                if (!string.IsNullOrEmpty(Request["ddltype"]))
                    ddltype.SelectedValue = Request["ddltype"].ToString();
                if (!string.IsNullOrEmpty(Request["ddlstatus"]))
                    ddlstatus.SelectedValue = Request["ddlstatus"].ToString();
                #endregion

                ShowData();

            }
        }

        protected void ShowData()
        {
            string strWhere = " 1=1 ";


            if (ddltype.SelectedValue != "")
            {
                strWhere += " and unametype=" + ddltype.SelectedValue;
            }
            if (ddlstatus.SelectedValue != "")
            {
                strWhere += " and ustatus=" + ddlstatus.SelectedValue;
            }
            if (txtUserName.Text != "")
            {
                strWhere += string.Format(" and uname like '%{0}%'", txtUserName.Text);
            }
            if (txtIP.Text != "")
            {
                strWhere += string.Format(" and regip like '%{0}%'", txtIP.Text);
            }
            if (txtstarttime.Text != "")
            {
                strWhere += string.Format(" and regtime>='{0}'", txtstarttime.Text);
            }
            if (txtendtime.Text != "")
            {
                strWhere += string.Format(" and regtime<='{0}'", txtendtime.Text);
            }
            List<EnCustomer> lists = ECCustomer.GetCustomerList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount);
            rptList.DataSource = lists;
            rptList.DataBind();
            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlRewritePattern =
                string.Format("customerlist.aspx?ddltype={0}&txtUserName={1}&txtIP={2}&txtendtime={3}&txtendtime={4}&ddlstatus{5}&page={6}",
                ddltype.SelectedValue, txtUserName.Text, txtIP.Text, txtstarttime.Text, txtendtime.Text, ddlstatus.SelectedValue, "{0}");

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}