using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    public enum EnumGroupOrderStatus
    {
        取消订单=100,
        待付报名费=101,
        己付报名费=102
    }

    public enum EnumGroupOrderPayStatus
    {
        未付=0,
        己付=1,
    }

    public enum EnumGroupOrderPayType
    {
        报名费=101,
    }
}
