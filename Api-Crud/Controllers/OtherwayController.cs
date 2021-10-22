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
        public string Post(userdata u)
        {
            db.userdatas.Add(u);
            db.SaveChanges();
            return "product Added";
        }
        public JsonResult Get()
        {
            var data = db.userdatas.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult find(int id)
        {
            userdata userdata = db.userdatas.Find(id);

            var data = JsonConvert.SerializeObject(userdata);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public string Put(int id, userdata u)
        {
            var dbs = db.userdatas.Find(id);
            dbs.firstname = u.firstname;
            dbs.lastname = u.lastname;
            db.Entry(dbs).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "update seccessfully";
        }
        public string Delete(int id)
        {
            userdata userdata = db.userdatas.Find(id);
            db.userdatas.Remove(userdata);
            db.SaveChanges();
            return "deleted";
        }
    }
}