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
        private readonly IStudentAdmissionRepository _repository;
        private readonly IStudentAdmissionService _studentAdmissionService;
      
        public StudentAdmissionController()
        {
            // Manual wiring (without DI)
            var context = new ApplicationDbContext();
            _repository = new StudentAdmissionRepository(context); // Infrastructure
            _studentAdmissionService = new StudentAdmissionService(_repository); // Application
        }

        [Route("api/admission")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {          
            var result = _studentAdmissionService.GetAllAdmissions();
            if (!result.Any()) return NotFound();
            return Ok(result);
        }

        /* [HttpGet]
         [Route("api/students")]
         public IHttpActionResult getAll() {

             var data = _repository.GetAll();
             if (data == null) return NotFound();
             return Ok(data);
         }*/

        [HttpGet]
        [Route("api/admission/{id}")]
        public IHttpActionResult getStudentByID(int id) {

            var item = _repository.GetById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

       /* [HttpPost]
        [Route("api/students")]
        public IHttpActionResult Create(StudentAdmission admission) {

            _repository.Add(admission);
            return Ok(admission);
        }       */

    }
}