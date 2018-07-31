using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharpnessControlWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EntityManagementController : Controller
    {
        // GET: EntityManagement
        public ActionResult Index()
        {
            return View();
        }
    }
}