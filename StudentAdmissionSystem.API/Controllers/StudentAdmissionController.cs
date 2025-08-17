using System.Linq;
using System.Web.Http;
using StudentAdmissionSystem.Application.DTOs;
using StudentAdmissionSystem.Application.Interfaces;
using StudentAdmissionSystem.Application.Services;
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


        [HttpGet]    
        [Route("api/admission/{stdID}")]
        public IHttpActionResult GetAdmDetailsByStdID(int stdID) {

            var admData = _service.GetAdmissionDetailsByStudentID(stdID);

            // Custom object return karo Angular ke liye
            var response = admData.Select(a => new
            {
                a.AdmissionId,
                a.FullName,
                a.Email,
                a.PhoneNumber,
                a.CourseName,
                a.CourseFee,
                a.StatusId,
                a.StatusName,
            });


            return Ok(new { response });

        }
    }
}