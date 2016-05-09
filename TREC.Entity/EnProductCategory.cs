using System;
namespace TREC.Entity
{
	/// <summary>
	/// productcategory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnProductCategory
	{
		public EnProductCategory()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _letter;
		private string _rewritetitle;
		private int? _parentid;
		private int? _lft;
		private int? _rgt;
		private int? _lev;
		private string _depth;
		private string _surface;
		private string _thumb;
		private string _bannel;
		private string _descript;
        private string _pagetitle;
		private string _keywords;
        private string _description;
		private string _template;
		private int? _hits;
		private int? _sort;
		private int? _createmid=0;
		private int? _lastedid=0;
		private DateTime _lastedittime;
        private int? _linestatus = 0;

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
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string letter
		{
			set{ _letter=value;}
			get{return _letter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rewritetitle
		{
			set{ _rewritetitle=value;}
			get{return _rewritetitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? parentid
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? lft
		{
			set{ _lft=value;}
			get{return _lft;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? rgt
		{
			set{ _rgt=value;}
			get{return _rgt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? lev
		{
			set{ _lev=value;}
			get{return _lev;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string depth
		{
			set{ _depth=value;}
			get{return _depth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string surface
		{
			set{ _surface=value;}
			get{return _surface;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string thumb
		{
			set{ _thumb=value;}
			get{return _thumb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bannel
		{
			set{ _bannel=value;}
			get{return _bannel;}
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
        public string pagetitle
        {
            set { _pagetitle = value; }
            get { return _pagetitle; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string keywords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string description
        {
            set { _description = value; }
            get { return _description; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string template
		{
			set{ _template=value;}
			get{return _template;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? hits
		{
			set{ _hits=value;}
			get{return _hits;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? createmid
		{
			set{ _createmid=value;}
			get{return _createmid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? lastedid
		{
			set{ _lastedid=value;}
			get{return _lastedid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime lastedittime
		{
			set{ _lastedittime=value;}
			get{return _lastedittime;}
		}

        public int? linestatus
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
    public class t_productcategory
    {
        public t_productcategory()
        {

        }

        /// <summary> 
        /// 
        /// </summary>
        public const string TableName = "t_productcategory";

        #region

        public const string Field_id = "id";
        public const string Field_title = "title";
        public const string Field_letter = "letter";
        public const string Field_rewritetitle = "rewritetitle";
        public const string Field_parentid = "parentid";
        public const string Field_lft = "lft";
        public const string Field_rgt = "rgt";
        public const string Field_lev = "lev";
        public const string Field_depth = "depth";
        public const string Field_surface = "surface";
        public const string Field_thumb = "thumb";
        public const string Field_bannel = "bannel";
        public const string Field_descript = "descript";
        public const string Field_pagetitle = "pagetitle";
        public const string Field_keywords = "keywords";
        public const string Field_description = "description";
        public const string Field_template = "template";
        public const string Field_hits = "hits";
        public const string Field_sort = "sort";
        public const string Field_linestatus = "linestatus";
        public const string Field_createmid = "createmid";
        public const string Field_lastedid = "lastedid";
        public const string Field_lastedittime = "lastedittime";
        #endregion

        #region

        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int id
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 80</para>
        /// </summary>
        public string title
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 20</para>
        /// </summary>
        public string letter
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 20</para>
        /// </summary>
        public string rewritetitle
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int parentid
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int lft
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int rgt
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int lev
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 200</para>
        /// </summary>
        public string depth
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 200</para>
        /// </summary>
        public string surface
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 40</para>
        /// </summary>
        public string thumb
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 300</para>
        /// </summary>
        public string bannel
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 1073741823</para>
        /// </summary>
        public string descript
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 200</para>
        /// </summary>
        public string pagetitle
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 200</para>
        /// </summary>
        public string keywords
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 200</para>
        /// </summary>
        public string description
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 50</para>
        /// </summary>
        public string template
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int hits
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int sort
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int linestatus
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int createmid
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 10</para>
        /// </summary>
        public int lastedid
        { get; set; }
        /// <summary> 
        /// 
        /// <para> 23</para>
        /// </summary>
        public DateTime lastedittime
        { get; set; }
        #endregion


        public System.Collections.Generic.List<t_productcategory> ProCategoryList = new System.Collections.Generic.List<t_productcategory>();


        public static void FillData(System.Data.DataRow dr, out t_productcategory info)
        {
            #region

            info = new t_productcategory();
            if (dr.Table.Columns.Contains(Field_id))
                info.id = DBNull.Value == dr[Field_id] ? default(int) : (int)dr[Field_id];
            if (dr.Table.Columns.Contains(Field_title))
                info.title = DBNull.Value == dr[Field_title] ? default(string) : (string)dr[Field_title];
            if (dr.Table.Columns.Contains(Field_letter))
                info.letter = DBNull.Value == dr[Field_letter] ? default(string) : (string)dr[Field_letter];
            if (dr.Table.Columns.Contains(Field_rewritetitle))
                info.rewritetitle = DBNull.Value == dr[Field_rewritetitle] ? default(string) : (string)dr[Field_rewritetitle];
            if (dr.Table.Columns.Contains(Field_parentid))
                info.parentid = DBNull.Value == dr[Field_parentid] ? default(int) : (int)dr[Field_parentid];
            if (dr.Table.Columns.Contains(Field_lft))
                info.lft = DBNull.Value == dr[Field_lft] ? default(int) : (int)dr[Field_lft];
            if (dr.Table.Columns.Contains(Field_rgt))
                info.rgt = DBNull.Value == dr[Field_rgt] ? default(int) : (int)dr[Field_rgt];
            if (dr.Table.Columns.Contains(Field_lev))
                info.lev = DBNull.Value == dr[Field_lev] ? default(int) : (int)dr[Field_lev];
            if (dr.Table.Columns.Contains(Field_depth))
                info.depth = DBNull.Value == dr[Field_depth] ? default(string) : (string)dr[Field_depth];
            if (dr.Table.Columns.Contains(Field_surface))
                info.surface = DBNull.Value == dr[Field_surface] ? default(string) : (string)dr[Field_surface];
            if (dr.Table.Columns.Contains(Field_thumb))
                info.thumb = DBNull.Value == dr[Field_thumb] ? default(string) : (string)dr[Field_thumb];
            if (dr.Table.Columns.Contains(Field_bannel))
                info.bannel = DBNull.Value == dr[Field_bannel] ? default(string) : (string)dr[Field_bannel];
            if (dr.Table.Columns.Contains(Field_descript))
                info.descript = DBNull.Value == dr[Field_descript] ? default(string) : (string)dr[Field_descript];
            if (dr.Table.Columns.Contains(Field_pagetitle))
                info.pagetitle = DBNull.Value == dr[Field_pagetitle] ? default(string) : (string)dr[Field_pagetitle];
            if (dr.Table.Columns.Contains(Field_keywords))
                info.keywords = DBNull.Value == dr[Field_keywords] ? default(string) : (string)dr[Field_keywords];
            if (dr.Table.Columns.Contains(Field_description))
                info.description = DBNull.Value == dr[Field_description] ? default(string) : (string)dr[Field_description];
            if (dr.Table.Columns.Contains(Field_template))
                info.template = DBNull.Value == dr[Field_template] ? default(string) : (string)dr[Field_template];
            if (dr.Table.Columns.Contains(Field_hits))
                info.hits = DBNull.Value == dr[Field_hits] ? default(int) : (int)dr[Field_hits];
            if (dr.Table.Columns.Contains(Field_sort))
                info.sort = DBNull.Value == dr[Field_sort] ? default(int) : (int)dr[Field_sort];
            if (dr.Table.Columns.Contains(Field_linestatus))
                info.linestatus = DBNull.Value == dr[Field_linestatus] ? default(int) : (int)dr[Field_linestatus];
            if (dr.Table.Columns.Contains(Field_createmid))
                info.createmid = DBNull.Value == dr[Field_createmid] ? default(int) : (int)dr[Field_createmid];
            if (dr.Table.Columns.Contains(Field_lastedid))
                info.lastedid = DBNull.Value == dr[Field_lastedid] ? default(int) : (int)dr[Field_lastedid];
            if (dr.Table.Columns.Contains(Field_lastedittime))
                info.lastedittime = DBNull.Value == dr[Field_lastedittime] ? default(DateTime) : (DateTime)dr[Field_lastedittime];
            #endregion

        }

    }

}

