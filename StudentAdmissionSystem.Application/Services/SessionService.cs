using StudentAdmissionSystem.Application.DTOs;
using StudentAdmissionSystem.Application.Interfaces;
using StudentAdmissionSystem.Domain.Entities;
using StudentAdmissionSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Application.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public IEnumerable<SessionDto> GetAllSession()
        {

            var sessions =  _sessionRepository.GetSessions();

            var sessionDtoList = new List<SessionDto>();

            foreach (var session in sessions) {

                var sessionDto = new SessionDto
                {

                    SessionId = session.SessionId,
                    SessionYear = session.SessionYear,
                    IsActive = session.IsActive,

                };
                 sessionDtoList.Add(sessionDto);
            }
            return sessionDtoList;
        }
    }
}
