using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text;
using System.IO;
using System.Data;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;
using System.Data.SqlClient;

namespace TREC.Web.ajax
{
    /// <summary>
    /// adminajax 的摘要说明
    /// </summary>
    public class ajaxuser : IHttpHandler, IRequiresSessionState
    {
        string regCode = string.Empty;//接收验证码
        HttpContext contextv;
        public void ProcessRequest(HttpContext context)
        {
            contextv = context;
            context.Response.ContentType = "text/plain";
            //参数类型
            string type = "";
            //参数值
            string value = "";
            string value2 = "";
            string t = "";
            string m = "";
            string mt = "";
            #region 接收参数
            regCode = HttpContext.Current.Request["regcode"];
            if (regCode == null)
            {
                regCode = "";
            }
            if (context.Request.QueryString["type"] != null)
            {
                type = context.Request.QueryString["type"];
            }
            else
            {
                type = context.Request.Params["type"];
            }

            if (context.Request.QueryString["v"] != null)
            {
                value = context.Request.QueryString["v"];
            }
            else
            {
                value = context.Request.Params["v"];
            }

            if (context.Request.QueryString["v2"] != null)
            {
                value2 = context.Request.QueryString["v2"];
            }
            else
            {
                value2 = context.Request.Params["v2"];
            }

            if (context.Request.QueryString["t"] != null)
            {
                t = context.Request.QueryString["t"];
            }
            else
            {
                t = context.Request.Params["t"];
            }

            if (context.Request.QueryString["m"] != null)
            {
                m = context.Request.QueryString["m"];
            }
            else
            {
                m = context.Request.Params["m"];
            }

            if (context.Request.QueryString["mt"] != null)
            {
                mt = context.Request.QueryString["mt"];
            }
            else
            {
                mt = context.Request.Params["mt"];
            }

         
            #endregion

            #region 判断类型

            switch (type)
            {
                case "getadcategoryadtype":
                    context.Response.Write(GetAdCategoryAdType(value));
                    break;
                case "getnoaddmember":
                    context.Response.Write(GetNoAddMember(value));
                    break;
                case "getnoaddmarket":
                    context.Response.Write(GetNoAddMarket(value));
                    break;
                case "getmarketbyctiy":
                    context.Response.Write(GetMarketListByCity(value));
                    break;
                case "getcompanyordealertoshop":
                    context.Response.Write(GetCompanyOrDealerToShop(value, t));
                    break;
                case "getbrandbycid":
                    context.Response.Write(Getbrandbycid(value, t));
                    break;
                case "gettopcompany":
                    context.Response.Write(GetTopCompany(value));
                    break;
                case "gettopbrand":
                    context.Response.Write(GetTopBrand(value));
                    break;
                case "getwebtopbrand":
                    context.Response.Write(GetTopWebBrand(value, m, mt));
                    break;
                case "getbrands":
                    context.Response.Write(GetBrands(value));
                    break;
                case "getthebrand":
                    context.Response.Write(GetTheBrand(value));
                    break;
                case "getmsc":
                    context.Response.Write(GetMSC(value));
                    break;
                case "upshopbrand":
                    context.Response.Write(UpShopBrandId(value, value2));
                    break;
                case "login":
                    context.Response.Write(Login(value, value2));
                    break;
                case "checkValidation":
                    context.Response.Write(CheckValidation(value, t, context));
                    break;
                case "checkvali":
                    context.Response.Write(CheckValidation(value, t, context));
                    break;
                case "checkName":
                    context.Response.Write(CheckName(value, value2, t));
                    break;
                case "checkname":
                    context.Response.Write(CheckName(value, value2, t));
                    break;
                case "sreg":
                    SaveRegisterDb(value, value2, m, t, context);
                    break;
                case "checkusername":
                    context.Response.Write(CheckName(value, value2, t));
                    break;
                case "checkNameEmail":
                    context.Response.Write(CheckNameEmail(value, value2, t, m));
                    break;
                case "checkmoblieemail":
                    context.Response.Write(CheckNameEmail(value, value2, t, m));
                    break;
                case "getsmallcatagory": //获取分类
                    context.Response.Write(getCategory(value, value2));
                    break;

                case "swatchcategroy": //查询色板类别
                    Getcolorswatchtype(context);
                    break;

                case "sendcode": //发送找回密码手机验证码
                    sendcode(context, value);
                    break;
                case "checkcode": //检查手机验证码
                    checkcode(context, value);
                    break;
                case "seekname": //找回用户名
                    seekname(context, value);
                    break;
                case "updatebasicdb": //修改用户资料
                    UpdateBasicDb(context);
                    break;
                case "queryshoplist": //修改用户资料
                    queryShopList(context);
                    break;
                case "saveaccountdb": //添加子账号
                    SaveAccountDb(context);
                    break;
                case "delaccount": //删除子账号
                    DelAccount(context);
                    break;

                case "revertaccountrecycle": //还原子账号
                    RevertAccountRecycle(context);
                    break;
                case "delaccountrecycle": //删除子账号
                    DelAccountRecycle(context);
                    break;
                case "seeknameemail": //邮箱找用户名
                    context.Response.Write(seeknameEmail(context, value));
                    break;
                case "sendsmscustomeractive": //发送短信消费用户注册验证吗 ******
                    context.Response.Write(SendSmsCustomerActive(context, value));
                    break;
                case "sendsmsmemberactive":
                    context.Response.Write(sendSmsMemberActive(context, value));
                    break;
                case "chkcustomer": //检查消费用户注册名
                    context.Response.Write(ChkCustomerName(context, value));
                    break;
                case "customerlogin": //消费用户登录
                    context.Response.Write(CustomerLogin(context, value));
                    break;
                case "sendfindpwd": //消费用户找回密码
                    context.Response.Write(SendFindPwd(context, value));
                    break;
                default:
                    context.Response.Write("ajax数据读取错误");
                    break;

            }
            #endregion

            context.Response.End();
        }
        #region 删除回收站中的数据
        /// <summary>
        /// 删除账号回收站中账号数据
        /// </summary>
        /// <param name="c"></param>
        /// <param name="userName">会员名</param>
        protected void DelAccountRecycle(HttpContext c)
        {
            string AccountId = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["AccountId"]))
                AccountId = c.Request["AccountId"].TrimEnd(',').Trim();
            if (!string.IsNullOrEmpty(AccountId))
            {
                bool IsDelete = ECMember.DelAccountRecycle(CookiesHelper.GetCookie("mname"), AccountId);
                if (IsDelete)
                    c.Response.Write("success");
                else
                    c.Response.Write("fail");
            }
            else
                c.Response.Write(null);
        }
        #endregion


        #region 还原回收站中子账号
        /// <summary>
        /// 还原回收站中子账号
        /// </summary>
        /// <param name="c"></param>        
        protected void RevertAccountRecycle(HttpContext c)
        {
            string AccountId = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["AccountId"]))
                AccountId = c.Request["AccountId"].TrimEnd(',').Trim();
            if (!string.IsNullOrEmpty(AccountId))
            {
                bool IsRevert = ECMember.RevertAccountRecycle(CookiesHelper.GetCookie("mname"), AccountId);
                if (IsRevert)
                    c.Response.Write("success");
                else
                    c.Response.Write("fail");
            }
            else
                c.Response.Write(null);
        }
        #endregion

        #region 删除子账号
        /// <summary>
        /// 删除账号
        /// </summary>
        /// <param name="c"></param>
        /// <param name="userName">用户名</param>
        protected void DelAccount(HttpContext c)
        {
            string AccountId = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["AccountId"]))
                AccountId = c.Request["AccountId"].TrimEnd(',').Trim();
            if (!string.IsNullOrEmpty(AccountId))
            {
                bool IsDelete = ECMember.DelAccountToRecycle(CookiesHelper.GetCookie("mname"), AccountId);
                if (IsDelete)
                    c.Response.Write("success");
                else
                    c.Response.Write("fail");
            }
            else
                c.Response.Write(null);
        }
        #endregion


        #region 保存账号信息
        /// <summary>
        /// 保存账户信息
        /// </summary>
        /// <param name="c"></param>
        /// <param name="userName">用户名</param>
        protected void SaveAccountDb(HttpContext c)
        {
            string Account = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["Account"]))
                Account = c.Request["Account"].Trim();
            string Password = string.Empty;
            if (!string.IsNullOrEmpty(c.Request["password"]))
                Password = c.Request["password"].Trim();
            int shopId = 0;
            if (!string.IsNullOrEmpty(c.Request["shopId"]))
                int.TryParse(c.Request["shopId"].Trim(), out shopId);
            int AccountId = 0;
            if (!string.IsNullOrEmpty(c.Request["AccountId"]))
                int.TryParse(c.Request["AccountId"].Trim(), out AccountId);

            #region 创建子账号
            EnMember memberModel = ECMember.GetMemberInfo(" where id=" + AccountId);
            #region  赋值
            if (memberModel != null)
            {
                memberModel.shopid = shopId;
                memberModel.password = MyMD5.GetMD5(Password);
                memberModel.paypassword = memberModel.password;
            }
            else
            {
                memberModel = new EnMember();
                memberModel.id = 0;
                memberModel.parentid = int.Parse(CookiesHelper.GetCookie("mid"));
                memberModel.username = Account;
                memberModel.shopid = shopId;
                memberModel.password = MyMD5.GetMD5(Password);
                memberModel.paypassword = memberModel.password;
                memberModel.birthdate = TypeConverter.StrToDateTime("1900-01-01");


                memberModel.type = (int)EnumMemberType.个人成员;
                memberModel.groupid = 0;
                memberModel.sound = "";
                memberModel.tname = "";
                //if (meType == "0")
                //    memberModel.email = MobileOrEmail;
                //else
                //    memberModel.email = "";            
                memberModel.gender = 0;
                //if (meType=="1")
                //    memberModel.mobile = MobileOrEmail;
                //else
                //    memberModel.mobile = "";
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

                memberModel.regtime = DateTime.Now;
                memberModel.logintime = DateTime.Now;
                memberModel.chat = 0;
                memberModel.message = 0;
                memberModel.logincount = 1;
                memberModel.regip = WebRequest.GetIP();
                memberModel.regtime = DateTime.Now;
                memberModel.loginip = WebRequest.GetIP();
            }

            #endregion

            int mid = ECMember.EditMember(memberModel);
            if (mid > 0)
                c.Response.Write("success");
            else
                c.Response.Write("fail");

            #endregion
            //if (!string.IsNullOrEmpty(Account) && !string.IsNullOrEmpty(Password) && 0 < shopId)
            //{
            //    Password=FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "MD5");
            //    int AccountId = 0;
            //    if (!string.IsNullOrEmpty(c.Request["AccountId"]))
            //        int.TryParse(c.Request["AccountId"].Trim(), out AccountId);
            //    if (AccountId < 0)
            //        AccountId = 0;
            //    bool IsSave = MemberLoginBll.SaveAccountDb(AccountId, Account, Password, shopId, userName, WebRequest.GetIP());
            //    if (IsSave)
            //        c.Response.Write("success");
            //    else
            //        c.Response.Write("fail");
            //}
            //else
            //    c.Response.Write(null);
        }

        #endregion

        #region 查询店铺数据

        /// <summary>
        /// 查询店铺数据
        /// </summary>
        /// <param name="memberId">会员id</param>
        private void queryShopList(HttpContext c)
        {
            List<EnShop> shopList = ECShop.GetShopList(" createmid = " + CookiesHelper.GetCookie("mid"));
            if (shopList != null)
            {
                string shopStr = string.Empty;
                foreach (EnShop model in shopList)
                {
                    shopStr += " <option value=\"" + model.id.ToString() + "\">" + model.title + " </option>";
                    //  shopStr += "<li><input type=\"checkbox\" value=\"" + model.id.ToString() + "\" name=\"shopId\">" + model.title + "</li>";

                }
                c.Response.Write(shopStr);
            }
        }

        #endregion

        #region 修改管理员资料
        /// <summary>
        /// 修改资料
        /// </summary>
        /// <param name="c"></param>
        /// <param name="userName">会员名</param>
        protected void UpdateBasicDb(HttpContext c)
        {
            EnMember model = ECMember.GetMemberInfo(" where username='" + CookiesHelper.GetCookie("mname") + "'");
            if (model != null)
            {

                //联系人
                model.tname = c.Request["Contact"].Trim();
                //职位
                model.career = c.Request["Duty"].Trim();
                //手机
                model.mobile = c.Request["Mobile"].Trim();
                //电话
                model.phone = c.Request["Tel"].Trim();
                //QQ/微博
                model.qq = c.Request["QQWeiBo"].Trim();
                //E-mail
                model.email = c.Request["Email"].Trim();

                bool isUpdate = ECMember.EditMember(model) > 0;
                model = null;
                if (isUpdate)
                    c.Response.Write("success");
                else
                    c.Response.Write("fail");
            }
        }
        #endregion

        #region 找回用户名

        private void seekname(HttpContext context, string value)
        {
            #region
            //判断验证码
            string vSession = "";
            string returnStr = string.Empty;
            string Sms_return_string = string.Empty;
            if (context.Session == null || context.Session["_session_code"] != null)
            {
                vSession = context.Session["_session_code"].ToString();
            }

            if (vSession.ToLower() != value.ToLower())
            {
                Sms_return_string = "对不起，输入的手机短信验证码不正确！";
            }
            else
            {

                string phone = string.Empty;
                if (context.Request.QueryString["phone"] != "")
                {
                    phone = context.Request.QueryString["phone"];
                }
                EnMember model = ECMember.GetMemberInfo(" where mobile='" + phone + "'");
                if (model != null)
                {

                    Random rd = new Random();
                    long msid = rd.Next(102346, 122658);
                    EnSms modelSms = new EnSms();
                    modelSms.Sms_content = "【家具快搜】 亲爱的用户，您正使用手机找回用户名，您的用户名为：" + model.username + ",请牢记";
                    string returnstr = MessageSend.MessageSendInfo(MessageSend.action, phone.Trim(), modelSms.Sms_content, msid.ToString(), "");
                    //存储验证码 10分钟有效
                    // SessionHelper.Add("_session_code", msid.ToString(), 10);
                    string[] retstr = returnstr.Split('&');

                    //model.Sms_number_quantity = txtcontent.Text.Trim().Length % 67 > 0 ? (txtcontent.Text.Trim().Length / 67) + 1 : txtcontent.Text.Trim().Length / 67;
                    modelSms.Sms_phone = phone.Trim();
                    modelSms.Sms_send_time = DateTime.Now;

                    if (retstr[0] == "1")
                    {
                        modelSms.Sms_status = true;
                        Sms_return_string = "true";
                    }
                    else
                    {
                        modelSms.Sms_status = false;

                        if (retstr[0] != "1")
                        {
                            string[] erridarr = retstr[1].Split('=');
                            int errid = 0;
                            if (erridarr.Length > 1 && erridarr[1] != null && erridarr[1] != "")
                            {
                                errid = int.Parse(erridarr[1]);
                            }
                            else
                            {
                                errid = 0;
                            }

                            switch (errid)
                            {
                                #region 判断提示

                                case 0:
                                    Sms_return_string = "系统原因失败";
                                    break;
                                case -1:
                                    Sms_return_string = "用户不存在或已禁用";
                                    break;
                                case -2:
                                    Sms_return_string = "hashcode或密码不正确";
                                    break;
                                case -3:
                                    Sms_return_string = "接收号码不正确";
                                    break;
                                case -4:
                                    Sms_return_string = "内容为空或超长";
                                    break;
                                case -5:
                                    Sms_return_string = "";
                                    break;
                                case -6:
                                    Sms_return_string = "内容含非法字符";
                                    break;
                                case -7:
                                    Sms_return_string = "帐户余额不足";
                                    break;
                                case -8:
                                    Sms_return_string = "当天小批次限额不足";
                                    break;
                                case -9:
                                    Sms_return_string = "提交过于频繁,超过1分钟内限定的流量";
                                    break;
                                case -10:
                                    Sms_return_string = "未添加通道签名";
                                    break;
                                default:
                                    Sms_return_string = "";
                                    break;
                                #endregion
                            }

                        }

                    }
                }

            #endregion
            }
            context.Response.Write(Sms_return_string);
        }
        #endregion

        #region 邮件找回密码
        private string seeknameEmail(HttpContext context, string value)
        {
            EnMember model = ECommerce.ECMember.GetMemberInfo(string.Format(" where email='{0}'", value));
            Random rd = new Random();
            long msid = rd.Next(123456, 234567);
            model.password = MyMD5.GetMD5(msid.ToString());
            ECommerce.ECMember.EditMember(model);

            string mailsubject = string.Format(@"
            <p>亲爱的{0}({1})，您好！</p>
            <p>您申请找回家具快搜密码，如非本人操作，请忽略此邮件。</p>
            <p>您的新密码：{2}<br/>
            --家具快搜</p>
            <p>此邮件为系统自动发送，请勿回复。<br/>
            如果您在使用中遇到问题，请发邮件到{3}</p>", model.username, model.email, msid.ToString(), EmailHelper._SendEmail);

            bool rs = EmailHelper.SendEmail("家具快搜 密码找回", model.email, mailsubject);
            if (rs)
                return "true";
            else
                return "邮件发送失败";
        }
        #endregion 邮件找回密码

        #region 修改密码
        private void checkcode(HttpContext context, string value)
        {
            //判断验证码
            string vSession = "";
            string returnStr = string.Empty;
            if (context.Session == null || context.Session["_session_code"] != null)
            {
                vSession = context.Session["_session_code"].ToString();
            }

            if (vSession.ToLower() != value.ToLower())
            {
                returnStr = "对不起，输入的手机短信验证码不正确！";
            }
            else
            {

                string username = context.Request.QueryString["name"];
                string txtRegPwd = context.Request.QueryString["pwd"];

                //内容是否完整
                if (string.IsNullOrEmpty(username))
                {
                    returnStr = "对不起，请填写用户名！";

                }
                else if (ECMember.ChkecUserName(username) <= 0)
                {
                    returnStr = "对不起，用户不存在！";

                }
                else
                {
                    Random ro = new Random();
                    int k = ro.Next(100000, 999999);
                    EnMember memberModel = ECMember.GetMemberInfo(" where username='" + username + "'");
                    memberModel.password = MyMD5.GetMD5(txtRegPwd);
                    memberModel.lastedittime = DateTime.Now;
                    memberModel.loginip = WebRequest.GetIP();
                    int mid = ECMember.EditMember(memberModel);
                    if (mid > 0)
                    {
                        returnStr = "true";
                    }
                    else
                    {
                        returnStr = "抱歉，系统错误！";
                    }
                }
            }
            context.Response.Write(returnStr);

        }
        #endregion


        #region 发送短信验证码

        private void sendcode(HttpContext context, string value)
        {
            #region 开始发送
            string title = string.Empty;
            if (context.Request.QueryString["title"] != "")
            {
                title = context.Request.QueryString["title"];
            }
            Random rd = new Random();
            long msid = rd.Next(102346, 122658);
            EnSms model = new EnSms();
            model.Sms_content = "【家具快搜】 亲爱的用户，您正使用手机找回" + title + "，手机验证码为:" + msid.ToString() + ",请您于10分钟内正确输入";
            string returnstr = MessageSend.MessageSendInfo(MessageSend.action, value.Trim(), model.Sms_content, msid.ToString(), "");
            //存储验证码 5分钟有效
            SessionHelper.Add("_session_code", msid.ToString(), 20);
            string[] retstr = returnstr.Split('&');

            //model.Sms_number_quantity = txtcontent.Text.Trim().Length % 67 > 0 ? (txtcontent.Text.Trim().Length / 67) + 1 : txtcontent.Text.Trim().Length / 67;
            model.Sms_phone = value.Trim();
            model.Sms_send_time = DateTime.Now;
            string Sms_return_string = string.Empty;
            if (retstr[0] == "1")
            {
                model.Sms_status = true;
                Sms_return_string = "true";
            }
            else
            {
                model.Sms_status = false;

                if (retstr[0] != "1")
                {
                    string[] erridarr = retstr[1].Split('=');
                    int errid = 0;
                    if (erridarr.Length > 1 && erridarr[1] != null && erridarr[1] != "")
                    {
                        errid = int.Parse(erridarr[1]);
                    }
                    else
                    {
                        errid = 0;
                    }

                    switch (errid)
                    {
                        #region 判断提示

                        case 0:
                            Sms_return_string = "系统原因失败";
                            break;
                        case -1:
                            Sms_return_string = "用户不存在或已禁用";
                            break;
                        case -2:
                            Sms_return_string = "hashcode或密码不正确";
                            break;
                        case -3:
                            Sms_return_string = "接收号码不正确";
                            break;
                        case -4:
                            Sms_return_string = "内容为空或超长";
                            break;
                        case -5:
                            Sms_return_string = "";
                            break;
                        case -6:
                            Sms_return_string = "内容含非法字符";
                            break;
                        case -7:
                            Sms_return_string = "帐户余额不足";
                            break;
                        case -8:
                            Sms_return_string = "当天小批次限额不足";
                            break;
                        case -9:
                            Sms_return_string = "提交过于频繁,超过1分钟内限定的流量";
                            break;
                        case -10:
                            Sms_return_string = "未添加通道签名";
                            break;
                        default:
                            Sms_return_string = "";
                            break;
                        #endregion
                    }

                }

            }
            context.Response.Write(Sms_return_string);
            #endregion
        }
        #endregion

        #region 查询色板类别
        public void Getcolorswatchtype(HttpContext c)
        {
            // ColorSwatchBll.QuerycolorSwatchDb(v);
            //色板中类别
            Dictionary<int, string> bgDict = ColorSwatchBll.QuerycolorSwatchDb("色板");
            if (bgDict != null)
            {
                if (0 < bgDict.Count)
                {
                    string mySc = string.Empty;
                    foreach (KeyValuePair<int, string> kvp in bgDict)
                        mySc += "<option value=\"" + kvp.Key + "\">" + kvp.Value + "</option>";
                    c.Response.Write(mySc);
                }
                else
                    c.Response.Write(null);
            }
            else
                c.Response.Write(null);
        }
        #endregion


        #region 获取小类

        public string getCategory(string value, string value2)
        {
            List<EnProductCategory> catagoryList = ECProductCategory.GetProductCategoryListToDDL("");
            StringBuilder sbCate = new StringBuilder();
            if (catagoryList != null)
            {
                int id = 0;
                int.TryParse(value, out id);
                var mallCate = from bc in catagoryList where bc.parentid == id select new { bc.id, bc.title };
                if (mallCate.Count() > 0)
                {
                    foreach (var item in mallCate)
                    {
                        sbCate.Append("{\"id\":\"" + item.id + "\",\"title\":\"" + item.title + "\"},");
                    }
                }

            }

            return sbCate.Length > 0 && sbCate.ToString().EndsWith(",") ? "[" + sbCate.ToString().Substring(0, sbCate.ToString().Length - 1) + "]" : "[" + sbCate.ToString() + "]";

        }
        #endregion

        /// <summary>
        /// 检查名称是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="ctype">m:登陆账号,c企业名称,d经销商，s店铺,m2卖场,b,品牌名称</param>
        /// <returns></returns>
        public string CheckName(string name, string name2, string ctype)
        {
            return ECommon.CheckName(name, name2, ctype);
        }

        /// <summary>
        /// 检查名称和邮箱是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="ctype">email:邮箱</param>
        /// <returns></returns>
        public string CheckNameEmail(string name, string email, string ctype, string _m)
        {
            if (_m == "0e0m0a0i0l") return "true";
            return ECommon.CheckNameEmail(name, email, ctype);
        }


        public string Login(string name, string pwd)
        {

          string getregcode=CheckValidation(regCode, "", contextv);
          getregcode = "true";
          if (getregcode == "true")
            {
                if (Validator.IsSafeSqlStringMemberLogin(name))
                {
                    int aid = ECMember.Login(name, pwd);
                    if (aid > 0)
                    {
                        if (aid == 10)
                        {
                            return "10";
                        }
                        if (aid == 100)
                        {
                            return "2";
                        }
                        else
                        {
                            return "1";
                        }
                    }
                }
                return "0";
            }
            else
            {
                return "-1";
            }
        }

        /// <summary>
        /// 检查验证码
        /// </summary>
        /// <param name="v">验证码</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string CheckValidation(string v, string vt, HttpContext context)
        {

            string vSession = "";
            if (context.Session == null || context.Session["_session_" + vt] != null)
            {
                vSession = context.Session["_session_" + vt].ToString();
            }

            if (string.IsNullOrEmpty(v))
            {
                 return "false";
            }
            if (vSession.ToLower() == v.ToLower())
            {
                return "true";
            }
            return "false";
        }


        public string GetBrands(string value)
        {
            StringBuilder sb = new StringBuilder();
            if (value != "")
            {
                List<EnBrands> list = ECBrand.GetBrandsList("  brandid=" + value);
                EnBrand b = ECBrand.GetBrandInfo(" where id=" + value);
                foreach (EnBrands m in list)
                {
                    sb.Append("{\"id\":\"" + m.id + "\",\"title\":\"" + m.title + "\",\"s\":\"" + b.style + "\",\"m\":\"" + b.material + "\",\"c\":\"" + b.color + "\"},");
                }
                if (list.Count == 0)
                {
                    sb.Append("{\"id\":\"\",\"title\":\"\",\"s\":\"" + b.style + "\",\"m\":\"" + b.material + "\",\"c\":\"" + b.color + "\"},");
                }
                return sb.Length > 0 && sb.ToString().EndsWith(",") ? "[" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "]" : "[" + sb.ToString() + "]";
            }
            return sb.ToString();
        }

        /// <summary>
        /// 品牌数据
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetTheBrand(string value)
        {
            StringBuilder sb = new StringBuilder();
            if (value != "")
            {
                List<EnBrand> list = ECBrand.GetBrandList(" companyid=" + value);
                foreach (EnBrand m in list)
                {
                    sb.Append("{\"id\":\"" + m.id + "\",\"title\":\"" + m.title + "\"},");
                }
                if (list.Count == 0)
                {
                    sb.Append("{\"id\":\"\",\"title\":\"\"},");
                }
                return sb.Length > 0 && sb.ToString().EndsWith(",") ? "[" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "]" : "[" + sb.ToString() + "]";
            }
            return sb.ToString();
        }

        /// <summary>
        /// 根据系列，回去三项（风格，选材，色系）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetMSC(string value)
        {
            StringBuilder sb = new StringBuilder();
            if (value != "")
            {
                EnBrands b = ECBrand.GetBrandsInfo(" where id=" + value);
                if (b != null)
                {
                    sb.Append("{\"s\":\"" + b.style + "\",\"m\":\"" + b.material + "\",\"c\":\"" + b.color + "\"},");
                }
                else
                {
                    sb.Append("{\"s\":\"\",\"m\":\"\",\"c\":\"\"},");
                }
                return sb.Length > 0 && sb.ToString().EndsWith(",") ? "[" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "]" : "[" + sb.ToString() + "]";
            }
            return sb.ToString();
        }

        //前台获取品牌-通过审核-从视图读取数据
        protected string UpShopBrandId(string sid, string value)
        {
            value = value.StartsWith(",") ? value.Substring(1, value.Length - 1) : value;
            value = value.EndsWith(",") ? value.Substring(0, value.Length - 1) : value;

            string[] values = value.Split(',');
            if (values.Length > 0)
            {
                StringOperation.SortAndDdistinct(values, StringOperation.OrderByType.DESC);
                List<EnShopBrand> list = new List<EnShopBrand>();
                foreach (string s in values)
                {
                    if (sid != "0" && s != "0")
                    {
                        EnShopBrand m = new EnShopBrand();
                        m.shopid = TypeConverter.StrToInt(sid);
                        m.brandid = TypeConverter.StrToInt(s);
                        list.Add(m);
                    }
                }

                if (list.Count > 0)
                {
                    ECShop.EditShopBrand(list);
                }


                int tmpPageCount = 0;
                StringBuilder sb = new StringBuilder();
                if (value != "")
                {
                    foreach (EnWebBrand b in ECBrand.GetWebBrandList(1, 30, " id in(" + value + ") ", out tmpPageCount))
                    {
                        sb.Append("{\"id\":\"" + b.id + "\",\"name\":\"" + b.title + "\",\"logo\":\"" + b.logo + "\",\"company\":\"" + b.companyname + "\",\"stylename\":\"" + b.stylename + "\",\"spreadname\":\"" + b.spreadname + "\",\"materialname\":\"" + b.materialname + "\"},");
                    }
                    if (sb.Length > 0)
                    {
                        return "[" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "]";
                    }
                }
            }
            return "";
        }


        //前台获取品牌-通过审核-从视图读取数据
        protected string GetTopWebBrand(string name, string m, string mt)
        {
            int tmpPageCount = 0;
            StringBuilder sb = new StringBuilder();
            string strWhere = "";
            if (m != "")
            {
                if (mt != "")
                {
                    switch (TypeConverter.StrToInt(mt))
                    {
                        case (int)EnumMemberType.工厂企业:
                            strWhere += " and companyid=" + m;
                            break;
                        case (int)EnumMemberType.经销商:
                            strWhere += " and id in( select brandid from " + TableName.TBAppBrand + " where dealerid=" + m + ") ";
                            break;
                    }
                }
            }

            foreach (EnWebBrand b in ECBrand.GetWebBrandList(1, 30, " (title like '%" + name + "%' or companyname like '" + name + "' or spreadname like '" + name + "' or stylename like '" + name + "' or materialname like '" + name + "') " + strWhere, out tmpPageCount))
            {
                sb.Append("{\"id\":\"" + b.id + "\",\"name\":\"" + b.title + "\",\"logo\":\"" + b.logo + "\",\"company\":\"" + b.companyname + "\",\"stylename\":\"" + b.stylename + "\",\"spreadname\":\"" + b.spreadname + "\",\"materialname\":\"" + b.materialname + "\"},");
            }
            if (sb.Length > 0)
            {
                return "[" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "]";
            }
            return "";
        }


        //获取品牌
        protected string GetTopBrand(string name)
        {
            int tmpPageCount = 0;
            StringBuilder sb = new StringBuilder();
            foreach (EnBrand b in ECBrand.GetBrandList(1, 30, " title like '%" + name + "%' ", out tmpPageCount))
            {
                sb.Append("{\"id\":\"" + b.id + "\",\"name\":\"" + b.title + "\"},");
            }
            if (sb.Length > 0)
            {
                return "[" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "]";
            }
            return "";
        }


        //获取工厂
        protected string GetTopCompany(string name)
        {
            int tmpPageCount = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"id\":\"0\",\"name\":\"无关联工厂\"},");
            foreach (EnCompany b in ECCompany.GetCompanyList(1, 30, " title like '%" + name + "%'", out tmpPageCount))
            {
                sb.Append("{\"id\":\"" + b.id + "\",\"name\":\"" + b.title + "\"},");
            }
            if (sb.Length > 0)
            {
                return "[" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "]";
            }
            return "";
        }


        //根据类型查找厂家或经销商用于店铺所属对象
        protected string GetCompanyOrDealerToShop(string name, string type)
        {
            StringBuilder sb = new StringBuilder();

            if (type == ((int)EnumMemberType.工厂企业).ToString())
            {
                foreach (EnCompany c in ECCompany.GetCompanyList(" title like '%" + name + "%'"))
                {
                    sb.Append("{\"id\":\"" + c.id + "\",\"name\":\"" + c.title + "\"},");
                }
            }

            if (type == ((int)EnumMemberType.经销商).ToString())
            {
                foreach (EnDealer d in ECDealer.GetDealerList(" title like '%" + name + "%'"))
                {
                    sb.Append("{\"id\":\"" + d.id + "\",\"name\":\"" + d.title + "\"},");
                }
            }
            if (sb.Length > 0)
            {
                return "[" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "]";
            }
            return "";
        }

        //根据类型查找厂家或经销商用于店铺所属对象
        protected string Getbrandbycid(string cid, string type)
        {
            StringBuilder sb = new StringBuilder();

            if (type == ((int)EnumMemberType.工厂企业).ToString())
            {
                foreach (EnBrand c in ECBrand.GetBrandList(" companyid=" + cid))
                {
                    sb.Append("{\"id\":\"" + c.id + "\",\"name\":\"" + c.title + "\"},");
                }
            }

            if (type == ((int)EnumMemberType.经销商).ToString())
            {
                foreach (EnAppBrand d in ECAppBrand.GetAppBrandList("dealerid=" + cid))
                {
                    sb.Append("{\"id\":\"" + d.brandid + "\",\"name\":\"" + d.brandtitle + "\"},");
                }
            }
            if (sb.Length > 0)
            {
                return "[" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "]";
            }
            return "";
        }

        //获取没有绑定对象的账号[个人会员]
        protected string GetNoAddMember(string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"id\":\"0\",\"name\":\"无关联会员\"},");
            foreach (EnMember m in ECMember.GetTop20MemberList(name))
            {
                sb.Append("{\"id\":\"" + m.id + "\",\"name\":\"" + m.username + "\"},");
            }
            if (sb.Length > 0)
            {
                return "[" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "]";
            }
            return "";
        }

        protected string GetNoAddMarket(string name)
        {
            StringBuilder sb = new StringBuilder();
            foreach (EnMarket m in ECMarket.GetTop20MarketList(name))
            {
                sb.Append("{\"id\":\"" + m.id + "\",\"name\":\"" + m.title + "\"},");
            }
            if (sb.Length > 0)
            {
                return "[" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "]";
            }
            return "";

        }

        /// <summary>
        /// 根据下拉城市获取卖场
        /// </summary>
        /// <param name="citycode"></param>
        /// <returns></returns>
        protected string GetMarketListByCity(string citycode)
        {
            StringBuilder sb = new StringBuilder();
            List<EnMarket> _lst = ECMarket.GetMarketListByCity2(citycode);
            foreach (EnMarket m in _lst)
            {
                sb.Append("{\"id\":\"" + m.id + "\",\"name\":\"" + m.title + "\"},");
            }
            if (sb.Length > 0)
            {
                return "[" + sb.ToString().Substring(0, sb.ToString().Length - 1) + "]";
            }
            return "";

        }

        public string GetAdCategoryAdType(string id)
        {
            return ECAdvertisementCategory.GetAdCategropyAdType(id);
        }

        /// <summary>
        /// 保存申请入住资料
        /// </summary>
        /// <param name="regUser">用户名</param>
        /// <param name="passWord">登录密码</param>
        /// <param name="MobileOrEmail">手机/邮箱</param>
        /// <param name="meType">1表示手机；0表示邮箱</param>
        public void SaveRegisterDb(string regUser, string passWord, string MobileOrEmail, string meType, HttpContext context)
        {
            string isRegister = ECommon.CheckName(regUser, "", "m");
            if (isRegister == "true")
            {
                context.Response.Write(ECMember.SaveRegisterDb(regUser, passWord, MobileOrEmail, meType, context.Request["userGroup"]));

                #region  注册成功短信
                Random rd = new Random();
                long msid = rd.Next(102346, 122658);
                EnSms model = new EnSms();
                model.Sms_content = "【家具快搜】 亲爱的用户，恭喜您已注册成功，请牢记您的用户名为：" + regUser + "，谢谢！";
                string returnstr = MessageSend.MessageSendInfo(MessageSend.action, MobileOrEmail.Trim(), model.Sms_content, msid.ToString(), "");

                string[] retstr = returnstr.Split('&');

                //model.Sms_number_quantity = txtcontent.Text.Trim().Length % 67 > 0 ? (txtcontent.Text.Trim().Length / 67) + 1 : txtcontent.Text.Trim().Length / 67;
                model.Sms_phone = MobileOrEmail.Trim();
                model.Sms_send_time = DateTime.Now;
                string Sms_return_string = string.Empty;
                if (retstr[0] == "1")
                {
                    model.Sms_status = true;
                    Sms_return_string = "true";
                }
                else
                {
                    model.Sms_status = false;

                    if (retstr[0] != "1")
                    {
                        string[] erridarr = retstr[1].Split('=');
                        int errid = 0;
                        if (erridarr.Length > 1 && erridarr[1] != null && erridarr[1] != "")
                        {
                            errid = int.Parse(erridarr[1]);
                        }
                        else
                        {
                            errid = 0;
                        }

                        switch (errid)
                        {
                            #region 判断提示

                            case 0:
                                Sms_return_string = "系统原因失败";
                                break;
                            case -1:
                                Sms_return_string = "用户不存在或已禁用";
                                break;
                            case -2:
                                Sms_return_string = "hashcode或密码不正确";
                                break;
                            case -3:
                                Sms_return_string = "接收号码不正确";
                                break;
                            case -4:
                                Sms_return_string = "内容为空或超长";
                                break;
                            case -5:
                                Sms_return_string = "";
                                break;
                            case -6:
                                Sms_return_string = "内容含非法字符";
                                break;
                            case -7:
                                Sms_return_string = "帐户余额不足";
                                break;
                            case -8:
                                Sms_return_string = "当天小批次限额不足";
                                break;
                            case -9:
                                Sms_return_string = "提交过于频繁,超过1分钟内限定的流量";
                                break;
                            case -10:
                                Sms_return_string = "未添加通道签名";
                                break;
                            default:
                                Sms_return_string = "";
                                break;
                            #endregion
                        }

                    }

                }
                #endregion
                context.Response.Write(Sms_return_string);
            }
            else
                context.Response.Write(false);
        }
        /// <summary>
        /// 消费用户发送注册激活吗短信
        /// </summary>
        /// <param name="context"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string SendSmsCustomerActive(HttpContext context, string value)
        {
            string mobile = context.Request["m"].ToString();
            EnCustomer chkU = ECCustomer.GetCustomer(string.Format(" where unametype=1 and uname='{0}'", mobile));
            if (chkU == null)
            {
                if (mobile != "")
                {
                    Random rnd = new Random();
                    string rndCode = rnd.Next(100000, 999999).ToString();

                    EnCustomerActive enCA = new EnCustomerActive();
                    enCA.ACode = rndCode;
                    enCA.CreateTime = DateTime.Now;
                    enCA.AType = 1;
                    enCA.AStatus = 1;
                    enCA.AText = mobile;

                    #region 发送验证码
                    EnSms model = new EnSms();
                    model.Sms_content = "【家具快搜】 亲爱的用户，您的注册激活码是【" + rndCode + "】！";
                    string returnstr = MessageSend.MessageSendInfo(MessageSend.action, mobile, model.Sms_content, rndCode, "");

                    string[] retstr = returnstr.Split('&');

                    model.Sms_phone = mobile;
                    model.Sms_send_time = DateTime.Now;
                    string Sms_return_string = string.Empty;
                    if (retstr[0] == "1")
                    {
                        model.Sms_status = true;
                        Sms_return_string = "true";
                    }
                    else
                    {
                        model.Sms_status = false;
                    }
                    #endregion

                    int rs = ECCustomerActive.EditCustomer(enCA);
                    return rs.ToString();
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "-1";
            }
        }

        public string sendSmsMemberActive(HttpContext context, string value)
        {
            string phone = context.Request["m"];
            string where="  WHERE mobile='"+phone+"' ";
            EnMember _member = ECMember.GetMemberInfo(where);

            if (_member == null)
            {

                Random rnd = new Random();
                string rndCode = rnd.Next(100000, 999999).ToString();

                EnCustomerActive enCA = new EnCustomerActive();
                enCA.ACode = rndCode;
                enCA.CreateTime = DateTime.Now;
                enCA.AType = 1;
                enCA.AStatus = 1;
                enCA.AText = phone;

                #region 发送验证码
                EnSms model = new EnSms();
                model.Sms_content = "【家具快搜】 亲爱的用户，您的注册激活码是【" + rndCode + "】！";
                string returnstr = MessageSend.MessageSendInfo(MessageSend.action, phone, model.Sms_content, rndCode, "");

                string[] retstr = returnstr.Split('&');

                model.Sms_phone = phone;
                model.Sms_send_time = DateTime.Now;
                string Sms_return_string = string.Empty;
                if (retstr[0] == "1")
                {
                    model.Sms_status = true;
                    Sms_return_string = "true";
                }
                else
                {
                    model.Sms_status = false;
                }
                #endregion

                int rs = ECCustomerActive.EditCustomer(enCA);
                return rs.ToString();
            }
            else
            {
              return "-1";
            }
        }
        /// <summary>
        /// 检查用户名
        /// </summary>
        /// <param name="context"></param>
        /// <param name="value">1检查手机 2 检查mail</param>
        /// <returns></returns>
        public string ChkCustomerName(HttpContext context, string value)
        {
            string mobile = context.Request["m"].ToString();
            EnCustomer models = ECCustomer.GetCustomer(string.Format(" where unametype={0} and uname='{1}'", value, mobile));
            if (models == null)
            {
                return "0";
            }
            else
            {
                return models.Id.ToString();
            }
        }
        /// <summary>
        /// 消费用户登录
        /// </summary>
        /// <param name="context"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string CustomerLogin(HttpContext context, string value)
        {
            string uname = context.Request["n"].ToString();
            string upwd = MyMD5.GetMD5(context.Request["p"].ToString());
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
                    return "-1"; //未激活
                }
                else
                {
                    #region 登录cookies
                    string customerTicketData = model.Id + "|" + model.UName + "|" + MyMD5.GetMD5(model.UPassword);
                    //加密存储cookie
                    System.Web.Security.FormsAuthenticationTicket Ticket = new System.Web.Security.FormsAuthenticationTicket(1, "CustomerTicket", DateTime.Now, DateTime.Now.AddDays(30), false, customerTicketData);
                    customerTicketData = System.Web.Security.FormsAuthentication.Encrypt(Ticket);
                    HttpCookie customerCookie = new HttpCookie("CustomerInfo", customerTicketData);
                    customerCookie.Expires = Ticket.Expiration;
                    HttpContext.Current.Response.AppendCookie(customerCookie);
                    #endregion

                    return "1"; //成功
                }
            }
            else
            {
                return "0"; //登录失败
            }
        }


        /// <summary>
        /// 消费用户找回密码
        /// </summary>
        /// <param name="context"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string SendFindPwd(HttpContext context, string value)
        {
            string utype = context.Request["t"].ToString();
            string mtxt = context.Request["m"].ToString();
            // 3 手机
            if (utype == "3")
            {
                EnCustomer models = ECCustomer.GetCustomer(string.Format(" where unametype=1 and uname='{0}'", mtxt));
                if (models != null)
                {
                    EnCustomerActive enCA = ECCustomerActive.GetCustomerActive(string.Format(" where atype=3 and astatus=1 and atext='{0}'", mtxt));
                    if (enCA == null)
                    {
                        enCA = new EnCustomerActive();
                        enCA.Id = 0;
                    }
                    Random rnd = new Random();
                    string rndCode = rnd.Next(100000, 999999).ToString();

                    enCA.ACode = rndCode;
                    enCA.AStatus = 1;
                    enCA.AType = 3;
                    enCA.AText = models.UName;
                    ECCustomerActive.EditCustomer(enCA);

                    #region 发送验证码
                    EnSms model = new EnSms();
                    model.Sms_content = "【家具快搜】 亲爱的用户，您的注册激活码是【" + rndCode + "】！";
                    string returnstr = MessageSend.MessageSendInfo(MessageSend.action, models.UName, model.Sms_content, rndCode, "");

                    string[] retstr = returnstr.Split('&');

                    model.Sms_phone = models.UName;
                    model.Sms_send_time = DateTime.Now;
                    string Sms_return_string = string.Empty;
                    if (retstr[0] == "1")
                    {
                        model.Sms_status = true;
                        Sms_return_string = "true";
                    }
                    else
                    {
                        model.Sms_status = false;
                    }
                    #endregion

                    return "1";
                }
                else
                {
                    //手机用户名不存在
                    return "-31";
                }
            }
            else if (utype == "4")
            {
                // 4 邮件
                EnCustomer models = ECCustomer.GetCustomer(string.Format(" where unametype=2 and uname='{0}'", mtxt));
                if (models != null)
                {
                    EnCustomerActive enCA = ECCustomerActive.GetCustomerActive(string.Format(" where atype=4 and astatus=1 and atext='{0}'", mtxt));
                    if (enCA == null)
                    {
                        enCA = new EnCustomerActive();
                        enCA.Id = 0;
                    }
                    Random rnd = new Random();
                    string rndCode = rnd.Next(10000000, 99999999).ToString();
                    enCA.ACode = rndCode;
                    enCA.AStatus = 1;
                    enCA.AType = 4;
                    enCA.AText = models.UName;
                    ECCustomerActive.EditCustomer(enCA);

                    #region 发送激活邮件

                    string mailsubject = string.Format(@"
                        <p>尊敬的 {0}</p>
                        <p>您的找回密码的动态码是。</p>
                        <p>{1}</p>
                        <p>上海渡福实业有限公司</p>
                        <p>网站地址：<a href='http://www.jiajuks.com' target='_blank'>www.jiajuks.com</a></p>
                        <p>客服邮箱：{2}</p>", models.UName, rndCode, EmailHelper._SendEmail);

                    bool rsmail = EmailHelper.SendEmail("家具快搜 邮件找回密码", models.UName, mailsubject);

                    #endregion

                    return "1";
                }
                else
                {
                    //邮件 用户名不存在
                    return "-41";
                }
            }
            else
            {
                //类型错误
                return "-1";

            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}