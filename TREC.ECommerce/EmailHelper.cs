using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using System.Net.Mime;

namespace TREC.ECommerce
{
    public class EmailHelper
    {
        /// <summary>
        /// 管理员接受信息邮箱
        /// </summary>
        public const string BackEmail = "purchase@jiajuks.com";
        /// <summary>
        /// 发送邮件邮箱
        /// </summary>
        public const string _SendEmail = "service@jiajuks.com";
        /// <summary>
        /// 发送邮件邮箱密码
        /// </summary>
        public const string SendEmailCode = "s1d2f3";
        /// <summary>
        /// 发送邮件HOST
        /// </summary>
        public const string SendEmailHost = "mail.jiajuks.com";
        /// <summary>
        /// 发送邮件HOST
        /// </summary>
        public const string SendName = "家具快搜";
        /// <summary>
        /// 公用发送邮件
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Email"></param>
        /// <param name="TEXT"></param>
        /// <returns></returns>
        public static bool SendEmail(string Title, string Email, string TEXT)
        {
            MailMessage mess = new MailMessage();
            mess.From = new MailAddress(_SendEmail, SendName);
            //send E-mail Address要正确
            mess.Subject = Title;
            //邮件标题
            mess.IsBodyHtml = true;

            mess.BodyEncoding = System.Text.Encoding.UTF8;
            //邮件编码
            mess.Body = TEXT;
            //邮件正文
            SmtpClient client = new SmtpClient();
            client.Host = SendEmailHost;
            //SMTP服务器要正确，经测试，可以使用smtp.sina.com(.cn)    smtp.163.com   smtp.126.com
            try
            {
                client.Credentials = new System.Net.NetworkCredential(_SendEmail, SendEmailCode);
            }
            catch
            {
                return false;
            }
            //需要验证，用户名和密码要正确
            mess.To.Add(new MailAddress(Email));

            //接收邮件的邮箱要正确
            try
            {
                client.Send(mess);
            }
            catch (Exception ee)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 会员注册发送邮件模版
        /// </summary>
        /// <param name="regUsername"></param>
        /// <returns></returns>
        protected static string GetRegisterBodyHtml()
        {
            string str = string.Empty;
            str += "<table style='width:90%' cellpadding='0' cellspacing='0'><tr><td align='center'><table style='background-color:#f0f7ff;font-size: 12px;color: #5a595a; line-height: 20px;border:solid 1px #d2d2d2;' border='0' cellpadding='0' cellspacing='0' width='590px'><tr><td align='center'><table border='0' cellpadding='0' cellspacing='5' style='font-size: 12px;color: #5a595a; line-height: 20px' width='95%'><tr><td align='left'><table style='font-size: 12px;'><tr><td style='height:8px'></td></tr><tr><td><span style='font-weight: bold; font-size: 14px; color: #9e116b'>尊敬的：";
            str += SupplerPageBase.memberInfo.username;
            str += "</span></td></tr><tr><td>您好！</td></tr><tr><td>恭喜您成功注册成为 [ <strong>家具快搜</strong> ] 会员！以下是您的注册信息：</td></tr></table><table style='border:solid 1px #d2d2d2;background-color:#fef5fb' border='0' cellpadding='0' cellspacing='0' width='100%'><tr><td align='center'><table style='font-size: 12px;width:95%;line-height: 21px;' cellpadding='0' cellspacing='0'><tr><td style='background-color:#fef5fb' align='left'><br />您的会员名：<strong>";
            str += SupplerPageBase.memberInfo.username;
            str += "</strong>";
            str += "<br />(注：请妥善保存此邮件，以便您忘记用户名或密码时使用)<br /><br /><br /><br /><br /></td></tr></table></td></tr></table><p>再次感谢您对家具快搜的信任与支持！<br />============================================</p><p><img alt='家具快搜' src='" + ECommon.WebResourceUrl + "/web/images/index_12.jpg' /></p><p>咨询热线：400-001-9211<br />传真：021-66240323</p><p>通信地址：宝山区长临路969号306室<br />E-mail：<a href='mailto:service@fujiawang.com' target='_blank'>service@fujiawang.com</a></p><p><br /><p><strong>家具快搜  - 您的新家从家具快搜开始</strong></p><p><strong>众多品牌家具厂家直销，上千款家具，实体店看样，网上订购 最多可省60% !</strong></p><a href='" + ECommon.WebResourceUrl + "' target='_blank'>" + ECommon.WebUrl + "</a><br />";
            str += DateTime.Today.ToString("yyyy 年 MM 月 dd 日");
            str += "<br /><br /></p></td></tr></table></td></tr></table></td></tr></table>";
            return str;
        }

        /// <summary>
        /// 注册发送邮件
        /// </summary>
        /// <param name="_username">用户名</param>
        /// <param name="_email">邮箱</param>
        /// <returns></returns>
        public static bool SendEmailReg(string _username, string _email, string TypeName, string _phone, string _tname, string _qq)
        {
            string username = string.Empty;
            string email = string.Empty;
            string phone = string.Empty;
            string tname = string.Empty;
            string qq = string.Empty;
            if (string.IsNullOrEmpty(_username))
            {
                username = SupplerPageBase.memberInfo.username;
            }
            else
            {
                username = _username;
            }
            if (string.IsNullOrEmpty(_email))
            {
                email = SupplerPageBase.memberInfo.email;
            }
            else
            {
                email = _email;
            }
            if (string.IsNullOrEmpty(_phone))
            {
                phone = SupplerPageBase.memberInfo.phone;
            }
            else
            {
                phone = _phone;
            }
            if (string.IsNullOrEmpty(_tname))
            {
                tname = SupplerPageBase.memberInfo.tname;
            }
            else
            {
                tname = _tname;
            }
            if (string.IsNullOrEmpty(qq))
            {
                qq = SupplerPageBase.memberInfo.qq;
            }
            else
            {
                qq = _qq;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                return false;
            }
            MailMessage mess = new MailMessage();
            mess.From = new MailAddress(_SendEmail, SendName);
            //send E-mail Address要正确
            mess.Subject = "您在家具快搜上的注册信息";
            //邮件标题
            mess.IsBodyHtml = true;

            mess.BodyEncoding = System.Text.Encoding.UTF8;
            //邮件编码
            mess.Body = GetRegisterBodyHtml();
            //邮件正文
            SmtpClient client = new SmtpClient();
            client.Host = SendEmailHost;
            //SMTP服务器要正确，经测试，可以使用smtp.sina.com(.cn)    smtp.163.com   smtp.126.com
            try
            {
                client.Credentials = new System.Net.NetworkCredential(_SendEmail, SendEmailCode);
            }
            catch
            {
                return false;
            }
            //需要验证，用户名和密码要正确
            mess.To.Add(new MailAddress(email));

            //接收邮件的邮箱要正确
            try
            {
                client.Send(mess);
            }
            catch (Exception ee)
            {
                return false;
            }
            finally
            {
                SendEmail("会员注册通知", BackEmail, GetRegBodyHtml(username, TypeName, phone, tname, qq));
            }
            return true;
        }

        /// <summary>
        /// 注册发送邮件
        /// </summary>
        /// <returns></returns>
        public static bool SendEmailReg(string TypeName)
        {
            return SendEmailReg(null, null, TypeName, null, null, null);
        }

        /// <summary>
        /// 客户注册后，发送给管理员的邮件通知模版
        /// </summary>
        /// <param name="regUsername"></param>
        /// <returns></returns>
        protected static string GetRegBodyHtml(string regUsername, string TypeName, string phone, string tname, string qq)
        {
            string str = string.Empty;
            str += "<table style='width:90%' cellpadding='0' cellspacing='0'><tr><td align='center'><table style='background-color:#f0f7ff;font-size: 12px;color: #5a595a; line-height: 20px;border:solid 1px #d2d2d2;' border='0' cellpadding='0' cellspacing='0' width='590px'><tr><td align='center'><table border='0' cellpadding='0' cellspacing='5' style='font-size: 12px;color: #5a595a; line-height: 20px' width='95%'><tr><td align='left'><table style='font-size: 12px;'><tr><td style='height:8px'></td></tr><tr><td><span style='font-weight: bold; font-size: 14px; color: #9e116b'>尊敬的：管理员";
            str += "</span></td></tr><tr><td>您好！</td></tr><tr><td>恭喜您，又有会员在[ <strong>家具快搜</strong> ]成功注册！以下是他/她的注册信息：</td></tr></table><table style='border:solid 1px #d2d2d2;background-color:#fef5fb' border='0' cellpadding='0' cellspacing='0' width='100%'><tr><td align='center'><table style='font-size: 12px;width:95%;line-height: 21px;' cellpadding='0' cellspacing='0'><tr><td style='background-color:#fef5fb' align='left'><br />名称：<strong>";
            str += regUsername;
            str += "<br /></td></tr><tr><td style='background-color:#fef5fb' align='left'><br />会员类型：<strong>";
            str += TypeName;
            str += "<br /></td></tr></table></td></tr>";
            str += "<tr><td style='background-color:#fef5fb' align='left'><br />联系方式：<strong>";
            str += phone;
            str += "<br /></td></tr><tr><td style='background-color:#fef5fb' align='left'><br />联系人：<strong>";
            str += tname;
            str += "<br /></td></tr><tr><td style='background-color:#fef5fb' align='left'><br />QQ：<strong>";
            str += qq;
            str += "<br /></td></tr>";
            str += "</table><p><img alt='家具快搜' src='" + ECommon.WebResourceUrl + "/web/images/index_12.jpg' /></p><p>咨询热线：400-001-9211<br />传真：021-66240323</p><p>E-mail：<a href='mailto:service@jiajuks.com' target='_blank'>service@jiajuks.com</a></p><a href='" + ECommon.WebResourceUrl + "' target='_blank'>" + ECommon.WebUrl + "</a><br />";
            str += DateTime.Today.ToString("yyyy 年 MM 月 dd 日");
            str += "<br /><br /></p></td></tr></table></td></tr></table></td></tr></table>";
            return str;
        }

        /// <summary>
        /// 家具快搜找回密码邮件
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool GetBackPassHtml(string username, string password, string email)
        {
            string str = string.Empty;
            str += "<div>";
            str += "<p>亲爱的" + username + "(" + email + ")，您好！</p>";
            str += "<p>您申请找回家具快搜密码，如非本人操作，请忽略此邮件。</p>";
            str += "<p>您的新密码：" + password + "</p>";
            str += "<p>--<a href=\"http://www.jiajuks.com/\">家具快搜</a><p/>";
            str += "<p>此邮件为系统自动发送，请勿回复。<br/>";
            str += "如果您在使用中遇到问题，请发邮件到service@jiajuks.com</p>";
            str += "</div>";

            return SendEmail("家具快搜找回密码", email, str);
        }
    }
}
