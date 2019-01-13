using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace Model.ViewModel
{
    public class NewsDetailViewModel
    {        
        public News news { get; set; }
        public IEnumerable<NewsDetalis> newsDeatil { get; set; }
        public IEnumerable<UserTalksViewModel> userTalk { get; set; }

        public IEnumerable<UserNewTalkViewModel> untvm { get; set; }
    }

    public class UserNewTalkViewModel
    {
        public DateTime TPostTime { get; set; }
        public string TalkContent { get; set; }
        public string userName { get; set; }
        public string userImg { get; set; }
    }

    public class UserTalksViewModel
    {
        public DateTime TPostTime { get; set; }
        public string TalkContent { get; set; }
        public string userName { get; set; }
        public string userImg { get; set; }
    }
}