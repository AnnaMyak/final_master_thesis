using IdentitySample.Models;
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
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : Controller
    {
        private IStainRepo _repoStains = new StainRepo();
        private IOrganRepo _repoOrgans = new OrganRepo();
        private ITissueRepo _repoTissues = new TissueRepo();
        private IWSIRepo _repoWSI = new WSIRepo();
        private IReportRepo _repoReports = new ReportRepo();
        private IReglamentRepo _repoReglaments = new ReglamentRepo();


        // GET: AdminDashboard
        public ActionResult Index()
        {
            
            return View();
        }
    }
}