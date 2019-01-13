using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using bll;
using System.IO;
using System.Net;
using System.Data.Entity;

namespace Yunan.Controllers
{
    public class ScenicManagementController : Controller
    {
        ScenicManage scenicmanage = new ScenicManage();
        private YunanEntities db = new YunanEntities();
        AdminsManage adminmanage = new AdminsManage();

        //发布景区
        public ActionResult Public()
        {
            IList<Scenic> scenic = scenicmanage.GetScenic();

            ViewBag.ScenicStyle = new SelectList(scenic, "ScenicId", "ScenicStyle");
            ViewBag.type = new SelectList(scenic, "ScenicId", "type");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Public(Scenic sc)
        {
            try
            {
                HttpPostedFileBase file = Request.Files["file"];//判断是否上传文件
                string filePath = file.FileName;
                string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                string path = Server.MapPath(@"\images\Activity\Cover\" + DateTime.Now.ToString("yyyyMMdd") + "\\");
                if(!Directory.Exists(path))//判断路径是否存在，若不存在则创建
                {
                    Directory.CreateDirectory(path);
                }
                string serverpath = path + filename;
                string relativepath = @"/images/Activity/Cover/" + DateTime.Now.ToString("yyyyMMdd") + "/" + filename;
                file.SaveAs(serverpath);//上传路径

                sc.ScenicCoverImg = relativepath;

                //sc.ScenicId = int.Parse(Request.Form["Scenic"]);
                if (scenicmanage.InsertScenic(sc))
                {
                    return Content("<script>alert('发布成功！');window.open('" + Url.Action("Index", "ScenicManagement") + "', '_self')</script>");
                }
                else
                {
                    return Content("<script>alert('对不起，发布失败！')</script>");
                }

            }
            catch (Exception ex)
            {
                return Content("<script>alert('系统出错，发布失败！原因如下：" + ex.Message + "');window.open('" + Url.Action("Public", "Scenicmanagement") + "', '_self')</script>");
            }
        }


        /// <summary>
        /// 异步获取管理员的身份
        /// </summary>
        /// <param name="AdminId"></param>
        /// <returns></returns>
        public string GetAdminName(int AdminId)
        {
            //int adminId = int.Parse(AdminId);
            Admins admin = adminmanage.GetAdminById(AdminId);
            if (admin != null)
            {
                return admin.AdminName;
            }
            else
            {
                return "不存在该用户";
            }
        }
        // GET: ScenicManagement
        public ActionResult Index()
        {

            return View(db.Scenic.ToList());
        }

        // GET: ScenicManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scenic scenic = db.Scenic.Find(id);
            if (scenic == null)
            {
                return HttpNotFound();
            }
            return View(scenic);
        }

        // GET: ScenicManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScenicManagement/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create([Bind(Include = "ScenicId,ScenicTitle,City,type,ScenicContent,ScenicVote,ScenicStyle,ScenicPrice,Days,ScenicCoverImg,ScenicKeyWord")] Scenic scenic)
        {

            //HttpPostedFileBase file = Request.Files["file"];//判断是否上传文件
            //string filePath = file.FileName;
            //string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
            //string path = Server.MapPath(@"\images\Activity\Cover\" + DateTime.Now.ToString("yyyyMMdd") + "\\");
            //if (!Directory.Exists(path))//判断路径是否存在，若不存在则创建
            //{
            //    Directory.CreateDirectory(path);
            //}
            //string serverpath = path + filename;
            //string relativepath = @"/images/Activity/Cover/" + DateTime.Now.ToString("yyyyMMdd") + "/" + filename;
            //file.SaveAs(serverpath);//上传路径

            //scenic.ScenicCoverImg = relativepath;

            if (ModelState.IsValid)
            {
                db.Scenic.Add(scenic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scenic);
        }

        // GET: ScenicManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scenic scenic = db.Scenic.Find(id);
            if (scenic == null)
            {
                return HttpNotFound();
            }
            return View(scenic);
        }

        // POST: ScenicManagement/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ScenicId,ScenicTitle,City,type,ScenicContent,ScenicVote,ScenicStyle,ScenicPrice,Days,ScenicCoverImg,ScenicKeyWord")] Scenic scenic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scenic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scenic);
        }

        // GET: ScenicManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scenic scenic = db.Scenic.Find(id);
            if (scenic == null)
            {
                return HttpNotFound();
            }
            return View(scenic);
        }

        // POST: ScenicManagement/Delete/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [ValidateAntiForgeryToken]
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Scenic scenic = db.Scenic.Find(id);
            db.Scenic.Remove(scenic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
