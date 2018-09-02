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
    [Authorize(Roles = "Admin")]
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



            //Common positive
            //Sorted, positive, Dataset 1
            var researchesCommonPositive = researchRepo.CommonReportPositive();
            var commonPositive = new List<string>();
            var commonValuesPositive = new List<int>();
            var commonColorPositive = new List<string>();
            foreach (var item in researchesCommonPositive)
            {
                commonPositive.Add(item.Stain+" "+item.Organ+" "+item.Tissue);
                commonValuesPositive.Add(item.Number);
                commonColorPositive.Add("#00802b");
            }
            ViewBag.CommonPositive = commonPositive;
            ViewBag.CommonValuesPositive = commonValuesPositive;
            ViewBag.CommonColorPositive = commonColorPositive;

            //Common negative
            //Sorted, positive, Dataset 2
            var researchesCommonNegative = researchRepo.CommonReportNegative();
            var commonNegative = new List<string>();
            var commonValuesNegative = new List<int>();
            var commonColorNegative = new List<string>();
            foreach (var item in researchesCommonNegative)
            {
                commonNegative.Add(item.Stain + " " + item.Organ + " " + item.Tissue);
                commonValuesNegative.Add(item.Number);
                commonColorNegative.Add("#e6004c");
            }
            ViewBag.CommonNegative = commonNegative;
            ViewBag.CommonValuesNegative = commonValuesNegative;
            ViewBag.CommonColorNegative = commonColorNegative;



            //sorted by stain & organ
            //positive
            var researcheStainOrganPositive = researchRepo.AllPositiveSortedByStainAndOrgan();
            var stain_organPositive = new List<string>();
            var stain_organValuesPositive = new List<int>();
            var stain_organColorPositive = new List<string>();
            foreach (var item in researcheStainOrganPositive)
            {
                stain_organPositive.Add(item.Stain + " " + item.Organ);
                stain_organValuesPositive.Add(item.Number);
                stain_organColorPositive.Add("#00802b");
            }
            ViewBag.stain_organPositive = stain_organPositive;
            ViewBag.stain_organValuesPositive = stain_organValuesPositive;
            ViewBag.stain_organColorPositive = stain_organColorPositive;

            //negative
            var researcheStainOrganNegative = researchRepo.AllNegativeSortedByStainAndOrgan();
            var stain_organNegative = new List<string>();
            var stain_organValuesNegative = new List<int>();
            var stain_organColorNegative = new List<string>();
            foreach (var item in researcheStainOrganNegative)
            {
                stain_organNegative.Add(item.Stain + " " + item.Organ);
                stain_organValuesNegative.Add(item.Number);
                stain_organColorNegative.Add("#e6004c");
            }
            ViewBag.stain_organNegative = stain_organNegative;
            ViewBag.stain_organValuesNegative = stain_organValuesNegative;
            ViewBag.stain_organColorNegative = stain_organColorNegative;






            return View();
        }
        
    }
}