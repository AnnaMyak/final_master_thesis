using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpnessControlWebApp.Models.Sharpness_Persistence.Sharpness_ResearchRepository
{
    public class ResearchRepo : IResearchRepo
    {
        public IEnumerable<Research> AllNegativeTestsSortedByOrgan()
        {
            var organRepo = new OrganRepo();
            var reportRepo = new ReportRepo();
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
                sortedByOrgan.Add(item);
            }

            return sortedByOrgan;
        }

        public IEnumerable<Research> AllNegativeTestsSortedByStain()
        {
            var stainRepo = new StainRepo();
            var reportRepo = new ReportRepo();
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
                sortedByStain.Add(item);
            }

            return sortedByStain;
        }

        public IEnumerable<Research> AllNegativeTestsSortedByTissue()
        {
            var tissueRepo = new TissueRepo();
            var reportRepo = new ReportRepo();
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
                sortedByTissue.Add(item);
            }

            return sortedByTissue;
        }

        public IEnumerable<Research> AllPositiveTestsSortedByOrgan()
        {
            var organRepo = new OrganRepo();
            var reportRepo = new ReportRepo();
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
                sortedByOrgan.Add(item);
            }

            return sortedByOrgan;
        }

        public IEnumerable<Research> AllPositiveTestsSortedByStain()
        {
            var stainRepo = new StainRepo();
            var reportRepo = new ReportRepo();
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
                sortedByStain.Add(item);
            }

            return sortedByStain;
        }

        public IEnumerable<Research> AllPositiveTestsSortedByTissue()
        {
            var tissueRepo = new TissueRepo();
            var reportRepo = new ReportRepo();
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
                sortedByTissue.Add(item);
            }

            return sortedByTissue;
        }
    }
}