using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPM.Clinic.Domain.ValueObject
{
    public class DrugId
    {
        public Guid Value { get; init; }

        public DrugId(Guid value)
        {
            this.Value = value;
        }

        public static implicit operator DrugId(Guid value) { return new DrugId(value); }
    }
}
