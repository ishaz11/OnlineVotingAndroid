namespace OnlineVotingAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exclusiv : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "exclusive", c => c.Int());
            AddColumn("dbo.Candidates", "Representative", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidates", "Representative");
            DropColumn("dbo.Candidates", "exclusive");
        }
    }
}
