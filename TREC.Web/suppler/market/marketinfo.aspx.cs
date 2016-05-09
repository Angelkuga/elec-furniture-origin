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
    public partial class marketinfo : SupplerPageBase
    {
        public string areaCode = "";
        public EnMember _memberInfo = null;
        protected EnMarketClique _marketClique = null;
        public string droparea;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 初始化数据
                Master.menuName = "companyinfo";
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
                ShowData();
            }
        }

        #region 读取显示数据

        protected void ShowData()
        {
            if (memberInfo.type != (int)EnumMemberType.卖场)
            {
                UiCommon.JscriptPrint(this.Page, "对不起您不是卖场账号!", Request.Url.AbsoluteUri, "error");
            }
            else
            {
                EnMarket model = null;
                if (marketInfo != null)
                {
                    model = ECMarket.GetMarketInfo("  where id=" + marketInfo.id);
                }
                if (model != null)
                {
                    // txttitle.Text = model.title;
                    this.txtletter.Text = model.letter;
                    areaCode = model.areacode;
                    this.txtaddress.Text = model.address;
                    this.ddlstaffsize.SelectedValue = model.staffsize.ToString();
                    this.txtregyear.Text = model.regyear;
                    txt_Clique.Text = model.MarketCliqueName;
                    txt_stitle.Text = string.IsNullOrEmpty(model.Stitle) ? model.title : model.Stitle;

                    try
                    {
                        EnArea _area3 = new EnArea();
                        EnArea _area2 = new EnArea();
                        _area3 = ECArea.GetAreaList("areacode='" + model.areacode + "'").FirstOrDefault();
                        _area2 = ECArea.GetAreaList("areacode='" + _area3.parentcode + "'").FirstOrDefault();


                        if (_area2 != null && !string.IsNullOrEmpty(_area2.areacode))
                        {
                            try
                            {
                                ddlPro.SelectedIndex = -1;
                                string pcode = _area2.parentcode == "0" ? _area2.areacode : _area2.parentcode;
                                ddlPro.Items.FindByValue(pcode).Selected = true;

                                ddlregcity.Items.Clear();
                                ddlregcity.DataSource = ECArea.GetAreaList("parentcode='" + _area2.parentcode + "'");
                                ddlregcity.DataTextField = "areaname";
                                ddlregcity.DataValueField = "areacode";
                                ddlregcity.DataBind();
                                ddlregcity.SelectedIndex = -1;
                                ddlregcity.Items.FindByValue(_area2.areacode).Selected = true;
                            }
                            catch
                            { }
                        }
                        foreach (EnArea en in ECArea.GetAreaList("parentcode='" + _area3.parentcode + "'"))
                        {
                            if (en.areacode != _area3.areacode)
                            {
                                droparea = droparea + "<option  value=\"" + en.areacode + "\">" + en.areaname + "</option>";
                            }
                            else
                            {
                                droparea = droparea + "<option selected=\"selected\" value=\"" + en.areacode + "\">" + en.areaname + "</option>";
                            }
                        }

                    }
                    catch
                    {
 
                    }
                    //if (!string.IsNullOrEmpty(model.regcity))
                    //{
                    //    this.ddlregcity.SelectedValue = model.regcity;
                    //    this.ddlPro.SelectedValue = model.regcity.Substring(0, 2) + "0000";

                    //    if (model.regcity != model.regcity.Substring(0, 2) + "0000")
                    //    {
                    //        ddlregcity.Items.Clear();
                    //        ddlregcity.DataSource = ECArea.GetAreaList(" parentcode=" + ddlPro.SelectedValue);
                    //        ddlregcity.DataTextField = "areaname";
                    //        ddlregcity.DataValueField = "areacode";
                    //        ddlregcity.DataBind();
                    //        ddlregcity.Items.Insert(0, new ListItem("请选择省份", ""));
                    //        ddlregcity.SelectedValue = model.regcity;
                    //    }
                    //}

                    //if (ddlPro.SelectedValue != "")
                    //{
                    //    ddlregcity.Items.Clear();
                    //    ddlregcity.DataSource = ECArea.GetAreaList(" parentcode=" + ddlPro.SelectedValue);
                    //    ddlregcity.DataTextField = "areaname";
                    //    ddlregcity.DataValueField = "areacode";
                    //    ddlregcity.DataBind();
                    //    ddlregcity.Items.Insert(0, new ListItem("请选择省份", ""));
                    //    ddlregcity.SelectedValue = model.regcity;
                    //}

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
                    if (string.IsNullOrEmpty(model.hours))
                        this.txthours.Text = "9:30—17:30(周一至周五)9:30-18:30(周六周日)";
                    else
                        this.txthours.Text = model.hours;
                }
                else
                {
                    droparea = "<option selected=\"selected\" value=\"0\">--区--</option>";
                }
                if (marketInfo != null)
                {
                    _marketClique = ECMarketClique.GetMarketCliqueBySubMainMarketId(marketInfo.id);
                }
            }
        }
        #endregion

        #region 保存事件

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string areacode = Request["selArea"];
            int checkcon = 0;
            if (areacode.Length>2)
            {
                checkcon++;
            }
            if (!String.IsNullOrEmpty(txt_Clique.Text.Trim()))
            {
                checkcon++;
            }

            if (!string.IsNullOrEmpty(txt_stitle.Text.Trim()))
            {
                checkcon++;
            }
            if (checkcon == 3)
            {
                EnMarket model = ECMarket.GetMarketInfo("  where id=" + marketInfo.id);
                #region 接收输入参数

                string title = txt_Clique.Text.Replace("集团", "") + txt_stitle.Text;
                string letter = this.txtletter.Text;
                string industry = "";
                string productcategory = "";

                string address = this.txtaddress.Text;
                int staffsize = TypeConverter.StrToInt(ddlstaffsize.SelectedValue);
                string regyear = this.txtregyear.Text;
                string regcity = Request["selArea"];
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
                string logo = this.hflogo.Value;//this.hflogo.Value; Request["relogo"].Trim()
                string thumb = this.hfthumb.Value; //this.hfthumb.Value; Request["rethumb"].Trim()
                string bannel = this.hfbannel.Value;
                string desimage = this.hfdesimage.Value;
                string descript = this.txtdescript.Text;

                DateTime lastedittime = DateTime.Now;
                #endregion

                #region 赋值

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
                model.MarketCliqueName = txt_Clique.Text.Trim();
                model.Stitle = txt_stitle.Text.Trim();
                model.mapapi = "";
                model.template = "1";
                #endregion
                int aid = ECMarket.EditMarket(model);
                #region 上传图片

                if (aid > 0)
                {
                    ECUpLoad ecUpload = new ECUpLoad();


                    //if (surface.Length > 0)
                    //{
                    //    surface = surface.StartsWith(",") ? surface.Substring(1, surface.Length - 1) : surface;
                    //    surface = surface.EndsWith(",") ? surface.Substring(0, surface.Length - 1) : surface;
                    //    ecUpload.MoveFiles(surface.Split(','), string.Format(EnFilePath.Market, aid, EnFilePath.Surface));
                    //}
                    //if (thumb.Length > 0)
                    //{
                    //    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Market, aid, EnFilePath.Thumb));
                    //}
                    //if (logo.Length > 0)
                    //{
                    //    ecUpload.MoveFiles(logo.Split(','), string.Format(EnFilePath.Market, aid, EnFilePath.Logo));
                    //}
                    //if (bannel.Length > 0)
                    //{
                    //    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Market, aid, EnFilePath.Banner));
                    //}
                    //if (desimage.Length > 0)
                    //{
                    //    ecUpload.MoveFiles(desimage.Split(','), string.Format(EnFilePath.Market, aid, EnFilePath.DesImage));
                    //}

                    //StringBuilder imglist = Utils.GetImgUrl(model.descript);

                    //if (Utils.GetImgUrl(model.descript).Length > 0)
                    //{
                    //    string strConFilePath = "";
                    //    foreach (string s in imglist.ToString().Split(','))
                    //    {
                    //        if (s.Contains(TREC.Entity.EnFilePath.tmpRootPath))
                    //        {
                    //            strConFilePath += s + ",";
                    //        }
                    //    }

                    //    if (strConFilePath.Length > 0)
                    //    {
                    //        ECMarket.UpConFilePath(ECommon.RepFilePathContent(model.descript, TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.Market, aid, EnFilePath.ConImage)), aid);
                    //        ecUpload.MoveContentFiles(strConFilePath.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.Market, aid, EnFilePath.ConImage));
                    //    }
                    //}

                #endregion
                    // UiCommon. ShowAndRedirect
                    //JscriptPrint(this.Page, "编辑成功!", "marketinfo.aspx", "Success");
                    //ShowAndRedirect()
                    //TREC.ECommerce.UiCommon.ShowAndRedirect("","");
                    
                }
                ScriptUtils.ShowAndRedirect("编辑成功!", "marketinfo.aspx");
            }
            else
            {
                if (areacode.Length < 2)
                {
                    ScriptUtils.Alert(this.Page, "请选择地区");
                   
                }
                if (String.IsNullOrEmpty(txt_Clique.Text.Trim()))
                {
                    ScriptUtils.Alert(this.Page, "请填写集团名称");

                   
                }

                if (string.IsNullOrEmpty(txt_stitle.Text.Trim()))
                {
                    ScriptUtils.Alert(this.Page, "请填写卖场名称");
                }
            }

        #endregion

        }
    }
}