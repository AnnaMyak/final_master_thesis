using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities;
using SharpnessControlWebApp.Models.Sharpness_Persistence.Sharpness_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Interfaces
{
    public interface IReportRepo
    {
        //Liste
        IEnumerable<Report> GetAllReports();
        IEnumerable<Report> GetAllReportsLastWeek();
        IEnumerable<Report> GetAllReportsLastMonth();
        IEnumerable<Report> GetAllReportsLastYear();
        IEnumerable<Report> GetAllReportsByUserId(string UserId);
        IEnumerable<Report> GetAllReportsByUserIdLastWeek(string UserId);
        IEnumerable<Report> GetAllReportsByUserLastMonth(string UserId);
        IEnumerable<Report> GetAllReportsByUserLastYear(string UserId);




        IEnumerable<Report> GetAllReportByOrganAndUserId(string Organ, string UserId);
        IEnumerable<Report> GetAllPositiveReports();
        IEnumerable<Report> GetAllNegativeReports();

        IEnumerable<Report> GetAllPositiveReportsByUser(string UserId);
        IEnumerable<Report> GetAllNegativeReportsByUser(string UserId);

        IEnumerable<Report> GetAllPositiveReportsByOrgan(string Organ);
        IEnumerable<Report> GetAllNegativeReportsByOrgan(string Organ);

        IEnumerable<Report> GetAllPositiveReportsByOrganAndUserId(string Organ, string UserId);
        IEnumerable<Report> GetAllNegativeReportsByOrganAndUserId(string Organ, string UserId);


        IEnumerable<Report> GetAllPositiveReportsByUserLastWeek(string UserId);
        IEnumerable<Report> GetAllNegativeReportsByUserLastWeek(string UserId);
        IEnumerable<Report> GetAllPositiveReportsByUserLastMonth(string UserId);
        IEnumerable<Report> GetAllNegativeReportsByUserLastMonth(string UserId);
        IEnumerable<Report> GetAllPositiveReportsByUserLastYear(string UserId);
        IEnumerable<Report> GetAllNegativeReportsByUserLastYear(string UserId);



        //Report
        Report GetReportById(Guid ReportId);

        //ADMIN
        //Common
        int GetTotalNumberOfTests();
        int GetTotalNumberOfTestsForLastWeek();
        int GetTotalNumberOfTestsForLastMonth();
        int GetTotalNumberOfTestsForLastYear();

        //positive
        int GetTotalNumberOfPositiveTests();
        int GetTotalNumberOfPositiveTestsForLastWeek();
        int GetTotalNumberOfPositiveTestsForLastMonth();
        int GetTotalNumberOfPositiveTestsForLastYear();

        //negative
        int GetTotalNumberOfNegativeTests();
        int GetTotalNumberOfNegativeTestsForLastWeek();
        int GetTotalNumberOfNegativeTestsForLastMonth();
        int GetTotalNumberOfNegativeTestsForLastYear();

        //USER
        //common
        int GetTotalNumberOfTestsByUserId(string UserId);
        int GetTotalNumberOfTestsForLastWeekByUserId(string UserId);
        int GetTotalNumberOfTestsForLastMonthByUserId(string UserId);
        int GetTotalNumberOfTestsForLastYearByUserId(string UserId);

        //positive
        int GetTotalNumberOfPositiveTestsByUserId(string UserId);
        int GetTotalNumberOfPositiveTestsForLastWeekByUserId(string UserId);
        int GetTotalNumberOfPositiveTestsForLastMonthByUserId(string UserId);
        int GetTotalNumberOfPositiveTestsForLastYearByUserId(string UserId);

        //negative
        int GetTotalNumberOfNegativeTestsByUserId(string UserId);
        int GetTotalNumberOfNegativeTestsForLastWeekByUserId(string UserId);
        int GetTotalNumberOfNegativeTestsForLastMonthByUserId(string UserId);
        int GetTotalNumberOfNegativeTestsForLastYearByUserId(string UserId);

        Report GetReportByWSI(Guid WSIId);

        //Reports by Entities
        //By Stains and UserId
        IEnumerable<ReportByStain> GetReportByStainsForLastWeek(string UserId);
        IEnumerable<ReportByStain> GetReportByStainsForLastMonth(string UserId);
        IEnumerable<ReportByStain> GetReportByStainsForLastYear(string UserId);

        //By Stains 
        IEnumerable<ReportByStain> GetReportByStainsForLastWeek();
        IEnumerable<ReportByStain> GetReportByStainsForLastMonth();
        IEnumerable<ReportByStain> GetReportByStainsForLastYear();

        //By Organs and UserId
        IEnumerable<ReportByOrgan> GetReportByOrgansForLastWeek(string UserId);
        IEnumerable<ReportByOrgan> GetReportByOrgansForLastMonth(string UserId);
        IEnumerable<ReportByOrgan> GetReportByOrgansForLastYear(string UserId);

        //By Organs 
        IEnumerable<ReportByOrgan> GetReportByOrgansForLastWeek();
        IEnumerable<ReportByOrgan> GetReportByOrgansForLastMonth();
        IEnumerable<ReportByOrgan> GetReportByOrgansForLastYear();

        //By Tissues and UserId
        IEnumerable<ReportByTissue> GetReportByTissuesForLastWeek(string UserId);
        IEnumerable<ReportByTissue> GetReportByTissuesForLastMonth(string UserId);
        IEnumerable<ReportByTissue> GetReportByTissuesForLastYear(string UserId);

        //By Organs 
        IEnumerable<ReportByTissue> GetReportByTissuesForLastWeek();
        IEnumerable<ReportByTissue> GetReportByTissuesForLastMonth();
        IEnumerable<ReportByTissue> GetReportByTissuesForLastYear();

        //Statistik for a Year by Month
        IEnumerable<DynamicForAYear> GetDynamicForAYear();
        IEnumerable<DynamicForAYear> GetDynamicForAYearByUser(string UserId);



        //Sharpness research
        //positive
        int GetAllPositiveTestsByStainOrganTissueForALastMonth(string stain, string organ, string tissue);
        int GetAllPositiveTestsByStainOrganTissueForALast6Month(string stain, string organ, string tissue);
        int GetAllPositiveTestsByStainOrganTissueForALastYear(string stain, string organ, string tissue);

        //negative
        int GetAllNegativeTestsByStainOrganTissueForALastMonth(string stain, string organ, string tissue);
        int GetAllNegativeTestsByStainOrganTissueForALast6Month(string stain, string organ, string tissue);
        int GetAllNegativeTestsByStainOrganTissueForALastYear(string stain, string organ, string tissue);





        //CRUD

        void Insert(Report Report);
        void Delete(Report Report);

    }
}
