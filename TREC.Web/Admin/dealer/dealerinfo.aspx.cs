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


namespace TREC.Web.Admin.dealer
{
    public partial class dealerinfo : AdminPageBase
    {
        public string areaCode = "";
        public EnMember _memberInfo = null;


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
                ddlmember.Items.Insert(1, new ListItem("无联联账号", "0"));


                ddldealergroup.Items.Clear();
                ddldealergroup.DataSource = ECDealer.GetDealerGroupList("");
                ddldealergroup.DataTextField = "title";
                ddldealergroup.DataValueField = "id";
                ddldealergroup.DataBind();
                ddldealergroup.Items.Insert(0, new ListItem("请选择", ""));

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

                WebControlBind.DrpBind(typeof(EnumTemplate), ddltemplate);

                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnDealer model = ECDealer.GetDealerInfo("  where id=" + ECommon.QueryId);
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
                    //this.txtletter.Text = model.letter;
                    this.ddldealergroup.SelectedValue = model.groupid.ToString();
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
                    this.txtlinkman.Text = model.linkman;
                    this.txtphone.Text = model.phone;
                    this.txtmphone.Text = model.mphone;
                    this.txtfax.Text = model.fax;
                    this.txtemail.Text = model.email;
                    this.txtpostcode.Text = model.postcode;
                    //this.txthomepage.Text = model.homepage;
                    this.txtdomain.Text = model.domain;
                    this.txtdomainip.Text = model.domainip;
                    this.txticp.Text = model.icp;
                    //this.hfsurface.Value = model.surface;
                    //this.hflogo.Value = model.logo;
                    //this.hfthumb.Value = model.thumb;
                    //this.hfbannel.Value = model.bannel;
                    //this.hfdesimage.Value = model.desimage;
                    this.txtdescript.Text = model.descript;
                    this.txtkeywords.Text = model.keywords;
                    this.ddltemplate.SelectedValue = model.template;
                    this.txthits.Text = model.hits.ToString();
                    this.txtsort.Text = model.sort.ToString();
                    this.txtlastedittime.Text = model.lastedittime.ToString();
                    this.ddlauditstatus.SelectedValue = model.auditstatus.ToString();
                    this.ddllinestatus.SelectedValue = model.linestatus.ToString();

                    this.hfDBook.Value = model.dbook;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnDealer model = null;

            string strErr = "";
            

            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            


            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECDealer.GetDealerInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
            }

            if (model == null)
            {
                model = new EnDealer();
                model.mapapi = "";
                model.createmid = 0;
            }


            int mid = TypeConverter.StrToInt(ddlmember.SelectedValue);
            string title = txttitle.Text;
            //string letter = this.txtletter.Text;
            int groupid = TypeConverter.StrToInt(ddldealergroup.SelectedValue);
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
            string linkman = this.txtlinkman.Text;
            string phone = this.txtphone.Text;
            string mphone = this.txtmphone.Text;
            string fax = this.txtfax.Text;
            string email = this.txtemail.Text;
            string postcode = this.txtpostcode.Text;
            //string homepage = this.txthomepage.Text;
            string domain = this.txtdomain.Text;
            string domainip = this.txtdomainip.Text;
            string icp = this.txticp.Text;
            //string surface = this.hfsurface.Value;
            //string logo = this.hflogo.Value;
            //string thumb = this.hfthumb.Value;
            //string bannel = this.hfbannel.Value;
            //string desimage = this.hfdesimage.Value;
            string descript = this.txtdescript.Text;
            string keywords = this.txtkeywords.Text;
            string template = ddltemplate.SelectedValue;
            int hits = TypeConverter.StrToInt(this.txthits.Text);
            int sort = TypeConverter.StrToInt(this.txtsort.Text);
            DateTime lastedittime = DateTime.Now;
            int auditstatus = TypeConverter.StrToInt(ddlauditstatus.SelectedValue);
            int linestatus = TypeConverter.StrToInt(ddllinestatus.SelectedValue);

            string dbook = this.hfDBook.Value;

            model.mid = mid;
            model.title = title;
            //model.letter = letter;
            model.groupid = groupid;
            model.industry = industry;
            model.productcategory = productcategory;
            model.vip = vip;
            model.areacode = areacode;
            model.address = address;
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
            //model.homepage = homepage;
            model.domain = domain;
            model.domainip = domainip;
            model.icp = icp;
            //model.surface = surface;
            //model.logo = logo;
            //model.thumb = thumb;
            //model.bannel = bannel;
            //model.desimage = desimage;
            model.descript = descript;
            model.keywords = keywords;
            model.template = template;
            model.hits = hits;
            model.sort = sort;
            model.lastedid = adminId;
            model.lastedittime = lastedittime;
            model.auditstatus = auditstatus;
            model.linestatus = linestatus;
            model.dbook = dbook;



            int aid = ECDealer.EditDealer(model);
            if (aid > 0)
            {

                ECUpLoad ecUpload = new ECUpLoad();


                //if (surface.Length > 0)
                //{
                //    surface = surface.StartsWith(",") ? surface.Substring(1, surface.Length - 1) : surface;
                //    surface = surface.EndsWith(",") ? surface.Substring(0, surface.Length - 1) : surface;
                //    ecUpload.MoveFiles(surface.Split(','), string.Format(EnFilePath.Dealer, aid, EnFilePath.Surface));
                //}
                //if (thumb.Length > 0)
                //{
                //    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Dealer, aid, EnFilePath.Thumb));
                //}
                //if (logo.Length > 0)
                //{
                //    ecUpload.MoveFiles(logo.Split(','), string.Format(EnFilePath.Dealer, aid, EnFilePath.Logo));
                //}
                //if (bannel.Length > 0)
                //{
                //    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Dealer, aid, EnFilePath.Banner));
                //}
                //if (desimage.Length > 0)
                //{
                //    ecUpload.MoveFiles(desimage.Split(','), string.Format(EnFilePath.Dealer, aid, EnFilePath.DesImage));
                //}

                //代理证书上传
                if (dbook.Length > 0)
                {
                    ecUpload.MoveFiles(dbook.Split(','), string.Format(EnFilePath.Dealer, aid, EnFilePath.Dbook));
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
                        ECDealer.UpConFilePath(ECommon.RepFilePathContent(model.descript, TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.Dealer, aid, EnFilePath.ConImage)), aid);
                        ecUpload.MoveContentFiles(strConFilePath.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.Dealer, aid, EnFilePath.ConImage));
                    }
                }


                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}