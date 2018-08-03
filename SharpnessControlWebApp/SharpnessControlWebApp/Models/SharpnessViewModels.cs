using IdentitySample.Models;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpnessControlWebApp.Models
{
    public class SharpnessViewModels
    {
        public IEnumerable<Stain> Stains { get; set; }
        public IEnumerable<Organ> Organs { get; set; }
        public IEnumerable<Tissue> Tissues { get; set; }
        public IEnumerable<Reglament> Reglaments { get; set; }
        public IEnumerable<WSI> WSIs { get; set; }
        public IEnumerable<Report> Reports { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<WSI> RecentWSIs { get; set; }



        public WSI WSI { get; set; }
        public Stain Stain { get; set; }
        public Organ Organ { get; set; }
        public Tissue Tissue { get; set; }
        public Report Report { get; set; }
        public Reglament Reglament { get; set; }
    }
}