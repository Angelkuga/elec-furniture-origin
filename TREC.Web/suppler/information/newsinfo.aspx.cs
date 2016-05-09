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
    public partial class newsinfo : SupplerPageBase
    {
        protected Dnews dnews = new Dnews();
        protected int PKID = TRECommon.WebRequest.GetQueryInt("id");
        Mnews mnews = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (!SupplerPageBase.IsPayMember())
                //{
                //    Response.Redirect("/suppler/Payment/RegPayment.aspx");
                //}
                if (PKID > 0)
                {
                    loadData();
                }
            }
        }
        void loadData()
        {
            mnews = dnews.Linq.FirstOrDefault(c => c.id == PKID && c.mid == memberInfo.id);
            if (mnews != null)
            {
                tbTitle.Text = mnews.title;
                tbDescript.Text = mnews.descript;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTitle.Text))
            {
                UiCommon.JscriptPrint(this.Page, "新闻标题不能为空", "#", "Error");
                return;
            }
            Mnews m = new Mnews();
            m.title = tbTitle.Text;
            m.descript = tbDescript.Text;
            m.intro = TRECommon.HTMLUtils.GetAllTextFromHTML(m.descript).Length > 100 ? TRECommon.HTMLUtils.GetAllTextFromHTML(m.descript).Substring(0, 99) : TRECommon.HTMLUtils.GetAllTextFromHTML(m.descript);
            if (PKID > 0)
            {
                m.lastedtime = DateTime.Now;
                dnews.Update(m, c => c.id == PKID);
            }
            else
            {
                m.ismember = true;
                m.mid = memberInfo.id;
                m.membertype = memberInfo.type;
                if (memberInfo.RegEndTime > DateTime.Now)
                {
                    m.auditstatus = 1;
                    m.linestatus = 1;
                }
                else
                {
                    m.auditstatus = 0;
                    m.linestatus = 0;
                }
                dnews.Insert(m);
            }
            UiCommon.JscriptPrint(this.Page, "保存成功！", Request.Url.AbsoluteUri, "Success");
        }
    }
}