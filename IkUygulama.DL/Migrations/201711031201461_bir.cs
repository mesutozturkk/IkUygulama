namespace IkUygulama.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bir : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bolum",
                c => new
                    {
                        BolumId = c.Int(nullable: false, identity: true),
                        BolumAd = c.String(),
                    })
                .PrimaryKey(t => t.BolumId);
            
            CreateTable(
                "dbo.Personel",
                c => new
                    {
                        PersonelId = c.Int(nullable: false, identity: true),
                        PersonelAd = c.String(nullable: false),
                        PersonelSoyad = c.String(nullable: false),
                        Maas = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Email = c.String(nullable: false),
                        TelNo = c.Int(nullable: false),
                        DogumTarihi = c.DateTime(nullable: false),
                        IlceId = c.Int(nullable: false),
                        BolumId = c.Int(nullable: false),
                        UnvanId = c.Int(nullable: false),
                        EgitimId = c.Int(nullable: false),
                        YoneticiId = c.Int(),
                        YoneticiMi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelId)
                .ForeignKey("dbo.Bolum", t => t.BolumId, cascadeDelete: true)
                .ForeignKey("dbo.Egitim", t => t.EgitimId, cascadeDelete: true)
                .ForeignKey("dbo.Personel", t => t.YoneticiId)
                .ForeignKey("dbo.Ilce", t => t.IlceId, cascadeDelete: true)
                .ForeignKey("dbo.Unvan", t => t.UnvanId, cascadeDelete: true)
                .Index(t => t.IlceId)
                .Index(t => t.BolumId)
                .Index(t => t.UnvanId)
                .Index(t => t.EgitimId)
                .Index(t => t.YoneticiId);
            
            CreateTable(
                "dbo.Egitim",
                c => new
                    {
                        EgitimId = c.Int(nullable: false, identity: true),
                        EgitimAd = c.String(),
                    })
                .PrimaryKey(t => t.EgitimId);
            
            CreateTable(
                "dbo.Ilce",
                c => new
                    {
                        IlceId = c.Int(nullable: false, identity: true),
                        IlceAd = c.String(),
                        IlId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IlceId)
                .ForeignKey("dbo.Il", t => t.IlId, cascadeDelete: true)
                .Index(t => t.IlId);
            
            CreateTable(
                "dbo.Il",
                c => new
                    {
                        IlId = c.Int(nullable: false, identity: true),
                        IlAd = c.String(),
                    })
                .PrimaryKey(t => t.IlId);
            
            CreateTable(
                "dbo.Unvan",
                c => new
                    {
                        UnvanId = c.Int(nullable: false, identity: true),
                        UnvanAd = c.String(),
                    })
                .PrimaryKey(t => t.UnvanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personel", "UnvanId", "dbo.Unvan");
            DropForeignKey("dbo.Personel", "IlceId", "dbo.Ilce");
            DropForeignKey("dbo.Ilce", "IlId", "dbo.Il");
            DropForeignKey("dbo.Personel", "YoneticiId", "dbo.Personel");
            DropForeignKey("dbo.Personel", "EgitimId", "dbo.Egitim");
            DropForeignKey("dbo.Personel", "BolumId", "dbo.Bolum");
            DropIndex("dbo.Ilce", new[] { "IlId" });
            DropIndex("dbo.Personel", new[] { "YoneticiId" });
            DropIndex("dbo.Personel", new[] { "EgitimId" });
            DropIndex("dbo.Personel", new[] { "UnvanId" });
            DropIndex("dbo.Personel", new[] { "BolumId" });
            DropIndex("dbo.Personel", new[] { "IlceId" });
            DropTable("dbo.Unvan");
            DropTable("dbo.Il");
            DropTable("dbo.Ilce");
            DropTable("dbo.Egitim");
            DropTable("dbo.Personel");
            DropTable("dbo.Bolum");
        }
    }
}
