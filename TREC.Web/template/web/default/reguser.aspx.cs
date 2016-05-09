using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Entity;
using TREC.ECommerce;
using TRECommon;

namespace TREC.Web
{
    public partial class reguser : System.Web.UI.Page
    {
        protected string pageTitle = "";
        protected string _t = "p";
        public string getUrlReferrer;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "家具快搜 - 用户注册";
            if (!Page.IsPostBack)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Request.UrlReferrer.AbsoluteUri))
                    {
                        getUrlReferrer = Request.UrlReferrer.AbsoluteUri;
                    }
                    else
                    {
                        getUrlReferrer = "/";
                    }
                }
                catch
                {
                    getUrlReferrer = "/";
                }

                if (string.IsNullOrEmpty(hideurl.Value))
                {
                    hideurl.Value = getUrlReferrer;
                }
            }
        }
       
       
        /// <summary>
        /// 手机注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnmobile_Click(object sender, ImageClickEventArgs e)
        {
           
            if (!string.IsNullOrEmpty(txtmobile.Text))
            {
                EnCustomerActive enCA = ECCustomerActive.GetCustomerActive(string.Format(" where atype=1 and astatus=1 and atext='{0}' order by id desc", txtmobile.Text));
                EnCustomer chkU = ECCustomer.GetCustomer(string.Format(" where unametype=1 and uname='{0}'", txtmobile.Text));
                if (enCA != null)
                {
                    if (chkU != null)
                    {
                        Response.Write("<script>alert('注册失败，手机账号已被使用!');window.history.go(-1);</script>");
                        Response.End();
                    }
                    if (enCA.ACode == txtcodeA.Text)
                    {
                        EnCustomer models = new EnCustomer();
                        models.Id = 0;
                        models.UName = txtmobile.Text;
                        models.UPassword = MyMD5.GetMD5(txtpassword.Text);
                        models.UStatus = 1;
                        models.UNameType = 1;
                        models.RegIP = HttpContext.Current.Request.UserHostAddress;
                        models.Regtime = DateTime.Now;
                        int rs = ECCustomer.EditCustomer(models);
                        enCA.AStatus = 0;
                        ECCustomerActive.EditCustomer(enCA);

                        #region 登录cookies
                        string customerTicketData = models.Id + "|" + models.UName + "|" + MyMD5.GetMD5(models.UPassword);
                        //加密存储cookie
                        System.Web.Security.FormsAuthenticationTicket Ticket = new System.Web.Security.FormsAuthenticationTicket(1, "CustomerTicket", DateTime.Now, DateTime.Now.AddDays(30), false, customerTicketData);
                        customerTicketData = System.Web.Security.FormsAuthentication.Encrypt(Ticket);
                        HttpCookie customerCookie = new HttpCookie("CustomerInfo", customerTicketData);
                        customerCookie.Expires = Ticket.Expiration;
                        HttpContext.Current.Response.AppendCookie(customerCookie);
                        #endregion

                        if (hdpopflag.Value == "0")
                        {
                            Response.Write("<script>alert('注册完成!');window.location.href='" + hideurl.Value + "';</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('注册完成!');window.parent.location = '" + hideurl.Value + "';window.parent.funclose('divsj');</script>");
                        }
                        Response.End();
                    }
                    else
                    {
                        Response.Write("<script>alert('注册失败，验证码错误!');window.history.go(-1);</script>");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("<script>alert('注册失败，验证码无效!!');window.history.go(-1);</script>");
                    Response.End();
                }
            }
        }
       
        /// <summary>
        /// 邮件注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnmail_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmail.Text))
            {
                if (Session["_session_reg"] != null)
                {
                    if (Session["_session_reg"].ToString() == txtcodemail.Text)
                    {
                        EnCustomer chkU = ECCustomer.GetCustomer(string.Format(" where unametype=2 and uname='{0}'", txtmail.Text));
                        if (chkU == null)
                        {
                            EnCustomer models = new EnCustomer();
                            models.Id = 0;
                            models.UName = txtmail.Text;
                            models.UPassword = MyMD5.GetMD5(txtpasswordmail.Text);
                            models.UStatus = 0;
                            models.UNameType = 2;
                            models.RegIP = HttpContext.Current.Request.UserHostAddress;
                            models.Regtime = DateTime.Now;
                            int rs = ECCustomer.EditCustomer(models);
                            Random rnd = new Random();
                            string rndCode = rnd.Next(10000000, 99999999).ToString();

                            EnCustomerActive enCA = new EnCustomerActive();
                            enCA.ACode = rndCode;
                            enCA.CreateTime = DateTime.Now;
                            enCA.AType = 2;
                            enCA.AStatus = 1;
                            enCA.AText = txtmail.Text;
                            #region 发送激活邮件
                            string mailcode = TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') + "/regusermailactive.aspx?code=" + rndCode + "&url=" + hideurl.Value;
                            
                            string mailsubject = string.Format(@"
                        <p>尊敬的{0}：<br/></p>
                        <p>您好！<br/></p>
                        <p>恭喜您成功注册成为 [ 家具快搜 ] 会员 ！ </p>
                        <p>请您点击以下链接完成邮件激活：<br/></p>
                        <p><a href='{1}' target='_blank'>点击这里激活帐户 </a></p>                        
                        <p>============================================</p>
                        <p><img src='http://www.jiajuks.com/resource/web/images/index_12.jpg'/></p>
                        <p>家具快搜 - 您的新家从家具快搜开始</p>
                        <p>众多品牌家具厂家直销，上千款家具，实体店看样，网上订购 最多可省60% !</p>
                        <p><a href='http://www.jiajuks.com' target='_blank'>www.jiajuks.com</a></p>
                        <p>{2}</p>", txtmail.Text, mailcode, DateTime.Today.ToString("yyyy 年 MM 月 dd 日"));

                            bool rsmail = EmailHelper.SendEmail("家具快搜 注册账号邮件激活", txtmail.Text, mailsubject);

                            #endregion
                            rs = ECCustomerActive.EditCustomer(enCA);
                            if (hdpopflag.Value == "0")
                            {
                                Response.Write("<script>alert('注册完成,注册激活邮件已发送到你的E-mail中!');window.location.href='" + hideurl.Value + "';</script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('注册完成,注册激活邮件已发送到你的E-mail中!');window.parent.location = '/';window.parent.funclose('divsj');</script>");
                            }
                            Response.End();
                        }
                        else
                        {
                            Response.Write("<script>alert('注册失败，邮件账号已被使用!');window.history.go(-1);</script>");
                            Response.End();
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('注册失败，验证码错误!');window.history.go(-1);</script>");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("<script>alert('注册失败，验证码无效!');window.history.go(-1);</script>");
                    Response.End();
                }
            }
        }


        private bool CheckMpUser()
        {
            return false;
        }
        protected void imgbnt_sjsave_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}