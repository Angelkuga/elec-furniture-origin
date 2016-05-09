using System;
namespace TREC.Entity
{
	/// <summary>
	/// admin_rol:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnRole
	{
        public EnRole()
		{}
		#region Model
		private int _id;
		private int _parentid;
		private string _title;
		private string _mark;
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
		public int parentid
		{
			set{ _parentid=value;}
			get{return _parentid;}
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
		#endregion Model

	}
}

