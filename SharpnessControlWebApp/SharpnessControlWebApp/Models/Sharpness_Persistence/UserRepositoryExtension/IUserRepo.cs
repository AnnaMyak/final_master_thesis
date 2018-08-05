using SharpnessControlWebApp.Models.Sharpness_Persistence.Sharpness_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpnessControlWebApp.Models.Sharpness_Persistence.UserRepositoryExtension
{
    public interface IUserRepo
    {
        //Tracking number of Users
        int RegisteredUsersToday();
        int RegisteredUsersThisMonth();
        int RegisteredUsersThisYear();

        //Tracking list of Users
        IEnumerable<UserTracking> ListRegisteredUsersToday();
        
        IEnumerable<UserTracking> ListRegisteredUsersThisMonth();

        IEnumerable<UserTracking> ListRegisteredUsersThisYear();

        //Tracking Report for a Year
        IEnumerable<DynamicForAYear> RegistrationStatistik();
    }
}
