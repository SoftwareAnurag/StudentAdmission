using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentAdmissionSystem.Domain.Entities;
using StudentAdmissionSystem.Domain.Interfaces;
using StudentAdmissionSystem.Infrastructure.Data;

namespace StudentAdmissionSystem.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context) {

            _context = context;
        }

        public IEnumerable<Course>  GetCourses()
        {
            return _context.Courses.ToList();
        }
    }
}
