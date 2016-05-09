using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Entity;
using System.Text;

namespace TREC.Web.Suppler.ajax
{
    public partial class CliqueCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String title=Request["title"];
            EnMarketClique model = null;
            model = ECommerce.ECMarketClique.GetMarketCliqueByWhere("WHERE REPLACE(title,'集团','')='" + title.Replace("集团", "") + "' ");
            StringBuilder _value = new StringBuilder(string.Empty);
            if (model == null)
            {
                _value.Append("{\"msg\":\"1\"}");//集团名没有重复，可以使用
            }
            else
            {
                if (model.MarketId ==0 && model.CreateMid>0)
                {
                    _value.Append("{\"msg\":\"0\"}");//集团名重复，不可以使用
                }
                else if (model.MarketId > 0 && model.CreateMid == 0) //卖场建了集团信息，展示出信息
                {
                    _value.Append("{\"msg\":\"2\",\"chairman\":\"" + model.Chairman + "\",\"chairmanoration\":\"" + model.ChairmanOration + "\",\"descript\":\"" + model.Descript.Replace("\"", "'") + "\",\"logimg\":\"" + model.LogImg + "\",\"chairmanimg\":\"" + model.ChairmanImg + "\",\"thumbimg\":\"" + model.ThumbImg + "\",\"infoimg\":\"" + model.InfoImg + "\",\"phone\":\""+model.Phone+"\",\"address\":\""+model.Address+"\"}");
                }
            }

            if (string.IsNullOrEmpty(_value.ToString()))
            {
                _value.Append("{\"msg\":\"1\"}");
            }
           
            Response.Write(_value.ToString());
        }
    }
}