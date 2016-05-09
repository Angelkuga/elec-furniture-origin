using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using System.Text;

namespace TREC.Web.Suppler.ajax
{
    public partial class MarketCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string title = Request["title"].Trim();
            EnMarket _market = ECMarket.GetMarketList(" title='" + title.Replace("集团", "") + "'").FirstOrDefault();
            StringBuilder _value = new StringBuilder(string.Empty);

            if (_market == null)
            {
                _value.Append("{\"msg\":\"1\"}");//卖场名没有重复，可以使用
            }
            else
            {
                if (_market.mid > 0)
                {
                    _value.Append("{\"msg\":\"0\"}");//卖场名重复，不可以使用
                }
                else
                {
                    string droparea3 = string.Empty;
                    string droparea2 = string.Empty;

                    EnArea _area3 = new EnArea();
                    EnArea _area2 = new EnArea();
                    EnArea _area1 = new EnArea();
                    _area3 = ECArea.GetAreaList("areacode='" + _market.areacode + "'").FirstOrDefault();
                    _area2 = ECArea.GetAreaList("areacode='" + _area3.parentcode + "'").FirstOrDefault();
                    _area1 = ECArea.GetAreaList("areacode='" + _area2.parentcode + "'").FirstOrDefault();

                    foreach (EnArea en in ECArea.GetAreaList("parentcode='" + _area3.parentcode + "'"))
                    {
                        if (en.areacode != _area3.areacode)
                        {
                            droparea3 = droparea3 + "<option  value='" + en.areacode + "'>" + en.areaname + "</option>";
                        }
                        else
                        {
                            droparea3 = droparea3 + "<option selected='selected' value='" + en.areacode + "'>" + en.areaname + "</option>";
                        }
                    }

                    foreach (EnArea en in ECArea.GetAreaList("parentcode='" + _area2.parentcode + "'"))
                    {
                        if (en.areacode != _area2.areacode)
                        {
                            droparea2 = droparea2 + "<option  value='" + en.areacode + "'>" + en.areaname + "</option>";
                        }
                        else
                        {
                            droparea2 = droparea2 + "<option selected='selected' value='" + en.areacode + "'>" + en.areaname + "</option>";
                        }
                    }



                    _value.Append("{\"msg\":\"2\",\"address\":\"" + _market.address + "\",\"droparea3\":\"" + droparea3 + "\",\"droparea2\":\"" + droparea2 + "\",\"droparea1\":\"" + _area1.areacode + "\"}");//卖场已存在，为集团所加
                }
            }

            //if (!string.IsNullOrEmpty(_value.ToString()))
            //{
            //    _value.Append("{\"msg\":\"-1\"}");
            //}
            Response.Write(_value.ToString());
        }
    }
}