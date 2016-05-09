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
using Haojibiz;

namespace TREC.Web.Suppler.market
{
    public partial class marketstoryshoplist : SupplerPageBase
    {
        public List<EnMarketStorey> mslist = new List<EnMarketStorey>();
        public int sid =-1;
        #region 页面加载事件

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
            Master.menuName = "marketstoryshoplist";
            if (!IsPostBack)
            {
                
                if (Request.QueryString["sid"] != null)
                {
                    int.TryParse(Request.QueryString["sid"],out sid);
                }
              
                mslist = ECMarketStorey.GetMarketStoreyList(" marketid=" + marketInfo.id);
                ShowData();
            }
        }
        #endregion

        #region repeater  行绑定事件
        
        #endregion
        protected void rptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DropDownList ddl = (DropDownList)e.Item.FindControl("ddlms") as DropDownList;
                ddl.DataSource = mslist;
                ddl.DataTextField = "title";
                ddl.DataValueField = "id";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("选择楼层", ""));
                ddl.SelectedValue = Request.QueryString["sid"].ToString();

                #region 绑定店铺品牌
                DropDownList ddlBrandList = (DropDownList)e.Item.FindControl("ddlBrandList") as DropDownList;
               
                int shopid = ((TREC.Entity.EnShop)(e.Item.DataItem)).id;               
                foreach (Hashtable m in ECShop.GetReaderShopBrandList(shopid))
                {
                    if (m["BrandName"] != null)
                    {
                        ddlBrandList.Items.Add(new ListItem(m["BrandName"].ToString(), m["BrandId"].ToString()));
                    }
                }
                DropDownList ddlStatus = (DropDownList)e.Item.FindControl("ddlLinestatus") as DropDownList;
                ddlStatus.Items.Insert(0, new ListItem("上线", "2"));
                ddlStatus.Items.Insert(1, new ListItem("下线", "0"));
               // ddlBrandList.Items.Insert(0, new ListItem("选择品牌", ""));
                #endregion
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
            if (Request.QueryString["sid"] != null)
            {
                if (Request.QueryString["sid"].ToString() == "" || Request.QueryString["sid"].ToString() == "-1")
                {
                    strWhere += " and mid!=0 and id not in(select shopid from t_marketstoreyshop where marketid=" + marketInfo.id + ") or id in(select shopid from t_marketstoreyshop where marketid=" + marketInfo.id + " and storeyid=0)";
                }                
            }
            AspNetPager1.PageSize = 40;
            rptList.DataSource = ECShop.GetShopList(ECommon.QueryPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount, marketInfo.id);
            rptList.DataBind();
            AspNetPager1.RecordCount = tmpPageCount;


        }
        #endregion

        #region 更新楼层信息
    
        protected void lbtnUpStorey_Click(object sender, EventArgs e)
        {
            List<EnMarketStoreyShop> list = new List<EnMarketStoreyShop>();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string shopid = ((Label)rptList.Items[i].FindControl("lb_shopid")).Text;
                string shoptitle = ((Label)rptList.Items[i].FindControl("lb_shoptitle")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                DropDownList ddl = (DropDownList)rptList.Items[i].FindControl("ddlms");
                TextBox myposition = (TextBox)rptList.Items[i].FindControl("txtposition");
                DropDownList ddlBrandList = (DropDownList)rptList.Items[i].FindControl("ddlBrandList") as DropDownList;
                DropDownList ddlLinestatus = (DropDownList)rptList.Items[i].FindControl("ddlLinestatus");
                if (cb.Checked)
                {
                    EnShop modelshop = null;
                    modelshop = ECShop.GetShopInfo("  where id=" + shopid);
                    EnMarketStoreyShop model = new EnMarketStoreyShop();
                    model.marketid = marketInfo.id;
                    model.markettitle = marketInfo.title;
                    model.storeyid = TypeConverter.StrToInt(ddl.SelectedValue);
                    model.storeytitle = ddl.SelectedValue == "" ? "未加入楼层" : ddl.SelectedItem.Text;
                    model.shopid = TypeConverter.StrToInt(shopid);
                    model.shoptitle = shoptitle;
                    model.istop = 0;
                    model.isrecommend = 0;
                    model.brandidlist = ddlBrandList.SelectedValue;
                    model.brandtitlelist = ddlBrandList.SelectedItem.Text;
                    model.lev = 0;
                    model.sort = 0;
                    model.lastedid = memberInfo.id;
                    model.lastedittime = DateTime.Now;
                    model.position = myposition.Text.Replace("'","").Trim();
                    model.linestatus = int.Parse(ddlLinestatus.SelectedValue);
                    model.source = 1;
                    model.createtime = DateTime.Now;
                    model.PavilionId = modelshop.PavilionId;
                   list.Add(model);
                }
            }

            if (list.Count > 0)
            {
                ECMarketStoreyShop.UpMarketShorey(list);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "click", "alert('更新楼层成功！');location.href='marketstoryshoplist.aspx?sid=" + Request.QueryString["sid"] + "';", true);
                //UiCommon.JscriptPrint(this.Page, "批量更新楼层成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        #endregion

      
        #region 读取店铺下面的品牌名称
        public string GetBrandOfShopId(object id)
        {
            string _ref = string.Empty;
            if (id == null)
            {
                return _ref;
            }
            int shopid = Convert.ToInt32(id);
            int i = 0;
            foreach (Hashtable m in ECShop.GetReaderShopBrandList(shopid))
            {
                if (m["BrandName"] != null)
                {
                    _ref += "<input name=\"brand\" type=\"radio\" value=\"" + m["BrandId"] + "\" />\r\n" + m["BrandName"];
                    //if (i == 0)
                    //{
                    //    _ref = m["BrandName"].ToString();
                    //}
                    //else
                    //{
                    //    _ref += "，" + m["BrandName"];
                    //}
                }
                else
                {
                    _ref = "暂无";
                }

                i++;
            }

            return _ref;
        }
            #endregion
          
        
    }
}