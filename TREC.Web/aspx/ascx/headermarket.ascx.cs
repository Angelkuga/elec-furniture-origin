using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using System.Collections;

namespace TREC.Web.aspx.ascx
{
    public class headermarket : System.Web.UI.UserControl
    {
        public Hashtable _htb = new Hashtable();//数据统计
        protected string _marketid = "";
        public string _marketcliqueid = "0"; //卖场集团ID
        public string cid = "0";
        public string address = string.Empty;
        public string phone = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            _htb = ECProduct.GetIndexCount().FirstOrDefault();
            _marketid = ECommon.QueryMid;

            if (_marketid != "")
            {
                EnMarket _marketinfor = ECMarket.GetMarketInfo(" where id=" + _marketid);
                EnMarketClique model = ECommerce.ECMarketClique.GetMarketCliqueByWhere(" where title='" + _marketinfor.MarketCliqueName + "'");
                if (model != null && model.Auditstatus == 1)
                {
                    try
                    {
                        //市辖区
                        string areaname = TREC.ECommerce.ECommon.getAreaAll(_marketinfor.areacode);
                        if (string.IsNullOrEmpty(areaname)) { areaname = " "; }
                        _marketcliqueid = model.Id.ToString();
                        if (!string.IsNullOrEmpty(_marketinfor.address))
                        {
                            address = areaname.Replace("市辖区", "") + _marketinfor.address.Replace(" ", "").Replace(areaname, "").Replace("市辖区", "");
                        }

                        if (!string.IsNullOrEmpty(_marketinfor.lphone))
                        {
                            phone =  _marketinfor.lphone;
                        }
                        else if (!string.IsNullOrEmpty(_marketinfor.zphone))
                        {
                            phone = _marketinfor.zphone;
                        }
                        else if (!string.IsNullOrEmpty(_marketinfor.fax))
                        {
                            phone =  _marketinfor.fax;
                        }
                        else if (!string.IsNullOrEmpty(_marketinfor.mphone))
                        {
                            phone =  _marketinfor.mphone;
                        }
                       else if (!string.IsNullOrEmpty(_marketinfor.phone))
                        {
                            phone = _marketinfor.phone;
                        }
                    }
                    catch
                    { 
                    }
                }
            }
        }
    }
}