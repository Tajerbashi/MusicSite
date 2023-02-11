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
using System.IO;

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
                return RedirectToAction("LoginUserPanel",new { username = user.Username });
            }
            return HttpNotFound();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
        [Route("LoginUser/LoginUserPanel/{username}")]
        public ActionResult LoginUserPanel(string username)
        {
            return PartialView(userRepository.GetByUsername(username));
        } 
        // POST: Admin/Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUser([Bind(Include = "userId,Name,Family,Phone,Email,Username,Password,Photo,Type,Total")] User user,String Pass, HttpPostedFileBase photoUp)
        {
            if (ModelState.IsValid)
            {
                if (photoUp != null)
                {
                    if (user.Photo != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Files/User/" + user.Photo));
                    }
                    user.Photo = Guid.NewGuid() + Path.GetExtension(photoUp.FileName);
                    photoUp.SaveAs(Server.MapPath("/Files/User/" + user.Photo));
                }
                if (Pass != user.Password && Pass.Count()>5)
                {
                    user.Password = Pass;
                }
                userRepository.Update(user);
                FormsAuthentication.SetAuthCookie(user.Username, true);
                userRepository.Save();
            }
            return Redirect("/");
        }
        public ActionResult UserPanelAside(int id)
        {            
            return PartialView(userRepository.GetById(id));
        }
        public ActionResult UserPanelBodyShowInfo(int id)
        {
            return PartialView(userRepository.GetById(id));
        }
        public ActionResult UserPanelBodyShowCard(int id)
        {
            return PartialView(userRepository.GetById(id));
        }
        public ActionResult UserPanelSlider(int id)
        {
            return PartialView(userRepository.GetById(id));
        }
    }
}