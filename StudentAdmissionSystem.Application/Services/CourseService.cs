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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IEnumerable<CourseDto> GetAllCourses()
        {
            // 1. Repository se data lao (Domain entities)
            var courses = _courseRepository.GetCourses();

            // 2. Naya list banao for DTO
            var courseDtoList = new List<CourseDto>();

            // 3. Har Course ko CourseDto me convert karo
            foreach (var course in courses)
            {
                var dto = new CourseDto
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName
                };

                courseDtoList.Add(dto); // List me add karo
            }

            // 4. Final DTO list return karo
            return courseDtoList;
        }
    }
}
