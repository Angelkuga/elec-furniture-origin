using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using Haojibiz;

namespace TREC.Web.Suppler.market
{
    public partial class marketshopadd : SupplerPageBase
    {
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        public int marketid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (memberInfo != null)
                {
                    marketid = marketInfo.id;
                    Master.menuName = "marketshopadd";
                    List<EnMarketStorey> mslist = ECMarketStorey.GetMarketStoreyList(" marketid=" + marketInfo.id);
                    ddlmarketstory.DataSource = mslist;
                    ddlmarketstory.DataTextField = "title";
                    ddlmarketstory.DataValueField = "id";
                    ddlmarketstory.DataBind();
                    ddlmarketstory.Items.Insert(0, new ListItem("楼层", ""));
                }


                List<t_Pavilion> _listpav = new List<t_Pavilion>();
                _listpav = EntityOper.t_Pavilion.Where(p => p.MarketId == marketInfo.id).ToList();
                drop_pav.DataSource = _listpav;
                drop_pav.DataTextField = "Title";
                drop_pav.DataValueField = "Id";
                drop_pav.DataBind();
                ListItem _item=new ListItem();
                _item.Text="--无--";
                _item.Value="0";
                drop_pav.Items.Insert(0, _item);

            }
        }
          #region 保存卖场店铺
        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            string name = brandName.Value.Trim();
            #region 添加品牌
            int brandid = 0;
            List<EnBrand> brandListM = ECBrand.GetBrandList(string.Format(" title='{0}'",name));
            if (brandListM != null && brandListM.Count > 0)
            {
                brandid = brandListM[0].id;
            }else{
                 //添加品牌
                EnBrand model = new EnBrand();
                string title = name;
                string letter = "";
                string productcategory = "";
                string style = "";
                string material = "";
                string spread = "";
                string color = "";
                string surface ="";
                string logo ="";
                string thumb ="";
                string bannel ="";
                string desimage = "";
                string descript = "卖场提前录入的品牌基本信息";
                DateTime lastedittime = DateTime.Now;


                model.companyid = 0;
                model.title = title;
                model.letter = letter;
                model.productcategory = productcategory;

                model.style = style;
                model.material = material;
                model.spread = spread;
                model.color = color;

                model.surface = surface;
                model.logo = logo;
                model.thumb = thumb;
                model.bannel = bannel;
                model.desimage = desimage;
                model.descript = descript;
                model.lastedittime = lastedittime;                
                brandid= ECBrand.EditBrand(model);
            }
          
            
            #endregion

            #region 添加店铺,楼层
            int shopid = 0;
            if (brandid>0)
            {
              EnShop  model = new EnShop();
                model.mapapi = "";                
                model.marketid = marketInfo.id;
                model.title = name;
                model.createmid = 0;
                model.lastedid = 0;
                model.auditstatus = 0;
                model.linestatus = 0;
                model.mid =0;
                model.domain = "";
                model.domainip = "";
                model.icp = "";
                model.keywords = "";
                model.template = "1";
                model.hits = 0;
                model.ctype = memberInfo.type;
                model.cid = 0;
                model.homepage = "";
                model.regyear = "2000";
                model.vip = 0;
                model.groupid = 1;
                model.attribute = "";
                model.regcity = "";
                model.surface = "";
                model.logo = "";
                model.desimage = "";
                model.staffsize = 0;
                model.auditstatus = 0;
                model.linestatus = 0;
                model.descript = "卖场提前录入的店铺基本信息";
                model.address = memberInfo.address;
                model.areacode = memberInfo.areacode;
                model.lastedittime = DateTime.Now;
                shopid = ECShop.EditShop(model);

                #region 添加楼层
                if (shopid > 0)
                {
                    EnMarketStoreyShop modelStroeyShop = new EnMarketStoreyShop();
                    int myid = 0;
                    modelStroeyShop.marketid = marketInfo.id;
                    modelStroeyShop.markettitle = marketInfo.title;
                    int.TryParse(ddlmarketstory.SelectedValue, out myid);
                    modelStroeyShop.storeyid = myid;
                    modelStroeyShop.storeytitle = ddlmarketstory.SelectedValue == "" ? "未加入楼层" : ddlmarketstory.SelectedItem.Text;
                    modelStroeyShop.shopid = shopid;
                    modelStroeyShop.shoptitle = name;
                    modelStroeyShop.istop = 0;
                    modelStroeyShop.isrecommend = 0;
                    modelStroeyShop.brandidlist =brandid.ToString();
                    modelStroeyShop.brandtitlelist = name;
                    modelStroeyShop.lev = 0;
                    modelStroeyShop.sort = 0;
                    modelStroeyShop.lastedid = memberInfo.id;
                    modelStroeyShop.lastedittime = DateTime.Now;
                    modelStroeyShop.createtime = DateTime.Now;
                    modelStroeyShop.position = marketshopposition.Value;
                    modelStroeyShop.linestatus = 0;
                    modelStroeyShop.source= 2;
                    modelStroeyShop.PavilionId = SubmitMeth.getInt(drop_pav.SelectedValue);
                    if (ECMarketStoreyShop.EditMarketStoreyShop(modelStroeyShop) > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "click", "alert('添加成功！');location.href='marketstoryshopmanage.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "click", "alert('添加失败！');", true);                      
                    }
                }
                #endregion
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "click", "alert('添加失败！');", true);          
            }
            #endregion
           

        }
          #endregion
    }
}