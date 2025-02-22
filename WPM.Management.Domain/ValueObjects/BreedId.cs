using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WPM.Management.Domain.Interfaces;

namespace WPM.Management.Domain.ValueObjects
{
    public record BreedId
    {
        public readonly IBreedServices breedService;
        public Guid Value { get; init; }

        private BreedId(Guid value)
        {
            Value = value;
        }

        public static BreedId Create(Guid value)
        {
            return new BreedId(value);
        }

        public BreedId(Guid value,IBreedServices breedServices)
        {
            this.breedService = breedServices;
            validateBreed(value);
            Value = value;
        }

        private void validateBreed(Guid id) {

            if (breedService.GetBreed(id) == null)
            {
                throw new ArgumentException("Breed is not valid");
            }
        
        }
    }
}
