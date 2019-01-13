using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace Model.ViewModel
{
    public class ScenicDetailViewModel
    {
        public Scenic scenic { get; set; }
        public IEnumerable<ScenicDetails> scenicdetail { get; set; }
        public int count { get; set; }
    }
}