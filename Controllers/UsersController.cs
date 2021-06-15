using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba14.Models;
using Prueba14.Models.ViewModels;

namespace Prueba14.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            List<ListUsersViewModel> lst;
            using (Punto14dbEntities db = new Punto14dbEntities())
            {
                lst = (from d in db.Users
                           select new ListUsersViewModel
                           {
                               Id = d.ID,
                               Apel = d.Apel,
                               Name = d.Name,
                               Email = d.email,
                               Address = d.Address
                           }).ToList();
            }


            return View(lst);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(UsersViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Punto14dbEntities db = new Punto14dbEntities())
                    {
                        var oUser = new Users();

                        oUser.ID = model.Id;
                        oUser.Apel = model.Apel;
                        oUser.Name = model.Name;
                        oUser.email = model.Email;
                        oUser.Address = model.Address;

                        db.Users.Add(oUser);
                        db.SaveChanges();
                    }

                    return Redirect("~/Users/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Mod(int Id)
        {
            UsersViewModel model = new UsersViewModel();
            using (Punto14dbEntities db = new Punto14dbEntities())
            {
                var oUser = db.Users.Find(Id);
                model.Id = oUser.ID;
                model.Apel = oUser.Apel;
                model.Name = oUser.Name;
                model.Email = oUser.email;
                model.Address = oUser.Address;
            }
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Mod(UsersViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Punto14dbEntities db = new Punto14dbEntities())
                    {
                        var oUser = db.Users.Find(model.Id);

                        oUser.ID = model.Id;
                        oUser.Apel = model.Apel;
                        oUser.Name = model.Name;
                        oUser.email = model.Email;
                        oUser.Address = model.Address;

                        db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Users/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Del(int Id)
        {            
            using (Punto14dbEntities db = new Punto14dbEntities())
            {
                var oUser = db.Users.Find(Id);
                db.Users.Remove(oUser);
                db.SaveChanges();
            }

            return Redirect("~/Users/");
        }
    }
}