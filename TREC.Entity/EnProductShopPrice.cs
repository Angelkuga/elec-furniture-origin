using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    [Serializable]
    public partial class EnProductShopPrice
    {
        public EnProductShopPrice()
		{}

        #region Model
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int productid;

        public int Productid
        {
            get { return productid; }
            set { productid = value; }
        }
        private int shopid;

        public int Shopid
        {
            get { return shopid; }
            set { shopid = value; }
        }
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        private decimal dollprice;

        public decimal Dollprice
        {
            get { return dollprice; }
            set { dollprice = value; }
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

        private int brandid;

        public int Brandid
        {
            get { return brandid; }
            set { brandid = value; }
        }

        private int attributeid;

        public int Attributeid
        {
            get { return attributeid; }
            set { attributeid = value; }
        }

        private int brandsid;

        public int Brandsid
        {
            get { return brandsid; }
            set { brandsid = value; }
        }
        #endregion
    }
}
