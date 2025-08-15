using StudentAdmissionSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Application.Interfaces
{
    public interface IStudentAdmissionService
    {
        int CreateAdmission(StudentAdmissionDto stdAdmDto);
    }
}
