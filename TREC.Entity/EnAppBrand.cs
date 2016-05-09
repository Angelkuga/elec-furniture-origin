using System;
namespace TREC.Entity
{
	/// <summary>
	/// sys_action:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class EnAppBrand
	{
        public EnAppBrand()
		{}
        #region Model
        private int _id;
        private int _dealerid;
        private string _dealetitle;
        private int _brandid;
        private string _brandtitle;
        private int _companyid;
        private string _companytitle;
        private int? _shopid;
        private string _shoptitle;
        private int _appmodule;
        private int _apptype;
        private DateTime _apptime;
        private int _createmid = 0;
        private DateTime _lastedittime;
        private int _auditstatus;
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
        public int dealerid
        {
            set { _dealerid = value; }
            get { return _dealerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dealetitle
        {
            set { _dealetitle = value; }
            get { return _dealetitle; }
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
        public string brandtitle
        {
            set { _brandtitle = value; }
            get { return _brandtitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int companyid
        {
            set { _companyid = value; }
            get { return _companyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string companytitle
        {
            set { _companytitle = value; }
            get { return _companytitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? shopid
        {
            set { _shopid = value; }
            get { return _shopid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shoptitle
        {
            set { _shoptitle = value; }
            get { return _shoptitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int appmodule
        {
            set { _appmodule = value; }
            get { return _appmodule; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int apptype
        {
            set { _apptype = value; }
            get { return _apptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime apptime
        {
            set { _apptime = value; }
            get { return _apptime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int createmid
        {
            set { _createmid = value; }
            get { return _createmid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime lastedittime
        {
            set { _lastedittime = value; }
            get { return _lastedittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int auditstatus
        {
            set { _auditstatus = value; }
            get { return _auditstatus; }
        }
        #endregion Model

	}
}

