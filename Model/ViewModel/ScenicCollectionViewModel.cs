using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace Model.ViewModel
{
    public class ScenicCollectionViewModel
    {

        public TopScenicViewModel top1 { get; set; }
        public IEnumerable<TopScenicViewModel> TopScenic { get; set; }
        public IEnumerable<ScenicStyleViewModel> ScenicStyle { get; set; }
        public IEnumerable<ScenicTypeViewModel> ScenicType { get; set; }
        public IEnumerable<Scenic> scenic { get; set; }
    }

    public class ScenicTypeViewModel
    {
        public int ScenicId { get; set; }
        public string type { get; set; }
        public string ScenicTitle { get; set; }
        public decimal ScenicPrice { get; set; }
        public string ScenicCoverImg { get; set; }
        public string ScenicKeyWord { get; set; }


    }

    public class ScenicStyleViewModel
    {
        public int ScenicId { get; set; }       
        public string ScenicStyle { get; set; }
        public string ScenicTitle { get; set; }
        public decimal ScenicPrice { get; set; }
        public string ScenicCoverImg { get; set; }
        public string ScenicKeyWord { get; set; }
    }

    public class TopScenicViewModel
    {
        public int ScenicId { get; set; }
        public string ScenicTitle { get; set; }
        public string ScenicCoverImg { get; set; }
        public decimal ScenicPrice { get; set; }
    }
}