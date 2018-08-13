using Sharpness.WebApp.Models.Sharpness_Persistence.Sharpness_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpnessControlWebApp.Utilities
{
    public interface ISharpnessManager
    {
        Reglament GetReglament();

        double[] GetSemaphoreValues(string path);
        double[] GetChannelsValues(string path);
    }
}
