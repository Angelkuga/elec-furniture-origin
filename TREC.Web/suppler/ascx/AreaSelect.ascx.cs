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
using Haojibiz.Data;
using Haojibiz.Model;
using Haojibiz.DAL;
using System.Data.Linq;
using System.ComponentModel;

namespace TREC.Web.Suppler.ascx
{
    public partial class AreaSelect : System.Web.UI.UserControl
    {
        private int _startDepth = 1, _endDepth = 9;
        protected string selectedAreaId = "0";
        protected string selectedAreaName = string.Empty;
        protected bool _readonly = false;
        protected bool _isCache = true;
        Darea darea = new Darea();
        protected StringBuilder selectedPath = new StringBuilder();
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!ReadOnly)
            {
                _isCache = (Request.QueryString["cache"] == "true");
                if (!_isCache) putoutHttpHeader();
                if (Request.QueryString["action"] == "getarealist")
                {
                    string areaId = Request.QueryString["areaId"];
                    Response.Write(getAreaSplit(areaId));
                    Response.End();
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!ReadOnly)
            {
                if (!IsPostBack && selectedAreaId != "0")
                    SelectedValue.Value = selectedAreaId.ToString();
                fore(selectedAreaId);
            }
            base.OnPreRender(e);
        }
        void fore(string p)
        {
            if (p == null || p == "0") return;
            var parent = darea.Linq.Where(c => c.areacode == p).Select(c => c.parentcode).FirstOrDefault();
            fore(parent);
            if (selectedPath.Length == 0)
                selectedPath.AppendFormat("{0}", p);
            else
                selectedPath.AppendFormat("|{0}", p);
        }
        [Bindable(true)]
        public string SelectedAreaID
        {
            get
            {
                if (selectedAreaId == "0")
                    selectedAreaId = Request.Form[SelectedValue.UniqueID];
                return selectedAreaId;
            }
            set { selectedAreaId = value; }
        }
        public string SelectedAreaName
        {
            get { return selectedAreaName; }
            set { selectedAreaName = value; }
        }

        [Bindable(true)]
        public bool ReadOnly
        {
            get { return _readonly; }
            set { _readonly = value; }
        }

        public bool IsCache
        {
            get { return _isCache; }
            set { _isCache = value; }
        }

        public bool IsValid
        {
            get { return RV1.Visible; }
            set { RV1.Visible = value; }
        }

        public string ErrorMessage
        {
            get { return RV1.ErrorMessage; }
            set { RV1.ErrorMessage = value; }
        }

        /// <summary>
        /// 获取或设置要显示的的相对于根的起始路径深度（包括 startDepth），默认为 1。
        /// </summary>
        public int StartDepth
        {
            get { return _startDepth; }
            set { _startDepth = value; }
        }

        /// <summary>
        /// 获取或设置要显示相对于根的终止路径深度（包括 endDepth），-1 表示最终一级。
        /// </summary>
        public int EndDepth
        {
            get { return _endDepth; }
            set { _endDepth = value; }
        }

        public long RootAreaID
        {
            get;
            set;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (this.ReadOnly)
            {
                var fullName = ECommon.GetAreaName(selectedAreaId);
                writer.Write(fullName);
            }
            else
            {
                base.Render(writer);
            }
        }

        //防止缓存
        void putoutHttpHeader()
        {
            Response.AddHeader("Pragma", "No-Cache");
            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
        }

        protected string getAreaSplit(string parenId)
        {
            var areaList = darea.Linq.Where(c => c.parentcode == parenId).Select(c => new { c.areaname, c.areacode, haschild = darea.Linq.Any(f => f.parentcode == c.areacode) });
            StringBuilder sb = new StringBuilder();
            foreach (var item in areaList)
            {
                if (sb.Length > 0)
                {
                    sb.Append("|");
                }
                sb.AppendFormat("{0}|{1}${2}", item.areaname, item.areacode, Convert.ToByte(item.haschild).ToString());
            }
            return sb.ToString();
        }
    }
}