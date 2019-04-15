using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Yunan.Model;
using Common;
using Model.ViewModel;
using IBLL;
using AutoMapper;
using static Yunan.Attributes.IsLoginAttributes;

namespace Yunan.Controllers
{
    [MyAuthorize]
    public class UserController : BaseController
    {
        private INewsManage _newsmanage;
        private IUsersManage _usermanage;
        private IScenicManage _scenicmanage;
        private IOrderDetailManage _orderdetailmanage;
        private IOrdersManage _ordermanage;
        private IUserQueryManange _userQueryManage;
        //***依赖注入
        public UserController(INewsManage newsmanage,IUsersManage usermanage,IScenicManage scenicmanage,IOrderDetailManage orderdetailmanage,IOrdersManage ordermanage,IUserQueryManange userQueryManange)
        {
            _newsmanage = newsmanage;
            _usermanage = usermanage;
            _scenicmanage = scenicmanage;
            _orderdetailmanage = orderdetailmanage;
            _ordermanage = ordermanage;
            _userQueryManage = userQueryManange;
        }      
        // GET: User
        public ActionResult Index()
        {
            string name = System.Web.HttpContext.Current.Session["UserName"].ToString();
            var news = _newsmanage.LoadService(n => n.User.UserName == name);
            ViewData.Model = news;
            return View();
        }

