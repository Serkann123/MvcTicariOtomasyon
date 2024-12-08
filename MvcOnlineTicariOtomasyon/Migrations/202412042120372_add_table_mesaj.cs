namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table_mesaj : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mesajlars",
                c => new
                    {
                        MesajId = c.Int(nullable: false, identity: true),
                        Gönderici = c.String(maxLength: 30, unicode: false),
                        Alici = c.String(maxLength: 50, unicode: false),
                        Konu = c.String(maxLength: 30, unicode: false),
                        İçerik = c.String(maxLength: 200, unicode: false),
                        Tarih = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.MesajId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mesajlars");
        }
    }
}
