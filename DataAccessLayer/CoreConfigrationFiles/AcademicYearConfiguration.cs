using CoreEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AcademicYearConfiguration : EntityTypeConfiguration<AcademicYear>
    {
        public AcademicYearConfiguration()
        {
            HasKey(e => e.AcademicYearId);
            Property(e => e.AcademicYearId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(e => e.AcademicYearName).IsRequired();
        }
    }
}
