using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Suppler.product
{
    public partial class modifyproductshop : SupplerPageBase
    {
        public static string urllist = "productlist.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SupplerPageBase.memberInfo == null)
                {
                    HttpContext.Current.Response.Redirect(ECommon.WebUrl + "loginout.aspx");
                }
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "")
            {
                EnProduct model = ECProduct.GetProductInfo("  where id=" + ECommon.QueryId);
                urllist = "productlist.aspx";
                string strWhere = "";
                switch (memberInfo.type)
                {
                    case (int)EnumMemberType.工厂企业:
                       // strWhere += " cid=" + companyInfo.id + " and ctype=" + memberInfo.type; 2014年12月6日14:53:16 ylk
                        strWhere += " mid=" + memberInfo.id + " and ctype=" + memberInfo.type;
                        urllist = "productlist.aspx";
                        break;
                    case (int)EnumMemberType.经销商:
                        strWhere += " mid=" + memberInfo.id + " and ctype=" + memberInfo.type;
                        urllist = "dealerproductlist.aspx";
                        break;
                }

                if (model != null)
                {
                    lb_productname.Text = model.title;
                }
                else
                {
                    //UiCommon.JscriptPrint(this.Page, "抱歉，产品不存在!", urllist, "Success");
                    Response.Write("<script>alert('抱歉，产品不存在!');parent.location.href='" + urllist + "'</script>");
                    return;
                }

                List<EnShop> _lst = ECShop.GetShopList(strWhere);
                if (_lst == null || _lst.Count <= 0)
                {
                    //UiCommon.JscriptPrint(this.Page, "抱歉，您还没有添加店铺。请先新增店铺!", Request.Url.AbsoluteUri, "Success");
                    Response.Write("<script>alert('抱歉，您还没有添加店铺。请先新增店铺!');</script>");
                    return;
                }
                EnProductAttribute ProductAttrModel = TREC.ECommerce.ECProductAttribute.GetProductAttributeInfo(" where productid=" + Convert.ToInt32(ECommon.QueryId));
                if (ProductAttrModel!=null)
                {
                    txtprice.Text = ProductAttrModel.markprice.ToString();
                    txtdollprice.Text = ProductAttrModel.buyprice.ToString();
                }
                
                ddlshop.DataSource = _lst;
                ddlshop.DataTextField = "title";
                ddlshop.DataValueField = "id";
                ddlshop.DataBind();
                ddlshop.Items.Insert(0, new ListItem("--请选择--", ""));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlshop.SelectedValue))
            {
                //UiCommon.JscriptPrint(this.Page, "抱歉，请选择店铺!", Request.Url.AbsoluteUri, "Success");
                Response.Write("<script>alert('抱歉，请选择店铺!');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtprice.Text.Trim()))
            {
                //UiCommon.JscriptPrint(this.Page, "抱歉，请填写销售价格!", Request.Url.AbsoluteUri, "Success");
                Response.Write("<script>alert('抱歉，请填写销售价格!');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtdollprice.Text.Trim()))
            {
                //UiCommon.JscriptPrint(this.Page, "抱歉，请填写促销价格!", Request.Url.AbsoluteUri, "Success");
                Response.Write("<script>alert('抱歉，请填写促销价格!');</script>");
                return;
            }
            EnProductShopPrice model = new EnProductShopPrice();
            if (ismodify.Value == "1")
            {
                model.Id = 1;
            }
            else
            {
                model.Id = 0;
            }
            model.Productid = Convert.ToInt32(ECommon.QueryId);
            model.Shopid = Convert.ToInt32(ddlshop.SelectedValue);
            model.Price = Convert.ToDecimal(txtprice.Text.Trim());
            model.Lastedittime = DateTime.Now;
            model.Dollprice = Convert.ToDecimal(txtdollprice.Text.Trim());
            model.Brandid = 0;
            model.Attributeid = 0;
            model.Brandsid = 0;
            int aid = ECProductShopPrice.EditProductShopPrice(model);
            #region 编辑产品价格

            EnProductAttribute ProductAttrModel = TREC.ECommerce.ECProductAttribute.GetProductAttributeInfo(" where productid=" + Convert.ToInt32(ECommon.QueryId));
            if (ProductAttrModel!=null)
            {
                ProductAttrModel.productid = ProductAttrModel.productid;
                ProductAttrModel.saleprice = Convert.ToDecimal(txtprice.Text.Trim());
                ProductAttrModel.buyprice = Convert.ToDecimal(txtdollprice.Text.Trim());
                ECProductAttribute.EditProductAttribute(ProductAttrModel);  
            }
            
            #endregion
            if (aid > 0)
            {
                //UiCommon.JscriptPrint(this.Page, "恭喜，编辑成功!", Request.Url.AbsoluteUri, "Success");
                //Response.Write("<script>alert('恭喜，编辑成功!');parent.location.href='" + "productlist.aspx" + "'</script>");
                Response.Write("<script>alert('恭喜，编辑成功!');parent.$.fancybox.close();</script>");
                return;
            }
            else
            {
                //UiCommon.JscriptPrint(this.Page, "抱歉，编辑失败!", Request.Url.AbsoluteUri, "Success");
                Response.Write("<script>alert('抱歉，编辑失败!');</script>");
                return;
            }
        }

        /// <summary>
        /// 获取店铺的价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlshop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlshop.SelectedValue))
            {
                string productid = ECommon.QueryId;
                string shopid = ddlshop.SelectedValue;
                EnProductShopPrice models2 = ECProductShopPrice.GetProductShopPriceInfo(" where productid=" + productid + " and shopid=" + shopid);
                if (models2 != null)
                {
                    txtprice.Text = models2.Price.ToString("F2");
                    txtdollprice.Text = models2.Dollprice.ToString("F2");
                    ismodify.Value = "1";
                }
                else
                {
                    ismodify.Value = "0";
                }
            }
        }
    }
}