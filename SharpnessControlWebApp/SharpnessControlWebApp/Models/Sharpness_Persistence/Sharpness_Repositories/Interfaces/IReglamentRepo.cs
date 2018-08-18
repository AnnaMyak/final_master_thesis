using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Interfaces
{
    public interface IReglamentRepo
    {
        IEnumerable<Reglement> GetAllReglaments();
        Reglement GetReglamentById(Guid ReglamentId);
        Reglement GetReglamentByTitel(string Titel);
        void Insert(Reglement r);
        void Delete(Reglement r);
        void Update(Reglement r);
    }
}
