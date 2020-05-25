namespace Veterinaria.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConsultDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        ConsultType = c.String(nullable: false, maxLength: 20),
                        Consult_Id = c.Int(),
                        Pet_Id = c.Int(nullable: false),
                        Veterinay_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consults", t => t.Consult_Id)
                .ForeignKey("dbo.Pets", t => t.Pet_Id, cascadeDelete: true)
                .ForeignKey("dbo.Veterinays", t => t.Veterinay_Id, cascadeDelete: true)
                .Index(t => t.Consult_Id)
                .Index(t => t.Pet_Id)
                .Index(t => t.Veterinay_Id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        PetType = c.String(nullable: false, maxLength: 20),
                        Age = c.Int(nullable: false),
                        BirthDAte = c.DateTime(nullable: false),
                        Color = c.String(maxLength: 30),
                        Race = c.String(nullable: false, maxLength: 15),
                        weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Application_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Application_Id)
                .Index(t => t.Application_Id);
            
            CreateTable(
                "dbo.Veterinays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 100),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Consult_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consults", t => t.Consult_Id)
                .Index(t => t.Consult_Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Managers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Histories", "Consult_Id", "dbo.Consults");
            DropForeignKey("dbo.Consults", "Veterinay_Id", "dbo.Veterinays");
            DropForeignKey("dbo.Veterinays", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Consults", "Pet_Id", "dbo.Pets");
            DropForeignKey("dbo.Pets", "Owner_Id", "dbo.Owners");
            DropForeignKey("dbo.Owners", "Application_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Consults", "Consult_Id", "dbo.Consults");
            DropIndex("dbo.Managers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Histories", new[] { "Consult_Id" });
            DropIndex("dbo.Veterinays", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Owners", new[] { "Application_Id" });
            DropIndex("dbo.Pets", new[] { "Owner_Id" });
            DropIndex("dbo.Consults", new[] { "Veterinay_Id" });
            DropIndex("dbo.Consults", new[] { "Pet_Id" });
            DropIndex("dbo.Consults", new[] { "Consult_Id" });
            DropColumn("dbo.AspNetUsers", "ImgUrl");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Managers");
            DropTable("dbo.Histories");
            DropTable("dbo.Veterinays");
            DropTable("dbo.Owners");
            DropTable("dbo.Pets");
            DropTable("dbo.Consults");
        }
    }
}
