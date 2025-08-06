using StudentAdmissionSystem.Application.DTOs;
using StudentAdmissionSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Application.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<CourseDto> GetAllCourses();
    }
}
