using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Http;
using StudentAdmissionSystem.Application.DTOs;
using System.Web.Services.Description;
using StudentAdmissionSystem.Application.Interfaces;
using StudentAdmissionSystem.Application.Services;
using StudentAdmissionSystem.Domain.Entities;
using StudentAdmissionSystem.Domain.Interfaces;
using StudentAdmissionSystem.Infrastructure.Data;
using StudentAdmissionSystem.Infrastructure.Repositories;

namespace StudentAdmissionSystem.API.Controllers
{
    public class StudentAdmissionController : ApiController
    {
        private readonly IStudentAdmissionService _service;

        public StudentAdmissionController()
        {
            // Manual Dependency Injection
            var context = new ApplicationDbContext();
            var studentAdmRepo = new StudentAdmissionRepository(context);

           _service = new StudentAdmissionService(studentAdmRepo);

        }

        [HttpPost]
        [Route("api/admission")]
        public IHttpActionResult CreateAdmission(StudentAdmissionDto admissionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);   // <-- no extra file
            }

           int admissionID =  _service.CreateAdmission(admissionDto);

            return Ok(new { admissionID });
        }
    }
}