﻿using IdentitySample.Models;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Implementation;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Interfaces;
using SharpnessControlWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SharpnessControlWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManagementController : Controller
    {
        private SharpnessViewModels model = new SharpnessViewModels();
        private IStainRepo repoStain = new StainRepo();
        private IOrganRepo repoOrgan = new OrganRepo();
        private ITissueRepo repoTissue = new TissueRepo();
        private IReglementRepo repoReglement = new ReglementRepo();
        private IReportRepo repoReport = new ReportRepo();
        private IWSIRepo repoWSI = new WSIRepo();


        // Overview
        public ActionResult Index()
        {
            return View();
        }
        //Stain Management
        public ActionResult StainsManagement()
        {


            return View(repoStain.GetStains());
        }

        public ActionResult CreateNewStain()
        {
            return View(new Stain());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewStain(Stain stain)
        {
            ViewBag.Error = "";

            try
            {


                if (ModelState.IsValid)
                {
                    repoStain.Insert(stain.Name);
                    return RedirectToAction("StainsManagement");
                }
            }
            catch
            {
                ViewBag.Error = "Die Färbung ist schon vorhanden!";
            }
            return View(stain);
        }
        [HttpGet]
        public ActionResult DeleteStain(string Name)
        {
            if (Name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var stain = repoStain.GetStainByName(Name);
            if (stain == null)
            {
                return HttpNotFound();
            }

            return View(repoStain.GetStainByName(Name));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStain(String Name, FormCollection collection)
        {
            ViewBag.Error = "";
            var _context = new ApplicationDbContext();
            try
            {


                _context.Stains.Remove(_context.Stains.Find(Name));
                _context.SaveChanges();
                return RedirectToAction("StainsManagement");

            }
            catch
            {
                ViewBag.Error = "Die Färbung ist schon gelöscht worden oder ist mit den Schärfe-Testen verbunden!";

            }
            return View(_context.Stains.Find(Name));
        }


        //Organ Management
        public ActionResult OrgansManagement()
        {


            return View(repoOrgan.GetOrgans());
        }

        public ActionResult CreateNewOrgan()
        {
            return View(new Organ());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewOrgan(Organ organ)
        {
            ViewBag.Error = "";

            try
            {


                if (ModelState.IsValid)
                {
                    repoOrgan.Insert(organ.Name);
                    return RedirectToAction("OrgansManagement");
                }
            }
            catch
            {
                ViewBag.Error = "Das Organ ist schon vorhanden!";
            }
            return View(organ);
        }



        [HttpGet]
        public ActionResult DeleteOrgan(string Name)
        {
            if (Name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var organ = repoOrgan.GetOrganByName(Name);
            if (organ == null)
            {
                return HttpNotFound();
            }

            return View(repoOrgan.GetOrganByName(Name));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrgan(String Name, FormCollection collection)
        {
            ViewBag.Error = "";
            var _context = new ApplicationDbContext();
            try
            {


                _context.Organs.Remove(_context.Organs.Find(Name));
                _context.SaveChanges();
                return RedirectToAction("OrgansManagement");

            }
            catch
            {
                ViewBag.Error = "Das Organ ist schon gelöscht worden oder ist mit den Schärfe-Testen verbunden!";

            }
            return View(_context.Organs.Find(Name));
        }


        //Tissue Management
        public ActionResult TissuesManagement()
        {


            return View(repoTissue.GetTissues());
        }

        public ActionResult CreateNewTissue()
        {
            return View(new Tissue());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewTissue(Tissue tissue)
        {
            ViewBag.Error = "";

            try
            {


                if (ModelState.IsValid)
                {
                    repoTissue.Insert(tissue.Name);
                    return RedirectToAction("TissuesManagement");
                }
            }
            catch
            {
                ViewBag.Error = "Die Gewebeart ist schon vorhanden!";
            }
            return View(tissue);
        }


        [HttpGet]
        public ActionResult DeleteTissue(string Name)
        {
            if (Name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tissue = repoTissue.GetTissueByName(Name);
            if (tissue == null)
            {
                return HttpNotFound();
            }

            return View(repoTissue.GetTissueByName(Name));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTissue(String Name, FormCollection collection)
        {
            ViewBag.Error = "";
            var _context = new ApplicationDbContext();
            try
            {


                _context.Tissues.Remove(_context.Tissues.Find(Name));
                _context.SaveChanges();
                return RedirectToAction("TissuesManagement");

            }
            catch
            {
                ViewBag.Error = "Die Gewebeart ist schon gelöscht worden oderist mit den Schärfe-Testen verbunden!";

            }
            return View(_context.Tissues.Find(Name));
        }

        //Sharpness Reglament Management 
        public ActionResult ReglementsManagement()
        {

            return View(repoReglement.GetAllReglements());
        }

        public ActionResult CreateNewReglement()
             
        {
            var organsObj = repoOrgan.GetOrgans();
            var stainsObj = repoStain.GetStains();
            var stains = new List<string>();
            var organs = new List<string>();
            foreach(var item in organsObj)
            {
                organs.Add(item.Name);
            }
            foreach(var item in stainsObj)
            {
                stains.Add(item.Name);
            }

            ViewBag.Stains = new SelectList(stains);
            ViewBag.Organs = new SelectList(organs);
            return View(new Reglement());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewReglement(Reglement reglament) 
        {
            ViewBag.Error = "";

            try
            {


                if (ModelState.IsValid)
                {
                    repoReglement.Insert(new Reglement
                    {
                        Titel = reglament.Titel,
                        SharpnessThresholdValue = reglament.SharpnessThresholdValue,
                        Scaling = reglament.Scaling,
                        Edges = reglament.Edges,
                        TileSize = reglament.TileSize,
                        AcceptanceValue = reglament.AcceptanceValue,
                        Status = reglament.Status,
                        StainName = reglament.StainName,
                        OrganName=reglament.OrganName
                    });

                    return RedirectToAction("ReglementsManagement");
                }
            }
            catch
            {
                ViewBag.Error = "Das neue Kriterium nicht möglich hinzufügen. Überprüfe die Eingabefelder!";
            }
            return View(reglament);
        }


        public ActionResult EditReglement(Guid ReglementId)
        {
            var organsObj = repoOrgan.GetOrgans();
            var stainsObj = repoStain.GetStains();
            var stains = new List<string>();
            var organs = new List<string>();
            foreach (var item in organsObj)
            {
                organs.Add(item.Name);
            }
            foreach (var item in stainsObj)
            {
                stains.Add(item.Name);
            }
            ViewBag.Stains = new SelectList(stains);
            ViewBag.Organs = new SelectList(organs);
            return View(repoReglement.GetReglementById(ReglementId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReglement(Reglement reglement)
        {

                if (ModelState.IsValid)
                {
                    repoReglement.Update(reglement);
                    return RedirectToAction("ReglementsManagement");
                }


                return View(reglement);
        }

        [HttpGet]
        public ActionResult DeleteReglement(Guid ReglementId)
        {
            if ( ReglementId== null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var reglament  = repoReglement.GetReglementById(ReglementId);
            if (reglament == null)
            {
                return HttpNotFound();
            }

            return View(repoReglement.GetReglementById(ReglementId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReglement(Guid ReglementId, FormCollection collection)
        {
            ViewBag.Error = "";
            var _context = new ApplicationDbContext();
            try
            {


                _context.Reglements.Remove(_context.Reglements.Find(ReglementId));
                _context.SaveChanges();
                return RedirectToAction("ReglementsManagement");

            }
            catch
            {
                ViewBag.Error = "Das Kriterium ist schon gelöscht worden oder existiert nicht!";

            }
            return View(_context.Reglements.Find(ReglementId));
        }
        
        
        //All tested WSIs ordered to UserName
        public ActionResult WSIs()
        {
            
            model.WSIs = repoWSI.GetWSIs();

            var _context = new ApplicationDbContext();
            var users = _context.Users.ToList();
            model.Users = users;
            model.Reports = repoReport.GetAllReports();

            foreach (var item in model.WSIs)
            {
                item.UserId = _context.Users.Find(item.UserId).UserName;
            }
            return View(model);
        }

        

        
        public ActionResult WSIToReport(Guid WSIId)
        {
            var report = repoReport.GetReportByWSI(WSIId);
            return RedirectToAction("Report", "ControlPanel", new { ReportId = report.ReportId });
        }

        public ActionResult DeleteWSIAndReport(Guid WSIId)
        {
            if (WSIId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var wsi = repoWSI.GetById(WSIId);


            if (wsi == null)
            {
                return HttpNotFound();
            }
            
            //TODO WSI-Repository
            var _contetx = new ApplicationDbContext();
            ViewBag.User = _contetx.Users.Find(wsi.UserId).UserName; 
            return View(wsi);
        }

        [HttpPost]
        public ActionResult DeleteWSIAndReport(Guid WSIId, FormCollection collection)
        {


            ViewBag.Error = "";
            var _context = new ApplicationDbContext();
            var wsi = _context.WSIs.Find(WSIId);
            var report = _context.Reports.Where(r => r.WSIId == WSIId).First();
            var dir = Path.GetDirectoryName(@report.SharpnessMapPath);
            Directory.Delete(dir, true);



            try
            {
                _context.Reports.Remove(report);
                _context.WSIs.Remove(wsi);
                _context.SaveChanges();
                return RedirectToAction("WSIs");

            }
            catch
            {
                ViewBag.Error = "Der Bericht und WSI sind schon gelöscht worden oder existiert nicht!";

            }

            return View(wsi);
        }

        public ActionResult DeleteWSI(Guid WSIId)
        {
            var _context = new ApplicationDbContext();
            var wsi = _context.WSIs.Find(WSIId);

            System.IO.FileInfo wsiFile = new System.IO.FileInfo(wsi.Path);
            try
            {
                wsiFile.Delete();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
            wsi.Path = "removed";
            _context.SaveChanges();

            return RedirectToAction("WSIs");
        }
    }
}