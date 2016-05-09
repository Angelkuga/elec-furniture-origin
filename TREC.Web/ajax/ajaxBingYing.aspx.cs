using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Haojibiz;
using TREC.ECommerce;

namespace TREC.Web.ajax
{
    public partial class ajaxBingYing : System.Web.UI.Page
    {
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        T_BiYing bingying = new T_BiYing();

        public string code
        {
            get
            {
                if (Session["Se_chkImageV"] != null)
                {
                    return Session["Se_chkImageV"].ToString();
                }
                else
                {
                    if (Request.Cookies["Co_chkImageV"] != null)
                    {
                        return Request.Cookies["Co_chkImageV"].Value;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
        }

        private void sendMail(string content,string mail)
        {
            string mailsubject = content;

            bool rsmail = EmailHelper.SendEmail("有求必应用户留言", mail, mailsubject);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string Description = Request.Form["Description"];
            string phone = Request.Form["phone"];
            string Msg = Request.Form["Msg"];
            string ImgPath = Request.Form["ImgPath"];
            string IP = System.Web.HttpContext.Current.Request.UserHostAddress;
            string getcode=Request.Form["code"];
            string Contact = Request.Form["Contact"];

         
            
            if (getcode.ToLower() == code.ToLower())
            {
                if (!string.IsNullOrEmpty(Description))
                {
                    try
                    {
                        bingying.CreateTime = DateTime.Now;
                        bingying.Description = Description;
                        bingying.ImgPath = ImgPath;
                        bingying.IP = IP;
                        bingying.IsShow = false;
                        bingying.Msg = Msg;
                        bingying.phone = phone;
                        bingying.Contact_time = Contact;
                        EntityOper.T_BiYing.InsertOnSubmit(bingying);
                        EntityOper.SubmitChanges();
                        sendMail(Description, "angela@jiajuks.com");
                        sendMail(Description, "liujing@jiajuks.com");
                        Response.Write("true");
                    }
                    catch
                    {
                        Response.Write("提交失败，请联系管理员");
                    }
                }
            }
            else
            {
                Response.Write("验证码有误");
            }
            

        }
    }
}