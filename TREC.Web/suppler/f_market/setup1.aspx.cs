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

namespace TREC.Web.Suppler.f_market
{
    public partial class setup1 : SupplerPageBase
    {
        public string areaCode = "";
        public EnMember _memberInfo = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 页面初始化

                ddlstaffsize.Items.Clear();
                ddlstaffsize.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.企业配置 + " and type=" + (int)EnumConfigByEnterprise.人员规模);
                ddlstaffsize.DataTextField = "title";
                ddlstaffsize.DataValueField = "value";
                ddlstaffsize.DataBind();
                ddlstaffsize.Items.Insert(0, new ListItem("请选择", ""));

                ddlPro.Items.Clear();
                ddlPro.DataSource = ECArea.GetAreaList(" parentcode=0");
                ddlPro.DataTextField = "areaname";
                ddlPro.DataValueField = "areacode";
                ddlPro.DataBind();
                ddlPro.Items.Insert(0, new ListItem("请选择", ""));

                ddlregcity.Items.Clear();
                ddlregcity.Items.Insert(0, new ListItem("请选择省份", ""));
                #endregion
                if (marketInfo!=null)
                {                    
                ShowData();
                }
            }
        }

        #region 显示数据
        
        protected void ShowData()
        {
            if (memberInfo.type != (int)EnumMemberType.卖场)
            {
                UiCommon.JscriptPrint(this.Page, "对不起您不是卖场账号!", Request.Url.AbsoluteUri, "error");
            }
            else
            {
                EnMarket model = ECMarket.GetMarketInfo("  where id=" + marketInfo.id);
                #region MyRegion
                
                if (model != null)
                {
                    txttitle.Text = model.title;
                    this.txtletter.Text = model.letter;
                    areaCode = model.areacode;
                    this.txtaddress.Text = model.address;
                    this.ddlstaffsize.SelectedValue = model.staffsize.ToString();
                    this.txtregyear.Text = model.regyear;
                    if (!string.IsNullOrEmpty(model.regcity))
                    {
                        this.ddlregcity.SelectedValue = model.regcity;
                        this.ddlPro.SelectedValue = model.regcity.Substring(0, 2) + "0000";

                        if (model.regcity != model.regcity.Substring(0, 2) + "0000")
                        {
                            ddlregcity.Items.Clear();
                            ddlregcity.DataSource = ECArea.GetAreaList(" parentcode=" + ddlPro.SelectedValue);
                            ddlregcity.DataTextField = "areaname";
                            ddlregcity.DataValueField = "areacode";
                            ddlregcity.DataBind();
                            ddlregcity.Items.Insert(0, new ListItem("请选择省份", ""));
                            ddlregcity.SelectedValue = model.regcity;
                        }
                    }

                    if (ddlPro.SelectedValue != "")
                    {
                        ddlregcity.Items.Clear();
                        ddlregcity.DataSource = ECArea.GetAreaList(" parentcode=" + ddlPro.SelectedValue);
                        ddlregcity.DataTextField = "areaname";
                        ddlregcity.DataValueField = "areacode";
                        ddlregcity.DataBind();
                        ddlregcity.Items.Insert(0, new ListItem("请选择省份", ""));
                        ddlregcity.SelectedValue = model.regcity;
                    }

                    this.txtbuy.Text = model.buy;
                    this.txtlinkman.Text = model.linkman;
                    this.txtphone.Text = model.phone;
                    this.txtmphone.Text = model.mphone;
                    this.txtfax.Text = model.fax;
                    this.txtemail.Text = model.email;
                    this.txtpostcode.Text = model.postcode;
                    this.txthomepage.Text = model.homepage;
                    this.hfsurface.Value = model.surface;
                    this.hflogo.Value = model.logo;
                    this.hfthumb.Value = model.thumb;
                    this.hfbannel.Value = model.bannel;
                    this.hfdesimage.Value = model.desimage;
                    this.txtdescript.Text = model.descript;
                    this.txtcbm.Text = model.cbm.ToString();
                    this.txtlphone.Text = model.lphone;
                    this.txtzphone.Text = model.zphone;
                    this.txtbusroute.Text = model.busroute;
                    this.txthours.Text = model.hours;

                }
                #endregion

            }
        }
        #endregion


        #region 保存事件
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EnMarket model = new EnMarket() ;
            if (marketInfo!=null)
            {
                model = ECMarket.GetMarketInfo("  where id=" + marketInfo.id);    
            }            

            #region 接收输入参数            
            string title = txttitle.Text;
            string letter = this.txtletter.Text;
            string industry = "";
            string productcategory = "";
            string areacode = Request.Form["ddlareacode_value"] == null ? Request.Params["ddlareacode_value"] == null ? "" : Request.Params["ddlareacode_value"].ToString() : Request.Form["ddlareacode_value"];
            string address = this.txtaddress.Text;
            int staffsize = TypeConverter.StrToInt(ddlstaffsize.SelectedValue);
            string regyear = this.txtregyear.Text;
            string regcity = Request.Form["ddlregcity"] == null ? Request.Form["ddlregcity"] == null ? "" : Request.Form["ddlregcity"].ToString() : Request.Form["ddlregcity"].ToString();
            string buy = this.txtbuy.Text;
            string sell = "";
            string linkman = this.txtlinkman.Text;
            string phone = this.txtphone.Text;
            string mphone = this.txtmphone.Text;
            string fax = this.txtfax.Text;
            string email = this.txtemail.Text;
            string postcode = this.txtpostcode.Text;
            string homepage = this.txthomepage.Text;
            string surface = this.hfsurface.Value;
            string logo = this.hflogo.Value;
            string thumb = this.hfthumb.Value;
            string bannel = this.hfbannel.Value;
            string desimage = this.hfdesimage.Value;
            string descript = this.txtdescript.Text;
            DateTime lastedittime = DateTime.Now;
            #endregion

            #region 为model赋值  
          
            model.title = title;
            model.letter = letter;
            model.industry = industry;
            model.productcategory = productcategory;
            model.areacode = areacode;
            model.address = address;
            model.staffsize = staffsize;
            model.regyear = regyear;
            model.regcity = regcity;
            model.buy = buy;
            model.sell = sell;
            model.linkman = linkman;
            model.phone = phone;
            model.mphone = mphone;
            model.fax = fax;
            model.email = email;
            model.postcode = postcode;
            model.homepage = homepage;
            model.surface = surface;
            model.logo = logo;
            model.thumb = thumb;
            model.bannel = bannel;
            model.desimage = desimage;
            model.descript = descript;
            model.lastedittime = lastedittime;
            model.cbm = TypeConverter.StrToDeimal(txtcbm.Text);
            model.lphone = this.txtlphone.Text;
            model.zphone = this.txtzphone.Text;
            model.busroute = this.txtbusroute.Text;
            model.hours = this.txthours.Text;
            model.lastedid = memberInfo.id;
            model.mapapi = "";
            model.mid = memberInfo.id;
            #endregion

            int aid = ECMarket.EditMarket(model);
            #region 上传图片            
            if (aid > 0)
            {
                ECUpLoad ecUpload = new ECUpLoad();


                if (surface.Length > 0)
                {
                    ArrayList alst1 = new ArrayList();
                    alst1.Add(ecUpload._992_2000);
                    ArrayList alst2 = new ArrayList();
                    alst2.Add(ecUpload._1_1);
                    surface = surface.StartsWith(",") ? surface.Substring(1, surface.Length - 1) : surface;
                    surface = surface.EndsWith(",") ? surface.Substring(0, surface.Length - 1) : surface;
                    ecUpload.MoveFiles(surface.Split(','), string.Format(EnFilePath.Market, aid, EnFilePath.Surface), alst1, alst2, true);
                }
                if (thumb.Length > 0)
                {
                    ArrayList alst1 = new ArrayList();
                    alst1.Add(ecUpload._174_188);
                    ArrayList alst2 = new ArrayList();
                    alst2.Add(ecUpload._1_1);
                    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Market, aid, EnFilePath.Thumb), alst1, alst2, true);
                }
                if (logo.Length > 0)
                {
                    ArrayList alst1 = new ArrayList();
                    alst1.Add(ecUpload._196_70);
                    ArrayList alst2 = new ArrayList();
                    alst2.Add(ecUpload._1_1);
                    ecUpload.MoveFiles(logo.Split(','), string.Format(EnFilePath.Market, aid, EnFilePath.Logo), alst1, alst2, true);
                }
                if (bannel.Length > 0)
                {
                    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Market, aid, EnFilePath.Banner));
                }
                if (desimage.Length > 0)
                {
                    ecUpload.MoveFiles(desimage.Split(','), string.Format(EnFilePath.Market, aid, EnFilePath.DesImage));
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
                        ECMarket.UpConFilePath(ECommon.RepFilePathContent(model.descript, TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.Market, aid, EnFilePath.ConImage)), aid);
                        ecUpload.MoveContentFiles(strConFilePath.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.Market, aid, EnFilePath.ConImage));
                    }
                }
            #endregion
                //   Response.Redirect("setup2.aspx");
                Response.Redirect("../index.aspx");
            }
        #endregion


        }
    }
}