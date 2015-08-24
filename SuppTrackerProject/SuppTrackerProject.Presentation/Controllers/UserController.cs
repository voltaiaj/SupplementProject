using SuppTrackerProject.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SuppTrackerProject.Domain.Entities;

namespace SuppTrackerProject.Presentation.Controllers
{
    public class UserController : Controller
    {
        private DataServices _dataServices;
        private AccountController _accountController = new AccountController();

        [HttpGet]
        public ActionResult Index()
        {                        
            
            //Guid userId = Guid.Parse(User.Identity.GetUserId());
            //IList<SupplementUser> result = _dataServices.SupplementUserService.GetSupplementUsersByUserId(userId);
            return View();
        }
    }
}