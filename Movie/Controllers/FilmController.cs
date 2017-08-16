using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.DAL;
using Movie.Models;

namespace Movie.Controllers
{
    public class FilmController : Controller
    {
        private testDBContext db = new testDBContext();

        // GET: Film
        public ActionResult Index()
        {
            var filmList = db.film.ToList();
            return View(filmList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Film newFilm)
        {
            if (ModelState.IsValid)
            {
                db.film.Add(newFilm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(500);
            }
            Film film = db.film.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        [HttpPost]
        public ActionResult Save(int filmID, Film changedFilm)
        {
            
            Film oldFilm = db.film.Find(filmID);
            if (oldFilm == null)
            {
                return  HttpNotFound();
            }
            if(ModelState.IsValid){
                TryUpdateModel(oldFilm);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(500);
            }
            Film film = db.film.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }           
            return View(film);
        }

        
        public ActionResult Delete(int id)
        {
            Film film = db.film.Find(id);
            db.film.Remove(film);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}