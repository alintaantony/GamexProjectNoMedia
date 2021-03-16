using GamexProject.Models;
using GamexProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamexProject.Controllers
{
    public class RegisterUserController : Controller
    {
        GamexDatabaseEntities gamexContext = new GamexDatabaseEntities();
        // GET: RegisterUser

        public JsonResult IsUserNameAvailable(string Username)
        {
            return Json(!gamexContext.UserDetails.Any(user => user.Username == Username),JsonRequestBehavior.AllowGet);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Registration registration)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    gamexContext.UserDetails.Add(new UserDetail(registration.Username,registration.UserFullName,registration.UserEmail,registration.UserPassword,"User",registration.Wallet,0,0));
                    gamexContext.SaveChanges();
                    ViewBag.Message = "User Registered Successfully !!";
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }
            return View();
        }



    }
}