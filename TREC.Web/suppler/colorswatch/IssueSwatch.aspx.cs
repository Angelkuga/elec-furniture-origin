using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;

namespace TREC.Web.Suppler.colorswatch
{
    public partial class IssueSwatch : SupplerPageBase
    {
        protected int SwatchId = 0;//色板id
        protected string SwatchName = string.Empty;//色板名称
        protected string Picture = string.Empty;//色板图片
        protected int? brandid = 0;//品牌id
        protected int? brandsid = 0;//系列id
        protected int? cateogryid = 0;//类别id
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //选中左边菜单栏目
                Master.menuName = "swatch";
                
                //编辑色板
                if (!string.IsNullOrEmpty(Request["SwatchId"]))
                {
                    int.TryParse(Request["SwatchId"].Trim(), out SwatchId);
                    //if (SwatchId <= 0)
                    //  //  MessageUtil.ShowTipMessageAlter("抱歉，传递参数有误！", false);
                    //else
                    //{
                        //是否有权限编辑该色板
                        bool IsEditor = false;
                        t_colorswatch model = ColorSwatchBll.QueryEditorColorSwatchDb(int.Parse(CookiesHelper.GetCookie("mid")), SwatchId, out IsEditor);
                        if (model != null)
                        {
                            
                                SwatchName = model.SwatchName;
                                Picture = model.Picture;
                                brandid= model.brandid;
                                brandsid = model.bSeriesId;
                                cateogryid = model.CategroyId;
                                ClientScript.RegisterStartupScript(this.GetType(), null, "<script type=\"text/javascript\">selecteDdl(" + model.CategroyId + ",'" + model.brandid + "','" + model.bSeriesId + "');</script>");
                            
                            model = null;
                        }
                   // }
                }

                //产品品牌
                DdlBrand.DataSource = brandList;
                DdlBrand.DataTextField = "title";
                DdlBrand.DataValueField = "id";
                DdlBrand.DataBind();
                DdlBrand.Items.Insert(0, new ListItem("选择品牌", ""));   
                DdlBrand.SelectedValue=brandid.ToString();
                List<EnBrands> SeriesList = ECBrand.GetBrandsList(" createmid=" + memberInfo.id);
                if (SeriesList != null)
                {
                    if (0 < SeriesList.Count)
                    {
                        RptSeries.DataSource = SeriesList;
                        RptSeries.DataBind();
                    }
                }
            }
        }
          #region 保存色板
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //色板名称
            
                t_colorswatch model = new t_colorswatch();
                model.SwatchName =Request["SwatchName"].Trim();
                //系列id
                int SeriesId = 0;
                if (!string.IsNullOrEmpty(Request["SeriesId"]))
                    int.TryParse(Request["SeriesId"].Trim(), out SeriesId);
                model.bSeriesId = SeriesId;
                //类别id
                int categroyId = 0;
                if (!string.IsNullOrEmpty(Request["myCategroy"]))
                    int.TryParse(Request["myCategroy"].Trim(), out categroyId);
                model.CategroyId = categroyId;
                //色板图片
                string Pictrue = string.Empty;
                if (!string.IsNullOrEmpty(Request["thumb"]))
                    Pictrue = Request["thumb"].Trim();
                model.Picture = Pictrue;
                //品牌id
                 int bid=0;
                 int.TryParse(DdlBrand.SelectedValue,out bid);
                model.brandid =bid;
                //发布人
                model.CreateId = memberInfo.id;
                //色板id
                int SwatchId = 0;
                bool IsSave = false;
                if (!string.IsNullOrEmpty(Request["SwatchId"]))
                {
                    int.TryParse(Request["SwatchId"].Trim(), out SwatchId);
                    model.csid = SwatchId;
                    IsSave = ECBrand.saveColorSwatchDb(model);
                }
                else                    
                    IsSave =ECBrand.saveColorSwatchDb(model);
                model = null;
                if (IsSave)
                  Response.Write("<script>alert('保存信息成功！');location.href='colorswatchlist.aspx';</script>");
                else
                   Response.Write("<script>alert('保存信息失败！');location.href='colorswatchlist.aspx';</script>");
            }
        
          #endregion
    }
}