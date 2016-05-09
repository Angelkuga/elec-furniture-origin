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

namespace TREC.Web.Suppler.brand
{
    public partial class brandinfo : SupplerPageBase
    {
        public string companyInfoid;

        public string areaCode = "";
        public EnCompany _companyInfo = null;
        public string myTitle = "添加";
        public int brandID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (memberInfo == null)
                {
                    Response.Write("<script>top.document.location.href='" + ECommon.WebUrl + "index.aspx" + "';</script>");
                    Response.End();
                }
                //选中左边菜单栏目
                Master.menuName = "brandlist";

                ddlspread.Items.Clear();
                ddlspread.DataSource = ECConfig.GetConfigList(" module=" + (int)EnumConfigModule.产品配置 + " and type=" + (int)EnumConfigByProduct.产品价位);
                ddlspread.DataTextField = "title";
                ddlspread.DataValueField = "value";
                ddlspread.DataBind();
                ddlspread.Items.Insert(0, new ListItem("请选择", ""));

                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                myTitle = "编辑";
                EnBrand model = ECBrand.GetBrandInfo("  where id=" + ECommon.QueryId);
                if (model != null)
                {
                    txttitle.Text = model.title;

                    this.ddlspread.SelectedValue = model.spread;
                    
                    this.hfsurface.Value = model.surface;
                    this.hflogo.Value = model.logo;
                    this.hfthumb.Value = model.thumb;
                    this.hfbannel.Value = model.bannel;
                    this.hfdesimage.Value = model.desimage;
                    this.txtdescript.Text = model.descript;
                    int cid = 0;
                    brandID = model.id;
                    if (SupplerPageBase.companyInfo != null)
                    {
                        cid = SupplerPageBase.companyInfo.id;
                        if (companyInfo != null)
                        {
                            companyInfoid = companyInfo.id.ToString();
                        }
                    }
                    SetPermission(model.createmid, cid, 0, 0, 0, model.id, (System.Web.UI.WebControls.WebControl)btnSave);

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            EnBrand model = null;

            string strErr = "";


            if (strErr != "")
            {
                //MessageBox.Show(this, strErr);
                return;
            }

            if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
            {
                model = ECBrand.GetBrandInfo("  where id=" + ECommon.QueryId);
                model.id = TypeConverter.StrToInt(ECommon.QueryId);
                if (model == null)
                {
                    model = new EnBrand();
                }

            }
            else
            {
                model = new EnBrand();
                model.createmid = 0;
                model.productcount = 0;
                model.createmid = memberInfo.id;
                model.attribute = "";
                model.keywords = "";
                model.template = "default";
                model.homepage = "";
                model.hits = 0;
                model.sort = 0;
                model.auditstatus = 0;
                model.linestatus = 0;

            }

            int companyid = 0;
            if (memberInfo.type == (int)EnumMemberType.工厂企业)
            {
                companyid = companyInfo.id;
            }
            else
            {
                //companyid = TypeConverter.StrToInt(hidd_company.Value);
                //_companyInfo = ECCompany.GetCompanyInfo(" where title='" + txtcompany.Text + "'");
                //if (_companyInfo == null)
                //{
                //    _companyInfo = new EnCompany();
                //    _companyInfo.lastedittime = DateTime.Now;
                //}
                //_companyInfo.title = txtcompany.Text;
                //companyid = ECCompany.EditCompany(_companyInfo);
            }


            string title = txttitle.Text;
            string letter = Hz2Py.Convert(title);
            string productcategory = "";

            string style = "";
            string material = "";
            string spread = ddlspread.SelectedValue;
            string color = "";


            string surface = this.hfsurface.Value;
            string logo = this.hflogo.Value;
            string thumb = this.hfthumb.Value;
            string bannel = this.hfbannel.Value;
            string desimage = this.hfdesimage.Value;
            string descript = this.txtdescript.Text;
            DateTime lastedittime = DateTime.Now;


            model.companyid = companyid;
            model.title = title;
            model.letter = letter;
            model.productcategory = productcategory;

            model.style = style;
            model.material = material;
            model.spread = spread;
            model.color = color;

            model.surface = surface;
            model.logo = logo;
            model.thumb = thumb;
            model.bannel = bannel;
            model.desimage = desimage;
            model.descript = descript;

            model.lastedittime = lastedittime;

            if (companyid > 0)
            {
                if (ChkBrand(model.title, model.companyid, SubmitMeth.getInt(ECommon.QueryId)))
                {
                    Response.Write("<script>alert('该品牌名称己存在！');window.history.back();</script>");
                    Response.End();
                }
            }

            int aid = ECBrand.EditBrand(model);

            #region 通知客服邮件
            if (model.id == 0)
            {
                string mailsubject = string.Format(@"
                        <p>商家: {0} 用户名：{5}</p>
                        <p>添加了品牌。</p>
                        <p>品牌id:{1}品牌名称:{2}</p>
                        <p>商家id:{3} 商家身份:{4}</p>"
                        , companyInfo.title, aid, model.title, companyInfo.id, memberInfo.type, memberInfo.username);
                string[] mailto = TREC.ECommerce.ECommon.ServiceMail.Split(',');
                foreach (string items in mailto)
                {
                    bool rsmail = EmailHelper.SendEmail("家具快搜 商家添加品牌通知提示", items, mailsubject);
                }
            }
            #endregion

            if (aid > 0)
            {
                #region 如果是经销商，则保存经销商申请的品牌
                if (memberInfo.type == 102)
                {
                    EnAppBrand appmodel = new EnAppBrand();
                    appmodel.id = 0;
                    appmodel.dealerid = dealerInfo.id;
                    appmodel.dealetitle = dealerInfo.title;
                    appmodel.brandid = aid;
                    appmodel.brandtitle = title;
                    appmodel.companyid = 0;
                    appmodel.companytitle = "";
                    appmodel.shopid = 0;
                    appmodel.shoptitle = "";
                    appmodel.appmodule = (int)EnumAppBrandModule.经销商申请;
                    appmodel.apptype = (int)EnumAppBrandType.申请新建品牌;
                    appmodel.apptime = DateTime.Now;
                    appmodel.createmid = memberInfo.id;
                    appmodel.lastedittime = DateTime.Now;
                    appmodel.auditstatus = 0;
                    ECAppBrand.EditAppBrand(appmodel);
                }

                #endregion

                ECUpLoad ecUpload = new ECUpLoad();


                if (surface.Length > 0)
                {
                    surface = surface.StartsWith(",") ? surface.Substring(1, surface.Length - 1) : surface;
                    surface = surface.EndsWith(",") ? surface.Substring(0, surface.Length - 1) : surface;
                    ArrayList alst1 = new ArrayList();
                    alst1.Add(ecUpload._196_70);
                    ArrayList alst2 = new ArrayList();
                    alst2.Add(ecUpload._1_1);
                    ecUpload.MoveFiles(surface.Split(','), string.Format(EnFilePath.Brand, aid, EnFilePath.Surface));
                }
                if (thumb.Length > 0)
                {
                    ArrayList alst1 = new ArrayList();
                    alst1.Add(ecUpload._550_410);
                    alst1.Add(ecUpload._141_106);
                    ArrayList alst2 = new ArrayList();
                    alst2.Add(ecUpload._1_1);
                    ecUpload.MoveFiles(thumb.Split(','), string.Format(EnFilePath.Brand, aid, EnFilePath.Thumb), alst1, alst2, true);
                }
                if (logo.Length > 0)
                {
                    ArrayList alst1 = new ArrayList();
                    alst1.Add(ecUpload._196_70);
                    ArrayList alst2 = new ArrayList();
                    alst2.Add(ecUpload._1_1);
                    ecUpload.MoveFiles(logo.Split(','), string.Format(EnFilePath.Brand, aid, EnFilePath.Logo), alst1, alst2, true);
                }
                if (bannel.Length > 0)
                {
                    ecUpload.MoveFiles(bannel.Split(','), string.Format(EnFilePath.Brand, aid, EnFilePath.Banner));
                }
                if (desimage.Length > 0)
                {
                    ecUpload.MoveFiles(desimage.Split(','), string.Format(EnFilePath.Brand, aid, EnFilePath.DesImage));
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
                        ECBrand.UpConFilePath(ECommon.RepFilePathContent(model.descript, TREC.Entity.EnFilePath.tmpRootPath, string.Format(EnFilePath.Brand, aid, EnFilePath.ConImage)), aid);
                        ecUpload.MoveContentFiles(strConFilePath.Replace(TREC.Entity.EnFilePath.tmpRootPath, "").Split(','), string.Format(EnFilePath.Brand, aid, EnFilePath.ConImage));
                    }
                }

                Response.Write("<script>alert('保存品牌信息成功！');location.href='brandlist.aspx';</script>");
            }
        }

        /// <summary>
        /// 检查厂商品牌重复
        /// </summary>
        /// <param name="title">品牌名</param>
        /// <param name="comid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ChkBrand(string title, int? comid, int id)
        {
            string sql = string.Format(" where companyid={0} and id<>{1} and title='{2}' ", comid.ToString(), id.ToString(), title.Trim());
            if (ECBrand.GetBrandInfo(sql) == null)
                return false;
            return true;
        }
    }
}