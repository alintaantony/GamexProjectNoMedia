using GamexProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamexProject.Controllers
{
    public class AdminController : Controller
    {
        GamexDatabaseEntities gamexContext = new GamexDatabaseEntities();
        // GET: Admin
        public ActionResult AdminHomePage()
        {
            if (Session["username"] != null)
            {
                Session["usernameToAdminActionMethods"] = Session["username"].ToString();
                return View();
            }
            else
                return RedirectToAction("Login", "LoginUser");
        }
        public ActionResult AddGames()
        {
            if (Session["usernameToAdminActionMethods"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Login", "LoginUser");
        }

        [HttpPost]
        public ActionResult AddGames(GameDetail gameDetails)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    string fileName = Path.GetFileNameWithoutExtension(gameDetails.ImageFile.FileName);
                    string imageExtension = Path.GetExtension(gameDetails.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + imageExtension;
                    gameDetails.GameImagePath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    gameDetails.ImageFile.SaveAs(fileName);
                    gamexContext.GameDetails.Add(gameDetails);
                    gamexContext.SaveChanges();
                    var gameDetailsToSet = gamexContext.GameDetails.Single(game => game.GameId == gameDetails.GameId);
                    gameDetailsToSet.GamePurchaseCount = 0;
                    gamexContext.SaveChanges();
                    ViewBag.Message = "Game Added Successfully";
                }
                catch(Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }
            return View();
        }

        public ActionResult AddDlc()
        {
            if (Session["usernameToAdminActionMethods"] != null)
            {
                try
                {
                    var gameIdDropDownList = gamexContext.GameDetails.ToList();
                    ViewBag.gameIdDropDownList = new SelectList(gameIdDropDownList, "GameId", "GameName");
                 
                }
                catch(Exception e)
                {
                    ViewBag.Message = e.Message;
                }
                return View();
            }
            else
                return RedirectToAction("Login", "LoginUser");
        }

        [HttpPost]
        public ActionResult AddDlc(DlcDetail dlcDetails)
        {
            var gameIdDropDownList = gamexContext.GameDetails.ToList();
            ViewBag.gameIdDropDownList = new SelectList(gameIdDropDownList, "GameId", "GameName");
            if (ModelState.IsValid)
            {
                try
                {
                    

                    gamexContext.DlcDetails.Add(dlcDetails);
                    gamexContext.SaveChanges();
                    var dlcDetailsToSet = gamexContext.DlcDetails.Single(dlc => dlc.DlcId == dlcDetails.DlcId);
                    dlcDetailsToSet.DlcPurchaseCount = 0;
                    gamexContext.SaveChanges();
                    ViewBag.Message = "DLC Added Successfully";
                }
                catch(Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }
            return View();
        }
        public ActionResult ViewGameStatus()
        {
            if (Session["usernameToAdminActionMethods"] != null)
            {
                try
                {
                    var gameStatus = gamexContext.GameDetails.ToList();
                    return View(gameStatus);
                }
                catch(Exception e)
                {
                    ViewBag.Message = e.Message;
                    return View();
                }
               
            }
            else
                return RedirectToAction("Login", "LoginUser");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "LoginUser");
        }

    }

   
}