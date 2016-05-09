using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;


namespace TREC.Web.Admin.advertisement
{
    public partial class advertisementinfo : AdminPageBase
    {
        /// <summary>
        /// 上传方式的图片=1
        /// </summary>
        protected int _isuplodimg = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategory.Items.Clear();
                List<EnAdvertisementCategory> list = ECAdvertisementCategory.GetAdvertisementCategoryList(" isopen=1").OrderBy(c => c.title).ToList();
                foreach (EnAdvertisementCategory ac in list)
                {
                    if (ac.parentid != 0)
                    {
                        ac.title = "|--" + ac.title;
                    }

                }
                ddlCategory.DataSource = list;
                ddlCategory.DataTextField = "title";
                ddlCategory.DataValueField = "id";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("请选择", "0"));
                if (ECommon.QueryCId != "")
                {
                    ddlCategory.SelectedValue = ECommon.QueryCId;
                }



                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnAdvertisement model = ECAdvertisement.GetAdvertisementInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    this.ddlCategory.SelectedValue = model.categoryid.ToString();
                    this.txttitle.Text = model.title;
                    this.txtlinkurl.Text = model.linkurl;
                    this.txtflashurl.Text = model.flashurl;
                    this.hfimgurl.Value = model.imgurl;
                    this.txtadtext.Text = model.adtext;
                    this.txtadcode.Text = model.adcode;
                    this.txtvideourl.Text = model.videourl;
                    this.raOpen.SelectedValue = model.isopen.ToString();
                    this.txtadlinkman.Text = model.adlinkman;
                    this.txtadlinkphone.Text = model.adlinkphone;
                    this.txtadlinkemail.Text = model.adlinkemail;
                    this.txtimgurlfull.Text = model.ImgUrlFull;
                    this.txtprice.Text = model.Price;
                    this.txtprodID.Text = model.adcode;
                    this.txtendtime.Text = model.EndTime.ToString();
                    this.txtstarttime.Text = model.StarTtime.ToString();
                    this.txtsort.Text = model.Sort.ToString();
                    this.txtorgprice.Text = model.OrgPrice;

                    lbOther.Text = "最后修改时间：" + model.lastedittime.ToString() + "    " + "最后修改人：" + model.lasteditaid.ToString();
                    if (!string.IsNullOrEmpty(model.imgurl))
                    {
                        _isuplodimg = 1;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnAdvertisement model = new EnAdvertisement();

            string strErr = "";


            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECAdvertisement.GetAdvertisementInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);

            }
            else
            {
                model = new EnAdvertisement();

            }

            int categoryid = TypeConverter.StrToInt(ddlCategory.SelectedValue);
            string title = this.txttitle.Text;
            string linkurl = this.txtlinkurl.Text;
            string flashurl = this.txtflashurl.Text;
            string imgurl = this.hfimgurl.Value;
            string adtext = this.txtadtext.Text;
            string adcode = this.txtadcode.Text;
            string videourl = this.txtvideourl.Text;
            int isopen = TypeConverter.StrToInt(this.raOpen.SelectedValue);
            string adlinkman = this.txtadlinkman.Text;
            string adlinkphone = this.txtadlinkphone.Text;
            string adlinkemail = this.txtadlinkemail.Text;
            DateTime lastedittime = DateTime.Now;
            int lasteditaid = 0;
            if (title == "")
            {
                Response.Write("<script>alert('广告名称必须填写');window.history.go(-1);</script>");
                Response.End();
            }

            model.categoryid = categoryid;
            model.title = title;
            model.videourl = videourl;
            model.linkurl = linkurl;
            model.flashurl = flashurl;
            model.imgurl = imgurl;
            model.adtext = adtext;
            model.adcode = adcode;
            model.isopen = isopen;
            model.adlinkman = adlinkman;
            model.adlinkphone = adlinkphone;
            model.adlinkemail = adlinkemail;
            model.lastedittime = lastedittime;
            model.lasteditaid = lasteditaid;
            model.adcode = this.txtprodID.Text;
            model.Price = this.txtprice.Text;
            model.OrgPrice = this.txtorgprice.Text;

            int psort = 0;
            int.TryParse(txtsort.Text, out psort);
            model.Sort = psort;
            if (this.txtstarttime.Text != "" && this.txtendtime.Text != "")
            {
                model.StarTtime = DateTime.Parse(this.txtstarttime.Text);
                model.EndTime = DateTime.Parse(this.txtendtime.Text);
            }
            else
            {
                model.StarTtime = DateTime.Now;
                model.EndTime = DateTime.Now;
            }
            if (!string.IsNullOrEmpty(this.txtimgurlfull.Text))
            {
                model.ImgUrlFull = this.txtimgurlfull.Text;
            }

            int aid = ECAdvertisement.EditAdvertisement(model);
            if (aid > 0)
            {
                //上图的图片地址更新到完整路径里
                if (!string.IsNullOrEmpty(hfimgurl.Value))
                {
                    EnAdvertisement setimgfull = ECAdvertisement.GetAdvertisementInfo(string.Format(" where id = {0}", aid));
                    setimgfull.ImgUrlFull = string.Format(EnFilePath.Ad, setimgfull.id, EnFilePath.Thumb).TrimEnd('/') + '/' + imgurl.TrimEnd(',');
                    ECAdvertisement.EditAdvertisement(setimgfull);
                }

                ECUpLoad ecUpload = new ECUpLoad();
                if (imgurl.Length > 0)
                {
                    imgurl = imgurl.StartsWith(",") ? imgurl.Substring(1, imgurl.Length - 1) : imgurl;
                    imgurl = imgurl.EndsWith(",") ? imgurl.Substring(0, imgurl.Length - 1) : imgurl;
                    ecUpload.MoveFiles(imgurl.Split(','), string.Format(EnFilePath.Ad, aid, EnFilePath.Thumb));
                }
                Response.Redirect("advertisementlist.aspx");
            }


        }
    }
}