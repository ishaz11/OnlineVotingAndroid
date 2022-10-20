namespace OnlineVotingAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addexl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Positions", "exclusive", c => c.Int());
            AddColumn("dbo.Positions", "Representative", c => c.Boolean(nullable: false));
            DropColumn("dbo.Candidates", "exclusive");
            DropColumn("dbo.Candidates", "Representative");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidates", "Representative", c => c.Boolean(nullable: false));
            AddColumn("dbo.Candidates", "exclusive", c => c.Int());
            DropColumn("dbo.Positions", "Representative");
            DropColumn("dbo.Positions", "exclusive");
        }
    }
}
