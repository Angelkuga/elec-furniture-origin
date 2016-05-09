using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;

namespace TREC.Web.Admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void loginsubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (txtUserName.Text == "admin" && txtUserPwd.Text == "HLYhpy15")
            {
                //TRECommon.CookiesHelper.WriteCookie("aadmin", TRECommon.MyMD5.GetMD5("admin"));
                //TRECommon.CookiesHelper.WriteCookie("apwd", TRECommon.MyMD5.GetMD5("HLYhpy15"));
                //Response.Redirect("index.aspx");
                #region 登录
                string userTicketData = "" + TRECommon.MyMD5.GetMD5("admin") + "|" + TRECommon.MyMD5.GetMD5("HLYhpy15");
                //加密存储cookie
                System.Web.Security.FormsAuthenticationTicket Ticket = new System.Web.Security.FormsAuthenticationTicket(1, "UserTicket", DateTime.Now, DateTime.Now.AddDays(1), false, userTicketData);
                userTicketData = System.Web.Security.FormsAuthentication.Encrypt(Ticket);
                HttpCookie userCookie = new HttpCookie("AdminInfo", userTicketData);
                userCookie.Expires = Ticket.Expiration;
                HttpContext.Current.Response.AppendCookie(userCookie);
                Response.Redirect("index.aspx");
                #endregion 登录
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}