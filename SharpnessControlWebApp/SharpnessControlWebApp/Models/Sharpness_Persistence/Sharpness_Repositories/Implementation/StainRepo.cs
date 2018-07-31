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
    public class StainRepo : IStainRepo
    {
        public void Delete(Stain s)
        {
            var _context = new ApplicationDbContext();
            _context.Stains.Remove(s);
            _context.SaveChanges();
        }



        public Stain GetStainByName(string Name)
        {
            var _context = new ApplicationDbContext();
            return _context.Stains.Find(Name);
        }


        public IEnumerable<Stain> GetStains()
        {
            var _context = new ApplicationDbContext();
            return _context.Stains.ToList();
        }

        public void Insert(string Name)
        {
            var _context = new ApplicationDbContext();
            _context.Stains.Add(new Stain { Name = Name });
            _context.SaveChanges();
        }

        public void Update(Stain s)
        {
            var _context = new ApplicationDbContext();
            _context.Entry(s).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}