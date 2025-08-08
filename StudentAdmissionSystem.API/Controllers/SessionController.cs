using StudentAdmissionSystem.Application.Interfaces;
using StudentAdmissionSystem.Application.Services;
using StudentAdmissionSystem.Infrastructure.Data;
using StudentAdmissionSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace StudentAdmissionSystem.API.Controllers
{
    public class SessionController : ApiController
    {
        private readonly ISessionService _sessionService;
        // API for Get Session List
        public SessionController() {

            var context = new ApplicationDbContext();
            var repository = new SessionRepository(context);
            _sessionService = new SessionService(repository);
        }

        [HttpGet]
        [Route("api/session")]
        public IHttpActionResult Get()
        {
            var session = _sessionService.GetAllSession();
            return Ok(session);
        }
    }
}