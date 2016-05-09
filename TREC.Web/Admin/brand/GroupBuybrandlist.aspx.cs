using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;
using Haojibiz.Model;
using Haojibiz.DAL;
using Haojibiz;

namespace TREC.Web.Admin.brand
{
    public partial class GroupBuybrandlist : AdminPageBase
    {
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void ShowData()
        {
            List<GroupBuy> _list = new List<GroupBuy>();

            if (!string.IsNullOrEmpty(txtbranname.Text.Trim()))
            {
                _list = EntityOper.GroupBuy.Where(p => p.brandName == txtbranname.Text.Trim()).ToList();
            }
            else
            {
                _list = EntityOper.GroupBuy.ToList();
            }



            rptList.DataSource = _list;
            rptList.DataBind();
            AspNetPager1.RecordCount = _list.Count;
        }

      
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            List<int> _ids = new List<int>();

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_id")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    _ids.Add(SubmitMeth.getInt(id));
                }
            }
            if (_ids.Count > 0)
            {
                List<GroupBuy> _listdel = new List<GroupBuy>();
                _listdel = EntityOper.GroupBuy.Where(p => _ids.Contains(p.Id)).ToList();
                EntityOper.GroupBuy.DeleteAllOnSubmit(_listdel);
                EntityOper.SubmitChanges();
                UiCommon.JscriptPrint(this.Page, "批量删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        #region 品牌搜索
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        #endregion

   

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            ShowData();
        }

       

    }
}