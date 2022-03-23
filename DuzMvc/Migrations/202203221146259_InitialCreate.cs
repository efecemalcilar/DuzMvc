namespace DuzMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sahips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        DTarih = c.DateTime(storeType: "date"),
                        Idno = c.String(maxLength: 20),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(storeType: "date"),
                        UpdatedBy = c.String(maxLength: 50),
                        UpdatedDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasinmazs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Sehir = c.String(maxLength: 30),
                        Adres = c.String(maxLength: 330),
                        AlinisTarih = c.DateTime(storeType: "date"),
                        AlinisFiyat = c.Decimal(nullable: false, precision: 14, scale: 2),
                        SahipId = c.Int(nullable: false),
                        Aciklama = c.String(maxLength: 330),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(storeType: "date"),
                        UpdatedBy = c.String(maxLength: 50),
                        UpdatedDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sahips", t => t.SahipId, cascadeDelete: true)
                .Index(t => t.SahipId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasinmazs", "SahipId", "dbo.Sahips");
            DropIndex("dbo.Tasinmazs", new[] { "SahipId" });
            DropTable("dbo.Tasinmazs");
            DropTable("dbo.Sahips");
        }
    }
}
