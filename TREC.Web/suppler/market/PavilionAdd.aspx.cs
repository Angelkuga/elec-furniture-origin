using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TRECommon;
using Haojibiz;

namespace TREC.Web.Suppler.market
{
    public partial class PavilionAdd : SupplerPageBase
    {
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        t_Pavilion _pavilion = new t_Pavilion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["id"] != null)
                {
                    _pavilion = EntityOper.t_Pavilion.Where(p => p.Id == SubmitMeth.getInt(Request["id"].Trim())).FirstOrDefault();
                    if (_pavilion != null)
                    {
                        txttitle.Text = _pavilion.Title;
                        hideBannelimg.Value = _pavilion.Bannel;
                        hfthumbimg.Value = _pavilion.thumb;
                        txtdescript.Text = _pavilion.Description;

                    }

                }
            }
        }
        public string alertmsg;
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string title = txttitle.Text.Trim();

            if (!string.IsNullOrEmpty(title))
            {
                if (Request["id"] != null)
                {
                    _pavilion = EntityOper.t_Pavilion.Where(p => p.Id == SubmitMeth.getInt(Request["id"].Trim())).FirstOrDefault();
                }
                _pavilion.Title = txttitle.Text.Trim();
                _pavilion.MarketId = marketInfo.id;
                _pavilion.Mid = marketInfo.mid;
                _pavilion.Bannel = hideBannelimg.Value;
                _pavilion.thumb = hfthumbimg.Value;
                _pavilion.Description = txtdescript.Text;
                _pavilion.CreateTime = DateTime.Now;

                if (Request["id"] == null)
                {
                    EntityOper.t_Pavilion.InsertOnSubmit(_pavilion);
                }
                EntityOper.SubmitChanges();

                if (Request["id"] == null)
                {
                  //  ScriptUtils.ShowAndRedirect("添加成功!", "PavilionAdd.aspx");
                    alertmsg = TREC.ECommerce.Ui.PageAlert.getalert(true, "添加成功!", "PavilionList.aspx");
                }
                else
                {
                    alertmsg = TREC.ECommerce.Ui.PageAlert.getalert(true, "修改成功!", "PavilionList.aspx");
                  //  ScriptUtils.ShowAndRedirect("修改成功!", "PavilionList.aspx");
                }
            }
            else
            {
                alertmsg = TREC.ECommerce.Ui.PageAlert.getalert(true, "场馆名称不能为空！", "");
               // ScriptUtils.Alert(this, "场馆名称不能为空");
            }
        }
    }
}