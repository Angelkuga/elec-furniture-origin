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
    using System.Collections;
    #endregion


    public partial class reg : WebPageBase
    {
        public string getr
        {
            get
            {
                if (Request["r"] != null)
                {
                    if (Request["r"] == "1")
                    {
                        return "2";
                    }
                    else
                    {
                        return "1";
                    }
                }
                else
                {
                    return "1";
                }
            }
        }
        public Hashtable _htb = new Hashtable();//数据统计
        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "-会员注册";
            if (!IsPostBack)
            {
                _htb = ECProduct.GetIndexCount()[0];
            }
            if (WebRequest.GetFormString("hf") == "add")
            {
                /*这里注册不用，直接在ajax保存注册资料
                if (WebRequest.GetFormString("txtValidation").ToLower() == "" || WebRequest.GetFormString("txtValidation").ToLower() != SessionHelper.Get("_session_reg").ToLower())
                {
                    ScriptUtils.ShowAndRedirect("验证码为空或错误", "reg.aspx");
                    Response.Redirect("reg.aspx");
                }

                if (ECMember.ChkecUserName(WebRequest.GetFormString("txtRegName")) > 0)
                {
                    ScriptUtils.ShowMessage(this.Page, "hasMember", "用户名己存在！");
                    return;
                }


                if (WebRequest.GetFormString("txtRegName") != "" && WebRequest.GetFormString("txtRegName") != "")
                {

                    EnMember memberModel = new EnMember();
                    memberModel.id = 0;
                    memberModel.username = WebRequest.GetFormString("txtRegName");
                    memberModel.password = MyMD5.GetMD5(WebRequest.GetFormString("txtRegPwd"));
                    memberModel.paypassword = memberModel.password;
                    memberModel.birthdate = TypeConverter.StrToDateTime("1900-01-01");


                    memberModel.type = (int)EnumMemberType.个人成员;
                    memberModel.groupid = 0;
                    memberModel.sound = "";
                    memberModel.tname = "";
                    memberModel.email = "";
                    memberModel.gender = 0;
                    memberModel.mobile = "";
                    memberModel.phone = "";
                    memberModel.msn = "";
                    memberModel.qq = "";
                    memberModel.skype = "";
                    memberModel.ali = "";
                    memberModel.areacode = "";
                    memberModel.address = "";
                    memberModel.department = "";
                    memberModel.career = "";
                    memberModel.bank = "";
                    memberModel.account = "";
                    memberModel.alipay = "";

                    memberModel.authtime = TypeConverter.StrToDateTime("1900-01-01");
                    memberModel.auth = "";
                    memberModel.authvalue = "";
                    memberModel.vemail = 0;
                    memberModel.vmobile = 0;
                    memberModel.vname = 0;
                    memberModel.vbank = 0;
                    memberModel.vcompany = 0;
                    memberModel.valipay = 0;
                    memberModel.support = "";
                    memberModel.inviter = "";

                    memberModel.regtime = TypeConverter.StrToDateTime("1900-01-01");
                    memberModel.logintime = TypeConverter.StrToDateTime("1900-01-01");
                    memberModel.chat = 0;
                    memberModel.message = 0;
                    memberModel.logincount = 0;
                    memberModel.regip = WebRequest.GetIP();
                    memberModel.regtime = DateTime.Now;
                    memberModel.loginip = WebRequest.GetIP();


                    int mid = ECMember.EditMember(memberModel);
                    if (mid > 0)
                    {
                        CookiesHelper.WriteCookie("mid", mid.ToString());
                        CookiesHelper.WriteCookie("mname", memberModel.username);
                        CookiesHelper.WriteCookie("mpwd", memberModel.password);
                        Response.Redirect(ECommerce.ECommon.WebSupplerUrl + "/suppler/supplerindex.aspx");
                    }
                }
                Response.Redirect("/index.aspx");
                 * */
            }
        }
    }
}