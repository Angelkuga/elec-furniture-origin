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

namespace TREC.Web.Suppler.f_dealer
{
    public partial class setup1 : SupplerPageBase
    {
        public string areaCode = "";
        public EnMember _memberInfo = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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



                //ShowData();
            }
        }
        #region 读取显示数据
        
        protected void ShowData()
        {
            EnDealer model = ECDealer.GetDealerInfo("  where id=" + dealerInfo.id);
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

                this.hfDBook.Value = model.dbook;

                this.txtdescript.Text = model.descript;
                this.ddlauditstatus.SelectedValue = model.auditstatus.ToString();

            }
        }
        #endregion


        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Modify：rafer
            //Date：2012-4-20
            EnDealer model = null;// ECDealer.GetDealerInfo("  where id=" + dealerInfo.id);

            if (model == null)
            {
                model = new EnDealer();
                model.mapapi = "";
                model.createmid = 0;
            }

            #region 接受输入参数，并为其赋值

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

            string dbook = this.hfDBook.Value;
           
            #endregion

            #region 实体赋值

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

            model.dbook = dbook;
            #endregion

            int aid = ECDealer.EditDealer(model);

            //Modify :rafer
            //date   :2012-4-25
            //Remarks:注册邮件
            EmailHelper.SendEmailReg(txttitle.Text, email, "经销商", phone, linkman, null);

            if (aid > 0)
            {
                #region 上傳圖片
                
                ECUpLoad ecUpload = new ECUpLoad();

                if (thumb.Length > 0)
                {
                    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Dealer, aid, EnFilePath.Thumb));
                }
                if (bannel.Length > 0)
                {
                    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Dealer, aid, EnFilePath.Banner));
                }
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
                #endregion
                              //  Response.Redirect("setup2.aspx");
                Response.Redirect("../index.aspx");
            }


        }
    }
}
