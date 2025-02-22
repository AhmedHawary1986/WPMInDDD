using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPM.SharedKernel
{
    public record Weight
    {
        public decimal Value { get; init; }

        public Weight(decimal value)
        {

            if (value < 0)
            {
                throw new ArgumentException("Value is not valid");
            }
            Value = value;
        }

        public static implicit operator Weight(decimal value) 
        { 
           return new Weight(value);
        }
    }
}
