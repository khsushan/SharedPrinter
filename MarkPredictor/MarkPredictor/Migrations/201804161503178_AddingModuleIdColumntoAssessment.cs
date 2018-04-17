namespace MarkPredictor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingModuleIdColumntoAssessment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assessments", "Module_Id", "dbo.Modules");
            DropIndex("dbo.Assessments", new[] { "Module_Id" });
            RenameColumn(table: "dbo.Assessments", name: "Module_Id", newName: "ModuleId");
            AlterColumn("dbo.Assessments", "ModuleId", c => c.Long(nullable: false));
            CreateIndex("dbo.Assessments", "ModuleId");
            AddForeignKey("dbo.Assessments", "ModuleId", "dbo.Modules", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assessments", "ModuleId", "dbo.Modules");
            DropIndex("dbo.Assessments", new[] { "ModuleId" });
            AlterColumn("dbo.Assessments", "ModuleId", c => c.Long());
            RenameColumn(table: "dbo.Assessments", name: "ModuleId", newName: "Module_Id");
            CreateIndex("dbo.Assessments", "Module_Id");
            AddForeignKey("dbo.Assessments", "Module_Id", "dbo.Modules", "Id");
        }
    }
}
