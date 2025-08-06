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
    public class CoursesController : ApiController
    {
        private readonly ICourseService _courseService;

        // GET: Courses
        public CoursesController()
        {
            var context = new ApplicationDbContext();
            var repository = new CourseRepository(context);
            _courseService = new CourseService(repository);         
        }

        [HttpGet]
        [Route("api/courses")]
        public IHttpActionResult Get()
        {
            var courses = _courseService.GetAllCourses();
            return Ok(courses);
        }
    }
}