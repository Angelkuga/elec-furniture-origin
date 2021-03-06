﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;

namespace TREC.Web.Suppler.f_dealer
{
    public partial class setup3 : SupplerPageBase
    {
        public string areaCode = "";
        public EnBrand _brandInfo = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string strWhere = "";
                switch (memberInfo.type)
                {
                    case (int)EnumMemberType.工厂企业:
                        strWhere = " companyid=" + companyInfo.id;
                        break;
                    case (int)EnumMemberType.经销商:
                        strWhere = " id in (select brandid from " + TableName.TBAppBrand + " where dealerid=" + dealerInfo.id + " and apptype=" + (int)EnumAppBrandType.申请新建品牌 + " and createmid=" + memberInfo.id + ") ";
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

                ddlstyle.Items.Clear();
                ddlstyle.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品风格);
                ddlstyle.DataTextField = "title";
                ddlstyle.DataValueField = "value";
                ddlstyle.DataBind();
                ddlstyle.Items.Insert(0, new ListItem("请选择", ""));


                ddlmaterial.Items.Clear();
                ddlmaterial.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品选材);
                ddlmaterial.DataTextField = "title";
                ddlmaterial.DataValueField = "value";
                ddlmaterial.DataBind();
                ddlmaterial.Items.Insert(0, new ListItem("请选择", ""));



                //ddlspread.Items.Clear();
                //ddlspread.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品价位);
                //ddlspread.DataTextField = "title";
                //ddlspread.DataValueField = "value";
                //ddlspread.DataBind();
                //ddlspread.Items.Insert(0, new ListItem("请选择", ""));

                ddlcolor.Items.Clear();
                ddlcolor.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品颜色);
                ddlcolor.DataTextField = "title";
                ddlcolor.DataValueField = "value";
                ddlcolor.DataBind();
                ddlcolor.Items.Insert(0, new ListItem("请选择", ""));


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
                        this.ddlbrand.Items.Clear();
                        this.ddlbrand.Items.Insert(0, new ListItem(_brandInfo.title, model.brandid.ToString()));
                        this.ddlbrand.Enabled = false;
                    }


                    txttitle.Text = model.title;

                    this.txtdescript.Text = model.descript;
                    this.txtsort.Text = model.sort.ToString();

                    //SetPermission(model.createmid, 0, 0, 0, 0, model.brandid, (System.Web.UI.WebControls.WebControl)btnSave, (System.Web.UI.HtmlControls.HtmlControl)btnRequest);

                }
            }
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

            string style = ddlstyle.SelectedValue;
            string material = ddlmaterial.SelectedValue;
            string spread = "";
            string color = ddlcolor.SelectedValue;



            model.brandid = brandid;
            model.title = title;
            model.descript = descript;
            model.sort = sort;
            model.lastedittime = lastedittime;
            model.style = style;
            model.material = material;
            model.spread = spread;
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