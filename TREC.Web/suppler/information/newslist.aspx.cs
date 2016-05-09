using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;

namespace TREC.Web.Suppler.information
{
    public partial class newslist : SupplerPageBase
    {
        protected Dnews dnews = new Dnews();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }
        void loadData()
        {
            var query = dnews.LinqData<Mnews>().Where(c => c.mid == memberInfo.id);
            query = query.OrderByDescending(c => c.createtime);
            rptList.DataSource = AspNetPager1.GetPagedDataSource(query);
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
                dnews.Delete(c => ids.Contains(c.id));
                UiCommon.JscriptPrint(this.Page, "删除成功！", Request.Url.AbsoluteUri, "Success");
            }
            else
            {
                UiCommon.JscriptPrint(this.Page, "没有记录被选中！", "#", "Error");
            }
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