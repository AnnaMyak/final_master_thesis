using IdentitySample.Models;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using SharpnessControlWebApp.Models.Sharpness_Persistence.Sharpness_Repositories;
using System.Collections;

namespace Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Implementation
{
    public class ReportRepo : IReportRepo
    {
        public void Delete(Report r)
        {
            var _context = new ApplicationDbContext();
            _context.Reports.Remove(r);
            _context.SaveChanges();
        }

        public IEnumerable<Report> GetAllNegativeReports()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == false).ToList();
        }

        public IEnumerable<Report> GetAllNegativeReportsByOrgan(string Organ)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.OrganName == Organ).ToList();
        }

        public IEnumerable<Report> GetAllNegativeReportsByOrganAndUserId(string Organ, string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.OrganName == Organ && r.UserId == UserId).ToList();

        }

        public IEnumerable<Report> GetAllNegativeReportsByUser(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Evaluation == false).ToList();
        }

        public IEnumerable<Report> GetAllNegativeReportsByUserLastMonth(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Evaluation == false && (r.Creation < DateTime.Now && r.Creation > DateTime.Now.AddMonths(-1))).ToList();

        }

        public IEnumerable<Report> GetAllNegativeReportsByUserLastWeek(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Evaluation == false && (r.Creation < DateTime.Now && r.Creation > DateTime.Now.AddDays(-7))).ToList();
        }

        public IEnumerable<Report> GetAllNegativeReportsByUserLastYear(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Evaluation == false && (r.Creation < DateTime.Now && r.Creation > DateTime.Now.AddYears(-1))).ToList();

        }

        public IEnumerable<Report> GetAllPositiveReports()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == true).ToList();
        }

        public IEnumerable<Report> GetAllPositiveReportsByOrgan(string Organ)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.OrganName == Organ).ToList();

        }

        public IEnumerable<Report> GetAllPositiveReportsByOrganAndUserId(string Organ, string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.OrganName == Organ && r.UserId == UserId).ToList();

        }

        public IEnumerable<Report> GetAllPositiveReportsByUser(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => (r.Evaluation == true) && r.UserId == UserId).ToList();

        }

        public IEnumerable<Report> GetAllPositiveReportsByUserLastMonth(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Evaluation == true && (r.Creation < DateTime.Now && r.Creation > DateTime.Now.AddMonths(-1))).ToList();

        }

        public IEnumerable<Report> GetAllPositiveReportsByUserLastWeek(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Evaluation == true && (r.Creation < DateTime.Now && r.Creation > DateTime.Now.AddDays(-7))).ToList();

        }

        public IEnumerable<Report> GetAllPositiveReportsByUserLastYear(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Evaluation == true && (r.Creation < DateTime.Now && r.Creation > DateTime.Now.AddYears(-1))).ToList();

        }

        public IEnumerable<Report> GetAllReportByOrganAndUserId(string Organ, string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.OrganName == Organ && r.UserId == UserId).ToList();
        }

        public IEnumerable<Report> GetAllReports()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.ToList().OrderByDescending(r => r.Creation);
        }


        public IEnumerable<Report> GetAllReportsByUserId(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.UserId == UserId).OrderBy(r => r.Creation).ToList();
        }

        public IEnumerable<Report> GetAllReportsByUserIdLastWeek(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Creation > EntityFunctions.AddDays(DateTime.Now, -7)).ToList();
        }

        public IEnumerable<Report> GetAllReportsByUserLastMonth(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Creation > EntityFunctions.AddMonths(DateTime.Now, -1)).ToList();
        }

        public IEnumerable<Report> GetAllReportsByUserLastYear(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.UserId == UserId && r.Creation > EntityFunctions.AddYears(DateTime.Now, -1)).ToList();

        }

        public IEnumerable<Report> GetAllReportsLastMonth()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Creation > DateTime.Now.AddMonths(-1)).ToList();
        }

        public IEnumerable<Report> GetAllReportsLastWeek()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Creation > DateTime.Now.AddDays(-7)).ToList();
        }

        public IEnumerable<Report> GetAllReportsLastYear()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Creation > DateTime.Now.AddYears(-1)).ToList();
        }

        public Report GetReportById(Guid ReportId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Find(ReportId);
        }

        public IEnumerable<ReportByOrgan> GetReportByOrgansForLastMonth()
        {
            var organRepo = new OrganRepo();
            var organs = organRepo.GetOrgans();
            var reports = GetAllReportsLastMonth();
            IList<ReportByOrgan> reportByOrgans = new List<ReportByOrgan>();

            foreach (Organ o in organs)
            {
                var item = new ReportByOrgan() { Organ = o.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.OrganName == o.Name)
                    {
                        item.Number++;
                    }
                }
                reportByOrgans.Add(item);
            }
            return reportByOrgans;
        }

        public IEnumerable<ReportByOrgan> GetReportByOrgansForLastMonth(string UserId)
        {
            var organRepo = new OrganRepo();
            var organs = organRepo.GetOrgans();
            var reports = GetAllReportsByUserLastMonth(UserId);
            IList<ReportByOrgan> reportByOrgans = new List<ReportByOrgan>();

            foreach (Organ o in organs)
            {
                var item = new ReportByOrgan() { Organ = o.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.OrganName == o.Name)
                    {
                        item.Number++;
                    }
                }
                reportByOrgans.Add(item);
            }
            return reportByOrgans;
        }

        public IEnumerable<ReportByOrgan> GetReportByOrgansForLastWeek()
        {
            var organRepo = new OrganRepo();
            var organs = organRepo.GetOrgans();
            var reports = GetAllReportsLastWeek();
            IList<ReportByOrgan> reportByOrgans = new List<ReportByOrgan>();

            foreach (Organ o in organs)
            {
                var item = new ReportByOrgan() { Organ = o.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.OrganName == o.Name)
                    {
                        item.Number++;
                    }
                }
                reportByOrgans.Add(item);
            }
            return reportByOrgans;
        }

        public IEnumerable<ReportByOrgan> GetReportByOrgansForLastWeek(string UserId)
        {
            var organRepo = new OrganRepo();
            var organs = organRepo.GetOrgans();
            var reports = GetAllReportsByUserIdLastWeek(UserId);
            IList<ReportByOrgan> reportByOrgans = new List<ReportByOrgan>();

            foreach (Organ o in organs)
            {
                var item = new ReportByOrgan() { Organ = o.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.OrganName == o.Name)
                    {
                        item.Number++;
                    }
                }
                reportByOrgans.Add(item);
            }
            return reportByOrgans;
        }

        public IEnumerable<ReportByOrgan> GetReportByOrgansForLastYear()
        {
            var organRepo = new OrganRepo();
            var organs = organRepo.GetOrgans();
            var reports = GetAllReportsLastYear();
            IList<ReportByOrgan> reportByOrgans = new List<ReportByOrgan>();

            foreach (Organ o in organs)
            {
                var item = new ReportByOrgan() { Organ = o.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.OrganName == o.Name)
                    {
                        item.Number++;
                    }
                }
                reportByOrgans.Add(item);
            }
            return reportByOrgans;
        }

        public IEnumerable<ReportByOrgan> GetReportByOrgansForLastYear(string UserId)
        {
            var organRepo = new OrganRepo();
            var organs = organRepo.GetOrgans();
            var reports = GetAllReportsByUserLastYear(UserId);
            IList<ReportByOrgan> reportByOrgans = new List<ReportByOrgan>();

            foreach (Organ o in organs)
            {
                var item = new ReportByOrgan() { Organ = o.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.OrganName == o.Name)
                    {
                        item.Number++;
                    }
                }
                reportByOrgans.Add(item);
            }
            return reportByOrgans;
        }

        public IEnumerable<ReportByStain> GetReportByStainsForLastMonth()
        {
            var stainRepo = new StainRepo();
            var stains = stainRepo.GetStains();
            var reports = GetAllReportsLastMonth();
            IList<ReportByStain> reportByStains = new List<ReportByStain>();

            foreach (Stain s in stains)
            {
                var item = new ReportByStain() { Stain = s.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.StainName == s.Name)
                    {
                        item.Number++;
                    }
                }
                reportByStains.Add(item);
            }
            return reportByStains;
        }

        public IEnumerable<ReportByStain> GetReportByStainsForLastMonth(string UserId)
        {
            var stainRepo = new StainRepo();
            var stains = stainRepo.GetStains();
            var reports = GetAllReportsByUserLastMonth(UserId);
            IList<ReportByStain> reportByStains = new List<ReportByStain>();

            foreach (Stain s  in stains)
            {
                var item = new ReportByStain(){Stain = s.Name, Number=0};
                
                foreach(Report r in reports)
                {
                    if (r.StainName == s.Name)
                    {
                        item.Number++;
                    }
                }
                reportByStains.Add(item);
            }
            return reportByStains;
        }

        public IEnumerable<ReportByStain> GetReportByStainsForLastWeek()
        {
            var stainRepo = new StainRepo();
            var stains = stainRepo.GetStains();
            var reports = GetAllReportsLastWeek();
            IList<ReportByStain> reportByStains = new List<ReportByStain>();

            foreach (Stain s in stains)
            {
                var item = new ReportByStain() { Stain = s.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.StainName == s.Name)
                    {
                        item.Number++;
                    }
                }
                reportByStains.Add(item);
            }
            return reportByStains;
        }

        public IEnumerable<ReportByStain> GetReportByStainsForLastWeek(string UserId)
        {
            var stainRepo = new StainRepo();
            var stains = stainRepo.GetStains();
            var reports = GetAllReportsByUserIdLastWeek(UserId);
            IList<ReportByStain> reportByStains = new List<ReportByStain>();

            foreach (Stain s in stains)
            {
                var item = new ReportByStain() { Stain = s.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.StainName == s.Name)
                    {
                        item.Number++;
                    }
                }
                reportByStains.Add(item);
            }
            return reportByStains;
        }

        public IEnumerable<ReportByStain> GetReportByStainsForLastYear()
        {
            var stainRepo = new StainRepo();
            var stains = stainRepo.GetStains();
            var reports = GetAllReportsLastYear();
            IList<ReportByStain> reportByStains = new List<ReportByStain>();

            foreach (Stain s in stains)
            {
                var item = new ReportByStain() { Stain = s.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.StainName == s.Name)
                    {
                        item.Number++;
                    }
                }
                reportByStains.Add(item);
            }
            return reportByStains;
        }

        public IEnumerable<ReportByStain> GetReportByStainsForLastYear(string UserId)
        {
            var stainRepo = new StainRepo();
            var stains = stainRepo.GetStains();
            var reports = GetAllReportsByUserLastYear(UserId);
            IList<ReportByStain> reportByStains = new List<ReportByStain>();

            foreach (Stain s in stains)
            {
                var item = new ReportByStain() { Stain = s.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.StainName == s.Name)
                    {
                        item.Number++;
                    }
                }
                reportByStains.Add(item);
            }
            return reportByStains;
        }

        public IEnumerable<ReportByTissue> GetReportByTissuesForLastMonth()
        {
            var tissueRepo = new TissueRepo();
            var tissues = tissueRepo.GetTissues();
            var reports = GetAllReportsLastMonth();
            IList<ReportByTissue> reportByTissues = new List<ReportByTissue>();

            foreach (Tissue t in tissues)
            {
                var item = new ReportByTissue() { Tissue = t.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.TissueName == t.Name)
                    {
                        item.Number++;
                    }
                }
                reportByTissues.Add(item);
            }
            return reportByTissues;
        }

        public IEnumerable<ReportByTissue> GetReportByTissuesForLastMonth(string UserId)
        {
            var tissueRepo = new TissueRepo();
            var tissues = tissueRepo.GetTissues();
            var reports = GetAllReportsByUserLastMonth(UserId);
            IList<ReportByTissue> reportByTissues = new List<ReportByTissue>();

            foreach (Tissue t in tissues)
            {
                var item = new ReportByTissue() { Tissue = t.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.TissueName == t.Name)
                    {
                        item.Number++;
                    }
                }
                reportByTissues.Add(item);
            }
            return reportByTissues;
        }

        public IEnumerable<ReportByTissue> GetReportByTissuesForLastWeek()
        {
            var tissueRepo = new TissueRepo();
            var tissues = tissueRepo.GetTissues();
            var reports = GetAllReportsLastWeek();
            IList<ReportByTissue> reportByTissues = new List<ReportByTissue>();

            foreach (Tissue t in tissues)
            {
                var item = new ReportByTissue() { Tissue = t.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.TissueName == t.Name)
                    {
                        item.Number++;
                    }
                }
                reportByTissues.Add(item);
            }
            return reportByTissues;
        }

        public IEnumerable<ReportByTissue> GetReportByTissuesForLastWeek(string UserId)
        {
            var tissueRepo = new TissueRepo();
            var tissues = tissueRepo.GetTissues();
            var reports = GetAllReportsByUserIdLastWeek(UserId);
            IList<ReportByTissue> reportByTissues = new List<ReportByTissue>();

            foreach (Tissue t in tissues)
            {
                var item = new ReportByTissue() { Tissue = t.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.TissueName == t.Name)
                    {
                        item.Number++;
                    }
                }
                reportByTissues.Add(item);
            }
            return reportByTissues;
        }

        public IEnumerable<ReportByTissue> GetReportByTissuesForLastYear()
        {
            var tissueRepo = new TissueRepo();
            var tissues = tissueRepo.GetTissues();
            var reports = GetAllReportsLastYear();
            IList<ReportByTissue> reportByTissues = new List<ReportByTissue>();

            foreach (Tissue t in tissues)
            {
                var item = new ReportByTissue() { Tissue = t.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.TissueName == t.Name)
                    {
                        item.Number++;
                    }
                }
                reportByTissues.Add(item);
            }
            return reportByTissues;
        }

        public IEnumerable<ReportByTissue> GetReportByTissuesForLastYear(string UserId)
        {
            var tissueRepo = new TissueRepo();
            var tissues = tissueRepo.GetTissues();
            var reports = GetAllReportsByUserLastYear(UserId);
            IList<ReportByTissue> reportByTissues = new List<ReportByTissue>();

            foreach (Tissue t in tissues)
            {
                var item = new ReportByTissue() { Tissue = t.Name, Number = 0 };

                foreach (Report r in reports)
                {
                    if (r.TissueName == t.Name)
                    {
                        item.Number++;
                    }
                }
                reportByTissues.Add(item);
            }
            return reportByTissues;
        }

        public Report GetReportByWSI(Guid WSIId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.WSIId == WSIId).FirstOrDefault();
        }

        public int GetTotalNumberOfNegativeTests()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == false).ToList().Count;
        }

        public int GetTotalNumberOfNegativeTestsByUserId(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.UserId == UserId).ToList().Count;
        }

        public int GetTotalNumberOfNegativeTestsForLastMonth()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.Creation > DateTime.Now.AddMonths(-1)).ToList().Count;
        }

        public int GetTotalNumberOfNegativeTestsForLastMonthByUserId(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.Creation > DateTime.Now.AddMonths(-1) && r.UserId == UserId).ToList().Count;
        }

        public int GetTotalNumberOfNegativeTestsForLastWeek()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.Creation > DateTime.Now.AddDays(-7)).ToList().Count;
        }

        public int GetTotalNumberOfNegativeTestsForLastWeekByUserId(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.Creation > DateTime.Now.AddDays(-7) && r.UserId == UserId).ToList().Count;
        }

        public int GetTotalNumberOfNegativeTestsForLastYear()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.Creation > DateTime.Now.AddYears(-1)).ToList().Count;
        }

        public int GetTotalNumberOfNegativeTestsForLastYearByUserId(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == false && r.Creation > DateTime.Now.AddYears(-1) && r.UserId == UserId).ToList().Count;

        }

        public int GetTotalNumberOfPositiveTests()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == true).ToList().Count;
        }

        public int GetTotalNumberOfPositiveTestsByUserId(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.UserId == UserId).ToList().Count;
        }

        public int GetTotalNumberOfPositiveTestsForLastMonth()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.Creation > DateTime.Now.AddMonths(-1)).ToList().Count;

        }

        public int GetTotalNumberOfPositiveTestsForLastMonthByUserId(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.Creation > DateTime.Now.AddMonths(-1) && r.UserId == UserId).ToList().Count;

        }

        public int GetTotalNumberOfPositiveTestsForLastWeek()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.Creation > DateTime.Now.AddDays(-7)).ToList().Count;

        }

        public int GetTotalNumberOfPositiveTestsForLastWeekByUserId(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.Creation > DateTime.Now.AddDays(-7) && r.UserId == UserId).ToList().Count;

        }

        public int GetTotalNumberOfPositiveTestsForLastYear()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.Creation > DateTime.Now.AddYears(-1)).ToList().Count;

        }

        public int GetTotalNumberOfPositiveTestsForLastYearByUserId(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Evaluation == true && r.Creation > DateTime.Now.AddYears(-1) && r.UserId == UserId).ToList().Count;

        }

        public int GetTotalNumberOfTests()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.ToList().Count;
        }

        public int GetTotalNumberOfTestsByUserId(string UserId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.UserId == UserId).ToList().Count;
        }

        public int GetTotalNumberOfTestsForLastMonth()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Creation > DateTime.Now.AddMonths(-1)).ToList().Count;
        }

        public int GetTotalNumberOfTestsForLastMonthByUserId(string UserId)
        {
            var _context = new ApplicationDbContext();
            DateTime period = DateTime.Now.AddMonths(-1);
            return _context.Reports.Where(r => r.Creation > period && r.UserId == UserId).ToList().Count;
        }

        public int GetTotalNumberOfTestsForLastWeek()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Creation > DateTime.Now.AddDays(-7)).ToList().Count;
        }

        public int GetTotalNumberOfTestsForLastWeekByUserId(string UserId)
        {
            var _context = new ApplicationDbContext();
            DateTime period = DateTime.Now.AddDays(-7);
            return _context.Reports.Where(r => r.Creation > period && r.UserId == UserId).ToList().Count;
        }

        public int GetTotalNumberOfTestsForLastYear()
        {
            var _context = new ApplicationDbContext();
            return _context.Reports.Where(r => r.Creation > DateTime.Now.AddYears(-1)).ToList().Count;
        }

        public int GetTotalNumberOfTestsForLastYearByUserId(string UserId)
        {
            var _context = new ApplicationDbContext();
            DateTime period = DateTime.Now.AddYears(-1);
            return _context.Reports.Where(r => r.Creation > period && r.UserId == UserId).ToList().Count;
        }

        public void Insert(Report Report)
        {
            var _context = new ApplicationDbContext();
            _context.Reports.Add(Report);
            _context.SaveChanges();
        }
    }
}