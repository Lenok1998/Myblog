using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_blog.Models;

namespace My_blog.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index ()
        {
            return View(User);
        }
        public ActionResult Details(Guid id)
        {
            var users = ArticleRepository.Users.FirstOrDefault(n => n.ID == id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(User user)
        {
            if (!ModelState.IsValid) return View(user);

            user.ID = Guid.NewGuid();
            
            ArticleRepository.Users.Add(user);
            return RedirectToAction("Users");
        }
        public ActionResult Edit([Bind(Include = "Id,Name")]Guid id)
        {
            User users = ArticleRepository.Users.FirstOrDefault(n => n.ID == id);
            if (users == null)
            {
                return HttpNotFound();
            }

            return View(users);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            User storedUser = ArticleRepository.Users.FirstOrDefault(n => n.ID == user.ID);
            if (storedUser == null)
            {
                return HttpNotFound();
            }
            storedUser.Username = user.Username;
            storedUser.YOB = user.YOB;
            storedUser.Email = user.Email;
            storedUser. Workexperience = user.Workexperience;
            storedUser. Education = user.Education;
            storedUser.Specialization = user.Specialization;
            storedUser.Avatar = user.Avatar;
            return RedirectToAction("Details", new { id = user.ID });
        }
        public ActionResult Delete(Guid id)
        {
            User user = ArticleRepository.Users.FirstOrDefault(n => n.ID == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View("Delete");
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(User user)
        {
            User User = ArticleRepository.Users.FirstOrDefault(n => n.ID == user.ID);
            if (User == null)
            {
                return HttpNotFound();
            }
            ArticleRepository.Users.Remove(User);
            return RedirectToAction("Users");
        }
    }

}