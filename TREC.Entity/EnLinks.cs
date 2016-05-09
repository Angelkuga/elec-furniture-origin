using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    [Serializable]
    public class EnLinks
    {
        public EnLinks()
        { }

        #region Model
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string link;

        public string Link
        {
            get { return link; }
            set { link = value; }
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

        #endregion
    }
}
