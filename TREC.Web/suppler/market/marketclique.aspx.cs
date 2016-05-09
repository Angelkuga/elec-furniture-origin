using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRECommon;
using TREC.ECommerce;
using TREC.Entity;
using System.Text;

namespace TREC.Web.Suppler.market
{
    public partial class marketclique : SupplerPageBase
    {
        public int marketid = 0;
        protected string auditstatus = "";
        protected StringBuilder submarketItem = new StringBuilder();

        protected string checkdisplay = "";

        private void sendMail(string content, string mail)
        {
            string mailsubject = content;

            bool rsmail = EmailHelper.SendEmail("集团用户注册提示", mail, mailsubject);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (memberInfo != null)
                {
                    //marketid = marketInfo.id;
                   
                    if (memberInfo.type != 105 && memberInfo.type==100)
                     {
                         memberInfo.type=105;
                         string Description = "集团新用户注册信息，登陆帐号：" + memberInfo.username + ",电话号码：" + memberInfo.mobile + ",商家id：" + memberInfo.id+",商家类型：105";
                        sendMail(Description, "angela@jiajuks.com");
                         sendMail(Description, "liujing@jiajuks.com");
                         ECMember.ModifyMenber2(memberInfo);  
                     memberInfo = ECMember.GetMemberInfo(" where id=" + CookiesHelper.GetCookie("mid") + " and password='" + CookiesHelper.GetCookie("mpwd") + "'");
                     }
                    #region 初始化数据
                    Master.menuName = "marketclique";
                    #endregion
                    ShowData();
                    if (memberInfo.type != 105)
                    {
                        checkdisplay = "none";
                    }
                }
            }
        }


