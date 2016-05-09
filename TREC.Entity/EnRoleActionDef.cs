using System;
namespace TREC.Entity
{
	/// <summary>
	/// sys_action:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class EnRoleActionDef
	{
		public EnRoleActionDef()
		{}
        #region Model
        private int _actionid;
        private int _moduleid;
        private int _roleid;
        /// <summary>
        /// 
        /// </summary>
        public int actionid
        {
            set { _actionid = value; }
            get { return _actionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int moduleid
        {
            set { _moduleid = value; }
            get { return _moduleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int roleid
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        #endregion Model

	}
}

