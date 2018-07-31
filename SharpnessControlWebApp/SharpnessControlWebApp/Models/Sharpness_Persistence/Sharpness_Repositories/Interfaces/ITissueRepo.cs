using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Interfaces
{
    public interface ITissueRepo
    {

        IEnumerable<Tissue> GetTissues();

        Tissue GetTissueByName(string Name);
        void Insert(string Name);
        void Delete(Tissue t);
        void Update(Tissue t);
    }
}
