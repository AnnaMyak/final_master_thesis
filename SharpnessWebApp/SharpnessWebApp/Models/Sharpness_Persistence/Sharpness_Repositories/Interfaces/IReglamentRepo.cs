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
        IEnumerable<Reglament> GetAllReglaments();
        Reglament GetReglamentById(Guid ReglamentId);
        Reglament GetReglamentByTitel(string Titel);
        void Insert(Reglament r);
        void Delete(Reglament r);
        void Update(Reglament r);
    }
}
