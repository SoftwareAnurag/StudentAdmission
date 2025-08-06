using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAdmissionSystem.Domain.Entities;

namespace StudentAdmissionSystem.Domain.Interfaces
{
    public interface ISessionRepository
    {
        IEnumerable<Session> GetSessions();
    }
}
