using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Domain.Entities
{
    public class StudentAdmission
    {
        [Key]
        public int AdmissionId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int SessionId { get; set; }
        public int StatusId { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }


        // Navigation Properties
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [ForeignKey("SessionId")]
        public Session Session { get; set; }

        [ForeignKey("StatusId")]
        public AdmissionStatus Status { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