        public ActionResult Delete(int id=0)
        {
            _newsmanage.deleteService(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult BuildOrder(int sid)
        {
           
            var user = GetUser();
            var scenic = _scenicmanage.LoadService(s => s.ScenicId == sid).FirstOrDefault();
            decimal price = scenic.ScenicPrice;
            OrderDetailsViewModel bovm = new OrderDetailsViewModel();
                      
            ViewData.Model = bovm;            
            ViewBag.scenictitle = scenic.ScenicTitle;
            ViewBag.scid = scenic.ScenicId;
            ViewBag.uname = user.UserName;
            ViewBag.price = scenic.ScenicPrice;

            List<TransportViewModel> tsvm = GetTransport();
            ViewData["transport"] = new SelectList(tsvm, "tsid", "tsname");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuildOrder([Bind(Include = "BeginTime, phone, Address, punmber,transport,ScenicId")] OrderDetailsViewModel model)
        {

            List<TransportViewModel> tsvm = GetTransport();
            ViewData["transport"] = new SelectList(tsvm, "tsid", "tsname");
            
            if (ModelState.IsValid)
            {
                var user = GetUser();
                var sc = _scenicmanage.LoadService(s => s.ScenicId == model.ScenicId).FirstOrDefault();

                var totlePrice = model.punmber * model.price;
                var buildtime = DateTime.Now;
                DateTime finishTime = DateTime.Parse(GetFinishtime(model.BeginTime, sc.Days));
                Orders od = new Orders() { TotalPrice = totlePrice,  UserId= user.UserId, BuildTime = buildtime };
                _ordermanage.AddService(od);

                OrderDetails odd = new OrderDetails() { OrderId = od.OrderId, BeginTime = model.BeginTime, UserId = user.UserId, ScenicId = sc.ScenicId, Phone = model.phone, Address = model.Address, Price = sc.ScenicPrice, Transport = model.transport, Pnumber = model.punmber, FinishTime = finishTime };
                _orderdetailmanage.AddService(odd);
                return RedirectToAction("OrderShow","User");
            }

            return View("BuildOrder");
        }

        public List<TransportViewModel> GetTransport()
        {
            List<TransportViewModel> tsvm = new List<TransportViewModel>();
            string appUrl = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());
            var dict = new XmlHelper(appUrl + "/TransportList.xml").GetSetting();

            foreach (var item in dict)
            {
                tsvm.Add(new TransportViewModel
                {
                    tsid = int.Parse(item.Key),
                    tsname = item.Value,
                });
            }
            return tsvm;
        }

        /// <summary>
        /// 获取登录用户对象
        /// </summary>
        /// <returns></returns>
        public Users GetUser()
        {
            var name = System.Web.HttpContext.Current.Session["UserName"].ToString();
            return _usermanage.LoadService(u => u.UserName == name).FirstOrDefault();
        }

        /// <summary>
        /// 计算旅行结束时间
        /// </summary>
        /// <param name="begintime"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public string GetFinishtime(DateTime begintime,int last)
        {
            DateTime dt = begintime;
            int year = dt.Year;
            int month = dt.Month;
            int day = dt.Day;
            int n = DateTime.DaysInMonth(year, month);
            int k = day + last;
            if (k > n)
            {
                day = last - (n - day);
                month = month + 1;
                if (month > 12)
                {
                    month = 1;
                    year = year + 1;
                }
            }
            else
            {
                day = day + last;
            }
            string c = year + "-" + month + "-" + day;
            return c;           
        }

        [HttpGet]
        public ActionResult BuildNews()
        {
            var user = GetUser();
            int  count = _newsmanage.LoadService(u => u.UserId == user.UserId).Count();
            ViewBag.ncount = count+1;
            ViewBag.user = user.UserName;
            return View();
        }

        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult BuildNews([Bind(Include ="title,context")] NewBuildViewModel model)
        {
            var user = GetUser();
            HttpPostedFileBase file = Request.Files["img"];
            if (ModelState.IsValid)
            {                         
                if (file != null)
                {
                    string filePath = file.FileName;
                    string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\images\News\") + fileName;
                    string relativepath = @"/images/News/" + fileName;
                    file.SaveAs(serverpath);                   
               
                   DateTime postTime = DateTime.Now;
                   
                   News news = new News() { UserId=user.UserId, PostTime = postTime, NewsTitle = model.title, NewsContent = model.context, NewsCoverImg = relativepath, NewsVote = 0 };
                   _newsmanage.AddService(news);              
                   return RedirectToAction("News", "Home");
                }
            }
           
            int count = _newsmanage.LoadService(u => u.UserId == user.UserId).Count();
            ViewBag.ncount = count + 1;
            ViewBag.user = user.UserName;
            return View("BuildNews");
        }
        public ActionResult OrderShow()
        {
            UserInfoViewModel uivm = new UserInfoViewModel();
            List<UserOrderViewModel> uovm = new List<UserOrderViewModel>();
            var user = GetUser();
            var order = _ordermanage.LoadService(o => o.UserId == user.UserId);
            foreach(var item in order)
            {
                var orderdetail = _orderdetailmanage.LoadService(d => d.OrderId == item.OrderId).FirstOrDefault();   //如果有多个订单详细的话还要一层foreach
                uovm.Add(new UserOrderViewModel
                {               
                    Oid=item.OrderId,
                    Sid=orderdetail.Scenic.ScenicId,
                    Simg=orderdetail.Scenic.ScenicCoverImg,
                    Stitle=orderdetail.Scenic.ScenicTitle,
                    price=orderdetail.Scenic.ScenicPrice,
                    punmber=orderdetail.Pnumber,
                    totlePrice=item.TotalPrice,
                });
            }
            uivm.user = user;
            uivm.userOrder = uovm;
            ViewData.Model = uivm;
            return View();
        }

        [HttpGet]
        public ActionResult EditUserInfo()
        {
            var user = GetUser();
            if (user != null)
            {
                UserEditviewModel edvm = Mapper.Map<UserEditviewModel>(user);                
                ViewData.Model = edvm;
            }
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserInfo([Bind(Include ="UserName,UserTel,Birthday,UserAddress,UserMotto,IdCard")] UserEditviewModel model)
        {
            HttpPostedFileBase file = Request.Files["headimg"];         
            
            if (ModelState.IsValid)
            {
                if (file != null)
                {               
                    string filePath = file.FileName;
                    string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\images\UserHead\") + fileName;
                    string relativepath = @"/images/UserHead/" + fileName;
                    file.SaveAs(serverpath);
                    //修改用户信息
                    var currentUser = GetUser();
                    var updateuser = userManage.LoadService(u => u.UserId == currentUser.UserId).FirstOrDefault();
                    updateuser = Mapper.Map<Users>(model);                    
                    updateuser.UserHeadimg = relativepath;                  
                    userManage.updateServic(updateuser);

                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("<script>alert('请上传头像');window.location.href='../User/EditUserInfo';</script>");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult OrderDetail(int oid)
        {
            UOrderDetailViewModel uodvm = new UOrderDetailViewModel();
            var order = _ordermanage.LoadService(o => o.OrderId == oid).FirstOrDefault();
            var orderdetail = _orderdetailmanage.LoadService(o => o.OrderId == order.OrderId).ToList();
            List<OdetailViewModel> ovm = new List<OdetailViewModel>();
            foreach(var item in orderdetail)
            {
                var scenic = _scenicmanage.LoadService(s => s.ScenicId == item.ScenicId).FirstOrDefault();
                ovm.Add(new OdetailViewModel
                {
                    sid=scenic.ScenicId,
                    simg=scenic.ScenicCoverImg,
                    stitle=scenic.ScenicTitle,
                    Address=item.Address,
                    phone=item.Phone,
                    begintime=item.BeginTime,
                    finishtime=item.FinishTime,
                    pnumber=item.Pnumber,
                    price=item.Price,
                    transport=item.Transport,
                });
            }

            uodvm.order = order;
            uodvm.odetail = ovm;
            ViewData.Model = uodvm;
            return View();
        }
        /// <summary>
        /// 按关键字查景区
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult QueryScenicInfo(string keyWords)
        {
            var name = System.Web.HttpContext.Current.Session["UserName"]?.ToString();
            if (string.IsNullOrWhiteSpace(name))
            {
                return RedirectToAction("Login", "Home");
            }
            var scenic = _userQueryManage.QueryScenicByKeyWords(keyWords);
            ViewBag.Scenic = scenic.ToList();
            return View();
        }
        /// <summary>
        /// 按关键字查攻略
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        [HttpGet]   
        [AllowAnonymous]
        public ActionResult QueryNewsInfo(string keyWords)
        {
            var name = System.Web.HttpContext.Current.Session["UserName"]?.ToString();
            if (string.IsNullOrWhiteSpace(name))
            {
                return RedirectToAction("Login", "Home");
            }
            var news = _userQueryManage.QueryNewsByKeyWords(keyWords);
            ViewBag.News = news.ToList();
            return View();
        }
    }
}