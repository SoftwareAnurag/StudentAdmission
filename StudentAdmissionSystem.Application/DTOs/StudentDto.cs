using System;
using System.ComponentModel.DataAnnotations;
namespace StudentAdmissionSystem.Application.DTOs
{
    public class StudentDto
    {
        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required, StringLength(1)]
        public string Gender { get; set; }

        [Required, EmailAddress, StringLength(150)]
        public string Email { get; set; }

        [Required, StringLength(15)]
        public string PhoneNumber { get; set; }
        [StringLength(300)]
        public string Address { get; set; }

        public DateTime? CreatedOn { get; set; }

    }
}
