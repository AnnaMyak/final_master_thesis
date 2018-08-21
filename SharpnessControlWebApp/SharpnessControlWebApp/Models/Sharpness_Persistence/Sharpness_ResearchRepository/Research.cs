using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpnessControlWebApp.Models.Sharpness_Persistence.Sharpness_ResearchRepository
{
    public class Research
    {
        public string Item { get; set; }
        public int Number { get; set; }
    }

    public class CommonResearch
    {
        public string Stain { get; set; }
        public string Organ { get; set; }
        public string Tissue { get; set; }
        public int Number { get; set; }
    }
}