using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPM.Management.Domain.Entities;
using WPM.Management.Domain.Interfaces;
using WPM.Management.Domain.ValueObjects;

namespace WPM.Management.Domain.DomainServices
{
    public class FakeBreedService : IBreedServices
    {
        public readonly List<Breed> Breeds =
            [
             new Breed(Guid.NewGuid(),"Beagle",new WeightRange(10.5m,20.5m),new WeightRange(5.5m,15.5m)),
             new Breed(Guid.NewGuid(),"Staffordshire Terrier",new WeightRange(10.5m,20.5m),new WeightRange(5.5m,15.5m))
            ];
        public Breed GetBreed(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentException("Breed is not valid");
            }

            var breed = Breeds.Find(x=> x.Id == id);

            return breed ?? throw new ArgumentException("Breed was not found");
        }
    }
}
