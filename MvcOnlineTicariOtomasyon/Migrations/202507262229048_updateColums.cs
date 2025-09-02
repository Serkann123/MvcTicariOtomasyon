namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateColums : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Faturalars", "TeslimEden", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Faturalars", "TeslimAlan", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faturalars", "TeslimAlan", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.Faturalars", "TeslimEden", c => c.String(maxLength: 10, unicode: false));
        }
    }
}
