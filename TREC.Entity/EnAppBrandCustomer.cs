using System;
namespace TREC.Entity
{
	/// <summary>
	/// sys_action:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class EnAppBrandCustomer
	{
        public EnAppBrandCustomer()
		{}
        #region Model
        private int _id;
        private int? _aid;
        private string _name;
        private string _phone;
        private string _mphone;
        private string _email;
        private string _address;
        private string _descript;
        private string _cus;
        private int _sex;
        /// <summary>
        /// 性别，1男，0,女
        /// </summary>
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        private string _citycode;
        /// <summary>
        /// 地区编码
        /// </summary>
        public string Citycode
        {
            get { return _citycode; }
            set { _citycode = value; }
        }
        private string productJson;
        /// <summary>
        /// 团购预订单
        /// </summary>
        public string ProductJson
        {
            get { return productJson; }
            set { productJson = value; }
        }
        private DateTime _createTime;

        public DateTime CreateTime
        {
            set { _createTime = value; }
            get { return _createTime; }
        }

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
        public int? aid
        {
            set { _aid = value; }
            get { return _aid; }
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
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
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
        public string email
        {
            set { _email = value; }
            get { return _email; }
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
        public string cus
        {
            set { _cus = value; }
            get { return _cus; }
        }
        #endregion Model

	}
}

