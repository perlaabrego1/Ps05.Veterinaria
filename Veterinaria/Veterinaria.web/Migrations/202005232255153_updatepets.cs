namespace Veterinaria.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "ImgUrl");
        }
    }
}
