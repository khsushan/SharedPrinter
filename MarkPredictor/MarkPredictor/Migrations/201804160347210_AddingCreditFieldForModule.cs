namespace MarkPredictor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCreditFieldForModule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Modules", "Credit", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Modules", "Credit");
        }
    }
}
