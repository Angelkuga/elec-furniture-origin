using System;
namespace TREC.Entity
{
	/// <summary>
	/// sys_action:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class EnLog
	{
        public EnLog()
		{}
        #region Model
        private int _id;
        private int? _modeule;
        private int? _action;
        private int? _operateid;
        private string _operatename;
        private string _title;
        private DateTime? _lastedittime = DateTime.Now;
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
        public int? modeule
        {
            set { _modeule = value; }
            get { return _modeule; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? action
        {
            set { _action = value; }
            get { return _action; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? operateid
        {
            set { _operateid = value; }
            get { return _operateid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string operatename
        {
            set { _operatename = value; }
            get { return _operatename; }
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
        public DateTime? lastedittime
        {
            set { _lastedittime = value; }
            get { return _lastedittime; }
        }
        #endregion Model

	}
}

