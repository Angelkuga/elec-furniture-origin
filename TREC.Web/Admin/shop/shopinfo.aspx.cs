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
using Haojibiz.Model;
using Haojibiz.DAL;


namespace TREC.Web.Admin.shop
{
    public partial class shopinfo : AdminPageBase
    {
        public string areaCode = "";
        public string IsMarket = "1";
        public EnMember _memberInfo = null;
        public string BrandList = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlmember.Items.Clear();
                ddlmember.DataSource = ECMember.GetTop20MemberList();
                ddlmember.DataTextField = "username";
                ddlmember.DataValueField = "id";
                ddlmember.DataBind();
                ddlmember.Items.Insert(0, new ListItem("请选择", ""));
                ddlmember.Items.Insert(1, new ListItem("无关联账号", "0"));
                ddlmember.SelectedValue = "0";

                ddlmarket.Items.Clear();
                ddlmarket.DataSource = ECMarket.GetTop20MarketList();
                ddlmarket.DataTextField = "title";
                ddlmarket.DataValueField = "id";
                ddlmarket.DataBind();
                ddlmarket.Items.Insert(0, new ListItem("请选择", ""));
                ddlmarket.Items.Insert(1, new ListItem("未加入卖场", "0"));


                ddlshopgroup.Items.Clear();
                ddlshopgroup.DataSource = ECShop.GetShopGroupList("");
                ddlshopgroup.DataTextField = "title";
                ddlshopgroup.DataValueField = "id";
                ddlshopgroup.DataBind();
                ddlshopgroup.Items.Insert(0, new ListItem("请选择", ""));

                //ddlstaffsize.Items.Clear();
                //ddlstaffsize.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.企业配置 + " and type=" + (int)EnumConfigByEnterprise.人员规模);
                //ddlstaffsize.DataTextField = "title";
                //ddlstaffsize.DataValueField = "value";
                //ddlstaffsize.DataBind();
                //ddlstaffsize.Items.Insert(0, new ListItem("请选择", ""));

                //ddlPro.Items.Clear();
                //ddlPro.DataSource = ECArea.GetAreaList(" parentcode=0");
                //ddlPro.DataTextField = "areaname";
                //ddlPro.DataValueField = "areacode";
                //ddlPro.DataBind();
                //ddlPro.Items.Insert(0, new ListItem("请选择", ""));

                //ddlregcity.Items.Clear();
                //ddlregcity.Items.Insert(0, new ListItem("请选择省份", ""));



