using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Application.DTOs
{
    public class SessionDto  
    {
        public int SessionId { get; set; }

        public string SessionYear { get; set; }

        public bool IsActive { get; set; }
    }
}
