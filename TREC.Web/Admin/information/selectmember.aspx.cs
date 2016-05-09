using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.Entity;
using TREC.ECommerce;

namespace TREC.Web.Admin.information
{
    public partial class selectmember : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //账号类型
                ddlmembertype.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumMemberType), ddlmembertype);
                ddlmembertype.Items.Insert(0, new ListItem("请选择", ""));


                ddlmembergroup.DataSource = ECMember.GetMemberGroupList("");
                ddlmembergroup.DataTextField = "title";
                ddlmembergroup.DataValueField = "id";
                ddlmembergroup.DataBind();
                ddlmembergroup.Items.Insert(0, new ListItem("请选择", ""));

                ShowData();
            }
        }


        protected void ShowData()
        {
            string strWhere = " 1=1 ";
            if (ECommon.QuerySearchDisplay == "shop")
            {
                strWhere += " and (type=" + (int)EnumMemberType.工厂企业 + " or type=" + (int)EnumMemberType.经销商 + ")";
            }
            else if (ECommon.QuerySearchDisplay == "market")
            {
                strWhere += " and (type=" + (int)EnumMemberType.卖场 + ")";
            }
            if (txtUserName.Text != "")
            {
                strWhere += " and username like '%" + txtUserName.Text + "%'";
            }

            if (ddlmembergroup.SelectedValue != "")
            {
                strWhere += " and groupid=" + ddlmembergroup.SelectedValue;
            }

            if (ddlmembertype.SelectedValue != "")
            {
                strWhere += " and type=" + ddlmembertype.SelectedValue;
            }

            rptList.DataSource = ECMember.GetMemberList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount);
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
                ECMember.DeletEnMemberByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
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
    }
}