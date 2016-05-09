using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;
using Haojibiz.Data;
using Haojibiz.DAL;
using Haojibiz.Model;
using System.Data.Linq;

namespace TREC.Web.Admin.information
{
    public partial class promotionslist : System.Web.UI.Page
    {
        public Dpromotions dpromotions = new Dpromotions();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void ShowData()
        {
            var query = dpromotions.Linq.Where(c => true);
            switch (ECommon.QuerySearchDisplay)
            {
                case "shop":
                    query = query.Where(c => c.membertype == (int)EnumMemberType.工厂企业 || c.membertype == (int)EnumMemberType.经销商);
                    break;
                case "market":
                    query = query.Where(c => c.membertype == (int)EnumMemberType.卖场);
                    break;
            }
            if (!string.IsNullOrEmpty(ddlauditstatus.SelectedValue))
            {
                query = query.Where(c => c.auditstatus == Convert.ToInt32(ddlauditstatus.SelectedValue));
            }
            if (!string.IsNullOrEmpty(ddllinestatus.SelectedValue))
            {
                query = query.Where(c => c.linestatus == Convert.ToInt32(ddllinestatus.SelectedValue));
            }
            rptList.DataSource = AspNetPager1.GetPagedDataSource(query.OrderByDescending(c => c.createtime));
            rptList.DataBind();
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            var ids = new List<int>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                var id = TRECommon.TypeConverter.StrToInt(((Label)rptList.Items[i].FindControl("lb_id")).Text);
                var cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    ids.Add(id);
                }
            }
            if (ids.Count > 0)
            {
                Dpromotionsrelated dpromotionsrelated = new Dpromotionsrelated(dpromotions);
                dpromotions.BeginTransaction();
                try
                {
                    dpromotions.Delete(c => ids.Contains(c.id));
                    dpromotionsrelated.Delete(c => ids.Contains(c.promotionsid));
                    dpromotions.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dpromotions.RollbackTransaction();
                    UiCommon.JscriptPrint(this.Page, "删除失败！", Request.Url.AbsoluteUri, "Error");
                    return;
                }
                UiCommon.JscriptPrint(this.Page, "删除成功！", Request.Url.AbsoluteUri, "Success");
            }
            else
            {
                UiCommon.JscriptPrint(this.Page, "没有记录被选中！", "#", "Error");
            }
        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        public string GetStatusStr(object obj)
        {
            string str = string.Empty;
            if (obj == null)
            {
                return str;
            }
            switch (obj.ToString())
            {
                case "-1":
                    str = "审核中";
                    break;
                case "0":
                    str = "下线";
                    break;
                case "1":
                    str = "上线";
                    break;
                case "-99":
                    str = "未通过";
                    break;
            }
            return str;
        }

        public string GetStatusStrA(object obj)
        {
            string str = string.Empty;
            if (obj == null)
            {
                return str;
            }
            switch (obj.ToString())
            {
                case "-1":
                    str = "审核中";
                    break;
                case "0":
                    str = "待审核";
                    break;
                case "1":
                    str = "审核通过";
                    break;
                case "-99":
                    str = "未通过";
                    break;
            }
            return str;
        }
    }
}