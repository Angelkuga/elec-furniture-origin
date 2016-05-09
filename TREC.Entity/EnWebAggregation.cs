using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TREC.Entity
{
    public class EnWebAggregation
    {
        #region Model
        private int _id;
        private string _typethumb;
        private string _typeurl;
        private string _typetitle;
        private int? _parent;
        private int? _type;
        private string _title;
        private string _title1;
        private string _title2;
        private string _title3;
        private string _thumb;
        private int? _thumbw;
        private int? _thumbh;
        private string _bannel;
        private string _url;
        private string _descript;
        private int? _sort;
        private int? _hits;
        private DateTime _lastedittime;
        private int? _createmid;

        private DateTime? _starttime;
        private DateTime? _endtime;
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
        public string typethumb
        {
            set { _typethumb = value; }
            get { return _typethumb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string typeurl
        {
            set { _typeurl = value; }
            get { return _typeurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string typetitle
        {
            set { _typetitle = value; }
            get { return _typetitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? parent
        {
            set { _parent = value; }
            get { return _parent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? type
        {
            set { _type = value; }
            get { return _type; }
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
        public string title1
        {
            set { _title1 = value; }
            get { return _title1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string title2
        {
            set { _title2 = value; }
            get { return _title2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string title3
        {
            set { _title3 = value; }
            get { return _title3; }
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
        public int? thumbw
        {
            set { _thumbw = value; }
            get { return _thumbw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? thumbh
        {
            set { _thumbh = value; }
            get { return _thumbh; }
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
        public string url
        {
            set { _url = value; }
            get { return _url; }
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
        public int? sort
        {
            set { _sort = value; }
            get { return _sort; }
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
        public DateTime lastedittime
        {
            set { _lastedittime = value; }
            get { return _lastedittime; }
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
        public DateTime? starttime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? endtime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        #endregion Model
    }
}
