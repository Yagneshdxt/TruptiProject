using CoreEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DbContextClass : DbContext
    {
        public DbContextClass() : base("name=DefaultConnection") {

            
            Database.SetInitializer<DbContextClass>(new MigrateDatabaseToLatestVersion<DbContextClass, DataAccessLayer.Migrations.Configuration>("DefaultConnection"));
            //Database.SetInitializer<DbContextClass>(new CreateDatabaseIfNotExists<DbContextClass>());
            //Database.SetInitializer<DbContextClass>(new DropCreateDatabaseIfModelChanges<DbContextClass>());
            //Database.SetInitializer<DbContextClass>(new DropCreateDatabaseAlways<DbContextClass>());
            //Database.SetInitializer<DbContextClass>(new SchoolDBInitializer());
        }

        DbSet<AcademicYear> AcademicYear { get; set; }
        DbSet<Branch> Branch { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<DocumentLinks> TimeTableLinks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new AcademicYearConfiguration());
            modelBuilder.Configurations.Add(new BranchConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new DocumentTypeConfiguration());
            modelBuilder.Configurations.Add(new DocumentLinkConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