        protected void ShowData()
        {
            EnMarketClique model=new EnMarketClique();
            if (memberInfo.type == 105)
            {
                 model = ECommerce.ECMarketClique.GetMarketCliqueByMid(memberInfo.id);
                
            }
            else
            {
                txttitle.ReadOnly = true;
                EnMarket _enmarket = null;
                if (marketInfo != null)
                {
                   _enmarket= ECMarket.GetMarketInfo("  where id=" + marketInfo.id);
                }
                if (_enmarket != null)
                {
                    model = ECommerce.ECMarketClique.GetMarketCliqueByWhere("WHERE REPLACE(title,'集团','')='" + _enmarket.MarketCliqueName.Replace("集团", "") + "'");
                }
                if (model != null)
                {
                    if (model.CreateMid == 0 && model.MarketId == _enmarket.id)
                    {
                        trbnt.Style.Add("display", "block");
                    }
                    else
                    {
                        trbnt.Style.Add("display", "none");
                    }
                }
            }
            if (model != null)
            {
                txttitle.Text = model.Title;
                txtchairman.Text = model.Chairman;
                txtchairmanoration.Text = model.ChairmanOration;
                txtdescript.Text = model.Descript;
                auditstatus = ((EnumAuditStatus)System.Enum.Parse(typeof(EnumAuditStatus), model.Auditstatus.ToString())).ToString();
                hidId.Value = model.Id.ToString();
                hfchairmanimg.Value = model.ChairmanImg;
                hfinfoimg.Value = model.InfoImg;
                hfthumbimg.Value = model.ThumbImg;
                hidelogimg.Value = model.LogImg;
                txt_address.Text = model.Address;
                txt_phone.Text = model.Phone;
                string submarketidlist = "";
                //foreach (string items in ECommerce.ECMarketClique.GetSubMarketByMarketCliqueId(model.Id))
                //{
                //    if (submarketidlist == string.Empty)
                //    {
                //        submarketidlist = items;
                //    }
                //    else
                //    {
                //        submarketidlist += "," + items;
                //    }
                //}

                hfsubmarketidlist.Value = submarketidlist;
            }
            else
            {
                EnMarket _enmarket = null;
                if (marketInfo != null)
                {
                    _enmarket = ECMarket.GetMarketInfo("  where id=" + marketInfo.id);
                    txttitle.Text = _enmarket.MarketCliqueName;
                }
            }
           
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int mcid = 0;
            int.TryParse(hidId.Value, out mcid);
            int marketid = 0;
            EnMarketClique model=null ;
             //model = ECommerce.ECMarketClique.GetMarketCliqueByMid(memberInfo.id);

            if (memberInfo.type == 105)//集团帐号
            {
                model = ECommerce.ECMarketClique.GetMarketCliqueByMid(memberInfo.id);

                if (model == null)
                {
                    //查询是否卖场已经添加了集团信息
                   model=ECommerce.ECMarketClique.GetMarketCliqueByWhere("WHERE REPLACE(title,'集团','')='" + txttitle.Text.Replace("集团", "") + "' and marketid>0");
                }
            }
            else
            {
                EnMarket _enmarket = null;
                if (marketInfo != null)
                {
                    _enmarket = ECMarket.GetMarketInfo("  where id=" + marketInfo.id);
                }
                if (_enmarket != null)
                {
                    marketid = _enmarket.id;
                    model = ECommerce.ECMarketClique.GetMarketCliqueByWhere(" where marketid=" + _enmarket.id);
                }

            }

            if (model == null)
            {
                model = new EnMarketClique();
                model.Id = 0;
            }
            #region 后台验证参数
            if (string.IsNullOrEmpty(txttitle.Text))
            {
                Response.Write("<script>alert('集团名称必须填写！');window.history.go(-1);</script>");
                Response.End();
            }
            #endregion

            #region 接收参数
            if (model == null) model = new EnMarketClique();
            model.Title = txttitle.Text.Replace("集团","");
            
            model.Chairman = txtchairman.Text;
            model.ChairmanOration = txtchairmanoration.Text;
            model.Descript = txtdescript.Text;
            if (!string.IsNullOrEmpty(hidId.Value) && hidId.Value != "0")
                model.Id = int.Parse(hidId.Value);
            
            if (memberInfo.type == 105)
            {
                model.CreateMid = memberInfo.id;
                model.MarketId = 0;
            }
            else
            {
                model.CreateMid = 0;
                model.MarketId = marketid;
            }

            if (model.Id == 0)
            {
                model.CreateTime = DateTime.Now;
                model.LastediTime = DateTime.Now;
               
                
            }
            else
            {
                model.LastediTime = DateTime.Now;
            }
            string chairmanimg = this.hfchairmanimg.Value.Replace(",","");
            model.ChairmanImg = chairmanimg;
            string infoimg = this.hfinfoimg.Value.Replace(",","");
            model.InfoImg = infoimg;
            string thumbimg = this.hfthumbimg.Value.Replace(",","");
            string hlogimg=hidelogimg.Value.Replace(",","");

            model.ThumbImg = thumbimg;
            model.LogImg = hlogimg;
            model.Address = txt_address.Text.Trim();
            model.Phone = txt_phone.Text;

            #endregion

            #region  保存图片
            //int aid = memberInfo.id;
            //if (aid > 0)
            //{
            //    ECUpLoad ecUpload = new ECUpLoad();
            //    if (chairmanimg.Length > 0)
            //    {
            //        ecUpload.MoveFiles(chairmanimg.TrimEnd(','), string.Format(EnFilePath.Market, aid, EnFilePath.Chairman));
            //    }
            //    if (infoimg.Length > 0)
            //    {
            //        ecUpload.MoveFiles(infoimg.TrimEnd(','), string.Format(EnFilePath.Market, aid, EnFilePath.MarketClique));
            //    }
            //    if (thumbimg.Length > 0)
            //    {
            //        ecUpload.MoveFiles(thumbimg.TrimEnd(','), string.Format(EnFilePath.Market, aid, EnFilePath.MarketCliqueThumb));
            //    }
            //    if (hlogimg.Length > 0)
            //    {
            //        ecUpload.MoveFiles(hlogimg.TrimEnd(','), string.Format(EnFilePath.Market, aid, EnFilePath.MarketCliqueThumb));
            //    }
            //}
            #endregion

            EnMarketClique modelc =null;

            if (model.Id == 0)
            {
                modelc = ECommerce.ECMarketClique.GetMarketCliqueByWhere("WHERE REPLACE(title,'集团','')='" + model.Title.Replace("集团", "") + "' ");
            }
            else
            {
               
                    modelc = ECommerce.ECMarketClique.GetMarketCliqueByWhere("WHERE REPLACE(title,'集团','')='" + model.Title.Replace("集团", "") + "' and    id!=" + model.Id);
               
            }
            if (modelc == null)
            {
                int rs = ECommerce.ECMarketClique.EditMarketClique(model);

                if (model.Id == 0)
                    model.Id = rs;
                //if (!string.IsNullOrEmpty(hfsubmarketidlist.Value))
                //{
                //    ECommerce.ECMarketClique.SetSubMarket(model.Id, hfsubmarketidlist.Value);
                //}
                //else
                //{
                //    ECommerce.ECMarketClique.DeleteSubMarket(model.Id);
                //}
                Response.Write("<script>alert('保存集团信息成功！');location.href='marketclique.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('集团名称已经存在！');</script>");
            }
        }
    }
}