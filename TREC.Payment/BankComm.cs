using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Xml;
using TREC.Config;

namespace TREC.Payment
{

    /// <summary>
    /// 交通银行支付方式
    /// Add :rafer
    /// Date:20120620
    /// </summary>
    public class BankComm
    {
        #region 参数
        /// <summary>
        /// Socket的IP地址
        /// </summary>
        private string ip = WebConfigs.GetConfig().Jtip;
        /// <summary>
        /// Socket的端口地址
        /// </summary>
        private int port = Convert.ToInt32(WebConfigs.GetConfig().JHost);
        /// <summary>
        /// 
        /// </summary>
        private string tranCode = "cb2200_sign";
        /// <summary>
        /// 表单提交模版
        /// </summary>
        private string Template = @"<form name='form1' method='post' action ='{0}' target='_blank' >
                                        <input type = 'hidden' name = 'interfaceVersion' value = '{1}'/>
			                            <input type = 'hidden' name = 'merID' value = '{2}'/>
			                            <input type = 'hidden' name = 'orderid' value = '{3}'/>
			                            <input type = 'hidden' name = 'orderDate' value = '{4}'/>
			                            <input type = 'hidden' name = 'orderTime' value = '{5}'/>
			                            <input type = 'hidden' name = 'tranType' value = '{6}'/>
			                            <input type = 'hidden' name = 'amount' value = '{7}'/>
			                            <input type = 'hidden' name = 'curType' value = '{8}'/>
			                            <input type = 'hidden' name = 'orderContent' value = '{9}'/>
			                            <input type = 'hidden' name = 'orderMono' value = '{10}'/>
			                            <input type = 'hidden' name = 'phdFlag' value = '{11}'/>
			                            <input type = 'hidden' name = 'notifyType' value = '{12}'/>
			                            <input type = 'hidden' name = 'merURL' value = '{13}'/>
			                            <input type = 'hidden' name = 'goodsURL' value = '{14}'/>
			                            <input type = 'hidden' name = 'jumpSeconds' value = '{15}'/>
			                            <input type = 'hidden' name = 'payBatchNo' value = '{16}'/>
			                            <input type = 'hidden' name = 'proxyMerName' value = '{17}'/>
			                            <input type = 'hidden' name = 'proxyMerType' value = '{18}'/>
			                            <input type = 'hidden' name = 'proxyMerCredentials' value = '{19}'/>
			                            <input type = 'hidden' name = 'netType' value = '{20}'/>
			                            <input type = 'hidden' name = 'merSignMsg' value = '{21}'/>
			                            <input type = 'hidden' name = 'issBankNo' value = '{22}'/>
                                        <input type='submit' value='交通银行在线支付' name='JT_Bank'>
                                    </form>";
        /// <summary>
        /// 商户号
        /// def:301310063009501
        /// </summary>
        private string merID = "301310073759501";
        /// <summary>
        /// 消息版本号*,
        /// def:1.0.0.0
        /// </summary>
        private string interfaceVersion = "1.0.0.0";// Request.Params.Get("interfaceVersion");
        /// <summary>
        ///订单号*
        /// </summary>
        private string orderid = "";//Request.Params.Get("orderid");
        /// <summary>
        /// 商户订单日期*
        /// def：yyyyMMdd
        /// </summary>
        private string orderDate = "";//Request.Params.Get("orderDate");
        /// <summary>
        /// 商户订单时间*
        /// def：HHmmss
        /// </summary>
        private string orderTime = "";//Request.Params.Get("orderTime");
        /// <summary>
        /// 交易类别*
        /// def：0:B2C
        /// </summary>
        private string tranType = "";//Request.Params.Get("tranType");
        /// <summary>
        /// 订单金额*
        /// </summary>
        private string amount = "";//Request.Params.Get("amount");
        /// <summary>
        /// 交易币种*
        /// def:CNY
        /// </summary>
        private string curType = "CNY";//Request.Params.Get("curType");
        /// <summary>
        /// 订单内容
        /// </summary>
        private string orderContent = "";//Request.Params.Get("orderContent");
        /// <summary>
        /// 商家备注
        /// </summary>
        private string orderMono = "";//Request.Params.Get("orderMono");
        /// <summary>
        /// 物流配送标志
        /// </summary>
        private string phdFlag = "";//Request.Params.Get("phdFlag");
        /// <summary>
        /// 通知方式*
        /// def:0 不通知 1 通知 2 抓取页面
        /// </summary>
        private string notifyType = "0";//Request.Params.Get("notifyType");
        /// <summary>
        /// 主动通知URL
        /// </summary>
        private string merURL = "";//Request.Params.Get("merURL");
        /// <summary>
        /// 取货URL
        /// </summary>
        private string goodsURL = "";//Request.Params.Get("goodsURL");
        /// <summary>
        /// 自动跳转时间
        /// def:（秒）
        /// </summary>
        private string jumpSeconds = "";//Request.Params.Get("jumpSeconds");
        /// <summary>
        /// 商户批次号
        /// def:商家对账使用
        /// </summary>
        private string payBatchNo = "";//Request.Params.Get("payBatchNo");
        /// <summary>
        /// 代理商家名称
        /// </summary>
        private string proxyMerName = "";//Request.Params.Get("proxyMername");
        /// <summary>
        /// 代理商家类型
        /// </summary>
        private string proxyMerType = "";//Request.Params.Get("proxyMerType");
        /// <summary>
        /// 代理商家证件号码
        /// </summary>
        private string proxyMercredentials = "";//Request.Params.Get("proxyMercredentials");
        /// <summary>
        /// 渠道编号*
        /// def:0:html渠道 
        /// </summary>
        private string netType = "";//Request.Params.Get("netType");
        /// <summary>
        /// 发卡行行号
        /// def:不输默认为交行
        /// </summary>
        private string issBankNo = "";//Request.Params.Get("issBankNo"); //不参与签名，规则同银联 
        #endregion

