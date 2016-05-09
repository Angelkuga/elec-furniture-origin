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
using System.Collections;
using Haojibiz;

namespace TREC.Web.Suppler.shop
{
    public partial class shopinfo : SupplerPageBase
    {
        public string droparea = "<option value='0'>--区--</option>";
        public string areaCode = "";
        public EnMember _memberInfo = null;
        public string IsMarket = "1";
        public string BrandItem = string.Empty;
        public int SellerId = 0;
        public string SellerName = string.Empty;
        public string Contact = string.Empty;
        public string ContactMobile = string.Empty;
        public string FirstClerk = string.Empty;
        public string FirstClerkMobile = string.Empty;
        public string SecondClerk = string.Empty;
        public string SecondClerkMobile = string.Empty;
        public string myTitle = "添加";
        public int isshopshare = 0; //是否共享
        public int companyid = 0;
        public string selPavilionId = "0";

        public bool ispay = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (!SupplerPageBase.IsPayMember())
                //{
                //    Response.Redirect("/suppler/Payment/RegPayment.aspx");
                //}
              //  ispay = SupplerPageBase.IsPayMember();
                ispay = true;
                string memberId = CookiesHelper.GetCookie("mid");
                if (string.IsNullOrEmpty(memberId))
                {
                    Response.Write("<script>top.document.location.href='" + ECommon.WebUrl + "index.aspx" + "';</script>");
                    Response.End();
                }
                //选中左边菜单栏目
                Master.menuName = "shoplist";
                List<EnBrand> brandList = SupplerPageBase.brandList;
                if (brandList != null)
                {
                    foreach (EnBrand bmodel in brandList)
                        BrandItem += "<label><input name=\"brand\" type=\"checkbox\" value=\"" + bmodel.id + "\" />\r\n" + bmodel.title + "</label>";
                }
                if (memberInfo.type == (int)EnumMemberType.工厂企业)
                {
                    companyid = companyInfo.id;
                }
                List<t_Pavilion> _listpav = new List<t_Pavilion>();
                //_listpav = EntityOper.t_Pavilion.Where(p => p.MarketId == marketInfo.id).ToList();

                ddlPro.Items.Clear();
                ddlPro.DataSource = ECArea.GetAreaList(" parentcode=0");
                ddlPro.DataTextField = "areaname";
                ddlPro.DataValueField = "areacode";
                ddlPro.DataBind();
                ddlPro.Items.Insert(0, new ListItem("--省--", "0"));

                ddlregcity.Items.Clear();
                ddlregcity.Items.Insert(0, new ListItem("--城市--", "0"));

