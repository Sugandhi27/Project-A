using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Models
{
    public class Appointment
    {
        [Key]
        [Required]
        [DisplayName("Appointment Id")]
        public int AppointmentId { get; set; }
        [Required]
        [DisplayName("Patient Id")]
        public int PatientID { get; set; }
        [Required]
        [DisplayName("Specialization Required")]
        public ASpecializationRequired SpecializationRequired { get; set; }
        [Required]
        [DisplayName("Doctor Name")]
        public string DoctorName { get; set; }
        [Required]
        [DisplayName("Visit Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{00:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime VisitDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayName("Visit Time")]
        public DateTime VisitTime { get; set; }
    }
    public enum ASpecializationRequired
    {
        General, Gynaecologist, Pediatrics, Orthopedics, Ophthalmology

    }
}

