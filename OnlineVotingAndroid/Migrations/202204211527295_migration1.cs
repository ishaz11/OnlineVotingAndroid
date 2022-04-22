namespace OnlineVotingAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateID = c.Int(nullable: false, identity: true),
                        PositionId = c.Int(),
                        StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.CandidateID)
                .ForeignKey("dbo.Positions", t => t.PositionId)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .Index(t => t.PositionId)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        ElectionID = c.Int(),
                        PositionName = c.String(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PositionId)
                .ForeignKey("dbo.Elections", t => t.ElectionID)
                .Index(t => t.ElectionID);
            
            CreateTable(
                "dbo.Elections",
                c => new
                    {
                        ElectionID = c.Int(nullable: false, identity: true),
                        ElectionName = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ElectionID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentSchoolID = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Password = c.String(),
                        Date = c.DateTime(nullable: false),
                        YearnSection = c.String(nullable: false),
                        isEnable = c.Boolean(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.PartyListMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartyListID = c.Int(),
                        StudentID = c.Int(),
                        isOfficer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PartyLists", t => t.PartyListID)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .Index(t => t.PartyListID)
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
                        Role = c.String(),
                        isEnable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        VoteID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(),
                        CandidateID = c.Int(),
                        DateVoted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VoteID)
                .ForeignKey("dbo.Candidates", t => t.CandidateID)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .Index(t => t.StudentID)
                .Index(t => t.CandidateID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Votes", "CandidateID", "dbo.Candidates");
            DropForeignKey("dbo.Platforms", "PartyListID", "dbo.PartyLists");
            DropForeignKey("dbo.PartyListMembers", "StudentID", "dbo.Students");
            DropForeignKey("dbo.PartyListMembers", "PartyListID", "dbo.PartyLists");
            DropForeignKey("dbo.Candidates", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Candidates", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Positions", "ElectionID", "dbo.Elections");
            DropIndex("dbo.Votes", new[] { "CandidateID" });
            DropIndex("dbo.Votes", new[] { "StudentID" });
            DropIndex("dbo.Platforms", new[] { "PartyListID" });
            DropIndex("dbo.PartyListMembers", new[] { "StudentID" });
            DropIndex("dbo.PartyListMembers", new[] { "PartyListID" });
            DropIndex("dbo.Positions", new[] { "ElectionID" });
            DropIndex("dbo.Candidates", new[] { "StudentID" });
            DropIndex("dbo.Candidates", new[] { "PositionId" });
            DropTable("dbo.Votes");
            DropTable("dbo.Users");
            DropTable("dbo.SamplePersons");
            DropTable("dbo.Platforms");
            DropTable("dbo.PartyLists");
            DropTable("dbo.PartyListMembers");
            DropTable("dbo.Students");
            DropTable("dbo.Elections");
            DropTable("dbo.Positions");
            DropTable("dbo.Candidates");
        }
    }
}
