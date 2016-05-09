using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Suppler
{
    public partial class memberinfo :SupplerPageBase
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
            if (memberInfo != null)
            {
                this.txtTruename.Text = memberInfo.tname;
                this.txtEmail.Text = memberInfo.email;
                raGender.SelectedValue = memberInfo.gender.ToString();
                this.txtMobile.Text = memberInfo.mobile;
                this.txtPhone.Text = memberInfo.phone;
                this.txtMsn.Text = memberInfo.msn;
                this.txtQQ.Text = memberInfo.qq;
                this.txtAli.Text = memberInfo.ali;
                this.txtBirthDate.Text = memberInfo.birthdate.ToShortDateString();
                this.txtAddress.Text = memberInfo.address;
                this.txtSkype.Text = memberInfo.skype;
                this.txtDepartment.Text = memberInfo.department;
                this.txtCareer.Text = memberInfo.career;
                this.txtBank.Text = memberInfo.bank;
                this.txtAccount.Text = memberInfo.account;
                this.txtAlipay.Text = memberInfo.alipay;
                this.selquestion.SelectedValue = memberInfo.question.ToString();
                this.txtanswer.Text = memberInfo.answer;

            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string truename = txtTruename.Text;
            string email = txtEmail.Text;
            int gender = TypeConverter.StrToInt(raGender.SelectedValue);
            string mobile = txtMobile.Text;
            string phone = txtPhone.Text;
            string msn = txtMsn.Text;
            string qq = txtQQ.Text;
            string ali = txtAli.Text;
            DateTime birthdate = DateTime.Parse(txtBirthDate.Text);
            string address = txtAddress.Text;
            string skype = txtSkype.Text;
            string department = this.txtDepartment.Text;
            string career = this.txtCareer.Text;
            int admin = 0;
            string areacode = Request.Form["ddlareacode_value"] == null ? Request.Params["ddlareacode_value"] == null ? "" : Request.Params["ddlareacode_value"].ToString() : Request.Form["ddlareacode_value"];
            string bank = this.txtBank.Text;
            string account = this.txtAccount.Text;
            string alipay = txtAlipay.Text;
            string auth = "";
            string authvalue = "";
            DateTime authtime = DateTime.Parse("1900-01-01 00:00:00");
            DateTime lastedittime = DateTime.Now;
            string question = Request.Form["selquestion"];
            string answer = string.Empty;
            if (question == "0")
            {
                answer = "";
            }
            else
            {
                answer = txtanswer.Text;
            }

            memberInfo.tname = truename;
            memberInfo.email = email;
            memberInfo.gender = gender;
            memberInfo.mobile = mobile;
            memberInfo.phone = phone;
            memberInfo.msn = msn;
            memberInfo.qq = qq;
            memberInfo.ali = ali;
            memberInfo.birthdate = birthdate;
            memberInfo.address = address;
            memberInfo.skype = skype;
            memberInfo.department = department;
            memberInfo.career = career;
            memberInfo.areacode = areacode;
            memberInfo.bank = bank;
            memberInfo.account = account;
            memberInfo.alipay = alipay;
            memberInfo.auth = auth;
            memberInfo.authvalue = authvalue;
            memberInfo.authtime = authtime;
            memberInfo.lastedittime = lastedittime;
            memberInfo.question = TypeConverter.StrToInt(question);
            memberInfo.answer = answer;
            int mid = ECMember.EditMember(memberInfo);


            if (mid > 0)
            {
                ScriptUtils.ShowAndRedirect("编辑成功!", "memberInfo.aspx");
            }



        }
    }
}