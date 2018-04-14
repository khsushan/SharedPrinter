namespace MarkPredictor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assessments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AssessmentType = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        Mark = c.Int(nullable: false),
                        Module_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modules", t => t.Module_Id)
                .Index(t => t.Module_Id);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ModuleName = c.String(),
                        LevelId = c.Long(nullable: false),
                        CourseId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LevelName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModuleLevels",
                c => new
                    {
                        LevelId = c.Long(nullable: false),
                        CourseId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.LevelId, t.CourseId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModuleLevels", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.ModuleLevels", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Modules", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.Modules", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Assessments", "Module_Id", "dbo.Modules");
            DropIndex("dbo.ModuleLevels", new[] { "CourseId" });
            DropIndex("dbo.ModuleLevels", new[] { "LevelId" });
            DropIndex("dbo.Modules", new[] { "CourseId" });
            DropIndex("dbo.Modules", new[] { "LevelId" });
            DropIndex("dbo.Assessments", new[] { "Module_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.ModuleLevels");
            DropTable("dbo.Levels");
            DropTable("dbo.Courses");
            DropTable("dbo.Modules");
            DropTable("dbo.Assessments");
        }
    }
}
