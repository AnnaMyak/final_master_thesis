using IdentitySample.Models;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities;
using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Implementation
{
    public class OrganRepo :IOrganRepo
    {
        public void Delete(Organ o)
        {
            var _context = new ApplicationDbContext();
            _context.Organs.Remove(o);
            _context.SaveChanges();
        }



        public Organ GetOrganByName(string Name)
        {
            var _context = new ApplicationDbContext();
            return _context.Organs.Find(Name);
        }


        public IEnumerable<Organ> GetOrgans()
        {
            var _context = new ApplicationDbContext();
            return _context.Organs.ToList();
        }

        public void Insert(string  Name)
        {
            var _context = new ApplicationDbContext();
            _context.Organs.Add(new Organ { Name=Name } );
            _context.SaveChanges();
        }

        public void Update(Organ o)
        {
            var _context = new ApplicationDbContext();
            _context.Entry(o).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}