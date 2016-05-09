using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;
using System.Collections;

namespace TREC.Web.Admin.market
{
    public partial class marketcliqueinfo : AdminPageBase
    {
        public EnMember _memberInfo = null;
        public string _submarket = "";
        public int _mainmarketid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlauditstatus.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumAuditStatus), ddlauditstatus);
                ddlauditstatus.Items.Insert(0, new ListItem("请选择", ""));
                ShowData();
            }
        }


        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {

                EnMarketClique model = ECommerce.ECMarketClique.GetMarketCliqueById(int.Parse(ECommon.QueryId));
                if (model != null)
                {
                    if (model != null && model.CreateMid != 0)
                    {
                        _memberInfo = ECMember.GetMemberInfo(" where id=" + model.CreateMid);
                        if (_memberInfo != null && _memberInfo.id != 0)
                        {
                            this.ddlmember.Items.Clear();
                            this.ddlmember.Items.Insert(0, new ListItem(_memberInfo.username, model.CreateMid.ToString()));
                            this.ddlmember.Enabled = false;
                        }
                    }
                    txttitle.Text = model.Title;
                    txtchairman.Text = model.Chairman;
                    txtchairmanoration.Text = model.ChairmanOration;
                    txtdescript.Text = model.Descript;
                    hfchairmanimg.Value = model.ChairmanImg;
                    hfinfoimg.Value = model.InfoImg;
                    hfthumbimg.Value = model.ThumbImg;
                    txtlastedittime.Text = model.LastediTime.ToString();
                    ddlauditstatus.SelectedValue = model.Auditstatus.ToString();
                    txt_phone.Text = model.Phone;
                    txt_address.Text = model.Address;

                    string[] submarketArr = ECommerce.ECMarketClique.GetSubMarketByMarketCliqueId(model.Id);
                    string submarketIL = "";
                    foreach (string items in submarketArr)
                    {
                        submarketIL += items + ',';
                    }
                    _mainmarketid = model.MarketId;
                    _submarket = GetSubMarket(submarketIL.TrimEnd(','));
                }
            }
        }


        protected string GetSubMarket(string submarketidlist)
        {

            if (string.IsNullOrEmpty(submarketidlist))
                return "";
            //查询条件
            string Where = string.Format(" id in ({0}) ", submarketidlist);

            int currentPage = 1;

            #region 读取绑定数据

            //总记录数
            int Counts = 0;
            //每页显示记录数
            int pagequantity = 100;
            List<EnMarket> marketList = ECMarket.GetMarketList(currentPage, pagequantity, Where, out Counts);
            string back = "";
            if (marketList != null)
            {
                //总页数
                int PageCount = 0;
                //计算总页数
                if (Counts % pagequantity != 0)
                    PageCount = (Counts - Counts % pagequantity) / pagequantity + 1;
                else
                    PageCount = Counts / pagequantity;
                foreach (EnMarket model in marketList)
                {
                    back += "<label class=\"marketlist\"><a href=\"/admin/market/marketinfo.aspx?edit=1&id="+model.id+"\"  >" + model.title + "</a> <b>(" +
                    ((EnumAuditStatus)System.Enum.Parse(typeof(EnumAuditStatus), model.auditstatus.ToString())).ToString() + ")</b></label>";
                }
                marketList.Clear();
                marketList = null;
            #endregion

            }
            else
            {
                back = "no";
            }
            return back;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EnMarketClique model = null;
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECommerce.ECMarketClique.GetMarketCliqueById(int.Parse(ECommon.QueryId));
                if (model != null)
                {
                    model.Title = txttitle.Text;
                    model.Chairman = txtchairman.Text;
                    model.Phone = txt_phone.Text;
                    model.Address = txt_address.Text;
                    model.ChairmanOration = txtchairmanoration.Text;
                    model.Descript = txtdescript.Text;
                    model.Auditstatus = int.Parse(ddlauditstatus.SelectedValue);
                    model.LastediTime = DateTime.Now;
                    ECommerce.ECMarketClique.EditMarketClique(model);

                    Response.Write("<script>alert('操作完成');window.location.href='marketcliquelist.aspx';</script>");
                    Response.End();
                }
            }

        }
    }
}