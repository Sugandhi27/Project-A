using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagement.Models
{
    public class DoctorDetail
    {
        [Key]
        [DisplayName("Doctor ID")]
        public int DoctorID { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Sex { get; set; }
        [Range(1, 120, ErrorMessage = "Age must be between 1-120 in years.")]
        public int Age { get; set; }
        [Required]
        public DSpecialization Specialization { get; set; }
        [DataType(DataType.Time)]
        [DisplayName("From Time")]
        public DateTime FromTime { get; set; }
        [DataType(DataType.Time)]
        [DisplayName("To Time")]
        public DateTime ToTime { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
    }
    public enum DSpecialization
    {
        General, Gynaecologist, Pediatrics, Orthopedics, Ophthalmology
    }
}
