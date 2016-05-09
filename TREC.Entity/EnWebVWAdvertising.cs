using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    /// <summary>
    /// sys_action:实体类(广告视图表)
    /// </summary>
    [Serializable]
    public partial class EnWebVWAdvertising : EnWebAdvertising
    {
        public int? parentid { get; set; }
        public int? moduleid { get; set; }
        public string modulevalue { get; set; } 
        public string img { get; set; }
        public int? height { get; set; }
        public int? width { get; set; } 
        public int? adtype { get; set; }
        public DateTime? starttime { get; set; }
        public DateTime? endtime { get; set; }
        public string descript { get; set; }
        public string template { get; set; }
        public int? sort { get; set; }
    }
}
