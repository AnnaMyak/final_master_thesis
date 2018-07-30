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
    public class TissueRepo : ITissueRepo
    {
        public void Delete(Tissue t)
        {
            var _context = new ApplicationDbContext();
            _context.Tissues.Remove(t);
            _context.SaveChanges();
        }



        public Tissue GetTissueByName(string Name)
        {
            var _context = new ApplicationDbContext();
            return _context.Tissues.Find(Name);
        }


        public IEnumerable<Tissue> GetTissues()
        {
            var _context = new ApplicationDbContext();
            return _context.Tissues.ToList();
        }

        public void Insert(string Name)
        {
            var _context = new ApplicationDbContext();
            _context.Tissues.Add(new Tissue { Name = Name });
            _context.SaveChanges();
        }

        public void Update(Tissue t)
        {
            var _context = new ApplicationDbContext();
            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}