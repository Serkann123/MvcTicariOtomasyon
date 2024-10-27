namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.mızık");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.mızık",
                c => new
                    {
                        mızıkId = c.Int(nullable: false, identity: true),
                        mızıkAd = c.String(),
                    })
                .PrimaryKey(t => t.mızıkId);
            
        }
    }
}
