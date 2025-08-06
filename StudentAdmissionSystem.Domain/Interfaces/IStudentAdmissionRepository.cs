using StudentAdmissionSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Domain.Interfaces
{
    public interface IStudentAdmissionRepository
    {
        void Add(StudentAdmission admission);

        IEnumerable<StudentAdmission> GetAll();

        StudentAdmission GetById(int id);

    }
}
