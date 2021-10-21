using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Api_Crud.Models;
using Newtonsoft.Json;

namespace Api_Crud.Controllers
{
    public class AddController : Controller
    {
        // GET: Add
        ApiContext db = new ApiContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(user u)
        {
            db.users.Add(u);
            db.SaveChanges();
            return View();
        }
        public ActionResult Get()
        {
            var data = db.users.ToList();
            var json = JsonConvert.SerializeObject(data);
            
            return Json(json,JsonRequestBehavior.AllowGet);
        }

        public ActionResult find(int id)
        {
            user user = db.users.Find(id);
            var json = JsonConvert.SerializeObject(user);

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPut]
        public string put(int id, user u)
        {
            var db_ = db.users.Find(id);
            db_.firstname = u.firstname;
            db_.lastname = u.lastname;

            db.Entry(db_).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "update successfully";
        }
        public string delete(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return "deleted";
        }
    }
}