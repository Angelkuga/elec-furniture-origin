using System;
namespace TREC.Entity
{
	/// <summary>
	/// admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnAdmin
	{
        public EnAdmin()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _password;
		private string _displayname;
		private string _question;
		private string _answer;
		private string _email;
		private string _phone;
		private string _areacode;
		private string _address;
		private int _logincount=0;
		private int _islock=0;
		private string _lastmodule;
		private DateTime _createdate;
		private DateTime _lastactivitydate;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string displayname
		{
			set{ _displayname=value;}
			get{return _displayname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string question
		{
			set{ _question=value;}
			get{return _question;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string answer
		{
			set{ _answer=value;}
			get{return _answer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string areacode
		{
			set{ _areacode=value;}
			get{return _areacode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int logincount
		{
			set{ _logincount=value;}
			get{return _logincount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int islock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lastmodule
		{
			set{ _lastmodule=value;}
			get{return _lastmodule;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime createdate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime lastactivitydate
		{
			set{ _lastactivitydate=value;}
			get{return _lastactivitydate;}
		}
		#endregion Model

	}
}

