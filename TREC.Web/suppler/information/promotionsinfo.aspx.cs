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
using System.Data.Linq;

namespace TREC.Web.Suppler.information
{
    public partial class promotionsinfo : SupplerPageBase
    {
        Dpromotions dpromotions = new Dpromotions();
        public Mpromotions mpromotions = new Mpromotions();
        public int PKID = TRECommon.WebRequest.GetQueryInt("id");
        public int? Type = null;
        protected string shopList = string.Empty;//店铺      
        protected int iType = 0;//信息类型
        protected int infoId = 0;//商务信息id
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (!SupplerPageBase.IsPayMember())
                //{
                //    Response.Redirect("/suppler/Payment/RegPayment.aspx");
                //}
                string memberId = CookiesHelper.GetCookie("mid");
                if (string.IsNullOrEmpty(memberId))
                {
                    Response.Write("<script>top.document.location.href='" + ECommon.WebUrl + "index.aspx" + "';</script>");
                    Response.End();
                }
                //选中左边菜单栏目
                Master.menuName = "informationinfo";
                //loadOptions();
                loadData(memberId);
            }
        }

        void loadOptions()
        {
            if (memberInfo.type == (int)EnumMemberType.工厂企业)
            {
                //var shoplist = dpromotions.LinqData<Mshop>().Where(c => c.auditstatus == 1 && c.linestatus == 1 && c.cid == companyInfo.id && c.ctype == memberInfo.type).Select(c => new { id = c.id, title = c.title }).ToArray();
                var shoplist = dpromotions.LinqData<Mshop>().Where(c => c.createmid == memberInfo.id && c.auditstatus == 1 && c.linestatus == 1).Select(c => new { id = c.id, title = c.title }).ToArray();
                if (shoplist.Count() == 0)
                {
                    // UiCommon.JscriptPrint(this.Page, "请您先添加店铺，审核上线后您才获得添加促销信息权限！", "promotionslist.aspx", "Error");
                    Response.Write("<script>alert('请您先添加店铺，审核上线后您才获得添加促销信息权限！！');location.href='promotionslist.aspx';</script>");
                    return;
                }
                // chkshoplist.Items.AddRange(shoplist.Select(c => new ListItem { Value = c.id.ToString(), Text = c.title }).ToArray());
            }
            else if (memberInfo.type == (int)EnumMemberType.经销商)
            {
                //var shoplist = dpromotions.LinqData<Mshop>().Where(c => c.auditstatus == 1 && c.linestatus == 1 && c.cid == dealerInfo.id && c.ctype == memberInfo.type).Select(c => new { id = c.id, title = c.title }).ToArray();
                var shoplist = dpromotions.LinqData<Mshop>().Where(c => c.createmid == memberInfo.id && c.auditstatus == 1 && c.linestatus == 1).Select(c => new { id = c.id, title = c.title }).ToArray();
                if (shoplist.Count() == 0)
                {
                    Response.Write("<script>alert('请您先添加店铺，审核上线后您才获得添加促销信息权限！！');location.href='promotionslist.aspx';</script>");
                    return;
                }
                // chkshoplist.Items.AddRange(shoplist.Select(c => new ListItem { Value = c.id.ToString(), Text = c.title }).ToArray());
            }
            else if (memberInfo.type == (int)EnumMemberType.卖场)
            {
                var marketstorylist = dpromotions.LinqData<Mmarketstorey>().Where(c => c.marketid == marketInfo.id).OrderBy(c => c.sort);
                rmarketstoreylist.Items.Add(new ListItem { Value = "0", Text = "全部楼层" });
                rmarketstoreylist.Items.AddRange(marketstorylist.Select(c => new ListItem { Value = c.id.ToString(), Text = c.title }).ToArray());
            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="memberId">会员号</param>
        public void loadData(string memberId)
        {
            //选择店铺
            int shopRecord = 0;
            List<EnShop> shopList = ECShop.GetShopList(" createmid = " + memberId.ToString(), out shopRecord);
            if (shopList != null)
            {
                if (0 < shopRecord)
                {
                    chkshoplist.DataTextField = "title";
                    chkshoplist.DataValueField = "Id";
                    chkshoplist.DataSource = shopList;
                    chkshoplist.DataBind();
                }
                else
                {
                    lb_hidTip.Text = "请先创建店铺！";
                }
                shopList.Clear();
                shopList = null;

            }
            else
            {
                //lb_hidTip.Enabled = true;
                lb_hidTip.Text = "请先创建店铺！";
            }

            if (PKID <= 0) return;
            mpromotions = dpromotions.Linq.FirstOrDefault(c => c.id == PKID);
            if (mpromotions != null)
            {
                tbTitle.Text = mpromotions.title;
                tbDescript.Text = mpromotions.descript;
                tbStartdatetime.Text = mpromotions.startdatetime.ToString("yyyy-MM-dd");
                tbEnddatetime.Text = mpromotions.enddatetime.ToString("yyyy-MM-dd");
                Type = mpromotions.membertype;
                hfsurface.Value = mpromotions.surface;
                chkisTop.Checked = mpromotions.IsTop;
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
        }

        #region 保存信息
        public string alertmsg;
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string memberId = CookiesHelper.GetCookie("mid");
            if (string.IsNullOrEmpty(memberId))
            {
                Response.Write("<script>top.document.location.href='" + ECommon.WebUrl + "index.aspx" + "';</script>");
                Response.End();
            }

            Dpromotionsrelated dpromotionsrelated = new Dpromotionsrelated(dpromotions);
            Mpromotions mpromotions = new Mpromotions();
            mpromotions.title = tbTitle.Text;
            mpromotions.htmltitle = tbTitle.Text;
            mpromotions.surface = hfsurface.Value;
            mpromotions.letter = "";
            mpromotions.attribute = infoType.SelectedItem.Text;
            mpromotions.IsTop = chkisTop.Checked;
            mpromotions.IsRecommend = false;
            mpromotions.IsHot = false;
            mpromotions.IsEssence = false;
            mpromotions.IsSlide = false;
            mpromotions.IsHighlight = false;
            mpromotions.descript = tbDescript.Text;
            mpromotions.startdatetime = TRECommon.TypeConverter.StrToDateTime(tbStartdatetime.Text);
            mpromotions.enddatetime = TRECommon.TypeConverter.StrToDateTime(tbEnddatetime.Text);
            dpromotions.BeginTransaction();
            try
            {
                if (PKID > 0)
                {
                    mpromotions.lastedmid = int.Parse(memberId);
                    mpromotions.lastedmtime = DateTime.Now;
                    dpromotions.Update(mpromotions, c => c.id == PKID);
                }
                else
                {
                    mpromotions.mid = int.Parse(memberId);
                    mpromotions.membertype = memberInfo.type;
                    if (memberInfo.RegEndTime > DateTime.Now)
                    {
                        mpromotions.auditstatus = 1;
                        mpromotions.linestatus = 1;
                    }
                    else
                    {
                        mpromotions.auditstatus = 0;
                        mpromotions.linestatus = 0;
                    }
                    mpromotions.createtime = DateTime.Now;
                    dpromotions.Insert(mpromotions, out PKID);
                }
                dpromotionsrelated.Delete(c => c.promotionsid == PKID);
                if (chkshoplist.Items.Count > 0)
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
                                mpromotionsrelated.promotionstitle = mpromotions.title;
                                mpromotionsrelated.mid = int.Parse(memberId);
                                mpromotionsrelated.membertype = memberInfo.type;
                                mpromotionsrelated.shopid = shopid;
                                mpromotionsrelated.shoptitle = item.Text;
                                mpromotionsrelated.shopareacode = shopmodel.areacode == null ? "" : shopmodel.areacode;
                                mpromotionsrelated.shopaddress = shopmodel.address == null ? "" : shopmodel.address;
                                dpromotionsrelated.Insert(mpromotionsrelated);
                            }
                        }
                    }
                }
                else //卖场
                {
                    var marketmodel = dpromotions.LinqData<Mmarket>().FirstOrDefault(c => c.id == marketInfo.id);
                    if (marketmodel != null)
                    {
                        Mpromotionsrelated mpromotionsrelated = new Mpromotionsrelated();
                        mpromotionsrelated.promotionsid = PKID;
                        mpromotionsrelated.promotionstitle = mpromotions.title;
                        mpromotionsrelated.mid = memberInfo.id;
                        mpromotionsrelated.membertype = memberInfo.type;
                        mpromotionsrelated.marketid = marketmodel.id;
                        mpromotionsrelated.markettitle = marketmodel.title;
                        mpromotionsrelated.marketareacode = marketmodel.areacode;
                        mpromotionsrelated.marketaddress = marketmodel.address;
                        mpromotionsrelated.marketstoreyid = TRECommon.TypeConverter.StrToInt(rmarketstoreylist.SelectedValue);
                        dpromotionsrelated.Insert(mpromotionsrelated);
                    }
                }
                dpromotions.CommitTransaction();
                #region  保存图片
                if (PKID > 0)
                {
                    ECUpLoad ecUpload = new ECUpLoad();
                    if (mpromotions.surface.Length > 0)
                    {

                        ecUpload.MoveFiles(mpromotions.surface.TrimEnd(','), string.Format(EnFilePath.Promotion, PKID, EnFilePath.Surface));
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                dpromotions.RollbackTransaction();
                Response.Write("<script>alert('" + ex + "');</script>");
                return;
            }
            #region 通知客服邮件
            if (TRECommon.WebRequest.GetQueryInt("id") == 0 && infoType.SelectedValue != "4")
            {
                int companyid = 0;
                string companyname = "";
                if (memberInfo.type == 101)
                {
                    companyid = companyInfo.id; companyname = companyInfo.title;
                }
                else if (memberInfo.type == 103)
                {
                    companyid = marketInfo.id; companyname = marketInfo.title;
                }
                try
                {
                    string mailsubject = string.Format(@"
                        <p>商家: {0} 用户名：{5}</p>
                        <p>添加了促销活动。</p>
                        <p>促销活动id:{1} 促销活动:{2}</p>
                        <p>商家id:{3} 商家身份:{4}</p>"
                            , companyname, PKID, mpromotions.title, companyid, memberInfo.type, memberInfo.username);
                    string[] mailto = TREC.ECommerce.ECommon.ServiceMail.Split(',');
                    foreach (string items in mailto)
                    {
                        bool rsmail = EmailHelper.SendEmail("家具快搜 商家添加促销活动通知提示", items, mailsubject);
                    }
                }
                catch
                { 
                }
            }
            #endregion
            alertmsg = TREC.ECommerce.Ui.PageAlert.getalert(true, "保存商务信息成功！", "promotionslist.aspx");
          //  Response.Write("<script>alert('保存商务信息成功！');location.href='promotionslist.aspx';</script>");
        }
        #endregion

    }
}