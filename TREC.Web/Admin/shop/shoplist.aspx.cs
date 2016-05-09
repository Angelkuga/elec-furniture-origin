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

namespace TREC.Web.Admin.shop
{
    public partial class shoplist : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 分页条件设置
                if (!string.IsNullOrEmpty(Request["ddlauditstatus"]))
                    ddlauditstatus.SelectedValue = Request["ddlauditstatus"].ToString();
                if (!string.IsNullOrEmpty(Request["ddllinestatus"]))
                    ddllinestatus.SelectedValue = Request["ddllinestatus"].ToString();
                if (!string.IsNullOrEmpty(Request["txtShopTitle"]))
                    txtShopTitle.Text = Request["txtShopTitle"].ToString();
                #endregion
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryEdit == "2" && ECommon.QueryId != "")
            {
                ECShop.DeletEnShop(TypeConverter.StrToInt(ECommon.QueryId));
                ECMarketStoreyShop.DeleteMarketStoreyShopByShopIdList(ECommon.QueryId);
            }

            string strWhere = " 1=1 ";

            //店铺名称
            if (!string.IsNullOrEmpty(txtShopTitle.Text.Trim()))
            {
                strWhere += " and title like '%" + txtShopTitle.Text.Trim() + "%'";
            }
            //审核状态
            if (!string.IsNullOrEmpty(ddlauditstatus.SelectedValue))
            {
                strWhere += " and auditstatus=" + ddlauditstatus.SelectedValue;
            }
            //上/下线
            if (!string.IsNullOrEmpty(ddllinestatus.SelectedValue))
            {
                strWhere += " and linestatus=" + ddllinestatus.SelectedValue;
            }
            AspNetPager1.EnableUrlRewriting = true;
            AspNetPager1.UrlRewritePattern =
                string.Format("shoplist.aspx?ddlauditstatus={0}&ddllinestatus={1}&txtShopTitle={2}&page={3}",
            ddlauditstatus.SelectedValue, ddllinestatus.SelectedValue, txtShopTitle.Text, "{0}");
            rptList.DataSource = ECShop.GetShopList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = tmpPageCount;
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
                ECShop.DeletEnShopByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                ECMarketStoreyShop.DeleteMarketStoreyShopByShopIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                UiCommon.JscriptPrint(this.Page, "批量删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }


        /// <summary>
        /// 下线并且未通过审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lonkNo_Click(object sender, EventArgs e)
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
            idlist = idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist;
            if (idlist.Length > 0)
            {
                ModifyTable_auditstatus_linestatus(idlist, EnumModifyType.shop, false, "id");

                foreach (string _item in idlist.Split(','))//处理促销信息
                {
                    if (string.IsNullOrEmpty(_item))
                    {
                        continue;
                    }
                    List<Mpromotionsrelated> promotionsrelatedlist = new List<Mpromotionsrelated>();

                    Dpromotions dpromotions = new Dpromotions();

                    promotionsrelatedlist = dpromotions.LinqData<Mpromotionsrelated>().Where(c => c.shopid == Convert.ToInt32(_item)).ToList();

                    foreach (Mpromotionsrelated _mspd in promotionsrelatedlist)
                    {
                        List<Mpromotionsrelated> _promotionsrelatedlist = dpromotions.LinqData<Mpromotionsrelated>().Where(c => c.promotionsid == _mspd.promotionsid).ToList();

                        if (_promotionsrelatedlist.Count == 1)
                        {
                            Mpromotions m = new Mpromotions();
                            m.auditstatus = 0;
                            m.linestatus = 0;
                            m.id = promotionsrelatedlist[0].promotionsid;
                            dpromotions.Update(m, c => c.id == m.id);
                        }
                        else
                        {
                            Dpromotionsrelated dpromotionsrelated = new Dpromotionsrelated();
                            dpromotionsrelated.Delete(c => c.shopid == Convert.ToInt32(_item) && c.promotionsid == _mspd.id);
                        }
                    }
                }

                List<EnBrand> model = ECBrand.GetBrandList(" id in (select brandid from t_shopbrand where shopid in(" + idlist + "))");
                if (model != null)
                {
                    foreach (EnBrand item in model)
                    {
                        List<EnAppBrand> _lst = ECAppBrand.GetAppBrandList(" brandid=" + item.id);

                        if (_lst == null || _lst.Count <= 0)//无代理
                        {
                            ModifyTable_auditstatus_linestatus(item.id.ToString(), EnumModifyType.brand, false, "id");

                            ModifyTable_auditstatus_linestatus(item.id.ToString(), EnumModifyType.product, false, "brandid");
                        }
                    }
                }

                UiCommon.JscriptPrint(this.Page, "批量下线并且未通过审核成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkGo_Click(object sender, EventArgs e)
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
            idlist = idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist;
            if (idlist.Length > 0)
            {

                ModifyTable_auditstatus_linestatus(idlist, EnumModifyType.shop, true, "id");

                UiCommon.JscriptPrint(this.Page, "批量审核通过并且上线成功!", Request.Url.AbsoluteUri, "Success");
            }
        }
    }
}