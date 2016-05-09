<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.BankUrl.Merchant_result" %>

<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="System.Net.Sockets" %>
<%@ Import Namespace="System.Xml" %>
<%@ Import Namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
</head>
<body>
     <%
      
        string tranCode = "cb2200_verify";
        string notifyMsg = Request.Params.Get("notifyMsg");

        //string realPath = Server.MapPath("Message.txt");
        //FileStream fsWriter = null;
        //if (!File.Exists(realPath))
        //{
        //    fsWriter = new FileStream(realPath, FileMode.Create);
        //}
        //else
        //{
        //    fsWriter = new FileStream(realPath, FileMode.Append);
        //}
        //StreamWriter sw = new StreamWriter(fsWriter);

        StringBuilder sendMsg = new StringBuilder("");
        //sendMsg.Append("<?xml version='1.0' encoding='UTF-8'?>")
        //组织申请报文
        sendMsg.Append("<Message>")
               .Append("<TranCode>").Append(tranCode).Append("</TranCode>")
               .Append("<MsgContent>")
               .Append(notifyMsg)
               .Append("</MsgContent></Message>");

        TcpClient client = new TcpClient(TREC.Config.WebConfigs.GetConfig().Jtip, Convert.ToInt32(TREC.Config.WebConfigs.GetConfig().JHost));
        NetworkStream stream = client.GetStream();

        Byte[] data = System.Text.Encoding.UTF8.GetBytes(sendMsg.ToString());
        stream.Write(data, 0, data.Length);
        data = new Byte[50 * 1024];
        String responseData = String.Empty;
        Int32 bytes = stream.Read(data, 0, data.Length);
        responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
        stream.Close();
        client.Close();

        //解析返回报文
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(responseData);
        XmlNodeList list = xmlDoc.GetElementsByTagName("retCode");
        string retCode = list.Item(0).InnerText.Trim();
        list = xmlDoc.GetElementsByTagName("errMsg");
        string errMsg = list.Item(0).InnerText.Trim();

        if (!retCode.Equals("0"))
        {
            //sw.WriteLine("");
            //sw.WriteLine("");
            //sw.WriteLine("");
            //sw.WriteLine("-------------------支付失败-------------------");
            //sw.WriteLine("日期:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //sw.WriteLine("交易返回码：" + retCode);
            //sw.WriteLine("交易错误信息：" + errMsg);
        }
        else
        {
            string[] strs = notifyMsg.Split('|');
            //sw.WriteLine("");
            //sw.WriteLine("");
            //sw.WriteLine("");
            //sw.WriteLine("-------------------支付成功-------------------");
            //sw.WriteLine("日期:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //sw.WriteLine("商户客户号:" + strs[0]);
            //sw.WriteLine("订单编号:" + strs[1]);
            //sw.WriteLine("交易金额:" + strs[2]);
            //sw.WriteLine("交易币种:" + strs[3]);
            //sw.WriteLine("平台批次号:" + strs[4]);
            //sw.WriteLine("商户批次号:" + strs[5]);
            //sw.WriteLine("交易日期:" + strs[6]);
            //sw.WriteLine("交易时间:" + strs[7]);
            //sw.WriteLine("交易流水号:" + strs[8]);
            //sw.WriteLine("交易结果:" + strs[9]);
            //sw.WriteLine("手续费总额:" + strs[10]);
            //sw.WriteLine("银行卡类型:" + strs[11]);
            //sw.WriteLine("银行备注:" + strs[12]);
            //sw.WriteLine("错误信息描述:" + strs[13]);
            //sw.WriteLine("IP:" + strs[14]);
            //sw.WriteLine("Referer:" + strs[15]);
            //sw.WriteLine("商户备注(base64编码的字符串，如需要返回的需要base64解码原文):" + strs[16]);
            //处理交易记录
            EnPayMent model = new EnPayMent();
            model = ECPayMent.GetPayMent(" where OrderCode='" + strs[1] + "' and Price=" + strs[2]);
            if (ECPayMent.InsertPayMentLog(model) > 0)
            {
                ECPayMent.DeletePayMent(" where OrderCode='" + strs[1] + "' and Price=" + strs[2]);
            }


            EnMember _member = ECMember.GetMemberInfo(" Where id=" + model.Mid);
            if (_member != null)
            {
                //修改客户充值状态
                EnMember Member = new EnMember();
                Member.overprice = 0;
                Member.useprice =Convert.ToDecimal(strs[2]);
                Member.Isrecharge = true;
                Member.RegStatcTime = DateTime.Now;
                Member.id = _member.id;
                if (_member.VipLevel == 0)
                { Member.VipLevel = 1; }
                else
                { Member.VipLevel = _member.VipLevel; }
                DateTime RegEndTime = _member.RegEndTime;
                DateTime DateNow = DateTime.Now;
                TimeSpan ts1 = new TimeSpan(DateNow.Ticks);
                TimeSpan ts2 = new TimeSpan(RegEndTime.Ticks);
                if (RegEndTime > DateNow)
                {
                    Member.RegEndTime = RegEndTime.AddMonths(model.Types);
                }
                else
                {
                    Member.RegEndTime = DateNow.AddMonths(model.Types);
                }

                ECMember.ModifyMenber(Member);
            }

           
        }
        //sw.Close();
        //fsWriter.Close();
    %>
</body>
</html>
