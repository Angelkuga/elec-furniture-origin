using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;

namespace TREC.Web.Admin.information
{
    public partial class promotionsinfo : AdminPageBase
    {
        protected Dpromotions dpromotions = new Dpromotions();
        protected Mpromotions mpromotions = null;
        protected Mmember memberInfo = null;
        protected Mcompany companyInfo = new Mcompany();
        protected Mdealer dealerInfo = new Mdealer();
        protected Mmarket marketInfo = new Mmarket();
        protected int PKID = TRECommon.WebRequest.GetQueryInt("id");
        protected int memberId = TRECommon.WebRequest.GetQueryInt("memberId");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PKID > 0 && memberId > 0)
            {
                Response.Redirect(Request.UrlReferrer.ToString());
                return;
            }
            if (PKID <= 0 && memberId <= 0)
            {
                Response.Redirect("selectmember.aspx?display=" + ECommon.QuerySearchDisplay);
                return;
            }
            if (PKID > 0 || memberId > 0)
            {
                loadInfo();
            }
            if (!IsPostBack)
            {
                loadOptions();
                if (PKID > 0 || memberId > 0)
                {
                    showData();
                }
            }
        }
        void loadInfo()
        {
            int mid = 0;
            if (memberId <= 0)
            {
                mpromotions = dpromotions.Linq.Where(c => c.id == PKID).FirstOrDefault();
                if (mpromotions != null)
                {
                    mid = mpromotions.mid;
                }
            }
            else
            {
                mid = memberId;
            }
            if (mid > 0)
            {
                memberInfo = dpromotions.LinqData<Mmember>().Where(c => c.id == mid).FirstOrDefault();
                if (memberInfo != null)
                {
                    if (memberInfo.type == (int)EnumMemberType.工厂企业)
                    {
                        companyInfo = dpromotions.LinqData<Mcompany>().Where(c => c.mid == mid).FirstOrDefault();
                    }
                    else if (memberInfo.type == (int)EnumMemberType.经销商)
                    {
                        dealerInfo = dpromotions.LinqData<Mdealer>().Where(c => c.mid == mid).FirstOrDefault();
                    }
                    else if (memberInfo.type == (int)EnumMemberType.卖场)
                    {
                        marketInfo = dpromotions.LinqData<Mmarket>().Where(c => c.mid == mid).FirstOrDefault();
                    }
                }
            }
        }
        void loadOptions()
        {
            ddlauditstatus.Items.Clear();
            WebControlBind.DrpBind(typeof(EnumAuditStatus), ddlauditstatus);
            ddlauditstatus.Items.Insert(0, new ListItem("请选择", ""));

            ddllinestatus.Items.Clear();
            WebControlBind.DrpBind(typeof(EnumLineStatus), ddllinestatus);
            ddllinestatus.Items.Insert(0, new ListItem("请选择", ""));

            ddlmembertype.Items.Clear();
            WebControlBind.DrpBind(typeof(EnumMemberType), ddlmembertype);
            ddlmembertype.Items.Insert(0, new ListItem("请选择", ""));
        }
        void loadshopmarketItem()
        {
            if (memberInfo == null) return;
            if (memberInfo.type == (int)EnumMemberType.工厂企业)
            {
                if (companyInfo != null)
                {
                    var cid = companyInfo.id;
                    var shoplist = dpromotions.LinqData<Mshop>().Where(c => c.auditstatus == 1).Select(c => new { c.id, c.title }).ToArray();
                    if (shoplist.Count() == 0)
                    {
                        UiCommon.JscriptPrint(this.Page, "该会员必须有了店铺并且审核上线后才能添加", Request.UrlReferrer.ToString(), "Error");
                        return;
                    }
                    chkshoplist.Items.AddRange(shoplist.Select(c => new ListItem { Value = c.id.ToString(), Text = c.title }).ToArray());
                }
            }
            else if (memberInfo.type == (int)EnumMemberType.经销商)
            {
                if (dealerInfo != null)
                {
                    var cid = dealerInfo.id;
                    var shoplist = dpromotions.LinqData<Mshop>().Where(c => c.auditstatus == 1).Select(c => new { c.id, c.title }).ToArray();
                    if (shoplist.Count() == 0)
                    {
                        UiCommon.JscriptPrint(this.Page, "该会员必须有了店铺并且审核上线后才能添加", Request.UrlReferrer.ToString(), "Error");
                        return;
                    }
                    chkshoplist.Items.AddRange(shoplist.Select(c => new ListItem { Value = c.id.ToString(), Text = c.title }).ToArray());
                }
            }
            else if (memberInfo.type == (int)EnumMemberType.卖场)
            {
                if (marketInfo != null)
                {
                    var marketid = marketInfo.id;
                    var marketstorylist = dpromotions.LinqData<Mmarketstorey>().Where(c => c.marketid == marketid).OrderBy(c => c.sort);
                    rmarketstoreylist.Items.Add(new ListItem { Value = "0", Text = "全部楼层" });
                    rmarketstoreylist.Items.AddRange(marketstorylist.Select(c => new ListItem { Value = c.id.ToString(), Text = c.title }).ToArray());
                }
            }
        }
        void showData()
        {
            //loadshopmarketItem();
            if (mpromotions != null)
            {
                tbTitle.Text = mpromotions.title;
                tbLetter.Text = mpromotions.letter;
                cbIsTop.Checked = mpromotions.IsTop;
                cbIsRecommend.Checked = mpromotions.IsRecommend;
                cbIsHot.Checked = mpromotions.IsHot;
                cbIsEssence.Checked = mpromotions.IsEssence;
                cbIsSlide.Checked = mpromotions.IsSlide;
                cbIsHighlight.Checked = mpromotions.IsHighlight;
                tbStartdatetime.Text = mpromotions.startdatetime.ToString("yyyy-MM-dd");
                tbEnddatetime.Text = mpromotions.enddatetime.ToString("yyyy-MM-dd");
                tbDescript.Text = mpromotions.descript;
                ddlauditstatus.SelectedValue = mpromotions.auditstatus.ToString();
                ddllinestatus.SelectedValue = mpromotions.linestatus.ToString();
                tbsort.Text = mpromotions.sort.ToString();
                hfsurface.Value = mpromotions.surface;
                //保存商务类型
                switch (mpromotions.attribute)
                {
                    case "促销":
                        infoType.SelectedValue = "1";
                        break;
                    case "活动":
                        infoType.SelectedValue = "2";
                        break;
                    case "新闻":
                        infoType.SelectedValue = "3";
                        break;
                    case "招商":
                        infoType.SelectedValue = "4";
                        break;
                    default:
                        infoType.SelectedValue = "5";
                        break;
                }
            }
            ddlmembertype.SelectedValue = memberInfo.type.ToString();
            tbusername.Text = memberInfo.username;
            tbuserid.Text = memberInfo.id.ToString();
            if (chkshoplist.Items.Count > 0 || rmarketstoreylist.Items.Count > 0)
            {
                var idlist = dpromotions.LinqData<Mpromotionsrelated>().Where(c => c.promotionsid == PKID && c.mid == memberInfo.id).Select(c => new { c.shopid, c.marketstoreyid }).ToArray();
                foreach (ListItem item in chkshoplist.Items)
                {
                    if (idlist.Any(c => c.shopid.ToString() == item.Value))
                    {
                        item.Selected = true;
                    }
                }
                foreach (ListItem item in rmarketstoreylist.Items)
                {
                    if (idlist.Any(c => c.marketstoreyid.ToString() == item.Value))
                    {
                        item.Selected = true;
                    }
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTitle.Text))
            {
                UiCommon.JscriptPrint(this.Page, "请输入促销标题", "#", "Error");
                return;
            }
            if (string.IsNullOrEmpty(ddlauditstatus.SelectedValue))
            {
                UiCommon.JscriptPrint(this.Page, "请选择审核状态", "#", "Error");
                return;
            }
            if (string.IsNullOrEmpty(ddllinestatus.SelectedValue))
            {
                UiCommon.JscriptPrint(this.Page, "请选择上下线状态", "#", "Error");
                return;
            }
            //if (memberInfo.type == (int)EnumMemberType.工厂企业 || memberInfo.type == (int)EnumMemberType.经销商)
            //{
            //    if (string.IsNullOrEmpty(chkshoplist.SelectedValue))
            //    {
            //        UiCommon.JscriptPrint(this.Page, "请选择所在店铺", "#", "Error");
            //        chkshoplist.Style[HtmlTextWriterStyle.BackgroundColor] = System.Drawing.Color.Red.Name;
            //        chkshoplist.Style[HtmlTextWriterStyle.Display] = "inline-block";
            //        return;
            //    }
            //    chkshoplist.Style[HtmlTextWriterStyle.BackgroundColor] = "";
            //}
            //else if (memberInfo.type == (int)EnumMemberType.卖场)
            //{
            //    if (string.IsNullOrEmpty(rmarketstoreylist.SelectedValue))
            //    {
            //        UiCommon.JscriptPrint(this.Page, "请选择所在店铺", "#", "Error");
            //        rmarketstoreylist.Style[HtmlTextWriterStyle.BackgroundColor] = System.Drawing.Color.Red.Name;
            //        rmarketstoreylist.Style[HtmlTextWriterStyle.Display] = "inline-block";
            //        return;
            //    }
            //    rmarketstoreylist.Style[HtmlTextWriterStyle.BackgroundColor] = "";
            //}
            var stDate = new DateTime();
            if (string.IsNullOrEmpty(tbStartdatetime.Text) || !DateTime.TryParse(tbStartdatetime.Text, out stDate))
            {
                UiCommon.JscriptPrint(this.Page, "开始时间没填写或格式不正确！", "#", "Error");
                return;
            }
            var eDate = new DateTime();
            if (string.IsNullOrEmpty(tbEnddatetime.Text) || !DateTime.TryParse(tbEnddatetime.Text, out eDate))
            {
                UiCommon.JscriptPrint(this.Page, "结束时间没填写或格式不正确！", "#", "Error");
                return;
            }
            if (stDate > eDate)
            {
                UiCommon.JscriptPrint(this.Page, "开始时间不能大于结束时间！", "#", "Error");
                return;
            }
            Dpromotionsrelated dpromotionsrelated = new Dpromotionsrelated(dpromotions);
            Mpromotions m = new Mpromotions();
            m.title = tbTitle.Text;
            m.htmltitle = tbTitle.Text;
            m.letter = tbLetter.Text;
            m.IsTop = cbIsTop.Checked;
            m.IsRecommend = cbIsRecommend.Checked;
            m.IsHot = cbIsHot.Checked;
            m.IsEssence = cbIsEssence.Checked;
            m.IsSlide = cbIsSlide.Checked;
            m.IsHighlight = cbIsHighlight.Checked;
            m.descript = tbDescript.Text;
            m.startdatetime = TRECommon.TypeConverter.StrToDateTime(tbStartdatetime.Text);
            m.enddatetime = TRECommon.TypeConverter.StrToDateTime(tbEnddatetime.Text);
            m.auditstatus = TRECommon.TypeConverter.StrToInt(ddlauditstatus.SelectedValue);
            m.linestatus = TRECommon.TypeConverter.StrToInt(ddllinestatus.SelectedValue);
            m.sort = TRECommon.TypeConverter.StrToInt(tbsort.Text);
            dpromotions.BeginTransaction();
            try
            {
                if (PKID > 0)
                {
                    m.lastedadminid = adminId;
                    m.lastedadmintime = DateTime.Now;
                    dpromotions.Update(m, c => c.id == PKID);
                }
                else
                {
                    m.mid = memberInfo.id;
                    m.membertype = memberInfo.type;
                    m.lastedmid = memberInfo.id;
                    m.lastedmtime = DateTime.Now;
                    m.createtime = DateTime.Now;
                    dpromotions.Insert(m, out PKID);
                }
                dpromotionsrelated.Delete(c => c.promotionsid == PKID);
                if (memberInfo.type == (int)EnumMemberType.工厂企业 || memberInfo.type == (int)EnumMemberType.经销商)
                {
                    foreach (ListItem item in chkshoplist.Items)
                    {
                        if (item.Selected)
                        {
                            var shopid = TRECommon.TypeConverter.StrToInt(item.Value);
                            var shopmodel = dpromotions.LinqData<Mshop>().FirstOrDefault(c => c.id == shopid);
                            if (shopmodel != null)
                            {
                                Mpromotionsrelated mpromotionsrelated = new Mpromotionsrelated();
                                mpromotionsrelated.promotionsid = PKID;
                                mpromotionsrelated.promotionstitle = m.title;
                                mpromotionsrelated.mid = memberInfo.id;
                                mpromotionsrelated.membertype = memberInfo.type;
                                mpromotionsrelated.shopid = shopid;
                                mpromotionsrelated.shoptitle = item.Text;
                                mpromotionsrelated.shopareacode = shopmodel.areacode == null ? "" : shopmodel.areacode;
                                mpromotionsrelated.shopaddress = shopmodel.address;
                                dpromotionsrelated.Insert(mpromotionsrelated);
                            }
                        }
                    }
                }
                else if (memberInfo.type == (int)EnumMemberType.卖场)
                {
                    var marketmodel = dpromotions.LinqData<Mmarket>().FirstOrDefault(c => c.id == marketInfo.id);
                    if (marketmodel != null)
                    {
                        Mpromotionsrelated mpromotionsrelated = new Mpromotionsrelated();
                        mpromotionsrelated.promotionsid = PKID;
                        mpromotionsrelated.promotionstitle = m.title;
                        mpromotionsrelated.mid = memberInfo.id;
                        mpromotionsrelated.membertype = memberInfo.type;
                        mpromotionsrelated.marketid = marketmodel.id;
                        mpromotionsrelated.markettitle = marketmodel.title;
                        mpromotionsrelated.marketareacode = marketmodel.areacode == null ? "" : marketmodel.areacode;
                        mpromotionsrelated.marketaddress = marketmodel.address == null ? "" : marketmodel.address;
                        mpromotionsrelated.marketstoreyid = TRECommon.TypeConverter.StrToInt(rmarketstoreylist.SelectedValue);
                        dpromotionsrelated.Insert(mpromotionsrelated);
                    }
                }
                dpromotions.CommitTransaction();
            }
            catch (Exception ex)
            {
                dpromotions.RollbackTransaction();
                UiCommon.JscriptPrint(this.Page, ex.Message, "#", "Error");
                return;
            }
            UiCommon.JscriptPrint(this.Page, "保存成功!", Request.Url.AbsoluteUri, "Success");
        }
    }
}
