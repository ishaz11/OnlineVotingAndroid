namespace OnlineVotingAndroid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removerolesample : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SamplePersons", "Role", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SamplePersons", "Role", c => c.String(nullable: false));
        }
    }
}
