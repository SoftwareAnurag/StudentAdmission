using StudentAdmissionSystem.Domain.Entities;
using StudentAdmissionSystem.Domain.Interfaces;
using StudentAdmissionSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;  // ✅ Required for Include() with lambda in EF6


namespace StudentAdmissionSystem.Infrastructure.Repositories
{
    public class StudentAdmissionRepository : IStudentAdmissionRepository 
    {
        private readonly ApplicationDbContext _context;

        public StudentAdmissionRepository(ApplicationDbContext context) { 
        
            _context = context;
        }

        public void Add(StudentAdmission admission) {

            _context.StudentAdmissions.Add(admission);
            _context.SaveChanges();
        }

        public IEnumerable<StudentAdmission> GetAdmissionDetailsByStudentIDAsync(int studentID)
        {
            // EF query based on join
            var admission =  _context.StudentAdmissions
                .Include(a => a.Student)  // join with Student table
                .Include(a => a.Course)   // join with Course table
                .Include(a => a.Status)   // join with Course table
                .Where(a => a.StudentId == studentID)
                .ToList();

            return admission;
        }

    }
}
