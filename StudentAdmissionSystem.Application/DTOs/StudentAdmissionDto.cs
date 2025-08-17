using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Application.DTOs
{
    public class StudentAdmissionDto
    {
        public int AdmissionId { get; set; }

        [Required]
        public int StudentId { get; set; }
       
        [Required(ErrorMessage = "Course is required.")]
        public int? CourseId { get; set; }

        [Required(ErrorMessage = "Session is required.")]
        public int? SessionId { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public int? StatusId { get; set; }

        public DateTime? AdmissionDate { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        //Additional Propertes 
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CourseName { get; set; } 
        public decimal CourseFee { get; set; }
        public string StatusName { get; set; }

    }
}
