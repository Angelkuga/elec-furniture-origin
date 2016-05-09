using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Entity;
using TREC.ECommerce;

namespace TREC.Web
{
    public partial class addBaoMing : WebPageBase
    {
        protected int _counts = 374;

        public int brandid
        {
            get
            {
                if (Request["brandid"] != null)
                {
                    return SubmitMeth.getInt(Request["brandid"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        public string brandname
        {
            get
            {
                if (Request["brandname"] != null)
                {
                    return Request["brandname"].Trim();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public int number
        {
            get
            {
                if (Request["number"] != null)
                {
                    return SubmitMeth.getInt(Request["number"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["Ptitle"] != null)
                {
                    prodTitle.Value = Server.UrlDecode(Request["Ptitle"]);
                }

                try
                {
                    if (prodID.Value != "")
                    {
                        int pdcon = 1;
                        if (prodCon.Value == "2")
                        {
                            pdcon = 2;
                        }
                        _counts = ECMsgCollection.GetMsgCollectionCount(string.Format(" where prodID={0} and prodCon={1}", prodID.Value, pdcon));
                    }
                }
                catch
                {
 
                }

                if (number > 0)
                {
                    _counts = number;
                }
            }

           
            //if (!Page.IsPostBack)
            //{
            //    prodID.Value = Request["Pid"];
            //    prodTitle.Value = Server.UrlDecode(Request["Ptitle"]);
            //    uneedProduct.Text = Server.UrlDecode(Request["Ptitle"]);
            //    prodURL.Value = Request["Purl"];
            //    prodCon.Value = Request["prodcon"];
            //    if (TRECommon.CookiesHelper.GetCookieCustomer("cid") != "")
            //    {
            //        uid.Value = TRECommon.CookiesHelper.GetCookieCustomer("cid");
            //        //EnMember members = ECMember.GetMemberInfo(" where id=" + uid.Value);
            //        //if (members != null)
            //        //{
            //        //    umobile.Text = members.mobile;
            //        //    uname.Text = members.username;
            //        //}
            //    }
            //if (prodID.Value != "")
            //{
            //    int pdcon = 1;
            //    if (prodCon.Value == "2")
            //    {
            //        pdcon = 2;
            //    }
            //    _counts = ECMsgCollection.GetMsgCollectionCount(string.Format(" where prodID={0} and prodCon={1}", prodID.Value, pdcon));
            //}
            //}
        }
        private void sendMail(string content, string mail)
        {
            string mailsubject = content;

            bool rsmail = EmailHelper.SendEmail("意向报名用户信息", mail, mailsubject);
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            EnMsgCollection MCmodel = new EnMsgCollection();
            Random rnd = new Random();
            string rndCode = rnd.Next(100000, 999999).ToString();

            MCmodel.Id = 0;
            MCmodel.Name = uname.Text;
            MCmodel.Contact = umobile.Text;
            MCmodel.CreateTime = DateTime.Now;
            MCmodel.Code = rndCode;
            MCmodel.UserAddress = uaddress.Text;
            MCmodel.MsgInfo = uneedProduct.Text;
            MCmodel.BrandId = brandid;
            MCmodel.BrandName = brandname;
           // MCmodel.ProdCon = int.Parse(prodCon.Value);
            MCmodel.ProdCon = 0;
            if (string.IsNullOrEmpty(MCmodel.Name))
            {
                Response.Write("<script>alert('姓名必须填写 !');windwo.histroy.go(-1);</script>"); Response.End();
            }
            if (string.IsNullOrEmpty(MCmodel.Contact))
            {
                Response.Write("<script>alert('手机必须填写 !');windwo.histroy.go(-1);</script>"); Response.End();
            }
            if (string.IsNullOrEmpty(MCmodel.UserAddress))
            {
                Response.Write("<script>alert('地址必须填写 !');windwo.histroy.go(-1);</script>"); Response.End();
            }
            if (prodCon.Value == "2")
            {
                MCmodel.ProdCon = 2;
            }
            if (!string.IsNullOrEmpty(prodID.Value))
            {
                MCmodel.ProdID = int.Parse(prodID.Value);
            }
            if (!string.IsNullOrEmpty(uid.Value))
            {
                MCmodel.MID = int.Parse(uid.Value);
            }

            if (brandid > 0)
            {
                string Description = "品牌ID" + brandid + ",品牌名称：" + brandname + "用户手机号码：" + MCmodel.Contact;
                sendMail(Description, "angela@jiajuks.com");
                sendMail(Description, "liujing@jiajuks.com");
            }
            //EnMsgCollection ckMC = ECMsgCollection.GetMsgCollectionInfo(string.Format(" where mid={0} and prodID={1} and prodCon={2}", MCmodel.MID, MCmodel.ProdID, MCmodel.ProdCon));
            //if (ckMC != null)
            //{
            //    Response.Write("<script>alert('您已预订过此产品');window.parent.funclose('divsj');</script>");
            //    Response.End();
            //}
            int id = ECMsgCollection.ModifyMsgCollection(MCmodel);
            #region  发送短信
            EnSms model = new EnSms();
            model.Sms_content = "【家具快搜】 亲爱的用户，恭喜您，您已成功提交抢购【" + prodTitle.Value + "】预订，请牢记您的验证码为：" + rndCode + "，谢谢！";
            string returnstr = MessageSend.MessageSendInfo(MessageSend.action, umobile.Text.Trim(), model.Sms_content, rndCode, "");

            string[] retstr = returnstr.Split('&');

            model.Sms_phone = umobile.Text.Trim();
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

            string msgbrand = string.Empty;
            if (brandid > 0)
            {
                msgbrand = "window.parent.funchangeprice();";
            }
            Response.Write("<script>" + msgbrand + "alert('报名提交完成');window.parent.funclose('divsj');</script>");
            Response.End();
        }
    }
}