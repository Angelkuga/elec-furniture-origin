using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;
using System.Text;

namespace TREC.Web.Suppler.product
{
    public partial class dealerproductlist : SupplerPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //选中左边菜单栏目
                Master.menuName = "productlist";

                //如果不是经销商，
                if (memberInfo!=null &&  memberInfo.type != 102)
                {
                    HttpContext.Current.Response.Redirect(ECommon.WebUrl + "/suppler/index.aspx");                 
                }
                ddlproductcategory.Items.Clear();
                ddlproductcategory.DataSource = ECProductCategory.GetProductCategoryListToDDL("");
                ddlproductcategory.DataTextField = "title";
                ddlproductcategory.DataValueField = "id";
                ddlproductcategory.DataBind();
                ddlproductcategory.Items.Insert(0, new ListItem("请选择分类", ""));

                ddlbrand.DataSource = brandList;
                ddlbrand.DataTextField = "title";
                ddlbrand.DataValueField = "id";
                ddlbrand.DataBind();
                ddlbrand.Items.Insert(0, new ListItem("请选择品牌", ""));


                ShowData();
            }
        }

        protected void ShowData()
        {
            string strWhere = "";
            if (brandidlist.Length > 0)
            {
                strWhere = " and brandid in (" + brandidlist + ") and brandid!=0";
            }
            if (ddlproductcategory.SelectedValue != "" && ddlproductcategory.SelectedValue != "0")
            {
                strWhere += " and categoryid=" + ddlproductcategory.SelectedValue;
            }

            if (ddlbrand.SelectedValue != "" && ddlbrand.SelectedValue != "0")
            {
                strWhere += " and brandid=" + ddlbrand.SelectedValue;
            }

            if (txtProductName.Text != "")
            {
                strWhere += " and (isnull(sku,'')+isnull(title,'')+isnull(shottitle,'')+isnull(brandtitle,'') like '%" + txtProductName.Text + "%')";
            }
            strWhere = strWhere.Length > 0 ? strWhere.Substring(4, strWhere.Length - 4) : strWhere;

            int pageCount=0;
            rptList.DataSource = ECProduct.GetProductList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out pageCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = pageCount;
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {           

            
           // UiCommon.JscriptPrint(this.Page, "删除成功!", Request.Url.AbsoluteUri, "Success");
            //jsprintCurPage
            string idlist="";
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_pid")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    idlist += id + ",";
                }
            }
            if (idlist.Length > 0)
            {
                ECProduct.DeleteProductByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "JsPrint", "<script>alert('删除成功!');parent.location.href='dealerproductlist.aspx';</script>");                   
                Response.Write("<script>alert('删除成功！');location.href='dealerproductlist.aspx';</script>");
            }
        }

        protected void lkBtnSearch_Click(object sender, EventArgs e)
        {            
            ShowData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        protected bool GetEdit(string mid)
        {
            if (memberInfo != null)
            {
                if (mid == memberInfo.id.ToString())
                    return true;
            }           
                return false;           
            
        }

        public string GetWebProduct(object pid)
        {
            StringBuilder sb = new StringBuilder();
            EnWebProduct productInfo = new EnWebProduct();
            productInfo = ECProduct.GetWebProducInfo(" where id=" + pid.ToString());
            if (productInfo != null && productInfo.HtSize.Keys.Count != 0)
            {
                sb.Append("<select style=\"width:208px; height:25px;\">");
                foreach (object s in productInfo.HtSize.Keys)
                {
                    sb.Append("<option>" + s.ToString() + "</option>");
                }
                sb.Append("</select>");
            }
            else
            {
                sb.Append("暂无尺寸");
            }
            return sb.ToString();
        }
        #region 获取产品尺寸

        /// <summary>
        /// 获取产品尺寸
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public string getProductSize(object pid)
        {
            List<EnProductAttribute> listproductattribute = ECProductAttribute.GetProductAttributeList(" productid='" + pid.ToString() + "'");
            if (listproductattribute != null && listproductattribute.Count>0)
            {
                return listproductattribute[0].productlength + "*" + listproductattribute[0].productwidth + "*" + listproductattribute[0].productheight;
            }
            else
            {
                return "暂无";
            }           
        
        }
        #endregion


        public string GetStatusStr(object obj)
        {
            string str = string.Empty;
            if (obj == null)
            {
                return str;
            }
            switch (obj.ToString())
            {
                case "-1":
                    str = "审核中";
                    break;
                case "0":
                    str = "待审核";
                    break;
                case "1":
                    str = "审核通过";
                    break;
                case "-99":
                    str = "未通过";
                    break;
            }
            return str;
        }


        /// <summary>
        /// 上线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnUp_Click(object sender, EventArgs e)
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
                ECProduct.ModifyProductlinestatusByID(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist, 1);
                UiCommon.JscriptPrint(this.Page, "上线成功!", Request.Url.AbsoluteUri, "Success");
            }
            else
            {
                UiCommon.JscriptPrint(this.Page, "请选择要上线的产品!", Request.Url.AbsoluteUri, "Success");
            }
        }

        /// <summary>
        /// 下线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDon_Click(object sender, EventArgs e)
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
                ECProduct.ModifyProductlinestatusByID(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist, 0);
                UiCommon.JscriptPrint(this.Page, "下线成功!", Request.Url.AbsoluteUri, "Success");
            }
            else
            {
                UiCommon.JscriptPrint(this.Page, "请选择要下线的产品!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected void lkBtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("productinfo.aspx");
        }
    }
}