namespace OnlineVotingAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatestudentaddPartylistpartylistmembersplatform : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "YearnSection", c => c.String(nullable: false));
            AddColumn("dbo.Students", "isEnable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "isEnable");
            DropColumn("dbo.Students", "YearnSection");
            DropColumn("dbo.Students", "Date");
        }
    }
}
