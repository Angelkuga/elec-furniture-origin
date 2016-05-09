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
    public partial class advertisementcategoryinfo : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlParent.Items.Clear();
                ddlParent.DataSource = ECAdvertisementCategory.GetAdvertisementCategoryList(" parentid=0");
                ddlParent.DataTextField = "title";
                ddlParent.DataValueField = "id";
                ddlParent.DataBind();
                ddlParent.Items.Insert(0, new ListItem("一级分类", "0"));

                ddlModule.Items.Clear();
                ddlModule.DataSource = ECModule.GetModuleList(" mark not like '%sys_%' ");
                ddlModule.DataTextField = "title";
                ddlModule.DataValueField = "id";
                ddlModule.DataBind();
                ddlModule.Items.Insert(0, new ListItem("所有模块", "0"));

                ddlAdType.Items.Clear();
                WebControlBind.DrpBind(typeof(EnumAdvertisementinType), ddlAdType);

                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                EnAdvertisementCategory model = ECAdvertisementCategory.GetAdvertisementCategoryInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    ddlParent.SelectedValue = model.parentid.ToString();
                    ddlModule.SelectedValue = model.moduleid.ToString();


                    this.txttitle.Text = model.title;
                    this.txtimg.Text = model.img;
                    this.txtheight.Text = model.height.ToString();
                    this.txtwidth.Text = model.width.ToString();
                    this.txtdescript.Text = model.descript;
                    this.txttemplate.Text = model.template;
                    this.txtsort.Text = model.sort.ToString();

                    this.txttitle.Text = model.title;
                    this.txtimg.Text = model.img;
                    this.txtheight.Text = model.height.ToString();
                    this.txtwidth.Text = model.width.ToString();
                    this.raOpen.SelectedValue = model.isopen.ToString();
                    this.ddlAdType.SelectedValue = model.adtype.ToString();
                    this.txtstarttime.Text = model.starttime.ToString();
                    this.txtendtime.Text = model.endtime.ToString();
                    this.txtdescript.Text = model.descript;
                    this.txttemplate.Text = model.template;
                    this.txtsort.Text = model.sort.ToString();
                    this.txtstarttime.Text = model.starttime.ToString();
                    this.txtendtime.Text = model.endtime.ToString();

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnAdvertisementCategory model = new EnAdvertisementCategory();

            string strErr = "";


            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECAdvertisementCategory.GetAdvertisementCategoryInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);

            }
            else
            {
                model = new EnAdvertisementCategory();

            }

            int parentid = TypeConverter.StrToInt(ddlParent.SelectedValue);
            int moduleid = TypeConverter.StrToInt(ddlModule.SelectedValue);
            string modulevalue = "";
            string title = this.txttitle.Text;
            string img = this.txtimg.Text;
            int height = TypeConverter.StrToInt(this.txtheight.Text);
            int width = TypeConverter.StrToInt(this.txtwidth.Text);
            int isopen = TypeConverter.StrToInt(raOpen.SelectedValue);
            int adtype = TypeConverter.StrToInt(ddlAdType.SelectedValue);
            string descript = this.txtdescript.Text;
            string template = this.txttemplate.Text;
            int sort = TypeConverter.StrToInt(this.txtsort.Text);

            model.parentid = parentid;
            model.moduleid = moduleid;
            model.modulevalue = modulevalue;
            model.title = title;
            model.img = img;
            model.height = height;
            model.width = width;
            model.isopen = isopen;
            model.adtype = adtype;
            int psort = 0;
            int.TryParse(txtsort.Text, out psort);
            model.sort = psort;
            if (this.txtstarttime.Text != "" && this.txtendtime.Text != "")
            {
                model.starttime = DateTime.Parse(this.txtstarttime.Text);
                model.endtime = DateTime.Parse(this.txtendtime.Text);
            }
            else
            {
                model.starttime = DateTime.Parse("1900-1-1 00:00:00");
                model.endtime = DateTime.Parse("1900-1-1 00:00:00");
            }
            model.descript = descript;
            model.template = template;
            model.sort = sort;



            int aid = ECAdvertisementCategory.EditAdvertisementCategory(model);
            if (aid > 0)
            {
                UiCommon.JscriptPrint(this.Page, "编辑成功!", Request.Url.AbsoluteUri, "Success");
            }


        }
    }
}