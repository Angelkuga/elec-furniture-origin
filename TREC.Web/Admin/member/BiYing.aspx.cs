using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;
using Haojibiz;

namespace TREC.Web.Admin.member
{
    public partial class BiYing : AdminPageBase
    {
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        T_BiYing bingying = new T_BiYing();
        public string curstring(string s, int len)
        {
            if (s.Length > (len / 2))
            {
                return SubmitMeth.bSubstring(s, len) + "....";
            }
            else
            {
                return s;
            }
        }

        public string isshow(object o)
        {
            if (o.ToString().ToLower() == "true")
            {
                return "已审核";
            }
            else
            {
                return "<span style='color:red;'>未审核</span>";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //账号类型
            


              
                ShowData();
            }
        }

        protected void ShowData()
        {
            
            List<T_BiYing> _list = new List<T_BiYing>();
            if (ddlmembertype.SelectedValue == "-1")
            {
                _list = EntityOper.T_BiYing.OrderBy(p => p.IsShow).ToList();
            }
            else
            {
                _list = EntityOper.T_BiYing.Where(p=>p.IsShow==bool.Parse(ddlmembertype.SelectedValue)).OrderByDescending(p => p.Id).ToList();
            }
            rptList.DataSource = _list;
            rptList.DataBind();
            AspNetPager1.RecordCount = tmpPageCount;
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            string idlist = "";
            List<T_BiYing> _listdel = new List<T_BiYing>();

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_id")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                idlist = idlist + "," + id;
                if (cb.Checked)
                {
                   _listdel.Add(EntityOper.T_BiYing.Where(p=>p.Id==Int32.Parse(id)).FirstOrDefault());

                }
            }
            if (idlist.Length > 0)
            {
                EntityOper.T_BiYing.DeleteAllOnSubmit(_listdel);
                EntityOper.SubmitChanges();
                ShowData();
                UiCommon.JscriptPrint(this.Page, "删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected string CompanyOrDealerTitle(object _Type, object _Id)
        {
            string _str = "暂无关联企业";
            if (_Type != null && _Id != null)
            {
                switch (TypeConverter.StrToInt(_Type.ToString()))
                {
                    case 101:
                        EnCompany enc = ECCompany.GetCompanyInfo(" where mid=" + _Id);
                        if (enc != null)
                        {
                            _str = enc.title;
                        }
                        break;
                    case 102:
                        EnDealer end = ECDealer.GetDealerInfo(" where mid=" + _Id);
                        if (end != null)
                        {
                            _str = end.title;
                        }
                        break;
                }
            }
            return _str;
        }

        protected void lbtnshow_Click(object sender, EventArgs e)
        {
            string idlist = "";
           

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_id")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                idlist = idlist + "," + id;
                if (cb.Checked)
                {
                   EntityOper.T_BiYing.Where(p => p.Id == Int32.Parse(id)).FirstOrDefault().IsShow=true;

                }
            }
            if (idlist.Length > 0)
            {
                EntityOper.SubmitChanges();
                ShowData();
                UiCommon.JscriptPrint(this.Page, "操作成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected void ddlmembertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}