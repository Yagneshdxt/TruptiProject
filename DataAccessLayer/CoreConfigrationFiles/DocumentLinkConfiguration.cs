using CoreEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class DocumentLinkConfiguration : EntityTypeConfiguration<DocumentLinks>
    {

        public DocumentLinkConfiguration()
        {
            HasKey(e => e.DocumentLinksId);
            Property(e => e.DocumentLinksId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            HasRequired(e => e.branch).WithMany().HasForeignKey(e => e.BranchId);
            HasRequired(e => e.academicYear).WithMany().HasForeignKey(e => e.AcademicYearId);
            HasRequired(e => e.documentType).WithMany().HasForeignKey(e => e.DocumentTypeId);
            Property(e => e.BranchId).IsRequired();
            Property(e => e.AcademicYearId).IsRequired();
            Property(e => e.DocumentTypeId).IsRequired();
            Property(e => e.DocumentPath).IsRequired();
        }
    }
}
