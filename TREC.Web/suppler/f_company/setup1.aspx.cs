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

namespace TREC.Web.Suppler.f_company
{
    public partial class setup1 : SupplerPageBase
    {
        public string areaCode = "";
        public EnMember _memberInfo = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 綁定信息
                
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



                ddlauditstatus.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumAuditStatus), ddlauditstatus);
                ddlauditstatus.Items.Insert(0, new ListItem("请选择", ""));


                #endregion
                if (companyInfo!=null)
                {
                    ShowData();
                }
                
            }
        }
        #region 绑定显示信息        
        protected void ShowData()
        {
            EnCompany model = ECCompany.GetCompanyInfo("  where id=" + companyInfo.id);
            if (model != null)
            {
                txttitle.Text = model.title;
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

                this.txtlinkman.Text = model.linkman;
                this.txtphone.Text = model.phone;
                this.txtmphone.Text = model.mphone;
                this.txtfax.Text = model.fax;
                this.txtemail.Text = model.email;
                this.txtpostcode.Text = model.postcode;
                this.txthomepage.Text = model.homepage;
                this.hfthumb.Value = model.thumb;
                this.hfbannel.Value = model.bannel;

                //add:rafer
                //date:4-24
                //新增三证图片
                this.hflicense.Value = model.license;
                this.hfregistration.Value = model.registration;
                this.hforganization.Value = model.organization;

                this.txtdescript.Text = model.descript;
                this.ddlauditstatus.SelectedValue = model.auditstatus.ToString();

            }
        }
        #endregion

        #region 保存事件
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EnCompany model = null;
            if (companyInfo!=null)
            {
                model = ECCompany.GetCompanyInfo("  where id=" + companyInfo.id);
            }       
            
            if (model == null)
            {
                model = new EnCompany();
                model.mapapi = "";
                model.createmid = 0;
            }

            #region 绑定信息
            
            int mid = memberInfo.id;
            string title = txttitle.Text;
            string areacode = Request.Form["ddlareacode_value"] == null ? Request.Params["ddlareacode_value"] == null ? "" : Request.Params["ddlareacode_value"].ToString() : Request.Form["ddlareacode_value"];
            string address = this.txtaddress.Text;
            int staffsize = TypeConverter.StrToInt(Request.Params["ddlstaffsize"].ToString());
            string regyear = this.txtregyear.Text;
            string regcity = Request.Form["ddlregcity"] == null ? Request.Form["ddlregcity"] == null ? "" : Request.Form["ddlregcity"].ToString() : Request.Form["ddlregcity"].ToString();
            string sell = "";
            string linkman = this.txtlinkman.Text;
            string phone = this.txtphone.Text;
            string mphone = this.txtmphone.Text;
            string fax = this.txtfax.Text;
            string email = this.txtemail.Text;
            string postcode = this.txtpostcode.Text;
            string homepage = this.txthomepage.Text;
            string thumb = this.hfthumb.Value;
            string bannel = this.hfbannel.Value;
            string descript = this.txtdescript.Text;
            DateTime lastedittime = DateTime.Now;
            int auditstatus = TypeConverter.StrToInt(ddlauditstatus.SelectedValue);

            //add:rafer
            //date:4-24
            //新增三证图片
            string license = hflicense.Value;
            string registration = hfregistration.Value;
            string organization = hforganization.Value;

            model.mid = mid;
            model.title = title;
            model.areacode = areacode;
            model.address = address;
            model.staffsize = staffsize;
            model.regyear = regyear;
            model.regcity = regcity;
            model.sell = sell;
            model.linkman = linkman;
            model.phone = phone;
            model.mphone = mphone;
            model.fax = fax;
            model.email = email;
            model.postcode = postcode;
            model.homepage = homepage;
            model.thumb = thumb;
            model.bannel = bannel;
            model.descript = descript;

            model.lastedid = model.mid;
            model.lastedittime = lastedittime;
            model.auditstatus = auditstatus;

            //add:rafer
            //date:4-24
            //新增三证图片
            model.license = license;
            model.registration = registration;
            model.organization = organization;
            #endregion

            int aid = ECCompany.EditCompany(model);
            #region 上传图片
          
            if (aid > 0)
            {
                ECUpLoad ecUpload = new ECUpLoad();

                if (thumb.Length > 0)
                {
                    ArrayList alst1 = new ArrayList();
                    alst1.Add(ecUpload._550_410);
                    alst1.Add(ecUpload._141_106);
                    ArrayList alst2 = new ArrayList();
                    alst2.Add(ecUpload._1_1);
                    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Company, aid, EnFilePath.Thumb), alst1, alst2, true);
                }
                if (bannel.Length > 0)
                {
                    ArrayList alst1 = new ArrayList();
                    alst1.Add(ecUpload._1_1);
                    ArrayList alst2 = new ArrayList();
                    alst2.Add(ecUpload._767_400);
                    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Company, aid, EnFilePath.Banner), alst1, alst2, true);
                }
                //add:rafer
                //date:4-24
                //新增三证图片
                if (license.Length > 0)
                {
                    ecUpload.MoveFiles(license.Split(','), string.Format(EnFilePath.Company, aid, EnFilePath.License));
                }
                if (registration.Length > 0)
                {
                    ecUpload.MoveFiles(registration.Split(','), string.Format(EnFilePath.Company, aid, EnFilePath.Registration));
                }
                if (organization.Length > 0)
                {
                    ecUpload.MoveFiles(organization.Split(','), string.Format(EnFilePath.Company, aid, EnFilePath.Organization));
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
                        ECCompany.UpConFilePath(ECommon.RepFilePathContent(model.descript, TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.Company, aid, EnFilePath.ConImage)), aid);
                        ecUpload.MoveContentFiles(strConFilePath.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.Company, aid, EnFilePath.ConImage));
                    }
                }
            #endregion

                // Response.Redirect("setup2.aspx");
                Response.Redirect("../index.aspx");
            }
        #endregion


        }
    }
}