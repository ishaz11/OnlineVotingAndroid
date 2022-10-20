namespace OnlineVotingAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removephoto : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "FileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "FileName", c => c.String());
        }
    }
}
