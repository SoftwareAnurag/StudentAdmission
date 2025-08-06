using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Application.DTOs
{
    public class StudentAdmissionDto
    {
        public int AdmissionId { get; set; }
        public string StudentFullName { get; set; }
        public string CourseName { get; set; }
        public string StatusName { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}
