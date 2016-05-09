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
    public partial class IpAddressPage : AdminPageBase
    {
        public int id
        {
            get
            {
                if (Request["id"] != null)
                {
                    return SubmitMeth.getInt(Request["id"].Trim());
                }
                else
                {
                    return 0;
                }
            }
        }
        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (id > 0)
                {
                    bnt_save.Text = "修改";
                    IpAddress _showip = new IpAddress();
                    _showip = EntityOper.IpAddress.Where(p => p.Id == id).FirstOrDefault();
                    txt_ip.Text = _showip.Ip;
                    txt_name.Text = _showip.CompanyName;
                    txt_url.Text = _showip.Url;
                }
                else
                {
                    bnt_save.Text = "添加";
                }
                ShowData();
            }
        }

        protected void ShowData()
        {
            List<IpAddress> _list = new List<IpAddress>();

            if (!string.IsNullOrEmpty(txt_search.Text.Trim()))
            {
                _list = EntityOper.IpAddress.Where(p => p.Ip.Contains(txt_search.Text.Trim())||p.CompanyName.Contains(txt_search.Text.Trim())).OrderByDescending(o=>o.Id).ToList();
            }
            else
            {
                _list = EntityOper.IpAddress.OrderByDescending(o => o.Id).ToList();
            }



            rptList.DataSource = _list;
            rptList.DataBind();
            AspNetPager1.RecordCount = _list.Count;
        }

      
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            List<int> _ids = new List<int>();

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string id = ((Label)rptList.Items[i].FindControl("lb_id")).Text;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    _ids.Add(SubmitMeth.getInt(id));
                }
            }
            if (_ids.Count > 0)
            {
                List<IpAddress> _listdel = new List<IpAddress>();
                _listdel = EntityOper.IpAddress.Where(p => _ids.Contains(p.Id)).ToList();
                EntityOper.IpAddress.DeleteAllOnSubmit(_listdel);
                EntityOper.SubmitChanges();
                ShowData();
                UiCommon.JscriptPrint(this.Page, "批量删除成功!", Request.Url.AbsoluteUri, "Success");
            }
        }

        #region 品牌搜索
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        #endregion

   

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            ShowData();
        }

        protected void bnt_save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_ip.Text.Trim()) && !string.IsNullOrEmpty(txt_url.Text.Trim()))
            {
                if (id == 0)//添加
                {

                    if (EntityOper.IpAddress.Where(p => p.Ip.ToLower() == txt_ip.Text.Trim().ToLower()).ToList().Count == 0)
                    {
                        IpAddress _ip = new IpAddress();
                        _ip.Ip = txt_ip.Text.Trim();
                        _ip.Url = txt_url.Text.Trim();
                        _ip.CompanyName = txt_name.Text.Trim();
                        _ip.CreateTime = DateTime.Now;
                        EntityOper.IpAddress.InsertOnSubmit(_ip);
                        EntityOper.SubmitChanges();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "T", "alert('添加成功');", true);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "C", "location.href='IpAddressPage.aspx';", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "click", "alert('二级域名已经存在，不能重复添加！');", true);
                    }
                }
                else
                {
                    if (EntityOper.IpAddress.Where(p => p.Ip.ToLower() == txt_ip.Text.Trim().ToLower()&&p.Id!=id).ToList().Count == 0)
                    {
                        IpAddress _upip = new IpAddress();
                        _upip = EntityOper.IpAddress.Where(p => p.Id == id).FirstOrDefault();
                        _upip.Ip = txt_ip.Text.Trim();
                        _upip.Url = txt_url.Text.Trim();
                        _upip.CompanyName = txt_name.Text.Trim();
                        _upip.CreateTime = DateTime.Now;
                        EntityOper.SubmitChanges();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "T", "alert('修改成功');", true);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "C", "location.href='IpAddressPage.aspx';", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "click", "alert('二级域名已经存在，不能重复添加！');", true);
                    }

                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "T", "alert('二级域名和对应地址都不能为空');", true);
               
            }

        }

    }
}