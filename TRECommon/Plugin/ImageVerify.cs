using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;
using TRECommon;

namespace TRECommon.Plugin
{
    //前台方法
    //1.新建文件 XXXX.aspx 删除代码文件 只留 .aspx文件
    //1-2. 将xxx.aspx 文件 codebind 到  TRECommon.Plugin.ImageVerify  
    //      eg:<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imageVerify.aspx.cs" Inherits="TRECommon.Plugin.ImageVerify" %>
    //2.<asp:image ID="Image1" runat="server" ImageUrl="~/tools/xxx.aspx?model="></asp:image> //model为session键值。防止多页面同时验证。覆盖问题

    public class ImageVerify : System.Web.UI.Page
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            string t = Request.QueryString["t"] == null ? "1" : Request.QueryString["t"];
            int w = Request.QueryString["w"] == null ? 15 : TRECommon.TypeConverter.StrToInt(Request.QueryString["w"]);
            int h = Request.QueryString["h"] == null ? 20 : TRECommon.TypeConverter.StrToInt(Request.QueryString["h"]);
            int l = Request.QueryString["l"] == null ? 4 : TRECommon.TypeConverter.StrToInt(Request.QueryString["l"]);
            string model = Request.QueryString["model"] == null ? "" : Request.QueryString["model"];
            string tempCode = "";
            switch (t)
            {
                case "1":
                    tempCode=WebUtils.GetNumVerify(l);
                    break;
                case "2":
                    tempCode=WebUtils.GetRandomNumVerify(l);
                    break;
                case "3":
                    tempCode=WebUtils.GetRandomNumAndLetterVerify(l);
                    break;
                case "4":
                    tempCode=WebUtils.GetRandomRegionVerifyByLength(l);
                    break;
                default:
                    tempCode = WebUtils.GetNumVerify(l);
                    break;
            }

            CreateVerifyImage(tempCode, w, h);
            SessionHelper.Add("_session_" + model, tempCode, 720);
        }


        private void CreateVerifyImage(string checkCode,int width,int height)
        {
            if (checkCode == null || checkCode.Trim() == String.Empty)
                return;
            int iWordWidth = 15;
            int iImageWidth = checkCode.Length * iWordWidth;
            Bitmap image = new Bitmap(iImageWidth, 20);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器 
                Random random = new Random();
                //清空图片背景色 
                g.Clear(Color.White);

                //画图片的背景噪音点
                for (int i = 0; i < 20; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                //画图片的背景噪音线 
                for (int i = 0; i < 2; i++)
                {
                    int x1 = 0;
                    int x2 = image.Width;
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    if (i == 0)
                    {
                        g.DrawLine(new Pen(Color.Gray, 2), x1, y1, x2, y2);
                    }

                }


                for (int i = 0; i < checkCode.Length; i++)
                {

                    string Code = checkCode[i].ToString();
                    int xLeft = iWordWidth * (i);
                    random = new Random(xLeft);
                    int iSeed = DateTime.Now.Millisecond;
                    int iValue = random.Next(iSeed) % 4;
                    if (iValue == 0)
                    {
                        Font font = new Font("Arial", 13, (FontStyle.Bold | System.Drawing.FontStyle.Italic));
                        Rectangle rc = new Rectangle(xLeft, 0, iWordWidth, image.Height);
                        LinearGradientBrush brush = new LinearGradientBrush(rc, Color.Blue, Color.Red, 1.5f, true);
                        g.DrawString(Code, font, brush, xLeft, 2);
                    }
                    else if (iValue == 1)
                    {
                        Font font = new System.Drawing.Font("楷体", 13, (FontStyle.Bold));
                        Rectangle rc = new Rectangle(xLeft, 0, iWordWidth, image.Height);
                        LinearGradientBrush brush = new LinearGradientBrush(rc, Color.Blue, Color.DarkRed, 1.3f, true);
                        g.DrawString(Code, font, brush, xLeft, 2);
                    }
                    else if (iValue == 2)
                    {
                        Font font = new System.Drawing.Font("宋体", 13, (System.Drawing.FontStyle.Bold));
                        Rectangle rc = new Rectangle(xLeft, 0, iWordWidth, image.Height);
                        LinearGradientBrush brush = new LinearGradientBrush(rc, Color.Green, Color.Blue, 1.2f, true);
                        g.DrawString(Code, font, brush, xLeft, 2);
                    }
                    else if (iValue == 3)
                    {
                        Font font = new System.Drawing.Font("黑体", 13, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Bold));
                        Rectangle rc = new Rectangle(xLeft, 0, iWordWidth, image.Height);
                        LinearGradientBrush brush = new LinearGradientBrush(rc, Color.Blue, Color.Green, 1.8f, true);
                        g.DrawString(Code, font, brush, xLeft, 2);
                    }
                }

                ////画图片的前景噪音点 
                for (int i = 0; i < 8; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线 
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                this.Page.Response.ClearContent();

                Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }


    }
}
