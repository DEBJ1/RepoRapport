namespace RepoRapport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstDataMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        JobID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        MemberID = c.Int(),
                    })
                .PrimaryKey(t => t.JobID)
                .ForeignKey("dbo.Member", t => t.MemberID)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Skillset = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MemberID);
            
            AddColumn("dbo.Report", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Report", "MemberId", c => c.Int());
            AddColumn("dbo.Report", "JobId", c => c.Int());
            CreateIndex("dbo.Report", "MemberId");
            CreateIndex("dbo.Report", "JobId");
            AddForeignKey("dbo.Report", "JobId", "dbo.Job", "JobID");
            AddForeignKey("dbo.Report", "MemberId", "dbo.Member", "MemberID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Report", "MemberId", "dbo.Member");
            DropForeignKey("dbo.Report", "JobId", "dbo.Job");
            DropForeignKey("dbo.Job", "MemberID", "dbo.Member");
            DropIndex("dbo.Job", new[] { "MemberID" });
            DropIndex("dbo.Report", new[] { "JobId" });
            DropIndex("dbo.Report", new[] { "MemberId" });
            DropColumn("dbo.Report", "JobId");
            DropColumn("dbo.Report", "MemberId");
            DropColumn("dbo.Report", "OwnerId");
            DropTable("dbo.Member");
            DropTable("dbo.Job");
        }
    }
}
