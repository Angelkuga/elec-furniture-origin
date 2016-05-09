using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Admin.sms
{
    public partial class smssend : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EnSms model = new EnSms();

            string strErr = "";
            if (this.txtphone.Text.Trim().Length == 0)
            {
                strErr += "发送号码不能为空！\\n";
            }

            if (this.txtcontent.Text.Trim().Length == 0)
            {
                strErr += "短信内容不能为空！\\n";
            }

            if (this.txtcontent.Text.Trim().Length > 250)
            {
                strErr += "短信内容不能大于250个字！\\n";
            }

            if (strErr != "")
            {
                return;
            }

            Random rd = new Random();
            long msid = rd.Next(1073741824, 2147483647);

            string returnstr = MessageSend.MessageSendInfo(MessageSend.action, this.txtphone.Text.Trim(), this.txtcontent.Text.Trim(), msid.ToString(), "");

            string[] retstr = returnstr.Split('&');

            model.Sms_content = txtcontent.Text.Trim();
            model.Sms_number_quantity = txtcontent.Text.Trim().Length % 67 > 0 ? (txtcontent.Text.Trim().Length / 67) + 1 : txtcontent.Text.Trim().Length / 67;
            model.Sms_phone = txtphone.Text.Trim();
            model.Sms_send_time = DateTime.Now;

            if (retstr[0] == "1")
            {
                model.Sms_status = true;
                model.Sms_return_string = "全部发送成功";
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
                        case 0:
                            model.Sms_return_string = "系统原因失败";
                            break;
                        case -1:
                            model.Sms_return_string = "用户不存在或已禁用";
                            break;
                        case -2:
                            model.Sms_return_string = "hashcode或密码不正确";
                            break;
                        case -3:
                            model.Sms_return_string = "接收号码不正确";
                            break;
                        case -4:
                            model.Sms_return_string = "内容为空或超长";
                            break;
                        case -5:
                            model.Sms_return_string = "";
                            break;
                        case -6:
                            model.Sms_return_string = "内容含非法字符";
                            break;
                        case -7:
                            model.Sms_return_string = "帐户余额不足";
                            break;
                        case -8:
                            model.Sms_return_string = "当天小批次限额不足";
                            break;
                        case -9:
                            model.Sms_return_string = "提交过于频繁,超过1分钟内限定的流量";
                            break;
                        case -10:
                            model.Sms_return_string = "未添加通道签名";
                            break;
                        default:
                            model.Sms_return_string = "";
                            break;
                    }
                }

            }
            if (retstr.Length > 3)
            {
                string[] fee = retstr[2].Split('=');
                if (fee.Length > 1 && fee[1] != null && fee[1] != "")
                {
                    model.Sms_return_number = int.Parse(fee[1]);
                }
                else
                {
                    model.Sms_return_number = 0;
                }

                string[] msgidarr = retstr[5].Split('=');
                if (msgidarr.Length > 1 && msgidarr[1] != null && msgidarr[1] != "")
                {
                    model.Sms_msgid = long.Parse(msgidarr[1]);
                }
                else
                {
                    model.Sms_msgid = 0;
                }

                string[] balancearr = retstr[3].Split('=');
                if (balancearr.Length > 1 && balancearr[1] != null && balancearr[1] != "")
                {
                    model.Sms_balance_money = int.Parse(balancearr[1]);
                }
                else
                {
                    model.Sms_balance_money = 0;
                }
            }

            int aid = TREC.ECommerce.ECSms.EditSms(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", "smslist.aspx", "Success");
            }



        }



    }

    


}