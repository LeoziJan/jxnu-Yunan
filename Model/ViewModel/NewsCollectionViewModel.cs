using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace Model.ViewModel
{
    public class NewsCollectionViewModel
    {      
        public IEnumerable<HotNewsViewModel> hotNews { get; set; }
        public IEnumerable<NewsViewModel> News { get; set; }
        public IEnumerable<AdminNewsViewModel> adminnews { get; set; }

        
    }
    public class AdminNewsViewModel
    {
        public int UserId { get; set; }
        public int NewsId { get; set; }
        public string UserName { get; set; }
        public string UserHeadimg { get; set; }
        public string NewsContent { get; set; }
        public string NewsCoverImg { get; set; }
        public string NewsTitle { get; set; }
    }

    public class NewsViewModel
    {
        public int UserId { get; set; }
        public int NewsId { get; set; }      
        public DateTime PostTime { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
        public int NewsVote { get; set; }
        public string NewsCoverImg { get; set; }
        public string UserHeadimg { get; set; }
        public string UserName { get; set; }
    }

    public class HotNewsViewModel
    {
        public int UserId { get; set; }
        public int NewsId { get; set; }
        public DateTime PostTime { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
        public int NewsVote { get; set; }
        public string NewsCoverImg { get; set; }
        public string UserName { get; set; }     
    }
}