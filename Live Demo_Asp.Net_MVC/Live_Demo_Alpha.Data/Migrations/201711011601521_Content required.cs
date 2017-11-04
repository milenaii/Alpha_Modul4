namespace Live_Demo_Alpha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contentrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlogPosts", "Content", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlogPosts", "Content", c => c.String(maxLength: 1000));
        }
    }
}