        /// <summary>
        /// 订单支付提交
        /// </summary>
        /// <param name="ordercode">订单号</param>
        /// <param name="price">金额</param>
        /// <param name="types">类型</param>
        /// <returns></returns>
        public string GetBankCommPayment(string ordercode,string _orderDate,string _orderTime, decimal price, string types, string _issBankNo)
        {
            //string temp = "";
            StringBuilder sb = new StringBuilder();
            //参数赋值   GO


            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            int hours = DateTime.Now.Hour;
            int minutes = DateTime.Now.Minute;
            int seconds = DateTime.Now.Second;

            string _month = ((month < 10) ? "0" : "") + month.ToString();
            string _day = ((day < 10) ? "0" : "") + day.ToString();
            string _hours = ((hours < 10) ? "0" : "") + hours.ToString();
            string _minutes = ((minutes < 10) ? "0" : "") + minutes.ToString();
            string _seconds = ((seconds < 10) ? "0" : "") + seconds.ToString();

            //document.all.orderid.value = year + month + day + hours + minutes + seconds;
            //document.all.orderDate.value = year + month + day;
            //document.all.orderTime.value = hours + minutes + seconds;
            orderid = "JT" + (year - 1900).ToString() + _month + _day + _hours + _minutes + _seconds;
            orderDate = year.ToString() + _month + _day;
            orderTime = _hours + _minutes + _seconds;
            tranType = "0";
            amount = price.ToString();
            curType = "CNY";
            orderContent = "";
            orderMono = "";
            phdFlag = "";
            notifyType = "1";
            merURL = WebConfigs.GetConfig().WebSupplerUrl + "/BankUrl/Merchant_result.aspx";
            goodsURL = "";
            jumpSeconds = "3";
            payBatchNo = "";
            proxyMerName = "";
            proxyMerType = "";
            proxyMercredentials = "";
            netType = "0";
            issBankNo = _issBankNo;

            string sourceMsg = interfaceVersion + "|" + merID + "|" + orderid + "|" + orderDate + "|" + orderTime + "|" + tranType + "|" + amount + "|" + curType + "|" +
                orderContent + "|" + orderMono + "|" + phdFlag + "|" + notifyType + "|" + merURL + "|" + goodsURL + "|" + jumpSeconds + "|" +
                payBatchNo + "|" + proxyMerName + "|" + proxyMerType + "|" + proxyMercredentials + "|" + netType;

            StringBuilder sendMsg = new StringBuilder("");
            //组织申请报文
            sendMsg.Append("<Message>")
                   .Append("<TranCode>").Append(tranCode).Append("</TranCode>")
                   .Append("<MsgContent>")
                   .Append(sourceMsg)
                   .Append("</MsgContent></Message>");
            //return sendMsg.ToString();
            TcpClient client = new TcpClient(ip, port);
            NetworkStream stream = client.GetStream();
            Byte[] data = System.Text.Encoding.UTF8.GetBytes(sendMsg.ToString());
            stream.Write(data, 0, data.Length);
            data = new Byte[50 * 1024];
            String responseData = String.Empty;
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
            stream.Close();
            client.Close();
            //return sendMsg.ToString() + "<br/><br/><br/>" + responseData;
            //解析返回报文
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(responseData);
            XmlNodeList list = xmlDoc.GetElementsByTagName("retCode");
            string retCode = list.Item(0).InnerText.Trim();

            list = xmlDoc.GetElementsByTagName("errMsg");
            string errMsg = list.Item(0).InnerText.Trim();

            list = xmlDoc.GetElementsByTagName("signMsg");
            string signMsg = list.Item(0).InnerText.Trim();
            //return signMsg;
            list = xmlDoc.GetElementsByTagName("orderUrl");
            string orderUrl = list.Item(0).InnerText.Trim();
            if (!retCode.Equals("0"))
            {
                sb.Append(retCode + "|-|" + errMsg);
            }
            else
            {
                //temp = string.Format(Template, orderUrl, interfaceVersion, merID, orderid, orderDate, orderTime, tranType, amount, curType, orderContent, orderMono, phdFlag, notifyType, merURL, goodsURL, jumpSeconds, payBatchNo, proxyMerName, proxyMerType, proxyMercredentials, netType, signMsg, issBankNo);
                sb.Append("<form name=\"form1\" method=\"post\" action =\"" + orderUrl + "\" target=\"_blank\" >");
                sb.Append("<input type = \"hidden\" name = \"interfaceVersion\" value = \"" + interfaceVersion + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"merID\" value = \"" + merID + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"orderid\" value = \"" + orderid + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"orderDate\" value = \"" + orderDate + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"orderTime\" value =\"" + orderTime + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"tranType\" value = \"" + tranType + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"amount\" value = \"" + amount + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"curType\" value = \"" + curType + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"orderContent\" value = \"" + orderContent + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"orderMono\" value = \"" + orderMono + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"phdFlag\" value = \"" + phdFlag + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"notifyType\" value = \"" + notifyType + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"merURL\" value = \"" + merURL + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"goodsURL\" value = \"" + goodsURL + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"jumpSeconds\" value = \"" + jumpSeconds + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"payBatchNo\" value = \"" + payBatchNo + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"proxyMerName\" value = \"" + proxyMerName + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"proxyMerType\" value =\"" + proxyMerType + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"proxyMerCredentials\" value = \"" + proxyMercredentials + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"netType\" value = \"" + netType + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"merSignMsg\" value = \"" + signMsg + "\"/>");
                sb.Append("<input type = \"hidden\" name = \"issBankNo\" value = \"" + issBankNo + "\"/>");
                sb.Append("</form>");
            }
            return sb.ToString();
        }


    }
}
