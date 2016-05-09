using System;
namespace TREC.Entity
{
	/// <summary>
	/// grouporderpay:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnGroupOrderPay
	{
        public EnGroupOrderPay()
		{}
		#region Model
		private int _id;
		private int? _grouporderid;
		private string _grouporderno;
		private string _paycode;
		private int? _paytype;
		private decimal? _paymoney;
		private string _descript;
		private int? _paystatus;
		private DateTime? _paydatetime;
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
		public int? grouporderid
		{
			set{ _grouporderid=value;}
			get{return _grouporderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string grouporderno
		{
			set{ _grouporderno=value;}
			get{return _grouporderno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string paycode
		{
			set{ _paycode=value;}
			get{return _paycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? paytype
		{
			set{ _paytype=value;}
			get{return _paytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? paymoney
		{
			set{ _paymoney=value;}
			get{return _paymoney;}
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
		public int? paystatus
		{
			set{ _paystatus=value;}
			get{return _paystatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? paydatetime
		{
			set{ _paydatetime=value;}
			get{return _paydatetime;}
		}
		#endregion Model

	}
}

