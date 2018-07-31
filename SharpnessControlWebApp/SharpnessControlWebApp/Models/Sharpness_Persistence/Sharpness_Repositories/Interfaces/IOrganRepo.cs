using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Interfaces
{
    public interface IOrganRepo
    {

        IEnumerable<Organ> GetOrgans();

        Organ GetOrganByName(string Name);
        void Insert(string Name);
        void Delete(Organ o);
        void Update(Organ o);
    }
}
