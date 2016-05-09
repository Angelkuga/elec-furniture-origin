using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TREC.Entity
{
    public class EnSearchItem : IEnumerable
    {
        public string type { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public int count { get; set; }
        public bool isCur { get; set; }
        public IEnumerator GetEnumerator()
        {
            yield return new EnSearchItem();
        }
    }

    public class EnSearchProductItem : IEnumerable
    {
        public string type { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public string brandid { get; set; }
        public string brandsid { get; set; }
        public string pcategoryid { get; set; }
        public int count { get; set; }
        public bool isCur { get; set; }
        public IEnumerator GetEnumerator()
        {
            yield return new EnSearchProductItem();
        }
    }
}
