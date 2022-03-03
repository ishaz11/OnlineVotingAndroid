namespace OnlineVotingAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatestudentaddPartylistpartylistmembersplatform2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PartyListMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(),
                        isOfficer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.PartyLists",
                c => new
                    {
                        PartyListID = c.Int(nullable: false, identity: true),
                        PartyListName = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        isEnable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PartyListID);
            
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlatformDescription = c.String(nullable: false, maxLength: 50),
                        PartyListID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PartyLists", t => t.PartyListID)
                .Index(t => t.PartyListID);
            
            CreateTable(
                "dbo.SamplePersons",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        StudentID = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Password = c.String(),
                        Date = c.DateTime(nullable: false),
                        YearnSection = c.String(nullable: false),
                        Role = c.String(nullable: false),
                        isEnable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Platforms", "PartyListID", "dbo.PartyLists");
            DropForeignKey("dbo.PartyListMembers", "StudentID", "dbo.Students");
            DropIndex("dbo.Platforms", new[] { "PartyListID" });
            DropIndex("dbo.PartyListMembers", new[] { "StudentID" });
            DropTable("dbo.SamplePersons");
            DropTable("dbo.Platforms");
            DropTable("dbo.PartyLists");
            DropTable("dbo.PartyListMembers");
        }
    }
}
