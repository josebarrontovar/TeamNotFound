namespace WebFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hola : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataForms", "NameC", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DataForms", "NameC");
        }
    }
}
