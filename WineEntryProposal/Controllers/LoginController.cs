using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineEntryProposal.Models.View_Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;


namespace WineEntryProposal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                var AuthManager = HttpContext.GetOwinContext().Authentication;

                AppUser user = userManager.Find(login.UserName, login.Password);
                if (user != null)
                {
                    var ident = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignIn(
                        new AuthenticationProperties { IsPersistent = false }, ident);
                    return Redirect(login.ReturnUrl ?? Url.Action("Index", "Home"));
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(login);
        }

        public ActionResult CreateRole(string roleName)
        {
            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<AppRole>>();

            if (!roleManager.RoleExists(roleName))
                roleManager.Create(new AppRole(roleName));
            // rest of code
        }
    }



    //UserManager.AddToRole(UserManager.FindByName("username").Id, "roleName");
    //By using Authorize you could guard your actions or controllers:
    //[Authorize]
    //public ActionResult MySecretAction() { }
    //or
    //[Authorize(Roles = "Admin")]]
    //public ActionResult MySecretAction() { }
}