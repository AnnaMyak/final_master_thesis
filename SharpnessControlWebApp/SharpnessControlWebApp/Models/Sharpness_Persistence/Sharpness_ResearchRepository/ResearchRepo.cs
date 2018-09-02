using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Implementation;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpnessControlWebApp.Models.Sharpness_Persistence.Sharpness_ResearchRepository
{
    public class ResearchRepo : IResearchRepo
    {
        private IOrganRepo organRepo = new OrganRepo();
        private IStainRepo stainRepo = new StainRepo();
        private ITissueRepo tissueRepo = new TissueRepo();
        private IReportRepo reportRepo = new ReportRepo();

        public IEnumerable<Research> AllNegativeTestsSortedByOrgan()
        {
            
            var organs = organRepo.GetOrgans();
            var reports = reportRepo.GetAllNegativeReports();

            var sortedByOrgan = new List<Research>();

            foreach (var o in organs)
            {
                var item = new Research { Item = o.Name, Number = 0 };
                foreach(var r in reports)
                {
                    if (r.OrganName == o.Name)
                    {
                        item.Number++;
                    }
                }
                if (item.Number != 0)
                {
                    sortedByOrgan.Add(item);
                }
            }

            return sortedByOrgan;
        }

        public IEnumerable<Research> AllNegativeTestsSortedByStain()
        {
            
            var stains = stainRepo.GetStains();
            var reports = reportRepo.GetAllNegativeReports();

            var sortedByStain = new List<Research>();

            foreach (var s in stains)
            {
                var item = new Research { Item = s.Name, Number = 0 };
                foreach (var r in reports)
                {
                    if (r.StainName == s.Name)
                    {
                        item.Number++;
                    }
                }
                if (item.Number != 0)
                {
                    sortedByStain.Add(item);
                }
            }

            return sortedByStain;
        }

        public IEnumerable<Research> AllNegativeTestsSortedByTissue()
        {
            var tissues = tissueRepo.GetTissues();
            var reports = reportRepo.GetAllNegativeReports();

            var sortedByTissue = new List<Research>();

            foreach (var t in tissues)
            {
                var item = new Research { Item = t.Name, Number = 0 };
                foreach (var r in reports)
                {
                    if (r.TissueName == t.Name)
                    {
                        item.Number++;
                    }
                }
                if (item.Number != 0)
                {
                    sortedByTissue.Add(item);
                }
            }

            return sortedByTissue;
        }




        public IEnumerable<Research> AllPositiveTestsSortedByOrgan()
        {
            var organs = organRepo.GetOrgans();
            var reports = reportRepo.GetAllPositiveReports();

            var sortedByOrgan = new List<Research>();

            foreach (var o in organs)
            {
                var item = new Research { Item = o.Name, Number = 0 };
                foreach (var r in reports)
                {
                    if (r.OrganName == o.Name)
                    {
                        item.Number++;
                    }
                }
                if (item.Number != 0)
                {
                    sortedByOrgan.Add(item);
                }
            }

            return sortedByOrgan;
        }

        public IEnumerable<Research> AllPositiveTestsSortedByStain()
        {
            var stains = stainRepo.GetStains();
            var reports = reportRepo.GetAllPositiveReports();

            var sortedByStain = new List<Research>();

            foreach (var s in stains)
            {
                var item = new Research { Item = s.Name, Number = 0 };
                foreach (var r in reports)
                {
                    if (r.StainName == s.Name)
                    {
                        item.Number++;
                    }
                }
                if (item.Number != 0)
                {
                    sortedByStain.Add(item);
                }
            }

            return sortedByStain;
        }

        public IEnumerable<Research> AllPositiveTestsSortedByTissue()
        {
            var tissues = tissueRepo.GetTissues();
            var reports = reportRepo.GetAllPositiveReports();

            var sortedByTissue = new List<Research>();

            foreach (var t in tissues)
            {
                var item = new Research { Item = t.Name, Number = 0 };
                foreach (var r in reports)
                {
                    if (r.TissueName == t.Name)
                    {
                        item.Number++;
                    }
                }
                if (item.Number!=0)
                {
                    sortedByTissue.Add(item);
                }
            }

            return sortedByTissue;
        }



        public IEnumerable<CommonResearch> CommonReportPositive()
        {
            var stains = stainRepo.GetStains();
            var organs = organRepo.GetOrgans();
            var tissues = tissueRepo.GetTissues();
            var reports = reportRepo.GetAllPositiveReports();
            var sorted = new List<CommonResearch>();

            foreach (var s in stains)
            {
                foreach (var o in organs)
                {
                    foreach (var t in tissues)
                    {
                        var item = new CommonResearch { Stain = s.Name, Organ=o.Name, Tissue= t.Name, Number = 0 };
                        foreach (var r in reports)
                        {
                            
                            if (r.StainName==item.Stain&& r.OrganName== item.Organ && r.TissueName == item.Tissue)
                            {
                                item.Number++;
                            }

                        }
                        if (item.Number != 0)
                        {
                            sorted.Add(item);
                        }
                    }
                    
                }
                
            }
            return sorted;
        }

        public IEnumerable<CommonResearch> CommonReportNegative()
        {
            var stains = stainRepo.GetStains();
            var organs = organRepo.GetOrgans();
            var tissues = tissueRepo.GetTissues();
            var reports = reportRepo.GetAllNegativeReports();
            var sorted = new List<CommonResearch>();

            foreach (var s in stains)
            {
                foreach (var o in organs)
                {
                    foreach (var t in tissues)
                    {
                        var item = new CommonResearch { Stain = s.Name, Organ = o.Name, Tissue = t.Name, Number = 0 };
                        foreach (var r in reports)
                        {

                            if (r.StainName == item.Stain && r.OrganName == item.Organ && r.TissueName == item.Tissue)
                            {
                                item.Number++;
                            }

                        }
                        if (item.Number != 0)
                        {
                            sorted.Add(item);
                        }
                        
                    }

                }

            }
            return sorted;
        }

        public IEnumerable<CommonResearch> AllPositiveSortedByStainAndOrgan()
        {
            var stains = stainRepo.GetStains();
            var organs = organRepo.GetOrgans();
            var reports = reportRepo.GetAllPositiveReports();
            var sorted = new List<CommonResearch>();

            foreach (var s in stains)
            {
                foreach (var o in organs)
                {
                    
                        var item = new CommonResearch { Stain = s.Name, Organ = o.Name, Number = 0 };
                        foreach (var r in reports)
                        {

                            if (r.StainName == item.Stain && r.OrganName == item.Organ)
                            {
                                item.Number++;
                            }

                        }
                        if (item.Number != 0)
                        {
                            sorted.Add(item);
                        }
                    

                }

            }
            return sorted;
        }

        public IEnumerable<CommonResearch> AllNegativeSortedByStainAndOrgan()
        {
            var stains = stainRepo.GetStains();
            var organs = organRepo.GetOrgans();
            var reports = reportRepo.GetAllNegativeReports();
            var sorted = new List<CommonResearch>();

            foreach (var s in stains)
            {
                foreach (var o in organs)
                {

                    var item = new CommonResearch { Stain = s.Name, Organ = o.Name, Number = 0 };
                    foreach (var r in reports)
                    {

                        if (r.StainName == item.Stain && r.OrganName == item.Organ)
                        {
                            item.Number++;
                        }

                    }
                    if (item.Number != 0)
                    {
                        sorted.Add(item);
                    }


                }

            }
            return sorted;
        }
    }
}