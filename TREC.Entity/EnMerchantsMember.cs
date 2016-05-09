using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{

    [Serializable]
    public partial class EnMerchantsMember
    {
        public EnMerchantsMember()
		{}

        #region Model
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int cid;

        public int Cid
        {
            get { return cid; }
            set { cid = value; }
        }

        private int merchantId;

        public int MerchantId
        {
            get { return merchantId; }
            set { merchantId = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string cityCode;

        public string CityCode
        {
            get { return cityCode; }
            set { cityCode = value; }
        }
        private string descript;

        public string Descript
        {
            get { return descript; }
            set { descript = value; }
        }
        private DateTime createTime;

        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
        #endregion
    }
}
