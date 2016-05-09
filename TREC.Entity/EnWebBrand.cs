using System;

namespace TREC.Entity
{
    [Serializable]
    public class EnWebBrand
    {
        
        /// <summary>
        /// id
        /// </summary>		
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// companyid
        /// </summary>		
        private int _companyid;
        public int companyid
        {
            get { return _companyid; }
            set { _companyid = value; }
        }
        /// <summary>
        /// title
        /// </summary>		
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// letter
        /// </summary>		
        private string _letter;
        public string letter
        {
            get { return _letter; }
            set { _letter = value; }
        }
        /// <summary>
        /// groupid
        /// </summary>		
        private int _groupid;
        public int groupid
        {
            get { return _groupid; }
            set { _groupid = value; }
        }
        /// <summary>
        /// attribute
        /// </summary>		
        private string _attribute;
        public string attribute
        {
            get { return _attribute; }
            set { _attribute = value; }
        }
        /// <summary>
        /// productcategory
        /// </summary>		
        private string _productcategory;
        public string productcategory
        {
            get { return _productcategory; }
            set { _productcategory = value; }
        }
        /// <summary>
        /// homepage
        /// </summary>		
        private string _homepage;
        public string homepage
        {
            get { return _homepage; }
            set { _homepage = value; }
        }
        /// <summary>
        /// productcount
        /// </summary>		
        private int _productcount;
        public int productcount
        {
            get { return _productcount; }
            set { _productcount = value; }
        }
        /// <summary>
        /// spread
        /// </summary>		
        private string _spread;
        public string spread
        {
            get { return _spread; }
            set { _spread = value; }
        }
        /// <summary>
        /// material
        /// </summary>		
        private string _material;
        public string material
        {
            get { return _material; }
            set { _material = value; }
        }
        /// <summary>
        /// style
        /// </summary>		
        private string _style;
        public string style
        {
            get { return _style; }
            set { _style = value; }
        }
        /// <summary>
        /// companyname
        /// </summary>		
        private string _companyname;
        public string companyname
        {
            get { return _companyname; }
            set { _companyname = value; }
        }
        /// <summary>
        /// spreadname
        /// </summary>		
        private string _spreadname;
        public string spreadname
        {
            get { return _spreadname; }
            set { _spreadname = value; }
        }
        /// <summary>
        /// stylename
        /// </summary>		
        private string _stylename;
        public string stylename
        {
            get { return _stylename; }
            set { _stylename = value; }
        }
        /// <summary>
        /// materialname
        /// </summary>		
        private string _materialname;
        public string materialname
        {
            get { return _materialname; }
            set { _materialname = value; }
        }
        /// <summary>
        /// surface
        /// </summary>		
        private string _surface;
        public string surface
        {
            get { return _surface; }
            set { _surface = value; }
        }
        /// <summary>
        /// logo
        /// </summary>		
        private string _logo;
        public string logo
        {
            get { _logo = _logo.StartsWith(",") ? _logo.Substring(1, _logo.Length - 1) : _logo;
            _logo = _logo.EndsWith(",") ? _logo.Substring(0, _logo.Length - 1) : _logo;
            return _logo;
            }
            set { _logo = value; }
        }
        /// <summary>
        /// thumb
        /// </summary>		
        private string _thumb;
        public string thumb
        {
            get { return _thumb; }
            set { _thumb = value; }
        }
        /// <summary>
        /// bannel
        /// </summary>		
        private string _bannel;
        public string bannel
        {
            get { return _bannel; }
            set { _bannel = value; }
        }
        /// <summary>
        /// desimage
        /// </summary>		
        private string _desimage;
        public string desimage
        {
            get { return _desimage; }
            set { _desimage = value; }
        }
        /// <summary>
        /// descript
        /// </summary>		
        private string _descript;
        public string descript
        {
            get { return _descript; }
            set { _descript = value; }
        }
        /// <summary>
        /// keywords
        /// </summary>		
        private string _keywords;
        public string keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }
        /// <summary>
        /// template
        /// </summary>		
        private string _template;
        public string template
        {
            get { return _template; }
            set { _template = value; }
        }
        /// <summary>
        /// hits
        /// </summary>		
        private int _hits;
        public int hits
        {
            get { return _hits; }
            set { _hits = value; }
        }
        /// <summary>
        /// sort
        /// </summary>		
        private int _sort;
        public int sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
        /// <summary>
        /// createmid
        /// </summary>		
        private int _createmid;
        public int createmid
        {
            get { return _createmid; }
            set { _createmid = value; }
        }
        /// <summary>
        /// lasteditid
        /// </summary>		
        private int _lasteditid;
        public int lasteditid
        {
            get { return _lasteditid; }
            set { _lasteditid = value; }
        }
        /// <summary>
        /// lastedittime
        /// </summary>		
        private DateTime _lastedittime;
        public DateTime lastedittime
        {
            get { return _lastedittime; }
            set { _lastedittime = value; }
        }
        /// <summary>
        /// auditstatus
        /// </summary>		
        private int _auditstatus;
        public int auditstatus
        {
            get { return _auditstatus; }
            set { _auditstatus = value; }
        }
        /// <summary>
        /// linestatus
        /// </summary>		
        private int _linestatus;
        public int linestatus
        {
            get { return _linestatus; }
            set { _linestatus = value; }
        }        
    }
}
