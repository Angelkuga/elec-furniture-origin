using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Admin.config
{
    public partial class configlist :AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryEdit == "2" && ECommon.QueryId != "")
            {
                ECConfig.DeleteConfig(TypeConverter.StrToInt(ECommon.QueryId));
            }

            rptList.DataSource = ECConfig.GetConfigList(ECommon.QueryPageIndex, AspNetPager1.PageSize, "", out tmpPageCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = tmpPageCount;
        }


        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            string idlist="";
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

                ECConfig.DeleteConfigByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                UiCommon.JscriptPrint(this.Page, "批量删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected void lbUpSort_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_id")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                TextBox txtSort = (TextBox)rptList.Items[i].FindControl("txtSort");
                if (cb.Checked)
                {

                    //ECConfig.UpConfigSort(TypeConverter.StrToInt(id), txtSort.Text == "" ? "0" : txtSort.Text);
                      
                }
            }
            UiCommon.JscriptPrint(this.Page, "排序更新成功!", Request.Url.AbsoluteUri, "Success");
        }
    }
}