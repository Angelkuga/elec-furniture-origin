using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    /// <summary>
    /// sys_action:实体类(广告表)
	/// </summary>
	[Serializable]
    public partial class EnWebAdvertising
    {
        public int id { get; set; }
        public int? categoryid { get; set; }
        public string title { get; set; }
        public string linkurl { get; set; }
        public string flashurl { get; set; }
        public string imgurl { get; set; }
        public string videourl { get; set; }
        public string adtext { get; set; }
        public string adcode { get; set; }
        public int? isopen { get; set; }
        public string adlinkman { get; set; }
        public string adlinkphone { get; set; }
        public string adlinkemail { get; set; }
        public DateTime? lastedittime { get; set; }
        public int lasteditaid { get; set; }
    }
}
