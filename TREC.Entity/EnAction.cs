using System;
namespace TREC.Entity
{
	/// <summary>
	/// sys_action:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class EnAction
	{
		public EnAction()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _mark;
		private int _mid;
		private int _actype=0;
		private string _descript;
		private int _sort;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
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
		public string mark
		{
			set{ _mark=value;}
			get{return _mark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int mid
		{
			set{ _mid=value;}
			get{return _mid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int actype
		{
			set{ _actype=value;}
			get{return _actype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string descript
		{
			set{ _descript=value;}
			get{return _descript;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}

        /// <summary>
        /// 是否有该动作权限
        /// </summary>
        public int isActionHas
        {
            get;
            set;
        }
		#endregion Model

	}
}

