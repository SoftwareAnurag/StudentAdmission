using StudentAdmissionSystem.Application.DTOs;
using StudentAdmissionSystem.Application.Interfaces;
using StudentAdmissionSystem.Application.Services;
using StudentAdmissionSystem.Infrastructure.Data;
using StudentAdmissionSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace StudentAdmissionSystem.API.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IStudentService _service;

        public StudentController()
        {
            var context = new ApplicationDbContext();
            // Manual initialization — tightly coupled
            _service = new StudentService(new StudentRepository(context));
        }

        [HttpPost]
        [Route("api/students")]
        public IHttpActionResult AddStudent([FromBody] StudentDto dto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);   // <-- no extra file
            }
               

            int studentId = _service.AddStudent(dto);
            return Ok(new { studentId });
        }
    }
}