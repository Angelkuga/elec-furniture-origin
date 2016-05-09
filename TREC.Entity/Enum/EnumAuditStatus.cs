using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    public enum EnumAuditStatus
    {
        待审核=0,
        正在审核=-1,
        通过=1,
        未通过=-99,
    }
}
