using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Admin.promotion
{
    public partial class promotiondeflist : AdminPageBase
    {
        public EnPromotion model = new EnPromotion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryPId == "")
            {
                UiCommon.JscriptPrint(this.Page, "参数不正确，请刷新数据得新查看!", Request.Url.AbsoluteUri, "Success");
                return;
            }
            

            model = ECPromotion.GetPromotionInfo("  where id=" + ECommon.QueryPId);

            if (ECommon.QueryEdit == "2" && ECommon.QueryId != "")
            {
                ECPromotionDef.DeletePromotionDef(TypeConverter.StrToInt(ECommon.QueryId));
            }


            rptList.DataSource = ECPromotionDef.GetPromotionDefList(ECommon.QueryPageIndex, AspNetPager1.PageSize, " pid='" + ECommon.QueryPId + "'", out tmpPageCount);
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
                ECPromotionDef.DeletePromotionDefByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                UiCommon.JscriptPrint(this.Page, "批量删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }
    }
}