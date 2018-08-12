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
        private IReglamentRepo repoReglament = new ReglamentRepo();
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
        public ActionResult ReglamentsManagement()
        {

            return View(repoReglament.GetAllReglaments());
        }

        public ActionResult CreateNewReglament()
        {
            return View(new Reglament());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewReglament(Reglament reglament)
        {
            ViewBag.Error = "";

            try
            {


                if (ModelState.IsValid)
                {
                    repoReglament.Insert(new Reglament
                    {
                        Titel = reglament.Titel,
                        SharpnessThresholdValue = reglament.SharpnessThresholdValue,
                        Scaling = reglament.Scaling,
                        Edges = reglament.Edges,
                        TileSize = reglament.TileSize,
                        AcceptanceValue = reglament.AcceptanceValue,
                        Status = reglament.Status
                    });

                    return RedirectToAction("ReglamentsManagement");
                }
            }
            catch
            {
                ViewBag.Error = "Das neue Kriterium nicht möglich hinzufügen. Überprüfe die Eingabefelder!";
            }
            return View(reglament);
        }


        public ActionResult EditReglament(Guid ReglamentId)
        {
            return View(repoReglament.GetReglamentById(ReglamentId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReglament(Reglament reglament)
        {
                if (ModelState.IsValid)
                {
                    repoReglament.Update(reglament);
                    return RedirectToAction("ReglamentsManagement");
                }


                return View(reglament);
            }

        [HttpGet]
        public ActionResult DeleteReglament(Guid ReglamentId)
        {
            if ( ReglamentId== null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var reglament  = repoReglament.GetReglamentById(ReglamentId);
            if (reglament == null)
            {
                return HttpNotFound();
            }

            return View(repoReglament.GetReglamentById(ReglamentId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReglament(Guid ReglamentId, FormCollection collection)
        {
            ViewBag.Error = "";
            var _context = new ApplicationDbContext();
            try
            {


                _context.Reglaments.Remove(_context.Reglaments.Find(ReglamentId));
                _context.SaveChanges();
                return RedirectToAction("ReglamentsManagement");

            }
            catch
            {
                ViewBag.Error = "Das Kriterium ist schon gelöscht worden oder existiert nicht!";

            }
            return View(_context.Reglaments.Find(ReglamentId));
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
            return View(wsi);
        }

        [HttpPost]
        public ActionResult DeleteWSIAndReport(Guid WSIId, FormCollection collection)
        {

            var _context = new ApplicationDbContext();
            
            try
            {
                

                try
                {
                    var globalPath = _context.WSIs.Find(WSIId).Path.Split('\\');
                    var directoryPath = "";

                    for (int i = 0; i < globalPath.Count() - 1; i++)
                    {
                        directoryPath = directoryPath + globalPath[i];
                    }
                    //directoryPath= @"C:\Users\AnnaToshiba2\Desktop\Test";
                     var dir = new DirectoryInfo(@directoryPath);
                    dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                    dir.Delete(true);
                    
                }
                catch (IOException ex)
                {
                    //
                }



                _context.Reports.Remove(_context.Reports.Where(r=> r.WSIId==WSIId).First());
                _context.WSIs.Remove(_context.WSIs.Find(WSIId));
                _context.SaveChanges();



                return RedirectToAction("WSIs");

            }
            catch
            {
                
            }

            return View(_context.WSIs.Find(WSIId));
        }

        public ActionResult DeleteWSI(Guid WSIId)
        {
            var _context = new ApplicationDbContext();
            var wsi = _context.WSIs.Find(WSIId);

            System.IO.FileInfo fi = new System.IO.FileInfo(wsi.Path);
            try
            {
                fi.Delete();
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