using GamexProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamexProject.Controllers
{
    public class LoginUserController : Controller
    {
        GamexDatabaseEntities gamexContext = new GamexDatabaseEntities();
        // GET: LoginUser
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDetails loginDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userLogIn = gamexContext.UserDetails.Single(user => user.Username == loginDetails.Username && user.UserPassword == loginDetails.Password);
                    if(userLogIn != null)
                    {
                        if(userLogIn.UserRole == "Admin")
                        {
                            Session["username"] = userLogIn.Username;
                            Session["adminFullName"] = userLogIn.UserFullName;
                            return RedirectToAction("AdminHomePage", "Admin");
                        }
                        if(userLogIn.UserRole == "User")
                        {
                            Session["username"] = userLogIn.Username;
                            Session["fullname"] = userLogIn.UserFullName;
                            return RedirectToAction("UserHomePage", "User");
                        }
                    }
                }
                catch
                {
                    ViewBag.Message = "User not Found !! Please check your Username and Password !!";
                }
            }
            return View();
        }
    }
}