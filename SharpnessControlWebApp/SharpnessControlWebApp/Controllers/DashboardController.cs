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
            ViewBag.RecentWSIs = repoWSI.GetRecentWSIByUSerId(User.Identity.GetUserId());

            //report by Stain last month
            var reportByStains = repoReport.GetReportByStainsForLastMonth(User.Identity.GetUserId());
            var stains = new List<string>();
            var stainsValues = new List<int>();
            var stainsColor = new List<string>();

            foreach (var item in reportByStains)
            {
                stains.Add(item.Stain);
                stainsValues.Add(item.Number);
                stainsColor.Add("#b82e8a");
            }
            ViewBag.Stains = stains;
            ViewBag.StainsValues = stainsValues;
            ViewBag.StainsColor = stainsColor;


            //report by Organs last month
            var reportByOrgans = repoReport.GetReportByOrgansForLastMonth(User.Identity.GetUserId());
            var organs = new List<string>();
            var organsValues = new List<int>();
            var organsColor = new List<string>();

            foreach (var item in reportByOrgans)
            {
                organs.Add(item.Organ);
                organsValues.Add(item.Number);
                organsColor.Add("#1a8cff");
            }
            ViewBag.Organs = organs;
            ViewBag.OrgansValues = organsValues;
            ViewBag.OrgansColor = organsColor;


            //report by Tissues last month
            var reportByTissues = repoReport.GetReportByTissuesForLastMonth(User.Identity.GetUserId());
            var tissues  = new List<string>();
            var tissuesValues = new List<int>();
            var tissuesColor = new List<string>();

            foreach (var item in reportByTissues)
            {
                tissues.Add(item.Tissue);
                tissuesValues.Add(item.Number);
                tissuesColor.Add("#ff9900");
            }
            ViewBag.Tissues = tissues;
            ViewBag.TissuesValues = tissuesValues;
            ViewBag.TissuesColor = tissuesColor;



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