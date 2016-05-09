using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Suppler.market
{
    public partial class marketstoryinfo : SupplerPageBase
    {
        public string areaCode = "";
        public EnMember _memberInfo = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.menuName = "marketstoryinfo";
                ShowData();
            }
        }

        protected void ShowData()
        {
            //修改
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnMarketStorey model = ECMarketStorey.GetMarketStoreyInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.droptitle.SelectedValue = model.title;
                    this.droptitle.Enabled = false;
                    this.hfsurface.Value = model.surface;
                    this.hflogo.Value = model.logo;
                    this.hfthumb.Value = model.thumb;
                    this.hfbannel.Value = model.bannel;
                    this.hfdesimage.Value = model.desimage;
                    this.txtdescript.Text = model.descript;
                    this.txtsort.Text = model.sort.ToString();
                }
            }
            else//新增 
            {
                List<EnMarketStorey> model = ECMarketStorey.GetMarketStoreyList(" marketid=" + marketInfo.id);
                foreach (ListItem item in droptitle.Items)
                {
                    for (int i = 0; i < model.Count; i++)
                    {
                        if (item.Value == model[i].title)
                        {
                            item.Enabled = false;
                        }
                    }
                }

            }
        }
        #region 添加楼层
        
        protected void btnSave_Click(object sender, EventArgs e)
        {

            TREC.Entity.EnMarketStorey model = null;

            string strErr = "";
            if (droptitle.SelectedValue=="")
            {
                strErr += "title不能为空！\\n";
            }

            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECMarketStorey.GetMarketStoreyInfo(" where id=" + ECommon.QueryId);

            }
            if (model == null)
            {
                model = new EnMarketStorey();
            }
            #region 接收信息
            
            int marketid = marketInfo.id;
            string markettitle = marketInfo.title;
            string title = droptitle.SelectedValue;
            string number = "0";
            string surface = this.hfsurface.Value;
            string logo = this.hflogo.Value;
            string thumb = this.hfthumb.Value;
            string bannel = this.hfbannel.Value;
            string desimage = this.hfdesimage.Value;
            string descript = this.txtdescript.Text;
            string keywords = "";
            string template = "";
            int hits = 0;
            int sort = int.Parse(this.txtsort.Text);
            int lastedid = memberInfo.id;
            DateTime lastedittime = DateTime.Now;
            #endregion
            #region 赋值
            
            model.marketid = marketid;
            model.markettitle = markettitle;
            model.title = title;
            model.number = number;
            model.surface = surface;
            model.logo = logo;
            model.thumb = thumb;
            model.bannel = bannel;
            model.desimage = desimage;
            model.descript = descript;
            model.keywords = keywords;
            model.template = template;
            model.hits = hits;
            model.sort = sort;
            model.lastedid = lastedid;
            model.lastedittime = lastedittime;
            #endregion

            int aid = ECMarketStorey.EditMarketStorey(model);
            if (aid > 0)
            {
                ECUpLoad ecUpload = new ECUpLoad();


                if (surface.Length > 0)
                {
                    surface = surface.StartsWith(",") ? surface.Substring(1, surface.Length - 1) : surface;
                    surface = surface.EndsWith(",") ? surface.Substring(0, surface.Length - 1) : surface;
                    ecUpload.MoveFiles(surface.Split(','), string.Format(EnFilePath.MarketStorey, aid, EnFilePath.Surface));
                }
                if (thumb.Length > 0)
                {
                    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.MarketStorey, aid, EnFilePath.Thumb));
                }
                if (logo.Length > 0)
                {
                    ecUpload.MoveFiles(logo.Split(','), string.Format(EnFilePath.MarketStorey, aid, EnFilePath.Logo));
                }
                if (bannel.Length > 0)
                {
                    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.MarketStorey, aid, EnFilePath.Banner));
                }
                if (desimage.Length > 0)
                {
                    ecUpload.MoveFiles(desimage.Split(','), string.Format(EnFilePath.MarketStorey, aid, EnFilePath.DesImage));
                }
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "click", "alert('编辑成功！');location.href='marketstorylist.aspx';", true);
               // UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
        #endregion

    }
}