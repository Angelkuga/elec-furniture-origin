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
using Haojibiz.DAL;
using Haojibiz.Model;


namespace TREC.Web.Admin.brand
{
    public partial class brandinfo : AdminPageBase
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
                ddlcompany.Items.Insert(0, new ListItem("请选择", ""));
                ddlcompany.Items.Insert(1, new ListItem("无联工厂", "0"));




                //ddlstyle.Items.Clear();
                //ddlstyle.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type="+(int)EnumConfigByProduct.产品风格);
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



                ddlauditstatus.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumAuditStatus), ddlauditstatus);
                ddlauditstatus.Items.Insert(0, new ListItem("请选择", ""));



                ddllinestatus.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumAuditStatus), ddllinestatus);
                ddllinestatus.Items.Insert(0, new ListItem("请选择", ""));

                chkattribute.Items.Clear();
                WebControlBind.CheckBoxListBind(typeof(EnumAttribute), chkattribute);


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

                        this.ddlcompany.Items.Insert(0, new ListItem(_companyInfo != null ? _companyInfo.title : "无企业", _companyInfo != null ? model.companyid.ToString() : "0"));
                        this.ddlcompany.Enabled = false;
                    }


                    txttitle.Text = model.title;
                    this.txtletter.Text = model.letter;
                    WebControlBind.CheckBoxListSetSelected(chkattribute, model.attribute);


                    //this.ddlstyle.SelectedValue = model.style;
                    //this.ddlmaterial.SelectedValue = model.material;
                    this.ddlspread.SelectedValue = model.spread;
                    //this.ddlcolor.SelectedValue = model.color;

                    //this.hfsurface.Value = model.surface;
                    this.hflogo.Value = model.logo;
                    this.hfthumb.Value = model.thumb;
                    this.hfbannel.Value = model.bannel;
                    //this.hfdesimage.Value = model.desimage;

                    this.txthomepage.Text = model.homepage;
                    this.txtdescript.Text = model.descript;
                    this.txtkeywords.Text = model.keywords;
                    this.ddltemplate.SelectedValue = model.template;
                    this.txthits.Text = model.hits.ToString();
                    this.txtsort.Text = model.sort.ToString();
                    this.txtlastedittime.Text = model.lastedittime.ToString();
                    this.ddlauditstatus.SelectedValue = model.auditstatus.ToString();
                    this.ddllinestatus.SelectedValue = model.linestatus.ToString();



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

            }

           // int companyid = TypeConverter.StrToInt(ddlcompany.SelectedValue);
            int companyid = TypeConverter.StrToInt(Request["ddlcompany"]);
            if (companyid <= 0)
            {
                companyid=TypeConverter.StrToInt(Request.Form["ddlcompanyname"]);
                //if (companyid <= 0)
                //{
                //    UiCommon.JscriptPrint(this.Page, "抱歉，请选择工厂!", Request.Url.AbsoluteUri, "Success");
                //    return;
                //}
            }
            string title = txttitle.Text;
            string letter = this.txtletter.Text;
            string attribute = WebControlBind.CheckBoxListSelected(chkattribute);
            string productcategory = "";

            //string style = ddlstyle.SelectedValue;
            //string material = ddlmaterial.SelectedValue;
            string spread = ddlspread.SelectedValue;
            //string color = ddlcolor.SelectedValue;


            string icp = this.txticp.Text;
            //string surface = this.hfsurface.Value;
            string logo = this.hflogo.Value;
            string thumb = this.hfthumb.Value;
            string bannel = this.hfbannel.Value;
            //string desimage = this.hfdesimage.Value;
            string descript = this.txtdescript.Text;
            string keywords = this.txtkeywords.Text;
            string template = ddltemplate.SelectedValue;
            int hits = TypeConverter.StrToInt(this.txthits.Text);
            int sort = TypeConverter.StrToInt(this.txtsort.Text);
            DateTime lastedittime = DateTime.Now;
            int auditstatus = TypeConverter.StrToInt(ddlauditstatus.SelectedValue);
            int linestatus = TypeConverter.StrToInt(ddllinestatus.SelectedValue);

            if (model.companyid == null || model.companyid.Value == 0)
            {
                model.companyid = companyid;
            }
            model.title = title;
            model.letter = letter;
            model.attribute = attribute;
            model.productcategory = productcategory;

            //model.style = style;
            //model.material = material;
            model.spread = spread;
            //model.color = color;

            //model.surface = surface;
            model.logo = logo;
            model.thumb = thumb;
            model.bannel = bannel;
            model.homepage = this.txthomepage.Text;
            //model.desimage = desimage;
            model.descript = descript;
            model.keywords = keywords;
            model.template = template;
            model.hits = hits;
            model.sort = sort;

            model.lasteditid = adminId;
            model.lastedittime = lastedittime;
            model.auditstatus = auditstatus;
            model.linestatus = linestatus;



            int aid = ECBrand.EditBrand(model);
            if (aid > 0)
            {
                if (model.auditstatus == 0)
                {
                    //代理+无代理
                    List<EnShop> list = ECShop.GetShopList(" id in(select distinct a.id from t_shop a left join t_shopbrand b on a.id=b.shopid where b.brandid=" + aid.ToString() + ")");
                    string str = "";
                    foreach (EnShop _item in list)
                    {
                        str += _item.id + ",";
                    }
                    str = str.EndsWith(",") ? str.Substring(0, str.Length - 1) : str;
                    if (str.Length > 0)
                    {
                        ModifyTable_auditstatus_linestatus(str, EnumModifyType.shop, false, "id");
                    }

                    foreach (EnShop _item in list)//处理促销信息
                    {
                        List<Mpromotionsrelated> promotionsrelatedlist = new List<Mpromotionsrelated>();

                        Dpromotions dpromotions = new Dpromotions();

                        promotionsrelatedlist = dpromotions.LinqData<Mpromotionsrelated>().Where(c => c.shopid == _item.id).ToList();

                        foreach (Mpromotionsrelated _mspd in promotionsrelatedlist)
                        {
                            List<Mpromotionsrelated> _promotionsrelatedlist = dpromotions.LinqData<Mpromotionsrelated>().Where(c => c.promotionsid == _mspd.promotionsid).ToList();

                            if (_promotionsrelatedlist.Count == 1)
                            {
                                Mpromotions m = new Mpromotions();
                                m.auditstatus = 0;
                                m.linestatus = 0;
                                m.id = promotionsrelatedlist[0].promotionsid;
                                dpromotions.Update(m, c => c.id == m.id);
                            }
                            else
                            {
                                Dpromotionsrelated dpromotionsrelated = new Dpromotionsrelated();
                                dpromotionsrelated.Delete(c => c.shopid == _item.id && c.promotionsid == _mspd.id);
                            }
                        }
                    }

                    List<EnAppBrand> _lst = ECAppBrand.GetAppBrandList(" brandid=" + aid.ToString());

                    if (_lst == null || _lst.Count <= 0)//无代理
                    {
                        ModifyTable_auditstatus_linestatus(aid.ToString(), EnumModifyType.product, false, "brandid");
                    }

                    EnBrand eccompany = ECBrand.GetBrandInfo(" where id=" + aid.ToString());
                    if (eccompany != null)
                    {
                        List<EnBrand> _list = ECBrand.GetBrandList(" companyid=" + eccompany.companyid);
                        if (_list != null && _list.Count == 1)
                        {
                            ModifyTable_auditstatus_linestatus(eccompany.companyid.ToString(), EnumModifyType.company, false, "id");
                        }
                    }
                }

                ECUpLoad ecUpload = new ECUpLoad();


                //if (surface.Length > 0)
                //{
                //    surface = surface.StartsWith(",") ? surface.Substring(1, surface.Length - 1) : surface;
                //    surface = surface.EndsWith(",") ? surface.Substring(0, surface.Length - 1) : surface;
                //    ecUpload.MoveFiles(surface.Split(','), string.Format(EnFilePath.Brand, aid, EnFilePath.Surface));
                //}
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
                //if (desimage.Length > 0)
                //{
                //    ecUpload.MoveFiles(desimage.Split(','), string.Format(EnFilePath.Brand, aid, EnFilePath.DesImage));
                //}

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


                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}