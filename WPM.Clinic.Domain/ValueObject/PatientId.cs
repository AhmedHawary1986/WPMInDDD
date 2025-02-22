using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WPM.Clinic.Domain.ValueObject
{
    public class PatientId
    {
        public Guid Value { get; init; }

        public void validate(Guid value)
        {
            if(value == Guid.Empty)
            {

            throw new ArgumentNullException("Patient Id is not valid"); 
            }
        }

        public PatientId(Guid value) 
        {
            validate(value);

            this.Value = value;
        }

        public static implicit operator PatientId(Guid value) { return new PatientId(value); }
    }
}
