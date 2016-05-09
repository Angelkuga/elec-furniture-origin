using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web
{
    public partial class FindPwdUser : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnmail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmail.Text))
            {
                EnCustomerActive enCA = ECCustomerActive.GetCustomerActive(string.Format(" where atype=4 and astatus=1 and atext='{0}'", txtmail.Text));
                if (enCA != null)
                {
                    if (enCA.ACode == txtcodeB.Text)
                    {
                        EnCustomer models = ECCustomer.GetCustomer(string.Format(" where unametype=2 and uname ='{0}'", enCA.AText));
                        if (models != null)
                        {
                            models.UPassword = MyMD5.GetMD5(txtpasswordmail.Text);
                            int rs = ECCustomer.EditCustomer(models);
                            enCA.AStatus = 0;
                            ECCustomerActive.EditCustomer(enCA);
                            Response.Write("<script>alert('密码修改完成!');window.location.href='/';</script>");
                            Response.End();
                        }
                        Response.Write("<script>alert('找回失败，用户不存在!');window.history.go(-1);</script>");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("<script>alert('找回失败，验证码错误!');window.history.go(-1);</script>");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("<script>alert('找回失败，验证码失败!!');window.history.go(-1);</script>");
                    Response.End();
                }
            }
        }
        /// <summary>
        /// 手机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnmobile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmobile.Text))
            {
                EnCustomerActive enCA = ECCustomerActive.GetCustomerActive(string.Format(" where atype=3 and astatus=1 and atext='{0}'", txtmobile.Text));
                if (enCA != null)
                {
                    if (enCA.ACode == txtcodeA.Text)
                    {
                        EnCustomer models = ECCustomer.GetCustomer(string.Format(" where unametype=1 and uname ='{0}'", enCA.AText));
                        if (models != null)
                        {
                            models.UPassword = MyMD5.GetMD5(txtpassword.Text);
                            int rs = ECCustomer.EditCustomer(models);
                            enCA.AStatus = 0;
                            ECCustomerActive.EditCustomer(enCA);
                            Response.Write("<script>alert('密码修改完成!');window.location.href='/';</script>");
                            Response.End();
                        }
                        Response.Write("<script>alert('找回失败，用户不存在!');window.history.go(-1);</script>");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("<script>alert('找回失败，验证码错误!');window.history.go(-1);</script>");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("<script>alert('找回失败，验证码失败!!');window.history.go(-1);</script>");
                    Response.End();
                }
            }
        }
    }
}