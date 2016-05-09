using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz;
using TREC.ECommerce;
using TRECommon;

namespace TREC.Web.Suppler.market
{
    public partial class PavilionList : SupplerPageBase
    {
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();

        /// <summary>
        /// 数据展示
        /// </summary>
        private void datashow()
        {
            List<t_Pavilion> _list = new List<t_Pavilion>();
            _list = EntityOper.t_Pavilion.Where(p=>p.MarketId==marketInfo.id).OrderByDescending(p => p.Id).ToList();
            rptList.DataSource = _list;
            rptList.DataBind();
            AspNetPager1.RecordCount = _list.Count;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                datashow();
            }
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            List<int> _listids=new List<int>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_id")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    _listids.Add(SubmitMeth.getInt(id));
                }
            }
            if (_listids.Count > 0)
            {
                List<t_Pavilion> _listdel=new List<t_Pavilion>();
                _listdel = EntityOper.t_Pavilion.Where(p => _listids.Contains(p.Id)).ToList();
                EntityOper.t_Pavilion.DeleteAllOnSubmit(EntityOper.t_Pavilion.Where(p => _listids.Contains(p.Id)));
                EntityOper.SubmitChanges();
                ScriptUtils.ShowAndRedirect("删除成功!", "PavilionList.aspx");
            }
        }
    }
}