using CoreEntities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccessLayer
{
    internal class BranchConfiguration : EntityTypeConfiguration<Branch>
    {
        public BranchConfiguration()
        {
            HasKey(e => e.BranchId);
            Property(e => e.BranchId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(e => e.BranchName).IsRequired();
        }
    }
}