using System;
namespace TREC.Entity
{
	/// <summary>
	/// sys_module_link:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnModuleLink
	{
        public EnModuleLink()
		{}
		#region Model
		private int _moduleid;
		private string _title;
		private string _icourl;
		private string _linkurl;
		/// <summary>
		/// 
		/// </summary>
        public int ModuleId
		{
            set { _moduleid = value; }
            get { return _moduleid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string icourl
		{
			set{ _icourl=value;}
			get{return _icourl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string linkurl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		#endregion Model

	}
}

