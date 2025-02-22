using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPM.Clinic.Domain.ValueObject
{
    public record Dose
    {
        public decimal Quantity { get; set; }
        public UnitOgMeasure Unit { get; init; }

        public Dose(decimal quantity, UnitOgMeasure unit)
        {
            this.Quantity = quantity;
            this.Unit = unit;
        }
    }

    public enum UnitOgMeasure
    {
        mg,
        ml,
        tablet
    }
}
