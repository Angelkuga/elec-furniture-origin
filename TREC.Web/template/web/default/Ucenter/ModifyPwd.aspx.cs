using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.Entity;
using TREC.ECommerce;

namespace TREC.Web.template.web.Ucenter
{
	public partial class ModifyPwd : System.Web.UI.Page
	{
        private bool checkpwd(string uname,string upwd,ref EnCustomer getmodel)
        {
            upwd = MyMD5.GetMD5(upwd);
            int utype = 1;
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"\d{11}");
            if (reg.Match(uname).Success)
            {
                utype = 1; //手机登录
            }
            else
            {
                utype = 2; //email登录
            }
            EnCustomer model = ECCustomer.LoginCustomer(uname, upwd, utype);
            if (model != null)
            {
                if (model.UStatus == 0)
                {
                    return false; //未激活
                }
                else
                {
                    getmodel = model;

                    return true; //成功
                }
            }
            else
            {
                return false; //登录失败
            }
                
        }

        private bool modify(string uname, string newspwd, EnCustomer model)
        {
           string npwd  = MyMD5.GetMD5(newspwd);
            
          
             
            model.UPassword=npwd;
            ECCustomer.EditCustomer(model);
            return true;
        }
       
		protected void Page_Load(object sender, EventArgs e)
		{
            string CustomerUserId = TRECommon.CookiesHelper.GetCookieCustomer("cid");
           string userName = TRECommon.CookiesHelper.GetCookieCustomer("cname");

            if (CustomerUserId != "")
            {
                //ShoppingAddress
            }
            else
            {
                Response.Redirect("/loginuser.aspx");
            }
		}

        protected void bnt_save_Click(object sender, ImageClickEventArgs e)
        {
            string CustomerUserId = TRECommon.CookiesHelper.GetCookieCustomer("cid");
            string userName = TRECommon.CookiesHelper.GetCookieCustomer("cname");
            EnCustomer model = new EnCustomer();
            if (CustomerUserId != "")
            {
                string pwdold = txt_oldpwd.Text.Trim();
                string pwd1 = txt_pwd.Text.Trim();
                string pwd2 = txt_pwd1.Text.Trim();

                if (pwd1.Length >= 6 && pwd2.Length >= 6 && pwdold.Length >= 6)
                {
                    if (checkpwd(userName, pwdold, ref model))
                    {
                        if (pwd1.Length == pwd2.Length)
                        {
                            if (modify(userName, pwd1, model))
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "T", "alert('密码修改成功');", true);
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "TM", "location.href='" + Request.Url + "';", true);
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "T", "alert('密码修改失败');", true);
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "T", "alert('新密码输入不一致');", true);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "T", "alert('旧密码输入有误');", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "T", "alert('密码长度不能小于6位');", true);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "TM", "location.href='" + Request.Url + "';", true);
                }

                
            }
            else
            {
                Response.Redirect("/loginuser.aspx");
            }
        }
	}
}