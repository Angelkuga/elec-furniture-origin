using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;
using Haojibiz.Model;
using Haojibiz.DAL;
using Haojibiz;

namespace TREC.Web.Admin.brand
{
    public partial class brandlist : AdminPageBase
    {
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void ShowData()
        {
            if (ECommon.QueryEdit == "2" && ECommon.QueryId != "")
            {
                ECBrand.DeleteBrand(TypeConverter.StrToInt(ECommon.QueryId));
            }

            string strWhere = " 1=1 ";
            //审核状态
            if (!string.IsNullOrEmpty(ddlauditstatus.SelectedValue))
            {
                strWhere += " and auditstatus=" + ddlauditstatus.SelectedValue;
            }
            //上/下线
            if (!string.IsNullOrEmpty(ddllinestatus.SelectedValue))
            {
                strWhere += " and linestatus=" + ddllinestatus.SelectedValue;
            }
            //品牌搜索
            if (txtbranname.Text != "")
            {
                strWhere += " AND title like '%" + txtbranname.Text + "%' ";
            }
            //工厂搜索
            if (txtCompanyTitle.Text != "")
            {
                strWhere += " AND CompanyTitle like '%" + txtCompanyTitle.Text + "%' ";
            }

            rptList.DataSource = ECBrand.GetAdminBrandList(AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, strWhere, out tmpPageCount);
            rptList.DataBind();
            AspNetPager1.RecordCount = tmpPageCount;
        }

      
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            string idlist = "";
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_id")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    idlist += id + ",";
                }
            }
            if (idlist.Length > 0)
            {
                ECBrand.DeleteBrandByIdList(idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist);
                UiCommon.JscriptPrint(this.Page, "批量删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        #region 品牌搜索
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        #endregion

        public string GetStatusStr(object obj)
        {
            string str = string.Empty;
            if (obj == null)
            {
                return str;
            }
            switch (obj.ToString())
            {
                case "-1":
                    str = "审核中";
                    break;
                case "0":
                    str = "下线";
                    break;
                case "1":
                    str = "上线";
                    break;
                case "-99":
                    str = "未通过";
                    break;
            }
            return str;
        }

        public string GetStatusStrA(object obj)
        {
            string str = string.Empty;
            if (obj == null)
            {
                return str;
            }
            switch (obj.ToString())
            {
                case "-1":
                    str = "审核中";
                    break;
                case "0":
                    str = "待审核";
                    break;
                case "1":
                    str = "审核通过";
                    break;
                case "-99":
                    str = "未通过";
                    break;
            }
            return str;
        }

        /// <summary>
        /// 下线并且未通过审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lonkNo_Click(object sender, EventArgs e)
        {
            string idlist = "";
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_id")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    idlist += id + ",";
                }
            }
            idlist = idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist;
            if (idlist.Length > 0)
            {
                ModifyTable_auditstatus_linestatus(idlist, EnumModifyType.brand, false, "id");
                string[] _strsum = idlist.Split(',');
                foreach (string item in _strsum)
                {
                    //代理+无代理
                    List<EnShop> list = ECShop.GetShopList(" id in(select distinct a.id from t_shop a left join t_shopbrand b on a.id=b.shopid where b.brandid=" + item + ")");
                    string str = "";
                    foreach (EnShop _item in list)
                    {
                        str += _item.id + ",";
                    }
                    str = str.EndsWith(",") ? str.Substring(0, str.Length - 1) : str;
                    if (str.Length > 0)
                    {
                        ModifyTable_auditstatus_linestatus(str, EnumModifyType.shop, false, "id");
                    }

                    foreach (EnShop _item in list)//处理促销信息
                    {
                        List<Mpromotionsrelated> promotionsrelatedlist = new List<Mpromotionsrelated>();

                        Dpromotions dpromotions = new Dpromotions();

                        promotionsrelatedlist = dpromotions.LinqData<Mpromotionsrelated>().Where(c => c.shopid == _item.id).ToList();

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
                                dpromotionsrelated.Delete(c => c.shopid == _item.id && c.promotionsid == _mspd.id);
                            }
                        }
                    }


                    List<EnAppBrand> _lst = ECAppBrand.GetAppBrandList(" brandid=" + item);

                    if (_lst == null || _lst.Count <= 0)//无代理
                    {
                        ModifyTable_auditstatus_linestatus(item, EnumModifyType.product, false, "brandid");
                    }

                    EnBrand eccompany = ECBrand.GetBrandInfo(" where id=" + item);
                    if (eccompany != null)
                    {
                        List<EnBrand> _list = ECBrand.GetBrandList(" companyid=" + eccompany.companyid);
                        if (_list != null && _list.Count == 1)
                        {
                            ModifyTable_auditstatus_linestatus(eccompany.companyid.ToString(), EnumModifyType.company, false, "id");
                        }
                    }
                }

                UiCommon.JscriptPrint(this.Page, "批量下线并且未通过审核成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkGo_Click(object sender, EventArgs e)
        {
            string idlist = "";
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_id")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    idlist += id + ",";
                }
            }
            idlist = idlist.EndsWith(",") ? idlist.Substring(0, idlist.Length - 1) : idlist;
            if (idlist.Length > 0)
            {

                ModifyTable_auditstatus_linestatus(idlist, EnumModifyType.brand, true, "id");

                UiCommon.JscriptPrint(this.Page, "批量审核通过并且上线成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            ShowData();
        }

        protected void Linkgroup_Click(object sender, EventArgs e)
        {
            List<GroupBuy> _list = new List<GroupBuy>();

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                GroupBuy _groupby = new GroupBuy();
                string id = ((Label)rptList.Items[i].FindControl("lb_id")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                string name = ((Label)rptList.Items[i].FindControl("lb_name")).Text;
                string logo = ((Label)rptList.Items[i].FindControl("lb_logo")).Text;

                if (cb.Checked && EntityOper.GroupBuy.Where(p=>p.brandId==SubmitMeth.getInt(id)).ToList().Count==0)
                {
                    _groupby.brandId = SubmitMeth.getInt(id);
                    _groupby.brandName = name;
                    _groupby.brandImgUrl = logo;
                    _groupby.DiscountPerson1 = 0;
                    _groupby.DiscountPerson2 = 0;
                    _groupby.DiscountResult1 = 0;
                    _groupby.DiscountResult2 = 0;
                    _groupby.ImgUrl = "";
                    _groupby.Title = "";
                    _groupby.Unline = "";
                    _groupby.ShowPosition = "";
                    _groupby.CreateTime = DateTime.Now;

                    _list.Add(_groupby);
                }
            }
            if (_list.Count > 0)
            {
                EntityOper.GroupBuy.InsertAllOnSubmit(_list);
                EntityOper.SubmitChanges();
                UiCommon.JscriptPrint(this.Page, "成功加入团购!", Request.Url.AbsoluteUri, "Success");
            }
        }

    }
}