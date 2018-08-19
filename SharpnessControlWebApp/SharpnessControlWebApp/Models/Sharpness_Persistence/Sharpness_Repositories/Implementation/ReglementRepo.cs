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
    public class ReglementRepo:IReglementRepo
    {

        public void Delete(Reglement r)
        {
            var _context = new ApplicationDbContext();
            _context.Reglements.Remove(r);
            _context.SaveChanges();
        }

        public IEnumerable<Reglement> GetAllReglements()
        {
            var _context = new ApplicationDbContext();
            return _context.Reglements.ToList();

        }

        public Reglement GetReglementById(Guid ReglamentId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reglements.Find(ReglamentId);
        }

        public Reglement GetReglementByTitel(string Titel)
        {
            var _context = new ApplicationDbContext();
            return _context.Reglements.Where(r => r.Titel == Titel).First();
        }

        public void Insert(Reglement r)
        {
            var _context = new ApplicationDbContext();
            _context.Reglements.Add(r);
            _context.SaveChanges();
        }

        public void Update(Reglement r)
        {
            var _context = new ApplicationDbContext();
            _context.Entry(r).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}