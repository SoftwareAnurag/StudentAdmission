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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public int AddStudent(StudentDto dto)
        {        

            // ✅ Range validation
            if (dto.DateOfBirth.Date < new DateTime(1900, 1, 1))
                throw new ArgumentException("Date of Birth must be after 1900.");

            var student = new Student
            {
                FullName = dto.FullName,
                DateOfBirth = dto.DateOfBirth.Date,
                Gender = dto.Gender,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                CreatedOn = DateTime.UtcNow
            };

         
            _repo.Add(student);
            return student.StudentId;
        }
    }
}
