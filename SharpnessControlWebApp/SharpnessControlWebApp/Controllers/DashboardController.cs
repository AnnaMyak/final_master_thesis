using Microsoft.AspNet.Identity;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities;
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
        private IWSIRepo  repoWSI = new WSIRepo();
        private IReportRepo  repoReport = new ReportRepo();
        private SharpnessViewModels  model = new SharpnessViewModels();

        // GET: Dashboard
        public ActionResult Index()
        {
            
            //Total Tests
            ViewBag.TotalNumberOfTests = repoReport.GetAllReportsByUserId(User.Identity.GetUserId()).Count();
            ViewBag.TotalNumberOfTestsThisWeek = repoReport.GetAllReportsByUserIdLastWeek(User.Identity.GetUserId()).Count();
            ViewBag.TotalNumberOfTestsThisMonth = repoReport.GetAllReportsByUserLastMonth(User.Identity.GetUserId()).Count();
            ViewBag.TotalNumberOfTestsThisYear = repoReport.GetAllReportsByUserLastYear(User.Identity.GetUserId()).Count();

            //Positive Tests
            ViewBag.TotalNumberPositive= repoReport.GetAllPositiveReportsByUser(User.Identity.GetUserId()).Count();

            //negative Tests
            ViewBag.TotalNumberNegative = repoReport.GetAllNegativeReportsByUser(User.Identity.GetUserId()).Count();

            //recent Tests
            //model.WSIs = repoWSI.GetAllWSIByUserId(User.Identity.GetUserId());
            //model.Reports = repoReport.GetAllReportsByUserId(User.Identity.GetUserId());
            ViewBag.RecentWSIs = repoWSI.GetRecentWSIByUSerId(User.Identity.GetUserId());

            return View();
        }

        public ActionResult WSIToReport(Guid WSIId)
        {
            var report = repoReport.GetReportByWSI(WSIId);
            return RedirectToAction("Report", "ControlPanel", new { ReportId = report.ReportId });
        }

        public ActionResult AllMyTests()
        {
            model = new SharpnessViewModels();
            model.WSIs = repoWSI.GetAllWSIByUserId(User.Identity.GetUserId());
            return View(model);
        }
    }
}