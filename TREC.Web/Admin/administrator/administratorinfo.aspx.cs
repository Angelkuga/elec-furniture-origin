using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Admin.administrator
{
    public partial class administratorinfo : AdminPageBase
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
                EnAdmin model = ECAdmin.GetAdminInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.txtname.Text = model.name;
                    this.txtpassword.Text = model.password;
                    this.txtdisplayname.Text = model.displayname;
                    this.txtquestion.Text = model.question;
                    this.txtanswer.Text = model.answer;
                    this.txtemail.Text = model.email;
                    this.txtphone.Text = model.phone;
                    this.txtareacode.Text = model.areacode;
                    this.txtaddress.Text = model.address;
                    raIsLock.SelectedValue = model.islock.ToString();
                    lbOther.Text = "创建时间：" + model.createdate + "     " + "登陆次数：" + model.logincount + "     " + "最后活动模块：" + model.lastmodule + "      " + "最后活动时间：" + model.lastactivitydate;

                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnAdmin model = new EnAdmin();

            string strErr = "";
            if (this.txtname.Text.Trim().Length == 0)
            {
                strErr += "登陆账号不能为空！\\n";
            }
            if (this.txtpassword.Text.Trim().Length == 0)
            {
                strErr += "密码不能为空！\\n";
            }
            if (this.txtdisplayname.Text.Trim().Length == 0)
            {
                strErr += "姓名不能为空！\\n";
            }

            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECAdmin.GetAdminInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
                

            }
            else
            {
                model = new EnAdmin();
                model.lastmodule = "";
                model.createdate = DateTime.Now;
                model.lastactivitydate = DateTime.Now;
                model.logincount = 0;
            }


            string name = this.txtname.Text;
            string password = this.txtpassword.Text;
            string displayname = this.txtdisplayname.Text;
            string question = this.txtquestion.Text;
            string answer = this.txtanswer.Text;
            string email = this.txtemail.Text;
            string phone = this.txtphone.Text;
            string areacode = this.txtareacode.Text;
            string address = this.txtaddress.Text;
            int islock = TypeConverter.StrToInt(raIsLock.SelectedValue);

            model.name = name;
            model.password = password;
            model.displayname = displayname;
            model.question = question;
            model.answer = answer;
            model.email = email;
            model.phone = phone;
            model.areacode = areacode;
            model.address = address;
            model.islock = islock;




            

            int aid = ECAdmin.EditAdmin(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}