namespace DoAnLapTrinhWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemTrend : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Trend", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Trend");
        }
    }
}
