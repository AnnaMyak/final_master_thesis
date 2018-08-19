using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Interfaces
{
    public interface IReglementRepo
    {
        IEnumerable<Reglement> GetAllReglements();
        Reglement GetReglementById(Guid ReglamentId);
        Reglement GetReglementByTitel(string Titel);
        void Insert(Reglement r);
        void Delete(Reglement r);
        void Update(Reglement r);
    }
}
