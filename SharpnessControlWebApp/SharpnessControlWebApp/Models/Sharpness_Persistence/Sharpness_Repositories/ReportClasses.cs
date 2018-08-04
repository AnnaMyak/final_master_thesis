using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpnessControlWebApp.Models.Sharpness_Persistence.Sharpness_Repositories
{
    public class ReportByStain
    {
        public string Stain { get; set; }
        public int Number { get; set; }
    }

    public class ReportByOrgan
    {
        public string Organ { get; set; }
        public int Number { get; set; }
    }

    public class ReportByTissue 
    {
        public string Tissue { get; set; }
        public int Number { get; set; }
    }

    public class DynamicForAYear
    {
        public int Month { get; set; }
        public int Number { get; set; }
    }
}