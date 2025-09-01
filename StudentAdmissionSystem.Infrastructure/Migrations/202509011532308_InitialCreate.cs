namespace StudentAdmissionSystem.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdmissionStatus",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.StudentAdmissions",
                c => new
                    {
                        AdmissionId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        SessionId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        AdmissionDate = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.AdmissionId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .ForeignKey("dbo.AdmissionStatus", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.SessionId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        DurationInMonths = c.Int(nullable: false),
                        Fees = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionId = c.Int(nullable: false, identity: true),
                        SessionYear = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SessionId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Address = c.String(),
                        CreatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentPayments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.String(),
                        PaymentStatus = c.String(),
                        RazorpayPaymentId = c.String(),
                        RazorpayOrderId = c.String(),
                        PaymentMethod = c.String(),
                        PaymentDate = c.DateTime(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.PaymentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentAdmissions", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentAdmissions", "StatusId", "dbo.AdmissionStatus");
            DropForeignKey("dbo.StudentAdmissions", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.StudentAdmissions", "CourseId", "dbo.Courses");
            DropIndex("dbo.StudentAdmissions", new[] { "StatusId" });
            DropIndex("dbo.StudentAdmissions", new[] { "SessionId" });
            DropIndex("dbo.StudentAdmissions", new[] { "CourseId" });
            DropIndex("dbo.StudentAdmissions", new[] { "StudentId" });
            DropTable("dbo.StudentPayments");
            DropTable("dbo.Students");
            DropTable("dbo.Sessions");
            DropTable("dbo.Courses");
            DropTable("dbo.StudentAdmissions");
            DropTable("dbo.AdmissionStatus");
        }
    }
}
