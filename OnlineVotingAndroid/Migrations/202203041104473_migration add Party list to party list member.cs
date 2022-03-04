namespace OnlineVotingAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationaddPartylisttopartylistmember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PartyListMembers", "PartyListID", c => c.Int());
            CreateIndex("dbo.PartyListMembers", "PartyListID");
            AddForeignKey("dbo.PartyListMembers", "PartyListID", "dbo.PartyLists", "PartyListID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartyListMembers", "PartyListID", "dbo.PartyLists");
            DropIndex("dbo.PartyListMembers", new[] { "PartyListID" });
            DropColumn("dbo.PartyListMembers", "PartyListID");
        }
    }
}
