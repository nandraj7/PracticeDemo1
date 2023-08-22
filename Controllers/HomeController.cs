using Microsoft.AspNetCore.Mvc;
using PracticeDemo1.Models;
using System.Diagnostics;

namespace PracticeDemo1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            BollywoodContext db = new BollywoodContext();
            var actors = db.Actors.ToList();

            return View(actors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Actor actor = new Actor();

            return View(actor);
        }

        [HttpPost]
        public IActionResult Create(Actor actor)
        {
            BollywoodContext db = new BollywoodContext();
            db.Actors.Add(actor);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            BollywoodContext db = new BollywoodContext();
            var actor = db.Actors.Find(Id);
            if (actor != null)
            {
                db.Actors.Remove(actor);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            BollywoodContext db = new BollywoodContext();
            var actors = db.Actors.Find(Id);

            return View(actors);
        }

        [HttpPost]
        public IActionResult Update(Actor actor)
        {
            BollywoodContext db = new BollywoodContext();
            db.Actors.Update(actor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
