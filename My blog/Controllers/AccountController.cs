using My_blog.ViewModels.Account;
using MyBlog.LogicContracts;
using System.Web.Mvc;
using System.Web.Security;

namespace My_blog.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthLogic _authLogic;

        public AccountController(IAuthLogic authLogic)
        {
            _authLogic = authLogic;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_authLogic.CanAuthenticate(model.Login, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Login, false);
                return RedirectToAction("Index", "Note");
            }

            ModelState.AddModelError(string.Empty, "Bad login/password");
            return View(model);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("~");
        }
    }
}