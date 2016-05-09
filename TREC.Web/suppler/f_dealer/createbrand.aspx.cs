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
using System.Collections;

namespace TREC.Web.Suppler.f_dealer
{
    public partial class createbrand :SupplerPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ddlstyle.Items.Clear();
                //ddlstyle.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品风格);
                //ddlstyle.DataTextField = "title";
                //ddlstyle.DataValueField = "value";
                //ddlstyle.DataBind();
                //ddlstyle.Items.Insert(0, new ListItem("请选择", ""));


                //ddlmaterial.Items.Clear();
                //ddlmaterial.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品选材);
                //ddlmaterial.DataTextField = "title";
                //ddlmaterial.DataValueField = "value";
                //ddlmaterial.DataBind();
                //ddlmaterial.Items.Insert(0, new ListItem("请选择", ""));



                ddlspread.Items.Clear();
                ddlspread.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品价位);
                ddlspread.DataTextField = "title";
                ddlspread.DataValueField = "value";
                ddlspread.DataBind();
                ddlspread.Items.Insert(0, new ListItem("请选择", ""));

                //ddlcolor.Items.Clear();
                //ddlcolor.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品颜色);
                //ddlcolor.DataTextField = "title";
                //ddlcolor.DataValueField = "value";
                //ddlcolor.DataBind();
                //ddlcolor.Items.Insert(0, new ListItem("请选择", ""));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int companyId = 0;
            int brandId = 0;
            EnCompany model = ECCompany.GetCompanyInfo(" where title='" + txtcompanytitle.Text + "'");
            if (model == null)
            {
                hfcompanyid.Value = "";
            }
            else
            {
                hfcompanyid.Value = model.id.ToString();
            }
            if (hfcompanyid.Value == "")
            {
                EnCompany companyModel = new EnCompany();
                //企业信息
                int mid = 0;
                string title = txtcompanytitle.Text;
                string letter = "";
                int groupid = 0;
                string attribute = "";
                string industry = "";
                string productcategory = "";
                int vip = 0;
                string areacode = "";
                string address = "";
                int staffsize = 0;
                string regyear = "2012";
                string regcity = "";
                string buy = "";
                string sell = "";
                string linkman = txtclinkman.Text;
                string phone = txtcphone.Text;
                string mphone = "";
                string fax = "";
                string email = "";
                string postcode = "";
                string homepage = "";
                string domain = "";
                string domainip = "";
                string icp = "";
                string surface = "";
                string logo = "";
                string thumb = "";
                string bannel = "";
                string desimage = "";
                string descript = txtcdescript.Text;
                string keywords = "";
                string template = "";
                int hits = 0;
                int sort = 0;
                DateTime lastedittime = DateTime.Now;
                int auditstatus = 0;
                int linestatus = 0;

                companyModel.id = 0;
                companyModel.mid = mid;
                companyModel.title = title;
                companyModel.letter = letter;
                companyModel.groupid = groupid;
                companyModel.attribute = attribute;
                companyModel.industry = industry;
                companyModel.productcategory = productcategory;
                companyModel.vip = vip;
                companyModel.areacode = areacode;
                companyModel.address = address;
                companyModel.staffsize = staffsize;
                companyModel.regyear = regyear;
                companyModel.regcity = regcity;
                companyModel.buy = buy;
                companyModel.sell = sell;
                companyModel.linkman = linkman;
                companyModel.phone = phone;
                companyModel.mphone = mphone;
                companyModel.fax = fax;
                companyModel.email = email;
                companyModel.postcode = postcode;
                companyModel.homepage = homepage;
                companyModel.domain = domain;
                companyModel.domainip = domainip;
                companyModel.icp = icp;
                companyModel.surface = surface;
                companyModel.logo = logo;
                companyModel.thumb = thumb;
                companyModel.bannel = bannel;
                companyModel.desimage = desimage;
                companyModel.descript = descript;
                companyModel.keywords = keywords;
                companyModel.template = template;
                companyModel.hits = hits;
                companyModel.sort = sort;
                companyModel.mapapi = "";
                companyModel.createmid = memberInfo.id;
                companyModel.lastedid = 0;
                companyModel.lastedittime = lastedittime;
                companyModel.auditstatus = auditstatus;
                companyModel.linestatus = linestatus;

                companyId=ECCompany.EditCompany(companyModel);
            }
            else
            {
                companyId = TypeConverter.StrToInt(hfcompanyid.Value);
            }

            if (companyId > 0)
            {
                string title = txtbrandtitle.Text;
                string letter = this.txtbrandletter.Text;
                string productcategory = "";

                string style = "";// ddlstyle.SelectedValue;
                string material = "";// ddlmaterial.SelectedValue;
                string spread = ddlspread.SelectedValue;
                string color = "";// ddlcolor.SelectedValue;


                string surface = "";
                string logo = this.hfbrandlogo.Value;
                string thumb = hfthumb.Value;
                string bannel = "";
                string desimage = "";
                string descript = txtbranddescript.Text;
                DateTime lastedittime = DateTime.Now;

                EnBrand brandModel = new EnBrand();
                brandModel.createmid = memberInfo.id;
                brandModel.productcount = 0;
                brandModel.attribute = "";
                brandModel.keywords = "";
                brandModel.template = "default";
                brandModel.homepage = "";
                brandModel.hits = 0;
                brandModel.sort = 0;
                brandModel.auditstatus = 0;
                brandModel.linestatus = 0;
                brandModel.companyid = companyId;
                brandModel.title = title;
                brandModel.letter = letter;
                brandModel.productcategory = productcategory;
                brandModel.style = style;
                brandModel.material = material;
                brandModel.spread = spread;
                brandModel.color = color;
                brandModel.surface = surface;
                brandModel.logo = logo;
                brandModel.thumb = thumb;
                brandModel.bannel = bannel;
                brandModel.desimage = desimage;
                brandModel.descript = descript;
                brandModel.lastedittime = lastedittime;
                brandId = ECBrand.EditBrand(brandModel);


            }
            else
            {
                ScriptUtils.ShowAndRedirect("工厂信息获取失败!", "setup2.aspx");
                return;
            }

            if (brandId > 0)
            {
                EnAppBrand appmodel = new EnAppBrand();
                appmodel.id=0;
                appmodel.dealerid = dealerInfo.id;
                appmodel.dealetitle = dealerInfo.title;
                appmodel.brandid = brandId;
                appmodel.brandtitle = txtbrandtitle.Text;
                appmodel.companyid = 0;
                appmodel.companytitle = "";
                appmodel.shopid = 0;
                appmodel.shoptitle = "";
                appmodel.appmodule = (int)EnumAppBrandModule.经销商申请;
                appmodel.apptype = (int)EnumAppBrandType.申请新建品牌;
                appmodel.apptime = DateTime.Now;
                appmodel.createmid = memberInfo.id;
                appmodel.lastedittime = DateTime.Now;
                appmodel.auditstatus = 0;

                int aid = ECAppBrand.EditAppBrand(appmodel);
                if (aid > 0)
                {
                    ECUpLoad ecUpload = new ECUpLoad();

                    if (this.hfbrandlogo.Value.Length > 0)
                    {
                        ArrayList alst1 = new ArrayList();
                        alst1.Add(ecUpload._196_70);
                        ArrayList alst2 = new ArrayList();
                        alst2.Add(ecUpload._1_1);
                        this.hfbrandlogo.Value = this.hfbrandlogo.Value.EndsWith(",") ? this.hfbrandlogo.Value.Substring(0, this.hfbrandlogo.Value.Length - 1) : this.hfbrandlogo.Value;
                        ecUpload.MoveFiles(this.hfbrandlogo.Value.Split(','), string.Format(EnFilePath.Brand, brandId, EnFilePath.Logo), alst1, alst2, true);
                    }

                    if (hfthumb.Value.Length > 0)
                    {
                        ArrayList alst1 = new ArrayList();
                        alst1.Add(ecUpload._550_410);
                        alst1.Add(ecUpload._141_106);
                        ArrayList alst2 = new ArrayList();
                        alst2.Add(ecUpload._1_1);
                        ecUpload.MoveFiles(hfthumb.Value.Split(','), string.Format(EnFilePath.Brand, aid, EnFilePath.Thumb), alst1, alst2, true);
                    }

                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(),
                           System.Guid.NewGuid().ToString(),
                           "<script>parent.location.href='setup3.aspx';art.dialog.close()</script>"
                           );
                }
                else
                {
                    ScriptUtils.ShowAndRedirect("品牌申请己创建，但代理失败，请查找并申请代理!", "setup2.aspx");
                }
            }
            else
            {
                ScriptUtils.ShowAndRedirect("品牌添加失败!", "setup2.aspx");
                return;
            } 
            
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(),
                            System.Guid.NewGuid().ToString(),
                            "<script>art.dialog.close()</script>"
                            );
            
        }
    }
}