                ShowData();
            }
        }
        #region 编辑显示信息

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                myTitle = "编辑";
                EnShop model = ECShop.GetShopInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    txttitle.Text = model.title;
                    areaCode = model.areacode;

                    //this.txtbuy.Text = model.buy;
                    Contact = model.linkman;
                    this.txtphone.Text = model.phone;
                    ContactMobile = model.mphone;
                    this.txtfax.Text = model.fax;
                    this.txtemail.Text = model.email;
                    //this.txtpostcode.Text = model.postcode;
                    this.hfthumb.Value = model.thumb;
                    this.hfbannel.Value = model.bannel;
                    this.txtdescript.Text = model.descript;
                    this.txtsort.Text = model.sort.ToString();
                    this.txtqq.Text = model.qq;
                    //this.txtletter.Text = model.letter;
                    if (model.marketid != null)
                        SellerId = int.Parse(model.marketid.ToString());
                    this.txtaddress.Text = model.address;
                    FirstClerk = model.ShopContact;
                    FirstClerkMobile = model.FirstClerkMobile;
                    SecondClerk = model.SecondClerk;
                    SecondClerkMobile = model.SecondClerkMobile;
                    isshopshare = int.Parse(model.isshopshare.ToString());

                    selPavilionId = model.PavilionId.ToString();


                   

                    EnArea _area3 = new EnArea();
                    EnArea _area2 = new EnArea();

                    _area3 = ECArea.GetAreaList("areacode='" + areaCode + "'").FirstOrDefault();
                    if (_area3 != null)
                    {
                        _area2 = ECArea.GetAreaList("areacode='" + _area3.parentcode + "'").FirstOrDefault();
                    }


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
                    if (_area3 != null)
                    {
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

                    List<EnShopBrand> brandList = ECShop.GetReaderShopBrandList(" where shopid=" + model.id);
                    if (brandList != null)
                    {
                        if (0 < brandList.Count())
                        {
                            string brandIdStr = ",";
                            foreach (EnShopBrand m in brandList)
                            {
                                brandIdStr += m.brandid.ToString() + ",";
                            }
                            ClientScript.RegisterStartupScript(this.GetType(), "", "<script type=\"text/javascript\">SelectSaleBrand('" + brandIdStr + "');</script>");
                        }
                    }
                }
            }
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string memberId = CookiesHelper.GetCookie("mid");
            if (string.IsNullOrEmpty(memberId))
            {
                Response.Write("<script>top.document.location.href='" + ECommon.WebUrl + "index.aspx" + "';</script>");
                Response.End();
            }
            EnShop model = null;

            string strErr = "";


            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECShop.GetShopInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }

            #region 初始化店铺信息
            int marketId = 0;
            if (model == null)
            {
                model = new EnShop();
                model.mapapi = "";
                if (!string.IsNullOrEmpty(Request.Form["marketId"]))
                    int.TryParse(Request.Form["marketId"].Trim(), out marketId);
                model.marketid = marketId;
                model.createmid = int.Parse(memberId);
                model.lastedid = int.Parse(memberId);
                model.auditstatus = 0;
                model.linestatus = 0;
                model.mid = int.Parse(memberId);
                model.domain = "";
                model.domainip = "";
                model.icp = "";
                model.keywords = "";
                model.template = "1";
                model.hits = 0;
                model.ctype = memberInfo.type;
                model.cid = 0;
                model.homepage = "";
                model.regyear = "2000";
                model.vip = 0;
                model.groupid = 1;
                model.attribute = "";
                model.regcity = "";
                model.surface = "";
                model.logo = "";
                model.desimage = "";
                model.staffsize = 0;
                model.auditstatus = 0;
                model.linestatus = 0;
                
            }
            #endregion

            #region 接收参数

            string title = txttitle.Text;
            //string letter = txtletter.Text;
            string letter = "";
            string industry = "";
            string productcategory = "";
            string areacode = Request.Form["ddlareacode_value"] == null ? Request.Params["ddlareacode_value"] == null ? "" : Request.Params["ddlareacode_value"].ToString() : Request.Form["ddlareacode_value"];
            string address = this.txtaddress.Text;
            //string buy = this.txtbuy.Text;
            string buy = "";
            string sell = "";
            string linkman = "";
            if (Request.Form["ShopContact"] != null)
                linkman = Request.Form["ShopContact"].Trim();
            string phone = this.txtphone.Text;
            string mphone = "";
            if (Request.Form["ShopContactMobile"] != null)
                mphone = Request.Form["ShopContactMobile"].Trim();
            string fax = this.txtfax.Text;
            string email = this.txtemail.Text;
            string postcode = "";
            string thumb = this.hfthumb.Value;
            string bannel = this.hfbannel.Value;
            string descript = this.txtdescript.Text;
            int sort = TypeConverter.StrToInt(this.txtsort.Text);
            DateTime lastedittime = DateTime.Now;
            string qq = this.txtqq.Text.Trim();
            string FirstClerk = "";
            if (Request.Form["FirstClerk"] != null)
                FirstClerk = Request.Form["FirstClerk"].Trim();
            string FirstClerkMobile = "";
            if (Request.Form["FirstClerkMobile"] != null)
                FirstClerkMobile = Request.Form["FirstClerkMobile"].Trim();
            string SecondClerk = "";
            if (Request.Form["SecondClerk"] != null)
                SecondClerk = Request.Form["SecondClerk"].Trim();
            string SecondClerkMobile = "";
            if (Request.Form["SecondClerkMobile"] != null)
                SecondClerkMobile = Request.Form["SecondClerkMobile"].Trim();
            int IsShopShare = 0;
            if (Request.Form["IsShare"] != null)
                IsShopShare = 1;
            //更新时归属卖场
            if (!string.IsNullOrEmpty(Request.Form["marketId"]))
                int.TryParse(Request.Form["marketId"].Trim(), out marketId);
            
            #endregion

            #region 赋值

            model.ShopContact = FirstClerk;
            model.FirstClerkMobile = FirstClerkMobile;
            model.SecondClerk = SecondClerk;
            model.SecondClerkMobile = SecondClerkMobile;
            model.IsPay = 0;
            model.title = title;
            model.letter = letter;
            model.industry = industry;
            model.productcategory = productcategory;
            model.areacode = areacode;
            model.address = address;
            model.buy = buy;
            model.sell = sell;
            model.linkman = linkman;
            model.phone = phone;
            model.mphone = mphone;
            model.fax = fax;
            model.email = email;
            model.postcode = postcode;
            model.thumb = thumb;
            model.bannel = bannel;
            model.descript = descript;
            model.sort = sort;
            model.qq = qq;
            model.isshopshare = IsShopShare;
            //更新时归属卖场
            model.marketid = marketId;
            model.PavilionId = SubmitMeth.getInt(Request["selPavilion"]);
            #endregion

            //更新卖场信息到店铺
            if (model.marketid > 0)
            {
                EnMarket _MarketModel = ECMarket.GetMarketInfo(" where id=" + model.marketid);
                if (_MarketModel != null)
                {
                    //model.areacode = _MarketModel.areacode;
                    //model.address = _MarketModel.address;
                    model.marketid = _MarketModel.id;
                }
            }
            model.lastedittime = lastedittime;

            int aid = ECShop.EditShop(model);

            #region 通知客服邮件
            if (model.id == 0)
            {
                try
                {
                    string mailsubject = string.Format(@"
                        <p>商家: {0} 用户名：{5}</p>
                        <p>添加了店铺。</p>
                        <p>品牌id:{1} 店铺名称:{2}</p>
                        <p>商家id:{3} 商家身份:{4}</p>"
                            , companyInfo.title, aid, model.title, companyInfo.id, memberInfo.type, memberInfo.username);

                    string[] mailto = TREC.ECommerce.ECommon.ServiceMail.Split(',');
                    foreach (string items in mailto)
                    {
                        bool rsmail = EmailHelper.SendEmail("家具快搜 商家添加店铺通知提示", items, mailsubject);
                    }
                }
                catch
                { 
                }
            }
            #endregion

            if (aid > 0)
            {
                //关联品牌
                #region 关联品牌

                string value = "";
                if (Request["brand"] != null)
                    value = Request["brand"].Trim();
                //foreach (ListItem i in chkbrandlist.Items)
                //{
                //    if (i.Selected)
                //        value += i.Value + ",";
                //}
                value = value.StartsWith(",") ? value.Substring(1, value.Length - 1) : value;
                value = value.EndsWith(",") ? value.Substring(0, value.Length - 1) : value;

                string[] values = value.Split(',');
                if (values.Length > 0)
                {
                    StringOperation.SortAndDdistinct(values, StringOperation.OrderByType.DESC);
                    List<EnShopBrand> list = new List<EnShopBrand>();
                    foreach (string s in values)
                    {
                        EnShopBrand m = new EnShopBrand();
                        m.shopid = aid;
                        m.brandid = TypeConverter.StrToInt(s);
                        list.Add(m);
                    }

                    if (list.Count > 0)
                    {
                        ECShop.EditShopBrand(list);
                    }
                }
                #endregion

                #region 上传图片

                ECUpLoad ecUpload = new ECUpLoad();


                ArrayList alst1 = new ArrayList();
                alst1.Add(ecUpload._550_410);
                ArrayList alst2 = new ArrayList();
                alst2.Add(ecUpload._1_1);
                if (thumb.Length > 0)
                {
                    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Shop, aid, EnFilePath.Thumb), alst1, alst2, true);
                }

                if (bannel.Length > 0)
                {
                    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Shop, aid, EnFilePath.Banner), alst1, alst2, true);
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
                        ECShop.UpConFilePath(ECommon.RepFilePathContent(model.descript, TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.Shop, aid, EnFilePath.ConImage)), aid);
                        ecUpload.MoveContentFiles(strConFilePath.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.Shop, aid, EnFilePath.ConImage));
                    }
                }
                #endregion
                Response.Write("<script>alert('保存店铺信息成功！');location.href='shoplist.aspx';</script>");
            }
        }
    }
}