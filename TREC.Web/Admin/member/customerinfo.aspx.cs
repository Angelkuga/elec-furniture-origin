using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Admin.member
{
    public partial class customerinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddltype.Items.Add(new ListItem("手机", "1"));
                ddltype.Items.Add(new ListItem("邮箱", "2"));

                ddlustatus.Items.Add(new ListItem("未激活", "0"));
                ddlustatus.Items.Add(new ListItem("激活", "1"));
                ShowData();
            }
        }
        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnCustomer model = ECCustomer.GetCustomerById(int.Parse(ECommon.QueryId));
                if (model != null)
                {
                    ddltype.SelectedValue = model.UNameType.ToString();
                    ddlustatus.SelectedValue = model.UStatus.ToString();
                    txtIP.Text = model.RegIP;
                    txtname.Text = model.UName;
                    txtregtime.Text = model.Regtime.ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnCustomer model = new EnCustomer();

            string strErr = "";


            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECCustomer.GetCustomerById(int.Parse(ECommon.QueryId));
                if (model == null) return;
                model.Id = TypeConverter.StrToInt(ECommon.QueryId);

                if (!string.IsNullOrEmpty(txtpwd.Text))
                {
                    model.UPassword = MyMD5.GetMD5(txtpwd.Text);
                }
                model.UStatus = int.Parse(ddlustatus.SelectedValue);
                ECCustomer.EditCustomer(model);

                Response.Write("<script>alert('操作完成');window.location.href='customerlist.aspx';</script>");
                Response.End();
            }
            else
            {
                model = new EnCustomer();

            }
        }
    }
}