using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPM.Clinic.Domain.ValueObject;
using WPM.SharedKernel;

namespace WPM.Clinic.Domain.Entities
{
    public class DrugAdministration : Entity
    {
        public DrugId DrugId { get; init; }

        public Dose Dose { get; init; }

        public DrugAdministration(DrugId drugId, Dose dose)
        {
            Id = Guid.NewGuid();
            DrugId = drugId;
            Dose = dose;
        }
    }
}
