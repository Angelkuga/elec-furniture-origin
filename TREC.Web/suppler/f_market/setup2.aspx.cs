using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Suppler.f_market
{
    public partial class setup2 : SupplerPageBase
    {
        public string areaCode = "";
        public EnMember _memberInfo = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ShowData();
            }
        }

        #region 绑定事件，，暂时不用
        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnMarketStorey model = ECMarketStorey.GetMarketStoreyInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.droptitle.SelectedValue = model.title;
                    this.hfsurface.Value = model.surface;
                    this.hflogo.Value = model.logo;
                    this.hfthumb.Value = model.thumb;
                    this.hfbannel.Value = model.bannel;
                    this.hfdesimage.Value = model.desimage;
                    this.txtdescript.Text = model.descript;
                    this.txtsort.Text = model.sort.ToString();
                }
            }
        }
        #endregion


        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EnMarketStorey model = new EnMarketStorey();
            string strErr = "";
            int droptitlecount = Convert.ToInt32(Request.Form["droptitle"]);
            int aid = 0;
            for (int i = 1; i <= droptitlecount; i++)
            {
                model = EnMarketStoreyModel(i);
                aid = ECMarketStorey.EditMarketStorey(model);
            }
            if (aid > 0)
            {
                #region 处理图片
                //ECUpLoad ecUpload = new ECUpLoad();


                //if (surface.Length > 0)
                //{
                //    surface = surface.StartsWith(",") ? surface.Substring(1, surface.Length - 1) : surface;
                //    surface = surface.EndsWith(",") ? surface.Substring(0, surface.Length - 1) : surface;
                //    ecUpload.MoveFiles(surface.Split(','), string.Format(EnFilePath.MarketStorey, aid, EnFilePath.Surface));
                //}
                //if (thumb.Length > 0)
                //{
                //    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.MarketStorey, aid, EnFilePath.Thumb));
                //}
                //if (logo.Length > 0)
                //{
                //    ecUpload.MoveFiles(logo.Split(','), string.Format(EnFilePath.MarketStorey, aid, EnFilePath.Logo));
                //}
                //if (bannel.Length > 0)
                //{
                //    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.MarketStorey, aid, EnFilePath.Banner));
                //}
                //if (desimage.Length > 0)
                //{
                //    ecUpload.MoveFiles(desimage.Split(','), string.Format(EnFilePath.MarketStorey, aid, EnFilePath.DesImage));
                //}
                #endregion

                Response.Redirect("../index.aspx");
            }
        }

        /// <summary>
        /// 卖场楼层的Model
        /// </summary>
        /// <returns></returns>
        private EnMarketStorey EnMarketStoreyModel(int StoreyCount)
        {
            EnMarketStorey model = new EnMarketStorey();
            int marketid = marketInfo.id;
            string markettitle = marketInfo.title;
            string title = StoreyCount.ToString() + "楼";
            string number = "0";
            string surface = "";
            string logo = "";
            string thumb = "";
            string bannel = "";
            string desimage = "";
            string descript = "";
            string keywords = "";
            string template = "";
            int hits = 0;
            int sort = int.Parse(this.txtsort.Text);
            int lastedid = memberInfo.id;
            DateTime lastedittime = DateTime.Now;

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

            return model;
        }
    }
}