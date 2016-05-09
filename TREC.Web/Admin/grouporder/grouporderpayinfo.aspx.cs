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
    public partial class grouporderpayinfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                WebControlBind.DrpBind(typeof(EnumGroupOrderPayType), ddlpaytype);
                ddlpaytype.Items.Insert(0, new ListItem("请选择类型", ""));

                WebControlBind.DrpBind(typeof(EnumGroupOrderPayStatus), ddlpaystatus);
                ddlpaystatus.Items.Insert(0, new ListItem("请选择状态", ""));

                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnGroupOrderPay model = ECGroupOrderPay.GetGroupOrderPayInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.txtgrouporderno.Text = model.grouporderno;
                    this.txtpaycode.Text = model.paycode;
                    this.ddlpaytype.SelectedValue = model.paytype.ToString();
                    this.txtpaymoney.Text = model.paymoney.ToString();
                    this.txtdescript.Text = model.descript;
                    this.ddlpaystatus.SelectedValue = model.paystatus.ToString();
                    this.txtpaydatetime.Text = model.paydatetime.ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnGroupOrderPay model = null;

            string strErr = "";
            

            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            int grouporderid = int.Parse(ECommon.QueryOId);
            string grouporderno = this.txtgrouporderno.Text;
            string paycode = this.txtpaycode.Text;
            int paytype = int.Parse(this.ddlpaytype.SelectedValue);
            decimal paymoney = decimal.Parse(this.txtpaymoney.Text);
            string descript = this.txtdescript.Text;
            int paystatus = int.Parse(this.ddlpaystatus.SelectedValue);
            DateTime paydatetime = DateTime.Parse(this.txtpaydatetime.Text);

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECGroupOrderPay.GetGroupOrderPayInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }

            if (model == null)
            {
                model = new EnGroupOrderPay();
            }

            model.grouporderid = grouporderid;
            model.grouporderno = grouporderno;
            model.paycode = paycode;
            model.paytype = paytype;
            model.paymoney = paymoney;
            model.descript = descript;
            model.paystatus = paystatus;
            model.paydatetime = paydatetime;


            int aid = ECGroupOrderPay.EditGroupOrderPay(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}