using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpnessControlWebApp.Models.Sharpness_Persistence.Sharpness_ResearchRepository
{
    public interface IResearchRepo
    {
        //All Positive Tests
        IEnumerable<Research> AllPositiveTestsSortedByStain();
        IEnumerable<Research> AllPositiveTestsSortedByOrgan();
        IEnumerable<Research> AllPositiveTestsSortedByTissue();

        //All Negative Tests
        IEnumerable<Research> AllNegativeTestsSortedByStain();
        IEnumerable<Research> AllNegativeTestsSortedByOrgan();
        IEnumerable<Research> AllNegativeTestsSortedByTissue();



        //By Stain & Organ
        IEnumerable<CommonResearch> AllPositiveSortedByStainAndOrgan();
        IEnumerable<CommonResearch> AllNegativeSortedByStainAndOrgan();









        //Special common  report
        IEnumerable<CommonResearch> CommonReportPositive();
        IEnumerable<CommonResearch> CommonReportNegative();


    }
}
