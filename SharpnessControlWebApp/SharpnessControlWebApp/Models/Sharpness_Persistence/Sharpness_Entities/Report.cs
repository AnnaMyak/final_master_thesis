﻿using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities
{
    public class Report
    {
        public Report()
        {
            ReportId = System.Guid.NewGuid();
            Creation = DateTime.Now;
        }

        public Guid ReportId { get; set; }
        //UserId
        public string UserId { get; set; }




        public Guid WSIId { get; set; }
        public Guid ReglementId { get; set; }

        public string StainName { get; set; }
        public string OrganName { get; set; }
        public string TissueName { get; set; }







        //First Sharpness Map
        //in %
        public double Semaphore_Green { get; set; }
        public double Semaphore_Yellow { get; set; }
        public double Semaphore_Red { get; set; }



        //Second Sharpness Map
        //Debug Map
        //in %
        public double Red_Channel { get; set; }
        public double Blue_Channel { get; set; }


        public string ReportLink { get; set; }
        public string SharpnessMapPath { get; set; }
        public string SharpnessMapPathDebug { get; set; }


        public bool Evaluation { get; set; }
        public string Comment { get; set; }
        public DateTime Creation { get; set; }


        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("WSIId")]
        public WSI WSI { get; set; }

        [ForeignKey("ReglementId")]
        public Reglement Reglament { get; set; }
        [ForeignKey("StainName")]
        public Stain Stain { get; set; }
        [ForeignKey("OrganName")]
        public Organ Organ { get; set; }
        [ForeignKey("TissueName")]
        public Tissue Tissue { get; set; }

        

    }
}