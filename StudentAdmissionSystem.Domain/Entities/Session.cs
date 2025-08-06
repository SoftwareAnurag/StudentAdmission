using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Domain.Entities
{
    public class Session
    {
        [Key]
        public int SessionId { get; set; }
        public string SessionYear { get; set; }

        public bool IsActive { get; set; }

        public ICollection<StudentAdmission> Admissions { get; set; }
    }
}
