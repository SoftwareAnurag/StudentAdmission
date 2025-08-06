using StudentAdmissionSystem.Application.DTOs;
using StudentAdmissionSystem.Application.Interfaces;
using StudentAdmissionSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Application.Services
{
    public class StudentAdmissionService : IStudentAdmissionService
    {
        private readonly IStudentAdmissionRepository _repo;

        public StudentAdmissionService(IStudentAdmissionRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<StudentAdmissionDto> GetAllAdmissions()
        {
            var admissions = _repo.GetAll(); // returns IEnumerable<StudentAdmission> (entity)
            var dtos = admissions.Select(a => new StudentAdmissionDto
            {
                AdmissionId = a.AdmissionId,
                StudentFullName = a.Student.FullName,
                CourseName = a.Course.CourseName,
                StatusName = a.Status.StatusName,
                AdmissionDate = a.AdmissionDate
            });
            return dtos;
        }
    }
}