                ddlauditstatus.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumAuditStatus), ddlauditstatus);
                ddlauditstatus.Items.Insert(0, new ListItem("请选择", ""));



                ddllinestatus.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumLineStatus), ddllinestatus);
                ddllinestatus.Items.Insert(0, new ListItem("请选择", ""));

                chkattribute.Items.Clear();
                WebControlBind.CheckBoxListBind(typeof(EnumAttribute), chkattribute);


                ddlctype.Items.Clear();
                ddlctype.Items.Add(new ListItem(Enum.GetName(typeof(EnumMemberType), (int)EnumMemberType.工厂企业), ((int)EnumMemberType.工厂企业).ToString()));
                ddlctype.Items.Add(new ListItem(Enum.GetName(typeof(EnumMemberType), (int)EnumMemberType.经销商), ((int)EnumMemberType.经销商).ToString()));
                ddlctype.Items.Insert(0, new ListItem("请选择", ""));

                ddlc.Items.Clear();
                ddlc.Items.Add(new ListItem("未加入企业", "0"));
                ddlc.Items.Insert(0, new ListItem("请选择", ""));


                WebControlBind.DrpBind(typeof(EnumTemplate), ddltemplate);

                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnShop model = ECShop.GetShopInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    if (model != null && model.mid != 0)
                    {
                        _memberInfo = ECMember.GetMemberInfo(" where id=" + model.mid);
                        if (_memberInfo != null && _memberInfo.id != 0)
                        {
                            this.ddlmember.Items.Clear();
                            this.ddlmember.Items.Insert(0, new ListItem(_memberInfo.username, model.mid.ToString()));
                            this.ddlmember.Enabled = false;
                        }
                    }

                    txttitle.Text = model.title;
                    this.txtletter.Text = model.letter;
                    this.ddlshopgroup.SelectedValue = model.groupid.ToString();
                    WebControlBind.CheckBoxListSetSelected(chkattribute, model.attribute);
                    this.txtvip.Text = model.vip.ToString();
                    areaCode = model.areacode;
                    this.txtaddress.Text = model.address;
                    //this.ddlstaffsize.SelectedValue = model.staffsize.ToString();
                    //this.txtregyear.Text = model.regyear;
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



                    //this.txtbuy.Text = model.buy;
                    //this.txtlinkman.Text = model.linkman;
                    this.txtphone.Text = model.phone;
                    //this.txtmphone.Text = model.mphone;
                    this.txtfax.Text = model.fax;
                    this.txtemail.Text = model.email;
                    //this.txtpostcode.Text = model.postcode;
                    //this.txthomepage.Text = model.homepage;
                    this.txtdomain.Text = model.domain;
                    this.txtdomainip.Text = model.domainip;
                    this.txticp.Text = model.icp;
                    //this.hfsurface.Value = model.surface;
                    //this.hflogo.Value = model.logo;
                    this.hfthumb.Value = model.thumb;
                    this.hfbannel.Value = model.bannel;
                    //this.hfdesimage.Value = model.desimage;
                    this.txtdescript.Text = model.descript;
                    this.txtkeywords.Text = model.keywords;
                    this.ddltemplate.SelectedValue = model.template;
                    this.txthits.Text = model.hits.ToString();
                    this.txtsort.Text = model.sort.ToString();
                    this.txtlastedittime.Text = model.lastedittime.ToString();
                    this.ddlauditstatus.SelectedValue = model.auditstatus.ToString();
                    this.ddllinestatus.SelectedValue = model.linestatus.ToString();
                    this.ddlctype.SelectedValue = model.ctype.ToString();
                    this.txtqq.Text = model.qq;
                    if (model.cid != 0)
                    {
                        ddlc.Items.Clear();
                        ddlc.Items.Add(new ListItem("未加入企业", "0"));
                        ddlc.Items.Add(new ListItem("己加入企业", model.cid.ToString()));
                        ddlc.Items.Insert(0, new ListItem("请选择", ""));
                        ddlc.SelectedValue = model.cid.ToString();
                    }

                    if (model != null && model.marketid != 0)
                    {

                        bool isHas = false;
                        foreach (ListItem item in ddlmarket.Items)
                        {
                            if (item.Value == model.marketid.ToString())
                            {
                                item.Selected = true;
                                isHas = true;
                                break;
                            }
                        }
                        if (!isHas)
                        {
                            EnMarket m = ECMarket.GetMarketInfoVSNameAndIdInfo(" where id=" + model.marketid.ToString());
                            if (m != null)
                            {
                                ddlmarket.Items.Add(new ListItem(m.title, model.marketid.ToString()));
                                ddlmarket.SelectedValue = model.marketid.ToString();
                            }
                        }

                    }
                    else if (model != null && model.marketid == 0)
                    {
                        IsMarket = "0";
                    }

                    foreach (EnShopBrand m in ECShop.GetReaderShopBrandList(" where shopid=" + model.id))
                    {
                        EnBrand _enb = ECBrand.GetBrandInfo(" where id=" + m.brandid);
                        if (_enb != null)
                            BrandList += _enb.title + "<input type=\"checkbox\" name=\"ckcal\" checked=\"checked\" value=\"" + m.brandid + "\" />";
                    }

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnShop model = null;

            string strErr = "";


            if (strErr != "")
            {
                return;
            }

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECShop.GetShopInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }

            if (model == null)
            {
                model = new EnShop();
                model.mapapi = "";
                model.createmid = 0;
            }


            int mid = TypeConverter.StrToInt(ddlmember.SelectedValue);
            string title = txttitle.Text;
            string letter = this.txtletter.Text;
            int groupid = TypeConverter.StrToInt(ddlshopgroup.SelectedValue);
            string attribute = WebControlBind.CheckBoxListSelected(chkattribute);
            string industry = "";
            string productcategory = "";
            int vip = TypeConverter.StrToInt(this.txtvip.Text);
            string areacode = Request.Form["ddlareacode_value"] == null ? Request.Params["ddlareacode_value"] == null ? "" : Request.Params["ddlareacode_value"].ToString() : Request.Form["ddlareacode_value"];
            string address = this.txtaddress.Text;
            //int staffsize = TypeConverter.StrToInt(ddlstaffsize.SelectedValue);
            //string regyear = this.txtregyear.Text;
            string regcity = Request.Form["ddlregcity"] == null ? Request.Form["ddlregcity"] == null ? "" : Request.Form["ddlregcity"].ToString() : Request.Form["ddlregcity"].ToString();
            //string buy = this.txtbuy.Text;
            string sell = "";
            string linkman = "";// this.txtlinkman.Text;
            string phone = this.txtphone.Text;
            string mphone = "";//this.txtmphone.Text;
            string fax = this.txtfax.Text;
            string email = this.txtemail.Text;
            string postcode = "";//this.txtpostcode.Text;
            string homepage = "";//this.txthomepage.Text;
            string domain = this.txtdomain.Text;
            string domainip = this.txtdomainip.Text;
            string icp = this.txticp.Text;
            //string surface = this.hfsurface.Value;
            //string logo = this.hflogo.Value;
            string thumb = this.hfthumb.Value;
            string bannel = this.hfbannel.Value;
            //string desimage = this.hfdesimage.Value;
            string descript = this.txtdescript.Text;
            string keywords = this.txtkeywords.Text;
            string template = ddltemplate.SelectedValue;
            int hits = TypeConverter.StrToInt(this.txthits.Text);
            int sort = TypeConverter.StrToInt(this.txtsort.Text);
            string cid = Request.Form["ddlc"];
            string ctype = ddlctype.SelectedValue;
            DateTime lastedittime = DateTime.Now;
            int auditstatus = TypeConverter.StrToInt(ddlauditstatus.SelectedValue);
            int linestatus = TypeConverter.StrToInt(ddllinestatus.SelectedValue);
            string qq = txtqq.Text;

            //是否在卖场
            int rodIsMarket = TypeConverter.StrToInt(Request.Form["rodIsMarket"]);
            if (rodIsMarket == 1)
            {
                model.marketid = TypeConverter.StrToInt(ddlmarket.SelectedValue);
                if (model.marketid <= 0)
                {
                    model.marketid = TypeConverter.StrToInt(Request.Form["ddlmarket"]);
                }
            }
            else
            {
                model.marketid = 0;
            }
            //更新卖场信息到店铺
            if (model.marketid > 0)
            {
                EnMarket _MarketModel = ECMarket.GetMarketInfo(" where id=" + model.marketid);
                if (_MarketModel != null)
                {
                    model.areacode = _MarketModel.areacode;
                    model.address = _MarketModel.address;
                }
            }

            model.mid = mid;
            model.title = title;
            model.letter = letter;
            model.groupid = groupid;
            model.attribute = attribute;
            model.industry = industry;
            model.productcategory = productcategory;
            model.vip = vip;
            //model.areacode = areacode;
            //model.address = address;
            //model.staffsize = staffsize;
            //model.regyear = regyear;
            model.regcity = regcity;
            //model.buy = buy;
            model.sell = sell;
            model.linkman = linkman;
            model.phone = phone;
            model.mphone = mphone;
            model.fax = fax;
            model.email = email;
            model.postcode = postcode;
            model.homepage = homepage;
            model.domain = domain;
            model.domainip = domainip;
            model.icp = icp;
            //model.surface = surface;
            //model.logo = logo;
            model.thumb = thumb;
            model.bannel = bannel;
            //model.desimage = desimage;
            model.descript = descript;
            model.keywords = keywords;
            model.template = template;
            model.hits = hits;
            model.sort = sort;
            //model.marketid = TypeConverter.StrToInt(ddlmarket.SelectedValue);
            model.cid = TypeConverter.StrToInt(cid);
            model.ctype = TypeConverter.StrToInt(ctype);
            model.lastedittime = lastedittime;
            model.auditstatus = auditstatus;
            model.linestatus = linestatus;
            model.lastedid = adminId;
            model.qq = qq;
            //if (model.mid > 0)
            //{
            //    EnMember enms = ECMember.GetMemberInfo(" where id=" + model.mid);
            //    if (enms != null)
            //    {
            //        switch (enms.type)
            //        {
            //            case (int)EnumMemberType.工厂企业:
            //                EnCompany enc = ECCompany.GetCompanyInfo(" where mid=" + model.mid);
            //                if (enc != null)
            //                {
            //                    model.cid = enc.id;
            //                }
            //                break;
            //            case (int)EnumMemberType.经销商:
            //                EnDealer end = ECDealer.GetDealerInfo(" where mid=" + model.mid);
            //                if (end != null)
            //                {
            //                    model.cid = end.id;
            //                }
            //                break;
            //        }
            //    }
            //}

            int aid = ECShop.EditShop(model);
            if (aid > 0)
            {
                //下线
                if (model.auditstatus == 0)
                {
                    List<Mpromotionsrelated> promotionsrelatedlist = new List<Mpromotionsrelated>();

                    Dpromotions dpromotions = new Dpromotions();

                    promotionsrelatedlist = dpromotions.LinqData<Mpromotionsrelated>().Where(c => c.shopid == aid).ToList();

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
                            dpromotionsrelated.Delete(c => c.shopid == aid && c.promotionsid == _mspd.id);
                        }
                    }

                    List<EnBrand> Brandmodel = ECBrand.GetBrandList(" id in (select brandid from t_shopbrand where shopid in(" + aid + "))");
                    if (model != null)
                    {
                        foreach (EnBrand item in Brandmodel)
                        {
                            List<EnAppBrand> _lst = ECAppBrand.GetAppBrandList(" brandid=" + item.id);

                            if (_lst == null || _lst.Count <= 0)//无代理
                            {
                                ModifyTable_auditstatus_linestatus(item.id.ToString(), EnumModifyType.brand, false, "id");

                                ModifyTable_auditstatus_linestatus(item.id.ToString(), EnumModifyType.product, false, "brandid");
                            }
                        }
                    }
                }
                //关联店铺
                if (model.marketid <= 0)
                {
                    ECMarketStoreyShop.DeleteMarketStoreyShopByShopIdList(aid.ToString());
                }

                //关联品牌
                string value = Request.Form["ckcal"];
                if (!string.IsNullOrEmpty(value))
                {
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
                }




                ECUpLoad ecUpload = new ECUpLoad();

                ArrayList alst1 = new ArrayList();
                alst1.Add(ecUpload._550_410);
                ArrayList alst2 = new ArrayList();
                alst2.Add(ecUpload._1_1);
                //if (surface.Length > 0)
                //{
                //    surface = surface.StartsWith(",") ? surface.Substring(1, surface.Length - 1) : surface;
                //    surface = surface.EndsWith(",") ? surface.Substring(0, surface.Length - 1) : surface;
                //    ecUpload.MoveFiles(surface.Split(','), string.Format(EnFilePath.Shop, aid, EnFilePath.Surface));
                //}
                if (thumb.Length > 0)
                {
                    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Shop, aid, EnFilePath.Thumb), alst1, alst2, true);
                }
                //if (logo.Length > 0)
                //{
                //    ecUpload.MoveFiles(logo.Split(','), string.Format(EnFilePath.Shop, aid, EnFilePath.Logo));
                //}
                if (bannel.Length > 0)
                {
                    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Shop, aid, EnFilePath.Banner), alst1, alst2, true);
                }
                //if (desimage.Length > 0)
                //{
                //    ecUpload.MoveFiles(desimage.Split(','), string.Format(EnFilePath.Shop, aid, EnFilePath.DesImage));
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
                        ECShop.UpConFilePath(ECommon.RepFilePathContent(model.descript, TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.Shop, aid, EnFilePath.ConImage)), aid);
                        ecUpload.MoveContentFiles(strConFilePath.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.Shop, aid, EnFilePath.ConImage));
                    }
                }



                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}