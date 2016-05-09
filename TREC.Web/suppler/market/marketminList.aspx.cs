using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;
namespace TREC.Web.Suppler.market
{
    public partial class marketminList : SupplerPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        public string Opertxt(string auditstatus, string createmid,string id)
        {
            if (createmid == memberInfo.id.ToString())
            {
                return "<a href='marketminInfor.aspx?id=" + id + "' style='color:#947800;'>编辑</a>";
            }
            else if (auditstatus == "1")
            {
                return "<a href='/market/" + id + "/index.aspx' target='_blank'>查看卖场</a> ";
            }
            else
            {
                return "<span style='color:red;'>" + EnumAuditStatus.待审核 + "</span>";
            }
        }
        protected void ShowData()
        {
            EnMarketClique model = ECommerce.ECMarketClique.GetMarketCliqueByMid(memberInfo.id);
            if (model != null)
            {
                List<EnMarket> _listMarket = ECMarket.GetMarketList(" MarketCliqueName='" + model.Title.Replace("集团", "") + "'");
                rptList.DataSource = _listMarket; 
                rptList.DataBind();
                AspNetPager1.RecordCount = _listMarket.Count;
            }
            else
            {
                ScriptUtils.ShowAndRedirect("请完善集团信息!", "marketclique.aspx");
            }
           
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {

        }
    }
}