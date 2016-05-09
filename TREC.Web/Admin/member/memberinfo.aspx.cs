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
    public partial class memberinfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //账号类型
                ddlmembertype.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumMemberType), ddlmembertype);
                ddlmembertype.Items.Insert(0, new ListItem("请选择", ""));


                ddlmembergroup.DataSource = ECMember.GetMemberGroupList("");
                ddlmembergroup.DataTextField = "title";
                ddlmembergroup.DataValueField = "id";
                ddlmembergroup.DataBind();
                ddlmembergroup.Items.Insert(0, new ListItem("请选择", ""));


                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnMember model = ECMember.GetMemberInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    ddlmembertype.Enabled = false;

                    this.txtusername.Text = model.username;

                    this.lbpassport.Text = model.passport;


                    this.ddlmembertype.SelectedValue = model.type.ToString();
                    this.ddlmembertype.Enabled = false;
                    this.ddlmembergroup.SelectedValue = model.groupid.ToString();


                    //this.txtsound.Text = model.sound;
                    this.txttname.Text = model.tname;
                    this.txtemail.Text = model.email;
                    raGender.SelectedValue = model.gender.ToString();
                    this.txtmobile.Text = model.mobile;
                    this.txtphone.Text = model.phone;
                    //this.txtmsn.Text = model.msn;
                    //this.txtqq.Text = model.qq;
                    //this.txtskype.Text = model.skype;
                    //this.txtali.Text = model.ali;
                    //this.txtbirthdate.Text = model.birthdate.ToString();
                    //this.txtareacode.Text = model.areacode;
                    //this.txtaddress.Text = model.address;
                    //this.txtdepartment.Text = model.department;
                    //this.txtcareer.Text = model.career;
                    //this.txtsms.Text = model.sms.ToString();
                    //this.txtintegral.Text = model.integral.ToString();
                    //this.txtmoney.Text = model.money.ToString();
                    //this.txtbank.Text = model.bank;
                    //this.txtaccount.Text = model.account;
                    //this.txtalipay.Text = model.alipay;
                    this.txtregip.Text = model.regip;
                    this.txtregtime.Text = model.regtime.ToString();
                    this.txtloginip.Text = model.loginip;
                    this.txtlogintime.Text = model.logintime.ToString();
                    this.txtlogincount.Text = model.logincount.ToString();

                    //this.ravemail.SelectedValue = model.vemail.ToString();
                    //this.ravmobile.SelectedValue = model.vmobile.ToString();
                    //this.ravname.SelectedValue = model.vname.ToString();
                    //this.ravbank.SelectedValue = model.vbank.ToString();
                    //this.ravcompany.SelectedValue = model.vcompany.ToString();
                    //this.ravalipay.SelectedValue = model.valipay.ToString();


                    //this.txtsupport.Text = model.support;
                    //this.txtinviter.Text = model.inviter;
                    //this.lblastedittime.Text = model.lastedittime.ToString();
                    //this.lbchat.Text = model.chat.ToString();
                    //this.lbmsg.Text = model.message.ToString();

                    txtRegEndTime.Text = model.RegEndTime.Year > 1900 ? model.RegEndTime.ToString() : "";
                }
            }
            else
            {

                txtregip.Text = WebRequest.GetIP();
                txtregtime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
                //txtbirthdate.Text = "1900-01-01 00:00:00";
                //txtsms.Text = "0";
                //txtintegral.Text = "0";
                //txtmoney.Text = "0";
                txtloginip.Text = WebRequest.GetIP();
                txtlogintime.Text = "1900-01-01 00:00:00";
                txtlogincount.Text = "0";
                ddlmembertype.SelectedValue = ((int)EnumMemberType.个人成员).ToString();
                //ddlmembertype.Enabled = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnMember model = null;

            string strErr = "";


            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            string username = this.txtusername.Text;
            string password = this.txtpassword.Text;
            string paypassword = this.txtpaypassword.Text;
            int type = TypeConverter.StrToInt(this.ddlmembertype.SelectedValue);
            int groupid = TypeConverter.StrToInt(ddlmembergroup.SelectedValue);
            //string sound = this.txtsound.Text;
            string tname = this.txttname.Text;
            string email = this.txtemail.Text;
            int gender = TypeConverter.StrToInt(raGender.SelectedValue);
            string mobile = this.txtmobile.Text;
            string phone = this.txtphone.Text;
            //string msn = this.txtmsn.Text;
            //string qq = this.txtqq.Text;
            //string skype = this.txtskype.Text;
            //string ali = this.txtali.Text;
            DateTime birthdate = DateTime.Parse("1900-01-01");
            //string areacode = this.txtareacode.Text;
            //string address = this.txtaddress.Text;
            //string department = this.txtdepartment.Text;
            //string career = this.txtcareer.Text;
            //string bank = this.txtbank.Text;
            //string account = this.txtaccount.Text;
            //string alipay = this.txtalipay.Text;
            //int vemail = TypeConverter.StrToInt(this.ravemail.SelectedValue);
            //int vmobile = TypeConverter.StrToInt(this.ravmobile.SelectedValue);
            //int vname = TypeConverter.StrToInt(this.ravname.SelectedValue);
            //int vbank = TypeConverter.StrToInt(this.ravbank.SelectedValue);
            //int vcompany = TypeConverter.StrToInt(this.ravcompany.SelectedValue);
            //int valipay = TypeConverter.StrToInt(this.ravalipay.SelectedValue);
            //string support = this.txtsupport.Text;
            //string inviter = this.txtinviter.Text;
            DateTime lastedittime = DateTime.Now;


            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECMember.GetMemberInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);

                if (txtpassword.Text == "")
                {
                    model.password = model.password;
                }
                else
                {
                    model.password = MyMD5.GetMD5(txtpassword.Text);
                }
                if (txtpaypassword.Text == "")
                {
                    model.paypassword = model.paypassword;
                }
                else
                {
                    model.paypassword = MyMD5.GetMD5(txtpaypassword.Text);
                }

            }
            if (model == null)
            {
                model = new EnMember();
                model.chat = 0;
                model.message = 0;
                model.logincount = 0;
                model.regip = WebRequest.GetIP();
                model.regtime = DateTime.Now;
                model.passport = "";
                model.auth = "";
                model.authvalue = "";
                model.authtime = TypeConverter.StrToDateTime("1900-1-1 00:00:00");
                model.support = "";
                model.inviter = "";
                model.loginip = WebRequest.GetIP();
                model.logintime = TypeConverter.StrToDateTime("1900-1-1 00:00:00");
                model.password = MyMD5.GetMD5(password);
                model.paypassword = MyMD5.GetMD5(paypassword);
            }




            model.username = username;
            model.type = type;
            model.groupid = groupid;
            //model.sound = sound;
            model.tname = tname;
            model.email = email;
            model.gender = gender;
            model.mobile = mobile;
            model.phone = phone;
            //model.msn = msn;
            //model.qq = qq;
            //model.skype = skype;
            //model.ali = ali;
            model.birthdate = birthdate;
            //model.areacode = areacode;
            //model.address = address;
            //model.department = department;
            //model.career = career;
            //model.bank = bank;
            //model.account = account;
            //model.alipay = alipay;
            //model.vemail = vemail;
            //model.vmobile = vmobile;
            //model.vname = vname;
            //model.vbank = vbank;
            //model.vcompany = vcompany;
            //model.valipay = valipay;
            //model.support = support;
            //model.inviter = inviter;
            model.lastedittime = lastedittime;


            int aid = ECMember.EditMember(model);
            if (aid > 0)
            {
                if (!string.IsNullOrEmpty(txtprice.Text.Trim()) || !string.IsNullOrEmpty(txtRegEndTime.Text))
                {
                    try
                    {
                        model.overprice = 0;
                        model.RegStatcTime = DateTime.Now;
                        model.Isrecharge = true;
                        model.useprice = delstr(txtprice.Text);
                        model.RegEndTime = DateTime.Parse(txtRegEndTime.Text);
                        model.id = aid;
                        if (ECMember.ModifyMenber(model) > 0)
                        {
                            EnPayMent models = new EnPayMent();
                            models.Bank = "线下汇款";
                            models.Mid = aid;


                            int day = DateTime.Now.Day;
                            int month = DateTime.Now.Month;
                            int year = DateTime.Now.Year;
                            int hours = DateTime.Now.Hour;
                            int minutes = DateTime.Now.Minute;
                            int seconds = DateTime.Now.Second;

                            string _month = ((month < 10) ? "0" : "") + month.ToString();
                            string _day = ((day < 10) ? "0" : "") + day.ToString();
                            string _hours = ((hours < 10) ? "0" : "") + hours.ToString();
                            string _minutes = ((minutes < 10) ? "0" : "") + minutes.ToString();
                            string _seconds = ((seconds < 10) ? "0" : "") + seconds.ToString();

                            string orderid = "XX" + (year - 1900).ToString() + _month + _day + _hours + _minutes + _seconds;

                            models.OrderCode = orderid;
                            models.Price = model.useprice;
                            models.Types = 2;
                            models.CreateTime = DateTime.Now;
                            if (ECPayMent.InsertPayMentLog(models) > 0)
                            { 
                                
                            }
                        }
                    }
                    catch
                    {
                        UiCommon.JscriptPrint(this.Page, "编辑成功,单数金额输入不正确，充值失败!", Request.Url.AbsoluteUri, "Success");
                    }
                }
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        private decimal delstr(string price)
        {
            decimal str = 0;
            if (string.IsNullOrEmpty(price))
            {
                return str;
            }
            try
            {
                str = decimal.Parse(price);
            }
            catch
            {
                return 0;
            }
            return str;
        }
    }
}