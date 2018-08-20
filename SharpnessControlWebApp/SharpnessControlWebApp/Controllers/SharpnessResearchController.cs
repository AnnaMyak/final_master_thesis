using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Implementation;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Interfaces;
using SharpnessControlWebApp.Models;
using SharpnessControlWebApp.Models.Sharpness_Persistence.Sharpness_ResearchRepository;
using System;
using System.Collections;
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
        private IResearchRepo researchRepo  = new ResearchRepo();
        


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


            //Stain
            var researchesStainPositive = researchRepo.AllPositiveTestsSortedByStain();
            var researchesStainNegative = researchRepo.AllNegativeTestsSortedByStain();

            //Sorted by stain, positive, Dataset 1
            var stainsPositive = new List<string>();
            var stainsValuesPositive = new List<int>();
            var stainsColorPositive = new List<string>();
            foreach (var item in researchesStainPositive)
            {
                stainsPositive.Add(item.Item);
                stainsValuesPositive.Add(item.Number);
                stainsColorPositive.Add("#00802b");
            }
            ViewBag.StainsPositive = stainsPositive;
            ViewBag.StainsValuesPositive = stainsValuesPositive;
            ViewBag.StainsColorPositive = stainsColorPositive;
            //Sorted by stain, negative, Dataset 2
            var stainsNegative = new List<string>();
            var stainsValuesNegative = new List<int>();
            var stainsColorNegative = new List<string>();
            foreach (var item in researchesStainNegative)
            {
                stainsNegative.Add(item.Item);
                stainsValuesNegative.Add(item.Number);
                stainsColorNegative.Add("#e6004c");
            }
            ViewBag.StainsNegative = stainsNegative;
            ViewBag.StainsValuesNegative = stainsValuesNegative;
            ViewBag.StainsColorNegative = stainsColorNegative;


            //Organ
            var researchesOrganNegative  = researchRepo.AllNegativeTestsSortedByOrgan();
            var researchesOrganPositive = researchRepo.AllPositiveTestsSortedByOrgan();
            //Sorted by organs, positive, Dataset 1
            var organsPositive = new List<string>();
            var organsValuesPositive = new List<int>();
            var organsColorPositive = new List<string>();
            foreach (var item in researchesOrganPositive)
            {
                organsPositive.Add(item.Item);
                organsValuesPositive.Add(item.Number);
                organsColorPositive.Add("#00802b");
            }
            ViewBag.OrgansPositive = organsPositive;
            ViewBag.OrgansValuesPositive = organsValuesPositive;
            ViewBag.OrgansColorPositive = organsColorPositive;
            //Sorted by organ, negative, Dataset 2
            var organsNegative = new List<string>();
            var organsValuesNegative = new List<int>();
            var organsColorNegative = new List<string>();
            foreach (var item in researchesOrganNegative)
            {
                organsNegative.Add(item.Item);
                organsValuesNegative.Add(item.Number);
                organsColorNegative.Add("#e6004c");
            }
            ViewBag.OrgansNegative = organsNegative;
            ViewBag.OrgansValuesNegative = organsValuesNegative;
            ViewBag.OrgansColorNegative = organsColorNegative;



            //Tissue
            var researchesTissueNegative = researchRepo.AllNegativeTestsSortedByTissue();
            var researchesTissuePositive = researchRepo.AllPositiveTestsSortedByTissue();

            //Sorted by organs, positive, Dataset 1
            var tissuesPositive = new List<string>();
            var tissuesValuesPositive = new List<int>();
            var tissuesColorPositive = new List<string>();
            foreach (var item in researchesTissuePositive)
            {
                tissuesPositive.Add(item.Item);
                tissuesValuesPositive.Add(item.Number);
                tissuesColorPositive.Add("#00802b");
            }
            ViewBag.TissuesPositive = tissuesPositive;
            ViewBag.TissuesValuesPositive = tissuesValuesPositive;
            ViewBag.TissuesColorPositive = tissuesColorPositive;
            //Sorted by organ, negative, Dataset 2
            var tissuesNegative = new List<string>();
            var tissuesValuesNegative = new List<int>();
            var tissuesColorNegative = new List<string>();
            foreach (var item in researchesTissueNegative)
            {
                tissuesNegative.Add(item.Item);
                tissuesValuesNegative.Add(item.Number);
                tissuesColorNegative.Add("#e6004c");
            }
            ViewBag.TissuesNegative = tissuesNegative;
            ViewBag.TissuesValuesNegative = tissuesValuesNegative;
            ViewBag.TissuesColorNegative = tissuesColorNegative;



            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Stain stain, Organ organ, Tissue tissue)
        {
        



            return RedirectToAction("SharpnessResearchResult", new { stain = stain.Name, organ=organ.Name, tissue=tissue.Name });
        }

        public ActionResult SharpnessResearchResult(string stain, string organ, string tissue)
        {

            return View();
        }
    }
}