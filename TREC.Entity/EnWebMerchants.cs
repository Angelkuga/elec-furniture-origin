using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TREC.Entity
{
    public class EnWebMerchants
    {
        public EnWebMerchants()
        { }

        #region Model
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int cid;

        public int Cid
        {
            get { return cid; }
            set { cid = value; }
        }
        private string brandid;

        public string Brandid
        {
            get { return brandid; }
            set { brandid = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string descript;

        public string Descript
        {
            get { return descript; }
            set { descript = value; }
        }
        private int auditstatus;

        public int Auditstatus
        {
            get { return auditstatus; }
            set { auditstatus = value; }
        }
        private int linestatus;

        public int Linestatus
        {
            get { return linestatus; }
            set { linestatus = value; }
        }
        private DateTime createtime;

        public DateTime Createtime
        {
            get { return createtime; }
            set { createtime = value; }
        }

        private DateTime lastedittime;

        public DateTime Lastedittime
        {
            get { return lastedittime; }
            set { lastedittime = value; }
        }

        private int membercount;

        public int Membercount
        {
            get { return membercount; }
            set { membercount = value; }
        }

        private string companyxml;

        public string Companyxml
        {
            get { return companyxml; }
            set { companyxml = value; }
        }

        private string brandxml;

        public string Brandxml
        {
            get { return brandxml; }
            set { brandxml = value; }
        }

        #endregion

        public string shopMapapi = "";

        public List<MerchantsCompanyList> GetMerchantsCompanyList
        {
            get
            {
                if (!string.IsNullOrEmpty(Companyxml))
                {
                    List<MerchantsCompanyList> list = new List<MerchantsCompanyList>();
                    string pattern = string.Format("{0}(?<g>(.|[\r\n])+?){1}", "<type>", "</type>");//匹配URL的模式,并分组
                    MatchCollection mc = Regex.Matches(Companyxml, pattern);//满足pattern的匹配集合
                    if (mc.Count != 0)
                    {
                        foreach (Match match in mc)
                        {
                            MerchantsCompanyList m = new MerchantsCompanyList();
                            GroupCollection gc = match.Groups;
                            list.Add((MerchantsCompanyList)TRECommon.SerializationHelper.DeSerialize(typeof(MerchantsCompanyList), "<MerchantsCompanyList>" + gc["g"].Value + "</MerchantsCompanyList>"));
                        }
                    }
                    return list;
                }
                return new List<MerchantsCompanyList>();
            }
        }

        public List<MerchantsBrandList> GetMerchantsBrandList
        {
            get
            {
                if (!string.IsNullOrEmpty(Brandxml))
                {
                    List<MerchantsBrandList> list = new List<MerchantsBrandList>();
                    string pattern = string.Format("{0}(?<g>(.|[\r\n])+?){1}", "<type>", "</type>");//匹配URL的模式,并分组
                    MatchCollection mc = Regex.Matches(Brandxml, pattern);//满足pattern的匹配集合
                    if (mc.Count != 0)
                    {
                        foreach (Match match in mc)
                        {
                            MerchantsBrandList m = new MerchantsBrandList();
                            GroupCollection gc = match.Groups;
                            list.Add((MerchantsBrandList)TRECommon.SerializationHelper.DeSerialize(typeof(MerchantsBrandList), "<MerchantsBrandList>" + gc["g"].Value + "</MerchantsBrandList>"));
                        }
                    }
                    return list;
                }
                return new List<MerchantsBrandList>();
            }
        }
 
    }

    [Serializable]
    public class MerchantsCompanyList
    {
        public string id { get; set; }
        public string title { get; set; }
        public string logo { get; set; }
    }

    [Serializable]
    public class MerchantsBrandList
    {
        public string id { get; set; }
        public string title { get; set; }
        public string material { get; set; }
        public string style { get; set; }
        public string logo { get; set; }
        public string thumb { get; set; }
    }
}
