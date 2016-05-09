using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Suppler.brand
{
    public partial class brandslist : SupplerPageBase
    {
        protected int pagequantity = 20;//每页信息数
        protected string pageStr = string.Empty;//分页
        protected int currentPage = 1;//当前索引页

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string memberId = CookiesHelper.GetCookie("mid");
                if (string.IsNullOrEmpty(memberId))
                {
                    Response.Write("<script>top.document.location.href='" + ECommon.WebUrl + "index.aspx" + "';</script>");
                    Response.End();
                }
                //选中左边菜单栏目
                Master.menuName = "brandlist";
                ShowData(memberId);
            }
        }

        protected void ShowData(string memberId)
        {
            if (string.IsNullOrEmpty(memberId))
                return;
            string strWhere = "";
            strWhere += " createmid=" + memberId;

            DataTable _dt = ECBrand.GetBrandsListToTableByView(ECommon.QueryPageIndex, pagequantity, strWhere, out tmpPageCount);
            if (_dt != null)
            {
                rptList.DataSource = _dt;
                rptList.DataBind();

                int totalPage = 0;
                //计算总页数
                if (tmpPageCount % pagequantity != 0)
                    totalPage = (tmpPageCount - tmpPageCount % pagequantity) / pagequantity + 1;
                else
                    totalPage = tmpPageCount / pagequantity;

                pageStr = commonMemberPageSub(tmpPageCount, totalPage, pagequantity, currentPage, "brandslist.aspx?", 5, "个", "系列");
            }
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
                ECBrand.DeleteBrandsByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                UiCommon.JscriptPrint(this.Page, "删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected bool GetEdit(string bid)
        {
            if (dealerCreateBrandIdList.Contains(bid))
                return true;
            return false;
        }
    }
}