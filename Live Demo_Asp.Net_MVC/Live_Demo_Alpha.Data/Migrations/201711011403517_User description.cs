namespace Live_Demo_Alpha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Userdescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Description", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Description");
        }
    }
}
