using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Model;
using Model.ViewModel;
using Yunan.Model;
using Webdiyer.WebControls.Mvc;
using AutoMapper;
using IBLL;
using Autofac;
using Common;

namespace Yunan.Controllers
{
    public class HomeController : BaseController
    {
       
        private IScenicManage _scenicManage;
        private IScenicDetailManage _scenicDetailManage;
        private INewsManage _newsManage;
        private IUsersManage _userManage;
        private ITalksManage _talksManage;
        private IVoteLogManage _votelogManage;
        private DbContext _db=new YunanEntities();       
        //****依赖注入*****
        public HomeController(IScenicManage scenicManage,IScenicDetailManage scenicDetailManae,INewsManage newsManage,IUsersManage usersManage,ITalksManage talksManage,IVoteLogManage votelogManage)
        {
            _scenicDetailManage = scenicDetailManae;
            _scenicManage = scenicManage;
            _newsManage = newsManage;
            _talksManage = talksManage;
            _userManage = usersManage;
            _votelogManage = votelogManage;         
        }                       
        [HttpGet]
        public ActionResult Index(string styles="跟团",string types="自然风光")
         {           
            ScenicCollectionViewModel scvm = new ScenicCollectionViewModel();            
            List<Scenic> scenic =_scenicManage.LoadService().ToList();
            var Url = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());
            var xml = new XmlHelper(Url + "/YunanDesc.xml").GetSetting();
            if (xml != null)
            {
                var title = xml.Keys.FirstOrDefault();
                var text = xml.Values.FirstOrDefault();
                ViewBag.title = title;
                ViewBag.text = text;
            }
            else
            {
                string Etitle = "error";
                ViewBag.title = Etitle;
            }
            //top5                                          
            scvm.TopScenic = Mapper.Map<List<TopScenicViewModel>>(_scenicManage.FindTopSalesService());
            //景区旅游方式分类信息
            scvm.ScenicStyle = Mapper.Map<List<ScenicStyleViewModel>>(_scenicManage.GetScenicByStyleService(styles).ToList());
            //景区类型分类信息   
            scvm.ScenicType = Mapper.Map<List<ScenicTypeViewModel>>(_scenicManage.GetScenicByTypeService(types).ToList());
            //top one销量景区信息   
            scvm.top1 = Mapper.Map<TopScenicViewModel>(_scenicManage.FindTopSalesService().First());
            scvm.scenic = scenic;
            ViewData.Model = scvm;           
            return View();

        }
        [HttpPost]
        public ActionResult Index(string value,int flag)
         {
            ScenicCollectionViewModel scvm = new ScenicCollectionViewModel();
            if (flag == 1)
            {               
                scvm.ScenicType = Mapper.Map<List<ScenicTypeViewModel>>(_scenicManage.GetScenicByTypeService(value).ToList());
                return PartialView("_IndexType", scvm);
            }
            else if (flag == 0)
            {               
                scvm.ScenicStyle = Mapper.Map<List<ScenicStyleViewModel>>(_scenicManage.GetScenicByStyleService(value).ToList());
                return PartialView("_IndexStyle", scvm);
            }
            return View();         
            
        }        

