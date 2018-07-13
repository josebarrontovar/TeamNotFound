namespace WebFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProper : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataForms", "iconURL", c => c.String());
            AddColumn("dbo.DataForms", "DescriptionforCloud", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DataForms", "DescriptionforCloud");
            DropColumn("dbo.DataForms", "iconURL");
        }
    }
}
