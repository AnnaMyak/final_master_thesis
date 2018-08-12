using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpnessControlWebApp.Models.Sharpness_Persistence.Sharpness_Repositories;
using IdentitySample.Models;

namespace SharpnessControlWebApp.Models.Sharpness_Persistence.UserRepositoryExtension
{
    public class UserRepo : IUserRepo
    {
        public IEnumerable<ApplicationUser> GetNotConfirmedUsers()
        {
            var _context = new ApplicationDbContext();

            return _context.Users.Where(u=> u.LockoutEndDateUtc > DateTime.UtcNow && u.LockoutEnabled==true).ToList();
        }

        public IEnumerable<UserTracking> ListRegisteredUsersThisMonth()
        {
            var _context = new ApplicationDbContext();
            var users = _context.Users.Where(u => u.RegistrationDate.Month == DateTime.Now.Month && u.RegistrationDate.Year == DateTime.Now.Year).ToList();
            var userTracking = new List<UserTracking>();
            foreach(var item in users)
            {
                userTracking.Add(new UserTracking() { Username = item.UserName,RegistrationDate=item.RegistrationDate });
            }

            return userTracking;
        }

        public IEnumerable<UserTracking> ListRegisteredUsersThisYear()
        {
            var _context = new ApplicationDbContext();
            var users= _context.Users.Where(u => u.RegistrationDate.Year == DateTime.Now.Year).ToList();
            var userTracking = new List<UserTracking>();
            foreach(var item in users)
            {
                userTracking.Add(new UserTracking() {Username=item.UserName, RegistrationDate=item.RegistrationDate });
            }
            return userTracking;
        }

        public IEnumerable<UserTracking> ListRegisteredUsersToday()
        {
            var _context = new ApplicationDbContext();
            var users = _context.Users.Where(u => u.RegistrationDate.Day == DateTime.Now.Day && u.RegistrationDate.Month == DateTime.Now.Month && u.RegistrationDate.Year == DateTime.Now.Year).ToList();
            var userTracking = new List<UserTracking>();
            foreach (var item in users)
            {
                userTracking.Add(new UserTracking() { Username = item.UserName, RegistrationDate = item.RegistrationDate });
            }

            return userTracking;
        }

        public int RegisteredUsersThisMonth()
        {
            var _context = new ApplicationDbContext();
            return _context.Users.Where(u => u.RegistrationDate.Month == DateTime.Now.Month && u.RegistrationDate.Year == DateTime.Now.Year).ToList().Count;
        }

        

        public int RegisteredUsersThisYear()
        {
            var _context = new ApplicationDbContext();
            return _context.Users.Where(u => u.RegistrationDate.Year == DateTime.Now.Year).ToList().Count;

        }

        public int RegisteredUsersToday()
        {
            var _context = new ApplicationDbContext();
            return _context.Users.Where(u => u.RegistrationDate.Day == DateTime.Now.Day).ToList().Count;
        }

        public IEnumerable<DynamicForAYear> RegistrationStatistik()
        {
            var _context = new ApplicationDbContext();
            var users = _context.Users.ToList();
            var statistik = new List<DynamicForAYear>();

            

            for (int i=1; i<=12; i++)
            {
                var record = new DynamicForAYear {Month=i, Number = 0 };
                foreach (var item in users)
                {
                    if (item.RegistrationDate.Month==i && item.RegistrationDate.Year == DateTime.Now.Year)
                    {
                        record.Number++;
                    }
                }
                statistik.Add(record); 
            }
            return statistik;
        }
    }
}