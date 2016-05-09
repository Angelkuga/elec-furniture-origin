using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Admin.grouporder
{
    public partial class grouporderproductinfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnGroupOrderProduct model = ECGroupOrderProduct.GetGroupOrderProductInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.txtgrouporderno.Text = model.grouporderno;
                    this.txtpromotionid.Text = model.promotionid.ToString();
                    this.txtpromotiondefid.Text = model.promotiondefid.ToString();
                    this.txtpromoteionstageid.Text = model.promoteionstageid.ToString();
                    this.txtproductid.Text = model.productid.ToString();
                    this.txtproductattributeid.Text = model.productattributeid.ToString();
                    this.txtproductcode.Text = model.productcode;
                    this.txtproductname.Text = model.productname;
                    this.txtcolor.Text = model.color;
                    this.txtmaterial.Text = model.material;
                    this.txtsize.Text = model.size;
                    this.txtcbm.Text = model.cbm.ToString();
                    this.txtnum.Text = model.num.ToString();
                    this.txtprice.Text = model.price.ToString();
                    this.txttotalmoney.Text = model.totalmoney.ToString();
                    this.txtprice.Text = model.proprice.ToString();
                    this.txtproprice.Text = model.prototalmoney.ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnGroupOrderProduct model = null;

            string strErr = "";
            

            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }
            int productid = int.Parse(this.txtproductid.Text);
            int productattributeid = int.Parse(this.txtproductattributeid.Text);
            string productcode = this.txtproductcode.Text;
            string productname = this.txtproductname.Text;
            string color = this.txtcolor.Text;
            string material = this.txtmaterial.Text;
            string size = this.txtsize.Text;
            decimal cbm = decimal.Parse(this.txtcbm.Text);
            int num = int.Parse(this.txtnum.Text);
            decimal price = decimal.Parse(this.txtprice.Text);
            decimal totalmoney = decimal.Parse(this.txttotalmoney.Text);
            decimal proprice =decimal.Parse(this.txtproprice.Text);
            decimal prototalmoney = decimal.Parse(this.txtprototalmoney.Text);


            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECGroupOrderProduct.GetGroupOrderProductInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }

            if (model == null)
            {
                model = new EnGroupOrderProduct();

                model.grouporderid = 0;
                model.grouporderno = "";
                model.promotionid = 0;
                model.promotiondefid = 0;
                model.promoteionstageid = 0;
            }
            model.productid = productid;
            model.productattributeid = productattributeid;
            model.productcode = productcode;
            model.productname = productname;
            model.color = color;
            model.material = material;
            model.size = size;
            model.cbm = cbm;
            model.num = num;
            model.price = price;
            model.totalmoney = totalmoney;
            model.proprice = proprice;
            model.prototalmoney = prototalmoney;


            int aid = ECGroupOrderProduct.EditGroupOrderProduct(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}