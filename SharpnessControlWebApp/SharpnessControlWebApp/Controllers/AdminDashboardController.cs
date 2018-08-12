using IdentitySample.Models;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Implementation;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Interfaces;
using SharpnessControlWebApp.Models;
using SharpnessControlWebApp.Models.Sharpness_Persistence.UserRepositoryExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SharpnessControlWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : Controller
    {
        private IWSIRepo repoWSI = new WSIRepo();
        private IReportRepo repoReport = new ReportRepo();
        private IUserRepo repoTracking = new UserRepo();
        private SharpnessViewModels model = new SharpnessViewModels();


        // GET: AdminDashboard
        public ActionResult Index()
        {

            //Total Tests
            ViewBag.TotalNumberOfTests = repoReport.GetAllReports().Count();
            ViewBag.TotalNumberOfTestsThisWeek = repoReport.GetAllReportsLastWeek().Count();
            ViewBag.TotalNumberOfTestsThisMonth = repoReport.GetAllReportsLastMonth().Count();
            ViewBag.TotalNumberOfTestsThisYear = repoReport.GetAllReportsLastYear().Count();

            //Positive Tests
            ViewBag.TotalNumberPositive = repoReport.GetAllPositiveReports().Count();

            //negative Tests
            ViewBag.TotalNumberNegative = repoReport.GetAllNegativeReports().Count();

            //recent Tests
            ViewBag.RecentWSIs = repoWSI.GetRecentWSIs();

            //report by Stain last month
            var reportByStains = repoReport.GetReportByStainsForLastMonth();
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
            var reportByOrgans = repoReport.GetReportByOrgansForLastMonth();
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
            var reportByTissues = repoReport.GetReportByTissuesForLastMonth();
            var tissues = new List<string>();
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

            var dynamics = repoReport.GetDynamicForAYear();
            var months = new List<int>();
            var monthsValues = new List<int>();
            //var monthsColor = new List<string>();

            foreach (var item in dynamics)
            {
                months.Add(item.Month);
                monthsValues.Add(item.Number);
               // monthsColor.Add("#00cc44");
            }

            ViewBag.Months = months;
            ViewBag.MonthsValues = monthsValues;


            ViewBag.usersToday = repoTracking.RegisteredUsersToday();
            ViewBag.usersMonth = repoTracking.RegisteredUsersThisMonth();
            ViewBag.usersYear = repoTracking.RegisteredUsersThisYear();
            var _context = new ApplicationDbContext();
            ViewBag.TotalUsers = _context.Users.ToList().Count;


            return View();
        }

        public ActionResult WSIToReport(Guid WSIId)
        {
            var report = repoReport.GetReportByWSI(WSIId);
            return RedirectToAction("Report", "ControlPanel", new { ReportId = report.ReportId });
        }

        

        public ActionResult UserActivity()
        {
            ViewBag.Today = repoTracking.ListRegisteredUsersToday();
            ViewBag.TodayNumber = repoTracking.RegisteredUsersToday();

            ViewBag.Month = repoTracking.ListRegisteredUsersThisMonth();
            ViewBag.MonthNumber = repoTracking.RegisteredUsersThisMonth();


            //Statistc for a current year
            var statistics = repoTracking.RegistrationStatistik();
            var months = new List<int>();
            var monthsValues = new List<int>();
            
            foreach (var item in statistics)
            {
                months.Add(item.Month);
                monthsValues.Add(item.Number);
                
            }

            ViewBag.Months = months;
            ViewBag.MonthsValues = monthsValues;


            return View();
        } 
    }
}