using CoreEntities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccessLayer
{
    internal class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            HasKey(e => e.StudentId);
            Property(e => e.FullName).IsRequired();
            Property(e => e.RollNo).IsRequired();
            Property(e => e.EnrollmentNo).IsRequired();
            HasRequired(e => e.branch).WithMany().HasForeignKey(e => e.BranchId);
            HasRequired(e => e.AcademicYear).WithMany().HasForeignKey(e => e.AcademicYearId);
        }
    }
}