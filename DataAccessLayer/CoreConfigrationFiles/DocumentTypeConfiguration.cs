using CoreEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class DocumentTypeConfiguration : EntityTypeConfiguration<DocumentType>
    {
        public DocumentTypeConfiguration() {
            HasKey(e => e.DocumentTypeId);
            Property(e => e.DocumentTypeId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(e => e.DocumentTypeId).IsRequired();  
            Property(e => e.DocumentName).IsRequired();
        }

    }
}
