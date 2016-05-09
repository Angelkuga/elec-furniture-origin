using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Suppler.shop
{
    public partial class shopbrand : SupplerPageBase
    {
        public string mid = "";

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
                ECShop.DeletEnShop(TypeConverter.StrToInt(ECommon.QueryId));
            }
            string strWhere = "";
            switch (memberInfo.type)
            {
                case (int)EnumMemberType.工厂企业:
                    strWhere += " cid=" + companyInfo.id + " and ctype=" + memberInfo.type;
                    mid = companyInfo.id.ToString();
                    break;
                case (int)EnumMemberType.经销商:
                    strWhere += " cid=" + dealerInfo.id + " and ctype=" + memberInfo.type;
                    mid = dealerInfo.id.ToString();
                    break;
            }



            rptList.DataSource = ECShop.GetShopList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount);
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
                ECShop.DeletEnShopByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                UiCommon.JscriptPrint(this.Page, "删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }
    }
}