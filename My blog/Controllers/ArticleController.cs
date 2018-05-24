using My_blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_blog.Controllers
{
    public class ArticleController : Controller
    {
        private const string AdminRolesString = RoleNames.Admins + "," + RoleNames.Psychologist;
        // GET: Article
        public ActionResult Index()
        {

            var articles = ArticleRepository.Articles.OrderByDescending(n => n.CreateDate);
            return View(articles);

        }
        public ActionResult Details(Guid id)
        {
            var article = ArticleRepository.Articles.FirstOrDefault(n => n.ID == id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create([Bind(Include = "Text")] Article article)
        {
            if (!ModelState.IsValid) return View(article);

            article.ID = Guid.NewGuid();
            article.CreateDate = DateTime.Now;
            article.UpdateDate = DateTime.Now;
            ArticleRepository.Articles.Add(article);
            return RedirectToAction("Index");
        }
        public ActionResult Edit([Bind(Include = "Id,Text")]Guid id)
        {
            Article article = ArticleRepository.Articles.FirstOrDefault(n => n.ID == id);
            if (article == null)
            {
                return HttpNotFound();
            }

            return View(article);
        }
        [HttpPost]
        public ActionResult Edit(Article article)
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }
            Article storedArticle = ArticleRepository.Articles.FirstOrDefault(n => n.ID == article.ID);
            if (storedArticle == null)
            {
                return HttpNotFound();
            }
            storedArticle.Text = article.Text;
            storedArticle.UpdateDate = DateTime.Now;
            return RedirectToAction("Details", new { id = article.ID });
        }
        public ActionResult Delete(Guid id)
        {
            Article article = ArticleRepository.Articles.FirstOrDefault(n => n.ID == id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        [Authorize(Roles = AdminRolesString)]
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(Article article)
        {
            Article Article = ArticleRepository.Articles.FirstOrDefault(n => n.ID == article.ID);
            if (Article == null)
            {
                return HttpNotFound();
            }
            ArticleRepository.Articles.Remove(Article);
            return RedirectToAction("Index");
        }


        [ChildActionOnly]
        public ActionResult ShowAttachments(Guid id)
        {
            var model = ArticleRepository.Attachments.Where(n => n.ArticleId == id);
            return PartialView("_ShowAttachmentsPartial", model);

        }

        public ActionResult Download(Guid id)
        {
            Attachment attachment = ArticleRepository.Attachments.FirstOrDefault(n => n.Id == id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            return File(attachment.Data, "application/octet-stream", attachment.FileName);
        }

        public ActionResult Show(Guid id)
        {
            Attachment attachment = ArticleRepository.Attachments.FirstOrDefault(n => n.Id == id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            return File(attachment.Data, attachment.ContentType, attachment.FileName);
        }

        [HttpPost]
        public ActionResult Upload(Guid id, HttpPostedFileBase uploaded)
        {
            var attachment = new Attachment
            {
                Id = Guid.NewGuid(),
                FileName = uploaded.FileName,
                Data = new byte[uploaded.ContentLength],
                ArticleId = id,
                ContentType = uploaded.ContentType
            };

            uploaded.InputStream.Read(attachment.Data, 0, attachment.Data.Length);
            ArticleRepository.Attachments.Add(attachment);
            return RedirectToAction("Details", new { id });
        }


        public ActionResult DeleteUploads(Guid id)
        {
            Attachment attachment = ArticleRepository.Attachments.FirstOrDefault(n => n.Id == id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            return View(attachment);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteUploadedConfirmed(Attachment attachment)
        {
            Attachment Attachment = ArticleRepository.Attachments.FirstOrDefault(n => n.Id == attachment.Id);
            if (Attachment == null)
            {
                return HttpNotFound();
            }
            ArticleRepository.Attachments.Remove(Attachment);
            return RedirectToAction("Details");
        }
    }
}