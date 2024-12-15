namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMessage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Mesajlars", "İçerik", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Mesajlars", "İçerik", c => c.String(maxLength: 200, unicode: false));
        }
    }
}