        [MyAuthorize]
        public ActionResult ScenicDetail(int? id)
         {
            ScenicDetailViewModel sdvm = new ScenicDetailViewModel();
            Scenic scenic = _scenicManage.GetScenicById(id??0);
            var scenicdetail = _scenicDetailManage.GetSDbyScenicService(scenic).ToList();         
            var count = _scenicManage.GetSOrderCount(id??0);
            sdvm.scenicdetail = scenicdetail;
            sdvm.scenic = scenic;
            sdvm.count = count;
            ViewData.Model = sdvm;           
            return View();
        }          
        public ActionResult ScenicSort(int? id,string styles="跟团")
        {

            ScenicSortViewModel ssvm = new ScenicSortViewModel();           
            var typeList = _db.Set<Scenic>().Select(s => s.type).Distinct().ToList();         
            var scenic =_scenicManage.GetScenicByStyleService(styles);
            var scenicTypeSorts = Mapper.Map<List<SortScenicTypeViewModel>>(_scenicManage.LoadService().ToList());
            List<ScenicListViewModel> scenicList = Mapper.Map<List<ScenicListViewModel>>(scenic);            
            ssvm.scenic = scenicList.ToPagedList(id??0,9);
            ssvm.naturalscenic = scenicTypeSorts.Where(s=>s.type== "自然风光");
            ssvm.cityscenic = scenicTypeSorts.Where(s => s.type == "都市购物");
            ssvm.memoryscenic = scenicTypeSorts.Where(s => s.type == "古城");
            ssvm.customscenic = scenicTypeSorts.Where(s => s.type == "民俗风情");
            ViewData.Model = ssvm;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ScenicPage", ssvm.scenic);
            }                                                                     
            return View(ssvm);
        }      

        [HttpGet]
        public ActionResult News()
        {
            NewsCollectionViewModel ncvm = new NewsCollectionViewModel();           
            var topnews =_newsManage.FindTopVoteService();
            //获取热门攻略
            List<HotNewsViewModel> hnvm = Mapper.Map<List<HotNewsViewModel>>(topnews);  
            foreach(var item in hnvm)
            {
                Users user = _userManage.LoadService(u => u.UserId == item.UserId).FirstOrDefault();
                item.UserName = user.UserName;                
            }   
            //获取系统推荐攻略
            List<AdminNewsViewModel> anvm = Mapper.Map<List<AdminNewsViewModel>>(_newsManage.GetNewsByUserService("NewsAdmin"));
            foreach(var item in anvm)
            {
                Users user = _userManage.LoadService(u => u.UserId == item.UserId).FirstOrDefault();
                item.UserName = user.UserName;
                item.UserHeadimg = user.UserHeadimg;
            }
            //获取最新攻略列表
            List<NewsViewModel> nvm = Mapper.Map<List<NewsViewModel>>(_newsManage.GetNewsByTime());  
            foreach(var item in nvm)
            {
                Users user = _userManage.LoadService(u => u.UserId == item.UserId).FirstOrDefault();
                item.UserName = user.UserName;
                item.UserHeadimg = user.UserHeadimg;
            }         
            ncvm.adminnews = anvm;
            ncvm.hotNews = hnvm;
            ncvm.News = nvm;
            ViewData.Model = ncvm;
            var count = _newsManage.LoadService().Count();
            ViewBag.Ncount = count;
            return View();
        }

        [HttpPost]
        public ActionResult News(int id)
        {
            if (Session["UserName"] == null)
            {
                return Content("-1");
            }
            else
            {
                var name = Session["UserName"].ToString();
                var user = _userManage.LoadService(u => u.UserName == name).FirstOrDefault();
                var isvoted = _votelogManage.GetVoteLogByNewsUser(id, user.UserId);
                if (isvoted != null)
                {
                    return Content("-2");
                }
                else
                {
                    _votelogManage.AddService(new VoteLog
                    {
                        NewsId = id,
                        UserId = user.UserId,
                        VoteTime = DateTime.Now
                    });
                    var news = _newsManage.LoadService(n => n.NewsId == id).FirstOrDefault();
                    news.NewsVote = news.NewsVote + 1;
                    if (_newsManage.updateServic(news))
                    {
                        NewsViewModel nvm = Mapper.Map<NewsViewModel>(news);
                        return Content(nvm.NewsVote.ToString());
                    }
                    else
                    {
                        return Content("0");
                    }
                }
            }                                 
        }
        [HttpGet]
        public ActionResult NewsDetail(int id)
        {            
            var news = _newsManage.LoadService(n => n.NewsId == id).FirstOrDefault();            
            var newsDetail = _newsManage.GetNewsDetailByNews(id);
            var talk = _talksManage.NewsTalksService(news);             
            NewsDetailViewModel ndvm = new NewsDetailViewModel();
            ndvm.news = news;
            ndvm.newsDeatil = newsDetail;
            ndvm.userTalk = GetTalk(news);
            var talkNum = _talksManage.NewsTalksCount(news);            //攻略评论数
            ViewBag.TalkNums = talkNum;
            ViewData.Model = ndvm;
            return View();
        }
        public List<UserTalksViewModel> GetTalk(News news)
        {
            string name = Session["UserName"].ToString();
            var user = userManage.LoadService(u => u.UserName == name).FirstOrDefault();
            var talk = _talksManage.NewsTalksService(news);
            List<UserTalksViewModel> utvm = new List<UserTalksViewModel>();
            if (talk.Count()>0)
            {
                foreach(var item in talk)
                {
                    utvm.Add(new UserTalksViewModel()
                    {
                        TalkContent = item.TalkContent,
                        TPostTime = item.TPostTime,
                        userImg = user.UserHeadimg,
                        userName = name
                    });
                }
                                 
            }           
            return utvm;
        }       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewsDetail(int? id)
        {
            if (ModelState.IsValid)
            {
                if (Session["UserName"] == null)
                {
                    return Content("<script>alert('请先登录');window.location.href='../News';</script>");
                }
                else
                {               
                    string name = Session["UserName"].ToString();               
                    var user = userManage.LoadService(u => u.UserName == name).FirstOrDefault();
                    var news = _newsManage.LoadService(n => n.NewsId == id).FirstOrDefault();
                    string context =System.Web.HttpContext.Current.Request["context"].ToString()==null?"": System.Web.HttpContext.Current.Request["context"].ToString();
                    var talks = Addtalks(news, context);
                    List<UserNewTalkViewModel> utk = new List<UserNewTalkViewModel>();
                    if (talks != null)
                    {
                        utk.Add(new UserNewTalkViewModel()
                        {
                            userImg = user.UserHeadimg,
                            TalkContent = talks.TalkContent,
                            TPostTime = talks.TPostTime,
                            userName = user.UserName,
                        });
                    }
                    return RedirectToAction("NewsDetail");
                }
            }
            return RedirectToAction("News", "Home");
        }

        public Talks Addtalks(News news,string context)
        {
            DateTime dt = DateTime.Now;
            string name = Session["UserName"].ToString();
            Users user = _userManage.LoadService(u => u.UserName == name).FirstOrDefault();
            Talks talk = new Talks {NewsId=news.NewsId,TPostTime=dt,UserId=user.UserId,TalkContent=context };
            _talksManage.AddService(talk);
            return talk;           
        }
       
        [HttpGet]
        public ActionResult Login() 
        {           
            return View();
        }

        [HttpPost]      
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include ="UserName,UserPassward")]ULoginViewModel model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {                
                Users user = _userManage.LoadService(u => u.UserName == model.UserName).FirstOrDefault();
                if (user == null)
                {
                    ModelState.AddModelError("","用户名或密码错误");
                }
                else if(user.UserPassward!=model.UserPassward)
                {
                    ModelState.AddModelError("", "用户名或密码错误");
                }
                else
                {
                    Session["UserName"] = model.UserName;
                    if (ReturnUrl == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(ReturnUrl);
                    }                                    
                    
                }
            }
            return View("Login");
        }

        public ActionResult LoginOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include ="UserName,UserPassward,ConfirmPassward,UserTel,Birthday,UserAddress,IdCard")]URegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string name = model.UserName;
                var check = _userManage.LoadService(u => u.UserName == name).FirstOrDefault();
                if (check != null)
                {
                    ModelState.AddModelError("", "你来晚了这个昵称被占用了");
                }
                else
                {
                    Users newuser = new Users() { UserName = model.UserName,UserPassward = model.UserPassward,UserTel = model.UserTel,UserAddress = model.UserAddress,Birthday = model.Birthday,IdCard = model.IdCard
                    };
                    _userManage.AddService(newuser);
                    return Content("<script>alert('注册成功');window.location.href='../Home/Login';</script>");                  
                }                           
            }            
            return View("Register");
        }            
    }
}