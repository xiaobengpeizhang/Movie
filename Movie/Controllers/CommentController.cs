using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.DAL;
using Movie.Models;

namespace Movie.Controllers
{
    public class CommentController : Controller
    {
        private testDBContext db = new testDBContext();

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form)
        {      
            if (form != null)
            {
                string userName = Session["userName"].ToString();
                User LoginUser = db.user.FirstOrDefault(x => x.userName == userName);
                int userID = LoginUser.userID;

                db.comment.Add(new Comment
                {
                    filmID = Convert.ToInt16(form["filmID"]),
                    userID = userID,
                    commentTitle = form["title"],
                    commentBody = form["body"],
                    create_at = DateTime.Now

                });
                db.SaveChanges();
                return RedirectToAction("Details", "Film", new {id = form["filmID"] });
            }
            return View();
        }
    }
}