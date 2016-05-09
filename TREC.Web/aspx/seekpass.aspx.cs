using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TREC.Web.aspx
{


    #region 类库引用
    using TRECommon;
    using TREC.ECommerce;
    using TREC.Entity;
    #endregion


    public partial class seekpass : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "-会员找回密码";
            if (!IsPostBack)
            { }
          

            if (WebRequest.GetFormString("hf") == "seekback")
            {

                string username = WebRequest.GetFormString("txtRegName", true);
                string txtRegPwd = WebRequest.GetFormString("txtRegPwd", true);
                string txtCode = WebRequest.GetFormString("txtCode", true);           
                //判断验证码
                string vSession = "";
                if (Session == null || Session["_session_code"] != null)
                {
                    vSession = Session["_session_code"].ToString();
                }

                if (vSession.ToLower() != txtCode.ToLower())
                {
                    ScriptUtils.ShowAndRedirect("对不起，验证码不正确！", "seekpass.aspx");
                    return;
                }

                    //内容是否完整
                if (string.IsNullOrEmpty(username))
                {
                    ScriptUtils.ShowAndRedirect("对不起，请填写用户名！", "seekpass.aspx");
                    return;
                }

                if (ECMember.ChkecUserName(username) <= 0)
                {
                    ScriptUtils.ShowAndRedirect("对不起，用户不存在！", "seekpass.aspx");
                    return;
                }
               

                Random ro = new Random();
                int k = ro.Next(100000, 999999);
                EnMember memberModel = new EnMember();
                memberModel.password = MyMD5.GetMD5(txtRegPwd);
                memberModel.lastedittime = DateTime.Now;
                memberModel.loginip = WebRequest.GetIP();
                int mid = ECMember.EditMember(memberModel);
                if (mid > 0)
                {
                    ScriptUtils.ShowAndRedirect("密码修改成功，请登录！", "/index.aspx");
                    //if (Email == "question")
                    //{
                    //    CookiesHelper.WriteCookie("mid", mid.ToString());
                    //    CookiesHelper.WriteCookie("mname", memberModel.username);
                    //    CookiesHelper.WriteCookie("mpwd", memberModel.password);

                    //    ScriptUtils.ShowAndRedirect("填写正确，您密码已经修改！", "/index.aspx");
                    //}
                    //else if (Email == "email")
                    //{
                    //    //发送重置密码
                    //    EmailHelper.GetBackPassHtml(username, txtRegPwd, txtEmail);

                    //    ScriptUtils.ShowAndRedirect("填写正确，新密码已经发送至您的邮箱，请查收！", "/index.aspx");
                    //}
                }
                else
                {
                    ScriptUtils.ShowAndRedirect("抱歉，系统错误！", "/index.aspx");
                }
            }

        }


        public bool IsValidEmail(string strIn)
        {
            if (strIn.IndexOf('@') == -1)
            {
                return false;
            }
            if (strIn.IndexOf('.') == -1)
            {
                return false;
            }
            return true;

            //return System.Text.RegularExpressions.Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}