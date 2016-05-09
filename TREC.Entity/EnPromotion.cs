using System;
namespace TREC.Entity
{
	/// <summary>
	/// admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnPromotion
	{
        public EnPromotion()
		{}
        #region Model
        private int _id;
        private string _title;
        private string _htmltitle;
        private string _letter;
        private string _attribute;
        private int? _ptype;
        private DateTime? _startdatetime;
        private DateTime? _enddatetime;
        private string _areacode;
        private string _address;
        private string _surface;
        private string _logo;
        private string _thumb;
        private string _bannel;
        private string _desimage;
        private string _descript;
        private string _keywords;
        private string _template;
        private int? _hits;
        private int? _sort;
        private int? _createmid = 0;
        private int? _lastedid = 0;
        private DateTime _lastedittime;
        private int _auditstatus;
        private int _linestatus;
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
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string htmltitle
        {
            set { _htmltitle = value; }
            get { return _htmltitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string letter
        {
            set { _letter = value; }
            get { return _letter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attribute
        {
            set { _attribute = value; }
            get { return _attribute; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ptype
        {
            set { _ptype = value; }
            get { return _ptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? startdatetime
        {
            set { _startdatetime = value; }
            get { return _startdatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? enddatetime
        {
            set { _enddatetime = value; }
            get { return _enddatetime; }
        }
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
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string surface
        {
            set { _surface = value; }
            get { return _surface; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string logo
        {
            set { _logo = value; }
            get { return _logo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string thumb
        {
            set { _thumb = value; }
            get { return _thumb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bannel
        {
            set { _bannel = value; }
            get { return _bannel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string desimage
        {
            set { _desimage = value; }
            get { return _desimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string descript
        {
            set { _descript = value; }
            get { return _descript; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string keywords
        {
            set { _keywords = value; }
            get { return _keywords; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string template
        {
            set { _template = value; }
            get { return _template; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? createmid
        {
            set { _createmid = value; }
            get { return _createmid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? lastedid
        {
            set { _lastedid = value; }
            get { return _lastedid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime lastedittime
        {
            set { _lastedittime = value; }
            get { return _lastedittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int auditstatus
        {
            set { _auditstatus = value; }
            get { return _auditstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int linestatus
        {
            set { _linestatus = value; }
            get { return _linestatus; }
        }
        #endregion Model

	}


    /// <summary>
    /// shen 2015-02-04
    /// </summary>
    [Serializable]
    public class t_promotionstype
    {
        public t_promotionstype()
        {

        }

        /// <summary> 
        /// 
        /// </summary>
        public const string TableName = "t_promotionstype";

        #region

        public const string Field_id = "id";
        public const string Field_title = "title";
        public const string Field_createtime = "createtime";
        public const string Field_userid = "userid";
        public const string Field_pstate = "pstate";
        public const string Field_pindex = "pindex";
        #endregion

        #region

        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int id
        { get; set; }
        /// <summary> 
        /// 促销类型名
        /// <para> 50</para>
        /// </summary>
        public string title
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 23</para>
        /// </summary>
        public DateTime createtime
        { get; set; }
        /// <summary> 
        /// 创建人id
        /// <para> 10</para>
        /// </summary>
        public int userid
        { get; set; }
        /// <summary> 
        /// 状态 1 有效0无效
        /// <para> 10</para>
        /// </summary>
        public int pstate
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int pindex
        { get; set; }

        /// <summary>
        /// 参加各个促销类型的数量
        /// </summary>
        public int pcount { get; set; }


        #endregion

        public static void FillData(System.Data.DataRow dr, out t_promotionstype info)
        {
            #region

            info = new t_promotionstype();
            if (dr.Table.Columns.Contains(Field_id))
                info.id = DBNull.Value == dr[Field_id] ? default(int) : (int)dr[Field_id];
            if (dr.Table.Columns.Contains(Field_title))
                info.title = DBNull.Value == dr[Field_title] ? default(string) : (string)dr[Field_title];
            if (dr.Table.Columns.Contains(Field_createtime))
                info.createtime = DBNull.Value == dr[Field_createtime] ? default(DateTime) : (DateTime)dr[Field_createtime];
            if (dr.Table.Columns.Contains(Field_userid))
                info.userid = DBNull.Value == dr[Field_userid] ? default(int) : (int)dr[Field_userid];
            if (dr.Table.Columns.Contains(Field_pstate))
                info.pstate = DBNull.Value == dr[Field_pstate] ? default(int) : (int)dr[Field_pstate];
            if (dr.Table.Columns.Contains(Field_pindex))
                info.pindex = DBNull.Value == dr[Field_pindex] ? default(int) : (int)dr[Field_pindex];
            if (dr.Table.Columns.Contains("num"))
                info.pcount = DBNull.Value == dr["num"] ? default(int) : (int)dr["num"];
            #endregion

        }

    }
}

