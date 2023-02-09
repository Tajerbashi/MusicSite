using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DAL.Context;

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
        public ActionResult Login()
        {
            return PartialView();

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
            userRepository.Add(user);
            userRepository.Save();
            return PartialView(user);

        }
    }
}