using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Movie.DAL;
using Movie.Models;
using System.Security.Cryptography;

namespace Movie.Controllers
{
    public class UserController : Controller
    {
        private testDBContext db = new testDBContext();

        // GET: User
        public ActionResult Index()
        {
            return View(db.user.ToList());
        }

        // GET: User/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form)
        {
            if (form["password"] == form["password_confirm"])
            {
                User newUser = new User
                {
                    userName = form["userName"],
                    email = form["email"],
                    password = ToMd5(form["password"]),  //对密码加密
                    create_at = DateTime.Now             //获取当前时间
                };
                db.user.Add(newUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["passwordError"] = "两次密码输入不一致";
                return View();
            }
            
            
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection form)
        {
            string userEmail = form["email"];
            string userPassword = form["password"];
                     
            User user = db.user.FirstOrDefault(x=>x.email == userEmail);

            if (user.password == ToMd5(userPassword))
            {
                Session["userName"] = user.userName;
               
                return RedirectToAction("Index", "Film");
            }
            else
            {
                ViewData["loginMessage"] = "登录失败！请返回！";
                return View();
            }
            
        }

        // GET: User/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // POST: User/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "userID,userName,email,password,create_at")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(user).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(user);
        //}

        // GET: User/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.user.Find(id);
            db.user.Remove(user);
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

        //md5加密函数
        public static string ToMd5(string clearString)
        {
            Byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearString);
            string hashedPwd = BitConverter.ToString(((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes));
            return hashedPwd;
        }
    }
}
