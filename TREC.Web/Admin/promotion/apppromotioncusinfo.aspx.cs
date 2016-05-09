using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Admin.promotion
{
    public partial class apppromotioncusinfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ddlappbrand.Items.Clear();
                ddlappbrand.DataSource = ECAppPromotion.GetPromotionAppBrandList("");
                ddlappbrand.DataTextField = "title";
                ddlappbrand.DataValueField = "id";
                ddlappbrand.DataBind();
                ddlappbrand.Items.Insert(0, new ListItem("请选择", ""));

                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
               
                EnAppBrandCustomer model = ECAppPromotion.GetAppBrandCustomerInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.ddlappbrand.SelectedValue = model.aid.ToString();
                    this.txtname.Text = model.name;
                    this.txtphone.Text = model.phone;
                    this.txtmphone.Text = model.mphone;
                    this.txtemail.Text = model.email;
                    this.txtaddress.Text = model.address;
                    this.txtdescript.Text = model.descript;
                    this.txtcus.Text = model.cus;

                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnAppBrandCustomer model = null;

            int asid = int.Parse(ddlappbrand.SelectedValue);
            string name = this.txtname.Text;
            string phone = this.txtphone.Text;
            string mphone = this.txtmphone.Text;
            string email = this.txtemail.Text;
            string address = this.txtaddress.Text;
            string descript = this.txtdescript.Text;
            string cus = this.txtcus.Text;


            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECAppPromotion.GetAppBrandCustomerInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }
            if (model == null)
            {
                model = new EnAppBrandCustomer();
                model.id = 0;
            }

            model.aid = asid;
            model.name = name;
            model.phone = phone;
            model.mphone = mphone;
            model.email = email;
            model.address = address;
            model.descript = descript;
            model.cus = cus;

            int aid = ECAppPromotion.EditAppBrandCustomer(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}