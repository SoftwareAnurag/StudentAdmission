using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Domain.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]       
        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        [Required]
        public string Email { get; set; }


        [Required]
        public string PhoneNumber { get; set; }

        
        public string Address { get; set; }

        public DateTime? CreatedOn { get; set; }

        public ICollection<StudentAdmission> Admissions { get; set; }
    }
}
