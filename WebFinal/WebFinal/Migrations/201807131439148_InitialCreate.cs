namespace WebFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Duration = c.Int(nullable: false),
                        City = c.Int(nullable: false),
                        NameCity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.NameCity_Id)
                .Index(t => t.NameCity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DataForms", "NameCity_Id", "dbo.Cities");
            DropIndex("dbo.DataForms", new[] { "NameCity_Id" });
            DropTable("dbo.DataForms");
            DropTable("dbo.Cities");
        }
    }
}
