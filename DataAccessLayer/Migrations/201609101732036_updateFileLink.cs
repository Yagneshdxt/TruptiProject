namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFileLink : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TimeTableLinks", "AcademicYearId", "dbo.AcademicYears");
            DropForeignKey("dbo.TimeTableLinks", "BranchId", "dbo.Branches");
            DropIndex("dbo.TimeTableLinks", new[] { "BranchId" });
            DropIndex("dbo.TimeTableLinks", new[] { "AcademicYearId" });
            CreateTable(
                "dbo.DocumentLinks",
                c => new
                    {
                        DocumentLinksId = c.Long(nullable: false, identity: true),
                        BranchId = c.Long(nullable: false),
                        AcademicYearId = c.Long(nullable: false),
                        DocumentTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentLinksId)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYearId, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeId, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.AcademicYearId)
                .Index(t => t.DocumentTypeId);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        DocumentTypeId = c.Long(nullable: false, identity: true),
                        DocumentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentTypeId);
            
            DropTable("dbo.TimeTableLinks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TimeTableLinks",
                c => new
                    {
                        TimeTableLinksId = c.Long(nullable: false, identity: true),
                        BranchId = c.Long(nullable: false),
                        AcademicYearId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TimeTableLinksId);
            
            DropForeignKey("dbo.DocumentLinks", "DocumentTypeId", "dbo.DocumentTypes");
            DropForeignKey("dbo.DocumentLinks", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.DocumentLinks", "AcademicYearId", "dbo.AcademicYears");
            DropIndex("dbo.DocumentLinks", new[] { "DocumentTypeId" });
            DropIndex("dbo.DocumentLinks", new[] { "AcademicYearId" });
            DropIndex("dbo.DocumentLinks", new[] { "BranchId" });
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.DocumentLinks");
            CreateIndex("dbo.TimeTableLinks", "AcademicYearId");
            CreateIndex("dbo.TimeTableLinks", "BranchId");
            AddForeignKey("dbo.TimeTableLinks", "BranchId", "dbo.Branches", "BranchId", cascadeDelete: true);
            AddForeignKey("dbo.TimeTableLinks", "AcademicYearId", "dbo.AcademicYears", "AcademicYearId", cascadeDelete: true);
        }
    }
}
