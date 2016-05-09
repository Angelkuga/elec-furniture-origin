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
    public partial class grouporderinfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WebControlBind.DrpBind(typeof(EnumGroupOrderStatus), ddlstatus);
                ddlstatus.Items.Insert(0, new ListItem("请选择状态", ""));

                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnGroupOrder model = ECGroupOrder.GetGroupOrderInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.txtgrouporderno.Text = model.grouporderno;
                    this.txtname.Text = model.name;
                    this.txtemail.Text = model.email;
                    this.txtphone.Text = model.phone;
                    this.txtfax.Text = model.fax;
                    this.txtmphone.Text = model.mphone;
                    this.txtzip.Text = model.zip;
                    this.txtareacode.Text = model.areacode;
                    this.txtaddress.Text = model.address;
                    this.txttotalmoney.Text = model.totalmoney.ToString();
                    this.txttotlepromoney.Text = model.totlepromoney.ToString();
                    this.txtinvoicemoney.Text = model.invoicemoney.ToString();
                    this.txtinstallationmeney.Text = model.installationmeney.ToString();
                    this.ddlstatus.SelectedValue = model.status.ToString();
                    this.txtcreatetime.Text = model.createtime.ToString();

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnGroupOrder model = null;

            string strErr = "";
            

            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            string grouporderno = this.txtgrouporderno.Text;
            string name = this.txtname.Text;
            string email = this.txtemail.Text;
            string phone = this.txtphone.Text;
            string fax = this.txtfax.Text;
            string mphone = this.txtmphone.Text;
            string zip = this.txtzip.Text;
            string areacode = this.txtareacode.Text;
            string address = this.txtaddress.Text;
            decimal totlepromoney = decimal.Parse(this.txttotlepromoney.Text);
            decimal totalmoney = decimal.Parse(this.txttotalmoney.Text);
            decimal invoicemoney = decimal.Parse(this.txtinvoicemoney.Text);
            decimal installationmeney = decimal.Parse(this.txtinstallationmeney.Text);
            int status = int.Parse(this.ddlstatus.SelectedValue);
            DateTime createtime = DateTime.Parse(this.txtcreatetime.Text);

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECGroupOrder.GetGroupOrderInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }

            if (model == null)
            {
                model = new EnGroupOrder();
                model.grouporderno = "";
                model.createtime = DateTime.Now;
                model.mid = 0;
                model.fjmid = 0;
            }

            model.name = name;
            model.email = email;
            model.phone = phone;
            model.fax = fax;
            model.mphone = mphone;
            model.zip = zip;
            model.areacode = areacode;
            model.address = address;
            model.totalmoney = totalmoney;
            model.totlepromoney = totlepromoney;
            model.invoicemoney = invoicemoney;
            model.installationmeney = installationmeney;
            model.status = status;


            int aid = ECGroupOrder.EditGroupOrder(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}