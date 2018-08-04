using Microsoft.AspNet.Identity;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Implementation;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Interfaces;
using SharpnessControlWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharpnessControlWebApp.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private IWSIRepo _repoWSIs = new WSIRepo();
        private IReportRepo _repoReports = new ReportRepo();
        //private IUserRepo _repoUsers = new UserRepo();
        private SharpnessViewModels model;
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult WSIToReport(Guid WSIId)
        {
            var report = _repoReports.GetReportByWSI(WSIId);
            return RedirectToAction("Report", "ControlPanel", new { ReportId = report.ReportId });
        }

        public ActionResult AllMyTests()
        {
            model = new SharpnessViewModels();
            model.WSIs = _repoWSIs.GetAllWSIByUserId(User.Identity.GetUserId());
            return View(model);
        }
    }
}