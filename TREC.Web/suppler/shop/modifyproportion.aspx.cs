using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Suppler.shop
{
    public partial class modifyproportion : SupplerPageBase
    {
        public static string urllist = "shoplist.aspx";
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
                EnShop model = ECShop.GetShopInfo("  where id=" + ECommon.QueryId);
                urllist = "shoplist.aspx";

                if (model != null)
                {
                    lb_shop.Text = model.title;
                }
                else
                {
                    //UiCommon.JscriptPrint(this.Page, "抱歉，产品不存在!", urllist, "Success");
                    Response.Write("<script>alert('抱歉，店铺不存在!');parent.location.href='" + urllist + "'</script>");
                    return;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int count = 0;

            //调整销售价格
            if (radsale.Checked)
            {
                int pricetype = int.Parse(rad_type.SelectedValue);
                int adjustmenttype = int.Parse(dropadjustment.SelectedValue);

                if (string.IsNullOrEmpty(txtprice.Text.Trim()))
                {
                    //UiCommon.JscriptPrint(this.Page, "抱歉，请填写销售价格!", Request.Url.AbsoluteUri, "Success");
                    Response.Write("<script>alert('抱歉，请填写调整比例!');</script>");
                    return;
                }
                if (string.IsNullOrEmpty(txtdollprice.Text.Trim()))
                {
                    //UiCommon.JscriptPrint(this.Page, "抱歉，请填写促销价格!", Request.Url.AbsoluteUri, "Success");
                    Response.Write("<script>alert('抱歉，请填写促销价格!');</script>");
                    return;
                }
                EnProductShopPrice model = new EnProductShopPrice();

                List<EnProductShopPrice> modelshoppricelist = ECProductShopPrice.GetProductShopPriceListByShopId(ECommon.QueryId);
                List<EnProductAttribute> modeltproattlist = ECProductAttribute.GetProductAttributeListByShopId(ECommon.QueryId);

                
                foreach (EnProductAttribute pa in modeltproattlist)
                {
                    int flg = 0;
                    int spi = 0;
                    for (int i = 0; i < modelshoppricelist.Count; i++)
                    {
                        if (pa.productid == modelshoppricelist[i].Productid)
                        {
                            flg = i;
                            spi = 1;
                        }
                    }
                    if (spi > 0)
                    {
                        //在ProductShopPrice表做更新操作
                        modelshoppricelist[flg].Lastedittime = DateTime.Now;

                        //根据市场价调整，下调，当前市场价不是空,当前市场价不是0
                        if (int.Parse(rad_type.SelectedValue) == 0 && int.Parse(dropadjustment.SelectedValue) > 0 && pa.markprice != null && pa.markprice != 0)
                        {
                            modelshoppricelist[flg].Price = (decimal)pa.markprice - (decimal)((pa.markprice / Convert.ToDecimal(100)) * Convert.ToDecimal(txtprice.Text.Trim()));
                        }

                        //根据市场价调整，下调，当前市场价是空，或者当前市场价是0
                        if (int.Parse(rad_type.SelectedValue) == 0 && int.Parse(dropadjustment.SelectedValue) > 0 && (pa.markprice == null || pa.markprice ==0))
                        {
                            modelshoppricelist[flg].Price = Convert.ToDecimal(0);
                        }

                        //根据市场价调整，上调，当前市场价不是空,当前市场价不是0
                        if (int.Parse(rad_type.SelectedValue) == 0 && int.Parse(dropadjustment.SelectedValue) == 0 && pa.markprice != null && pa.markprice != 0)
                        {
                            modelshoppricelist[flg].Price = (decimal)pa.markprice + (decimal)((pa.markprice / Convert.ToDecimal(100)) * Convert.ToDecimal(txtprice.Text.Trim()));
                        }

                        //根据市场价调整，上调，当前市场价不是空,或者当前市场价是0
                        if (int.Parse(rad_type.SelectedValue) == 0 && int.Parse(dropadjustment.SelectedValue) == 0 && (pa.markprice == null || pa.markprice == 0))
                        {
                            modelshoppricelist[flg].Price = Convert.ToDecimal(0);
                        }

                        //根据销售价调整，下调，当前销售价不是空,当前销售价不是0
                        if (int.Parse(rad_type.SelectedValue) == 1 && int.Parse(dropadjustment.SelectedValue) > 0 && modelshoppricelist[flg].Price != null && modelshoppricelist[flg].Price != 0)
                        {
                            modelshoppricelist[flg].Price = (decimal)modelshoppricelist[flg].Price - (decimal)((modelshoppricelist[flg].Price / Convert.ToDecimal(100)) * Convert.ToDecimal(txtprice.Text.Trim()));
                        }

                        //根据销售价调整，下调，当前销售价是空,或者当前销售价是0
                        if (int.Parse(rad_type.SelectedValue) == 1 && int.Parse(dropadjustment.SelectedValue) > 0 && (modelshoppricelist[flg].Price == null || modelshoppricelist[flg].Price == 0))
                        {
                            modelshoppricelist[flg].Price = Convert.ToDecimal(0);
                        }

                        //根据销售价调整，上调，当前销售价不是空,当前销售价不是0
                        if (int.Parse(rad_type.SelectedValue) == 1 && int.Parse(dropadjustment.SelectedValue) == 0 && modelshoppricelist[flg].Price != null && modelshoppricelist[flg].Price != 0)
                        {
                            modelshoppricelist[flg].Price = (decimal)modelshoppricelist[flg].Price + (decimal)((modelshoppricelist[flg].Price / Convert.ToDecimal(100)) * Convert.ToDecimal(txtprice.Text.Trim()));
                        }

                        //根据销售价调整，上调，当前销售价是空，当前销售价是0
                        if (int.Parse(rad_type.SelectedValue) == 1 && int.Parse(dropadjustment.SelectedValue) == 0 && (modelshoppricelist[flg].Price == null || modelshoppricelist[flg].Price == 0))
                        {
                            modelshoppricelist[flg].Price = Convert.ToDecimal(0);
                        }

                        EnProduct product = ECProduct.GetProductInfo("where id=" + pa.productid.ToString());
                        modelshoppricelist[flg].Brandid = product.brandid;
                        modelshoppricelist[flg].Brandsid = int.Parse(product.brandsid.ToString());
                        modelshoppricelist[flg].Attributeid = pa.id;
                        modelshoppricelist[flg].Dollprice = decimal.Parse(txtdollprice.Text.Trim());
                        count = ECProductShopPrice.EditProductShopPrice(modelshoppricelist[flg]);
                    }
                    else
                    {
                        //在ProductShopPrice表做插入操作
                        EnProductShopPrice productshopprice = new EnProductShopPrice();
                        productshopprice.Productid = int.Parse(pa.productid.ToString());
                        productshopprice.Shopid = int.Parse(ECommon.QueryId);
                        productshopprice.Id = 0;

                        //根据市场价，下调，市场价不是空,市场价不是0
                        if (int.Parse(rad_type.SelectedValue) == 0 && int.Parse(dropadjustment.SelectedValue) > 0 && pa.markprice != null && pa.markprice != 0)
                        {
                            productshopprice.Price = (decimal)pa.markprice - (decimal)((pa.markprice / Convert.ToDecimal(100)) * Convert.ToDecimal(txtprice.Text.Trim()));
                        }

                        //根据市场价，下调，市场价是空,或者市场价是0
                        if (int.Parse(rad_type.SelectedValue) == 0 && int.Parse(dropadjustment.SelectedValue) > 0 && (pa.markprice == null||pa.markprice == 0))
                        {
                            productshopprice.Price = Convert.ToDecimal(0);
                        }

                        //根据市场价，上调，市场价不是空,市场价不是0
                        if (int.Parse(rad_type.SelectedValue) == 0 && int.Parse(dropadjustment.SelectedValue) == 0 && pa.markprice != null && pa.markprice != 0)
                        {
                            productshopprice.Price = (decimal)pa.markprice + (decimal)((pa.markprice / Convert.ToDecimal(100)) * Convert.ToDecimal(txtprice.Text.Trim()));
                        }

                        //根据市场价，上调，市场价是空,或者市场价是0
                        if (int.Parse(rad_type.SelectedValue) == 0 && int.Parse(dropadjustment.SelectedValue) == 0 && (pa.markprice == null || pa.markprice == 0))
                        {
                            productshopprice.Price = Convert.ToDecimal(0);
                        }

                        //根据销售价，不论上下调都是0
                        if (int.Parse(rad_type.SelectedValue) == 0)
                        {
                            productshopprice.Price = Convert.ToDecimal(0);
                        }

                        EnProduct product = ECProduct.GetProductInfo("where id=" + pa.productid.ToString());
                        productshopprice.Brandid = product.brandid;
                        productshopprice.Brandsid = int.Parse(product.brandsid.ToString());
                        productshopprice.Attributeid = pa.id;
                        productshopprice.Dollprice = decimal.Parse(txtdollprice.Text.Trim());
                        productshopprice.Lastedittime = DateTime.Now;

                        count = ECProductShopPrice.EditProductShopPrice(productshopprice);
                    }

                }

            }
            //调整市场价
            if (!radsale.Checked)
            {
                int adjustmenttype = int.Parse(dropadjustmentmarket.SelectedValue);

                if (string.IsNullOrEmpty(txtpricemarket.Text.Trim()))
                {
                    //UiCommon.JscriptPrint(this.Page, "抱歉，请填写销售价格!", Request.Url.AbsoluteUri, "Success");
                    Response.Write("<script>alert('抱歉，请填写调整比例!');</script>");
                    return;
                }
                if (string.IsNullOrEmpty(txtdollprice.Text.Trim()))
                {
                    //UiCommon.JscriptPrint(this.Page, "抱歉，请填写促销价格!", Request.Url.AbsoluteUri, "Success");
                    Response.Write("<script>alert('抱歉，请填写促销价格!');</script>");
                    return;
                }

                EnProductAttribute model = new EnProductAttribute();

                List<EnProductAttribute> modeltproattlist = ECProductAttribute.GetProductAttributeListByShopId(ECommon.QueryId);

                if (modeltproattlist != null)
                {
                    foreach (EnProductAttribute pa in modeltproattlist)
                    {
                        if (pa.markprice == null || pa.markprice == 0)
                        {
                            pa.markprice = Convert.ToDecimal(0);
                        }
                        else
                        {
                            //上调
                            if (dropadjustmentmarket.SelectedValue == "0")
                            {
                                pa.markprice = (decimal)pa.markprice + (decimal)((pa.markprice / Convert.ToDecimal(100)) * Convert.ToDecimal(txtpricemarket.Text.Trim()));
                            }
                            //下调
                            if (dropadjustmentmarket.SelectedValue == "1")
                            {
                                pa.markprice = (decimal)pa.markprice - (decimal)((pa.markprice / Convert.ToDecimal(100)) * Convert.ToDecimal(txtpricemarket.Text.Trim()));
                            }
                        }
                        ECProductAttribute ecprodatt = new ECProductAttribute();

                        count = ECProductAttribute.EditProductAttribute(pa);
                    }
                }

            }
            if (count > 0)
            {
                //Response.Write("<script>alert('恭喜，编辑成功!');parent.location.href='" + urllist + "'</script>");
                Response.Write("<script>alert('恭喜，编辑成功!');parent.$.fancybox.close();</script>");
            }
            else
            {
                Response.Write("<script>alert('抱歉，编辑失败!');</script>");
            }
        }

    }
}