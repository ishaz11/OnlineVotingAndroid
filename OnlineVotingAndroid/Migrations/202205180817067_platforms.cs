namespace OnlineVotingAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class platforms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PartyLists", "Platform1", c => c.String());
            AddColumn("dbo.PartyLists", "Platform2", c => c.String());
            AddColumn("dbo.PartyLists", "Platform3", c => c.String());
            AddColumn("dbo.PartyLists", "Platform4", c => c.String());
            AddColumn("dbo.PartyLists", "Platform", c => c.String());
            AddColumn("dbo.PartyLists", "Platform6", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PartyLists", "Platform6");
            DropColumn("dbo.PartyLists", "Platform");
            DropColumn("dbo.PartyLists", "Platform4");
            DropColumn("dbo.PartyLists", "Platform3");
            DropColumn("dbo.PartyLists", "Platform2");
            DropColumn("dbo.PartyLists", "Platform1");
        }
    }
}
