using System;

namespace TREC.Entity
{
    [Serializable]
    public class EnAllBrand
    {
        #region Model
        private long? _id;
        private int _brandid;
        private string _brandcode;
        private string _companycode;
        private string _title;
        private string _quanpin;
        private string _ename;
        private string _logo;
        private int? _compayid;
        private string _fordio;
        /// <summary>
        /// 
        /// </summary>
        public long? id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int brandid
        {
            set { _brandid = value; }
            get { return _brandid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string brandcode
        {
            set { _brandcode = value; }
            get { return _brandcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string companycode
        {
            set { _companycode = value; }
            get { return _companycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string quanpin
        {
            set { _quanpin = value; }
            get { return _quanpin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ename
        {
            set { _ename = value; }
            get { return _ename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string logo
        {
            set { _logo = value; }
            get { return _logo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? compayid
        {
            set { _compayid = value; }
            get { return _compayid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fordio
        {
            set { _fordio = value; }
            get { return _fordio; }
        }
        #endregion Model

    }
}
