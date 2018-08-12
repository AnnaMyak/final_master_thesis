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
    public class SharpnessResearchController : Controller
    {
        private IStainRepo  repoStains = new StainRepo();
        private IOrganRepo  repoOrgans = new OrganRepo();
        private ITissueRepo repoTissues = new TissueRepo();
        private IReportRepo repoReports = new ReportRepo();
        


        // GET: SharpnessResearch
        public ActionResult Index()
        {
            SharpnessViewModels model = new SharpnessViewModels();
            model.Organs = repoOrgans.GetOrgans();
            model.Stains = repoStains.GetStains();
            model.Tissues = repoTissues.GetTissues();
           

            ViewBag.Stains = new SelectList(model.Stains, "Name", "Name");
            ViewBag.Organs = new SelectList(model.Organs, "Name", "Name");
            ViewBag.Tissues = new SelectList(model.Tissues, "Name", "Name");
            

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Stain stain, Organ organ, Tissue tissue)
        {


            return RedirectToAction("SharpnessResearchResult", new { stain = stain.Name, organ=organ.Name, tissue=tissue.Name });
        }

        public ActionResult SharpnessResearchResult(string stain, string organ, string tissue)
        {
            ViewBag.PositiveMonth = repoReports.GetAllPositiveTestsByStainOrganTissueForALastMonth(stain, organ, tissue);
            ViewBag.Positive6Months = repoReports.GetAllPositiveTestsByStainOrganTissueForALast6Month(stain, organ, tissue);
            ViewBag.PositiveYear = repoReports.GetAllPositiveTestsByStainOrganTissueForALastYear(stain, organ, tissue);

            return View();
        }
    }
}