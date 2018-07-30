using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Interfaces
{
    public interface IWSIRepo
    {
        IEnumerable<WSI> GetWSIs();
        WSI GetById(Guid WSIId);
        WSI GetByTitel(string Titel);
        IEnumerable<WSI> GetAllWSIByUserId(string UserId);
        IEnumerable<WSI> GetRecentWSIByUSerId(string UserId);
        void Insert(WSI w);
        void Delete(WSI w);
        void Update(WSI w);
    }
}
