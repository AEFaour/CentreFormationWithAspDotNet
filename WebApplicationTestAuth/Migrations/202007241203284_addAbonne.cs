namespace WebApplicationTestAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAbonne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonnes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prenom = c.String(nullable: false),
                        Tel = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Abonnes");
        }
    }
}
