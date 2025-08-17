using Org.BouncyCastle.Asn1.IsisMtt.X509;
using StudentAdmissionSystem.Domain.Entities;
using StudentAdmissionSystem.Domain.Interfaces;
using StudentAdmissionSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Infrastructure.Repositories
{
    public class StudentPaymentRepository : IStudentPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentPaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(StudentPayment payment)
        {       
            _context.StudentPayments.Add(payment);
            _context.SaveChanges();
        }


    }
}
