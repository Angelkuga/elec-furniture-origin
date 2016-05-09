using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    [Serializable]
    public partial class EnMerchants
    {
        public EnMerchants()
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
        private string brandid;

        public string Brandid
        {
            get { return brandid; }
            set { brandid = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string descript;

        public string Descript
        {
            get { return descript; }
            set { descript = value; }
        }
        private int auditstatus;

        public int Auditstatus
        {
            get { return auditstatus; }
            set { auditstatus = value; }
        }
        private int linestatus;

        public int Linestatus
        {
            get { return linestatus; }
            set { linestatus = value; }
        }
        private DateTime createtime;

        public DateTime Createtime
        {
            get { return createtime; }
            set { createtime = value; }
        }

        private DateTime lastedittime;

        public DateTime Lastedittime
        {
            get { return lastedittime; }
            set { lastedittime = value; }
        }

        private int membercount;

        public int Membercount
        {
            get { return membercount; }
            set { membercount = value; }
        }

        #endregion
    }
}
