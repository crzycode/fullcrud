using Api_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Api_Crud.Controllers
{
    public class OtherwayController : Controller
    {
        // GET: Otherway
        ApiContext db = new ApiContext();
        public string Post(user u)
        {
            db.users.Add(u);
            db.SaveChanges();
            return "product Added";
        }
        public JsonResult Get()
        {
            var data = JsonConvert.SerializeObject(db.users.ToList());
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult find(int id)
        {
            user user = db.users.Find(id);

            var data = JsonConvert.SerializeObject(user);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public string Put(int id, user u)
        {
            var dbs = db.users.Find(id);
            dbs.firstname = u.firstname;
            dbs.lastname = u.lastname;
            db.Entry(dbs).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "update seccessfully";
        }
        public string Delete(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return "deleted";
        }
    }
}