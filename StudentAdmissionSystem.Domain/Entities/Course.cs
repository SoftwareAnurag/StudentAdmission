using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Domain.Entities
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public int DurationInMonths { get; set; }

        [Required]
        public Decimal Fees { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<StudentAdmission> Admissions { get; set; }
    }
}
