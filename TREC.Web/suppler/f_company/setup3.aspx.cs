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

namespace TREC.Web.Suppler.f_company
{
    public partial class setup3 : SupplerPageBase
    {
        public string areaCode = "";
        public EnBrand _brandInfo = null;
        public List<EnBrands> listbrands = new List<EnBrands>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listbrands = ECBrand.GetBrandsList(" brandid in (" + SupplerPageBase.brandidlist + ")");

                string strWhere = "";
                switch (memberInfo.type)
                {
                    case (int)EnumMemberType.工厂企业:
                        strWhere = " companyid=" + companyInfo.id;
                        break;
                    case (int)EnumMemberType.经销商:
                        strWhere = " id in (select brandid from " + TableName.TBAppBrand + " where dealerid=" + dealerInfo.id + " and apptype=" + (int)EnumAppBrandType.申请新建品牌 + ") ";
                        break;
                }

                ddlbrand.Items.Clear();
                ddlbrand.DataSource = ECBrand.GetBrandList(1, 20, strWhere, out tmpPageCount);
                ddlbrand.DataTextField = "title";
                ddlbrand.DataValueField = "id";
                ddlbrand.DataBind();
                ddlbrand.Items.Insert(0, new ListItem("请选择", ""));
                if (tmpPageCount == 0)
                {
                    ScriptUtils.ShowAndRedirect("请选添加品牌", "appbrand.aspx");
                }

                //Add :rafer
                //date:2012-4-24
                //Remarks:系列新增（材质，风格，色系）三项，初始化三项
                //风格
                ddlstyle.Items.Clear();
                ddlstyle.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品风格);
                ddlstyle.DataTextField = "title";
                ddlstyle.DataValueField = "value";
                ddlstyle.DataBind();
                ddlstyle.Items.Insert(0, new ListItem("选择风格", ""));
                //选材
                ddlmaterial.Items.Clear();
                ddlmaterial.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品选材);
                ddlmaterial.DataTextField = "title";
                ddlmaterial.DataValueField = "value";
                ddlmaterial.DataBind();
                ddlmaterial.Items.Insert(0, new ListItem("选择选材", ""));
                //色系
                ddlcolor.Items.Clear();
                ddlcolor.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品颜色);
                ddlcolor.DataTextField = "title";
                ddlcolor.DataValueField = "value";
                ddlcolor.DataBind();
                ddlcolor.Items.Insert(0, new ListItem("选择颜色", ""));

                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnBrands model = ECBrand.GetBrandsInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    if (model != null && model.brandid != 0)
                    {
                        _brandInfo = ECBrand.GetBrandInfo(" where id=" + model.brandid);
                        //this.ddlbrand.Items.Clear();
                        this.ddlbrand.SelectedValue = model.brandid.ToString();  //.Items.Insert(0, new ListItem(_brandInfo.title, model.brandid.ToString()));
                        this.ddlbrand.Enabled = false;
                    }

                    //新增三项
                    //add:rafer
                    //date:4-24
                    this.ddlstyle.SelectedValue = model.style;
                    this.ddlmaterial.SelectedValue = model.material;
                    this.ddlcolor.SelectedValue = model.color;

                    txttitle.Text = model.title;

                    this.txtdescript.Text = model.descript;
                    this.txtsort.Text = model.sort.ToString();

                    //SetPermission(model.createmid, 0, 0, 0, 0, model.brandid, (System.Web.UI.WebControls.WebControl)btnSave, (System.Web.UI.HtmlControls.HtmlControl)btnRequest);

                }
            }
        }

        protected string GetBrandTitle(int bid)
        {
            if (brandList == null || brandList.Count == 0)
                return "";
            return brandList.Single(x => x.id == bid).title + "-";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnBrands model = null;

            string strErr = "";


            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }




            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECBrand.GetBrandsInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
                if (model == null)
                {
                    model = new EnBrands();
                }
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
            string descript = this.txtdescript.Text;
            int sort = TypeConverter.StrToInt(this.txtsort.Text);
            DateTime lastedittime = DateTime.Now;

            string material = Request.Form["ddlmaterial"]; //ddlmaterial.SelectedValue;
            string style = Request.Form["ddlstyle"]; //ddlstyle.SelectedValue;
            string color = Request.Form["ddlcolor"]; //ddlcolor.SelectedValue;

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
                ECUpLoad ecUpload = new ECUpLoad();
                StringBuilder imglist = Utils.GetImgUrl(model.descript);

                if (Utils.GetImgUrl(model.descript).Length > 0)
                {
                    string strConFilePath = "";
                    foreach (string s in imglist.ToString().Split(','))
                    {
                        if (s.Contains(TREC.Entity.EnFilePath.tmpRootPath))
                        {
                            strConFilePath += s + ",";
                        }
                    }

                    if (strConFilePath.Length > 0)
                    {
                        ECBrand.UpBrandsConFilePath(ECommon.RepFilePathContent(model.descript, TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.Brands, aid, EnFilePath.ConImage)), aid);
                        ecUpload.MoveContentFiles(strConFilePath.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.Brands, aid, EnFilePath.ConImage));
                    }
                }

                Response.Redirect("../index.aspx");
            }


        }
    }
}