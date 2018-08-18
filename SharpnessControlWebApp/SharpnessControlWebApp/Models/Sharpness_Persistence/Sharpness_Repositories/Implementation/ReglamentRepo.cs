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
    public class ReglamentRepo:IReglamentRepo
    {

        public void Delete(Reglement r)
        {
            var _context = new ApplicationDbContext();
            _context.Reglaments.Remove(r);
            _context.SaveChanges();
        }

        public IEnumerable<Reglement> GetAllReglaments()
        {
            var _context = new ApplicationDbContext();
            return _context.Reglaments.ToList();

        }

        public Reglement GetReglamentById(Guid ReglamentId)
        {
            var _context = new ApplicationDbContext();
            return _context.Reglaments.Find(ReglamentId);
        }

        public Reglement GetReglamentByTitel(string Titel)
        {
            var _context = new ApplicationDbContext();
            return _context.Reglaments.Where(r => r.Titel == Titel).First();
        }

        public void Insert(Reglement r)
        {
            var _context = new ApplicationDbContext();
            _context.Reglaments.Add(r);
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