using System;
namespace TREC.Entity
{
	/// <summary>
	/// ʵ����GroupProductProperty ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��ϲ�Ʒid����ϲ�Ʒ�뵥Ʒ������
		/// </summary>
		public int gpId
		{
			set{ _gpid=value;}
			get{return _gpid;}
		}
		/// <summary>
		/// ��Ʒ����id
		/// </summary>
		public int ppId
		{
			set{ _ppid=value;}
			get{return _ppid;}
		}
		#endregion Model

	}
}

