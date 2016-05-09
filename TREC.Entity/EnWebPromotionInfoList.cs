using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    public class EnWebPromotionInfoList
    {
        #region Model
        private string _brandlogo;
        private string _ptitle;
        private string _htmltitle;
        private DateTime? _startdatetime;
        private DateTime? _enddatetime;
        private string _areacode;
        private string _address;
        private int? _ptype;
        private int _id;
        private string _title;
        private int _pid;
        private string _attribute;
        private string _type;
        private string _value;
        private string _valueletter;
        private string _valuetitle;
        private string _thumb;
        private string _banner;
        private string _descript;
        private string _curcountmoney;
        private string _curcountpeople;
        private string _curstage;
        private string _fordio;
        private int? _sort;
        private string _stagelist;
        private int? _stagecount;
        //public 
        

        /// <summary>
        /// 
        /// </summary>
        public string brandlogo
        {
            set { _brandlogo = value; }
            get { return _brandlogo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ptitle
        {
            set { _ptitle = value; }
            get { return _ptitle; }
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
        public int? ptype
        {
            set { _ptype = value; }
            get { return _ptype; }
        }
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
        public int pid
        {
            set { _pid = value; }
            get { return _pid; }
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
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value
        {
            set { _value = value; }
            get { return _value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string valueletter
        {
            set { _valueletter = value; }
            get { return _valueletter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string valuetitle
        {
            set { _valuetitle = value; }
            get { return _valuetitle; }
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
        public string banner
        {
            set { _banner = value; }
            get { return _banner; }
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
        public string curcountmoney
        {
            set { _curcountmoney = value; }
            get { return _curcountmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string curcountpeople
        {
            set { _curcountpeople = value; }
            get { return _curcountpeople; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string curstage
        {
            set { _curstage = value; }
            get { return _curstage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fordio
        {
            set { _fordio = value; }
            get { return _fordio; }
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
        public string stagelist
        {
            set { _stagelist = value; }
            get { return _stagelist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? stagecount
        {
            set { _stagecount = value; }
            get { if (_stagecount == 0)return 1; return _stagecount; }
        }

        #endregion Model


        private List<EnPromotionStage> _Stagelist = new List<EnPromotionStage>();
        public List<EnPromotionStage> StageList
        {
            get
            {
                if (!string.IsNullOrEmpty(stagelist))
                {
                    List<EnPromotionStage> list = new List<EnPromotionStage>();
                    string pattern = string.Format("{0}(?<g>(.|[\r\n])+?){1}", "<type>", "</type>");//匹配URL的模式,并分组
                    MatchCollection mc = Regex.Matches(stagelist, pattern);//满足pattern的匹配集合
                    if (mc.Count != 0)
                    {
                        foreach (Match match in mc)
                        {
                            GroupCollection gc = match.Groups;
                            EnPromotionStage m = (EnPromotionStage)TRECommon.SerializationHelper.DeSerialize(typeof(EnPromotionStage), "<EnPromotionStage>" + gc["g"].Value + "</EnPromotionStage>");
                            
                            list.Add(m);
                        }
                    }
                    return list;
                }
                return new List<EnPromotionStage>();
            }
        }

    }
}
