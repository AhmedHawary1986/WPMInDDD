using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPM.Management.Domain.ValueObjects;
using WPM.SharedKernel;

namespace WPM.Management.Domain.Entities
{
    public class Breed : Entity
    {
        public Breed(Guid id,
                     string name,
                     WeightRange maleRange,
                     WeightRange femaleRange)
        {
            Id = id;
            Name = name;
            MaleRange = maleRange;
            FemaleRange = femaleRange;
        }

        public string Name { get; init; }

        public WeightRange MaleRange { get; init; }

        public WeightRange FemaleRange { get; init; }
    }
}
