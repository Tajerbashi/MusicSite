using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DAL.Context;
using System.Web.Security;
using Microsoft.Ajax.Utilities;

namespace MusicSite.Controllers
{
    public class LoginUserController : Controller
    {
        DbContexts DB = new DbContexts();
        IUserRepository userRepository;
        public LoginUserController()
        {
            userRepository = new UserRepository(DB);
        }
        // GET: LoginUser
        public ActionResult Panel()
        {
            return PartialView();
        }
        public ActionResult LoginForm()
        {
            return PartialView();
        }
        public ActionResult RegisterForm()
        {
            return PartialView();
        }
        public ActionResult LoginPanel()
        {
            return PartialView();
        }
        public ActionResult UserIsLogin(string Username,string Password,bool Remember)
        {
            if (userRepository.GetUserByUsernamePassword(Username, Password))
            {
                FormsAuthentication.SetAuthCookie(Username, Remember);
                return RedirectToAction("LoginUserPanel", new { username = Username });

            }
            return RedirectToAction("LoginPanel");
        }
        public ActionResult RegUser(string Name, string Family, string Email, string Phone, string Username, string Password)
        {
            User user = new User();

            user.Name = Name;
            user.Family = Family;
            user.Phone = Phone;
            user.Email = Email;
            user.Username = Username;
            user.Password = Password;
            user.Total = 0;
            user.Type = false;
            user.CreateDate = DateTime.Now;
            if (!userRepository.IsUser(user))
            {
                userRepository.Add(user);
                userRepository.Save();
                FormsAuthentication.SetAuthCookie(user.Username, false);
            }
            return RedirectToAction("LoginUserPanel",new { username = user.Username });
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
        public ActionResult LoginUserPanel(string username)
        {
            return PartialView(userRepository.GetByUsername(username));
        } 
    }
}