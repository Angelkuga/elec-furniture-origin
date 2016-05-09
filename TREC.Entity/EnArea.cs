using System;
using System.Collections.Generic;
namespace TREC.Entity
{
	/// <summary>
	/// sys_action:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class EnArea
	{
        public EnArea()
		{}
        #region Model
        private string _areacode;
        private string _parentcode;
        private string _areaname;
        private string _areazipcode;
        private string _grouparea;
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
        public string parentcode
        {
            set { _parentcode = value; }
            get { return _parentcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string areaname
        {
            set { _areaname = value; }
            get { return _areaname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string areazipcode
        {
            set { _areazipcode = value; }
            get { return _areazipcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string grouparea
        {
            set { _grouparea = value; }
            get { return _grouparea; }
        }

        /// <summary>
        /// 2015-01-30 shen
        /// </summary>
        public int sort { get; set; }
        public int zxs { get; set; }
        public List<EnArea> CityList { get; set; }
        public List<EnArea> CountyList { get; set; }

        #endregion Model

	}
}

