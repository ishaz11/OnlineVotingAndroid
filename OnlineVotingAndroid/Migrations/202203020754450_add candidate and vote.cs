namespace OnlineVotingAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcandidateandvote : DbMigration
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
            DropForeignKey("dbo.Candidates", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Candidates", "PositionId", "dbo.Positions");
            DropIndex("dbo.Votes", new[] { "CandidateID" });
            DropIndex("dbo.Votes", new[] { "StudentID" });
            DropIndex("dbo.Candidates", new[] { "StudentID" });
            DropIndex("dbo.Candidates", new[] { "PositionId" });
            DropTable("dbo.Votes");
            DropTable("dbo.Candidates");
        }
    }
}
