using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPM.Management.Domain.Entities;

namespace WPM.Management.Domain.Interfaces
{
    public  interface IBreedServices
    {
        Breed GetBreed(Guid id);
    }
}
