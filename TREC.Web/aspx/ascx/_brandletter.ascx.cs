using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TRECommon;
using TREC.Entity;

namespace TREC.Web.aspx.ascx
{
    public partial class _brandletter : System.Web.UI.UserControl
    {
        public DataTable dtBrandLetterIndex = new DataTable();
        public string[] letterIndex = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        protected void Page_Load(object sender, EventArgs e)
        {
            dtBrandLetterIndex = ECBrand.GetBrandLetterList();
        }
    }
}