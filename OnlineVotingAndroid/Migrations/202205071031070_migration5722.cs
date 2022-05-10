namespace OnlineVotingAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration5722 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Votes", "ElectionID", c => c.Int());
            CreateIndex("dbo.Votes", "ElectionID");
            AddForeignKey("dbo.Votes", "ElectionID", "dbo.Elections", "ElectionID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "ElectionID", "dbo.Elections");
            DropIndex("dbo.Votes", new[] { "ElectionID" });
            DropColumn("dbo.Votes", "ElectionID");
        }
    }
}
