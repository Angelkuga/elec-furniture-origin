using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TREC.Entity;
using TREC.ECommerce;
using System.Text;
using TRECommon;

namespace TREC.Web.Suppler.market
{
    public partial class marketminInfor : SupplerPageBase
    {
        public string areaCode = "";
        public string marketTitle = string.Empty;

        public EnMember _memberInfo = null;
        protected EnMarketClique _marketClique = null;
        public static EnMarket marketInfoMin = null;
        public string dropMarket;

        public string droparea;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 初始化数据
            if (!IsPostBack)
            {
                

                EnMarketClique model = ECommerce.ECMarketClique.GetMarketCliqueByMid(memberInfo.id);
                if (model != null)
                {
                    txt_Clique.Text = model.Title.Replace("集团", "");
                }
                else
                {
                    ScriptUtils.ShowAndRedirect("请完善集团信息!", "marketclique.aspx");
                }

               
                    ddlPro.Items.Clear();
                    ddlPro.DataSource = ECArea.GetAreaList(" parentcode=0");
                    ddlPro.DataTextField = "areaname";
                    ddlPro.DataValueField = "areacode";
                    ddlPro.DataBind();
                    ddlPro.Items.Insert(0, new ListItem("请选择", ""));

                    ddlregcity.Items.Clear();
                    ddlregcity.Items.Insert(0, new ListItem("请选择省份", ""));
               

                if (Request["Id"] != null)
                {


                    marketInfoMin = ECMarket.GetMarketInfo(" where Id=" + Request["Id"]);
                    EnArea _area3 = new EnArea();
                    EnArea _area2 = new EnArea();

                    marketTitle = marketInfoMin.title;
                    txt_stitle.Text = marketInfoMin.Stitle;
                    txtletter.Text = marketInfoMin.letter;
                    txtaddress.Text = marketInfoMin.address;
                    this.hfsurface.Value = marketInfoMin.surface.Replace(",", "");
                    this.hflogo.Value = marketInfoMin.logo.Replace(",", "");
                    this.hfthumb.Value = marketInfoMin.thumb.Replace(",", "");

                    try
                    {
                        _area3 = ECArea.GetAreaList("areacode='" + marketInfoMin.areacode + "'").FirstOrDefault();
                        if (_area3 != null)
                        {
                            _area2 = ECArea.GetAreaList("areacode='" + _area3.parentcode + "'").FirstOrDefault();
                        }



                        string pcode = _area2.parentcode == "0" ? _area2.areacode : _area2.parentcode;
                        ddlPro.SelectedIndex = -1;
                        ddlPro.Items.FindByValue(pcode).Selected = true;

                        ddlregcity.Items.Clear();
                        ddlregcity.DataSource = ECArea.GetAreaList("parentcode='" + _area2.parentcode + "'");
                        ddlregcity.DataTextField = "areaname";
                        ddlregcity.DataValueField = "areacode";
                        ddlregcity.DataBind();
                        ddlregcity.SelectedIndex = -1;
                        ddlregcity.Items.FindByValue(_area2.areacode).Selected = true;

                        if (_area3 != null)
                        {
                            foreach (EnArea en in ECArea.GetAreaList("parentcode='" + _area3.parentcode + "'"))
                            {
                                if (en.areacode != _area3.areacode)
                                {
                                    droparea = droparea + "<option  value=\"" + en.areacode + "\">" + en.areaname + "</option>";
                                }
                                else
                                {
                                    droparea = droparea + "<option selected=\"selected\" value=\"" + en.areacode + "\">" + en.areaname + "</option>";
                                }
                            }
                        }
                    }
                    catch
                    { 
                    }
                    

                }
                else
                {
                    droparea="<option selected=\"selected\" value=\"0\">--区--</option>";
                }

                if (model != null)
                {
                    List<EnMarket> _listMarket = ECMarket.GetMarketList(" MarketCliqueName='" + model.Title.Replace("集团", "") + "'");

                    StringBuilder _value = new StringBuilder(string.Empty);

                    foreach (EnMarket m in _listMarket)
                    {
                        if (m.title != marketTitle)
                        {
                            _value.Append("<li value='" + m.id + "'>" + m.title + "</li>");
                        }
                    }
                    dropMarket = _value.ToString();
                }
            }
            #endregion
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
                marketInfoMin = new EnMarket();
        
