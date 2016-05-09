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


namespace TREC.Web.Suppler.company
{
    public partial class companyinfo : SupplerPageBase
    {
        public string areaCode = "";
        public EnMember _memberInfo = null;
        protected string myName = string.Empty;
        protected int memberType = 0;
        protected string address = string.Empty;
        protected string postcode = string.Empty;
        protected string linkman = string.Empty;
        protected string phone = string.Empty;
        protected string mphone = string.Empty;
        protected string fax = string.Empty;
        protected string email = string.Empty;
        protected string homepage = string.Empty;
        protected string QQWeiBo = string.Empty;
        protected string Duty = string.Empty;
        protected string cPerson = string.Empty;
        protected string ContactType = string.Empty;
        protected string BrandInfo = string.Empty;
        public string droparea;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (memberInfo == null)
                {
                    Response.Write("<script>top.document.location.href='" + ECommon.WebUrl + "index.aspx" + "';</script>");
                    Response.End();
                }
                else
                    memberType = memberInfo.type;
                //选中左边菜单栏目
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

                ShowData();
            }
        }
        #region 显示数据

        protected void ShowData()
        {
            EnCompany model = ECCompany.GetCompanyInfo("  where id=" + companyInfo.id);
            if (model != null)
            {
                myName = model.title;
                areaCode = model.areacode;
                address = model.address.Replace(" ", "").Replace(TREC.ECommerce.ECommon.getAreaAll(model.areacode), "");
                this.ddlstaffsize.SelectedValue = model.staffsize.ToString();
                linkman = model.linkman;
                phone = model.phone;
                mphone = model.mphone;
                fax = model.fax;
                email = model.email;
                postcode = model.postcode;
                homepage = string.IsNullOrEmpty(model.homepage) ? "http://" : model.homepage;
                //this.hfthumb.Value = model.thumb;
                this.hfbannel.Value = model.bannel;
                //add:rafer
                //date:4-24
                //新增三证图片
                this.hflicense.Value = model.license;
                this.hfregistration.Value = model.registration;
                this.hforganization.Value = model.organization;

                this.txtdescript.Text = model.descript;
                //QQ/微博
                if (!string.IsNullOrEmpty(model.QQWeiBo))
                    QQWeiBo = model.QQWeiBo.Trim();
                //职位
                if (!string.IsNullOrEmpty(model.Duty))
                    Duty = model.Duty.Trim();
                //负责人
                if (!string.IsNullOrEmpty(model.cPerson))
                    cPerson = model.cPerson.Trim();
                //联系方式
                if (!string.IsNullOrEmpty(model.ContactType))
                    ContactType = model.ContactType.Trim();
                //厂家注册时品牌信息`
                if (!string.IsNullOrEmpty(model.BrandInfo))
                    BrandInfo = model.BrandInfo.Trim();


                EnArea _area3 = new EnArea();
                EnArea _area2 = new EnArea();
                try
                {
                    _area3 = ECArea.GetAreaList("areacode='" + model.areacode + "'").FirstOrDefault();
                    if (_area3 != null)
                    {
                        _area2 = ECArea.GetAreaList("areacode='" + _area3.parentcode + "'").FirstOrDefault();
                    }



                    string pcode = _area2.parentcode == "0" ? _area2.areacode : _area2.parentcode;
                    ddlPro.SelectedIndex = -1;
                    ddlPro.Items.FindByValue(pcode).Selected = true;

                    ddlregcity.Items.Clear();
                    ddlregcity.DataSource = ECArea.GetAreaList("parentcode='" + _area2.parentcode + "'");
                    ddlregcity.DataTextField = "areaname";
                    ddlregcity.DataValueField = "areacode";
                    ddlregcity.DataBind();
                    ddlregcity.SelectedIndex = -1;
                    ddlregcity.Items.FindByValue(_area2.areacode).Selected = true;

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
                }
                catch
                {
                }
             }
                else
                {
                    droparea="<option selected=\"selected\" value=\"0\">--区--</option>";
                }
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnCompany model = ECCompany.GetCompanyInfo("  where id=" + companyInfo.id);


            if (model == null)
            {
                model = new EnCompany();
                model.mapapi = "";
                model.createmid = 0;
            }

            #region 接收参数

            int mid = memberInfo.id;
            string title = Request.Form["myName"].Trim();
            string areacode = Request["selArea"];
            string address = Request.Form["Address"].Trim();
            int staffsize = 0;
            string regyear = "";
            string regcity = ddlregcity.SelectedValue;
            string sell = "";
            string linkman = Request.Form["Contact"].Trim();
            string phone = Request.Form["Tel"].Trim();
            string mphone = Request.Form["Mobile"];
            string fax = Request.Form["Fax"].Trim();
            string email = Request.Form["Email"].Trim();
            string postcode = Request.Form["Post"].Trim();
            string homepage = Request.Form["Website"].Trim(); 
            //string thumb = this.hfthumb.Value;
            string thumb = "";
            string bannel = this.hfbannel.Value;
            string descript = this.txtdescript.Text;
            DateTime lastedittime = DateTime.Now;
            int auditstatus = model.auditstatus;
            #endregion

            //add:rafer
            //date:4-24
            //新增三证图片
            string license = hflicense.Value;
            string registration = hfregistration.Value;
            string organization = hforganization.Value;
            #region 赋值

            model.mid = mid;
            model.title = title;
            model.areacode = areacode;
            model.address = address;
            if (!string.IsNullOrEmpty(ddlstaffsize.SelectedValue))
                staffsize = Convert.ToInt16(ddlstaffsize.SelectedValue);
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
            //QQ/微博
            model.QQWeiBo = Request.Form["QQWeiBo"].Trim();
            //职位
            model.Duty = Request.Form["Duty"].Trim();
            //负责人
            model.cPerson = Request.Form["cPerson"].Trim();
            //联系方式
            model.ContactType = Request.Form["ContactType"].Trim();
            //联系方式
            model.BrandInfo = Request.Form["BrandInfo"].Trim();
            #endregion

            int aid = ECCompany.EditCompany(model);
            if (aid > 0)
            {
                //清除关联的Cache
                if ((EnWebCompany)DataCache.GetCache("companywhereid=" + aid) != null)
                {
                    DataCache.Remove("companywhereid=" + aid);//前台工厂信息需要查询的
                }



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
                Response.Write("<script>alert('保存基本信息成功！');location.href='companyinfo.aspx';</script>");
            }
        }
    }
}