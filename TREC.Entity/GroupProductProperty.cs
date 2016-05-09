using System;
namespace TREC.Entity
{
	/// <summary>
	/// 实体类GroupProductProperty 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class GroupProductProperty
	{
		public GroupProductProperty()
		{}
		#region Model
		private int _gpid;
		private int _ppid;
		/// <summary>
		/// 组合产品id（组合产品与单品关联表）
		/// </summary>
		public int gpId
		{
			set{ _gpid=value;}
			get{return _gpid;}
		}
		/// <summary>
		/// 产品属性id
		/// </summary>
		public int ppId
		{
			set{ _ppid=value;}
			get{return _ppid;}
		}
		#endregion Model

	}
}

