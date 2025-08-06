using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Domain.Entities
{
    public class AdmissionStatus
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        public string StatusName { get; set; }

        public ICollection<StudentAdmission> Admissions { get; set; }
    }
}
