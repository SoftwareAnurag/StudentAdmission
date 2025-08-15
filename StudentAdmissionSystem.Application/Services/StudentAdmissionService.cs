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
    public class StudentAdmissionService : IStudentAdmissionService
    {
        private readonly IStudentAdmissionRepository _repo;

        public StudentAdmissionService(IStudentAdmissionRepository repo)
        {
            _repo = repo;
        }

        public int CreateAdmission(StudentAdmissionDto stdAdmDto) {

           
            var studentAdmission = new StudentAdmission
            {
                AdmissionId = stdAdmDto.AdmissionId,
                StudentId = stdAdmDto.StudentId,
                CourseId = stdAdmDto.CourseId.Value,
                SessionId = stdAdmDto.SessionId.Value,
                StatusId = stdAdmDto.StatusId.Value,
            
            };

            _repo.Add(studentAdmission);
            return studentAdmission.AdmissionId;
          
        }
        
    }
}
