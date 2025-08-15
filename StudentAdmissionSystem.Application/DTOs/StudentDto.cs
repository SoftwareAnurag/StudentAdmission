using System;
using System.ComponentModel.DataAnnotations;
namespace StudentAdmissionSystem.Application.DTOs
{
    public class StudentDto
    {      
        [Required(ErrorMessage = "FullName is required."), StringLength(100)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "DateOfBirth is required.")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required."), StringLength(1)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email is required."), EmailAddress, StringLength(150)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile Number is required."), StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(300)]
        public string Address { get; set; }

        public DateTime? CreatedOn { get; set; }

    }
}
