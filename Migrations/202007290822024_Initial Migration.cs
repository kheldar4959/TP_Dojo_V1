namespace TP_Dojo_V1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Armes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Degats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArtMartials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Samourais",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Force = c.Int(nullable: false),
                        Nom = c.String(),
                        Arme_Id = c.Int(),
                        ArtMartial_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Armes", t => t.Arme_Id)
                .ForeignKey("dbo.ArtMartials", t => t.ArtMartial_Id)
                .Index(t => t.Arme_Id)
                .Index(t => t.ArtMartial_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Samourais", "ArtMartial_Id", "dbo.ArtMartials");
            DropForeignKey("dbo.Samourais", "Arme_Id", "dbo.Armes");
            DropIndex("dbo.Samourais", new[] { "ArtMartial_Id" });
            DropIndex("dbo.Samourais", new[] { "Arme_Id" });
            DropTable("dbo.Samourais");
            DropTable("dbo.ArtMartials");
            DropTable("dbo.Armes");
        }
    }
}
