using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Entity;
using TREC.ECommerce;
using TRECommon;
using Haojibiz;

namespace TREC.Web.Suppler.market
{
    public partial class marketstoryshopmanage : SupplerPageBase
    {
        public List<EnMarketStorey> mslist = new List<EnMarketStorey>();
        public int sid = -1;
        public int linestatus = -1;
        public int source = -1;


        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        public List<t_Pavilion> _listPav = new List<t_Pavilion>();

        public string getpavTitle(string pavid)
        {
            t_Pavilion _pav = new t_Pavilion();
            _pav = _listPav.Where(p => p.Id == SubmitMeth.getInt(pavid)).FirstOrDefault();
            if (_pav != null)
            {
                return _pav.Title;
            }
            else
            {
                return "无";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _listPav = EntityOper.t_Pavilion.ToList();
            Master.menuName = "marketstoryshopmanage";
            mslist = ECMarketStorey.GetMarketStoreyList(" marketid=" + marketInfo.id);
            if (!IsPostBack)
            {
                drop_Pavilion.DataSource = EntityOper.t_Pavilion.Where(p => p.Mid == SubmitMeth.getInt(CookiesHelper.GetCookie("mid"))).ToList();
                drop_Pavilion.DataTextField = "Title";
                drop_Pavilion.DataValueField = "id";
                drop_Pavilion.DataBind();

                ListItem _item = new ListItem();
                _item.Value = "-1";
                _item.Text = "--不限--";
                drop_Pavilion.Items.Insert(0, _item);

                if (Request.QueryString["sid"] != null)
                {
                    int.TryParse(Request.QueryString["sid"], out sid);
                }
                #region 绑定楼层
                List<EnMarketStorey> mmarketslist = ECMarketStorey.GetMarketStoreyList(" marketid=" + marketInfo.id);
                ddlmarketstory.DataSource = mmarketslist;
                ddlmarketstory.DataTextField = "title";
                ddlmarketstory.DataValueField = "id";
                ddlmarketstory.DataBind();
                ddlmarketstory.Items.Insert(0, new ListItem("楼层", ""));
                #endregion
                #region 绑定品牌
                List<EnMarketStoreyShop> msbrandList = ECMarketStoreyShop.GetMarketStoreyShopList(" marketid=" + marketInfo.id);
                foreach (var item in msbrandList)
                {
                    if (item.brandidlist != null && item.brandidlist != "" && item.brandtitlelist != null &&  item.brandtitlelist != "")
                    {
                        ddlbrand.Items.Add(new ListItem(item.brandtitlelist, item.brandidlist));
                    }
                }
                ddlbrand.Items.Insert(0,new ListItem("请选择",""));
                #endregion
               
                ShowData();
            }
            
        }

        protected void rptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DropDownList ddl = (DropDownList)e.Item.FindControl("ddlms") as DropDownList;
                ddl.DataSource = mslist;
                ddl.DataTextField = "title";
                ddl.DataValueField = "id";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("取消楼层", ""));
                ddl.SelectedValue = ((TREC.Entity.EnMarketStoreyShop)(e.Item.DataItem)).storeyid.ToString();
                DropDownList ddlStatus = (DropDownList)e.Item.FindControl("ddlLinestatus") as DropDownList;                               
                ddlStatus.Items.Insert(0, new ListItem("上线", "2"));
                ddlStatus.Items.Insert(1, new ListItem("下线", "0"));
                ddlStatus.SelectedValue = ((TREC.Entity.EnMarketStoreyShop)(e.Item.DataItem)).linestatus==null ?"2":((TREC.Entity.EnMarketStoreyShop)(e.Item.DataItem)).linestatus.ToString();
            }
        }

        #region 显示数据

        protected void ShowData()
        {
            if (ECommon.QueryEdit == "2" && ECommon.QueryId != "")
            {
                ECShop.DeletEnShop(TypeConverter.StrToInt(ECommon.QueryId));
            }

            string strWhere = " marketid=" + marketInfo.id;
        
                if (ddlmarketstory.SelectedValue != "")
                {
                    strWhere += " and storeyid=" + ddlmarketstory.SelectedValue;
                }
                if (marketshopposition.Value != "")
                {
                    strWhere += " and position like  '%" + marketshopposition.Value + "%'";
                }
                if (ddlbrand.SelectedValue != "")
                {
                    strWhere += " and brandtitlelist='" + ddlbrand.SelectedItem.Text + "'";
                }

                if (Request["Status"] != null && Request["Status"] != "")
                {
                    strWhere += " and linestatus=" + Request["Status"];
                    int.TryParse(Request["Status"],out linestatus);
                }
                if (drop_Pavilion.SelectedValue != "-1")
                {
                    strWhere += " and PavilionId=" + drop_Pavilion.SelectedValue;
                }
                if (Request["source"] != null && Request["source"] != "")
                {
                    strWhere += " and source=" + Request["source"];
                    int.TryParse(Request["source"], out source);
                }

                //strWhere += " and id in(select shopid from t_marketstoreyshop where marketid=" + marketInfo.id + ")";
                List<EnMarketStoreyShop> mkshop = ECMarketStoreyShop.GetMarketStoreyShopList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount);


                AspNetPager1.PageSize = 40;
                rptList.DataSource = mkshop;           
                rptList.DataBind();
                AspNetPager1.RecordCount = tmpPageCount;
            
        }
        #endregion

        #region 更新楼层信息

        protected void lbtnUpStorey_Click(object sender, EventArgs e)
        {
           // List<EnMarketStoreyShop> list = new List<EnMarketStoreyShop>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {

                string shopid = ((Label)rptList.Items[i].FindControl("lb_id")).Text;
              //  string shoptitle = ((Label)rptList.Items[i].FindControl("lb_title")).Text;
                string marketstoryshopid = ((Label)rptList.Items[i].FindControl("lb_mkssId")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                DropDownList ddl = (DropDownList)rptList.Items[i].FindControl("ddlms");
                DropDownList ddlLinestatus = (DropDownList)rptList.Items[i].FindControl("ddlLinestatus");
                TextBox myposition = (TextBox)rptList.Items[i].FindControl("txtposition");
                if (cb.Checked)
                {

                    EnMarketStoreyShop model = ECMarketStoreyShop.GetMarketStoreyShopInfo(string.Format(" where id={0}",marketstoryshopid)); ;
                    //model.marketid = marketInfo.id;
                   // model.markettitle = marketInfo.title;
                    model.storeyid = TypeConverter.StrToInt(ddl.SelectedValue);
                    model.storeytitle = ddl.SelectedValue == "" ? "未加入楼层" : ddl.SelectedItem.Text;
                   // model.shopid = TypeConverter.StrToInt(shopid);
                  //  model.shoptitle = shoptitle;
                   // model.istop = 0;
                    //model.isrecommend = 0;
                   // model.brandidlist = "";
                   // model.brandtitlelist = "";
                  //  model.lev = 0;
                   // model.sort = 0;
                   // model.lastedid = memberInfo.id;
                    model.lastedittime = DateTime.Now;
                    model.position = myposition.Text.Replace("'", "").Trim();
                    model.linestatus =int.Parse(ddlLinestatus.SelectedValue);
                    //model.source = 1;
                   // list.Add(model);
                    ECMarketStoreyShop.EditMarketStoreyShop(model);
                }
            }

            //if (list.Count > 0)
            //{
            //    ECMarketStoreyShop.UpMarketShorey(list);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "click", "alert('更新成功！');location.href='marketstoryshopmanage.aspx';", true);
                //UiCommon.JscriptPrint(this.Page, "批量更新楼层成功!", Request.Url.AbsoluteUri, "Success");
           // }
        }

        #endregion

  
        #region 搜索数据

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        #endregion

      

    }
}