using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPM.Clinic.Domain.Entities
{
    public class VitalSigns
    {
        Guid Id { get; init; }
        public DateTime ReadingDateTime { get; init; }

        public decimal Temperature { get; init; }


        public int HeartRate { get; init; }

        public int RespiratoryRate { get; init; }



        public VitalSigns(decimal temperature, int heartRate, int respiratoryRate)
        {
            Id = new Guid();
            ReadingDateTime = DateTime.UtcNow;
            Temperature = temperature;
            HeartRate = heartRate;
            RespiratoryRate = respiratoryRate;
        }
    }
}
