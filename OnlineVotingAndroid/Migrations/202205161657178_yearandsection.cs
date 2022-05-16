namespace OnlineVotingAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yearandsection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo._YearAndSection",
                c => new
                    {
                        YearAndSectionID = c.Int(nullable: false, identity: true),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => t.YearAndSectionID);
            
            AddColumn("dbo.Students", "YearAndSectionID", c => c.Int());
            AlterColumn("dbo.Students", "YearnSection", c => c.String());
            CreateIndex("dbo.Students", "YearAndSectionID");
            AddForeignKey("dbo.Students", "YearAndSectionID", "dbo._YearAndSection", "YearAndSectionID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "YearAndSectionID", "dbo._YearAndSection");
            DropIndex("dbo.Students", new[] { "YearAndSectionID" });
            AlterColumn("dbo.Students", "YearnSection", c => c.String(nullable: false));
            DropColumn("dbo.Students", "YearAndSectionID");
            DropTable("dbo._YearAndSection");
        }
    }
}
