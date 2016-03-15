using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;

namespace AjaxWithAsp.netMvc.Controllers
{
    using AjaxWithAsp.netMvc.Models;

    public class HomeController : Controller
    {
        CollegeDbContext db = new CollegeDbContext();
        // GET: Home
        public ActionResult Index()
        {
            
            return this.View();

        }

        public PartialViewResult All()
        {
            //Thread.Sleep(4000);
            List<Student> model = db.Students.ToList();

            return this.PartialView("_Student", model);
        }

        public PartialViewResult Top3()
        {
            //Thread.Sleep(4000);
            List<Student> model = db.Students.OrderByDescending(x => x.TotalMarks).Take(3).ToList();

            return this.PartialView("_Student", model);
        }

        public PartialViewResult Bottom3()
        {
            List<Student> model = db.Students.OrderBy(x => x.TotalMarks).Take(3).ToList();

            return this.PartialView("_Student", model);
        }
    }
}