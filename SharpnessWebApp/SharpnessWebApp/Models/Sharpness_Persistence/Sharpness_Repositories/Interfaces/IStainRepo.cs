using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Repositories.Interfaces
{
    public interface IStainRepo 
    {

        IEnumerable<Stain> GetStains();

        Stain GetStainByName(string Name);
        void Insert(string Name);
        void Delete(Stain s);
        void Update(Stain s);
    }
}
