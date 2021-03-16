using GamexProject.Models;
using GamexProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamexProject.Controllers
{
    public class UserController : Controller
    {
        GamexDatabaseEntities gamexContext = new GamexDatabaseEntities();
        // GET: User
        public ActionResult UserHomePage()
        {
            if (Session["username"] != null)
            {
                Session["usernameToUserActionMethods"] = Session["username"].ToString();
                return View();
            }
            else
            {
                return RedirectToAction("Login", "LoginUser");
            }
        }
        public ActionResult ViewGamesToPurchase()
        {
            if (Session["usernameToUserActionMethods"] != null)
            {
                try
                {
                    var gameDetails = gamexContext.GameDetails.ToList();
                    return View(gameDetails);
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                    return View();
                }
            }
            else
                return RedirectToAction("Login", "LoginUser");

        }


        public ActionResult PurchaseGame(string gameID)
        {
            if (Session["usernameToUserActionMethods"] != null)
            {
                TempData["gameIdToUserActionMethods"] = gameID;
                try
                {

                    var user = gamexContext.GameDetails.Single(game => game.GameId == gameID);
                    return View(user);
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                    return View();
                }
            }
            else
                return RedirectToAction("Login", "LoginUser");
        }

        public ActionResult GamePurchased()
        {
            if (Session["usernameToUserActionMethods"] != null)
            {
                try
                {
                    string gameIdToPurchase = TempData.Peek("gameIdToUserActionMethods").ToString();
                    string usernameToPurchase = Session["usernameToUserActionMethods"].ToString();
                    var gameDetailsToPurchase = gamexContext.GameDetails.Single(game => game.GameId == gameIdToPurchase);
                    var userDetailsToPurchase = gamexContext.UserDetails.Single(user => user.Username == usernameToPurchase);
                    var purchasedGamesList = gamexContext.PurchasedGameDetails.Where(game => game.Username == usernameToPurchase && game.GameId == gameIdToPurchase && game.InLibraryGameStatus == 1).ToList();
                    if (purchasedGamesList.Count < 1)
                    {
                        if (userDetailsToPurchase.Wallet >= gameDetailsToPurchase.GamePrice)
                        {
                            userDetailsToPurchase.Wallet = userDetailsToPurchase.Wallet - gameDetailsToPurchase.GamePrice;
                            gameDetailsToPurchase.GamePurchaseCount = gameDetailsToPurchase.GamePurchaseCount + 1;
                            gamexContext.PurchasedGameDetails.Add(new PurchasedGameDetail(gameDetailsToPurchase.GameId, userDetailsToPurchase.Username, 1));
                            gamexContext.SaveChanges();
                            ViewBag.Message = "Thank you for Purchasing " + gameDetailsToPurchase.GameName;
                            ViewBag.WalletBalance = "Your Wallet Balance is : " + userDetailsToPurchase.Wallet;
                        }
                        else
                        {
                            ViewBag.Message = "Wallet doesn't have sufficient Amount !! Please Recharge Wallet and Try Again !!";
                            ViewBag.WalletBalance = "Your Wallet Balance is : " + userDetailsToPurchase.Wallet;
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Game already Purchased !! Please Check Your Library";
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
                return View();
            }
            else
                return RedirectToAction("Login", "LoginUser");
        }

        public ActionResult ViewGameDlcUser()
        {
            if (Session["usernameToUserActionMethods"] != null)
            {
                try
                {
                    string gameIdToViewDlc = TempData.Peek("gameIdToUserActionMethods").ToString();
                    var dlcDetailsOfGame = gamexContext.DlcDetails.Where(dlc => dlc.GameId == gameIdToViewDlc).ToList();
                    if(dlcDetailsOfGame.Count > 0)
                    {
                        return View(dlcDetailsOfGame);
                    }
                    else
                    {
                        ViewBag.Message = "No DLCs available for this Game !!";
                        return View("NoDlcsView");
                    }

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
        public ActionResult PurchaseDlc(string Dlcid)
        {
            if (Session["usernameToUserActionMethods"] != null)
            {
                try
                {
                    string DlcIdToPurchase = Dlcid;
                    string usernameToPurchase = Session["usernameToUserActionMethods"].ToString();
                    var DlcDetailsToPurchase = gamexContext.DlcDetails.Single(dlc => dlc.DlcId == DlcIdToPurchase);
                    var usernameDetailsToPurchase = gamexContext.UserDetails.Single(user => user.Username == usernameToPurchase);
                    var purchasedDlcList = gamexContext.PurchasedDlcDetails.Where(dlc => dlc.Username == usernameToPurchase && dlc.DlcId == DlcIdToPurchase && dlc.InLibraryDlcStatus == 1).ToList();
                    if(purchasedDlcList.Count < 1)
                    {
                        if(usernameDetailsToPurchase.Wallet >= DlcDetailsToPurchase.DlcPrice)
                        {
                            usernameDetailsToPurchase.Wallet = usernameDetailsToPurchase.Wallet - DlcDetailsToPurchase.DlcPrice;
                            DlcDetailsToPurchase.DlcPurchaseCount = DlcDetailsToPurchase.DlcPurchaseCount + 1;
                            gamexContext.PurchasedDlcDetails.Add(new PurchasedDlcDetail(DlcDetailsToPurchase.DlcId, usernameDetailsToPurchase.Username, 1));
                            gamexContext.SaveChanges();
                            ViewBag.Message = "Thank You for Purchasing " + DlcDetailsToPurchase.DlcName;
                            ViewBag.WalletBalance = "Your Wallet Balance is : " + usernameDetailsToPurchase.Wallet;
                        }
                        else
                        {
                            ViewBag.Message = "Wallet doesn't have sufficient Amount !! Please Recharge Wallet and Try Again !!";
                            ViewBag.WalletBalance = "Your Wallet Balance is : " + usernameDetailsToPurchase.Wallet;
                        }
                    }
                    else
                    {
                        ViewBag.Message = "DLC already Purchased !! Please Check Your Library"; ;
                    }
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
        public ActionResult ViewGameandDlcMenu()
        {
            if (Session["usernameToUserActionMethods"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Login", "LoginUser");
        }

        public ActionResult UserGameLibrary()
        {
            if(Session["usernameToUserActionMethods"] != null)
            {
                try
                {
                    List<string> gamesLibraryOfUserList = new List<string>();
                    string usernameForGameLibrary = Session["usernameToUserActionMethods"].ToString();
                    var boughtGames = from games in gamexContext.GameDetails
                                      join purchasedGames in gamexContext.PurchasedGameDetails
                                      on games.GameId equals purchasedGames.GameId
                                      into gamesLibrary
                                      from gl in gamesLibrary.DefaultIfEmpty()
                                      select new
                                      {
                                          games.GameId,
                                          games.GameName,
                                          games.GameResaleValue,
                                          gl.Username,
                                          gl.InLibraryGameStatus
                                      };
                    var gameLibraryOfUser = boughtGames.Where(games => games.Username == usernameForGameLibrary && games.InLibraryGameStatus == 1).ToList();
                    if (gameLibraryOfUser.Count > 0)
                    {
                        foreach(var gamesItem in gameLibraryOfUser)
                        {
                            gamesLibraryOfUserList.Add(gamesItem.GameName);

                        }
                        ViewBag.GamesNameList = gamesLibraryOfUserList;
                        return View();
                    }
                    else
                    {
                        ViewBag.Message = "No games in Your Library !! Why Dont You Hit the Store :)";
                        return View("NoGamesInLibrary");
                    }
                 }
                catch(Exception e)
                {
                    ViewBag.Message = e.Message;
                    return View("NoGamesInLibrary");
                }
            }
            else
                return RedirectToAction("Login", "LoginUser");
        }

        public ActionResult SellGames()
        {
            if(Session["usernameToUserActionMethods"] != null)
            {
                try
                {
                    string usernameForGameLibrary = Session["usernameToUserActionMethods"].ToString();
                    var boughtGames = from games in gamexContext.GameDetails
                                      join purchasedGames in gamexContext.PurchasedGameDetails
                                      on games.GameId equals purchasedGames.GameId
                                      into gamesLibrary
                                      from gl in gamesLibrary.DefaultIfEmpty()
                                      select new
                                      {
                                          games.GameId,
                                          games.GameName,
                                          games.GameResaleValue,
                                          gl.Username,
                                          gl.InLibraryGameStatus
                                      };
                    var gameLibraryOfUser = boughtGames.Where(games => games.Username == usernameForGameLibrary && games.InLibraryGameStatus == 1).ToList();
                    ViewBag.sellGamesDropDownList = new SelectList(gameLibraryOfUser, "GameId", "GameName");
                    
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
        public ActionResult SellGames(SellGameViewModel gameDetails)
        {
            string usernameForGameLibrary = Session["usernameToUserActionMethods"].ToString();
            var boughtGames = from games in gamexContext.GameDetails
                              join purchasedGames in gamexContext.PurchasedGameDetails
                              on games.GameId equals purchasedGames.GameId
                              into gamesLibrary
                              from gl in gamesLibrary.DefaultIfEmpty()
                              select new
                              {
                                  games.GameId,
                                  games.GameName,
                                  games.GameResaleValue,
                                  gl.Username,
                                  gl.InLibraryGameStatus
                              };
            var gameLibraryOfUser = boughtGames.Where(games => games.Username == usernameForGameLibrary && games.InLibraryGameStatus == 1).ToList();
            ViewBag.sellGamesDropDownList = new SelectList(gameLibraryOfUser, "GameId", "GameName");
            if (ModelState.IsValid)
            {
                try
                {
                    string usernameToSellGame = Session["usernameToUserActionMethods"].ToString();
                    var userDetailsToSellGame = gamexContext.UserDetails.Single(user => user.Username == usernameToSellGame);
                    var gameDetailsToSellGame = gamexContext.GameDetails.Single(games => games.GameId == gameDetails.GameId);
                    var purchasedGameDetailsToSellGame = gamexContext.PurchasedGameDetails.Single(purchasedGame => purchasedGame.GameId == gameDetails.GameId && purchasedGame.Username == usernameToSellGame && purchasedGame.InLibraryGameStatus == 1);
                    userDetailsToSellGame.Wallet = userDetailsToSellGame.Wallet + gameDetailsToSellGame.GameResaleValue;
                    purchasedGameDetailsToSellGame.InLibraryGameStatus = 0;
                    gamexContext.SaveChanges();
                    ViewBag.Message = "The Game was Sold for " + gameDetailsToSellGame.GameResaleValue;
                    ViewBag.WalletBalance = "Your Wallet Balance is " + userDetailsToSellGame.Wallet;

                }
                catch (Exception e)
                {
                    ViewBag.Message = "Game already Sold !! Please try selling another Game";
                }
            }
            return View();
        }
        public ActionResult UserDlcLibrary()
        {
            if (Session["usernameToUserActionMethods"] != null)
            {
                try
                {
                    //dynamic o = new ExpandoObject();
                    List<string> dlcLibraryOfUserDlcNames = new List<string>();
                    string usernameForDlcLibrary = Session["usernameToUserActionMethods"].ToString();
                    var boughtDlcs = from dlcs in gamexContext.DlcDetails
                                     join purchasedDlcs in gamexContext.PurchasedDlcDetails
                                     on dlcs.DlcId equals purchasedDlcs.DlcId
                                     into dlcsLibrary
                                     from dl in dlcsLibrary.DefaultIfEmpty()
                                     select new
                                     {
                                         dlcs.DlcId,
                                         dlcs.DlcName,
                                         dlcs.DlcResaleValue,
                                         dlcs.GameId,
                                         dl.Username,
                                         dl.InLibraryDlcStatus
                                     };
                    var dlcLibraryOfUser = boughtDlcs.Where(dlcs => dlcs.Username == usernameForDlcLibrary && dlcs.InLibraryDlcStatus == 1).ToList();
                    if(dlcLibraryOfUser.Count > 0)
                    {
                       foreach(var dlcItem in dlcLibraryOfUser)
                        {
                            dlcLibraryOfUserDlcNames.Add(dlcItem.DlcName);
                        }
                        ViewBag.DlcNameList = dlcLibraryOfUserDlcNames; 
                        return View();
                    }
                    else
                    {
                        ViewBag.Message = "No DLCs in Your Library !! Why Dont You Hit the Store :)";
                        return View("NoDlcsInLibrary");
                    }
                }
                catch(Exception e)
                {
                    ViewBag.Message = e.Message;
                    return View("NoDlcsInLibrary");
                }
               
            }
            else
                return RedirectToAction("Login", "LoginUser");
        }

        public ActionResult RechargeWallet()
        {
            if(Session["usernameToUserActionMethods"] != null)
            { 
                try
                {
                    string usernameToRechargeWallet = Session["usernameToUserActionMethods"].ToString();
                    var userDetailsToRechargeWallet = gamexContext.UserDetails.Single(user => user.Username == usernameToRechargeWallet);
                    userDetailsToRechargeWallet.Wallet = userDetailsToRechargeWallet.Wallet;
                    ViewBag.WalletBalance = "Your Wallet Balance Is " + userDetailsToRechargeWallet.Wallet;
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
        public ActionResult RechargeWallet(RechargeWalletViewModel rechargeWallet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string usernameToRechargeWallet = Session["usernameToUserActionMethods"].ToString();
                    var userDetailsToRechargeWallet = gamexContext.UserDetails.Single(user => user.Username == usernameToRechargeWallet);
                    userDetailsToRechargeWallet.Wallet = userDetailsToRechargeWallet.Wallet + rechargeWallet.Wallet;
                    gamexContext.SaveChanges();
                    ViewBag.WalletBalance = "Your Wallet Balance Is " + userDetailsToRechargeWallet.Wallet;
                    ViewBag.Message = "Wallet Successfully Recharged";
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }
            
            return View();
        }

        public ActionResult ViewProfileDetails()
        {
            if(Session["usernameToUserActionMethods"] != null)
            {
                try
                {
                    var usernameToViewProfile = Session["usernameToUserActionMethods"].ToString();
                    var userDetailsToViewProfile = gamexContext.UserDetails.Where(user => user.Username == usernameToViewProfile).ToList();
                    return View(userDetailsToViewProfile);
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
        public ActionResult EditProfileOfUser()
        {
            if(Session["usernameToUserActionMethods"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Login", "LoginUser");
        }
        [HttpPost]
        public ActionResult EditProfileOfUser(EditProfileOfUserViewModel editProfile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usernameToEditProfile = Session["usernameToUserActionMethods"].ToString();
                    var userDetailsToEditProfile = gamexContext.UserDetails.Single(user => user.Username == usernameToEditProfile);
                    if (editProfile.OldPassword == userDetailsToEditProfile.UserPassword)
                    {
                        userDetailsToEditProfile.UserFullName = editProfile.UserFullName;
                        userDetailsToEditProfile.UserEmail = editProfile.UserEmail;
                        userDetailsToEditProfile.UserPassword = editProfile.UserPassword;
                        gamexContext.SaveChanges();
                        ViewBag.Message = "Profile Edited Successfully";
                    }
                    else
                    {
                        ViewBag.Message = "The Old Password didn't Match !! Please Try again !!";
                    }

                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "LoginUser");
        }
    }
}