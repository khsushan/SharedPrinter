namespace MarkPredictor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeingCourseNameDatatypeToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Name", c => c.Long(nullable: false));
        }
    }
}
