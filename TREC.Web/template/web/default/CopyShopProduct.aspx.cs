using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data;
using TREC.ECommerce;
using TREC.Entity;
using TRECommon;
using Haojibiz;

namespace TREC.Web.template.web
{
	public partial class CopyShopProduct : System.Web.UI.Page
	{
        private void saveproductcopyshop(string companyid, string shopId, string brandid)
        {
            ////产品id
            //string productId = string.Empty;
            //if (!string.IsNullOrEmpty(c.Request["productId"]))
            //    productId = c.Request["productId"].Trim();

            ////店铺id
            //string shopId = string.Empty;
            //if (!string.IsNullOrEmpty(c.Request["shopId"]))
            //    shopId = c.Request["shopId"].Trim();

            if (!string.IsNullOrEmpty(shopId))
            {
                
                shopId = shopId.TrimEnd(',').Trim();
                string[] shopids = shopId.Split(',');
                int myId = 0;
                for (int i = 0; i < shopids.Length; i++)
                {
                    List<EnProduct> modelList = ECProduct.GetProductList(" companyid=" + companyid + " and brandid=" + brandid + " ");
                    foreach (EnProduct item in modelList)
                    {
                        if (ECProduct.GetProductList(" companyid=" + companyid + " AND shopid=" + shopids[i] + " and brandid="+brandid).ToList().Count == 0)
                        {
                            #region 复制图片和属性
                            int oldId = item.id;
                            EnProduct proModel = new EnProduct();
                            proModel = item;
                            int.TryParse(shopids[i], out myId);
                            proModel.id = 0;
                            proModel.tob2c = "add";
                            proModel.shopid = myId;
                            int aid = ECProduct.EditProduct(proModel);
                            if (aid > 0)
                            {
                                #region 复制图片

                                //复制图片
                                string oldFilePath = string.Empty;
                                string newFilePath = string.Empty;
                                string newFilePath2 = string.Empty;
                                oldFilePath = Server.MapPath("~/upload/product/thumb/" + oldId + "/" + item.thumb);
                                //  string newAtri = hfproductattribute.Value;
                                if (oldFilePath.Substring(oldFilePath.Length - 1, 1) == ",")
                                {
                                    oldFilePath = oldFilePath.Substring(0, oldFilePath.Length - 1);
                                }

                                if (oldFilePath != "" && File.Exists(oldFilePath))
                                {
                                    var str1 = oldFilePath.Substring(0, oldFilePath.IndexOf("thumb") + 6);
                                    var str2 = oldFilePath.Substring(str1.Length, oldFilePath.Length - str1.Length);
                                    newFilePath = str1 + aid + "\\" + str2.Substring(str2.LastIndexOf("\\"), str2.Length - str2.LastIndexOf("\\"));
                                    newFilePath2 = str1 + aid + "\\";
                                    try
                                    {
                                        if (!Directory.Exists(newFilePath2))
                                        {
                                            Directory.CreateDirectory(newFilePath2);
                                        }

                                        DirectoryInfo dinfo = new DirectoryInfo(Server.MapPath("~/upload/product/thumb/" + oldId + "/"));//注，这里面传的是路径，并不是文件，所以不能保含带后缀的文件
                                        foreach (FileSystemInfo f in dinfo.GetFileSystemInfos())
                                        {
                                            File.Copy(oldFilePath, newFilePath, true);//true代表可以覆盖同名文件
                                        }
                                    }
                                    catch (Exception)
                                    {

                                        throw;
                                    }
                                }
                                #endregion

                                #region 复制产品属性
                                //复制产品属性
                                List<EnProductAttribute> listproductattribute = ECProductAttribute.GetProductAttributeList(" productid='" + oldId + "'");
                                foreach (EnProductAttribute patrrModel in listproductattribute)
                                {
                                    EnProductAttribute attrModel = new EnProductAttribute();
                                    attrModel = patrrModel;
                                    attrModel.id = 0;
                                    attrModel.productid = aid;
                                    ECProductAttribute.EditProductAttribute(attrModel);
                                }
                                #endregion

                               // Response.Write("ok");
                            }
                            else
                            {
                              //  Response.Write(null);
                            }
                            #endregion
                        }
                    }
                }
                // int quantity = 0;
                //bool IsCopy =ProductBll.SaveCopyProductToShopDb(productId, shopId, out quantity);
                //if (IsCopy)
                //    c.Response.Write(quantity);
                //else
                //    c.Response.Write(null);
            }
            else
                Response.Write(null);
        }

		protected void Page_Load(object sender, EventArgs e)
		{
            //List<EnProduct> modelList = ECProduct.GetProductList("  id=22643 ");
            // foreach (EnProduct item in modelList)
            // {
            //     string t = item.createtime.ToString("yyyy-MM-dd HH:mm:ss");
            // }
           
            
		}

        protected void Button1_Click(object sender, EventArgs e)
        {
             DataTable dt = new DataTable();
            dt = ECProduct.copyShopproduct(TextBox1.Text.Trim());
            foreach (DataRow r in dt.Rows)
            {
                if (r["companyid"].ToString() != "0")
                {
                    saveproductcopyshop(r["companyid"].ToString(), r["shopid"].ToString(), r["brandid"].ToString());
                }
            }

            Response.Write("搞定"+DateTime.Now.ToString());
            
        }
	}
}