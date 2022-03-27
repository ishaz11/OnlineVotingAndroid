namespace OnlineVotingAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addphoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Photo");
        }
    }
}
