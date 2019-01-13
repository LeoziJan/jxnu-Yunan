using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using Webdiyer.WebControls.Mvc;

namespace Model.ViewModel
{
    public class ScenicSortViewModel
    {
        public IPagedList<ScenicListViewModel> scenic { get; set; }
        public IEnumerable<SortScenicTypeViewModel> naturalscenic { get; set; }
        public IEnumerable<SortScenicTypeViewModel> cityscenic { get; set; }
        public IEnumerable<SortScenicTypeViewModel> memoryscenic { get; set; }
        public IEnumerable<SortScenicTypeViewModel> customscenic { get; set; }
    }

    public class ScenicListViewModel
    {
        public int ScenicId { get; set; }
        public string ScenicTitle { get; set; }
        public string type { get; set; }
        public int ScenicVote { get; set; }
        public decimal ScenicPrice { get; set; }
        public string ScenicCoverImg { get; set; }
        public string ScenicKeyWord { get; set; }
    }

    //public class CustomSenicViewModel:NaturalScenicViewModel
    //{
    //}

    //public class MemoryScenicViewModel:NaturalScenicViewModel
    //{
    //}

    //public class CityScenicViewModel:NaturalScenicViewModel
    //{
    //}

    public class SortScenicTypeViewModel
    {
        public int ScenicId { get; set; }
        public string ScenicTitle { get; set; }
        public string type { get; set; }       
        public int ScenicVote { get; set; }
        public decimal ScenicPrice { get; set; }
        public int Days { get; set; }
        public string ScenicCoverImg { get; set; }     

    }
}