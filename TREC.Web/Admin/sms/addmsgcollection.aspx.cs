using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Admin.sms
{
    public partial class addmsgcollection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlPromtype.Items.Clear();
                ddlPromtype.Items.Add(new ListItem("请选择", ""));
                ddlPromtype.Items.Add(new ListItem("抢购报名", "1"));
                ddlPromtype.Items.Add(new ListItem("团购报名", "3"));
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "")
            {
                EnMsgCollection model = ECMsgCollection.GetMsgCollectionInfo(" where id=" + ECommon.QueryId);
                txtname.Text = model.Name;
                txtcontact.Text = model.Contact;
                hiddcode.Value = model.Code;
                txtaddress.Text = model.UserAddress;
                txtProd.Text = model.MsgInfo;
                if (model.ProdCon > 0)
                {
                    ddlPromtype.SelectedValue = model.ProdCon.ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Random rat = new Random();
            EnMsgCollection model = new EnMsgCollection();
            model.Name = txtname.Text;
            model.Contact = txtcontact.Text;
            model.Code = rat.Next(100000, 999999).ToString();
            if (ECommon.QueryId != "")
            {
                model.Id = Convert.ToInt32(ECommon.QueryId);
                model.Code = hiddcode.Value;
            }
            //int id = ECMsgCollection.ModifyMsgCollection(model);
            //if (id > 0)
            //{
            //    UiCommon.JscriptPrint(this.Page, "编辑成功!", "msgcollectionlist.aspx", "Success");
            //}
        }
    }
}