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
using System.Collections;

namespace TREC.Web.Suppler.f_company
{
    public partial class setup2 : SupplerPageBase
    {
        public string areaCode = "";
        public EnCompany _companyInfo = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlcompany.Items.Clear();
                ddlcompany.DataSource = ECCompany.GetCompanyList(1, 20, "", out tmpPageCount);
                ddlcompany.DataTextField = "title";
                ddlcompany.DataValueField = "id";
                ddlcompany.DataBind();
                ddlcompany.Items.Insert(0, new ListItem("选择厂商", ""));
                ddlcompany.Items.Insert(1, new ListItem("无关联工厂", "0"));


                //Modify :rafer
                //date:2012-4-24
                //Remarks:（材质，风格，色系）三项移动到系列

                //ddlstyle.Items.Clear();
                //ddlstyle.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品风格);
                //ddlstyle.DataTextField = "title";
                //ddlstyle.DataValueField = "value";
                //ddlstyle.DataBind();
                //ddlstyle.Items.Insert(0, new ListItem("选择风格", ""));

                //ddlmaterial.Items.Clear();
                //ddlmaterial.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品选材);
                //ddlmaterial.DataTextField = "title";
                //ddlmaterial.DataValueField = "value";
                //ddlmaterial.DataBind();
                //ddlmaterial.Items.Insert(0, new ListItem("选择选材", ""));

                //ddlcolor.Items.Clear();
                //ddlcolor.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品颜色);
                //ddlcolor.DataTextField = "title";
                //ddlcolor.DataValueField = "value";
                //ddlcolor.DataBind();
                //ddlcolor.Items.Insert(0, new ListItem("选择颜色", ""));

                ddlspread.Items.Clear();
                ddlspread.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品价位);
                ddlspread.DataTextField = "title";
                ddlspread.DataValueField = "value";
                ddlspread.DataBind();
                ddlspread.Items.Insert(0, new ListItem("选择档位", ""));

                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnBrand model = ECBrand.GetBrandInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    if (model != null && model.companyid != 0)
                    {
                        _companyInfo = ECCompany.GetCompanyInfo(" where id=" + model.companyid);
                        this.ddlcompany.Items.Clear();
                        this.ddlcompany.Items.Insert(0, new ListItem(_companyInfo.title, model.companyid.ToString()));
                        this.ddlcompany.Enabled = false;
                    }


                    txttitle.Text = model.title;
                    this.txtletter.Text = model.letter;


                    //this.ddlstyle.SelectedValue = model.style;
                    //this.ddlmaterial.SelectedValue = model.material;
                    this.ddlspread.SelectedValue = model.spread;
                    //this.ddlcolor.SelectedValue = model.color;

                    this.hfsurface.Value = model.surface;
                    this.hflogo.Value = model.logo;
                    this.hfthumb.Value = model.thumb;
                    this.hfbannel.Value = model.bannel;
                    this.hfdesimage.Value = model.desimage;

                    this.txtdescript.Text = model.descript;

                    //SetPermission(model.createmid, model.companyid, 0, 0, 0, model.id, (System.Web.UI.WebControls.WebControl)btnSave, (System.Web.UI.HtmlControls.HtmlControl)btnRequest);

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnBrand model = null;

            string strErr = "";


            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }




            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECBrand.GetBrandInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId); if (model == null)
                    if (model == null)
                    {
                        model = new EnBrand();
                    }
            }
            else
            {
                model = new EnBrand();
                model.createmid = 0;
                model.productcount = 0;
                model.createmid = memberInfo.id;
                model.attribute = "";
                model.keywords = "";
                model.template = "default";
                model.homepage = "";
                model.hits = 0;
                model.sort = 0;
                model.auditstatus = 0;
                model.linestatus = 0;

            }


            int companyid = 0;
            if (memberInfo.type == (int)EnumMemberType.工厂企业)
            {
                companyid = companyInfo.id;
            }
            else
            {
                companyid = TypeConverter.StrToInt(ddlcompany.SelectedValue);
            }



            string title = txttitle.Text;
            string letter = this.txtletter.Text;
            string productcategory = "";

            string style = ddlstyle.SelectedValue;
            string material = ddlmaterial.SelectedValue;
            string spread = ddlspread.SelectedValue;
            string color = ddlcolor.SelectedValue;


            string surface = this.hfsurface.Value;
            string logo = this.hflogo.Value;
            string thumb = this.hfthumb.Value;
            string bannel = this.hfbannel.Value;
            string desimage = this.hfdesimage.Value;
            string descript = this.txtdescript.Text;
            DateTime lastedittime = DateTime.Now;


            model.companyid = companyid;
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



            int aid = ECBrand.EditBrand(model);
            if (aid > 0)
            {
                ECUpLoad ecUpload = new ECUpLoad();


                if (surface.Length > 0)
                {
                    surface = surface.StartsWith(",") ? surface.Substring(1, surface.Length - 1) : surface;
                    surface = surface.EndsWith(",") ? surface.Substring(0, surface.Length - 1) : surface;
                    ecUpload.MoveFiles(surface.Split(','), string.Format(EnFilePath.Brand, aid, EnFilePath.Surface));
                }
                if (thumb.Length > 0)
                {
                    ArrayList alst1 = new ArrayList();
                    alst1.Add(ecUpload._550_410);
                    alst1.Add(ecUpload._141_106);
                    ArrayList alst2 = new ArrayList();
                    alst2.Add(ecUpload._1_1);
                    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Brand, aid, EnFilePath.Thumb), alst1, alst2, true);
                }
                if (logo.Length > 0)
                {
                    ArrayList alst1 = new ArrayList();
                    alst1.Add(ecUpload._196_70);
                    ArrayList alst2 = new ArrayList();
                    alst2.Add(ecUpload._1_1);
                    ecUpload.MoveFiles(logo.Split(','), string.Format(EnFilePath.Brand, aid, EnFilePath.Logo), alst1, alst2, true);
                }
                if (bannel.Length > 0)
                {
                    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Brand, aid, EnFilePath.Banner));
                }
                if (desimage.Length > 0)
                {
                    ecUpload.MoveFiles(desimage.Split(','), string.Format(EnFilePath.Brand, aid, EnFilePath.DesImage));
                }

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
                        ECBrand.UpConFilePath(ECommon.RepFilePathContent(model.descript, TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.Brand, aid, EnFilePath.ConImage)), aid);
                        ecUpload.MoveContentFiles(strConFilePath.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.Brand, aid, EnFilePath.ConImage));
                    }
                }


                Response.Redirect("setup3.aspx");
            }


        }
    }
}