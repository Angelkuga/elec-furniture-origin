using System;
namespace TREC.Entity
{
	/// <summary>
	/// grouporder:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnGroupOrder
	{
        public EnGroupOrder()
		{}
        #region Model
        private int _id;
        private string _grouporderno;
        private int? _mid;
        private int? _fjmid;
        private string _name;
        private string _email;
        private string _phone;
        private string _fax;
        private string _mphone;
        private string _zip;
        private string _areacode;
        private string _address;
        private string _descript;
        private decimal? _totlepromoney;
        private decimal? _totalmoney;
        private decimal? _invoicemoney;
        private decimal? _installationmeney;
        private int? _status;
        private DateTime? _createtime;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string grouporderno
        {
            set { _grouporderno = value; }
            get { return _grouporderno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? mid
        {
            set { _mid = value; }
            get { return _mid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? fjmid
        {
            set { _fjmid = value; }
            get { return _fjmid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mphone
        {
            set { _mphone = value; }
            get { return _mphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zip
        {
            set { _zip = value; }
            get { return _zip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string areacode
        {
            set { _areacode = value; }
            get { return _areacode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string descript
        {
            set { _descript = value; }
            get { return _descript; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? totlepromoney
        {
            set { _totlepromoney = value; }
            get { return _totlepromoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? totalmoney
        {
            set { _totalmoney = value; }
            get { return _totalmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? invoicemoney
        {
            set { _invoicemoney = value; }
            get { return _invoicemoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? installationmeney
        {
            set { _installationmeney = value; }
            get { return _installationmeney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion Model

	}
}

