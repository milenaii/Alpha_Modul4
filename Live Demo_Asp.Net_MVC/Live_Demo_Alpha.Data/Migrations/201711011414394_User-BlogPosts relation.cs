namespace Live_Demo_Alpha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserBlogPostsrelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogPosts", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BlogPosts", "ApplicationUserId");
            AddForeignKey("dbo.BlogPosts", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPosts", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.BlogPosts", new[] { "ApplicationUserId" });
            DropColumn("dbo.BlogPosts", "ApplicationUserId");
        }
    }
}