            #region 接收输入参数
                string areacode = Request["selArea"];
                int i = 0;
                if (string.IsNullOrEmpty(areacode)|| areacode.Length<2)
                {
                    i++;
                    ScriptUtils.Alert(this, "请选择地区");
                   
                }
                if (String.IsNullOrEmpty(txt_Clique.Text.Trim()))
                {
                    i++;
                    ScriptUtils.Alert(this, "请填写集团名称");
                    
                }

                if (string.IsNullOrEmpty(txt_stitle.Text.Trim()))
                {
                    i++;
                    ScriptUtils.Alert(this, "请填写卖场名称");
                    
                }
                if (i == 0)
                {
                    string title = txt_Clique.Text.Trim() + txt_stitle.Text.Trim();
                    List<EnMarket> _listMarket;
                    if (Request["Id"] == null)
                    {
                        _listMarket = ECMarket.GetMarketList(" title='" + title + "'");
                    }
                    else
                    {
                        _listMarket = ECMarket.GetMarketList(" title='" + title + "' and id!=" + Request["Id"]);
                    }
                    if (_listMarket.Count == 0 && txt_stitle.Text.Trim() != string.Empty)
                    {
                        string letter = this.txtletter.Text;
                        string industry = "";
                        string productcategory = "";

                        string address = this.txtaddress.Text;


                        string regcity = Request["selArea"];

                        string sell = "";

                        string surface = this.hfsurface.Value.Replace(",", "");
                        string logo = this.hflogo.Value.Replace(",", "");
                        string thumb = this.hfthumb.Value.Replace(",", "");

                        DateTime lastedittime = DateTime.Now;
            #endregion

                        #region 赋值
                        if (Request["Id"] != null)
                        {
                            marketInfoMin.id = Int32.Parse(Request["Id"]);
                        }
                        else
                        {
                            marketInfoMin.id = 0;
                        }

                        marketInfoMin.mid = 0;
                        marketInfoMin.createmid = memberInfo.id;
                        marketInfoMin.title = title;
                        marketInfoMin.letter = letter;
                        marketInfoMin.industry = industry;
                        marketInfoMin.productcategory = productcategory;
                        marketInfoMin.areacode = areacode;
                        marketInfoMin.address = address;
                        marketInfoMin.regcity = regcity;
                        marketInfoMin.sell = sell;
                        marketInfoMin.surface = surface;
                        marketInfoMin.logo = logo;
                        marketInfoMin.thumb = thumb;
                        marketInfoMin.lastedittime = lastedittime;
                        marketInfoMin.lastedid = memberInfo.id;
                        marketInfoMin.mapapi = "";
                        marketInfoMin.MarketCliqueName = txt_Clique.Text.Trim();
                        marketInfoMin.Stitle = txt_stitle.Text.Trim();
                        marketInfoMin.template = "1";
                        #endregion
                        int aid = ECMarket.EditMarket(marketInfoMin);
                        #region 上传图片

                        #endregion
                        // UiCommon. ShowAndRedirect
                        //JscriptPrint(this.Page, "编辑成功!", "marketinfo.aspx", "Success");
                        //ShowAndRedirect()
                        //TREC.ECommerce.UiCommon.ShowAndRedirect("","");
                        if (Request["Id"] == null)
                        {
                            ScriptUtils.ShowAndRedirect("添加成功!", "marketminInfor.aspx");
                        }
                        else
                        {
                            ScriptUtils.ShowAndRedirect("保存成功!", "marketminList.aspx");
                        }
                    }
                    else
                    {
                        if (Request["Id"] == null)
                        {
                            ScriptUtils.ShowAndRedirect("卖场已经存在，不能重复添加!", "marketminInfor.aspx");
                        }
                        else
                        {
                            ScriptUtils.Alert(this, "卖场已经存在，不能重复添加");
                        }
                    }
                }
            

        }
    }
}