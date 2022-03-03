namespace OnlineVotingAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpostionname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Positions", "PositionName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Positions", "PositionName");
        }
    }
}
