using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Implementation;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Interfaces;
using SharpnessControlWebApp.Models;
using SharpnessControlWebApp.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities;
using System.Diagnostics;

namespace SharpnessControlWebApp.Controllers
{
    [Authorize]
    public class ControlPanelController : Controller
    {
        private IStainRepo _repoStains = new StainRepo();
        private IOrganRepo _repoOrgans = new OrganRepo();
        private IWSIRepo _repoWSIs = new WSIRepo();
        private IReglamentRepo _repoReglaments = new ReglamentRepo();
        private ISharpnessManager manager = new SharpnessManager();
        private ITissueRepo _repoTissues = new TissueRepo();
        private IReportRepo _repoReports = new ReportRepo();

        // GET: ControlPanel
        public ActionResult Index()
        {
            SharpnessViewModels model = new SharpnessViewModels();
            model.Organs = _repoOrgans.GetOrgans();
            model.Stains = _repoStains.GetStains();
            model.Tissues = _repoTissues.GetTissues();
            ViewBag.Stains = new SelectList(model.Stains, "Name", "Name");
            ViewBag.Organs = new SelectList(model.Organs, "Name", "Name");
            ViewBag.Tissues = new SelectList(model.Tissues, "Name", "Name");
            return View(model);
        }

        public ActionResult Report(Guid ReportId)
        {
            var report = _repoReports.GetReportById(ReportId);
            ViewBag.ViewerLink = "http://localhost:5000/Sharpness_WebApp_Uploads/" + report.ReportLink;
            ViewBag.Stain = _repoStains.GetStainByName(report.StainName).Name;
            ViewBag.Tissue = _repoTissues.GetTissueByName(report.TissueName).Name;
            ViewBag.Organ = _repoOrgans.GetOrganByName(report.OrganName).Name;
            ViewBag.Evaluation = report.Evaluation;
            ViewBag.G = report.Semaphore_Green;
            ViewBag.Y = report.Semaphore_Yellow;
            ViewBag.R = report.Semaphore_Red;


            var ImgPath = report.SharpnessMapPath;
            Image img = Image.FromFile(ImgPath);
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                arr = ms.ToArray();
            }



            var base64 = Convert.ToBase64String(arr);
            ViewBag.Img = String.Format("data:image/png;base64,{0}", base64);

            var ImgPathDebug = report.SharpnessMapPathDebug;
            Image imgDebug = Image.FromFile(ImgPathDebug);
            byte[] arrDebug;
            using (MemoryStream ms = new MemoryStream())
            {
                imgDebug.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                arrDebug = ms.ToArray();
            }
            var base64Debug = Convert.ToBase64String(arrDebug);
            ViewBag.Debug = String.Format("data:image/png;base64,{0}", base64Debug);
            ViewBag.DebugRed = report.Red_Channel;
            ViewBag.DebugBlue = report.Blue_Channel;
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, WSI wsi, Stain stain, Organ organ, Tissue tissue)
        {

            //TODO
            //Today only one value possible
            //var tissue = _repoTissues.GetTissueByName("Tissue");
            ISharpnessManager manager = new SharpnessManager();
            //
            var root = @"C:\Users\AnnaToshiba2\Desktop\WSI\Sharpness_WebApp_Uploads\";
            var fileName = "";
            wsi.WSIId = Guid.NewGuid();

            string outputDir = Path.Combine(Path.GetDirectoryName(root), User.Identity.GetUserName(), "WSI " + wsi.WSIId + @"\");
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(outputDir, fileName);
                file.SaveAs(path);


                wsi.Path = path;
                wsi.UserId = User.Identity.GetUserId();
                _repoWSIs.Insert(wsi);

            }

            var reportLink = User.Identity.GetUserId() + "/" + "WSI " + wsi.WSIId + "/" + fileName + " ";
            var evaluationLink = root + reportLink.Replace("/", @"\");
            Process first = new Process();
            first.StartInfo.FileName = @"C:\Users\AnnaToshiba2\Documents\GitHub\sharpness\sharpness console App\SharpnessExplorationCurrent\SharpnessExplorationCurrent\bin\x64\Release\SharpnessExplorationCurrent.exe";
            first.StartInfo.Arguments = String.Format(@"""{0}""", wsi.Path);
            first.Start();
            first.WaitForExit();

            var report = new Report();
            report.ReglamentId = _repoReglaments.GetReglamentByTitel("Default").ReglamentId;
            report.Comment = "some words";

            report.OrganName = organ.Name;
            report.TissueName = tissue.Name;
            report.WSIId = wsi.WSIId;
            report.StainName = stain.Name;
            report.SharpnessMapPath = outputDir + Path.GetFileNameWithoutExtension(fileName) + ".png";
            report.SharpnessMapPathDebug = outputDir + Path.GetFileNameWithoutExtension(fileName) + "Debug.png";
            var semaphoreValues = manager.GetSemaphoreValues(report.SharpnessMapPath);
            var channelsValues = manager.GetChannelsValues(report.SharpnessMapPathDebug);


            report.Semaphore_Red = semaphoreValues[0];
            report.Semaphore_Green = semaphoreValues[1];
            report.Semaphore_Yellow = semaphoreValues[2];

            report.Red_Channel = channelsValues[0];
            report.Blue_Channel = channelsValues[1];

            if (semaphoreValues[1] > 70)
            {
                report.Evaluation = true;
            }
            else
            {
                report.Evaluation = false;
            }
            report.ReportLink = reportLink;
            report.UserId = User.Identity.GetUserId();
            _repoReports.Insert(report);
            return RedirectToAction("Report", new { ReportId = report.ReportId });
        }
    }
}