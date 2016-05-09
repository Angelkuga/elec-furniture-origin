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

namespace TREC.Web.Admin.information
{
    public partial class newsinfo : AdminPageBase
    {
        protected Dnews dnews = new Dnews();
        protected int PKID = TRECommon.WebRequest.GetQueryInt("id");
        protected Mnews mnews = null;
        protected Mmember memberInfo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadOptions();
                if (PKID > 0)
                {
                    loadData();
                }
                else
                {
                    userinfobox.Visible = false;
                    txxcreattime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
            }
        }
        void loadOptions()
        {
            ddlauditstatus.Items.Clear();
            WebControlBind.DrpBind(typeof(EnumAuditStatus), ddlauditstatus);
            ddlauditstatus.Items.Insert(0, new ListItem("请选择", ""));

            ddllinestatus.Items.Clear();
            WebControlBind.DrpBind(typeof(EnumLineStatus), ddllinestatus);
            ddllinestatus.Items.Insert(0, new ListItem("请选择", ""));

            ddlmembertype.Items.Clear();
            WebControlBind.DrpBind(typeof(EnumMemberType), ddlmembertype);
            ddlmembertype.Items.Insert(0, new ListItem("请选择", ""));
        }
        void loadData()
        {
            mnews = dnews.Linq.FirstOrDefault(c => c.id == PKID);
            if (mnews != null)
            {
                tbTitle.Text = mnews.title;
                tbLetter.Text = mnews.letter;
                tbIntro.Text = mnews.intro;
                tbDescript.Text = mnews.descript;
                ddlauditstatus.SelectedValue = mnews.auditstatus.ToString();
                ddllinestatus.SelectedValue = mnews.linestatus.ToString();
                txxcreattime.Text = mnews.createtime.ToString("yyyy-MM-dd");
                if (mnews.ismember)
                {
                    memberInfo = dnews.LinqData<Mmember>().Where(c => c.id == mnews.mid).FirstOrDefault();
                    if (memberInfo != null)
                    {
                        ddlmembertype.SelectedValue = memberInfo.type.ToString();
                        tbuserid.Text = memberInfo.id.ToString();
                        tbusername.Text = memberInfo.username;
                    }
                    else
                    {
                        userinfobox.Visible = false;
                    }
                }
                else
                {
                    userinfobox.Visible = false;
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Mnews m = new Mnews();
            m.title = tbTitle.Text;
            m.letter = tbLetter.Text;
            m.intro = tbIntro.Text;
            m.descript = tbDescript.Text;
            m.auditstatus = TRECommon.TypeConverter.StrToInt(ddlauditstatus.SelectedValue);
            m.linestatus = TRECommon.TypeConverter.StrToInt(ddllinestatus.SelectedValue);
            m.createtime = TRECommon.TypeConverter.StrToDateTime(txxcreattime.Text);
            if (PKID > 0)
            {
                m.lastedtime = DateTime.Now;
                dnews.Update(m, c => c.id == PKID);
            }
            else
            {
                m.ismember = false;
                m.adminid = adminId;
                dnews.Insert(m);
            }
            UiCommon.JscriptPrint(this.Page, "保存成功！", Request.Url.AbsoluteUri, "Success");
        }
    }
}