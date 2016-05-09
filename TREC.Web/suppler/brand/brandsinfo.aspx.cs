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


namespace TREC.Web.Suppler.brand
{
    public partial class brandsinfo : SupplerPageBase
    {
        public string myTitle = "添加";
        public string SwatchName = string.Empty;
        public string SwatchId = string.Empty;
        protected int SeriesId = 0;//系列id
        protected string SeriesName = string.Empty;//系列名称
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string memberId = CookiesHelper.GetCookie("mid");
                if (string.IsNullOrEmpty(memberId))
                {
                    Response.Write("<script>top.document.location.href='" + ECommon.WebUrl + "index.aspx" + "';</script>");
                    Response.End();
                }

                //选中左边菜单栏目
                Master.menuName = "brandlist";
                ddlbrand.Items.Clear();
               
                if (memberInfo.type == (int)EnumMemberType.工厂企业)
                {
                   
                    ddlbrand.DataSource = ECBrand.GetBrandList(" companyid =  " + companyInfo.id, out tmpPageCount);
                }
                else
                {
                    ddlbrand.DataSource = ECBrand.GetBrandList(" createmid =  " + memberId, out tmpPageCount);
                }
                ddlbrand.DataTextField = "title";
                ddlbrand.DataValueField = "id";
                ddlbrand.DataBind();
                ddlbrand.Items.Insert(0, new ListItem("请选择", "0"));

                //Add :rafer
                //date:2012-4-24
                //Remarks:系列新增（材质，风格，色系）三项，初始化三项
                //风格
                ddlstyle.Items.Clear();
                ddlstyle.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品风格);
                ddlstyle.DataTextField = "title";
                ddlstyle.DataValueField = "value";
                ddlstyle.DataBind();
                ddlstyle.Items.Insert(0, new ListItem("选择风格", "0"));
                //选材
                ddlmaterial.Items.Clear();
                ddlmaterial.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品选材);
                ddlmaterial.DataTextField = "title";
                ddlmaterial.DataValueField = "value";
                ddlmaterial.DataBind();
                ddlmaterial.Items.Insert(0, new ListItem("选择选材", "0"));
                //色系
                ddlcolor.Items.Clear();
                ddlcolor.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品颜色 + " and id between 143 and 148");
                ddlcolor.DataTextField = "title";
                ddlcolor.DataValueField = "value";
                ddlcolor.DataBind();
                ddlcolor.Items.Insert(0, new ListItem("选择颜色", "0"));


                ShowData(memberId);
            }
        }

        protected void ShowData(string memberId)
        {
            int.TryParse(ECommon.QueryId, out SeriesId);
            if (SeriesId <= 0)
                return;

            Dictionary<int, string> SwatchDic = ECBrand.GetSwatchName(memberId, SeriesId);
            if (0 < SwatchDic.Count())
            {
                foreach (KeyValuePair<int, string> kvp in SwatchDic)
                {
                    SwatchName += kvp.Value + "、";
                    SwatchId += kvp.Key + ",";
                }

                SwatchName = SwatchName.TrimEnd('、');
                SwatchId = SwatchId.TrimEnd(',');
            }

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                myTitle = "编辑";
                EnBrands model = ECBrand.GetBrandsInfo("  where createmid = " + memberId + " and id=" + ECommon.QueryId);
                if (model != null)
                {
                    if (0 < model.brandid)
                        this.ddlbrand.SelectedValue = model.brandid.ToString();

                    this.ddlstyle.SelectedValue = model.style;
                    this.ddlmaterial.SelectedValue = model.material;
                    this.ddlcolor.SelectedValue = model.color;
                    txttitle.Text = model.title;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EnBrands model = new EnBrands(); ;
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECBrand.GetBrandsInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }
            else
            {
                model = new EnBrands();
                model.createmid = 0;
                model.productcount = 0;
                model.style = "";
                model.color = "";
                model.spread = "";
                model.material = "";
                model.createmid = memberInfo.id;
                model.attribute = "";
                model.surface = "";
                model.logo = "";
                model.thumb = "";
                model.bannel = "";
                model.desimage = "";
                model.keywords = "";
                model.template = "";
                model.hits = 0;
                model.auditstatus = 0;
                model.linestatus = 0;
                model.letter = "";

            }


            int brandid = TypeConverter.StrToInt(ddlbrand.SelectedValue);
            string title = txttitle.Text;
            string descript = "";
            int sort = 0;
            DateTime lastedittime = DateTime.Now;
            string material = Request.Form["ctl00$ContentPlaceHolder1$ddlmaterial"]; //ddlmaterial.SelectedValue;
            string style = Request.Form["ctl00$ContentPlaceHolder1$ddlstyle"]; //ddlstyle.SelectedValue;
            string color = Request.Form["ctl00$ContentPlaceHolder1$ddlcolor"]; //ddlcolor.SelectedValue;

            model.letter = "";
            model.brandid = brandid;
            model.title = title;
            model.descript = descript;
            model.sort = sort;
            model.lastedittime = lastedittime;

            model.style = style;
            model.material = material;
            model.color = color;


            int aid = ECBrand.EditBrands(model);
            if (aid > 0)
            {
                string memberId = CookiesHelper.GetCookie("mid");
                int.TryParse(ECommon.QueryId, out SeriesId);
                if (SeriesId == 0 && !string.IsNullOrEmpty(memberId))
                    ECBrand.updateSwatchSeriesId(aid, memberId);
                Response.Write("<script>alert('保存系列数据成功！');location.href='brandslist.aspx';</script>");
            }
            else
                Response.Write("<script>alert('系统正忙，请稍后保存系列数据！');</script>");

        }
    }
}