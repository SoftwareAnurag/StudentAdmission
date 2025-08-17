using StudentAdmissionSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionSystem.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=StudentAdmissionContext") {
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(s => s.DateOfBirth)
                .HasColumnType("datetime");

            modelBuilder.Entity<Student>()
                .Property(s => s.CreatedOn)
                .HasColumnType("datetime");

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<StudentAdmission> StudentAdmissions { get; set; }
   
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<AdmissionStatus> AdmissionStatuses { get; set; }

        public DbSet<StudentPayment> StudentPayments { get; set; }
    }
}
