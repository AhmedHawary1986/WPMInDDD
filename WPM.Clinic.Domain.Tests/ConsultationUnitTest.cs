using WPM.Clinic.Domain.Entities;
using WPM.Clinic.Domain.ValueObject;

namespace WPM.Clinic.Domain.Tests
{
    public class ConsultationUnitTest
    {
        [Fact]
        public void Consultation_Should_be_open()
        {
            var consultation = new Consultation(Guid.NewGuid());
            Assert.True(consultation.Status == ConsultationStatus.Open);
        }

        [Fact]

        public void Consultation_Should_not_have_ended()
        {
            var consultation = new Consultation(Guid.NewGuid());
            Assert.Null(consultation.EndedAt);
        }

        [Fact]
        public void Consultation_Should_not_end_when_missing_date()
        {
            var consultation = new Consultation(Guid.NewGuid());
            Assert.Throws<InvalidOperationException>(consultation.End);
        }

        [Fact]

        public void Consultation_Should_end_with_complete_date()
        {
            var consultation = new Consultation(Guid.NewGuid());
            consultation.SetTreatment("Treatment");
            consultation.SetWeight(1);
            consultation.SetDiagnosis("Diagnosis");
            consultation.End();
            Assert.True(consultation.Status== ConsultationStatus.Closed);
        }

        [Fact]

        public void Consultation_Should_Not_Allow_change_weight_When_status_is_closed()
        {
            var consultation = new Consultation(Guid.NewGuid());
            consultation.SetTreatment("Treatment");
            consultation.SetWeight(1);
            consultation.SetDiagnosis("Diagnosis");
            consultation.End();
            Assert.Throws<InvalidOperationException>(()=>consultation.SetWeight(12));
        }


        [Fact]

        public void Consultation_Should_Not_Allow_change_treatment_When_status_is_closed()
        {
            var consultation = new Consultation(Guid.NewGuid());
            consultation.SetTreatment("Treatment");
            consultation.SetWeight(1);
            consultation.SetDiagnosis("Diagnosis");
            consultation.End();
            Assert.Throws<InvalidOperationException>(() => consultation.SetTreatment("Treatment"));
        }

        [Fact]
        public void Consultation_shold_allow_adminstrate_drugs()
        {
            var drugId = new DrugId(Guid.NewGuid());
            var consultation = new Consultation(Guid.NewGuid());
            var dose = new Dose(1, UnitOgMeasure.tablet);
            consultation.AdmisteredDrugs(drugId, dose);
            Assert.True(consultation.Drugs.Count == 1);
            Assert.True(consultation.Drugs.First().DrugId == drugId);
        }

        [Fact]
        public void Consultation_shold_allow_register_vital_signs()
        {
           
            var consultation = new Consultation(Guid.NewGuid());
            IEnumerable<VitalSigns> vitalsigns = [new VitalSigns(38.8m, 100, 120)];
            consultation.RegisterVitalSigns(vitalsigns);
            Assert.True(consultation.VitalSignsReading.Count == 1);
            Assert.True(consultation.VitalSignsReading.First()== vitalsigns.First() );
        }
    }
}