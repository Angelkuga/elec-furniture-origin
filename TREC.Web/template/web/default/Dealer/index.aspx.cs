using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.ECommerce;
using TRECommon;
using TREC.Web.Code;
using Haojibiz;
using System.Text;
namespace TREC.Web.template.web.Dealer
{
    public partial class index : DealerPageBase
	{

        Haojibiz.DataClasses1DataContext EntityOper = new Haojibiz.DataClasses1DataContext();
        public string seotitle = string.Empty;
        public string seokeyword = string.Empty;
        public string seokeydescrip = string.Empty;

        public string getthumbImg(string id, object thumb)
        {
            if (thumb == null)
            {
                return string.Empty;
            }
            else
            {
                return "/upload/brand/thumb/" + id + "/" + thumb.ToString().Replace(",","");
            }
        }
        public string getlogImg(string id, object log)
        {
            if (log == null)
            {
                return string.Empty;
            }
            else
            {
                return "/upload/brand/logo/" + id + "/" + log.ToString().Replace(",","");
            }
        }
        public string getdescript(object des)
        {
            if (des == null)
            {
                return string.Empty;
            }
            else
            {
                return SubmitMeth.bSubstring(SubmitMeth.DisposeHtml(des.ToString()), 200);
            }
        }

        public string getcreatemid="-1";
        public string getbannelImg
        {
            get
            {
                try
                {
                    if (DealerInfor != null)
                    {
                        if (DealerInfor.bannel.Length > 5)
                        {
                            StringBuilder _value = new StringBuilder(string.Empty);

                            foreach (string s in DealerInfor.bannel.Split(','))
                            {
                                if (s.Length > 2)
                                {
                                    _value.Append(" <div class=\"item\">");
                                    _value.Append("<a href=\"#\" title=\"" + DealerInfor.title + "\" class=\"block\">");
                                    _value.Append(" <img class=\"block\" src=\"/upload/dealer/banner/" + DealerInfor.id + "/" + s + "\" alt=\"" + DealerInfor.title + "\" width=\"947\" height=\"449\" style=\"width: 947px; height: 449px;\" /></a>");
                                    _value.Append("</div>");
                                }
                            }
                            return _value.ToString();
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                catch {
                    return string.Empty;
                }
            }
        }

        public int procunt = 0;

        public int did
        {
            get
            {
                if (Request["did"] != null)
                {
                    return SubmitMeth.getInt(Request["did"]);
                }
                else
                {
                    return 0;
                }
            }
        }

		protected void Page_Load(object sender, EventArgs e)
		{
            List<t_brand> _blist = new List<t_brand>();

            if (DealerInfor != null)
            {
                if (!string.IsNullOrEmpty(DealerInfor.keywords))
                {
                    seotitle = DealerInfor.keywords.Split('|')[0];
                    if (DealerInfor.keywords.Split('|').Length > 1)
                    {
                        seokeyword = "<meta name=\"keywords\" content=\"" + DealerInfor.keywords.Split('|')[1] +"\">"; 
                    }
                    if (DealerInfor.keywords.Split('|').Length > 2)
                    {
                        seokeydescrip = "<meta name=\"description\" content=\"" + DealerInfor.keywords.Split('|')[2] + "\">";
                    }
                }
                else
                {
                    seotitle = DealerInfor.title + "-家具快搜";
                }
                getcreatemid = DealerInfor.mid.ToString();
                //_blist = EntityOper.t_brand.Where(p => p.createmid == DealerInfor.mid && p.auditstatus == 1 && p.linestatus == 1).ToList();
                Repeater_brand.DataSource = ECBrand.getBrandList(" and createmid ="+DealerInfor.mid+" and auditstatus = 1 and linestatus =1 ");
                Repeater_brand.DataBind();

                procunt = EntityOper.t_product.Where(p => p.createmid == DealerInfor.mid).Count();
            }
		}
	}
}