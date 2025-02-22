using WPM.Clinic.Domain.Entities;
using WPM.Clinic.Domain.ValueObject;
using WPM.SharedKernel;

namespace WPM.Clinic.Domain
{
    public class Consultation : AggregrateRoot
    {
        public Text Diagnosis { get; private set; }

        public Text Treatment { get; private set; }

        public PatientId PatientId { get; init; }

        public Weight CurrentWeight { get; private set; }

        public ConsultationStatus Status { get; private set; }

        public DateTime StartedAt { get; init; }

        public DateTime? EndedAt { get; private set; }

        private readonly List<DrugAdministration> drugAdministrations = new();



        public IReadOnlyCollection<DrugAdministration> Drugs => drugAdministrations;

        private readonly List<VitalSigns> vitalSignsReading = new();

        public IReadOnlyCollection<VitalSigns> VitalSignsReading => vitalSignsReading;

        public Consultation(PatientId patientId)
        {
            Id = Guid.NewGuid();
            PatientId = patientId;
            Status = ConsultationStatus.Open;
            StartedAt = DateTime.UtcNow;
        }

      

        private void validateConsultation()
        {
            if(Status== ConsultationStatus.Closed)
            {
                throw new InvalidOperationException("Consultation is already closed");
            }
        }
        public void SetWeight(Weight weight)
        {
            validateConsultation();
        this.CurrentWeight = weight; 
        }

        public void SetDiagnosis(Text diagnosis)
        {
            validateConsultation();
            this.Diagnosis = diagnosis;
        }

        public void SetTreatment(Text treatment)
        {
            validateConsultation();
            this.Treatment = treatment;
        }

        public void End()
        {

        validateConsultation(); 
        
            if(Treatment ==null || Diagnosis == null || CurrentWeight == null)
            {
                throw new InvalidOperationException("The conultation can not be ended");
            }
            Status= ConsultationStatus.Closed;
            EndedAt = DateTime.UtcNow;
        
        }

        public void AdmisteredDrugs(DrugId drugId,Dose dose)
        {
            validateConsultation();
            var newDrugAdministration = new DrugAdministration(drugId, dose);
            drugAdministrations.Add(newDrugAdministration);
        }

        public void RegisterVitalSigns(IEnumerable<VitalSigns> vitalSigns)
        {
            validateConsultation();
            vitalSignsReading.AddRange(vitalSigns);
        }
    }

    public enum ConsultationStatus
    {
        Open=1,
        Closed=2
    }
}
