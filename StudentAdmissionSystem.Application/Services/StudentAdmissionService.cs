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

        public IEnumerable<StudentAdmissionDto> GetAdmissionDetailsByStudentID(int StudentID) {

            // 1. Repository se data lao (Domain entities)
            var admList = _repo.GetAdmissionDetailsByStudentIDAsync(StudentID);

            // 2. Naya list banao for DTO
            var admissionDtoList = new List<StudentAdmissionDto>();

            // 3. Har Admission ko AdmissionDto me convert karo
            foreach (var list in admList)
            {
                var dto = new StudentAdmissionDto
                {
                    AdmissionId = list.AdmissionId,
                    FullName = list.Student.FullName,
                    Email = list.Student.Email,
                    PhoneNumber = list.Student.PhoneNumber,
                    CourseName = list.Course.CourseName,
                    CourseFee = list.Course.Fees,
                    StatusId = list.Status.StatusId,
                    StatusName = list.Status.StatusName,
                };

                admissionDtoList.Add(dto); // List me add karo
            }

            // 4. Final DTO list return karo
            return admissionDtoList;

        }


    }
}
