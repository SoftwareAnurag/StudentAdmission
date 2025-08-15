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
   
    }
}
