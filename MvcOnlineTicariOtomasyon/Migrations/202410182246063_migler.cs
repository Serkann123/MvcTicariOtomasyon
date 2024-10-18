namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migler : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Adminİd = c.Int(nullable: false, identity: true),
                        KullanıcıAd = c.String(maxLength: 10, unicode: false),
                        Sifre = c.String(maxLength: 10, unicode: false),
                        Yetki = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Adminİd);
            
            CreateTable(
                "dbo.Carilers",
                c => new
                    {
                        Cariİd = c.Int(nullable: false, identity: true),
                        CariAdı = c.String(maxLength: 30, unicode: false),
                        CariSoyad = c.String(nullable: false, maxLength: 30, unicode: false),
                        CariSehir = c.String(maxLength: 13, unicode: false),
                        CariMail = c.String(maxLength: 50, unicode: false),
                        CariDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Cariİd);
            
            CreateTable(
                "dbo.SatisHarekets",
                c => new
                    {
                        Satısİd = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        Adet = c.Int(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToplamTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Urunİd = c.Int(nullable: false),
                        Cariİd = c.Int(nullable: false),
                        Personelİd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Satısİd)
                .ForeignKey("dbo.Carilers", t => t.Cariİd, cascadeDelete: true)
                .ForeignKey("dbo.Personels", t => t.Personelİd, cascadeDelete: true)
                .ForeignKey("dbo.Uruns", t => t.Urunİd, cascadeDelete: true)
                .Index(t => t.Urunİd)
                .Index(t => t.Cariİd)
                .Index(t => t.Personelİd);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        Personelİd = c.Int(nullable: false, identity: true),
                        PersonelAd = c.String(maxLength: 30, unicode: false),
                        personelSoyad = c.String(maxLength: 10, unicode: false),
                        personelGorsel = c.String(maxLength: 8000, unicode: false),
                        departmanİd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Personelİd)
                .ForeignKey("dbo.Departmen", t => t.departmanİd, cascadeDelete: true)
                .Index(t => t.departmanİd);
            
            CreateTable(
                "dbo.Departmen",
                c => new
                    {
                        Departmanİd = c.Int(nullable: false, identity: true),
                        DepartmanAd = c.String(maxLength: 30, unicode: false),
                        DepartmanStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Departmanİd);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        Urunİd = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(maxLength: 30, unicode: false),
                        Marka = c.String(maxLength: 30, unicode: false),
                        Stok = c.Short(nullable: false),
                        AlisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SatisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Durum = c.Boolean(nullable: false),
                        UrunGorsel = c.String(),
                        kategoriİd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Urunİd)
                .ForeignKey("dbo.Kategoris", t => t.kategoriİd, cascadeDelete: true)
                .Index(t => t.kategoriİd);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        İD = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.İD);
            
            CreateTable(
                "dbo.Detays",
                c => new
                    {
                        DetayId = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(maxLength: 50, unicode: false),
                        UrunBilgi = c.String(maxLength: 2000, unicode: false),
                    })
                .PrimaryKey(t => t.DetayId);
            
            CreateTable(
                "dbo.FaturaKalems",
                c => new
                    {
                        FaturaKalemİd = c.Int(nullable: false, identity: true),
                        Acıklama = c.String(maxLength: 100, unicode: false),
                        Miktar = c.Int(nullable: false),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Faturaİd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FaturaKalemİd)
                .ForeignKey("dbo.Faturalars", t => t.Faturaİd, cascadeDelete: true)
                .Index(t => t.Faturaİd);
            
            CreateTable(
                "dbo.Faturalars",
                c => new
                    {
                        Faturaİd = c.Int(nullable: false, identity: true),
                        FaturaSeriNo = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        FaturaSıraNo = c.String(maxLength: 6, unicode: false),
                        FaturaTarih = c.DateTime(nullable: false),
                        VergiDairesi = c.String(maxLength: 60, unicode: false),
                        Saat = c.String(maxLength: 5, fixedLength: true, unicode: false),
                        TeslimEden = c.String(maxLength: 10, unicode: false),
                        Toplam = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TeslimAlan = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Faturaİd);
            
            CreateTable(
                "dbo.Giders",
                c => new
                    {
                        Giderİd = c.Int(nullable: false, identity: true),
                        Acıklama = c.String(maxLength: 100, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Giderİd);
            
            CreateTable(
                "dbo.Yapilacaks",
                c => new
                    {
                        YapilacakId = c.Int(nullable: false, identity: true),
                        Başlik = c.String(maxLength: 100, unicode: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.YapilacakId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FaturaKalems", "Faturaİd", "dbo.Faturalars");
            DropForeignKey("dbo.SatisHarekets", "Urunİd", "dbo.Uruns");
            DropForeignKey("dbo.Uruns", "kategoriİd", "dbo.Kategoris");
            DropForeignKey("dbo.SatisHarekets", "Personelİd", "dbo.Personels");
            DropForeignKey("dbo.Personels", "departmanİd", "dbo.Departmen");
            DropForeignKey("dbo.SatisHarekets", "Cariİd", "dbo.Carilers");
            DropIndex("dbo.FaturaKalems", new[] { "Faturaİd" });
            DropIndex("dbo.Uruns", new[] { "kategoriİd" });
            DropIndex("dbo.Personels", new[] { "departmanİd" });
            DropIndex("dbo.SatisHarekets", new[] { "Personelİd" });
            DropIndex("dbo.SatisHarekets", new[] { "Cariİd" });
            DropIndex("dbo.SatisHarekets", new[] { "Urunİd" });
            DropTable("dbo.Yapilacaks");
            DropTable("dbo.Giders");
            DropTable("dbo.Faturalars");
            DropTable("dbo.FaturaKalems");
            DropTable("dbo.Detays");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Uruns");
            DropTable("dbo.Departmen");
            DropTable("dbo.Personels");
            DropTable("dbo.SatisHarekets");
            DropTable("dbo.Carilers");
            DropTable("dbo.Admins");
        }
    }
}
