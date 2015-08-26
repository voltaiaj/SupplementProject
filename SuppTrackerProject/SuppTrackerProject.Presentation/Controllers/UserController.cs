using SuppTrackerProject.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SuppTrackerProject.Domain.Entities;
using SuppTrackerProject.Presentation.Models;
using Microsoft.AspNet.Identity.Owin;

namespace SuppTrackerProject.Presentation.Controllers
{
    public class UserController : Controller
    {
        private DataServices _dataServices;
        private AccountController _accountController = new AccountController();

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            var result = _accountController.Login(model);
            switch (result.Result)
            {
                case SignInStatus.Success:
                    //return RedirectToLocal(returnUrl);
                    TempData["loginModel"] = model;
                    return RedirectToAction("Index", "User");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
            //Guid userId = Guid.Parse(User.Identity.GetUserId());
            //IList<SupplementUser> result = _dataServices.SupplementUserService.GetSupplementUsersByUserId(userId);
            return View();
        }
    }
}