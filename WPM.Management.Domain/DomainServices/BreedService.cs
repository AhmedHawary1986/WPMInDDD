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
    public class BreedService : IBreedServices
    {
        public readonly List<Breed> Breeds =
          [
           new Breed(Guid.Parse("58ddde05-baf8-4ac7-a26b-e1a92f0b7e2b"),"Beagle",new WeightRange(10.5m,20.5m),new WeightRange(5.5m,15.5m)),
             new Breed(Guid.Parse("30d59f51-1d08-4945-8462-06891a484f09"),"Staffordshire Terrier",new WeightRange(10.5m,20.5m),new WeightRange(5.5m,15.5m))
          ];
        public Breed GetBreed(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Breed is not valid");
            }

            var breed = Breeds.Find(x => x.Id == id);

            return breed ?? throw new ArgumentException("Breed was not found");
        }
    }
}
